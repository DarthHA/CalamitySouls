using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class PeerlessWind : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peerless Wind");
            DisplayName.AddTranslation(GameCulture.Chinese, "无双之风");
            CalamityLists.projectileDestroyExceptionList.Add(projectile.type);
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;            
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;            
        }
        public override void SetDefaults()
        {
            projectile.width = 112;
            projectile.height = 14;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.timeLeft = 60;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            projectile.alpha = 0;
            projectile.rotation = projectile.velocity.ToRotation();
            Lighting.AddLight(projectile.Center, 0.3f, 0.3f, 0f);
            if (Main.rand.Next(30) == 0)
            {
                if (projectile.owner == Main.myPlayer)
                {
                    int amt = Main.rand.Next(2, 5);
                    for (int i = 0; i < amt; i++)
                        Projectile.NewProjectile(projectile.Center + CSUtils.RandomRotate * Main.rand.Next(0, 32), CSUtils.RandomRotate * 5f,
                            ModContent.ProjectileType<PeerlessBullet>(), projectile.damage / 2, 0f, projectile.owner);
                }
            }
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            for (int i = -3; i < 5; i++) if (targetHitbox.Distance(projectile.Center + Vector2.Normalize(projectile.velocity) * 14 * i) < 7f) return true;
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            CalamityMod.Projectiles.CalamityGlobalProjectile.DrawCenteredAndAfterimage(projectile, Color.White, 1);
            return false;
        }
    }
}