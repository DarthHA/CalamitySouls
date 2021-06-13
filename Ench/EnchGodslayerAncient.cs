using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchGodslayerAncient : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Ancient Godslayer";
            ChineseName = "远古弑神者";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "5F21A0";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「追随神的脚步。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(item.type, color) +
                    "增加21%伤害，+50%加速度");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "不使用物品两秒会获得异界增益，使用物品会打破它");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "异界增益在非boss战期间使你的移增加50%，高速移动时你处于无敌状态且能反弹弹幕");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Follow the God.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(item.type, color) +
                "+21% damage, +50% acceleration");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Not using item for 2s grant you Otherworldly buff, and the use of any item breaks it");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "With the buff you grant 50% more speed while no boss is alive, and when moving quickly you are immnue and can reflect projectiles");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchGodslayerAncient = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.Vanity.AncientGodSlayerHelm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.Vanity.AncientGodSlayerChestplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.Vanity.AncientGodSlayerLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.MirrorBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.StormDragoon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.TheStorm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.Cosmilamp>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.CosmicKunai>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}