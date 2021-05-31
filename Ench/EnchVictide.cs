using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchVictide : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Victide";
            ChineseName = "胜潮";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "CC4235";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「胜者书写历史。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.VictideBreastplate>(), color) +
                    "召唤一个海胆保护你，消除水的阻力，在深渊提供短暂呼吸时间");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.ShieldoftheOcean>(), color) +
                    "在水中增加77%移速和7回血");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "每分钟获得77秒阿米迪亚斯的祝福，有祝福时增加7%攻速");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Only victory leads the age」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.VictideBreastplate>(), color) +
                "Summons a sea urchin to protect you, provides increased underwater mobility and slightly reduces breath loss in the abyss");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.ShieldoftheOcean>(), color) +
                "+7 life regen and +77% damage while submerged in liquid");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Grants 77s Amidias' Blessing every minute, with the Blessing you grant +7% attack speed");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 7;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchVictide = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Victide");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.VictideBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.VictideLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.ShieldoftheOcean>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.RedtideSword>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Cnidarian>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.UrchinSpear>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Seabow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.CoralSpout>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.SeashellBoomerang>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}