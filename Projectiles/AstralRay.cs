using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Projectiles
{
    public class AstralRay : ModProjectile
    {
        public override string Texture => CSUtils.BlankTexture;
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 16;
            projectile.extraUpdates = 100;
            projectile.timeLeft = 600;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 40;
            projectile.soundDelay = 2;
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0)
            {
                int rand = Main.rand.Next(360);
                for (int i = 0; i < 12; i++)
                {
                    Vector2 rot = MathHelper.ToRadians(360 * i / 12 + rand).ToRotationVector2();
                    int randomDust = Utils.SelectRandom(Main.rand, new int[]
                    {
                        DustType<AstralOrange>(),
                        DustType<AstralBlue>()
                    });
                    Dust astral = Dust.NewDustPerfect(projectile.Center, randomDust);
                    astral.velocity = rot;
                    astral.scale *=2f;
                    astral.noGravity = true;
                    astral = Dust.NewDustPerfect(projectile.Center, randomDust);
                    astral.velocity = rot /2f;
                    astral.scale *= 3f;
                    astral.noGravity = true;
                }
            }
            projectile.ai[1]++;
            if (projectile.ai[1] % 40 == 39)
            {
                for (int i = 0; i < 24; i++)
                {
                    Vector2 rot = MathHelper.ToRadians(360 * i / 24).ToRotationVector2();
                    rot.X /= 2;
                   rot= rot.RotatedBy(projectile.velocity.ToRotation());
                    int randomDust = Utils.SelectRandom(Main.rand, new int[]
                    {
                        DustType<AstralOrange>(),
                        DustType<AstralBlue>()
                    });
                    Dust astral = Dust.NewDustPerfect(projectile.Center, randomDust);
                    astral.velocity = rot;
                    astral.scale *= 1.5f;
                    astral.noGravity = true;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Dust astral = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustType<AstralOrange>());
                astral.noGravity = true;
                astral.noLight = true;
                astral.velocity *= 0.05f;
                astral = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustType<AstralBlue>());
                astral.noGravity = true;
                astral.noLight = true;
                astral.velocity *= 0.05f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.NPCHit43, projectile.Center);
            int rand = Main.rand.Next(360);
            for (int i = 0; i < 12; i++)
            {
                Vector2 rot = MathHelper.ToRadians(360 * i / 12 + rand).ToRotationVector2();
                int randomDust = Utils.SelectRandom(Main.rand, new int[]
                {
                        DustType<AstralOrange>(),
                        DustType<AstralBlue>()
                });
                Dust astral = Dust.NewDustPerfect(projectile.Center, randomDust);
                astral.velocity = rot;
                astral.scale *= 2f;
                astral.noGravity = true;
                astral = Dust.NewDustPerfect(projectile.Center, randomDust);
                astral.velocity = rot / 2f;
                astral.scale *= 3f;
                astral.noGravity = true;
            }
        }
    }
}