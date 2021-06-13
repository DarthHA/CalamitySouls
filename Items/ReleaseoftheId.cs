using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalamitySouls.Projectiles;

namespace CalamitySouls.Items
{
    public class ReleaseoftheId : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emotion Release");
            Tooltip.SetDefault("514");
            DisplayName.AddTranslation(GameCulture.Chinese, "情绪释放");
            Tooltip.AddTranslation(GameCulture.Chinese, "514");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 36;
            item.rare = ItemRarityID.Yellow;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity8BuyPrice;
            item.noMelee = true;

            item.summon = true;
            item.damage = 60;
            item.knockBack = 5f;
            item.useAnimation = item.useTime = 20;
            item.UseSound = SoundID.Item71;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<IdentityCard>();
            item.shootSpeed = 0;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.ownedProjectileCounts(item.shoot) >= 6) return false;
            float totalMinionSlots = 0f;
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].minion && Main.projectile[i].owner == player.whoAmI)
				{
					totalMinionSlots += Main.projectile[i].minionSlots;
				}
			}
			if (player.altFunctionUse != 2 && totalMinionSlots < player.maxMinions)
			{
				Projectile.NewProjectile(position, Vector2.Zero, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position, Vector2.Zero, type, damage, knockBack, player.whoAmI);
				int swordCount = 0;
				for (int j = 0; j < Main.projectile.Length; j++)
				{
					if (Main.projectile[j].active && Main.projectile[j].type == type && Main.projectile[j].owner == player.whoAmI)
					{
						swordCount++;
					}
				}
				float angleVariance = MathHelper.TwoPi/ swordCount;
				float angle = 0f;
				for (int l = 0; l < Main.projectile.Length; l++)
				{
					if (Main.projectile[l].active && Main.projectile[l].type == type && Main.projectile[l].owner == player.whoAmI)
					{
						Main.projectile[l].ai[0] = angle;
						angle += angleVariance;
					}
				}
			}
			return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.SolarVeil>(), 10);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}