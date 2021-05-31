using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items
{
  public  class ManicTalisman:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Manic Talisman");
            Tooltip.SetDefault("Activates Manic Mode, which doubles NPC's ai speed, halves NPC's damage taken, and you take 50% more damage\n" +
                "But your crit deals 5% more damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "脑瘫护符");
            Tooltip.AddTranslation(GameCulture.Chinese, "激活脑瘫模式，加倍NPC的ai速度，减半NPC受到伤害，你多受到50%伤害\n" +
                "但是你的暴击多造成5%伤害");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.useAnimation = item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item120;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach(TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = Color.SkyBlue;
                }
            }
        }
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation == player.itemAnimationMax-1) 
            {
                string text = CSUtils.GameCultureChinese ? "脑瘫模式关闭" : "Manic Mode deactivated.";
                if (!CSWorld.HyperMode) text = CSUtils.GameCultureChinese ? "脑瘫模式开启" : "Manic Mode activated.";
                if (!CSUtils.AnyBossAlive) CSWorld.HyperMode = !CSWorld.HyperMode;
                else text = CSUtils.GameCultureChinese ? "Boss战中不能改变模式" : "You cannot switch the mode during a boss fight";
                Main.NewText(text, Color.SkyBlue);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
