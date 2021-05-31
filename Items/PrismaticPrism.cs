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
   public class PrismaticPrism:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Prism");
            Tooltip.SetDefault("Spawn a prism that circle around you and change hostile projectile's direction\n" +
                "Cancel the non-magic damage reduction of Prismatic armor While wearing full-set prismatic armor");
            DisplayName.AddTranslation(GameCulture.Chinese, "光棱镜");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个在你周围环绕，改变敌对弹幕方向的棱镜\n" +
                "当穿着全套光棱套时，取消光棱套的非魔法伤害减少效果");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 38;
            item.accessory = true;
            item.value = CalamityGlobalItem.Rarity13BuyPrice;
            item.Calamity().customRarity = CalamityRarity.Dedicated;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().pPrism = true;
            if (player.armor[0].type == ItemType<PrismaticHelmet>() 
                && player.armor[1].type == ItemType<PrismaticRegalia>() 
                && player.armor[2].type == ItemType<PrismaticGreaves>())
            {
                player.allDamage += 0.6f;
                player.magicDamage -= 0.6f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<DarkPlasma>(), 5);
            recipe.AddIngredient(ItemType<ArmoredShell>(), 5);
            recipe.AddIngredient(ItemType<TwistingNether>(), 5);
            recipe.AddIngredient(ItemType<DivineGeode>(), 10);
            recipe.AddIngredient(ItemType<ExodiumClusterOre>(), 14);
            recipe.AddIngredient(ItemID.Nanites, 777);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
