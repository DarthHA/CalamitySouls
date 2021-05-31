using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Projectiles.Ranged;
using CalamityMod.Projectiles.Summon;

namespace CalamitySouls.Projectiles
{
    public class DaedalusJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Javelin");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 50;
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
        }
        public override bool CanDamage() => false;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            Rectangle sourceRectangle = new Rectangle(0, 0, 152, 152);
            Vector2 origin = new Vector2(57, 95);
            Vector2 origin2 = new Vector2(25, 25);
            Color color = lightColor;
            for (int i = 0; i < 4; i++)
            {
                color *= 0.6f;
                spriteBatch.Draw(texture, projectile.oldPos[i] + origin2 - Main.screenPosition, sourceRectangle, color, projectile.oldRot[i],
                    origin, projectile.scale / 1.25f, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, lightColor, projectile.rotation,
                origin, projectile.scale / 1.25f, SpriteEffects.None, 0f);
            return false;
        }
        public override void AI()
        {
            Projectile crystal = Main.projectile[(int)projectile.ai[0]];
            if (!crystal.active || crystal.owner != projectile.owner || crystal.type != ModContent.ProjectileType<DaedalusTrueCrystal>() || crystal.ai[0] <= 0)
            {
                projectile.Kill();
                return;
            }
            projectile.timeLeft = 2;
            Player player = Main.player[projectile.owner];
            float SearchDist = 1200f;
            NPC target = null;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (npc.active && npc.CanBeChasedBy(projectile) && npc.Distance(projectile.Center) < SearchDist)
                {
                    if (projectile.CanHit(npc)) target = npc;
                }
            }
            if (target == null)
            {
                float MinDist = SearchDist;
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && !npc.friendly && npc.CanBeChasedBy(projectile) && npc.Distance(projectile.Center) < MinDist)
                    {
                        if (projectile.CanHit(npc))
                        {
                            target = npc;
                            MinDist = npc.Distance(projectile.Center);
                        }
                    }
                }
            }
            ref float ai1 = ref projectile.ai[1];
            if (ai1 <= 30 && !projectile.friendly)
            {
                ai1++;
                projectile.rotation += 0.2f;
                projectile.scale = MathHelper.Lerp(0, 1f, ai1 / 30f);
                projectile.Center = crystal.Center + Vector2.Lerp(Vector2.Zero, -Vector2.UnitY * 64f, ai1 / 30f);
                if (ai1 == 30)
                {
                    projectile.friendly = true;
                    ai1 = 0;
                }
            }
            else
            {
                projectile.FollowPlayer(crystal.Center, 76f, 38f, crystal.velocity, 20f, true);
                ai1++;
                if (target != null && projectile.owner == Main.myPlayer)
                {
                    projectile.rotation = MathHelper.Lerp(projectile.rotation, projectile.AngleTo(target.Center) + MathHelper.PiOver4, 0.1f);
                    if (ai1 % 20 == 0 && ai1 <= 60)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Vector2 pos = new Vector2(Main.rand.Next(-50, 51), Main.rand.Next(-50, 51)) + crystal.Center;
                            Vector2 dir = target.Center + target.velocity * 10f - pos; dir.SafeNormalize(Vector2.Zero);
                            Projectile YellowRocket = Projectile.NewProjectileDirect(pos, dir * 16f,
                                ModContent.ProjectileType<GalacticaComet>(), (int)(20f * player.AverageDamage()), 12f, projectile.owner);
                            YellowRocket.AllClass(); YellowRocket.extraUpdates = 2;
                        }
                        for (int i = -9; i <= 9; i++)
                        {
                            Vector2 pos = new Vector2(Main.rand.Next(-50, 51), Main.rand.Next(-50, 51)) + crystal.Center;
                            Vector2 dir = target.Center + target.velocity * 10f - pos; dir.SafeNormalize(Vector2.Zero);
                            Vector2 rot = (MathHelper.ToRadians(i * 45 / 18f) + dir.ToRotation()).ToRotationVector2();
                            if (i == -6 || i == 2) i += 3;
                            Projectile BlueRocket = Projectile.NewProjectileDirect(crystal.Center + rot * 8f, rot * 16f,
                                ModContent.ProjectileType<CosmicViperConcussionMissile > (), (int)(20f * player.AverageDamage()), 12f, projectile.owner);
                            BlueRocket.AllClass(); BlueRocket.extraUpdates = 2;
                        }
                    }
                    if (ai1 % 40 == 0 && ai1 > 60)
                    {
                        for (int i = -2; i <= 2; i++)
                        {
                            Vector2 pos = new Vector2(Main.rand.Next(-50, 51), Main.rand.Next(-50, 51)) + crystal.Center;
                            Vector2 dir = target.Center + target.velocity * 10f - pos; dir.SafeNormalize(Vector2.Zero);
                            Vector2 rot = (MathHelper.ToRadians(i * 5 / 5f) + dir.ToRotation()).ToRotationVector2();
                            if (i == 0) i += 1;
                            Projectile BlueRocket = Projectile.NewProjectileDirect(crystal.Center + rot * 8f, rot * 8f,
                                ModContent.ProjectileType<PlasmaBlast>(), (int)(50f * player.AverageDamage()), 12f, projectile.owner);
                            BlueRocket.AllClass(); BlueRocket.extraUpdates = 1;
                        }
                        if (ai1 >= 120) ai1 = 0;
                    }
                }
                else
                {
                    float rotdir = System.Math.Sign(projectile.velocity.X);
                    projectile.rotation = MathHelper.Lerp(projectile.rotation, 0.3f * rotdir - MathHelper.PiOver4, 0.1f);
                }
            }
        }
    }
}