using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Ench;

namespace CalamitySouls.Force
{
    public class ForceTyranny : BasicForce
    {
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Tyranny";
            ChineseName = "暴政";
            ttAmt = 5;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            string hotkey = CalamityMod.CalamityMod.TarraHotKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「你即君主。」");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchGodslayerAncient>(), "5F21A0") +
                    "增加21%伤害，加倍加速度，非boss战中加倍移速");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchGodslayer>(), "FC6DCA") +
                    "你获得冷却只有30秒的弑神者复活效果，你每隔一段时间获得不同的增益");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAuric>(), "7BCDED") +
                    "金源复活效果，免疫孱弱巫咒，升级金源魔石那五把武器");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDemonshade>(), "FF1910") +
                    "暗影速度，按" + hotkey + "使用黑魔咒激怒所有生物10秒");
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「You are the monarch.」");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchGodslayerAncient>(), "5F21A0") +
                "+21% damage, your acceleration is doubled, while no boss is alive your speed is also doubled");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchGodslayer>(), "FC6DCA") +
                "You are granted godslayer revive effect with only 30s cooldown, you gain different bonus over time");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAuric>(), "7BCDED") +
                "Auric revive effect, immunity to Vulnerable Hex, upgrade the 5 weapons Auric enchant upgraded");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDemonshade>(), "FF1910") +
                "Shadow speed, press " + hotkey + " to enrage nearby enemies with a dark magic spell for 10 seconds");
        }
        public override void SetForceDefaults()
        {
            item.defense += 27;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceTyranny = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchGodslayerAncient>());
            recipe.AddIngredient(ModContent.ItemType<EnchGodslayer>());
            recipe.AddIngredient(ModContent.ItemType<EnchAuric>());
            recipe.AddIngredient(ModContent.ItemType<EnchDemonshade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Rock>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}