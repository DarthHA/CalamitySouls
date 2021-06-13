using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items.BossLoots
{
  public  class CoreofSlimeGod:ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of the Slime God");
            Tooltip.SetDefault("Greatly increase horizonal movement speed and you grant infinite Statis Jump when ridding on a slime mount\n" +
                CSUtils.ManicModeName + " only");
            DisplayName.AddTranslation(GameCulture.Chinese, "史莱姆之神核心");
            Tooltip.AddTranslation(GameCulture.Chinese, "乘坐在史莱姆坐骑上时，大大增加水平移动速度且你获得无限的斯塔提斯跳跃\n" +
                CSUtils.ManicModeNameChi + "专属");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.accessory = true;
            item.rare = ItemRarityID.Expert;
            item.value = CalamityMod.Items.CalamityGlobalItem.Rarity12BuyPrice;
            item.expert = true;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().sgCore = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = Color.Gold;
                }
            }
        }
    }
}