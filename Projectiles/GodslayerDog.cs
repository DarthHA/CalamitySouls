using System;
	using CalamityMod.Buffs.DamageOverTime;
	using CalamityMod.Buffs.StatDebuffs;
	using Terraria;
	using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalamitySouls.Projectiles
{
	public class GodslayerDoGHead : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devourer of Gods");
		}
		public override void SetDefaults()
		{
			projectile.width = 123;
			projectile.height = 105;
			projectile.alpha = 70;
			projectile.timeLeft = 240;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.light = 1.5f;
		}
		public override void AI()
		{
			if (projectile.timeLeft < 30)
			{
				projectile.alpha = projectile.alpha + 6;
				return;
			}
			if (projectile.timeLeft < 210)
			{
				projectile.velocity = projectile.velocity * 0.9f;
				return;
			}
			if (projectile.timeLeft == 240)
			{
				projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X);
				float num = (float)Math.Sqrt(3748);
				float offsetRotation = (float)Math.Atan2(-38.0, 48.0) + projectile.rotation;
				Vector2 offset = num * offsetRotation.ToRotationVector2();
				if (projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(projectile.Center + offset, projectile.velocity, ModContent.ProjectileType<GodslayerDoGJaw>(),
						projectile.damage, projectile.knockBack, projectile.owner, projectile.rotation);
				}
				offsetRotation = (float)Math.Atan2(38.0, 48.0) + projectile.rotation;
				offset = num * offsetRotation.ToRotationVector2();
				if (projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(projectile.Center + offset, projectile.velocity, ModContent.ProjectileType<GodslayerDoGJaw>(),
						projectile.damage, projectile.knockBack, projectile.owner, projectile.rotation, 1f);
				}
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<GodSlayerInferno>(), 600, true);
			target.AddBuff(ModContent.BuffType<DemonFlames>(), 600, true);
			target.AddBuff(ModContent.BuffType<ArmorCrunch>(), 600, true);
			if (Utils.NextBool(Main.rand, 30))
			{
				target.AddBuff(ModContent.BuffType<ExoFreeze>(), 120, true);
			}
		}
	}
	public class GodslayerDoGJaw : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devourer of Gods");
		}
		public override void SetDefaults()
		{
			projectile.width = 144;
			projectile.height = 72;
			projectile.alpha = 70;
			projectile.timeLeft = 240;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.light = 1.5f;
		}
		public override void AI()
		{
			if (projectile.timeLeft < 30)
			{
				projectile.alpha = projectile.alpha + 6;
				return;
			}
			if (projectile.timeLeft < 210)
			{
				projectile.velocity = projectile.velocity * 0.9f;
				return;
			}
			if (projectile.timeLeft >= 240)
			{
				if (projectile.timeLeft == 240)
				{
					if (projectile.ai[1] == 0f)
					{
						projectile.rotation = projectile.ai[0] - 1.0471976f;
						return;
					}
					projectile.rotation = projectile.ai[0] + 1.0471976f + 3.1415927f;
					projectile.spriteDirection = -1;
				}
				return;
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.rotation += 0.04537856f;
				return;
			}
			projectile.rotation -= 0.04537856f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<GodSlayerInferno>(), 600, true);
			target.AddBuff(ModContent.BuffType<DemonFlames>(), 600, true);
			target.AddBuff(ModContent.BuffType<ArmorCrunch>(), 600, true);
			if (Utils.NextBool(Main.rand, 30))
			{
				target.AddBuff(ModContent.BuffType<ExoFreeze>(), 120, true);
			}
		}
		private const float degrees = 0.034906585f;
	}
}