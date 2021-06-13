using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamitySouls;
using System.Collections.Generic;

namespace CalamitySouls.Ench
{
    public class EnchDesertprowler : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Desert Prowler";
            ChineseName = "沙漠游侠";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "C29151";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「面对沙暴吧。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DesertProwlerShirt>(), color) +
                    "攻击获得额外5伤害（不受加成），有很小几率召唤沙龙卷");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "免疫击退和强劲的风，你对沙尘精、沙鲨和大沙鲨造成双倍伤害");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "站立而且不使用物品超过5s后，你获得一次会将你吹上天的沙暴闪避，此效果有60s冷却");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Now face the sandstorm」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DesertProwlerShirt>(), color) +
                "Attacks deal an extra 5 flat damage and can rarely whip up a sandstorm");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Immune to knockback and Mighty Wind, your attack deals doubled damage to Sand Elemental, sandsharks and the Great Sand Shark");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "After standing still and not using item for 5 seconds you gain a sandstorm dodge which lifts you up, which have a 60s Cooldown");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchDesert = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DesertProwlerHat>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DesertProwlerShirt>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DesertProwlerPants>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.MandibleClaws>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.BurntSienna>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.MandibleBow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.StormjawStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.NastyCholla>(), 150);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
