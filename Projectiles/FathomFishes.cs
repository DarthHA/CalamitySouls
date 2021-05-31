using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CalamitySouls.Projectiles
{
    public abstract class FathomFishes : ModProjectile
    {
        public override string Texture => "CalamitySouls/Projectiles/FathomFish";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fathom Fish");
            DisplayName.AddTranslation(GameCulture.Chinese, "幻渊小鱼");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 origin = texture.Size() / 2f;
            Color color = projectile.GetAlpha(lightColor);
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            for (int i = 0; i < 4; i++)
            {
                color *= 0.6f; color.B = (byte)(color.B / 0.6f); color.G = (byte)(color.G / 0.7f);
                spriteBatch.Draw(texture, projectile.oldPos[i] + origin - Main.screenPosition, null, color, projectile.oldRot[i],
                    origin, projectile.scale, effects, 0f);
            }
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, lightColor, projectile.rotation,
                origin, projectile.scale, effects, 0f);
            return false;
        }
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 22;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active || !player.CS().FathomFishes)
            {
                projectile.Kill();
                return;
            }
            projectile.timeLeft = 2;
            Lighting.AddLight(projectile.Center, 0f, 0.15f, 0.4f);
            int randomDust = Main.rand.Next(4);
            if (randomDust == 3) randomDust = 89;
            else randomDust = 33;
            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, randomDust);
            if (randomDust == 89) dust.scale *= 0.5f;
            dust.noGravity = true; dust.velocity *= 0f;
            if (InnerAI(player))
            {
                ref Vector2 velocity = ref projectile.velocity;
                float TryToLerp = Math.Abs(velocity.Y);
                TryToLerp = MathHelper.ToRadians(50 - 50 / (1 + TryToLerp / 5f));
                projectile.spriteDirection = projectile.direction;
                if (velocity.X * velocity.Y > 0) projectile.rotation = TryToLerp;
                else projectile.rotation = -TryToLerp;
            }
        }
        public virtual bool InnerAI(Player player)
        {
            return true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.NPCDeath19, projectile.Center);
            for (int i = 0; i < 18; i++)
            {
                Vector2 rot = MathHelper.ToRadians(360 * i / 18f).ToRotationVector2();
                Dust dust = Dust.NewDustPerfect(projectile.Center, 89);
                dust.noGravity = true;
                dust.velocity = rot * 3f;
                dust.scale *= 2f;
            }
        }
        public override bool CanDamage() => false;
    }
    public class FathomFishOtter : FathomFishes
    {
        public override bool InnerAI(Player player)
        {
            ref Vector2 velocity = ref projectile.velocity;
            float angle = MathHelper.ToRadians(Main.GlobalTime * 180f + 120f);
            Vector2 dir = angle.ToRotationVector2();
            projectile.Center = player.Center + dir * 240f;
            projectile.velocity = Vector2.Zero;
            projectile.rotation = dir.ToRotation() + MathHelper.PiOver2;
            if (projectile.ai[0] == 0)
            {
                projectile.alpha = 0;
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    Projectile hostileProj = Main.projectile[i];
                    if (hostileProj.active && hostileProj.hostile && hostileProj.Hitbox.Intersects(projectile.Hitbox) && hostileProj.timeLeft < 60 * 60 * 3)
                    {
                        Main.PlaySound(SoundID.NPCDeath19, hostileProj.Center);
                        if (player.whoAmI == Main.myPlayer)
                        {
                            hostileProj.Kill();
                            projectile.ai[0] = 60;
                            break;
                        }
                    }
                }
            }
            else
            {
                projectile.ai[0]--;
                projectile.alpha = 200;
            }
            return false;
        }
    }
    public class FathomFish : FathomFishes
    {
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = CSTexture.Circle;
            Vector2 origin = new Vector2(80, 80);
            float rot = MathHelper.ToRadians(Main.rand.Next(360));
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, lightColor, rot, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool InnerAI(Player player)
        {
            float maxDist = 1600f;
            Projectile findTargetMinion = null;
            for(int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile minion = Main.projectile[i];
                if (minion.active && minion.friendly)
                {
                    if (minion.minionSlots > 0 && minion.owner == player.whoAmI && minion.Distance(projectile.Center) < maxDist)
                    {
                        maxDist = minion.Distance(projectile.Center);
                        findTargetMinion = minion;
                    }
                    if (minion.Hitbox.Distance(projectile.Center) < 80f && minion.type != projectile.type) minion.Center += minion.velocity;
                }
            }
            if (findTargetMinion == null)
            {
                projectile.FollowPlayer(player.Center, 800f, 80f, player.velocity, 32f);
               projectile.velocity= projectile.velocity.RotatedByRandom(0.1f);
            }
            else
            {
                projectile.FollowPlayer(findTargetMinion.Center, 1600f, 40f, findTargetMinion.velocity, 32f, false, 0.07f, 0.1f);
                if (Main.rand.Next(180) == 0)
                {
                    projectile.Center += projectile.velocity * 10f;
                    Main.PlaySound(SoundID.NPCDeath19, projectile.Center);
                    for (int i = 0; i < 36; i++)
                    {
                        Vector2 rot = MathHelper.ToRadians(360 * i / 36f).ToRotationVector2();
                        Dust dust = Dust.NewDustPerfect(projectile.Center, 89);
                        dust.noGravity = true;
                        dust.velocity = rot * 8f;
                    }
                }
            }
            return true;
        }
    }
    public class FathomFishAttacker : FathomFishes
    {
        public override bool CanDamage() => true;
        public override bool InnerAI(Player player)
        {
            float dist = 1600f;
            NPC target = null;
            if (player.HasMinionAttackTargetNPC) target = Main.npc[player.MinionAttackTargetNPC];
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && !npc.dontTakeDamage)
                {
                    if (npc.CanBeChasedBy(projectile) && npc.Distance(projectile.Center) < dist)
                    {
                        dist = npc.Distance(projectile.Center);
                        target = npc;
                    }
                }
            }
            if (target == null)
            {
                projectile.FollowPlayer(player.Center, 800f, 160f, player.velocity, 15f);
                projectile.velocity = projectile.velocity.RotatedByRandom(0.1f);
            }
            else
            {
                projectile.FollowPlayer(target.Center, 1600f, 0f, target.velocity, 32f, false, 0.07f, 0.1f);
                if (Main.rand.Next(180) == 0)
                {
                    projectile.Center += projectile.velocity * 10f;
                    Main.PlaySound(SoundID.NPCDeath19, projectile.Center);
                    for (int i = 0; i < 36; i++)
                    {
                        Vector2 rot = MathHelper.ToRadians(360 * i / 36f).ToRotationVector2();
                        Dust dust = Dust.NewDustPerfect(projectile.Center, 89);
                        dust.noGravity = true;
                        dust.velocity = rot * 8f;
                    }
                }
            }
            return true;
        }
    }
}