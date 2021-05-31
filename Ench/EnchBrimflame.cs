using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchBrimflame : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Brimflame";
            ChineseName = "硫火";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "E34F4F";
            string hotkey = CSUtils.TooltipHotkeyString(CalamitySouls.BrimflameKey);
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「被遗忘的女神蔑视着这些只知道寻求力量的可怜虫子。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.BrimflameRobes>(), color) +
                    "免疫大多数火系列减益，按" + hotkey + "开启硫火暴乱效果，期间你多造成25%伤害");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.BrimflameRobes>(), color) +
                    "硫火暴乱持续10秒，冷却时间25秒，且只有带着此饰品才会进行冷却");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "释放硫火暴乱的同时释放扫射的硫火激光，随机消除一段距离内的弹幕");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「The Forgotten Goddess looks with contempt at those poor insects seeking for power.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBreastplate>(), color) +
                "Immnue to most fire-relative debuffs, Press " + hotkey + " to trigger a brimflame frenzy effect, during which you deal 25% more damage");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBreastplate>(), color) +
                "The frenzy lasts for 10s with a 25s cooldown, and only with this accessory the cooldown works");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Releasing a frenzy causes you to burst into brimstone rays which randomly clear projectiles within a certain range");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchBrim = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.BrimflameScowl>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.BrimflameRobes>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.BrimflameBoots>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.ProfanedSword>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.BrimstoneFury>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.BrimroseStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.BurningSea>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.IgneousExaltation>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}