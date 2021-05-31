using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamitySouls;
using System.Collections.Generic;

namespace CalamitySouls.Ench
{
    public class EnchWulfrum : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Wulfrum";
            ChineseName = "钨钢";
            Tooltip = ChineseTooltip = "Line0\nLine1\nLine2\nLine3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "9BAB75";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「钨钢就是最好的。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.WulfrumArmor>(), color) +
                    "半血以下额外加5防御");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "召唤一个阻挡一次不穿墙弹幕的盾");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "这个盾提供6防御，存在10秒，破碎后冷却20秒");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Wulfrum Makes Great.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.WulfrumArmor>(), color) +
                "+5 extra defense when below 50% life");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Spawn a shield that blocks projectiles that cannot pass through walls once");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The shield provides 6 defense, exists for 10s with a 20s Cooldown after broken");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchWulfrum = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Wulfrum");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.WulfrumArmor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.WulfrumLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.WulfrumBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.WulfrumBow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.WulfrumStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.WulfrumController>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.WulfrumKnife>(), 600);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.EnergyCore>(), 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
