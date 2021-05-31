using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchPlagueReaper : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Plague Reaper";
            ChineseName = "瘟疫收割者";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "3A514B";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「不做好防护，被感染很正常。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlagueReaperVest>(), color) +
                    "被瘟疫感染的生物多受到10%伤害，你获得额外飞行时间但是被致盲");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "增强肾上腺素的效果，且满肾上腺素后受击不会清空肾上腺素");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「It's common to get infected without proper protect.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.PlagueReaperVest>(), color) +
                "Plagued enemies receive 10% more damage, you gain extra flight time but get blinded");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Boost the effect of adrenaline and your adrenaline won't be cleared anymore once get fully charged");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchPlagueReaper = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlagueReaperMask>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlagueReaperVest>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.PlagueReaperStriders>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.SoulHarvester>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Ammo.AcidBullet>(), 600); 
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Plaguenade>(),300);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.EpidemicShredder>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Typeless.YanmeisKnife>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
