using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using CalamityMod.Items;
using CalamityMod.Items.Armor;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Items
{
    public class PrismaticTrailToggler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Trail Toggler");
            Tooltip.SetDefault("Favorite in inventory to cancel Prismatic Trail effect");
            DisplayName.AddTranslation(GameCulture.Chinese, "光棱预判线开关");
            Tooltip.AddTranslation(GameCulture.Chinese, "在背包中收藏，关闭光棱魔石的预判线效果");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 38;
            item.Calamity().customRarity = CalamityRarity.Dedicated;
        }
        public override void UpdateInventory(Player player)
        {
            if (item.favorited) player.CS().NoTrailPleaseEvenIfYouHaventDoneConfigPleaseDoSomethingToCloseTheTrail = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<DarkPlasma>(), 1);
            recipe.AddIngredient(ItemType<ArmoredShell>(), 1);
            recipe.AddIngredient(ItemType<TwistingNether>(), 1);
            recipe.AddIngredient(ItemType<DivineGeode>(), 1);
            recipe.AddIngredient(ItemType<ExodiumClusterOre>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}