using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamityMod.Projectiles.Magic;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class FriendlyCalamitas : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Friendly Calamitas");
            DisplayName.AddTranslation(GameCulture.Chinese, "友好的终灾");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 66;
            projectile.height = 50;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 1800;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.CS().EnchDemonshade)
            {
                projectile.Kill();
                return;
            }
            projectile.timeLeft++;
            ref Vector2 velocity = ref projectile.velocity;
            Vector2 playerCenterWithY = player.Center - Vector2.UnitY * 80f;
            if (projectile.Distance(playerCenterWithY) < 1) velocity = Vector2.Lerp(velocity, player.velocity, 1f);
            else if (projectile.Distance(playerCenterWithY) > 160) projectile.Center = playerCenterWithY + projectile.DirectionFrom(playerCenterWithY) * 160f;
            else velocity = Vector2.Lerp(velocity, projectile.DirectionTo(playerCenterWithY) * 10f, 0.1f);
            projectile.Center = Vector2.Lerp(projectile.Center, playerCenterWithY, 0.15f);
            int NPCWhoAmI = -1;
            if (player.HasMinionAttackTargetNPC && Main.npc[player.MinionAttackTargetNPC].Distance(projectile.Center) < 16 * 1000 * 10) 
            {
                NPCWhoAmI = player.MinionAttackTargetNPC ;
            }
            else
            {
                float MinDistance = 16 * 1000 * 10;
                foreach (NPC See in Main.npc)
                {
                    if (See.active && !See.friendly && !See.dontTakeDamage && projectile.Distance(See.Center) < MinDistance)
                    {
                        MinDistance = projectile.Distance(See.Center);
                        NPCWhoAmI = See.whoAmI ;
                    }
                }
            }
            if (NPCWhoAmI == -1)
            {
                if (projectile.velocity != Vector2.Zero) projectile.rotation = projectile.velocity.ToRotation();
                return;
            }
            NPC npc = Main.npc[NPCWhoAmI];
            if (!npc.active || npc.friendly || npc.dontTakeDamage || npc.Distance(projectile.Center) >= 16 * 1000 * 10
                || (player.HasMinionAttackTargetNPC && npc.whoAmI != player.MinionAttackTargetNPC))
            {
                projectile.ai[1] = 0;
                return;
            }
            projectile.rotation = MathHelper.Lerp(projectile.rotation, (npc.Center - projectile.Center).ToRotation(), 0.1f);
            projectile.ai[1]++;
            int Damage = (int)(1000 * CalamityMod.CalamityUtils.AverageDamage(player));
            Vector2 Direction = npc.Center - projectile.Center;
            Direction.Normalize();
            if (projectile.ai[1] % 15 == 0)
            {
                if (CSUtils.GoodNetMode)
                {
                    int PWAI = Projectile.NewProjectile(projectile.Center, Direction * 22f,
                        ModContent.ProjectileType<SeethingDischargeBrimstoneHellblast>(), Damage, 0f, player.whoAmI);
                    CSUtils.GetItemDamageType(PWAI, player.HeldItem);
                    Main.projectile[PWAI].penetrate = 2;
                    Main.projectile[PWAI].tileCollide = false;
                    Main.projectile[PWAI].usesLocalNPCImmunity = true;
                    Main.projectile[PWAI].localNPCHitCooldown = 0;
                }
                for (int j = -5; j <= 5; j++)
                {
                    Vector2 Rotation = (MathHelper.TwoPi * j / 30f + projectile.rotation).ToRotationVector2();
                    Dust dust = Dust.NewDustPerfect(projectile.Center + Rotation * 16f, 235);
                    dust.velocity = Rotation * (7f - System.Math.Abs(j));
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale *= 2f;
                }
            }
            if (projectile.ai[1] >= 60)
            {
                projectile.ai[1] = 0;
                if (CSUtils.GoodNetMode)
                    for (int i = 0; i < 5; i++)
                    {
                        float radians = MathHelper.ToRadians(5);
                        Vector2 Dir2 = Vector2.Lerp(Direction.RotatedBy(-radians), Direction.RotatedBy(radians), i / 4f);
                        int PWAI = Projectile.NewProjectile(projectile.Center, Dir2 * 27f,
                            ModContent.ProjectileType<SeethingDischargeBrimstoneBarrage>(), (int)(Damage / 40f), 0f, player.whoAmI);
                        CSUtils.GetItemDamageType(PWAI, player.HeldItem);
                        Main.projectile[PWAI].penetrate = -1;
                        Main.projectile[PWAI].usesLocalNPCImmunity = true;
                        Main.projectile[PWAI].localNPCHitCooldown = 0;
                    }
            }
        }
        public override bool? CanCutTiles() => false;
        public override bool CanDamage() => false;
        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Texture2D texture = Main.projectileTexture[projectile.type];
        //    Rectangle sourceRectangle = new Rectangle(0, 0, 66, 50);
        //    Vector2 origin = new Vector2(33, 25);
        //    Color color = Color.White;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        color *= 0.6f; color.R = (byte)(color.R / 0.7f);
        //        spriteBatch.Draw(texture, projectile.oldPos[i] + origin - Main.screenPosition, sourceRectangle, color, projectile.oldRot[i],
        //            origin, projectile.scale, SpriteEffects.None, 0f);
        //    }
        //    spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, Color.White, projectile.rotation,
        //        origin, projectile.scale, SpriteEffects.None, 0f);
        //    return false;
        //}
    }
}