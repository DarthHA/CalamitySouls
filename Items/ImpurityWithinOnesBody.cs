using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamitySouls.Projectiles;

namespace CalamitySouls.Items
{
  public  class ImpurityWithinOnesBody:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impurity Inside");
            Tooltip.SetDefault("Fury of the earth");
            DisplayName.AddTranslation(GameCulture.Chinese, "内在邪秽");
            Tooltip.AddTranslation(GameCulture.Chinese, "地球之怒");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 54;
            item.rare = ItemRarityID.Yellow;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity8BuyPrice;

            item.magic = true;
            item.mana = 6;
            item.damage = 66;
            item.knockBack = 6f;
            item.useAnimation = 30;
            item.useTime = 10;
            item.UseSound = SoundID.Item71;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ImpurityOrb>();
            item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            speedX = Main.rand.Next(-10, 11) / 10f;
            speedY = -10f;
            Projectile.NewProjectile(position.X + Main.rand.Next(300, 401), position.Y + 900, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X - Main.rand.Next(300, 401), position.Y + 900, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return false;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            damage *= 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.SolarVeil>(), 10);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.TrueShadowScale>(), 100);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
