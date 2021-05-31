//using System.ComponentModel;
//using Terraria.ModLoader;
//using Terraria.ModLoader.Config;

//namespace CalamitySouls
//{
//    [Label("Configuration Options")]
//    [BackgroundColor(49, 32, 36, 216)]
//   public class CSConfig :ModConfig
//	{
//		public override ConfigScope Mode
//		{
//			get
//			{
//				return (ConfigScope)1;
//			}
//		}
//		[Header("$Mods.CalamitySouls.ConfigForceAntiNatural")]
//        #region Aero
//        [Label("$Mods.CalamitySouls.ConfigAeroFall")]
//		[BackgroundColor(201, 153, 92, 192)]
//		[DefaultValue(true)]
//		public bool AeroFall { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAeroFeather")]
//		[BackgroundColor(201, 153, 92, 192)]
//		[DefaultValue(true)]
//		public bool AeroFeather { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAeroJump")]
//		[BackgroundColor(201, 153, 92, 192)]
//		[DefaultValue(true)]
//		public bool AeroJump { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAeroPotion")]
//		[BackgroundColor(201, 153, 92, 192)]
//		[DefaultValue(true)]
//		public bool AeroPotion { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAeroSummon")]
//		[BackgroundColor(201, 153, 92, 192)]
//		[DefaultValue(true)]
//		public bool AeroSummon { get; set; }
//        #endregion
//        [Header("$Mods.CalamitySouls.ConfigForceMechanical")]
//        #region Astral
//        [Label("$Mods.CalamitySouls.ConfigAstralHide")]
//		[BackgroundColor(206, 201, 170, 192)]
//		[DefaultValue(true)]
//		public bool AstralHide { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAstralMana")]
//		[BackgroundColor(206, 201, 170, 192)]
//		[DefaultValue(true)]
//		public bool AstralMana { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAstralPotion")]
//		[BackgroundColor(206, 201, 170, 192)]
//		[DefaultValue(true)]
//		public bool AstralPotion { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAstralSpeed")]
//		[BackgroundColor(206, 201, 170, 192)]
//		[DefaultValue(true)]
//		public bool AstralSpeed { get; set; }
//		[Label("$Mods.CalamitySouls.ConfigAstralStar")]
//		[BackgroundColor(206, 201, 170, 192)]
//		[DefaultValue(true)]
//		public bool AstralStar { get; set; }
//        #endregion





//        public static CSConfig Instance;
//	}
//}
