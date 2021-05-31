using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class FearmongerAreaProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 500;
            projectile.timeLeft = 5 * 60;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 155;
        }
        public override void AI()
        {
            projectile.velocity = Vector2.Zero;
            projectile.scale = 2f;
            int rand = Main.rand.Next(360);
            for (int i = 0; i < 36; i++)
            {
                Vector2 rot = MathHelper.ToRadians(360 * i / 36f + rand).ToRotationVector2() * Main.rand.Next(20, 500);
                Dust dust = Dust.NewDustPerfect(projectile.Center + rot, 92);
                dust.noGravity = true; dust.velocity = Vector2.Zero; dust.scale *= 0.4f;
            }
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.Distance(projectile.Center) < 500f)
                    projectile.position -= projectile.velocity;
            }
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.Distance(projectile.Center) < 500f)
                    npc.position -= npc.velocity;
            }
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player1 = Main.player[i];
                if (player1.active && !player1.dead && player1.Distance(projectile.Center) < 500)
                    player1.position -= player1.velocity / 2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && ((projectile.hostile && !projectile.friendly) || projectile.type == ProjectileType<CalamityMod.Projectiles.Boss.HealOrbProv>())
                    && projectile.Distance(base.projectile.Center) < 500f
                    && !CalamityMod.CalamityLists.projectileDestroyExceptionList.Contains(projectile.type)) 
                {
                    Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, 0, 0f, 255);
                    projectile.Kill();
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin();
        }
    }
}