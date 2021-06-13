using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamitySouls.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Projectiles
{
    public class FrostPaintball : ModProjectile
    {
        public override string Texture => CSUtils.BlankTexture;
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.width = projectile.height = 8;
            projectile.extraUpdates = 3;
            projectile.soundDelay = 2;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
            projectile.timeLeft = 200;
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0)
            {
                projectile.soundDelay = 0;
                projectile.ai[0] = Main.rand.Next(2);
                projectile.penetrate = (int)projectile.ai[0] + 1;
                for (int i = 0; i < 10; i++)
                {
                    Dust dust1 = Dust.NewDustPerfect(projectile.Center, projectile.ai[0] == 0 ? 76 : 92);
                    dust1.noGravity = true;
                    dust1.noLight = true;
                    dust1.velocity = Vector2.Normalize(projectile.velocity) * 2.5f + CSUtils.RandomRotate * 2f;
                }
            }
            if (projectile.velocity.Y < 20f) projectile.velocity.Y += 0.05f;
            Dust dust = Dust.NewDustPerfect(projectile.Center, projectile.ai[0] == 0 ? 76 : 92);
            dust.noGravity = true;
            dust.noLight = true;
            dust.velocity = Vector2.Normalize(projectile.velocity) * 2f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, projectile.ai[0] == 0 ? 120 : 300);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
            for(int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustPerfect(projectile.Center, projectile.ai[0] == 0 ? 76 : 92);
                dust.noGravity = true;
                dust.noLight = true;
                dust.velocity = CSUtils.RandomRotate * Main.rand.Next(30, 51) / 10f;
            }
        }
    }
    public class IcicleDaggerProj : ModProjectile
    {
        public override string Texture => "CalamitySouls/Items/IcicleDagger";
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 22;
            projectile.Calamity().rogue = true;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.timeLeft = 200;
        }
        public override void AI()
        {
            if (projectile.velocity.Y < 20f) projectile.velocity.Y += 0.15f;
            if (projectile.timeLeft < 100) projectile.rotation += 0.1f;
            else projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.Next(3) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 92);
                dust.noGravity = true;
                dust.velocity = Vector2.Zero;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn,  120);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.Center);
            for(int i = 0; i < 12; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 92);
                dust.noGravity = true;
                dust.velocity = Vector2.Normalize(projectile.velocity) * 5f + CSUtils.RandomRotate * 2f;
            }
        }
    }
}
