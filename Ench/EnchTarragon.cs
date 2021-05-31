using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchTarragon : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Tarragon";
            ChineseName = "龙蒿";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "D3B258";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「丛林之心与你同在。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.TarragonBreastplate>(), color) +
                    "获得拾心和镇静效果，击杀敌人有几率掉落额外的红心");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "击中敌人生成不同的增益叶片，玩家吃到时会获得各种各样的加成");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "你所到之处皆是丛林");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Heart of the jungle be with you.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.TarragonBreastplate>(), color) +
                "Heartreach and calm potion effect, enemies have a chance to drop extra hearts on death");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Hitting enermies spawn different bonus leaves, player who pick them are granted all kinds of buffs");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Wherever you are in is jungle");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchTarragon = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Tarragon");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.TarragonBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.TarragonLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.BadgeofBravery>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.LifefruitScythe>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Verdant>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.NettlelineGreatbow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.GammaFusillade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.TarragonThrowingDart>(), 999);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}