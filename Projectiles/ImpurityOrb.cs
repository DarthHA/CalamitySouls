using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace CalamitySouls.Projectiles
{
    public class ImpurityOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impurity Orb");
            DisplayName.AddTranslation(GameCulture.Chinese, "邪秽球");
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 22;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.soundDelay = 2;
            projectile.timeLeft = 114514;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0)
            {
                projectile.soundDelay = 0;
                projectile.timeLeft = 104 + Main.rand.Next(24);
                projectile.rotation = MathHelper.ToRadians(Main.rand.Next(360));
            }
            projectile.rotation += 0.157f;
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
            Main.PlaySound(SoundID.Item9, projectile.Center);
            if (projectile.owner == Main.myPlayer)
            {
                int index = -1;
                float minDist = 800f;
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC targetSelect = Main.npc[i];
                    if (targetSelect.active && !targetSelect.friendly && !targetSelect.dontTakeDamage && targetSelect.Distance(Main.player[projectile.owner].Center) < minDist)
                    {
                        index = i;
                        minDist = targetSelect.Distance(Main.player[projectile.owner].Center);
                    }
                }
                Vector2 iCenter = Main.MouseWorld;
                if (index != -1) iCenter = Main.npc[index].Center;
                Projectile.NewProjectile(projectile.Center, projectile.DirectionTo(iCenter) * 15f,
                    ModContent.ProjectileType<ImpurityLaser>(), projectile.damage, projectile.knockBack, Main.myPlayer);
            }
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 86);
                dust.noGravity = true;
                dust.noLight = false;
                dust.velocity = CSUtils.RandomRotate * 3f;
                dust.scale *= 2f;
            }
        }
        public override bool CanDamage() => false;
    }
}