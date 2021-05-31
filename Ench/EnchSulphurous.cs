using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using System.IO;

namespace CalamitySouls.Ench
{
   public  class EnchSulphurous:BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Sulphurous";
            ChineseName = "硫磺海";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "A89254";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「一定程度上的侵蚀使得存在更有力。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SulfurBreastplate>(), color) +
                    "无视水阻力，减少硫磺海水的伤害，你和你的鼠标周围环绕着cool的酸海剧毒区域");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "获得一个硫海二段跳、一个屁二段跳、单纯的冲刺、连跳和羽落效果，+24%跳跃速度");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "代价是火箭靴和翅膀时间都归零");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「To a certain extent, corrosion leads to better existance.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.SulfurBreastplate>(), color) +
                "Ignore water, reduces the DoT of the sulphuric waters and cool sulphurous areas are around you and your mouse");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Accessories.RustyMedallion>(), color) +
                "Grant a sulphur jump, a fart jump, a dash, autojump and featherfall effect, +24% jump speed");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "But the price is that you can no longer fly with wings or rocket boots");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchSulphurous = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SulfurHelmet>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SulfurBreastplate>()); 
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.SulfurLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Basher>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Toxibow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.AcidGun>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.CausticCroakerStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.RustyBeaconPrototype>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.ContaminatedBile>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Pets.RadiatingCrystal>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}