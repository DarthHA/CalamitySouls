using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Projectiles
{
    public class PrismaticPrismProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 900;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead || !player.CS().pPrism)
            {
                projectile.Kill();
                return;
            }
            projectile.rotation += Main.rand.Next(3) / 10f;
            projectile.timeLeft = 900;
            projectile.Center = player.Center + MathHelper.ToRadians(projectile.ai[1]*6f).ToRotationVector2() * 320f;
            projectile.ai[1] += 1f;
            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 86);
            dust.velocity *= 0f;
            dust.noGravity = true;
            dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 89);
            dust.velocity *= 0f;
            dust.noGravity = true;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile hosProj = Main.projectile[i];
                if (hosProj.active && hosProj.hostile && !hosProj.friendly && !CalamityLists.projectileDestroyExceptionList.Contains(hosProj.type)
                    && hosProj.Hitbox.Distance(projectile.Center) < 30f)
                {
                    hosProj.velocity = hosProj.DirectionFrom(player.Center) * hosProj.velocity.Length();
                }
            }
        }
        public override bool CanDamage() => false;
    }
}