using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Ench;

namespace CalamitySouls.Force
{
    public class ForceRevolution : BasicForce
    {
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Revolution";
            ChineseName = "起义";
            ttAmt = 7;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「世界属于人民。」");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDesertprowler>(), "C29151") +
                    "免疫击退和强劲的风，站立而且不使用物品超过5s后，你获得一次会将你吹上天的沙暴闪避");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSnowruffian>(), "63DDE0") +
                    "免疫摔伤，免疫冰肺，提供寒冷抗性，受击时冰冻周围敌人和你自己");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchStatigel>(), "DFCCFF") +
                    "增加30%跳跃速度、5%免伤和5生命回复，无敌时间延长");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDaedalus>(), "DA69E9") +
                    "免疫伊卡洛斯之愚蠢，受伤时闪避并生成一圈追踪水晶，冷却45秒");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchTarragon>(), "D3B258") +
                    "击中敌人生成不同的增益叶片，玩家吃到时会获得各种各样的加成");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSilva>(), "E2BC4A") +
                    "增强的始源林海复活效果，+60生命上限");
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「The world belong to the civilization.」");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDesertprowler>(), "C29151") +
                "Immune to knockback and Mighty Wind, After standing still and not using item for 5 seconds you gain a sandstorm dodge which lifts you up");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSnowruffian>(), "63DDE0") +
                "Negate fall damage, immunity to Frozen Lung, provide cold resistance, being attacked freezes nearby enermies and yourself for a short time.");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchStatigel>(), "DFCCFF") +
                "+5 jump height, +30% jump speed, +5% DR and +5 life regen, you have increased immunity frame");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchDaedalus>(), "DA69E9") +
                "Immunity to Icarus' Folly, evade damage and burst out chasing crystal shard with a 45s cooldown");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchTarragon>(), "D3B258") +
                "Hitting enermies spawn different bonus leaves, player who pick them are granted all kinds of buffs");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSilva>(), "E2BC4A") +
                "Enhanced silva revival effect, +60 max health");
        }
        public override void SetForceDefaults()
        {
            item.defense = 5;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceRevolution = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchDesertprowler>());
            recipe.AddIngredient(ModContent.ItemType<EnchSnowruffian>());
            recipe.AddIngredient(ModContent.ItemType<EnchStatigel>());
            recipe.AddIngredient(ModContent.ItemType<EnchDaedalus>());
            recipe.AddIngredient(ModContent.ItemType<EnchTarragon>());
            recipe.AddIngredient(ModContent.ItemType<EnchSilva>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}