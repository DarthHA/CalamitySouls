using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace CalamitySouls.Items
{
	[AutoloadEquip(EquipType.Shoes)]
	public class EvilTreads : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Treads");
			Tooltip.SetDefault("Fantastic speed!\nYou are panic\n+20 max mana");
			DisplayName.AddTranslation(GameCulture.Chinese, "邪恶之靴");
			Tooltip.AddTranslation(GameCulture.Chinese, "超凡的速度！\n你处于慌乱状态\n+20魔力上限");
		}
		public override void SetDefaults()
		{
			item.width = 54;
			item.height = 52;
			item.value = CalamityMod.Items.CalamityGlobalItem.Rarity3BuyPrice;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 8f;
			player.rocketBoots = 5;
			player.AddBuff(BuffID.Panic, 2);
			player.statManaMax2 += 20;
		}
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.SpectreBoots);
			modRecipe.AddIngredient(ItemID.PanicNecklace);
			modRecipe.AddIngredient(ItemID.BandofStarpower);
			modRecipe.AddIngredient(ItemID.ShadowScale, 25);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.SpectreBoots);
			modRecipe.AddIngredient(ItemID.PanicNecklace);
			modRecipe.AddIngredient(ItemID.BandofStarpower);
			modRecipe.AddIngredient(ItemID.TissueSample, 25);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
	