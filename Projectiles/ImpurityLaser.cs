using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace CalamitySouls.Projectiles
{
    public class ImpurityLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impurity Laser");
            DisplayName.AddTranslation(GameCulture.Chinese, "邪秽激光");
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 22;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.soundDelay = 2;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 2;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 120;
        }
        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 20) projectile.tileCollide = true;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.Next(5) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 86);
                dust.noGravity = true;
                dust.noLight = false;
                dust.velocity = Vector2.Normalize(projectile.velocity) * 3f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item30, projectile.Center);
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustPerfect(projectile.Center, 86);
                dust.noGravity = true;
                dust.noLight = false;
                dust.velocity = Vector2.Normalize(projectile.velocity) * Main.rand.Next(7) + CSUtils.RandomRotate;
                dust.scale *= 2f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 5 * 60);
        }
    }
}