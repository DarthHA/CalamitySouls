using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchPlaguebringer : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Plague Bringer";
            ChineseName = "瘟疫使者";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "E54242";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「你觉得自己像是一座灯塔。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerCarapace>(), color) +
                    "获得一个瘟疫冲刺，快速移动时生成蜜蜂");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerCarapace>(), color) +
                    "召唤一个小瘟疫使者保护你并增强附近召唤物");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "免疫瘟疫，攻击造成瘟疫，移除敌人的瘟疫免疫，并加强瘟疫debuff的效果");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「You feel like a lighthouse.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerCarapace>(), color) +
                "Grants a plague dash to ram enemies and you spawn bees while sprinting or dashing ");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerCarapace>(), color) +
                "Summons a lil' plaguebringer to protect you and empower nearby minions");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "Immunity to Plague, your attack force plague on enermies and significantly boost plague effect");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchPlagueBringer= true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerVisor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerCarapace>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlaguebringerPistons>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.VirulentKatana>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.DiseasedPike>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.ThePlaguebringer>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Malevolence>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.PestilentDefiler>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.TheHive>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.MepheticSprayer>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.PlagueStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.FuelCellBundle>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.InfectedRemote>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.TheSyringe>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}