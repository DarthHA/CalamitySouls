using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CalamitySouls.Buffs;
using CalamitySouls.Projectiles;
using CalamityMod.Buffs.Summon;
using CalamityMod.Projectiles.Summon;
using CalamityMod;
using static Terraria.ModLoader.ModContent;
using static System.Math;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class SlimeGodMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 32;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead || !player.Calamity().slimeGod)
            {
                projectile.active = false;
                return;
            }
            projectile.timeLeft = 2;
            if (!player.inventory[player.selectedItem].IsAir)
            {
                projectile.GetItemDamageType(player.inventory[player.selectedItem]);
            }
            int index = -1;
            float minDist = 480f;
            float maxDist = 800f;
            float acc1 = 0.97f;
            float acc2 = 1.6f;
            bool ignoreImmunity = false;
            if (player.CS().StatigelTeleport)
            {
                minDist = 120f;
                maxDist = 160f;
                acc1 = 0f;
                acc2 = 16f;
            }
            if (player.HasMinionAttackTargetNPC && Main.npc[player.MinionAttackTargetNPC].Distance(player.Center) < maxDist) index = player.MinionAttackTargetNPC;
            else
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && (npc.CanBeChasedBy(projectile) || ignoreImmunity) && !npc.dontTakeDamage
                        && !npc.friendly && npc.Distance(projectile.Center) < minDist && npc.Distance(player.Center) < maxDist) 
                    {
                        index = i;
                        minDist = npc.Distance(projectile.Center);
                    }
                }
            }
            Vector2 iCenter = player.Center;
            if (index != -1) iCenter = Main.npc[index].Center;
            projectile.velocity *= acc1;
            projectile.velocity += projectile.DirectionTo(iCenter) * acc2;
            if (projectile.Distance(player.Center) > maxDist) projectile.Center = player.Center + player.DirectionTo(projectile.Center) * maxDist;
            projectile.rotation += MathHelper.Clamp(projectile.velocity.X, -0.1f, 0.1f);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = GetTexture(Texture);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, lightColor, projectile.rotation,
                texture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            for (int i = 0; i < 5; i++)
            {
                lightColor *= 0.6f;
                spriteBatch.Draw(texture, projectile.oldPos[i] + texture.Size() / 2f - Main.screenPosition, null, lightColor, projectile.rotation,
                  texture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}