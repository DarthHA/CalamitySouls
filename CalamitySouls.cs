using Terraria.ModLoader;
using CalamitySouls.Ench;
using System.Collections.Generic;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CalamitySouls.Projectiles;

namespace CalamitySouls
{
	public class CalamitySouls : Mod
	{
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			Player player = Main.LocalPlayer;
			CSPlayer mplayer = player.CS();
			int projIndex = layers.FindIndex((GameInterfaceLayer layer) => layer.Name == "Vanilla: Laser Ruler");
			if (projIndex != -1)
			{
				layers.Insert(projIndex, new LegacyGameInterfaceLayer("BrimflameRay", delegate ()
				{
					if (mplayer.BrimFrenzyVisualEffect > 0)
					{
						Texture2D laserTexture = Instance.GetTexture("Extras/BrimflameLasers");
						float rot = MathHelper.ToRadians(3 * mplayer.BrimFrenzyVisualEffect);
						float colorLerpRaius = 1f;
						if (mplayer.BrimFrenzyVisualEffect <= 5) colorLerpRaius = MathHelper.Lerp(1f, 0f, mplayer.BrimFrenzyVisualEffect / 5f);
						else if (mplayer.BrimFrenzyVisualEffect >= 25) colorLerpRaius = MathHelper.Lerp(1f, 0f, (mplayer.BrimFrenzyVisualEffect - 25f) / 5f);
						Color color = Color.White * colorLerpRaius;
						Main.spriteBatch.Draw(laserTexture, player.Center - Main.screenPosition, null, Color.White, -rot, laserTexture.Size() / 2f, 1f, SpriteEffects.None, 0f);
					}
					return true;
				}, InterfaceScaleType.Game));
			}
			int mouseIndex = layers.FindIndex((GameInterfaceLayer layer) => layer.Name == "Vanilla: Mouse Text");
			if (mouseIndex != -1)
			{
				layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Manic Mode UI", delegate ()
				{
					if (Main.playerInventory && CSWorld.HyperMode)
					{
						Texture2D outerAreaTexture = ModContent.GetTexture("CalamitySouls/Extras/ManicModeUI");
						Vector2 drawCenter = new Vector2((float)Main.screenWidth - 400f, 72f) + Utils.Size(outerAreaTexture) * 0.5f;
						Main.spriteBatch.Draw(outerAreaTexture, drawCenter, null, Color.White, 0f, Utils.Size(outerAreaTexture) * 0.5f, 1f, SpriteEffects.None, 0f);
					}
						return true;
				}, InterfaceScaleType.UI));
			}
		}
		public override void Load()
		{
			Instance = this;
			//AddConfigTranslation("ForceAntiNatural", "Force of Anti-Natural", 2, "C9995C");
			//AddConfigTranslation("AeroFall", "Aerospec Enchant Fall and Jump Boost", ModContent.ItemType<EnchAerospec>(), "99C8C1");
			//AddConfigTranslation("AeroFeather", "Aerospec Enchant Feather and Transformer on hit", ModContent.ItemType<EnchAerospec>(), "99C8C1");
			//AddConfigTranslation("AeroJump", "Aerospec Enchant Blizzard and Tsunami Jump", ModContent.ItemType<EnchAerospec>(), "99C8C1");
			//AddConfigTranslation("AeroPotion", "Aerospec Enchant Bounding and Soaring Potion", ModContent.ItemType<EnchAerospec>(), "99C8C1");
			//AddConfigTranslation("AeroSummon", "Aerospec Enchant Locket and Valkyrie", ModContent.ItemType<EnchAerospec>(), "99C8C1");
			//AddConfigTranslation("AstralHide", "Astral Enchant Hide of the Astrum Deus effect", ModContent.ItemType<EnchAstral>(), "959C9B");
			//AddConfigTranslation("AstralMana", "Astral Enchant crazy mana regen", ModContent.ItemType<EnchAstral>(), "959C9B");
			//AddConfigTranslation("AstralPotion", "Astral Enchant Omnisense and Gravity Normalizer Potion", ModContent.ItemType<EnchAstral>(), "959C9B");
			//AddConfigTranslation("AstralSpeed", "Astral Enchant fire rate boost", ModContent.ItemType<EnchAstral>(), "959C9B");
			//AddConfigTranslation("AstralStar", "Astral Enchant star on crit", ModContent.ItemType<EnchAstral>(), "959C9B");
			RegisterHotKeys();
			CSLists.Load();
			CalamityMod.CalamityLists.projectileDestroyExceptionList.Add(ModContent.ProjectileType<GodslayerDoGHead>());
			CalamityMod.CalamityLists.projectileDestroyExceptionList.Add(ModContent.ProjectileType<GodslayerDoGJaw>());
		}
        public override void Unload()
        {
			Instance = null;
			UnloadHotKeys();
			CSLists.Unload();
        }
        public override void AddRecipeGroups()
        {
            CSRecipe.AddRecipeGroup();
        }
  //      public void AddConfigTranslation(string Source, string name, string item, string color)
		//{
		//	ModTranslation text = CreateTranslation("Config" + Source);
		//	text.SetDefault(string.Concat(new object[]
		//	{
		//		"[i:",
		//		Instance.ItemType(item),
		//		"][c/",
		//		color,
		//		": ",
		//		name,
		//		"]"
		//	}));
		//	AddTranslation(text);
		//}
		//public void AddConfigTranslation(string Source, string name, int item, string color)
		//{
		//	ModTranslation text = CreateTranslation(Source);
		//	text.SetDefault(string.Concat(new object[]
		//	{
		//		"[i:",
		//		item,
		//		"][c/",
		//		color,
		//		": ",
		//		name,
		//		"]"
		//	}));
		//	AddTranslation(text);
		//}
		public static Mod Instance;
		public void RegisterHotKeys()
        {
			BloodKey = RegisterHotKey("Bloodflare Option hotkey", "L");
			BrimflameKey = RegisterHotKey("Brimflame enchant hotkey", "G");
			FearmongerArea = RegisterHotKey("Fearmonger Frigid Area hotkey", "K");
			FearmongerMark = RegisterHotKey("Fearmonger Mark hotkey", "J");
			GodslayerKey = RegisterHotKey("Godslayer Devourer hotkey", "H");
			StatigelKey = RegisterHotKey("Statigel enchant hotkey", "B");
			TitanKey = RegisterHotKey("Titan heart enchant hotkey", "N");
        }
		public void UnloadHotKeys()
        {
			BloodKey = null;
			BrimflameKey = null;
			FearmongerArea = null;
			FearmongerMark = null;
			GodslayerKey = null;
			StatigelKey = null;
			TitanKey = null;
        }
		public static ModHotKey BloodKey;
		public static ModHotKey BrimflameKey;
		public static ModHotKey FearmongerArea;
		public static ModHotKey FearmongerMark;
		public static ModHotKey GodslayerKey;
		public static ModHotKey StatigelKey;
		public static ModHotKey TitanKey;
    }
}