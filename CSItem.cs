using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.TreasureBags;
using CalamityMod.Projectiles.Melee;
using System.Collections.Generic;
using CalamitySouls.Items.BossLoots;

namespace CalamitySouls
{
    public class CSItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            return CSPlayerEffects.UseItem(item, player);
        }
        public override float UseTimeMultiplier(Item item, Player player)
        {
            CSPlayer mplayer = player.CS();
            float Multiplier = 1f;
            if (item.damage > 0) Multiplier *= mplayer.WeaponFireRateBoost;
            return Multiplier;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Main.LocalPlayer.CS().AuricWeaponBoost)
            {
                Color AuricGold = Color.Lerp(Main.DiscoColor, Color.Gold, 0.75f);
                if (item.type == ItemType<TrueTyrantYharimsUltisword>() || item.type == ItemType<DevilsDevastation>() || item.type == ItemType<DarkSpark>()
                    || item.type == ItemType<Keelhaul>() || item.type == ItemType<PhantasmalRuin>())
                {
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                        {
                            line.overrideColor = AuricGold;
                            break;
                        }
                    }
                }
            }
        }
        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            SwitchTexture();
            return true;
        }
        private void SwitchTexture()
        {
            if (Main.LocalPlayer.CS().AuricWeaponBoost)
            {
                Main.itemTexture[ItemType<TrueTyrantYharimsUltisword>()] = GetTexture("CalamitySouls/Extras/AuricWeapon1");
                Main.itemTexture[ItemType<DevilsDevastation>()] = GetTexture("CalamitySouls/Extras/AuricWeapon2");
                Main.itemTexture[ItemType<DarkSpark>()] = GetTexture("CalamitySouls/Extras/AuricWeapon3");
                Main.itemTexture[ItemType<Keelhaul>()] = GetTexture("CalamitySouls/Extras/AuricWeapon4");
                Main.itemTexture[ItemType<PhantasmalRuin>()] = GetTexture("CalamitySouls/Extras/AuricWeapon5");
                Main.projectileTexture[ProjectileType<HyperBlade>()] = GetTexture("CalamitySouls/Extras/AuricProj1-1");
                Main.projectileTexture[ProjectileType<Oathblade>()] = GetTexture("CalamitySouls/Extras/AuricProj2-1");
                Main.projectileTexture[ProjectileType<DemonBlast>()] = GetTexture("CalamitySouls/Extras/AuricProj2-2");
            }
            else
            {
                Main.itemTexture[ItemType<TrueTyrantYharimsUltisword>()] = GetTexture("CalamityMod/Items/Weapons/Melee/TrueTyrantYharimsUltisword");
                Main.itemTexture[ItemType<DevilsDevastation>()] = GetTexture("CalamityMod/Items/Weapons/Melee/DevilsDevastation");
                Main.itemTexture[ItemType<DarkSpark>()] = GetTexture("CalamityMod/Items/Weapons/Magic/DarkSpark");
                Main.itemTexture[ItemType<Keelhaul>()] = GetTexture("CalamityMod/Items/Weapons/Magic/Keelhaul");
                Main.itemTexture[ItemType<PhantasmalRuin>()] = GetTexture("CalamityMod/Items/Weapons/Rogue/PhantasmalRuin");
                Main.projectileTexture[ProjectileType<HyperBlade>()] = GetTexture("CalamityMod/Projectiles/Melee/HyperBlade");
                Main.projectileTexture[ProjectileType<Oathblade>()] = GetTexture("CalamityMod/Projectiles/Melee/Oathblade");
                Main.projectileTexture[ProjectileType<DemonBlast>()] = GetTexture("CalamityMod/Projectiles/Melee/DemonBlast");
            }
        }
        public override float MeleeSpeedMultiplier(Item item, Player player)
        {
            if (player.CS().AuricWeaponBoost)
            {
                if (item.type == ItemType<TrueTyrantYharimsUltisword>()) return 1.5f;
            }
            return 1f;
        }
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (player.CS().AuricWeaponBoost)
            {
                if (item.type == ItemType<TrueTyrantYharimsUltisword>())
                {
                    damage *= 20;
                }
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemType<TrueTyrantYharimsUltisword>())
            {
                if (player.CS().AuricWeaponBoost)
                {
                    item.scale = 2f;
                    item.UseSound = SoundID.Item71;
                }
                else
                {
                    item.scale = 1f;
                    item.UseSound = SoundID.Item1;
                }
            }
            return true;
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 velocity = new Vector2(speedX, speedY);
            if (player.CS().AuricWeaponBoost)
            {
                if (item.type == ItemType<TrueTyrantYharimsUltisword>())
                {
                    type = ProjectileType<HyperBlade>();
                    Projectile slash = Projectile.NewProjectileDirect(position, velocity * 2f, type, damage * 4, 0f, player.whoAmI);
                    slash.penetrate = -1;
                    slash.extraUpdates = 4;
                    slash.usesLocalNPCImmunity = true;
                    slash.localNPCHitCooldown = 45;
                    slash.timeLeft = 300;
                    return false;
                }
                if (item.type == ItemType<DevilsDevastation>())
                {
                    Projectile fork = Projectile.NewProjectileDirect(position, velocity, type, damage * 15, knockBack * 3f, player.whoAmI);
                    fork.penetrate = -1;
                    fork.localNPCHitCooldown = 60;
                    fork.usesLocalNPCImmunity = true;
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 pos = position - Vector2.Normalize(velocity) * 960f + new Vector2(Main.rand.Next(-300, 301), Main.rand.Next(-300, 301));
                        Vector2 velo = Vector2.Normalize(Main.MouseWorld - pos) * 25f;
                        Projectile.NewProjectileDirect(pos, velo, ProjectileType<DemonBlast>(), damage * 5, knockBack, player.whoAmI);
                    }
                    return false;
                }
                if (item.type == ItemType<Keelhaul>()) 
                {
                    damage *= 50;
                    return true;
                }
                if (item.type == ItemType<PhantasmalRuin>())
                {
                    damage *= 3;
                    Projectile pr = Projectile.NewProjectileDirect(position, velocity, type, damage, knockBack, player.whoAmI);
                    pr.extraUpdates = (pr.extraUpdates + 1) * 2 - 1;
                    pr.timeLeft *= 2;
                    return false;
                }
            }
            return true;
        }
        public override void RightClick(Item item, Player player)
        {
            if (CSWorld.HyperMode)
            {
                if (item.type == ItemType<SlimeGodBag>()) Item.NewItem(player.Center, ItemType<CoreofSlimeGod>());
            }
        }
    }
}