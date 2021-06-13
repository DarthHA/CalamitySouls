using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod;
using CalamitySouls.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls.Items
{
    public class FrostPaintgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Paintball Gun");
            Tooltip.SetDefault("Spread out Frost Paints that inflicts frostburn");
            DisplayName.AddTranslation(GameCulture.Chinese, "雪花彩弹枪");
            Tooltip.AddTranslation(GameCulture.Chinese, "射出造成霜火的冰雪染料球");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 24;
            item.ranged = true;
            item.damage = 13;
            item.useAnimation = 30;
            item.useTime = 10;
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ProjectileType<FrostPaintball>();
            item.shootSpeed = 7f;
            item.noMelee = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Green;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity2BuyPrice;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 velo = new Vector2(speedX, speedY);
            position += velo * 3f;
            speedX += Main.rand.Next(-10, 11) / 10f;
            speedY += Main.rand.Next(-10, 11) / 10f;
            Main.PlaySound(SoundID.Item5, position);
            return true;  
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemID.PainterPaintballGun);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class IcicleDagger : RogueWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle Dagger");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰刺投刀");
        }
        public override void SafeSetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.Calamity().rogue = true;
            item.damage = 14;
            item.knockBack = 3f;
            item.useAnimation = 11;
            item.useTime = 11;
            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileType<IcicleDaggerProj>();
            item.shootSpeed = 15f;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.consumable = true;
            item.healMana = 1;
            item.maxStack = 999;
            item.autoReuse = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 0, 1);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 10);
            recipe.AddIngredient(ItemID.SnowBlock, 10);
            recipe.AddIngredient(ItemID.BorealWood, 5);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostDaggerfish, 100);
            recipe.AddIngredient(ItemID.BorealWood, 10);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}