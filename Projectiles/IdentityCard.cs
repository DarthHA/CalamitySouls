using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamitySouls.Buffs;

namespace CalamitySouls.Projectiles
{
    public class IdentityCard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Identity Card");
            DisplayName.AddTranslation(GameCulture.Chinese, "本我符卡");
        }
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 18;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 255;
            projectile.minionSlots = 0.5f;
        }
        public override void AI()
        {
            projectile.alpha = 0;
            Lighting.AddLight(projectile.Center, 0.3f, 0f, 0f);
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead)
            {
                player.CS().RotI = false;
                projectile.Kill();
                return;
            }
            bool flag = projectile.type == ModContent.ProjectileType<IdentityCard>();
            player.AddBuff(ModContent.BuffType<IdentityMinionBuff>(), 3600, true);
            if (flag && player.CS().RotI) projectile.timeLeft = 2;
            projectile.ai[0] += MathHelper.ToRadians(4);
            projectile.Center = player.Center + projectile.ai[0].ToRotationVector2() * 80f;
            projectile.velocity = player.DirectionTo(projectile.Center).RotatedBy(MathHelper.PiOver2);
            projectile.rotation = projectile.velocity.ToRotation();
            if (player.miscCounter % 60 < 15 && player.miscCounter % 5 < 1) 
            {
                Main.PlaySound(SoundID.Item29, projectile.Center);
                for (int i = -1; i <= 1; i += 2)
                {
                    Projectile.NewProjectile(projectile.Center, player.DirectionTo(projectile.Center) * 12f,
                        ModContent.ProjectileType<IdentityHeart>(), (int)(60f * player.MinionDamage()), projectile.knockBack, player.whoAmI, i);
                }
            }
        }
        public override bool CanDamage() => false;
    }
}