using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;

namespace CalamitySouls.Items
{
   public class TheSorber:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Sorber");
            DisplayName.AddTranslation(GameCulture.Chinese, "阴阳化功石");
            Tooltip.SetDefault("Simplized version of the absorber\n" +
                "+12% movement speed, +24% jump speed\n" +
                "+20 max life and mana, +5% damage reduction\n");
            Tooltip.AddTranslation(GameCulture.Chinese, "阴阳吸星石的简化版\n" +
                "+12%移速，+24%跳跃速度\n" +
                "+20最大生命和最大魔力，+5%免伤\n");
        }
        public override void SetDefaults()
        {
            item.defense = 6;
            item.width = 20;
            item.height = 24;
            item.value = CalamityGlobalItem.Rarity10BuyPrice;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalamityPlayer cplayer = player.Calamity();
            if (!cplayer.absorber)
            {
                player.moveSpeed += 0.12f;
                player.jumpSpeedBoost += 1.2f;
                player.statLifeMax2 += 20;
                player.statManaMax2 += 20;
            }
            if (!cplayer.seaShell) player.endurance += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GrandGelatin>());
            recipe.AddIngredient(ModContent.ItemType<SeaShell>());
            recipe.AddIngredient(ModContent.ItemType<CrawCarapace>());
            recipe.AddIngredient(ModContent.ItemType<FungalCarapace>());
            recipe.AddIngredient(ModContent.ItemType<GiantTortoiseShell>());
            recipe.AddIngredient(ModContent.ItemType<AmidiasSpark>());
            recipe.AddIngredient(ModContent.ItemType<RoverDrive>());
            recipe.AddIngredient(ModContent.ItemType<DepthCells>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Lumenite>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Tenebris>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Stardust>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GrandGelatin>());
            recipe.AddIngredient(ModContent.ItemType<SeaShell>());
            recipe.AddIngredient(ModContent.ItemType<FungalCarapace>());
            recipe.AddIngredient(ModContent.ItemType<GiantShell>());
            recipe.AddIngredient(ModContent.ItemType<GiantTortoiseShell>());
            recipe.AddIngredient(ModContent.ItemType<AmidiasSpark>());
            recipe.AddIngredient(ModContent.ItemType<RoverDrive>());
            recipe.AddIngredient(ModContent.ItemType<DepthCells>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Lumenite>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Tenebris>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Stardust>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ModContent.ItemType<TheAbsorber>());
            recipe.AddRecipe();
        }
    }
}
