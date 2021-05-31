using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class WulfrumShield : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 2;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 600;
            projectile.soundDelay = 2;
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0) Main.PlaySound(SoundID.Item15, projectile.Center);
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead)
            {
                projectile.Kill();
                return;
            }
            player.CS().WulfrumShieldCooldown = 20 * 60;
            player.statDefense += 6;
            projectile.Center = player.Center;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile bullet = Main.projectile[i];
                if (bullet.active && bullet.hostile && !bullet.friendly && bullet.tileCollide
                    &&!CalamityMod.CalamityLists.projectileDestroyExceptionList.Contains(bullet.type))
                {
                    if (bullet.Hitbox.Distance(projectile.Center) < 47f)
                    {
                        if (ProjectileLoader.OnTileCollide(bullet, bullet.oldVelocity)) bullet.Kill();
                        projectile.Kill();
                        Main.PlaySound(SoundID.NPCDeath44, projectile.Center);
                        if (player.CS().ImmunityTime < 30) player.CS().ImmunityTime = 30;
                        return;
                    }
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.BlueCrystalShard);
                dust.noGravity = true;
                dust.scale *= 2f;
                dust.velocity = Main.rand.Next(10, 41) / 10f * MathHelper.ToRadians(Main.rand.Next(360)).ToRotationVector2();
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
            }
            if (projectile.frame > 15) projectile.frame = 0;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.BlueCrystalShard);
                dust.noGravity = true;
                dust.scale *= 2f;
                dust.velocity = Main.rand.Next(10, 41) / 7f * MathHelper.ToRadians(Main.rand.Next(360)).ToRotationVector2();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) => false;
        public override bool CanDamage() => false;
    }
}