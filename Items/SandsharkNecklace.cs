using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace CalamitySouls.Items
{
    public class SandsharkNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Shark Necklace");
            Tooltip.SetDefault("+50 armor penetration and +8% damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙鲨项链");
            Tooltip.AddTranslation(GameCulture.Chinese, "+50穿甲和+8%伤害");
        }
        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 36;
            item.accessory = true;
            item.rare = ItemRarityID.Yellow;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity8BuyPrice;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 50;
            player.allDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MoltenNecklace>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.GrandScale>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}