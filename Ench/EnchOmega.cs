using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchOmega : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Omega Blue";
            ChineseName = "欧米伽蓝";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "4887CD";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「他们应当为自己的所作所为付出代价。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.OmegaBlueChestplate>(), color) +
                    "增加10%伤害暴击，触手会汲取敌人生命治疗你");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "你常驻深渊狂乱状态，代价是失去正面生命回复");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「They'd pay for what they've done.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.OmegaBlueChestplate>(), color) +
                "10% increased damage and critical strike chance, tentacles heal you by sucking enemy life");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "You always have abyssal madness activated at the price of no positive life regen");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchOmega = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.OmegaBlueHelmet>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.OmegaBlueChestplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.OmegaBlueLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.SoulEdge>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.CrescentMoon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.ClamorNoctus>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.StratusSphere>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.CalamarisLament>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Valediction>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.JawsOfOblivion>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
