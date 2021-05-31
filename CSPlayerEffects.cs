using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CalamitySouls.Buffs;
using CalamitySouls.Items;
using CalamitySouls.Projectiles;
using CalamityMod.CalPlayer;
using CalamityMod.Buffs.Summon;
using CalamityMod.Projectiles.Summon;
using CalamityMod.Projectiles.Pets;
using CalamityMod;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using static System.Math;

namespace CalamitySouls
{
    public class CSPlayerEffects
    {
        public static void PostUpdateEquips(Player player)
        {
            CSPlayer mplayer = player.CS();
            float liferadius = player.statLife / (float)player.statLifeMax2;
            CalamityPlayer cplayer = player.Calamity();
            if (mplayer.ForceTechnical)
            {
                int shield = ProjectileType<WulfrumShield>();
                if (player.ownedProjectileCounts(shield) < 1 && player.whoAmI == Main.myPlayer)
                    Projectile.NewProjectile(player.Center, Vector2.Zero, shield, 0, 0f, player.whoAmI);

                mplayer.PlagueReaperPlague = true;
                player.wingTime = player.wingTimeMax;
                mplayer.PlagueReaperAdrenaline = true;

                cplayer.dashMod = 8;
                mplayer.PlagueBringerPlague = true;

                cplayer.omniscience = true;
                player.findTreasure = true;
                player.detectCreature = true;
                player.dangerSense = true;
                player.allDamage += 0.05f;
                player.ModifyAllCrit(5);
                player.manaCost -= 0.05f;
                player.endurance += 0.05f;
                mplayer.WeaponFireRateBoost += 0.05f;
                player.slotsMinions += 0.5f;
                player.maxTurrets += 1;
                player.statLifeMax2 += 20;

                mplayer.pPrism = true;
                mplayer.PrismaticTrail = true;
            }
            if (mplayer.ForceCreature)
            {
                mplayer.WeaponFireRateBoost += 0.07f;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.AmidiasBlessing>(), 2);

                player.doubleJumpFart = true;
                if (cplayer.dashMod < 1) cplayer.dashMod = 1;
                player.jumpBoost = true;
                player.jumpSpeedBoost += 1.2f;

                player.npcTypeNoAggro[NPCType<CalamityMod.NPCs.SunkenSea.Clam>()] = true;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatDebuffs.Clamity>(), 2);
                player.ModifyAllCrit(10);

                mplayer.WeaponKnockback += 3f;
                mplayer.AllDamageByMult += 0.11f;

                mplayer.CreatureSpore = true;

                player.maxMinions++;
                player.minionDamage += 0.1f;
                mplayer.FathomFishes = true;
                if (player.whoAmI == Main.myPlayer)
                    if (player.ownedProjectileCounts(ProjectileType<FathomFishOtter>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<FathomFishOtter>(), 100, 0f, player.whoAmI);


                cplayer.omegaBlueSet = true;
                player.allDamage -= 0.1f;
                player.ModifyAllCrit(-10);
                cplayer.omegaBlueHentai = true;
                cplayer.omegaBlueCooldown = 1800;
            }
            if (mplayer.ForceAnnihilation)
            {
                player.noFallDmg = true;
                if (!player.wet && !player.mount.Active) player.maxFallSpeed = 15f;
                player.armorPenetration += 10;
                player.slotsMinions += 1;

                mplayer.CanBrimFrenzy = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Frostburn] = true;
                player.buffImmune[BuffID.CursedInferno] = true;
                player.buffImmune[BuffID.ShadowFlame] = true;
                player.buffImmune[BuffID.Burning] = true;
                player.buffImmune[BuffID.Daybreak] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.AbyssalFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.BrimstoneFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.CragsLava>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.DemonFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.GodSlayerInferno>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.HolyFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.LethalLavaBurn>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.Shadowflame>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.DeathModeHot>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatBuffs.BrimflameFrenzyBuff>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.Cooldowns.BrimflameFrenzyCooldown>()] = true;
                player.lavaRose = true;
                player.fireWalk = true;
                player.lavaImmune = true;

                mplayer.CanUmbraphileShealth = true;
                mplayer.UmbraphileShealth = -1;

                mplayer.CanHydrothermicRevive = true;

