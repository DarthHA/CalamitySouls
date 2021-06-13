using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items
{
    public class StinkCushion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stink Cushion");
            Tooltip.SetDefault("Annoying stinky");
            DisplayName.AddTranslation(GameCulture.Chinese, "恶臭坐垫");
            Tooltip.AddTranslation(GameCulture.Chinese, "TMD臭死了");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 24;
            item.rare = ItemRarityID.Orange;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity3BuyPrice;
            item.useAnimation = item.useTime = 5;
            item.holdStyle = ItemHoldStyleID.HoldingOut;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item16;
            item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = Color.LimeGreen;
                }
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpFart = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinkfish);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.ShinyRedBalloon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.FartInABalloon);
            recipe.AddRecipe();
        }
    }
}