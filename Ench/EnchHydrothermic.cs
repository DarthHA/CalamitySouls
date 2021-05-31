using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
   public class EnchHydrothermic : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Hydrothermic";
            ChineseName = "渊泉";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "E06C1D";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「核污水的那边，是敌人。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaArmor>(), color) +
                    "低于半血时获得狱火药水效果，受伤有20%几率造成爆炸");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "死亡时以10血复活，该能力冷却为120秒");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Enermy is behind the nuclear-polluted water.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaArmor>(), color) +
                "Inferno effect when below 50% life,and you have a 20% chance to emit a blazing explosion when you are hit");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "You revive at 10 hp when dead which have a 120s cooldown");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 16;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchHydrothermic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Hydrothermic");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaArmor >());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaSubligar>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.HellfireFlamberge>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.ExsanguinationLance>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Chaotrix>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.GreatbowofTurmoil>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Helstorm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.ForbiddenSun>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.FlameScythe>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}