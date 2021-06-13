using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchStatigel : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Statigel";
            ChineseName = "斯塔提斯";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "DFCCFF";
            string teleport = CSUtils.TooltipHotkeyString(CalamitySouls.StatigelKey);
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「传说忍者之魂」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.StatigelArmor>(), color) +
                    "召唤迷你史莱姆之神为你而战，增加30%跳跃速度，无敌时间延长");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "按" + teleport + "键让核心转化为防御状态，索敌范围大大降低但是速度大大增加");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Spirit of the legendary ninja」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.StatigelArmor>(), color) +
                "Summons a mini slime god to fight for you, +5 jump height, +30% jump speed and increased immunity frame");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Press "+teleport+" to let the Core transform into defensive mode, lower search range but higher speed");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchStatigel = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Statigel");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.StatigelArmor>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.StatigelGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.GeliticBlade>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.TheGodsGambit>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Goobow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.GunkShot>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.OverloadedBlaster>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.EldritchTome>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.AbyssalTome>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.CorroslimeStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.CrimslimeStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.GelDart>(), 514);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}