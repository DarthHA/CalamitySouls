using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items
{
    public class SeafrogLeg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seafrog Leg");
            Tooltip.SetDefault("+48% jump speed, grant autojump and a sail jump");
            DisplayName.AddTranslation(GameCulture.Chinese, "海蛙腿");
            Tooltip.AddTranslation(GameCulture.Chinese, "+48%跳跃速度，获得连跳和一个海啸二段跳");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 38;
            item.rare = ItemRarityID.Green;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity2BuyPrice;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.jumpSpeedBoost += 2.4f;
            player.autoJump = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrogLeg);
            recipe.AddIngredient(ItemID.SharkronBalloon);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.VictideBar>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrogLeg);
            recipe.AddIngredient(ItemID.BalloonHorseshoeSharkron);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.VictideBar>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}