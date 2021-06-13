using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchAstral : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Astral";
            ChineseName = "幻星";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "63A0A4";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「愿群星指引你的前路。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AstralBreastplate>(), color) +
                    "获得勘探、狩猎和危险感药水的效果，大幅度增加各种属性");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "半血的时候获得四秒无敌，之后聚集能量，回复满血，攻速召唤栏炮台栏和生命上限都加倍");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "该效果持续10秒，结束时再获得四秒无敌，并以60分钟冷却收尾");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「May the stars guide your way.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AstralBreastplate>(), color) +
                "Spenkular, Hunter and Dangersense effect, major increase on many stats");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Grant 4s inmmunity under half life, then return to full health and grant doubled fire rate, minion slots and max hp");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The effect lasts for 10s and grant another 4s immunity in the end, all these have a 60min cooldown");
        }
        public override void SetEnchDefaults()
        {
            item.defense += 10;
            item.lifeRegen += 10;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchAstral = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AstralHelm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AstralBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AstralLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.AstralBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.AstralPike>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.AstralRepeater>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.AstralBlaster>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.AstralStaff>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
