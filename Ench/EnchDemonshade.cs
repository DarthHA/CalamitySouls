using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchDemonshade : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Demonshade";
            ChineseName = "魔影";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "FF1910";
            string hotkey = CalamityMod.CalamityMod.TarraHotKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「在你统治者的沮丧要求下，你将踏平敌人的一切。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeBreastplate>(), color) +
                    "暗影回血，暗影速度，暗影减益和受击时从天而降的一些暗影弹幕");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeBreastplate>(), color) +
                    "按" + hotkey + "使用黑魔咒激怒所有生物10秒");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "一个可爱的终灾宠物跟着你");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Now you are sent to demolish the foe upon your ruler's despondont demand.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeBreastplate>(), color) +
                "Shadow regen, shadow speed, shadow debuff, and some shadow projectiles will fire down when you are hit");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeBreastplate>(), color) +
                "Press " + hotkey + " to enrage nearby enemies with a dark magic spell for 10 seconds");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "A lovely calamitas pet follow you");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchDemonshade = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeHelm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DemonshadeGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.Vehemenc>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.LoreItems.KnowledgeCalamitas>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Pets.BrimstoneJewel>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Pets.Levi>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Mounts.Fabsol>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Critters.PiggyItem>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}