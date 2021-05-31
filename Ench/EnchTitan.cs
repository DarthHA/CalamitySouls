using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchTitan : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Titan Heart";
            ChineseName = "泰坦之心";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "7B6382";
            string hotkey = CSUtils.TooltipHotkeyString(CalamitySouls.TitanKey);
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「抛瓦！...但是泰拉人，代价是什么呢？」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.TitanHeartMantle>(), color) +
                    "增加300%击退和8%伤害");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "按" + hotkey + "激活泰坦之力，增加75%伤害");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "代价？你的攻速和召唤栏减半，还不够吗？");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「POWER!...And what, Terrarian, must we give in return?」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.TitanHeartMantle>(), color) +
                "+300% knockback, +8% damage");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Press " + hotkey + " to activate Titan Power, increase 75% damage");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The price? You'll get halved attack speed and max minions. isn't it enough?");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 12;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchTitan = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.TitanHeartMask>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.TitanHeartMantle>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.TitanHeartBoots>());
            recipe.AddIngredient(ModContent.ItemType<Items.MonolithStick>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Fishing.AstralCatches.PolarisParrotfish>());
            recipe.AddIngredient(ModContent.ItemType<Items.MonolithRay>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Typeless.LunicEye>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Fishing.AstralCatches.GacruxianMollusk>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}