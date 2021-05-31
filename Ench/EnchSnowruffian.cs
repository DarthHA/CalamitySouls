using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
   public class EnchSnowruffian:BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Snow Ruffian";
            ChineseName = "雪境暴徒";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "63DDE0";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「他们从我们手中夺取了一切，现在是时候夺回来了。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SnowRuffianChestplate>(), color) +
                    "免疫摔伤，增加15%盗贼伤害，但增加的量不大于12");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "免疫冰肺，提供寒冷抗性，受击时冰冻周围敌人和你自己");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "被冰冻的玩家获得12防御，被冰冻的敌人在非boss战期间无法移动");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「They took everything from us, now let's get these back.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SnowRuffianChestplate>(), color) +
                "Negate fall damage, +15% rogue damage, the amount added is limited at 12");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Immunity to Frozen Lung, provide cold resistance, being attacked freezes nearby enermies and yourself for a short time.");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The player frozen grant 12 defense, and enermies frozen cannot move when currently no boss is alive");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchSnowRuffian = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SnowRuffianMask>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SnowRuffianChestplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SnowRuffianGreaves>());
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.FrostBolt>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.FrostBlossomStaff>());
            recipe.AddIngredient(ItemID.IceBoomerang);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
