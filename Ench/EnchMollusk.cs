using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchMollusk : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Mollusk";
            ChineseName = "软壳";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "7FFFFD";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「Clamity」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.MolluskShellplate>(), color) +
                    "两个贝壳（召唤物）助你战斗，且贝壳（敌怪）对你友好");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "当拥有任意套装效果（不包括软壳套）时，增加20%暴击");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Clamity」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.MolluskShellplate>(), color) +
                "Two shellfishes(minion) aid you in combat, clams(enermy) become friendly");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "When you have any kind of set bonus(the mollusk itself is not included), you'd grant 20% increased crit");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 10;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchMollusk = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.MolluskShellmet>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.MolluskShellplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.MolluskShelleggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.ClamCrusher>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.ClamorRifle>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.Poseidon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.ShellfishStaff>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}