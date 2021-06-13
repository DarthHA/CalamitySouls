using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class IdentityHeart : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Identity Heart");
            DisplayName.AddTranslation(GameCulture.Chinese, "本我之心");
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 18;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 120;
            projectile.alpha = 255;
            projectile.minionSlots = 0f;
            projectile.timeLeft = 120;
        }
        public override void AI()
        {
            projectile.alpha = 0;
            Lighting.AddLight(projectile.Center, 0.3f, 0f, 0f);
            if (projectile.ai[1] < 60)
            {
                projectile.ai[1]++;
                projectile.velocity = projectile.velocity.RotatedBy(MathHelper.ToRadians(projectile.ai[0] * (60 - projectile.ai[1]) / 12f));
                projectile.velocity *= 0.97f;
            }
            else
            {
                int index = -1;
                float minDist = 800f;
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC targetSelect = Main.npc[i];
                    if (targetSelect.active && !targetSelect.friendly && !targetSelect.dontTakeDamage && targetSelect.Distance(projectile.Center) < minDist)
                    {
                        index = i;
                        minDist = targetSelect.Distance(projectile.Center);
                    }
                }
                if (index != -1)
                {
                    Vector2 iCenter = Main.npc[index].Center;
                    projectile.FollowPlayer(iCenter, 800f, 0f, Vector2.Zero, 25f, false, 0.06f);
                    projectile.timeLeft++;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation();
            Dust dust = Dust.NewDustPerfect(projectile.Center, 73);
            dust.velocity = Vector2.Zero;
            dust.noGravity = true;
            dust.scale *= 0.8f;
        }
        public override bool CanDamage() => projectile.ai[1] >= 60;
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item4, projectile.Center);
            for (int k = 0; k < 22; k++)
            {
                Dust dust = Dust.NewDustPerfect(projectile.Center, 73);
                dust.velocity = CSUtils.RandomRotate * 2f;
                dust.noGravity = true;
                dust.scale *= 1f;
            }
        }
    }
}