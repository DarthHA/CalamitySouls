using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalamitySouls.Ench
{
    public class EnchAerospec : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Aerospec";
            ChineseName = "天蓝";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "99C8C1";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「你感觉瓦尔基里之力蕴含其中。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AerospecBreastplate>(), color) +
                    "让你下落更快，免疫坠落伤害，召唤一个天蓝武神协助你");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "获得10%伤害、10穿甲、1召唤栏和10%盗贼弹速");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "代价是受到的伤害增加，以50为界（原倍），受到伤害越高增幅越多");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「You feel the power of Valkyrie inside.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.AerospecBreastplate>(), color) +
                "Allows you to fall more quickly and disables fall damage, summons a valkyrie to protect you");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Grant 10% damage, 10 armor penetration, 1 minion slot and 10% rogue velocity");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "But you'll take increased damage, 50 by default, the more it is, the more is increased");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchAero = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Aerospec");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AerospecBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.AerospecLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.WindBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.GoldplumeSpear>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.AirSpinner>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Galeforce>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.StormSurge>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.Tradewinds>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Turbulance>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.SkyStabber>(), 4);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.FeatherKnife>(), 300);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}