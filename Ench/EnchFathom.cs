using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchFathom : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Fathom Swarmer";
            ChineseName = "幻渊鱼群";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "63A0A4";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「合则存，分必亡。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBreastplate>(), color) +
                    "+10%召唤伤害，+1召唤栏，在深渊提供大量光照和呼吸");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "召唤3个作用不同的小鱼助你战斗");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "一个围着你转圈摧毁敌对弹幕，一个追踪你的召唤物并加速，一个攻击敌人");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「United we stand, divided we fall.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBreastplate>(), color) +
                "+10% minion damage, +1 max minion and provides a good amount of light and greatly reduces breath loss in the abyss");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Spawn 3 fathom fishes to assist you, doing different jobs");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "1 circle around you destroying hostile projectiles, 1 chase your minions and speed up it, 1 attack enermies");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchFathom = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerVisage>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FathomSwarmerBoots>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.AbyssBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.TyphonsGreed>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.FlakKraken>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Triploon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.UndinesRetribution>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.DreadmineStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.BallisticPoisonBomb>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Apoctolith>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
