using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls.Projectiles
{
    public class DaedalusTrueCrystal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Daedalus Crystal");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 22; projectile.height = 34;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.soundDelay = 2;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.soundDelay = 2;
        }
        public override bool CanDamage() => false;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            Rectangle sourceRectangle = new Rectangle(0, 0, 82, 34);
            Vector2 origin = new Vector2(41, 17);
            Vector2 origin2 = new Vector2(11, 17);
            if (projectile.ai[0] > 0)
            {
                texture = CSTexture.寒元;
                sourceRectangle = new Rectangle(0, 0, 82, 58);
                origin = new Vector2(41, 33);
            }
            Color color = lightColor;
            for (int i = 0; i < 4; i++)
            {
                color *= 0.6f; color.B = (byte)(color.B / 0.7f); color.G = (byte)(color.G / 0.7f);
                spriteBatch.Draw(texture, projectile.oldPos[i] + origin2 - Main.screenPosition, sourceRectangle, color, projectile.oldRot[i],
                    origin, 1f, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, lightColor, projectile.rotation, origin, 1f, SpriteEffects.None, 0f);
            return false;
        }
        private void Transform()
        {
            Main.PlaySound(SoundID.Item25, projectile.Center);
            for (int i = 0; i < 48; i++)
            {
                int seleDust = Utils.SelectRandom(Main.rand, new int[]
                {
                    DustID.BlueCrystalShard,
                    DustID.PinkCrystalShard,
                    DustID.PurpleCrystalShard,
                    88,
                    173,
                });
                Dust dust = Dust.NewDustPerfect(projectile.Center, seleDust);
                dust.noGravity = true;
                dust.velocity = MathHelper.ToRadians(Main.rand.Next(360)).ToRotationVector2() * Main.rand.Next(30, 41) / 10f;
                dust.scale *= 2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item4, projectile.Center);
        }
        public override void AI()
        {
            if (projectile.soundDelay > 0) Main.PlaySound(SoundID.Item4, projectile.Center);
            ref float ai0 = ref projectile.ai[0];
            if (ai0 == 1)
            {
                Transform();
            }
            if (ai0 > 0) ai0--;
            Player player = Main.player[projectile.owner];
            if (!player.active || player.dead || !player.CS().DaedalusCrystal)
            {
                projectile.Kill();
                return;
            }
            projectile.timeLeft = 2;
            ref float ai1 = ref projectile.ai[1];
            ai1++;
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
            bool attack = true;
            Item item = player.inventory[player.selectedItem];
            if (!item.IsAir)
            {
                if (item.type == ModContent.ItemType<CalamityMod.Items.Materials.VerstaltiteBar>())
                {
                    if (ai0 == 0)
                    {
                        Transform();
                    }
                    ai0 = 2;
                    projectile.AllClass();
                    if (target != null)
                    {
                        projectile.FollowPlayer((player.Center * 4 + target.Center) / 5, 320f, 20f, (player.velocity * 4 + target.velocity) / 5, 32f);
                        if (player.ownedProjectileCounts(ModContent.ProjectileType<DaedalusJavelin>()) < 1) 
                        {
                            Main.PlaySound(SoundID.Item4, projectile.Center);
                            if (CSUtils.GoodNetMode)
                            {
                                Projectile.NewProjectileDirect(projectile.Center, Vector2.Zero,
                                    ModContent.ProjectileType<DaedalusJavelin>(), (int)(200f * player.AverageDamage()), 12f, player.whoAmI, projectile.whoAmI);
                            }
                        }
                    }
                    else projectile.FollowPlayer(player.Center, 800f, 160f, player.velocity, 20f);
                }
                else if (target != null)
                {
                    if (item.melee && item.pick <= 0 && item.axe <= 0 && item.hammer <= 0)
                    {
                        projectile.Melee();
                        projectile.FollowPlayer(target.Center, 1600f, 64f, projectile.DirectionTo(target.Center) * 50f, 20f);
                        if (ai1 > 5)
                        {
                            ai1 = 0;
                            if (CSUtils.GoodNetMode)
                            {
                                Projectile beam = Projectile.NewProjectileDirect(projectile.Center, projectile.velocity, ProjectileID.FrostBoltSword,
                                    (int)(30f * player.MeleeDamage()), 12f, player.whoAmI);
                                beam.penetrate = 1; beam.timeLeft = 60; beam.tileCollide = false;
                            }
                        }
                    }
                    else if (item.ranged)
                    {
                        projectile.Ranged();
                        projectile.FollowPlayer((player.Center + target.Center * 2) / 3 - Vector2.UnitY * 160f, 640f, 320f, (player.velocity * 2 + target.velocity) / 3, 20f);
                        if (ai1 > 23)
                        {
                            ai1 = 0;
                            Main.PlaySound(SoundID.Item5, projectile.Center);
                            projectile.velocity += Vector2.UnitY * 10f;
                            for (int j = 18; j <= 36; j++)
                            {
                                Vector2 rotate = MathHelper.ToRadians(j * 10f).ToRotationVector2();
                                Dust dust = Dust.NewDustPerfect(projectile.Center, 88);
                                dust.noGravity = true;
                                dust.scale *= 2f;
                                dust.velocity = rotate * 4f;
                                dust.velocity.Y /= 1.3f;
                            }
                            if (CSUtils.GoodNetMode)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    Vector2 pos = (projectile.Center + target.Center * 3) / 4 + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101) - 800f);
                                    Vector2 vel = target.Center + target.velocity * 15f - pos; vel.SafeNormalize(Vector2.UnitY);
                                    Projectile arrow = Projectile.NewProjectileDirect(pos, vel * 20f,
                                             ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.IcicleArrowProj>(),
                                             (int)(25f * player.RangedDamage()), 12f, player.whoAmI);
                                    arrow.extraUpdates = 2;
                                }
                            }
                        }
                    }
                    else if (item.magic)
                    {
                        projectile.Magic();
                        projectile.FollowPlayer(player.Center + MathHelper.ToRadians(Main.GlobalTime * 360f).ToRotationVector2() * 120f,
                            320f, 320f, player.velocity, 0, true, 0.05f, 0.1f, 0.3f);
                        if (ai1 >= 30)
                        {
                            ai1 = 0;
                            Main.PlaySound(SoundID.Item12, projectile.Center);
                            if (CSUtils.GoodNetMode)
                            {
                                int type = Utils.SelectRandom(Main.rand, new int[]
                                {
                                ModContent.ProjectileType<CalamityMod.Projectiles.Typeless.LunicBeam>(),
                                ModContent.ProjectileType<CalamityMod.Projectiles.Magic.MagnusBeam>(),
                                });
                                Projectile lunic = Projectile.NewProjectileDirect(projectile.Center, projectile.DirectionTo(target.Center) * 16f, type,
                                    (int)(50f * player.MagicDamage()), 12f, player.whoAmI);
                                lunic.tileCollide = false; lunic.Magic();
                            }
                        }
                    }
                    else if (item.summon || item.sentry)
                    {
                        projectile.Minion();
                        projectile.FollowPlayer(player.Center - Vector2.UnitY * 80f, 800f, 1f, player.velocity, 3f, true, 0.05f, 0.07f, 0.3f);
                        if (ai1 >= 17)
                        {
                            ai1 = 0;
                            for (int i = 0; i < 18; i++)
                            {
                                Dust dust = Dust.NewDustPerfect(projectile.Center, 173);
                                dust.noGravity = true;
                                dust.velocity = MathHelper.ToRadians(Main.rand.Next(360)).ToRotationVector2() * 3f;
                                dust.scale *= 1.4f;
                            }
                            if (CSUtils.GoodNetMode)
                            {
                                Projectile.NewProjectile(projectile.Center, projectile.DirectionTo(target.Center + target.velocity * 10f) * 24f,
                                    ModContent.ProjectileType<CalamityMod.Projectiles.Summon.DaedalusCrystalShot>(),
                                   (int)(90f * player.MinionDamage()), 12f, player.whoAmI);
                            }
                        }
                    }
                    else if (item.thrown || CalamityUtils.Calamity(item).rogue)
                    {
                        projectile.Rogue();
                        projectile.FollowPlayer((player.Center + target.Center) / 2, 320f, 20f, (player.velocity + target.velocity) / 2, 32f);
                        if (ai1 > 100)
                        {
                            ai1 = 0;
                            Main.PlaySound(SoundID.Item28, projectile.Center);
                            Vector2 dir = projectile.DirectionTo(target.Center);
                            for (int i = 0; i < 31; i++)
                            {
                                Vector2 rotate = (MathHelper.ToRadians(360 * (i + 3) / 36f) + dir.ToRotation()).ToRotationVector2();
                                Dust dust = Dust.NewDustPerfect(projectile.Center, 88);
                                dust.noGravity = true; dust.scale *= 2f; dust.velocity = rotate * 4f;
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                Dust dust = Dust.NewDustPerfect(projectile.Center + dir * i * 8f, 88);
                                dust.noGravity = true; dust.scale *= 2f; dust.velocity = dir * 4f;
                            }
                            projectile.velocity -= dir * 30f;
                            if (CSUtils.GoodNetMode)
                                for (int i = 0; i < 20; i++)
                                {
                                    Projectile star = Projectile.NewProjectileDirect(projectile.Center + dir * 64f * i, dir * 0.1f,
                                        ModContent.ProjectileType<CalamityMod.Projectiles.Typeless.KelvinCatalystStar>(), (int)(17f * player.RogueDamage()), 12f, player.whoAmI);
                                    star.Rogue(); star.tileCollide = false;
                                }
                        }
                    }
                    else attack = false;
                }
                else attack = false;
            }
            else attack = false;
            if (!attack)
            {
                projectile.Classless();
                projectile.FollowPlayer(player.Center, 1600f, 1f, player.velocity, 1f, true, 0.05f, 0.07f, 0.3f);
            }
            float rot = System.Math.Sign((int)projectile.velocity.X) * 0.5f;
            projectile.rotation = MathHelper.Lerp(projectile.rotation, rot, 0.1f);
        }
    }
}