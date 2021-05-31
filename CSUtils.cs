using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using System.Collections.Generic;
using System.Text;

namespace CalamitySouls
{
    public static class CSUtils
    {
        public static void Strike(this NPC npc, int damage, Player player = null)
        {
            if (player == null && Main.netMode != NetmodeID.MultiplayerClient) player = Main.LocalPlayer;
            if (player.whoAmI == Main.myPlayer) {
                Projectile strike = Projectile.NewProjectileDirect(npc.Center, Vector2.Zero,
                   ModContent.ProjectileType<CalamityMod.Projectiles.Typeless.DirectStrike>(), damage, 0f, player.whoAmI);
                strike.GetPlayerDamageType(player);
            } }
        public static Mod Cal = ModLoader.GetMod("CalamityMod");
        public static bool HoldingANotSummonWeapon(this Player player)
        {
            if (player.Calamity().fearmongerSet || player.setForbidden || player.Calamity().forbiddenCirclet) return false;
            Item item = player.inventory[player.selectedItem];
            if (item.IsAir) return false;
            if (item.pick > 0 || item.axe > 0 || item.hammer > 0) return false;
            if (item.melee || item.ranged || item.magic || item.thrown || item.Calamity().rogue) return true;
            return false;
        }
        public static void HealLife(this Player player, int amount, bool visible = true)
        {
            player.statLife += amount;
            if (player.statLife > player.statLifeMax2) player.statLife = player.statLifeMax2;
            if (visible) player.HealEffect(amount, true);
        }
        public static void HealMana(this Player player, int amount, bool visible = true)
        {
            player.statMana += amount;
            if (player.statMana > player.statManaMax2) player.statMana = player.statManaMax2;
            if (visible) player.ManaEffect(amount);
        }
        public static void Melee(this Projectile projectile)
        {
            projectile.melee = true;
            projectile.ranged = projectile.magic = projectile.minion = projectile.thrown = projectile.Calamity().rogue = false;
        }
        public static void Ranged(this Projectile projectile)
        {
            projectile.ranged = true;
            projectile.melee = projectile.magic = projectile.minion = projectile.thrown = projectile.Calamity().rogue = false;
        }
        public static void Magic(this Projectile projectile)
        {
            projectile.magic = true;
            projectile.ranged = projectile.melee = projectile.minion = projectile.thrown = projectile.Calamity().rogue = false;
        }
        public static void Minion(this Projectile projectile)
        {
            projectile.minion = true;
            projectile.ranged = projectile.magic = projectile.melee = projectile.thrown = projectile.Calamity().rogue = false;
        }
        public static void Rogue(this Projectile projectile)
        {
            projectile.thrown =projectile.Calamity().rogue= true;
            projectile.ranged = projectile.magic = projectile.minion = projectile.melee = false;
        }
        public static void Classless(this Projectile projectile)
        {
            projectile.melee = projectile.ranged = projectile.magic = projectile.minion = projectile.thrown = projectile.Calamity().rogue = false;
        }
        public static void AllClass(this Projectile projectile)
        {
            projectile.melee = projectile.ranged = projectile.magic = projectile.minion = projectile.thrown = projectile.Calamity().rogue = true;
        }
        public static bool CanHitNPC(this Projectile projectile, NPC npc) => Collision.CanHit(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
        public static void FollowPlayer(this Projectile projectile, Vector2 place, float maxDist, float minDist, Vector2 velo, float speed = 0, bool positionLerp = false, float lerpAmtFar = 0.05f, float lerpAmtClose = 0.07f, float lerpAmtPos = 0.1f)
        {
            if (projectile.Distance(place) > maxDist) projectile.Center = place - projectile.DirectionTo(place) * maxDist;
            else if (projectile.Distance(place) < minDist) projectile.velocity = Vector2.Lerp(projectile.velocity, velo, lerpAmtClose);
            else projectile.velocity = Vector2.Lerp(projectile.velocity, projectile.DirectionTo(place) * speed, lerpAmtFar);
            if (positionLerp) projectile.Center = Vector2.Lerp(projectile.Center, place, lerpAmtPos);
        }
        public static void ModifyAllCrit(this Player player, int add = 0, bool set = false, int settle = 0)
        {
            player.magicCrit += add;
            player.meleeCrit += add;
            player.rangedCrit += add;
            player.thrownCrit += add;
            CalamityUtils.Calamity(player).throwingCrit += add;
            if (set)
            {
                player.magicCrit = settle;
                player.meleeCrit = settle;
                player.rangedCrit = settle;
                player.thrownCrit = settle;
                CalamityUtils.Calamity(player).throwingCrit = settle;
            }
        }
        public static bool AnyBossAlive
        {
            get
            {
                for(int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && npc.boss) return true;
                    if (npc.active && npc.type == NPCID.EaterofWorldsHead) return true;
                }
                return false;
            }
        }
        public static bool GameCultureChinese => GameCulture.Chinese.IsActive;
        public static string GetModItemText(int ItemID, string color = "", string itemname = "")
        {
            Item item = new Item(); item.SetDefaults(ItemID);
            string name = item.Name;
            if (itemname != "") name = itemname;
            if(color=="") return "[i:" + ItemID + "]「" + name + "」";
            return "[i:" + ItemID + "]「[c/" + color + ":" + name + "]」";
        }
        public static bool GoodNetMode => Main.netMode != NetmodeID.MultiplayerClient;
        public static CSPlayer CS(this Player player)=>player.GetModPlayer<CSPlayer>();
        public static CSNPC CS(this NPC npc)=>npc.GetGlobalNPC<CSNPC>();
        public static void GetItemDamageType(this Projectile projectile,Item item)
        {
            projectile.melee = item.melee;
            projectile.ranged = item.ranged;
            projectile.magic = item.magic;
            projectile.minion = item.summon;
            projectile.sentry = item.sentry;
            projectile.thrown = item.thrown;
            CalamityUtils.Calamity(projectile).rogue = CalamityUtils.Calamity(item).rogue;
        }    
        public static void GetPlayerDamageType(this Projectile projectile,Player player)
        {
            Item item = player.inventory[player.selectedItem];
            if (item.IsAir)
            {
                projectile.melee = projectile.ranged = projectile.magic = projectile.minion = projectile.sentry = projectile.thrown = projectile.Calamity().rogue = false;
                return;
            }
            projectile.melee = item.melee;
            projectile.ranged = item.ranged;
            projectile.magic = item.magic;
            projectile.minion = item.summon;
            projectile.sentry = item.sentry;
            projectile.thrown = item.thrown;
            CalamityUtils.Calamity(projectile).rogue = CalamityUtils.Calamity(item).rogue;
        }
        public static void GetItemDamageType(int ProjWhoAmI,Item item)
        {
            Projectile projectile = Main.projectile[ProjWhoAmI];
            projectile.melee = item.melee;
            projectile.ranged = item.ranged;
            projectile.magic = item.magic;
            projectile.minion = item.summon;
            projectile.sentry = item.sentry;
            projectile.thrown = item.thrown;
            CalamityMod.CalamityUtils.Calamity(projectile).rogue = CalamityMod.CalamityUtils.Calamity(item).rogue;
        }
        public static void CopyProjDamageType(this Projectile projectile,Projectile Source)
        {
            projectile.melee = Source.melee;
            projectile.ranged = Source.ranged;
            projectile.magic = Source.magic;
            projectile.minion = Source.minion;
            projectile.sentry = Source.sentry;
            projectile.thrown = Source.thrown;
            CalamityUtils.Calamity(projectile).rogue = CalamityUtils.Calamity(Source).rogue;
            projectile.friendly = Source.friendly;
            projectile.hostile = Source.hostile;
        }
        public static string TooltipHotkeyString(this ModHotKey mhk)
        {
            if (Main.dedServ || mhk == null)
            {
                return "";
            }
            List<string> keys = mhk.GetAssignedKeys(0);
            if (keys.Count == 0)
            {
                return GameCultureChinese ? "[未设置，请在控件中设置该快捷键" : "[None yet, please set the key up in Control]";
            }
            StringBuilder sb = new StringBuilder(16);
            sb.Append(keys[0]);
            for (int i = 1; i < keys.Count; i++)
            {
                sb.Append(" / ").Append(keys[i]);
            }
            return sb.ToString();
        }
        public static bool IsAExtraProjectile(this Projectile projectile) => CSLists.ExtraProjectileList.Contains(projectile.type);
        public static void DoAVisualBuff(this Player player, int type, int time = 0)
        {
            player.ClearBuff(type);
            player.AddBuff(type, time + 2);
        }
        public static Vector2 RandomRotate() => MathHelper.ToRadians(Main.rand.Next(360)).ToRotationVector2();
        public static int ownedProjectileCounts(this Player player,int type)
        {
            int amt = 0;
            for(int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.type == type && projectile.owner == player.whoAmI) amt++;
            }
            return amt;
        }
        public static string BlankTexture => "CalamitySouls/Extras/BlankTexture";
    }
}
