using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Ench;

namespace CalamitySouls.Force
{
    public class ForceCreature : BasicForce
    {
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Creature";
            ChineseName = "生灵";
            ttAmt = 8;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「一切生灵的主人。」");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchVictide>(), "CC4235") +
                    "消除水的阻力，无限时长阿米迪亚斯的祝福，增加7%攻速和7回血");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSulphurous>(), "A89254") +
                    "屁二段跳，冲刺，+24%跳跃速度，减少硫磺海水的伤害");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchMollusk>(), "7FFFFD") +
                    "贝壳对你友好，增加10%暴击");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchTitan>(), "7B6382") +
                    "增加300%击退和11%伤害");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchReaver>(), "91CB66") +
                    "击中敌人产生大量孢子云，攻击造成脓血、咒火和剧毒");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchFathom>(), "63A0A4") +
                    "+10%召唤伤害，+1召唤栏，召唤一个围着你转圈摧毁敌对弹幕的小鱼");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchOmega>(), "4887CD") +
                    "触手会汲取敌人生命治疗你，你常驻深渊狂乱状态");
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「Owner of  all creatures.」");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchVictide>(), "CC4235") +
                "Provides increased underwater mobility, you grant infinite Amidias' Blessing, +7% attack speed and +7 life regen");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchSulphurous>(), "A89254") +
                "Grant a fart jump, a dash and +24% jump speed, reduces the DoT of the sulphuric waters");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchMollusk>(), "7FFFFD") +
                "Clams become friendly, you grant 10% increased crit");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchTitan>(), "7B6382") +
                "+300% knockback, +11% damage");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchReaver>(), "91CB66") +
                "Enermy hit spawn plenty of spore clouds, attacks inflict ichor, cursed inferno and venom");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchFathom>(), "63A0A4") +
                "+10% minion damage, +1 max minion, Spawn a fathom fish which circles around you destroying hostile projectiles");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchOmega>(), "4887CD") +
                "Tentacles heal you by sucking enemy life and you always have abyssal madness activated");
        }
        public override void SetForceDefaults()
        {
            item.defense += 17;
            item.lifeRegen += 7;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceCreature = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchVictide>());
            recipe.AddIngredient(ModContent.ItemType<EnchSulphurous>());
            recipe.AddIngredient(ModContent.ItemType<EnchMollusk>());
            recipe.AddIngredient(ModContent.ItemType<EnchTitan>());
            recipe.AddIngredient(ModContent.ItemType<EnchReaver>());
            recipe.AddIngredient(ModContent.ItemType<EnchFathom>());
            recipe.AddIngredient(ModContent.ItemType<EnchOmega>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}