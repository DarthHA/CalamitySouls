using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using CalamitySouls.Force;
using Terraria.DataStructures;
using CalamityMod.Tiles.Furniture.CraftingStations;

namespace CalamitySouls.Souls
{
    public class SoulCalamity : BasicSoul
    {
        public override void SetSoulStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 10));
        }
        public override void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Calamity";
            ChineseName = "灾厄";
            ttAmt = 7;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int nextLine = 0;
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, ref nextLine, "「你即灾厄。」", Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceAnnihilation>()), Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceCreature>()), Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceRevolution>()), Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceTechnical>()), Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceTyranny>()), Main.DiscoColor);
                QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(item.type) +
                    "你的肾上腺素多造成300%伤害", Main.DiscoColor);
                return;
            }
            QuickModiLine(ref tooltips, ref nextLine, "「You are the calamity.」", Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceAnnihilation>(), ""), Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceCreature>(), ""), Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceRevolution>(), ""), Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceTechnical>(), ""), Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(ModContent.ItemType<ForceTyranny>(), ""), Main.DiscoColor);
            QuickModiLine(ref tooltips, ref nextLine, CSUtils.GetModItemText(item.type) +
                "Your adrenaline deals 300% more damage", Main.DiscoColor);
        }
        public override void SetSoulDefaults()
        {
            item.width = 38;
            item.height = 46;
            item.defense += 72;
            item.lifeRegen += 21;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().ForceAnnihilation = true;
            player.CS().ForceCreature = true;
            player.CS().ForceRevolution = true;
            player.CS().ForceTechnical = true;
            player.CS().ForceTyranny = true;
            player.CS().AdrenalineDamageBoost += 3f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ForceAnnihilation>());
            recipe.AddIngredient(ModContent.ItemType<ForceCreature>());
            recipe.AddIngredient(ModContent.ItemType<ForceRevolution>());
            recipe.AddIngredient(ModContent.ItemType<ForceTechnical>());
            recipe.AddIngredient(ModContent.ItemType<ForceTyranny>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Rock>(), 5);
            recipe.AddTile(ModContent.TileType<CalamityMod.Tiles.PlacedRock>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}