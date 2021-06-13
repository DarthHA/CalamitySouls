using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Ench;

namespace CalamitySouls.Force
{
    public class ForceAnnihilation : BasicForce
    {
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Annihilation";
            ChineseName = "湮灭";
            ttAmt = 8;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            string hotkey = CSUtils.TooltipHotkeyString(CalamitySouls.BrimflameKey);
            string key = CalamitySouls.BloodKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「这超越自然的力量将抹除一切存在。」");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAerospec>(), "99C8C1") +
                    "让你下落更快，免疫坠落伤害，获得10穿甲和1召唤栏");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchBrimflame>(), "E34F4F") +
                    "免疫大多数火系列减益，按" + hotkey + "开启硫火暴乱效果，期间你多造成25%伤害");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchUmbraphile>(), "ED7112") +
                    "获得不可检测增益，在没有boss存活时使所有生物变得友好，增加15%武器使用速度");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchHydrothermic>(), "E06C1D") +
                    "死亡时以10血复活，该能力冷却为120秒");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchEmpyrean>(), "9CFFEE") +
                    "击中敌人会释放各种各样的额外弹幕，常驻宇宙之怒和宇宙狂怒增益");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchBloodflare>(), "CC2A3C") +
                    "按" + key + "键将你的10%生命上限分离出来变成血炎子机");
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchFearmonger>(), "CD4D23") +
                    "取消手持非召唤武器时的召唤伤害衰减，极大增加生命回复，神惧者魔石的霜冻能力");
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「The unnatural power may demolish all existance.」");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchAerospec>(), "99C8C1") +
                "Allows you to fall more quickly and disables fall damage, grant 10 armor penetration and 1 minion slot");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchBrimflame>(), "E34F4F") +
                "Immnue to most fire-relative debuffs, Press " + hotkey + " to trigger a brimflame frenzy effect, during which you deal 25% more damage");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchUmbraphile>(), "ED7112") +
                "You grant Undetected buff, which makes all creatures friendly while no boss is alive, +15% weapon fire rate");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchHydrothermic>(), "E06C1D") +
                "You revive at 10 hp when dead which have a 120s cooldown");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchEmpyrean>(), "9CFFEE") +
                "Hitting a creature release tons of projectiles, you are imbued with cosmic wrath and rage");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchBloodflare>(), "CC2A3C") +
                "Press " + key + " to separate your 10% max hp to a Bloodflare Option");
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<EnchFearmonger>(), "CD4D23") +
                "Cancel the minion damage nerf, massively increase life regen, the frigid effect of fearmonger enchant");
        }
        public override void SetForceDefaults()
        {
            item.defense += 23;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceAnnihilation = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchAerospec>());
            recipe.AddIngredient(ModContent.ItemType<EnchBrimflame>());
            recipe.AddIngredient(ModContent.ItemType<EnchUmbraphile>());
            recipe.AddIngredient(ModContent.ItemType<EnchHydrothermic>());
            recipe.AddIngredient(ModContent.ItemType<EnchEmpyrean>());
            recipe.AddIngredient(ModContent.ItemType<EnchBloodflare>());
            recipe.AddIngredient(ModContent.ItemType<EnchFearmonger>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.DarksunFragment>(), 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}