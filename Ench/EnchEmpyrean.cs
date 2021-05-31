using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchEmpyrean : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Empyrean";
            ChineseName = "皇天";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "9CFFEE";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「一个值得做王的盗贼。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.XerocPlateMail>(), color) +
                    "击中敌人会释放各种各样的额外弹幕，常驻宇宙之怒和宇宙狂怒增益");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "一个皇天幻影保护你，并根据手持物品切换攻击方式");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「A rogue worth a king.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.XerocPlateMail>(), color) +
                "Hitting a creature release tons of projectiles, you are imbued with cosmic wrath and rage");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "A empyrean phantasm assist you and switch attack pattern according to your holding item");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.CS().EnchEmpyrean = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.XerocMask>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.XerocPlateMail>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.XerocCuisses>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.XerocsGreatsword>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.TheEmpyrean>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.TomeofFates>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.LanternoftheSoul>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.XerocPitchfork>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
