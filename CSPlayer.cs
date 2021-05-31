using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CalamitySouls.Buffs;
using CalamitySouls.Projectiles;

namespace CalamitySouls
{
    public class CSPlayer : ModPlayer
    {
        public override void UpdateDead()
        {
            AuricReviveCooldown1 = 0;
            AuricReviveCooldown2 = 0;
            ImmunityTime = 0;
            AstralTimer = 0;
            BrimFrenzy = 0;
            BrimFrenzyVisualEffect = 0;
            BrimFrenzyCooldown = 0;
            DaedalusEvadeCooldown = 0;
            GodslayerDogTimer = 0;
            GodslayerAncientOtherworldTimer = 0;
            SilvaRechargeCounter = 0;
            WulfrumShieldCooldown = 0;
            EffectsThatNeedtoReset();
        }
        public override void ResetEffects()
        {
            EffectsThatNeedtoReset();
        }
        public void EffectsThatNeedtoReset()
        {
            WeaponFireRateBoost = 1f;
            if (ImmunityTime > 0)
            {
                ImmunityTime--;
                player.immune = true;
                if (player.immuneTime < 2) player.immuneTime = 2;
            }
            Frozen = false;
            WeaponKnockback = 1f;
            AllDamageByMult = 1f;
            AdrenalineDamageBoost = 1f;

            cCVaccines = false;
            pPrism = false;

            CreatureSpore = false;

            AeroFragile = false;
            if (AstralTimer > 0) AstralTimer--;
            AuricRevive = false;
            AuricHexNerf = false;
            AuricWeaponBoost = false;
            BloodCanOption = false;
            player.statLifeMax2 -= (int)(player.statLifeMax2 * BloodOptionAmount / 10f);
            BloodOptionAmount = 0;
            if (BrimFrenzy == 1)
            {
                BrimFrenzyCooldown = 25 * 60;
                Main.PlaySound(CSUtils.Cal.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/BrimflameRecharge"), player.Center);
            }
            if (BrimFrenzy > 0) BrimFrenzy--;
            if (BrimFrenzyVisualEffect > 0) BrimFrenzyVisualEffect--;
            if (CanBrimFrenzy && BrimFrenzyCooldown > 0) BrimFrenzyCooldown--;
            CanBrimFrenzy = false;
            DaedalusEvade = false;
            if (DaedalusEvadeCooldown > 0) DaedalusEvadeCooldown--;
            DaedalusCrystal = false;
            DesertProwler = false;
            DesertOverKillSandShark = false;
            DesertDodge = false;
            DesertDodgeBuff = false;
            DesertDodgeCD = false;
            EmpyreanProj = false;
            EmpyreanSpectre = false;
            FathomFishes = false;
            FearmongerNerfCancel = false;
            FearmongerCanArea = false;
            FearmongerCanMark = false;
            GodslayerPhantom = false;
            if (GodslayerDog && GodslayerDogTimer > 0) GodslayerDogTimer--;
            GodslayerDog = false;
            if (!GodslayerAncientCanOtherworld) GodslayerAncientOtherworldTimer = 0;
            GodslayerAncientCanOtherworld = false;
            GodslayerAncientOtherworld = false;
            CanHydrothermicRevive = false;
            PlagueBringerPlague = false;
            PlagueReaperPlague = false;
            PlagueReaperFlight = false;
            PlagueReaperAdrenaline = false;
            PrismaticTrail = false;
            ReaverEffect = false;
            ReaverPlantera = false;
            SilvaBetterRevive = false;
            if (SilvaRechargeCounter > 0) SilvaRechargeCounter--;
            SnowFreeze = false;
            CanStatigelTeleport = false;
            SulphurousCircle = false;
            TarragonLeaves = false;
            if (player.miscCounter % 30 == 0) TarragonLeavesCoolDown = true;
            TitanPower = false;
            UmbraphileExplosion = false;
            CanUmbraphileShealth = false;
            if (WulfrumShieldCooldown > 0) WulfrumShieldCooldown--;

            ForceAnnihilation = false;
            ForceCreature = false;
            ForceRevolution = false;
            ForceTechnical = false;
            ForceTyranny = false;
            EnchAero = false;
            EnchAstral = false;
            EnchAuric = false;
            EnchBlood = false;
            EnchBrim = false;
            EnchDaedalus = false;
            EnchDemonshade = false;
            EnchDesert = false;
            EnchEmpyrean = false;
            EnchFathom = false;
            EnchFearmonger = false;
            EnchGodslayer = false;
            EnchGodslayerAncient = false;
            EnchHydrothermic = false;
            EnchMollusk = false;
            EnchOmega = false;
            EnchPlagueBringer = false;
            EnchPlagueReaper = false;
            EnchPrismatic = false;
            EnchReaver = false;
            EnchSilva = false;
            EnchSnowRuffian = false;
            EnchStatigel = false;
            EnchSulphurous = false;
            EnchTarragon = false;
            EnchTitan = false;
            EnchUmbraphile = false;
            EnchVictide = false;
            EnchWulfrum = false;
        }
        #region TONs of effects
        public override void PostUpdateEquips()
        {
            CSPlayerEffects.PostUpdateEquips(player);
        }
        public override void UpdateLifeRegen()
        {
            CSPlayerEffects.UpdateLifeRegen(player);
        }
        public override void GetWeaponKnockback(Item item, ref float knockback)
        {
            CSPlayerEffects.GetWeaponKnockback(player, item, ref knockback);
            knockback *= WeaponKnockback;
        }
        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            return CSPlayerEffects.CanBeHitByNPC(player, npc, ref cooldownSlot);
        }
        public override void PostUpdateBuffs()
        {
            CSPlayerEffects.PostUpdateBuffs(player);
        }
        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return CSPlayerEffects.Shoot(player, item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void PostUpdateMiscEffects()
        {
            CSPlayerEffects.PostUpdateMiscEffects(player);
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            CSPlayerEffects.ModifyHitByAnthing(player, ref damage, ref crit, npc);
        }
        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            CSPlayerEffects.ModifyHitByAnthing(player, ref damage, ref crit, null, proj);
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            CSPlayerEffects.OnHitByAnything(player, npc, null, damage, crit);
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            CSPlayerEffects.OnHitByAnything(player, null, proj, damage, crit);
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (ImmunityTime > 0) return false;
            if (CSWorld.HyperMode)
            {
                damage = (int)(1.5f * damage);
            }
            return CSPlayerEffects.PreHurt(player, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            CSPlayerEffects.PostHurt(player, pvp, quiet, damage, hitDirection, crit);
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            CSPlayerEffects.PostHurt(player, pvp, false, damage, hitDirection, false);
            if (ImmunityTime > 0) return false;
            return CSPlayerEffects.PreKill(player, damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            CSPlayerEffects.ModifyHitNPCWithAnything(player, target, ref damage, ref knockback, ref crit, item);
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            CSPlayerEffects.ModifyHitNPCWithAnything(player, target, ref damage, ref knockback, ref crit, null, proj);
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            CSPlayerEffects.OnHitNPCWithAnything(player, target, damage, knockback, crit, null, item);
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            CSPlayerEffects.OnHitNPCWithAnything(player, target, damage, knockback, crit, proj);
        }
        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            CSPlayerEffects.ModifyWeaponDamage(player, item, ref add, ref mult, ref flat);
        }
        public override void PostUpdate()
        {
            CSPlayerEffects.PostUpdate(player);
        }
        public override void PostUpdateRunSpeeds()
        {
            CSPlayerEffects.PostUpdateRunSpeeds(player);
        }
        #endregion
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (CalamitySouls.BloodKey.JustPressed && BloodCanOption && BloodOptionAmount < 4 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileType<BloodOption>(), 0, 0f, player.whoAmI);
            }
            if (CalamitySouls.FearmongerArea.JustPressed && FearmongerCanArea && FearmongerAreaTimer == 0)
            {
                Main.PlaySound(SoundID.Item46, player.Center);
                FearmongerAreaTimer = 30 * 60;
                if (player.whoAmI == Main.myPlayer)
                {
               Projectile area=     Projectile.NewProjectileDirect(player.Center, Vector2.Zero,
                      ProjectileType<FearmongerAreaProj>(), 0, 0f, player.whoAmI);
                    area.Center = player.Center;
                }
            }
            if (CalamitySouls.FearmongerMark.JustPressed && FearmongerCanMark)
            {
                if (FearmongerMark != -1) FearmongerMark = -1;
                else if (FearmongerMarkCooldown == 0 && player.whoAmI == Main.myPlayer)
                {
                    int index = -1;
                    float dist = -1;
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        NPC npc = Main.npc[i];
                        if (npc.active && !npc.friendly && npc.CanBeChasedBy() && (dist == -1 || npc.Distance(Main.MouseWorld) < dist))
                        {
                            index = i;
                            dist = npc.Distance(Main.MouseWorld);
                        }
                    }
                    if (index != -1)
                    {
                        FearmongerMark = index;
                        FearmongerMarkCooldown = 45 * 60;
                    }
                }
            }
            if (CalamitySouls.GodslayerKey.JustPressed && GodslayerDog && GodslayerDogTimer == 0)
            {
                if (player.whoAmI == Main.myPlayer)
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 15.69f, ProjectileType<GodslayerDoGHead>(),
                        10000, 6.9f, player.whoAmI);
                GodslayerDogTimer = 70 * 60;
            }
            if (CanBrimFrenzy && BrimFrenzy == 0 && BrimFrenzyCooldown == 0 && CalamitySouls.BrimflameKey.JustPressed)
            {
                BrimFrenzyVisualEffect = 30;
                BrimFrenzy = 10 * 60;
                Main.PlaySound(CSUtils.Cal.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/BrimflameAbility"), player.Center);
            }
            if (!CanStatigelTeleport) StatigelTeleport = false;
            else if (CalamitySouls.StatigelKey.JustPressed) StatigelTeleport = !StatigelTeleport;
            if (!TitanPower) TitanPowerBuff = false;
            else if (CalamitySouls.TitanKey.JustPressed) TitanPowerBuff = !TitanPowerBuff;
        }
        public float WeaponFireRateBoost;
        public int ImmunityTime;
        public bool Frozen;
        public float WeaponKnockback;
        public float AllDamageByMult;
        public float AdrenalineDamageBoost;

        public bool cCVaccines;
        public bool pPrism;

        public bool CreatureSpore;
        #region EnchEffect
        public bool AeroFragile;
        public int AstralTimer = 0;
        public bool AuricRevive;
        public int AuricReviveCooldown1 = 0;
        public int AuricReviveCooldown2 = 0;
        public bool AuricHexNerf;
        public bool AuricWeaponBoost;
        public bool BloodCanOption;
        public int BloodOptionAmount = 0;
        public bool CanBrimFrenzy;
        public int BrimFrenzy = 0;
        public int BrimFrenzyCooldown = 0;
        public int BrimFrenzyVisualEffect = 0;
        public bool DaedalusEvade;
        public int DaedalusEvadeCooldown = 0;
        public bool DaedalusCrystal;
        public bool DesertProwler;
        public bool DesertOverKillSandShark;
        public bool DesertDodge;
        public int DesertDodgeTimer = 0;
        public bool DesertDodgeBuff;
        public bool DesertDodgeCD;
        public bool EmpyreanProj;
        public bool EmpyreanSpectre;
        public bool FathomFishes;
        public bool FearmongerNerfCancel;
        public bool FearmongerCanArea;
        public int FearmongerAreaTimer = 0;
        public bool FearmongerCanMark;
        public int FearmongerMark = -1;
        public int FearmongerMarkCooldown = 0;
        public bool GodslayerPhantom;
        public bool GodslayerDog;
        public int GodslayerDogTimer = 0;
        public bool GodslayerAncientCanOtherworld;
        public int GodslayerAncientOtherworldTimer = 0;
        public bool GodslayerAncientOtherworld;
        public bool CanHydrothermicRevive;
        public int HydrothermicReviveCooldown = 0;
        public bool PlagueBringerPlague;
        public bool PlagueReaperPlague;
        public bool PlagueReaperFlight;
        public bool PlagueReaperAdrenaline;
        public bool PlagueReaperHasAdrenalineCurrently;
        public bool PrismaticTrail;
        public bool ReaverEffect;
        public bool ReaverPlantera;
        public bool SilvaBetterRevive;
        public int SilvaRechargeCounter = 0;
        public bool SnowFreeze;
        public bool StatigelTeleport;
        public bool CanStatigelTeleport;
        public bool SulphurousCircle;
        public bool TarragonLeaves;
        public bool TarragonLeavesCoolDown;
        public bool TitanPower;
        public bool TitanPowerBuff;
        public bool UmbraphileExplosion;
        public bool CanUmbraphileShealth;
        public int UmbraphileShealth = 0;
        public int WulfrumShieldCooldown = 0;
        #endregion
        #region Force
        public bool ForceAnnihilation;
        public bool ForceCreature;
        public bool ForceRevolution;
        public bool ForceTechnical;
        public bool ForceTyranny;
        #endregion
        #region Ench
        public bool EnchAero;
        public bool EnchAstral;
        public bool EnchAuric;
        public bool EnchBlood;
        public bool EnchBrim;
        public bool EnchDaedalus;
        public bool EnchDemonshade;
        public bool EnchDesert;
        public bool EnchEmpyrean;
        public bool EnchFathom;
        public bool EnchFearmonger;
        public bool EnchGodslayer;
        public bool EnchGodslayerAncient;
        public bool EnchHydrothermic;
        public bool EnchMollusk;
        public bool EnchOmega;
        public bool EnchPlagueBringer;
        public bool EnchPlagueReaper;
        public bool EnchPrismatic;
        public bool EnchReaver;
        public bool EnchSilva;
        public bool EnchSnowRuffian;
        public bool EnchStatigel;
        public bool EnchSulphurous;
        public bool EnchTarragon;
        public bool EnchTitan;
        public bool EnchUmbraphile;
        public bool EnchVictide;
        public bool EnchWulfrum;
        #endregion 
    }
}
