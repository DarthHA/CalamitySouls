using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace CalamitySouls.Items
{
   public class MoltenNecklace:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Necklace");
            Tooltip.SetDefault("+20 armor penetration and +5% damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "熔岩项链");
            Tooltip.AddTranslation(GameCulture.Chinese, "+20穿甲和+5%伤害");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 28;
            item.accessory = true;
            item.rare = ItemRarityID.Green;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity2BuyPrice;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 20;
            player.allDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
