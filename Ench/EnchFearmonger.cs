using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace CalamitySouls.Ench
{
    public class EnchFearmonger : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Fearmonger";
            ChineseName = "神惧者";
            Tooltip = ChineseTooltip = "0\n1\n2\n3\n4\n5";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "CD4D23";
            string key1 = CalamitySouls.FearmongerArea.TooltipHotkeyString();
            string key2 = CalamitySouls.FearmongerMark.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「即使最强大的神明也对你感到恐惧。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FearmongerPlateMail>(), color) +
                    "取消手持非召唤武器时的召唤伤害衰减，极大增加生命回复");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "受击或者按" + key1 + "时在你周围生成一个霜冻区域，停止区域内的所有实体");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "霜冻区域存在5秒，冷却为60秒，消失时清除范围内弹幕");
                QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                    "按" + key2 + "锁定距离鼠标最近的目标，你对锁定的目标多造成25%伤害，但对其他目标伤害减半");
                QuickModiLine(ref tooltips, 5, CSUtils.GetModItemText(item.type, color) +
                    "切换目标的冷却为15秒，可以随意清除锁定，如果目标死亡则自动清除锁定");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「Even the most magnificent Gods treat you with fear.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.FearmongerPlateMail>(), color) +
                "The minion damage nerf while wielding weaponry is cancelled, massively increase life regen");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Being attacked or press " + key1 + " spawn a frigid area stopping all entities");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The area lasts 5s with a 60s cooldown and clear projectiles when dead");
            QuickModiLine(ref tooltips, 4, CSUtils.GetModItemText(item.type, color) +
                "Press " + key2 + " to mark closet npc to mouse, you deal 25% more damage to marked enermies but deal half damage to others");
            QuickModiLine(ref tooltips, 5, CSUtils.GetModItemText(item.type, color) +
                "It takes 15s to mark another target, you can clear mark with no price, and the death of the marked clears the mark");
        }
        public override void SetEnchDefaults()
        {
            item.defense += 7;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchFearmonger = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FearmongerGreathelm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FearmongerPlateMail>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.FearmongerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.TheEnforcer>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.EssenceFlayer>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.StreamGouge>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.CleansingBlaze>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.SoulPiercer>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.ExecutionersBlade>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
