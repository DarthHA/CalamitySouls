using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamitySouls.Projectiles;

namespace CalamitySouls.Items
{
    public class PeerlessWindGod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flawless Wind");
            Tooltip.SetDefault("'I'd take it easy'");
            DisplayName.AddTranslation(GameCulture.Chinese, "无瑕之风");
            Tooltip.AddTranslation(GameCulture.Chinese, "‘我会放水的’");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 66;
            item.rare = ItemRarityID.Yellow;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity8BuyPrice;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;

            item.melee = true;
            item.damage = 60;
            item.knockBack = 3.5f;
            item.useAnimation = item.useTime = 30;
            item.UseSound = SoundID.Item71;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<PeerlessWindGodProj>();
            item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position, Vector2.Zero, type, damage, knockBack, player.whoAmI);
            return false;
        }
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts(item.shoot) < 1;
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Arkhalis);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.SolarVeil>(), 10);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.AerialiteBar>(), 23);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}