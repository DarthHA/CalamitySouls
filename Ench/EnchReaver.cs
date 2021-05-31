using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchReaver : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Reaver";
            ChineseName = "掠夺者";
            Tooltip = ChineseTooltip = "0\n1\n2\n3\n4";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "91CB66";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「*悠久的蒸汽机关*」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.ReaverScaleMail>(), color) +
                    "击中敌人造成爆炸并产生大量孢子云，攻击时每过一段时间射出追踪火箭");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.ReaverScaleMail>(), color) +
                    "受到伤害获得近战加成并炸开大片孢子，手持召唤武器时召唤一个掠夺者宝珠为你而战");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.NecklaceofVexation>(), color) +
                    "半血以下增加10%伤害，攻击造成脓血、咒火和剧毒");
                QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                    "苍华之庭速度加倍");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「*Long-standing stream engine*」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.ReaverScaleMail>(), color) +
                "Enermy hit create explosion and spawn plenty of spore clouds, your attack release chasing rocket sometimes");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.ReaverScaleMail>(), color) +
                "Grant melee bonus and burst out many spores on hurt, a reaver orb assist you when holding a summon weapon");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.NecklaceofVexation>(), color) +
                "Extra 10% damage under half life, attacks inflict ichor, cursed inferno and venom");
            QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                "Plantation Staff has double speed");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchReaver = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Reaver");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.ReaverScaleMail>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.ReaverCuisses>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.NecklaceofVexation>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.FeralthornClaymore>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.HellionFlowerSpear>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Quagmire>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.BladedgeGreatbow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.EvergladeSpray>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.MangroveChakram>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}