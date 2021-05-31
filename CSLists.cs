using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Projectiles.Melee.Spears;
using CalamityMod.Projectiles.Melee.Yoyos;
using CalamityMod.Projectiles.Ranged;
using CalamityMod.Projectiles.Magic;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Projectiles.Rogue;
using CalamityMod.Projectiles.Hybrid;
using CalamityMod.Projectiles.Typeless;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls
{
    public class CSLists
    {
        public static void Load()
        {
            WeakIceProjectiles = new List<int>
            {
                ModContent.ProjectileType<DarkIceZero>(),
                ModContent.ProjectileType<ArcticBearPawProj>(),
                ModContent.ProjectileType<IceBombFriendly>(),
                ProjectileID.FrostShard,
                ModContent.ProjectileType<CosmicDischargeFlail>(),
                ModContent.ProjectileType<CosmicIceBurst>(),
                ModContent.ProjectileType<CryoBlast>(),
                ModContent.ProjectileType<CrystalPiercerProjectile>(),
                ModContent.ProjectileType<CrystalPiercerShard>(),
                ProjectileID.BallofFrost,
                ProjectileID.SnowBallFriendly,
                ModContent.ProjectileType<FlurrystormCannonShooting>(),
                ModContent.ProjectileType<FlurrystormIceChunk>(),
                ModContent.ProjectileType<FlurrystormIceShard>(),
                ModContent.ProjectileType<FrostBlossom>(),
                ModContent.ProjectileType<FrostBeam>(),
                ModContent.ProjectileType<FlareBoltProjectile>(),
                ProjectileID.FrostBoltStaff,
                ModContent.ProjectileType<ValariBoomerang>(),
                ModContent.ProjectileType<Valaricicle>(),
                ModContent.ProjectileType<Valaricicle2>(),
                ModContent.ProjectileType<Iceberg>(),
                ModContent.ProjectileType<IceBarrageMain>(),
                ModContent.ProjectileType<IceBlock>(),
                ModContent.ProjectileType<IceBlockIcicle>(),
                ProjectileID.IceBoomerang,
                ProjectileID.FrostArrow,
                ProjectileID.IceBlock,
                ProjectileID.IceSickle,
                ModContent.ProjectileType<IceStarProjectile>(),
                ModContent.ProjectileType<IcebreakerHammer>(),
                ModContent.ProjectileType<IcicleStaffProj>(),
                ProjectileID.NorthPoleWeapon,
                ProjectileID.NorthPoleSpear,
                ProjectileID.NorthPoleSnowflake,
                ModContent.ProjectileType<Snowflake>(),
                ProjectileID.FrostHydra,
                ProjectileID.FrostBlastFriendly,
                ModContent.ProjectileType<StarnightLanceProjectile>(),
                ModContent.ProjectileType<StarnightBeam>(),
                125,123,121,
            };
            NormalIceProjectils = new List<int>
            {
                ProjectileID.Amarok,
                ModContent.ProjectileType<IceClasperMinion>(),
                ModContent.ProjectileType<IceSpike>(),
                ModContent.ProjectileType<SpiritFlameCurse>(),
                ModContent.ProjectileType<ArcticArrowProj>(),
                ModContent.ProjectileType<EndoHydraHead>(),
                ModContent.ProjectileType<EndoRay>(),
                ModContent.ProjectileType<FrostyFlareProj>(),
                ModContent.ProjectileType<FrostyFlareStealth>(),
                ModContent.ProjectileType<FrostShardFriendly>(),
                ModContent.ProjectileType<HypothermiaChunk>(),
                ModContent.ProjectileType<HypothermiaShard>(),
                ModContent.ProjectileType<TridentIcicle>(),
                ModContent.ProjectileType<KelvinCatalystBoomerang>(),
                ModContent.ProjectileType<KelvinCatalystStar>(),
                ModContent.ProjectileType<ShadecrystalProjectile>(),
                ModContent.ProjectileType<ShimmersparkYoyo>(),
                92,
                ModContent.ProjectileType<TemporalFloeSwordProjectile>(),
                ModContent.ProjectileType<TemporalFloeNumberTwo>(),
                ModContent.ProjectileType<Icicle>(),
                ModContent.ProjectileType<Snowball>(),
            };
            StrongIceProjectiles = new List<int>
            {
                ProjectileID.Blizzard,
                ModContent.ProjectileType<IceSentry>(),
                ModContent.ProjectileType<IceSentryFrostBolt>(),
                ModContent.ProjectileType<IceSentryShard>(),
                ModContent.ProjectileType<EndoBeam>(),
                ModContent.ProjectileType<EndoCooperBody>(),
                ModContent.ProjectileType<EndoCooperLimbs>(),
                ModContent.ProjectileType<EndoFire>(),
                ModContent.ProjectileType<EndoIceShard>(),
                ModContent.ProjectileType<IcicleArrowProj>(),
                ProjectileID.RocketSnowmanI,
                ProjectileID.RocketSnowmanII,
                ProjectileID.RocketSnowmanIII,
                ProjectileID.RocketSnowmanIV,
            };
            ExtraProjectileList = new List<int>
            {
                ProjectileType<UmbraphileBoom>(),
                ProjectileType<ReaverBlast>() ,
                ProjectileID.SporeGas,
                ProjectileID.SporeGas2,
                ProjectileID.SporeGas3,
                ProjectileID.TerrarianBeam,
                ProjectileType<XerocStar>(),
                ProjectileType<XerocOrb>(),
                ProjectileType<XerocFire>(),
                ProjectileType<XerocBlast>(),
                ProjectileType<XerocBubble>(),
                ProjectileType<GodSlayerPhantom>(),           
            };
        }
        public static void Unload()
        {
            WeakIceProjectiles = null;
            NormalIceProjectils = null;
            StrongIceProjectiles = null;
        }
        public static List<int> WeakIceProjectiles;
        public static List<int> NormalIceProjectils;
        public static List<int> StrongIceProjectiles;
        public static List<int> ExtraProjectileList;
    }
}
