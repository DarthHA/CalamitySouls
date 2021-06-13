using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Projectiles.Typeless;
using static Terraria.ModLoader.ModContent;
using static CalamityMod.CalamityUtils;

namespace CalamitySouls.Items
{
    public abstract class TarragonLeaves : ModItem
    {
        public static int GetRandomTarragonLeaves()
        {
            switch (Main.rand.Next(8))
            {
                case 0:return ItemType<BurstLeaf>();
                case 1:return ItemType<DamageLeaf>();
                case 2:return ItemType<EnergyLeaf>();
                case 3:return ItemType<ExplosionLeaf>();
                case 4:return ItemType<HealLeaf>();
                case 5:return ItemType<ImmuLeaf>();
                case 6:return ItemType<RegenLeaf>();
                case 7:return ItemType<ShieldLeaf>();
            }
            return 0;
        }
        public static Projectile SpawnProj(int type, Vector2 position, Vector2 velocity, int damage)
        {
            Item item2 = Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem];
            Projectile proj = Projectile.NewProjectileDirect(position, velocity,
               type, damage, 0f, Main.LocalPlayer.whoAmI);
            if (!item2.IsAir) proj.GetItemDamageType(item2);
            return proj;
        }
        public override string Texture => "CalamitySouls/Items/TarragonLeaves";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Why its max stack must be 1? Figure it out yourself");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 22;
            item.rare = ItemRarityID.Expert;
        }
        public virtual int BuffType => 0;
        public virtual int BuffTime => 10 * 60;
        public override bool OnPickup(Player player)
        {
            player.AddBuff(BuffType, BuffTime);
            return false;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            gravity = 0f;
            float Dist = 16 * 100f;
            int me = -1;
            if (Main.netMode == NetmodeID.SinglePlayer) me = Main.myPlayer;
            else for (int i = 0; i < Main.player.Length; i++)
                {
                    Player player = Main.player[i];
                    if (player.active && !player.dead && player.Distance(item.Center) < Dist)
                    {
                        Dist = player.Distance(item.Center);
                        me = i;
                    }
                }
            if (me != -1)
            {
                item.velocity = Vector2.Lerp(item.velocity, item.DirectionTo(Main.player[me].Center) * 15f, 0.05f);
                item.beingGrabbed = true;
                item.isBeingGrabbed = true;
            }
        }
    }
    public class RegenLeaf : TarragonLeaves
    {
        public override int BuffType => BuffType<TarraLifeRegen>();
    }
    public class ShieldLeaf : TarragonLeaves
    {
        public override int BuffType => BuffType<Buffs.TarragonCloak>();
    }
    public class EnergyLeaf : TarragonLeaves
    {
        public override bool OnPickup(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SpawnProj(ProjectileType<TarraEnergy>(), player.Center, player.DirectionTo(Main.MouseWorld) * 8.5f, 20000);
            }
            return false;
        }
    }
    public class ExplosionLeaf : TarragonLeaves
    {
        public override bool OnPickup(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < 15; i++)
                {
                    Projectile explosion = SpawnProj(ProjectileID.CrystalLeafShot,
                        player.Center + player.DirectionTo(Main.MouseWorld) * 64f*i, Vector2.Zero, 8000);
                    explosion.timeLeft = 1;
                }
            }
            return false;
        }
    }
    public class BurstLeaf : TarragonLeaves
    {
        public override bool OnPickup(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < 10; i++)
                {
                    SpawnProj(ProjectileID.Leaf, player.Center, player.DirectionTo(Main.MouseWorld).RotatedByRandom(0.1f) * 12f, 500);
                }
            }
            return false;
        }
    }
    public class HealLeaf : TarragonLeaves
    {
        public override bool OnPickup(Player player)
        {
            player.lifeSteal -= 228;
            player.HealLife(38);
            return false;
        }
    }
    public class DamageLeaf : TarragonLeaves
    {
        public override bool OnPickup(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC npc2 = Main.npc[k];
                    if (npc2.active && !npc2.friendly && !npc2.dontTakeDamage && Vector2.Distance(player.Center, npc2.Center) <= 300f)
                    {
                        Projectile.NewProjectileDirect(npc2.Center, Vector2.Zero, ProjectileType<DirectStrike>(),
                            3000, 0f, player.whoAmI, k, 0f);
                    }
                }
            }
            for(int i = 0; i < 160; i++)
            {
                Dust dust = Dust.NewDustPerfect(player.Center + MathHelper.ToRadians(i * 360 / 160).ToRotationVector2() * 300f, 107);
                dust.noGravity = true;
                dust.velocity = Vector2.Zero;
                dust.scale = 1.2f;
            }
            return false;
        }
    }
    public class ImmuLeaf : TarragonLeaves
    {
        public override int BuffType => BuffType<Buffs.TarragonImmunity>();
        public override int BuffTime => 2 * 60;
    }
}