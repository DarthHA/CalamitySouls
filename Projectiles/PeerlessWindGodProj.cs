using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod;

namespace CalamitySouls.Projectiles
{
   public class PeerlessWindGodProj:ModProjectile
    {
        public override string Texture => CSUtils.BlankTexture;
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override bool CanDamage() => false;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!player.active || !player.channel || player.dead || player.CCed)
            {
                projectile.Kill();
                return;
            }
            if (player.whoAmI == Main.myPlayer)
            {
                projectile.velocity = player.DirectionTo(Main.MouseWorld);
                projectile.netUpdate = true;
            }
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            projectile.timeLeft = 2;
            projectile.Center = player.Center;
            projectile.ai[0]++;
            projectile.ai[1]++;
            int amt = 5;
            if (projectile.ai[1] < 60) amt += 5;
            if (projectile.ai[1] < 120) amt += 5;
            if (projectile.ai[0] % amt < 1) 
            {
                Main.PlaySound(SoundID.Item71, projectile.Center);
                if (projectile.owner == Main.myPlayer) 
                {
                    Vector2 dir = projectile.DirectionTo(Main.MouseWorld).RotatedByRandom(MathHelper.ToRadians(15));
                    Vector2 rand = new Vector2(Main.rand.Next(-250, 251), Main.rand.Next(-50, 51));
                    Projectile.NewProjectile(projectile.Center + rand, dir * Main.rand.Next(200, 251) / 10f,
                        ModContent.ProjectileType<PeerlessWind>(), (int)(120f * player.MeleeDamage()), projectile.knockBack, projectile.owner);
                }
            }
        }
    }
}
