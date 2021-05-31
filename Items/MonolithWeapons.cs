using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamitySouls.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Items
{
    public class MonolithRay : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Myth");
            Tooltip.SetDefault("Shoot powerful astral ray");
            DisplayName.AddTranslation(GameCulture.Chinese, "神话之书");
            Tooltip.AddTranslation(GameCulture.Chinese, "射出强大的幻星射线");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 46;
            item.magic = true;
            item.damage = 80;
            item.knockBack = 5f;
            item.mana = 10;
            item.useAnimation = item.useTime = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item125;
            item.shoot = ProjectileType<AstralRay>();
            item.shootSpeed = 8f;
            item.rare = ItemRarityID.LightRed;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity5BuyPrice;
            item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position += new Vector2(speedX, speedY) * 4f;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<AstralMonolith>(), 20);
            recipe.AddIngredient(ItemType<Stardust>(), 32);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class MonolithStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infection Stick");
            Tooltip.SetDefault("Seems the wood is too hard for manipulation...But it's already a good weapon");
            DisplayName.AddTranslation(GameCulture.Chinese, "感染木棍");
            Tooltip.AddTranslation(GameCulture.Chinese, "看上去这种木头硬到难以加工...不过它已经可以作为一个好武器了");
        }
        public override void SetDefaults()
        {
            item.width = 72;
            item.height = 102;
            item.melee = true;
            item.damage = 300;
            item.knockBack = 10f;
            item.useAnimation = item.useTime = 45;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.LightRed;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity5BuyPrice;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<AstralMonolith>(), 50);
            recipe.AddIngredient(ItemType<Stardust>(), 5);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}