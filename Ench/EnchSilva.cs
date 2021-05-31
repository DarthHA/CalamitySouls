using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Items;

namespace CalamitySouls.Ench
{
    public class EnchSilva : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Silva";
            ChineseName = "始源林海";
            Tooltip = ChineseTooltip = "0\n1\n2\n3\n4";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "E2BC4A";
            string key = CalamitySouls.GodslayerKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「神话树妖闭上了她的双眼。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SilvaArmor>(), color) +
                    "所有攻击生成治疗叶珠，+5%最大移速和加速度，始源林海复活效果");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.Wings.SilvaWings>(), color) +
                    "始源林海复活直接治疗至半血，增加80最大生命");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "始源林海复活拥有180秒的再次充能");
                QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                    "始源林海无敌的时间增加到20秒，且最开始获得5秒真正的无敌");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「The mythical Dryad closed her eyes.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SilvaArmor>(), color) +
                "All attack spawn healing leaf orbs on enemy hits, +5% max run speed and acceleration, silva revival effect");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.Wings.SilvaWings>(), color) +
                "The Silva revive heals you to half health, +80 max health");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "Silva revive can recharge after 180s");
            QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                    "Silva invincibility increased to 20s, and grant 5s true invulnerability at first");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchSilva = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Silva");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SilvaArmor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SilvaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.Wings.SilvaWings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Nadir>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.ScourgeoftheCosmos>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Ultima>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.RubicoPrime>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Onyxia>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.Climax>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.AlphaRay>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.MidnightSunBeacon>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.EclipsesFall>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}