using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamityMod;

namespace CalamitySouls.Projectiles
{
    public class PeerlessBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peerless Bullet");
            DisplayName.AddTranslation(GameCulture.Chinese, "无双弹");
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.timeLeft = 400;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            projectile.velocity *= 0.975f;
            projectile.velocity.Y += 0.3f;
            projectile.rotation = projectile.velocity.ToRotation();
            Lighting.AddLight(projectile.Center, 0.3f, 0.3f, 0f);
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 6; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.AmberBolt);
                dust.noGravity = true;
                dust.velocity = Vector2.Normalize(projectile.velocity) * 3f;
                dust.scale = Main.rand.Next(10, 31) / 10f;
            }
        }
    }
}