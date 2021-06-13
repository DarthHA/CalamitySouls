using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using static System.Math;
using CalamityMod;

namespace CalamitySouls.Projectiles
{
    public class BloodOption : ModProjectile
    {
        public override string Texture => "CalamityMod/Projectiles/Boss/PhantomMine";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Option");
            DisplayName.AddTranslation(GameCulture.Chinese, "子机");
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 30;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.minionSlots = 0f;
            projectile.timeLeft = 900;
            projectile.penetrate = 1;
            projectile.soundDelay = 2;
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0)
            {
                Main.PlaySound(SoundID.Item20, projectile.position);
                SpawnDust();
                projectile.soundDelay = 0;
            }
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead || !player.CS().BloodCanOption)
            {
                projectile.Kill();
                return;
            }
            player.CS().BloodOptionAmount++;
            projectile.timeLeft = 900;
            projectile.Center = player.Center + MathHelper.ToRadians(projectile.ai[1] * 3).ToRotationVector2() * 64f;
            projectile.ai[1] += 1f;
            if (projectile.ai[0] == 0)
            {
            int index = -1;
            float dist = 1000f;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly & npc.CanBeChasedBy(projectile) && npc.Distance(player.Center) < dist)
                {
                    dist = npc.Distance(player.Center);
                    index = i;
                }
            }
            if (index != -1 && player.miscCounter % 30 == 0)
            {
                NPC target = Main.npc[index];
                if (player.whoAmI == Main.myPlayer)
                {
                    Projectile drain = Projectile.NewProjectileDirect(target.Center, Vector2.Zero, ProjectileID.SoulDrain, 500, 0f, player.whoAmI);
                    drain.usesLocalNPCImmunity = true;
                    drain.localNPCHitCooldown = 0;
                    drain.penetrate = 1;
                    drain.Classless(true);
                }
                player.HealLife(5);
            }
                projectile.alpha = 0;
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180);
                dust.velocity *= 0f;
                dust.noGravity = true;
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    Projectile hosProj = Main.projectile[i];
                    if (hosProj.active && hosProj.hostile && !hosProj.friendly && !CalamityLists.projectileDestroyExceptionList.Contains(hosProj.type)
                        && hosProj.Hitbox.Distance(projectile.Center) < 15f)
                    {
                        hosProj.Kill();
                        SpawnDust();
                        projectile.ai[0] = 5 * 60;
                        break;
                    }
                }
            }
            else
            {
                projectile.ai[0]--;
                projectile.alpha = 200;
            }
        }
        private void SpawnDust()
        {
            Main.PlaySound(SoundID.Item14, projectile.Center);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180);
                dust.velocity *= 3f;
                dust.scale *= 2f;
                if (Utils.NextBool(Main.rand, 2))
                {
                    dust.scale = 0.5f;
                    dust.fadeIn = 1f + Main.rand.Next(10) * 0.1f;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180);
                dust.noGravity = true;
                dust.velocity *= 5f;
                dust.scale *= 3f;
                dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180);
                dust.velocity *= 2f;
                dust.scale *= 2f;
            }
        }
        public override bool CanDamage() => false;
        public override void Kill(int timeLeft)
        {
            SpawnDust();
        }
    }
}