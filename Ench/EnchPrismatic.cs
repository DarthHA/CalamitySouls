using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Items;

namespace CalamitySouls.Ench
{
    public class EnchPrismatic : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Prismatic";
            ChineseName = "光棱";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "FF6AF6";
            string hotkey = CalamityMod.CalamityMod.TarraHotKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「棱镜模块运转正常，光能聚焦中。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PrismaticRegalia>(), color) +
                    "按"+hotkey+"释放一列集中在鼠标的死亡激光，持续5秒冷却30秒");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<PrismaticPrism>(), color) +
                    "召唤一个在你周围环绕，改变敌对弹幕方向的棱镜");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "敌人的攻击将会拥有预警线");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Prism sensors stable, focusing light energy.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PrismaticRegalia>(), color) +
                "Press " + hotkey + " to unleash a barrage of death lasers at the cursor for the next 5 seconds which has a 30 second cooldown");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<PrismaticPrism>(), color) +
                "Spawn a prism that circle around you and change hostile projectile's direction");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Enermies' attack will have their trail shown");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchPrismatic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PrismaticHelmet>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PrismaticRegalia>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PrismaticGreaves>());
            recipe.AddIngredient(ModContent.ItemType<PrismaticPrism>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}