                mplayer.EmpyreanProj = true;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.XerocRage>(), 2);
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.XerocWrath>(), 2);
                cplayer.throwingDamage -= 0.1f;
                cplayer.throwingCrit -= 5;
                player.allDamage += 0.1f;
                player.ModifyAllCrit(10);

                mplayer.BloodCanOption = true;

                mplayer.FearmongerNerfCancel = true;
                player.lifeRegen += 14;
                player.lifeRegenTime += 7;
                if (player.lifeRegenTime < 1800) player.lifeRegenTime = 1800;
                mplayer.FearmongerCanArea = true;
            }
            if (mplayer.ForceRevolution)
            {
                player.noKnockback = true;
                player.buffImmune[BuffID.WindPushed] = true;
                mplayer.DesertDodge = true;
                player.buffImmune[BuffType<DesertDodgeCD>()] = true;

                player.noFallDmg = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.FrozenLungs>()] = true;
                player.resistCold = true;
                mplayer.SnowFreeze = true;

                Player.jumpHeight += 5;
                player.jumpSpeedBoost += 1.5f;
                player.endurance += 0.05f;
                player.lifeRegen += 5;
                player.lifeRegenTime += 5;
                player.longInvince = true;

                mplayer.DaedalusEvade = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.ExtremeGravity>()] = true;

                mplayer.TarragonLeaves = true;

                cplayer.silvaSet = true;
                cplayer.silvaWings = true;
                mplayer.SilvaBetterRevive = true;
                player.statLifeMax2 += 60;
            }
            if (mplayer.ForceTyranny)
            {
                player.allDamage += 0.21f;
                mplayer.GodslayerAncientOtherworld = true;

                cplayer.godSlayer = true;
                mplayer.GodslayerPhantom = true;
                int grcd = player.FindBuffIndex(BuffType<CalamityMod.Buffs.Cooldowns.GodSlayerCooldown>());
                if (grcd != -1 && player.buffTime[grcd] > 30 * 60) player.buffTime[grcd] = 30 * 60;

                mplayer.AuricRevive = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.VulnerabilityHex>()] = true;
                mplayer.AuricWeaponBoost = true;

                cplayer.shadowSpeed = true;
                cplayer.dsSetBonus = true;
            }
            if (mplayer.EnchAero)
            {
                player.noFallDmg = true;
                if (!player.wet && !player.mount.Active) player.maxFallSpeed = 15f;
                if (!player.HoldingANotSummonWeapon())
                {
                    cplayer.valkyrie = true;
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.FindBuffIndex(BuffType<AerospecSummonSetBuff>()) == -1)
                            player.AddBuff(BuffType<AerospecSummonSetBuff>(), 3600, true);
                        if (player.ownedProjectileCounts(ProjectileType<Valkyrie>()) < 1)
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<Valkyrie>(),
                                (int)(60f * CalamityUtils.MinionDamage(player)), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                player.allDamage += 0.1f;
                player.armorPenetration += 10;
                player.slotsMinions += 1;
                cplayer.throwingVelocity += 0.1f;
                mplayer.AeroFragile = true;
            }
            if (mplayer.EnchAstral)
            {
                player.findTreasure = true;
                player.detectCreature = true;
                player.dangerSense = true;
                player.allDamage += 0.05f;
                player.ModifyAllCrit(5);
                player.manaCost -= 0.05f;
                player.endurance += 0.05f;
                mplayer.WeaponFireRateBoost += 0.05f;
                player.slotsMinions += 0.5f;
                player.maxTurrets += 1;
                player.statLifeMax2 += 20;
                if (liferadius < 0.5f && mplayer.AstralTimer <= 0) mplayer.AstralTimer = (4 + 10 + 4 + 60 * 60) * 60;
            }
            if (mplayer.EnchAuric)
            {
                mplayer.AuricRevive = true;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.TyrantsFury>(), 2);
                player.meleeDamage -= 0.3f;
                player.meleeCrit -= 10;
                player.ModifyAllCrit(10);
                mplayer.AuricHexNerf = true;
                mplayer.AuricWeaponBoost = true;
            }
            if (mplayer.EnchBlood)
            {
                cplayer.bloodflareSet = true;
                player.lifeMagnet = true;
                player.manaMagnet = true;
                mplayer.BloodCanOption = true;
            }
            if (mplayer.EnchBrim)
            {
                mplayer.CanBrimFrenzy = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Frostburn] = true;
                player.buffImmune[BuffID.CursedInferno] = true;
                player.buffImmune[BuffID.ShadowFlame] = true;
                player.buffImmune[BuffID.Burning] = true;
                player.buffImmune[BuffID.Daybreak] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.AbyssalFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.BrimstoneFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.CragsLava>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.DemonFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.GodSlayerInferno>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.HolyFlames>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.LethalLavaBurn>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.Shadowflame>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.DeathModeHot>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatBuffs.BrimflameFrenzyBuff>()] = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.Cooldowns.BrimflameFrenzyCooldown>()] = true;
                player.lavaRose = true;
                player.fireWalk = true;
                player.lavaImmune = true;
            }
            if (mplayer.EnchDaedalus)
            {
                player.statLifeMax2 += 20;
                mplayer.DaedalusEvade = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.ExtremeGravity>()] = true;
                mplayer.DaedalusCrystal = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts(ProjectileType<DaedalusTrueCrystal>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<DaedalusTrueCrystal>(), (int)(150f * player.AverageDamage()), 0f, Main.myPlayer);
                }
            }
            if (mplayer.EnchDemonshade)
            {
                cplayer.shadeRegen = true;
                cplayer.shadowSpeed = true;
                cplayer.dsSetBonus = true;
                cplayer.scalPet = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts(ProjectileType<SCalPet>()) < 1)
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<SCalPet>(), 0, 0f, Main.myPlayer);
                }
            }
            if (mplayer.EnchDesert)
            {
                mplayer.DesertProwler = true;
                player.noKnockback = true;
                player.buffImmune[BuffID.WindPushed] = true;
                mplayer.DesertOverKillSandShark = true;
                mplayer.DesertDodge = true;
            }
            if (mplayer.EnchEmpyrean)
            {
                mplayer.EmpyreanProj = true;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.XerocRage>(), 2);
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.XerocWrath>(), 2);
                cplayer.throwingDamage -= 0.1f;
                cplayer.throwingCrit -= 5;
                player.allDamage += 0.1f;
                player.ModifyAllCrit(10);
                mplayer.EmpyreanSpectre = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts(ProjectileType<EmpyreanSpectre>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<EmpyreanSpectre>(), 0, 0f, player.whoAmI);
                }
            }
            if (mplayer.EnchFathom)
            {
                cplayer.fathomSwarmer = true;
                player.maxMinions++;
                player.minionDamage += 0.1f;
                mplayer.FathomFishes = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts(ProjectileType<FathomFishOtter>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<FathomFishOtter>(), 100, 0f, player.whoAmI);
                    if (player.ownedProjectileCounts(ProjectileType<FathomFish>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<FathomFish>(), 100, 0f, player.whoAmI);
                    if (player.ownedProjectileCounts(ProjectileType<FathomFishAttacker>()) < 1)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<FathomFishAttacker>(), 100, 0f, player.whoAmI);
                }
            }
            if (mplayer.EnchFearmonger)
            {
                mplayer.FearmongerNerfCancel = true;
                player.lifeRegen += 14;
                player.lifeRegenTime += 7;
                if (player.lifeRegenTime < 1800) player.lifeRegenTime = 1800;
                mplayer.FearmongerCanArea = true;
                mplayer.FearmongerCanMark = true;
            }
            if (mplayer.EnchGodslayer)
            {
                cplayer.godSlayer = true;
                mplayer.GodslayerPhantom = true;
                int grcd = player.FindBuffIndex(BuffType<CalamityMod.Buffs.Cooldowns.GodSlayerCooldown>());
                if (grcd != -1 && player.buffTime[grcd] > 30 * 60) player.buffTime[grcd] = 30 * 60;
                mplayer.GodslayerDog = true;
            }
            if (mplayer.EnchGodslayerAncient)
            {
                player.allDamage += 0.21f;
                mplayer.GodslayerAncientCanOtherworld = true;
            }
            if (mplayer.EnchHydrothermic)
            {
                cplayer.ataxiaBlaze = true;
                mplayer.CanHydrothermicRevive = true;
            }
            if (mplayer.EnchMollusk)
            {
                if (!player.HoldingANotSummonWeapon())
                {
                    player.maxMinions += 4;
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.FindBuffIndex(BuffType<ShellfishBuff>()) == -1)
                            player.AddBuff(BuffType<ShellfishBuff>(), 3600, true);
                        if (player.ownedProjectileCounts(ProjectileType<Shellfish>()) < 2)
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<Shellfish>(),
                                (int)(140f * player.MinionDamage()), 0f, player.whoAmI, 0f, 0f);
                    }
                }
                player.npcTypeNoAggro[NPCType<CalamityMod.NPCs.SunkenSea.Clam>()] = true;
                player.AddBuff(BuffType<CalamityMod.Buffs.StatDebuffs.Clamity>(), 2);
                if (mplayer.EnchMollusk) if (player.setBonus != "" && !cplayer.molluskSet) player.ModifyAllCrit(20);
            }
            if (mplayer.EnchOmega)
            {
                cplayer.omegaBlueSet = true;
                cplayer.omegaBlueHentai = true;
                cplayer.omegaBlueCooldown = 1800;
                cplayer.noLifeRegen = true;
            }
            if (mplayer.EnchPlagueBringer)
            {
                player.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.Plague>()] = true;
                cplayer.dashMod = 8;
                cplayer.plaguebringerPistons = true;
                if (!player.HoldingANotSummonWeapon())
                {
                    cplayer.plaguebringerPatronSet = true;
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.FindBuffIndex(BuffType<PlaguebringerSummonBuff>()) == -1)
                            player.AddBuff(BuffType<PlaguebringerSummonBuff>(), 3600, true);
                        if (player.ownedProjectileCounts(ProjectileType<PlaguebringerSummon>()) < 1)
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<PlaguebringerSummon>(),
                                (int)(80f * player.MinionDamage()), 0f, player.whoAmI);
                    }
                }
                Lighting.AddLight(player.Center, 0f, 0.39f, 0.24f);
                mplayer.PlagueBringerPlague = true;
            }
            if (mplayer.EnchPlagueReaper)
            {
                mplayer.PlagueReaperPlague = true;
                mplayer.PlagueReaperFlight = true;
                mplayer.PlagueReaperAdrenaline = true;
                mplayer.AdrenalineDamageBoost += 0.15f;
            }
            if (mplayer.EnchPrismatic)
            {
                cplayer.prismaticSet = true;
                mplayer.pPrism = true;
                mplayer.PrismaticTrail = true;
            }
            if (mplayer.EnchReaver)
            {
                mplayer.ReaverEffect = true;
                if (!player.HoldingANotSummonWeapon())
                {
                    cplayer.reaverOrb = true;
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.FindBuffIndex(BuffType<ReaverSummonSetBuff>()) == -1)
                            player.AddBuff(BuffType<ReaverSummonSetBuff>(), 3600, true);
                        if (player.ownedProjectileCounts(ProjectileType<ReaverOrb>()) < 1)
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f,
                                ProjectileType<ReaverOrb>(), (int)(80f * player.MinionDamage()), 0f, Main.myPlayer, 50f);
                    }
                }
                if (player.statLife <= player.statLifeMax2) player.allDamage += 0.1f;
                mplayer.ReaverPlantera = true;
            }
            if (mplayer.EnchSilva)
            {
                cplayer.silvaSet = true;
                cplayer.silvaWings = true;
                player.statLifeMax2 += 80;
                mplayer.SilvaBetterRevive = true;
            }
            if (mplayer.EnchSnowRuffian)
            {
                player.noFallDmg = true;
                player.buffImmune[BuffType<CalamityMod.Buffs.StatDebuffs.FrozenLungs>()] = true;
                player.resistCold = true;
                mplayer.SnowFreeze = true;
            }
            if (mplayer.EnchStatigel)
            {
                cplayer.slimeGod = true;
                Player.jumpHeight += 5;
                player.jumpSpeedBoost += 1.5f;
                player.longInvince = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(BuffType<StatigelSummonSetBuff>()) == -1)
                        player.AddBuff(BuffType<StatigelSummonSetBuff>(), 3600, true);
                    if (player.ownedProjectileCounts(ProjectileType<SlimeGodMinion>()) < 1)
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<SlimeGodMinion>(),
                            66, 0f, Main.myPlayer);
                }
                mplayer.CanStatigelTeleport = true;
            }
            if (mplayer.EnchSulphurous)
            {
                player.ignoreWater = true;
                mplayer.SulphurousCircle = true;

                cplayer.sulfurJump = true;
                player.doubleJumpFart = true;
                cplayer.dashMod = 1;
                player.jumpBoost = true;
                player.autoJump = true;
                player.slowFall = true;
                player.jumpSpeedBoost += 1.2f;

                player.wingTime = player.wingTimeMax = 0;
                player.rocketTime = 0;
            }
            if (mplayer.EnchTarragon)
            {
                cplayer.tarraSet = true;
                mplayer.TarragonLeaves = true;
                player.ZoneJungle = true;
            }
            if (mplayer.EnchTitan)
            {
                mplayer.WeaponKnockback += 3f;
                player.allDamage += 0.08f;
                mplayer.TitanPower = true;
            }
            if (mplayer.EnchUmbraphile)
            {
                cplayer.umbraphileSet = true;
                mplayer.UmbraphileExplosion = true;
                mplayer.CanUmbraphileShealth = true;
            }
            if (mplayer.EnchVictide)
            {
                if (!player.HoldingANotSummonWeapon())
                {
                    cplayer.urchin = true;
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.FindBuffIndex(BuffType<VictideSummonSetBuff>()) == -1)
                            player.AddBuff(BuffType<VictideSummonSetBuff>(), 3600, true);
                        if (player.ownedProjectileCounts(ProjectileType<Urchin>()) < 1)
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileType<Urchin>(),
                                (int)(8f * (player.allDamage + player.minionDamage - 1f)), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                player.ignoreWater = true;
                if (player.HasBuff(BuffType<CalamityMod.Buffs.StatBuffs.AmidiasBlessing>()))
                {
                    mplayer.WeaponFireRateBoost += 0.07f;
                }
                if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
                {
                    player.moveSpeed += 0.77f;
                }
                if (player.miscCounter % 60 * 60 == 0)
                {
                    player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.AmidiasBlessing>(), 77 * 60);
                }
            }
            if (mplayer.EnchWulfrum)
            {
                if (liferadius < 0.5f)
                {
                    player.statDefense += 5;
                }
                int shield = ProjectileType<WulfrumShield>();
                if (player.ownedProjectileCounts(shield) < 1)
                {
                    if (mplayer.WulfrumShieldCooldown == 0 && player.whoAmI == Main.myPlayer)
                        Projectile.NewProjectile(player.Center, Vector2.Zero, shield, 0, 0f, player.whoAmI);
                }
                else player.statDefense += 6;
            }
        }
        public static void UpdateLifeRegen(Player player)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.StatigelTeleport)
            {
                player.lifeRegen += 5;
                player.lifeRegenTime += 5;
            }
            if (mplayer.EnchVictide && Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
            {
                player.lifeRegen += 7;
            }
        }
        public static void GetWeaponKnockback(Player player, Item item, ref float knockback)
        {
        }
        public static void ModifyHitByAnthing(Player player, ref int damage, ref bool crit, NPC npc = null, Projectile proj = null)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.AeroFragile)
            {
                double dmult = 1.3;
                damage = (int)(Pow(damage, dmult) / Pow(50, dmult - 1));
            }
        }
        public static void OnHitByAnything(Player player, NPC npc, Projectile proj, int damage, bool crit)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.GodslayerAncientOtherworld && proj != null && !CalamityLists.projectileDestroyExceptionList.Contains(proj.type))
            {
                proj.friendly = true;
                proj.hostile = false;
                proj.owner = player.whoAmI;
                proj.velocity = -proj.velocity;
                proj.damage *= 40;
            }
        }
        public static bool CanBeHitByNPC(Player player, NPC npc, ref int cooldownSlot)
        {
            CSPlayer mplayer = player.CS();
            return true;
        }
        public static bool Shoot(Player player, Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.Calamity();
            Vector2 velocity = new Vector2(speedX, speedY);
            if (mplayer.ReaverEffect && cplayer.canFireReaverRangedProjectile)
            {
                cplayer.canFireReaverRangedProjectile = false;
                if (player.whoAmI == Main.myPlayer)
                {
                    Projectile rocket = Projectile.NewProjectileDirect(position, velocity * 1.25f,
                           ProjectileType<CalamityMod.Projectiles.Ranged.MiniRocket>(), 150, 2f, player.whoAmI);
                    rocket.GetItemDamageType(item);
                }
            }
            return true;
        }
        public static bool UseItem(Item item, Player player)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.TitanPowerBuff && item.damage > 0 && player.itemAnimation == player.itemAnimationMax - 1)
            {
                Color color = Utils.NextBool(Main.rand) ? new Color(159, 54, 94) : new Color(26, 63, 100);
                string power = "POWER!";
                if (CSUtils.GameCultureChinese) power = "抛瓦！";
                CombatText.NewText(player.Hitbox, color, power);
            }
            if (mplayer.UmbraphileShealth > 0) mplayer.UmbraphileShealth = 0;
            return false;
        }
        public static bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.Calamity();
            if (mplayer.cCVaccines)
            {
                damage = (int)(damage * 0.01f);
                crit = false;
                if (Main.rand.Next(5) != 0)
                {
                    mplayer.ImmunityTime += 4 * 60;
                    return false;
                }
            }
            if (mplayer.DaedalusEvade && mplayer.DaedalusEvadeCooldown == 0)
            {
                if (player.whoAmI == Main.myPlayer)
                    for (int i = 0; i < 12; i++)
                    {
                        Vector2 rotate = MathHelper.ToRadians(i * 30f).ToRotationVector2();
                        Projectile shard = Projectile.NewProjectileDirect(player.Center + rotate * 16f, rotate * 10f,
                            ProjectileType<CalamityMod.Projectiles.Magic.IceSpike>(),
                            (int)(player.AverageDamage() * 200f), 12f, player.whoAmI);
                        shard.GetPlayerDamageType(player); shard.extraUpdates = 1;
                    }
                mplayer.ImmunityTime += player.longInvince ? 4 * 60 : 2 * 60;
                mplayer.DaedalusEvadeCooldown = 45 * 60;
                return false;
            }
            if (mplayer.DesertDodgeBuff)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    Projectile sStorm = Projectile.NewProjectileDirect(player.Center, Vector2.Zero, ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.DesertTornado>(),
                        50, 4f, player.whoAmI);
                    sStorm.ranged = false; sStorm.timeLeft = 60;
                }
                for (int i = 0; i < 36; i++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Sandnado);
                    dust.scale *= 3f;
                }
                player.ClearBuff(ModContent.BuffType<DesertDodgeBuff>());
                player.AddBuff(ModContent.BuffType<DesertDodgeCD>(), 60 * 60);
                mplayer.ImmunityTime += 2 * 60;
                player.velocity = -Vector2.UnitY * 15f;
                damage = 0; playSound = false; customDamage = false; crit = false; hitDirection = 0;
                return false;
            }
            if (mplayer.GodslayerAncientOtherworld)
            {
                return false;
            }
            return true;
        }
        public static void PostHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.GetModPlayer<CalamityPlayer>();
            if (mplayer.FearmongerCanArea && mplayer.FearmongerAreaTimer == 0)
            {
                Main.PlaySound(SoundID.Item46, player.Center);
                mplayer.FearmongerAreaTimer = 30 * 60;
                if (player.whoAmI == Main.myPlayer)
                {
                    Projectile area = Projectile.NewProjectileDirect(player.Center, Vector2.Zero,
                           ProjectileType<FearmongerAreaProj>(), 0, 0f, player.whoAmI);
                    area.Center = player.Center;
                }
            }
            if (mplayer.ReaverEffect)
            {
                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                float startAngle4 = player.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 / 2;
                float deltaAngle4 = MathHelper.PiOver4 / 8f;
                int rDamage = (int)(58f * player.AverageDamage());
                if (player.whoAmI == Main.myPlayer && damage > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        float xPos2 = Utils.NextBool(Main.rand, 2) ? (player.Center.X + 100f) : (player.Center.X - 100f);
                        Vector2 spawnPos2 = new Vector2(xPos2, player.Center.Y + Main.rand.Next(-100, 101));
                        Vector2 offsetAngle4 = (startAngle4 + deltaAngle4 * (i + i * i) / 2f + (32f * i)).ToRotationVector2();
                        Projectile rspore = Projectile.NewProjectileDirect(spawnPos2, offsetAngle4 * 5f,
                            ProjectileType<CalamityMod.Projectiles.Typeless.ReaverSpore>(), rDamage, 2f, player.whoAmI);
                        rspore.usesLocalNPCImmunity = true;
                        rspore.localNPCHitCooldown = 60;
                        rspore.GetPlayerDamageType(player);
                        rspore = Projectile.NewProjectileDirect(spawnPos2, -offsetAngle4 * 5f,
                            ProjectileType<CalamityMod.Projectiles.Typeless.ReaverSpore>(), rDamage, 2f, player.whoAmI, 1f);
                        rspore.usesLocalNPCImmunity = true;
                        rspore.localNPCHitCooldown = 60;
                        rspore.GetPlayerDamageType(player);
                    }
                }
                player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.ReaverRage>(), 180, true);
            }
            if (mplayer.SnowFreeze)
            {
                for (int j = 0; j < 36; j++)
                {
                    Vector2 rotate = MathHelper.ToRadians(j * 10f).ToRotationVector2();
                    Dust dust = Dust.NewDustPerfect(player.Center, DustID.BlueCrystalShard);
                    dust.noGravity = true;
                    dust.scale *= 3f;
                    dust.velocity = rotate * 8f;
                    dust.velocity.Y /= 2;
                }
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    float maxdist = 320f;
                    if (npc.active && !npc.friendly && !npc.dontTakeDamage && npc.Distance(player.Center) < maxdist)
                    {
                        npc.buffImmune[ModContent.BuffType<Frozen>()] = false;
                        npc.AddBuff(ModContent.BuffType<Frozen>(), 6 * 60);
                        npc.AddBuff(BuffID.Frostburn, 6 * 60);
                    }
                }
                player.AddBuff(ModContent.BuffType<Frozen>(), 1 * 60);
            }
        }
        public static void OnHitNPCWithAnything(Player player, NPC target, int damage, float knockback, bool crit, Projectile proj = null, Item item = null)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.Calamity();
            if (mplayer.CreatureSpore)
            {
                target.AddBuff(BuffID.Ichor, 10 * 60);
                target.AddBuff(BuffID.CursedInferno, 10 * 60);
                target.AddBuff(BuffID.Venom, 10 * 60);
                if ((proj == null || !proj.IsAExtraProjectile()) && player.whoAmI == Main.myPlayer)
                {
                    Vector2 velocity = CalamityUtils.RandomVelocity(100f, 70f, 100f, 0.1f);
                    Projectile spore = Projectile.NewProjectileDirect(target.Center, velocity, ProjectileID.TerrarianBeam,
                      (int)(damage * 0.05f), 0f, player.whoAmI);
                    spore.penetrate = -1;
                    spore.timeLeft = 10;
                    spore.usesLocalNPCImmunity = true;
                    spore.localNPCHitCooldown = 30;
                    spore.GetPlayerDamageType(player);
                }
            }
            if (mplayer.EnchBlood)
            {
                if (Main.rand.Next(500) == 0)
                {
                    Item.NewItem(target.Center, ItemID.Heart);
                }
                if (Main.rand.Next(500) == 0)
                {
                    Item.NewItem(target.Center, ItemID.Star);
                }
                if (Main.rand.Next(200) == 0)
                {
                    int HealAmt = (int)(damage / 500.0);
                    if (HealAmt < 1) HealAmt = 1;
                    player.statLife += HealAmt;
                    player.HealEffect(HealAmt, false);
                }
            }
            if (mplayer.DesertProwler)
            {
                int DesertMark = ProjectileType<CalamityMod.Projectiles.Ranged.DesertMark>();
                int DesertTornado = ProjectileType<CalamityMod.Projectiles.Ranged.DesertTornado>();
                if (player.ownedProjectileCounts(DesertMark) < 1 && player.ownedProjectileCounts(DesertTornado) < 1
                    && Utils.NextBool(Main.rand, 15) && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(target.Center, Vector2.Zero, DesertMark, CalamityUtils.DamageSoftCap(damage, 50), knockback, player.whoAmI, 0f, 0f);
                }
            }
            if (mplayer.EmpyreanProj)
            {
                Vector2 velocity = CalamityUtils.RandomVelocity(100f, 15f, 15f, 1f);
                if (proj != null && !CSLists.ExtraProjectileList.Contains(proj.type))
                {
                    Vector2 Center = ((proj == null) ? target.Center : proj.Center);
                    int damage2 = damage;
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            {
                                damage2 = (int)(damage2 * 0.8f); if (damage2 <= 0) break;
                                Projectile Orb = Projectile.NewProjectileDirect(Center, velocity * (Main.rand.Next(15, 30) / 15),
                                         ProjectileType<CalamityMod.Projectiles.Typeless.XerocStar>(),
                                         damage2, 0f, player.whoAmI, target.whoAmI, 0f);
                                if (proj != null) CSUtils.CopyProjDamageType(Orb, proj);
                                else if (item != null) CSUtils.GetItemDamageType(Orb, item);
                                else CSUtils.GetItemDamageType(Orb, player.HeldItem);
                                break;
                            }
                        case 1:
                            {
                                damage2 = (int)(damage2 * 0.625f); if (damage2 <= 0) break;
                                Projectile Orb = Projectile.NewProjectileDirect(Center, velocity * 2f,
                                    ProjectileType<CalamityMod.Projectiles.Typeless.XerocOrb>(),
                                    damage2, 0f, player.whoAmI, target.whoAmI, 0f);
                                if (proj != null) CSUtils.CopyProjDamageType(Orb, proj);
                                else if (item != null) CSUtils.GetItemDamageType(Orb, item);
                                else CSUtils.GetItemDamageType(Orb, player.HeldItem);
                                if (target.canGhostHeal && Main.player[Main.myPlayer].lifeSteal > 0f)
                                {
                                    if (proj != null)
                                    {
                                        float healMult9 = 0.06f - proj.numHits * 0.015f;
                                        float heal10 = damage * healMult9;
                                        if (healMult9 >= 1 && heal10 >= 1)
                                        {
                                            CalamityMod.Projectiles.CalamityGlobalProjectile.SpawnLifeStealProjectile(proj,
                                                player, heal10, ProjectileType<CalamityMod.Projectiles.Healing.XerocHealOrb>(), 1200f, 1.5f);
                                        }
                                    }
                                    else
                                    {
                                        float heal = damage * 0.03f;
                                        player.lifeSteal -= heal * 1.5f;
                                        if (heal >= 1) Projectile.NewProjectile(Center, Vector2.Zero, ProjectileType<CalamityMod.Projectiles.Healing.XerocHealOrb>(),
                                            0, 0f, player.whoAmI, player.whoAmI, heal);
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                damage2 = (int)(damage2 * 0.15); if (damage2 <= 0) break;
                                Projectile.NewProjectile(Center, Vector2.Zero, ProjectileType<CalamityMod.Projectiles.Typeless.XerocFire>(),
                             damage2, 0f, player.whoAmI, 0f, 0f);
                                break;
                            }
                        case 3:
                            {
                                damage2 = (int)(damage2 * 0.2); if (damage2 <= 0) break;
                                Projectile.NewProjectile(Center, Vector2.Zero, ProjectileType<CalamityMod.Projectiles.Typeless.XerocBlast>(),
                       damage2, 0f, player.whoAmI, 0f, 0f);
                                break;
                            }
                        case 4:
                            {
                                damage2 = (int)(damage2 * 0.6); if (damage2 <= 0) break;
                                Projectile Orb = Projectile.NewProjectileDirect(Center, velocity,
                                    ProjectileType<CalamityMod.Projectiles.Typeless.XerocBubble>(),
                                  damage2, 0f, player.whoAmI, target.whoAmI, 0f);
                                if (proj != null) CSUtils.CopyProjDamageType(Orb, proj);
                                else if (item != null) CSUtils.GetItemDamageType(Orb, item);
                                else CSUtils.GetItemDamageType(Orb, player.HeldItem);
                                break;
                            }
                    }
                }
            }
            if (mplayer.GodslayerDog)
            {
                if (cplayer.godSlayerDmg <= 0f && proj != null && !CSLists.ExtraProjectileList.Contains(proj.type))
                {
                    CalamityMod.Projectiles.CalamityGlobalProjectile.SpawnOrb(proj, damage,
                        ProjectileType<CalamityMod.Projectiles.Typeless.GodSlayerPhantom>(), 800f, 15f, true);
                    cplayer.godSlayerDmg += damage * 0.5f;
                }
            }
            if (mplayer.PlagueBringerPlague)
            {
                target.AddBuff(BuffType<CalamityMod.Buffs.DamageOverTime.Plague>(), 600);
                target.buffImmune[BuffType<CalamityMod.Buffs.DamageOverTime.Plague>()] = false;
            }
            if (mplayer.ReaverEffect)
            {
                target.AddBuff(BuffID.Ichor, 10 * 60);
                target.AddBuff(BuffID.CursedInferno, 10 * 60);
                target.AddBuff(BuffID.Venom, 10 * 60);
                if ((proj == null || !proj.IsAExtraProjectile()) && player.whoAmI == Main.myPlayer)
                {
                    if (proj != null)
                    {
                        Projectile blast = Projectile.NewProjectileDirect(proj.Center, Vector2.Zero,
                            ProjectileType<CalamityMod.Projectiles.Typeless.ReaverBlast>(), CalamityUtils.DamageSoftCap(proj.damage * 0.1f, 15), 0f, player.whoAmI);
                        blast.CopyProjDamageType(proj);
                        Vector2 velocity = CalamityUtils.RandomVelocity(100f, 70f, 100f, 0.1f);
                        Projectile spore = Projectile.NewProjectileDirect(proj.Center, velocity, ProjectileID.SporeGas + Main.rand.Next(3),
                            CalamityUtils.DamageSoftCap(proj.damage * 0.05f, 15), 0f, proj.owner);
                        spore.usesLocalNPCImmunity = true;
                        spore.localNPCHitCooldown = 30;
                        spore.GetPlayerDamageType(player);
                    }
                }
            }
            if (mplayer.TarragonLeaves && mplayer.TarragonLeavesCoolDown)
            {
                Item.NewItem(target.Center, TarragonLeaves.GetRandomTarragonLeaves(), 1, true);
                mplayer.TarragonLeavesCoolDown = false;
            }
            if (mplayer.UmbraphileExplosion && proj != null)
            {
                if (!proj.Calamity().rogue && (Utils.NextBool(Main.rand, 4)) && !proj.IsAExtraProjectile())
                {
                    Projectile explosion = Projectile.NewProjectileDirect(proj.Center, Vector2.Zero,
                        ProjectileType<CalamityMod.Projectiles.Rogue.UmbraphileBoom>(), CalamityUtils.DamageSoftCap(proj.damage * 0.25, 50), 0f, player.whoAmI);
                    explosion.CopyProjDamageType(proj);
                }
            }
        }
        public static void ModifyHitNPCWithAnything(Player player, NPC target, ref int damage, ref float knockback, ref bool crit, Item item = null, Projectile proj = null)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.Calamity();
            float mult = 0f;
            float flat = 0f;
            if (mplayer.AuricWeaponBoost)
            {
                if (proj != null && proj.type == ProjectileType<CalamityMod.Projectiles.Magic.DarkSparkBeam>()) damage *= 15;
            }
            if (mplayer.DesertOverKillSandShark)
                if (target.type == NPCID.SandElemental || target.type == NPCID.SandShark || target.type == NPCType<CalamityMod.NPCs.GreatSandShark.GreatSandShark>())
                {
                    mult += 1f;
                }
            if (mplayer.FearmongerNerfCancel && proj != null)
            {
                bool forbidden = player.head == 200 && player.body == 198 && player.legs == 142;
                Item heldItem = player.ActiveItem();
                float summonNerfMult = (cplayer.fearmongerSet || (forbidden && heldItem.magic)) ? 0.75f : 0.5f;
                if (proj.IsSummon() && !cplayer.profanedCrystalBuffs && heldItem.type > ItemID.None && !heldItem.summon
                    && (heldItem.melee || heldItem.ranged || heldItem.magic || heldItem.Calamity().rogue)
                    && heldItem.hammer == 0 && heldItem.pick == 0 && heldItem.axe == 0 && heldItem.useStyle != 0 && !heldItem.accessory && heldItem.ammo == AmmoID.None)
                {
                    damage = (int)(damage / summonNerfMult);
                }
            }
            if (mplayer.FearmongerCanMark && mplayer.FearmongerMark != -1)
            {
                if (target.whoAmI == mplayer.FearmongerMark) mult += 0.25f;
                else mult -= 0.5f;
            }
            if (mplayer.PlagueReaperPlague && target.Calamity().pFlames > 0) mult += 0.1f;
            if (mplayer.PlagueBringerPlague && target.Calamity().pFlames > 0) flat += 11.11f;
            if (mplayer.ReaverPlantera)
            {
                if (proj != null)
                {
                    List<int> planteraProjList = new List<int>
                    {
                        ProjectileType<PlantSummon>(),
                        ProjectileType<PlantTentacle>(),
                    };
                    if (planteraProjList.Contains(proj.type)) mult += 1f;
                }
            }
            if (mplayer.UmbraphileShealth == -1)
            {
                mult += 1f;
                mplayer.UmbraphileShealth = 0;
            }
            damage = (int)(damage * (mult + mplayer.AllDamageByMult) + flat);
            float adrenalineDamageBoost = 2f + (cplayer.adrenalineBoostOne ? 0.15f : 0f)
                + (cplayer.adrenalineBoostTwo ? 0.15f : 0) + (cplayer.adrenalineBoostThree ? 0.15f : 0);
            if (cplayer.adrenalineModeActive) damage = (int)(damage * (adrenalineDamageBoost + 1 - mplayer.AdrenalineDamageBoost) / adrenalineDamageBoost);
        }
        public static bool PreKill(Player player, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            CSPlayer mplayer = player.CS();
            CalamityPlayer cplayer = player.Calamity();
            if (mplayer.AuricRevive)
            {
                if (mplayer.AuricReviveCooldown1 == 0)
                {
                    Main.PlaySound(SoundID.Item67, player.Center);
                    player.statLife = player.statLifeMax2;
                    mplayer.ImmunityTime += 2 * 60;
                    mplayer.AuricReviveCooldown1 = 56 * 60;
                    int rand = Main.rand.Next(360);
                    for (int i = 0; i < 16; i++)
                    {
                        Vector2 rotate = MathHelper.ToRadians(i * 360f / 16f + rand).ToRotationVector2();
                        Dust dust = Dust.NewDustPerfect(player.Center, DustID.GoldFlame);
                        dust.velocity = rotate * 6f;
                        dust.velocity.Y *= 0.8f;
                        dust.scale *= 3f;
                        dust.noLight = true;
                    }
                    return false;
                }
                if (mplayer.AuricReviveCooldown2 == 0)
                {
                    Main.PlaySound(SoundID.Item67, player.Center);
                    player.statLife = player.statLifeMax2;
                    mplayer.ImmunityTime += 2 * 60;
                    mplayer.AuricReviveCooldown2 = 56 * 60;
                    int rand = Main.rand.Next(360);
                    for (int i = 0; i < 16; i++)
                    {
                        Vector2 rotate = MathHelper.ToRadians(i * 360f / 16f + rand).ToRotationVector2();
                        Dust dust = Dust.NewDustPerfect(player.Center, DustID.GoldFlame);
                        dust.velocity = rotate * 6f;
                        dust.velocity.Y *= 0.8f;
                        dust.scale *= 3f;
                        dust.noLight = true;
                    }
                    return false;
                }
            }
            if (mplayer.CanHydrothermicRevive && mplayer.HydrothermicReviveCooldown <= 0)
            {
                player.statLife = 10;
                mplayer.HydrothermicReviveCooldown = 120 * 60;
                return false;
            }
            return true;
        }
        public static void PostUpdateBuffs(Player player)
        {
            CSPlayer mplayer = player.CS();
        }
        public static void PostUpdateMiscEffects(Player player)
        {
            CalamityPlayer cplayer = player.Calamity();
            CSPlayer mplayer = player.CS();
            if (mplayer.AstralTimer >= (10 + 4 + 60 * 60) * 60)
            {
                player.DoAVisualBuff(BuffType<AstralImmunity>(), mplayer.AstralTimer - (10 + 4 + 60 * 60) * 60);
                if (mplayer.ImmunityTime < 2)
                    mplayer.ImmunityTime = 2;
            }
            else if (mplayer.AstralTimer >= (4 + 60 * 60) * 60)
            {
                player.DoAVisualBuff(BuffType<AstralDivision>(), mplayer.AstralTimer - (4 + 60 * 60) * 60);
                mplayer.WeaponFireRateBoost *= 2f;
                player.slotsMinions *= 2f;
                player.maxTurrets *= 2;
                player.statLifeMax2 *= 2;
            }
            else if (mplayer.AstralTimer >= 60 * 60 * 60)
            {
                player.DoAVisualBuff(BuffType<AstralImmunity>(), mplayer.AstralTimer - 60 * 60 * 60);
                if (mplayer.ImmunityTime < 2)
                    mplayer.ImmunityTime = 2;
            }
            if (mplayer.AuricReviveCooldown1 > 0)
            {
                mplayer.AuricReviveCooldown1--;
                player.DoAVisualBuff(BuffType<AuricReviveCooldown>(), mplayer.AuricReviveCooldown1);
            }
            if (mplayer.AuricReviveCooldown2 > 0)
            {
                mplayer.AuricReviveCooldown2--;
                player.DoAVisualBuff(BuffType<AuricReviveCooldown>(), mplayer.AuricReviveCooldown2);
            }
            if (mplayer.AuricHexNerf && cplayer.vHex)
            {
                cplayer.contactDamageReduction += 0.2;
                cplayer.projectileDamageReduction += 0.2;
                player.blind = false;
                player.statDefense += 20;
                player.moveSpeed += 0.1f;
                player.wingTimeMax *= 2;
                player.endurance += 0.3f;
            }
            if (mplayer.BrimFrenzy > 0)
            {
                player.DoAVisualBuff(BuffType<BrimFrenzy>(), mplayer.BrimFrenzy);
                mplayer.AllDamageByMult += 0.25f;
            }
            if (mplayer.BrimFrenzyCooldown > 0)
            {
                player.DoAVisualBuff(BuffType<BrimFrenzyCooldown>(), mplayer.BrimFrenzyCooldown);
            }
            if (mplayer.BrimFrenzyVisualEffect > 0)
            {
                Lighting.AddLight(player.Center, 2.55f, 2f, 2f);
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    Projectile projectile = Main.projectile[i];
                    if (projectile.active && !projectile.friendly && projectile.hostile && projectile.Distance(player.Center) <= 960f
                        && !CalamityLists.projectileDestroyExceptionList.Contains(projectile.type))
                    {
                        if (Main.rand.Next((projectile.tileCollide ? 1 : 2) * 30) == 0)
                        {
                            Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, 0, 0f, 255);
                            projectile.Kill();
                        }
                    }
                }
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && !npc.friendly && npc.Distance(player.Center) < 960f && !npc.dontTakeDamage)
                    {
                        npc.Strike(50, player);
                    }
                }
            }
            if (mplayer.DaedalusEvadeCooldown > 0)
            {
                player.ClearBuff(BuffType<DaedalusEvadeCooldown>());
                player.AddBuff(BuffType<DaedalusEvadeCooldown>(), mplayer.DaedalusEvadeCooldown + 2);
            }
            if (mplayer.DesertDodge)
            {
                if (!mplayer.DesertDodgeCD)
                {
                    bool flag = (player.velocity.Length() <= 0.1f) && (player.itemAnimation <= 0);
                    if (flag) mplayer.DesertDodgeTimer++;
                    else mplayer.DesertDodgeTimer = 0;
                    if (mplayer.DesertDodgeTimer > 5 * 60) player.AddBuff(BuffType<DesertDodgeBuff>(), 5 * 60);
                }
            }
            else
            {
                mplayer.DesertDodgeTimer = 0;
                if (mplayer.DesertDodgeBuff) player.ClearBuff(BuffType<DesertDodgeBuff>());
            }
            if (mplayer.FearmongerCanArea)
            {
                if (mplayer.FearmongerAreaTimer > 0)
                {
                    player.DoAVisualBuff(BuffType<FearmongerAreaCooldown>(), mplayer.FearmongerAreaTimer);
                    mplayer.FearmongerAreaTimer--;
                }
                if (mplayer.FearmongerAreaTimer > 25 * 60)
                {
                    player.DoAVisualBuff(BuffType<FearmongerArea>(), mplayer.FearmongerAreaTimer - 25 * 60);
                }
            }
            if (mplayer.FearmongerCanMark)
            {
                if (mplayer.FearmongerMarkCooldown > 0)
                {
                    player.DoAVisualBuff(BuffType<FearmongerMarkCooldown>(), mplayer.FearmongerMarkCooldown);
                    mplayer.FearmongerMarkCooldown--;
                }
                if (mplayer.FearmongerMark != -1 && !Main.npc[mplayer.FearmongerMark].active)
                {
                    mplayer.FearmongerMark = -1;
                }
            }
            if (mplayer.Frozen)
            {
                player.statDefense += 12;
            }
            if (mplayer.GodslayerAncientCanOtherworld)
            {
                mplayer.GodslayerAncientOtherworldTimer++;
                if (player.itemAnimation > 0) mplayer.GodslayerAncientOtherworldTimer = 0;
                if (mplayer.GodslayerAncientOtherworldTimer > 120)
                {
                    player.AddBuff(BuffType<GodslayerAncientOtherworld>(), 2);
                    if (player.velocity.Length() > 14f) mplayer.GodslayerAncientOtherworld = true;
                }
            }
            if (mplayer.CanHydrothermicRevive && mplayer.HydrothermicReviveCooldown > 0)
            {
                mplayer.HydrothermicReviveCooldown--;
                player.DoAVisualBuff(BuffType<HydrothermicReviveCooldown>(), mplayer.HydrothermicReviveCooldown);
            }
            if (mplayer.PlagueReaperFlight)
            {
                player.wingTimeMax += 60;
                cplayer.caveDarkness = 0.75f + cplayer.caveDarkness * 0.25f;
            }
            if (mplayer.pPrism)
            {
                int prism = ProjectileType<PrismaticPrismProj>();
                if (player.ownedProjectileCounts(prism) < 1 && player.whoAmI == Main.myPlayer)
                    Projectile.NewProjectile(player.Center, Vector2.Zero, prism, 0, 0f, player.whoAmI);
            }
            if (mplayer.SilvaBetterRevive)
            {
                if (cplayer.hasSilvaEffect && mplayer.SilvaRechargeCounter == 0)
                {
                    mplayer.SilvaRechargeCounter = 180 * 60;
                    player.DoAVisualBuff(BuffType<SilvaRecharge>(), mplayer.SilvaRechargeCounter);
                    if (cplayer.silvaCountdown > 0)
                    {
                        cplayer.silvaCountdown = (cplayer.auricSet ? 2 : 1) * 20 * 60;
                        player.AddBuff(BuffType<CalamityMod.Buffs.StatBuffs.SilvaRevival>(), 20 * 60);
                    }
                }
                if (mplayer.SilvaRechargeCounter > 175 * 60 && cplayer.silvaCountdown > 0)
                {
                    cplayer.silvaHitCounter = 0;
                    player.DoAVisualBuff(BuffType<SilvaInvulnerable>(), mplayer.SilvaRechargeCounter - 175 * 60);
                }
                if (mplayer.SilvaRechargeCounter == 1)
                {
                    cplayer.hasSilvaEffect = false;
                    cplayer.silvaCountdown = 600;
                    cplayer.silvaHitCounter = 0;
                    Main.PlaySound(CSUtils.Cal.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SilvaDispel"), player.Center);
                }
            }
            else
            {
                mplayer.SilvaRechargeCounter = 0;
                player.ClearBuff(BuffType<SilvaRecharge>());
                player.ClearBuff(BuffType<SilvaInvulnerable>());
            }
            if (mplayer.StatigelTeleport)
            {
                player.statDefense += 5;
                player.endurance += 0.05f;
            }
            if (mplayer.SulphurousCircle)
            {
                int rand = Main.rand.Next(360);
                int amt = 120;
                for (int i = 0; i < amt * 2; i++)
                {
                    Vector2 rot = MathHelper.ToRadians(rand + 360f * i / amt / 2f).ToRotationVector2();
                    Dust sulp = Dust.NewDustPerfect(player.Center + rot * 48f, 74);
                    sulp.noGravity = true;
                    sulp.noLight = true;
                    sulp.scale = 0.19f;
                    sulp.velocity = Vector2.Zero;
                }
                if (player.whoAmI == Main.myPlayer)
                    for (int i = 0; i < amt; i++)
                    {
                        Vector2 rot = MathHelper.ToRadians(rand + 360f * i / amt).ToRotationVector2();
                        Dust sulp = Dust.NewDustPerfect(Main.MouseWorld + rot * 8f, 74);
                        sulp.noGravity = true;
                        sulp.noLight = true;
                        sulp.scale = 0.19f;
                        sulp.velocity = Vector2.Zero;
                    }
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && !npc.friendly)
                    {
                        int poi = BuffType<CalamityMod.Buffs.DamageOverTime.SulphuricPoisoning>();
                        if (npc.Hitbox.Distance(player.Center) <= 48f)
                        {
                            npc.buffImmune[poi] = false;
                            npc.AddBuff(poi, 5 * 60);
                        }
                        if (player.whoAmI == Main.myPlayer && npc.Hitbox.Distance(Main.MouseWorld) < 8f)
                        {
                            npc.buffImmune[poi] = false;
                            npc.AddBuff(poi, 5);
                        }
                    }
                }
            }
            if (mplayer.TitanPowerBuff)
            {
                if (!mplayer.TitanPower) mplayer.TitanPowerBuff = false;
                else
                {
                    mplayer.AllDamageByMult += 0.75f;
                    mplayer.WeaponFireRateBoost /= 2;
                    int ThisIsANumber = (player.maxMinions % 2 == 0) ? 0 : 1;
                    player.maxMinions = (int)(player.maxMinions / 2f) + ThisIsANumber;
                    player.AddBuff(BuffType<TitanPower>(), 2);
                }
            }
            if (mplayer.CanUmbraphileShealth)
            {
                if (mplayer.UmbraphileShealth >= 0) mplayer.UmbraphileShealth++;
                if (mplayer.UmbraphileShealth >= 5 * 60) mplayer.UmbraphileShealth = -1;
            }
            else
            {
                mplayer.UmbraphileShealth = 0;
            }
            if (mplayer.UmbraphileShealth == -1)
            {
                player.AddBuff(BuffType<UmbraphileUndetected>(), 2);
                if (!CSUtils.AnyBossAlive)
                    for (int i = 0; i < player.npcTypeNoAggro.Length; i++)
                    {
                        player.npcTypeNoAggro[i] = true;
                    }
            }
        }
        public static void PostUpdateRunSpeeds(Player player)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.GodslayerAncientOtherworld)
            {
                player.runAcceleration *= 2;
                if (!CSUtils.AnyBossAlive)
                {
                    player.accRunSpeed *= 2;
                    player.maxRunSpeed *= 2;
                }
            }
        }
        public static void PostUpdate(Player player)
        {
            CalamityPlayer cplayer = player.Calamity();
            CSPlayer mplayer = player.CS();
            if (mplayer.PlagueReaperAdrenaline && CalamityMod.World.CalamityWorld.revenge)
            {
                if (cplayer.adrenaline == cplayer.adrenalineMax) mplayer.PlagueReaperHasAdrenalineCurrently = true;
                if (cplayer.adrenalineModeActive && mplayer.PlagueReaperHasAdrenalineCurrently) mplayer.PlagueReaperHasAdrenalineCurrently = false;
                if (mplayer.PlagueReaperHasAdrenalineCurrently) cplayer.adrenaline = cplayer.adrenalineMax;
            }
            else
            {
                mplayer.PlagueReaperHasAdrenalineCurrently = false;
            }
        }
        public static void ModifyWeaponDamage(Player player, Item item, ref float add, ref float mult, ref float flat)
        {
            CSPlayer mplayer = player.CS();
            if (mplayer.EnchSnowRuffian)
            {
                if (item.Calamity().rogue)
                {
                    int amt = (int)(item.damage * 0.15f);
                    if (amt > 12) flat += 12f;
                    else add += 0.15f;
                }
            }
            if (mplayer.DesertProwler && item.ammo == AmmoID.None) flat += 5f;
        }
    }
}