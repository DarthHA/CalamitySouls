using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchAuric : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Auric";
            ChineseName = "金源";
            Tooltip =             ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "7BCDED";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「暴君之力协助你。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaBodyArmor>(), color) +
                    "获得两次分开计算的金源复活，CD均为56s");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "常驻暴君之怒效果，大大减弱孱弱巫咒的效果");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "升级真·暴君巨剑、破灭魔王剑、寂虚之光、斥责法杖和幻魂归墟，使它们强度相当于金源武器");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「The Tyrant's power assist you.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaBodyArmor>(), color) +
                "Grant 2 auric revive that have their 56s cooldown counted separated");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Grant Tyrant's Fury buff, greatly reduce the effect of Vulnerable Hex");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Upgrade True Tyrant's Ultisword, Devil's Devastation, Dark Spark, Keelhaul and Phantasmal Ruin to auric tier");
        }
        public override void SetEnchDefaults()
        {
            item.defense += 35;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchAuric = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Auric");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaCuisses>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Ataraxia>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.GaelsGreatsword>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.YharimsCrystal>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.TheWand>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
