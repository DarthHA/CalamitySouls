using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls
{
    public static class CSRecipe
    {
        public static void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(CSUtils.Cal);
            recipe.AddIngredient(ItemID.AntlionMandible,10);
            recipe.AddIngredient(ItemID.HardenedSand, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemType<CalamityMod.Items.Weapons.Melee.MandibleClaws>());
            recipe.AddRecipe();
            recipe = new ModRecipe(CSUtils.Cal);
            recipe.AddIngredient(ItemID.Sandstone, 30);
            recipe.AddIngredient(ItemID.HardenedSand, 30);
            recipe.AddIngredient(ItemID.Torch, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemType<CalamityMod.Items.Weapons.Melee.BurntSienna>());
            recipe.AddRecipe();
            recipe = new ModRecipe(CSUtils.Cal);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddIngredient(ItemID.HardenedSand, 20);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemType<CalamityMod.Items.Weapons.Ranged.MandibleBow>());
            recipe.AddRecipe();
            recipe = new ModRecipe(CSUtils.Cal);
            recipe.AddIngredient(ItemType<CalamityMod.Items.Materials.StormlionMandible>(), 3);
            recipe.AddIngredient(ItemID.HardenedSand, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemType<CalamityMod.Items.Weapons.Summon.StormjawStaff>());
            recipe.AddRecipe();
        }
        public static void AddRecipeGroup()
        {
            RecipeGroup.RegisterGroup("CS:Aerospec", new RecipeGroup(() => "Any Aerospec Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.AerospecHat>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AerospecHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AerospecHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AerospecHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AerospecHood>()
            }));
            RecipeGroup.RegisterGroup("CS:Auric", new RecipeGroup(() => "Any Auric Tesla Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaHoodedFacemask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaPlumedHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaSpaceHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AuricTeslaWireHemmedVisage>()
            }));
            RecipeGroup.RegisterGroup("CS:Bloodflare", new RecipeGroup(() => "Any Bloodflare Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.BloodflareHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.BloodflareHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.BloodflareHornedHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.BloodflareHornedMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.BloodflareMask>()
            }));
            RecipeGroup.RegisterGroup("CS:Daedalus", new RecipeGroup(() => "Any Daedalus Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.DaedalusHat>(),
                ModContent.ItemType<CalamityMod.Items.Armor.DaedalusHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.DaedalusHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.DaedalusHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.DaedalusVisor>()
            }));
            RecipeGroup.RegisterGroup("CS:Godslayer", new RecipeGroup(() => "Any Godslayer Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerHornedHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.GodSlayerVisage>()
            }));
            RecipeGroup.RegisterGroup("CS:Hydrothermic", new RecipeGroup(() => "Any Hydrothermic Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.AtaxiaHood>()
            }));
            RecipeGroup.RegisterGroup("CS:Reaver", new RecipeGroup(() => "Any Reaver Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.ReaverHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.ReaverVisage>(),
                ModContent.ItemType<CalamityMod.Items.Armor.ReaverMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.ReaverHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.ReaverCap>()
            }));
            RecipeGroup.RegisterGroup("CS:Silva", new RecipeGroup(() => "Any Silva Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.SilvaHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.SilvaHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.SilvaHornedHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.SilvaMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.SilvaMaskedCap>()
            }));
            RecipeGroup.RegisterGroup("CS:Statigel", new RecipeGroup(() => "Any Statigel Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.StatigelCap>(),
                ModContent.ItemType<CalamityMod.Items.Armor.StatigelHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.StatigelHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.StatigelHood>(),
                ModContent.ItemType<CalamityMod.Items.Armor.StatigelMask>()
            }));
            RecipeGroup.RegisterGroup("CS:Tarragon", new RecipeGroup(() => "Any Tarragon Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.TarragonHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.TarragonVisage>(),
                ModContent.ItemType<CalamityMod.Items.Armor.TarragonMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.TarragonHornedHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.TarragonHelmet>()
            }));
            RecipeGroup.RegisterGroup("CS:Victide", new RecipeGroup(() => "Any Victide Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.VictideHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.VictideHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.VictideHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.VictideMask>(),
                ModContent.ItemType<CalamityMod.Items.Armor.VictideVisage>()
            }));
            RecipeGroup.RegisterGroup("CS:Wulfrum", new RecipeGroup(() => "Any Wulfrum Helmet", new int[]
            {
                ModContent.ItemType<CalamityMod.Items.Armor.WulfrumHeadgear>(),
                ModContent.ItemType<CalamityMod.Items.Armor.WulfrumHelm>(),
                ModContent.ItemType<CalamityMod.Items.Armor.WulfrumHelmet>(),
                ModContent.ItemType<CalamityMod.Items.Armor.WulfrumHood>(),
                ModContent.ItemType<CalamityMod.Items.Armor.WulfrumMask>()
            }));
        }
    }
}
