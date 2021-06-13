using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using CalamityMod;

namespace CalamitySouls.Items
{
    public class GodlySpikeNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Godly Spike Necklace");
            Tooltip.SetDefault("+150 armor penetration and +15% damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "神明之刺项链");
            Tooltip.AddTranslation(GameCulture.Chinese, "+150穿甲和+15%伤害");
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 56;
            item.accessory = true;
            item.Calamity().postMoonLordRarity = 15; 
            item.Calamity().customRarity = CalamityRarity.Violet;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity15BuyPrice;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 150;
            player.allDamage += 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SandsharkNecklace>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Accessories.ReaperToothNecklace>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.AuricBar>(), 4);
            recipe.AddTile(ModContent.TileType<CalamityMod.Tiles.Furniture.CraftingStations.DraedonsForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}