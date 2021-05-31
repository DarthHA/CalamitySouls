using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;

namespace CalamitySouls.Projectiles
{
    public class FathomOrb : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 10;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            ref float ai0 = ref projectile.ai[0];
            if (ai0 < 10000)
            {
                if (ai0 < 30)
                {
                    projectile.ai[0]++;
                    projectile.velocity *= 0.96f;
                }
                else
                {
                    projectile.FollowPlayer(player.Center, 16000f, 0f, Vector2.Zero, 20f, false, 1f);
                    if (projectile.Hitbox.Intersects(player.Hitbox))
                    {
                        player.HealLife((int)projectile.ai[1]); 
                        player.Calamity().aquaticBoost -= 0.002f * 60f;
                        if (player.Calamity().aquaticBoost < 0f) player.Calamity().aquaticBoost = 0f;
                        projectile.Kill();
                    }
                }
            }
            else
            {
                if (ai0 < 10030)
                {
                    projectile.ai[0]++;
                    projectile.velocity *= 0.96f;
                }
                else
                {
                    float dist = 1600f;
                    NPC target = null;
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
                    if (target == null) projectile.velocity *= 0.96f;
                    else projectile.FollowPlayer(target.Center, 1600f, 0f, Vector2.Zero, 32f, false, 0.5f);
                }
            }
            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.AmberBolt);
            dust.velocity = Vector2.Zero; dust.scale *= 1.2f;
        }
        public override bool CanDamage() => projectile.ai[0] > 10000;
        public override bool? CanCutTiles() => projectile.ai[0] > 10000;
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 18; i++)
            {
                Vector2 rot = MathHelper.ToRadians(360 * i / 18f).ToRotationVector2();
                Dust dust = Dust.NewDustPerfect(projectile.Center, DustID.AmberBolt);
                dust.scale *= 1.4f; dust.noGravity = true; dust.velocity = rot * 4f;
            }
        }
    }
}