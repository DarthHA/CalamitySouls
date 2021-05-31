using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamitySouls;
using System.Collections.Generic;

namespace CalamitySouls.Ench
{
    public class EnchDaedalus : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Daedalus";
            ChineseName = "代达罗斯";
            Tooltip = ChineseTooltip = "0\n1\n2";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "DA69E9";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「从太阳处逃离者建立了一个冻结的世界」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DaedalusBreastplate>(), color) +
                    "增加20生命上限，受伤时闪避并生成一圈追踪水晶，冷却45秒");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "免疫伊卡洛斯之愚蠢，一个真代达罗斯水晶协助你，根据手持物品切换攻击模式");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「The one who escaped from the sun build up a frozen world.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.DaedalusBreastplate>(), color) +
                "+20 max health, evade damage and burst out chasing crystal shard with a 45s cooldown");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "Immunity to Icarus' Folly, a true daedalus crystal assist you which swiches attack according to your holding item");
        }
        public override void SetEnchDefaults()
        {
            item.defense = 8;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchDaedalus = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CS:Daedalus");
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DaedalusBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.DaedalusLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.OrnateShield>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Trinity>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.StarnightLance>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Melee.Shimmerspark>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Ranged.DarkechoGreatbow>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Magic.ShadecrystalTome>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.CrystalPiercer>(), 360);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
