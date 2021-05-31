using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalamitySouls.Ench
{
    public class EnchBloodflare : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Bloodflare";
            ChineseName = "血炎";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "CC2A3C";
            string key = CalamitySouls.BloodKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「神弃的烈炎在黑暗中滋生。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.BloodflareBodyArmor>(), color) +
                    "半血的敌人被攻击时几率掉落红心，血月时掉落更多血珠");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "按" + key + "键将你的10%生命上限分离出来变成子机，同时最多存在4个子机");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "子机会为你吸血和消弹，消弹有5秒的冷却");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Forsaken Flare infestating in the darkness.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.BloodflareBodyArmor>(), color) +
                "Enemies below 50% life may drop hearts when struck and drop more Blood Orbs during a Blood Moon");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Press " + key + " to separate your 10% max hp to a Option, max 4 can exist at the same time");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Options do lifesteal and can block projectiles for you which have a 5s Cooldown");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 20;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchBlood = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Bloodflare");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.BloodflareBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.BloodflareCuisses>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.TheMutilator>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Lacerator>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.ArterialAssault>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.ClaretCannon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.BloodBoiler>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.Viscera>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.SanguineFlare>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.DragonbloodDisgorger>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.BloodsoakedCrasher>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
