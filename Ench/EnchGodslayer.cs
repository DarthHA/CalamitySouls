using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Items;

namespace CalamitySouls.Ench
{
    public class EnchGodslayer : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Godslayer";
            ChineseName = "弑神者";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "FC6DCA";
            string key = CalamitySouls.GodslayerKey.TooltipHotkeyString();
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「还没完，小鬼！」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerChestplate>(), color) +
                    "你获得弑神者复活效果，你的攻击会生成弑神者幻影");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "缩短弑神者复活CD至30秒，按"+key+"释放致命的神之幻影，冷却70秒");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「It's not over yet, kid!」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerChestplate>(), color) +
                "You are granted godslayer revive effect and your attack will summon god slayer phantoms");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Reduce Godslayer revive cooldown to 30s, Press " + key + "to unleash interdimensional projection with a 70s cooldown");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchGodslayer = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Godslayer");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerChestplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Excelsus>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.EradicatorMelee>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.TheObliterator>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.Deathwind>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.DeathhailStaff>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Summon.StaffoftheMechworm>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.Eradicator>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
