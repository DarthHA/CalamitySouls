using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items
{
    public class PortableFart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Portable Fart");
            Tooltip.SetDefault("Favorite in inventory to work as Green Horseshoe Balloon");
            DisplayName.AddTranslation(GameCulture.Chinese, "便携屁");
            Tooltip.AddTranslation(GameCulture.Chinese, "在背包中收藏，可以像绿马蹄气球一样工作");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.rare = ItemRarityID.Expert;
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
        public override void UpdateInventory(Player player)
        {
            if (item.favorited)
            {
                player.doubleJumpFart = true;
                player.jumpBoost = true;
                player.noFallDmg = true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BalloonHorseshoeFart);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}