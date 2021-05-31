using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Ench;

namespace CalamitySouls.Force
{
    public class ForceTechnical : BasicForce
    {
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Technical";
            ChineseName = "科技";
            ttAmt = 6;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「科技革命」");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchWulfrum>(), "9BAB75") +
                    "召唤一个阻挡不穿墙弹幕的盾");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPlagueReaper>(), "3A514B") +
                    "你获得无限飞行时间，且满肾上腺素后受击不会清空肾上腺素");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPlaguebringer>(), "E54242") +
                    "获得一个瘟疫冲刺，敌人多受到10%伤害");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAstral>(), "63A0A4") +
                    "获得全知药水的效果，小幅度增加各种属性");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPrismatic>(), "FF6AF6") +
                    "召唤一个在你周围环绕，改变敌对弹幕方向的棱镜，敌人的攻击将会拥有预警线");
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「Science Revolution.」");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchWulfrum>(), "9BAB75") +
                "Spawn a shield that blocks projectiles that cannot pass through walls");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPlagueReaper>(), "3A514B") +
                "You gain infinite flight time, and your adrenaline won't be cleared anymore once get fully charged");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPlaguebringer>(), "E54242") +
                "Grants a plague dash and enermies take 10% more damage");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAstral>(), "63A0A4") +
                "Omnisense effect, minor increase on many stats");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchPrismatic>(), "FF6AF6") +
                "Spawn a prism that circle around you and change hostile projectile's direction, enermies' attack will have their trail shown");
        }
        public override void SetForceDefaults()
        {
            item.defense += 5;
            item.lifeRegen += 5;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceTechnical = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchWulfrum>());
            recipe.AddIngredient(ModContent.ItemType<EnchPlagueReaper>());
            recipe.AddIngredient(ModContent.ItemType<EnchPlaguebringer>());
            recipe.AddIngredient(ModContent.ItemType<EnchAstral>());
            recipe.AddIngredient(ModContent.ItemType<EnchPrismatic>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}