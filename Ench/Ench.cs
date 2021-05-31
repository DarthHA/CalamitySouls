using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using System.Linq;
using CalamityMod;

namespace CalamitySouls.Ench
{
    public abstract class BasicEnch : ModItem
    {
        public override void SetStaticDefaults()
        {
            SetName(out string NM, out string CNM, out string TT, out string CTT);
            DisplayName.SetDefault(NM + " Enchantment");
            DisplayName.AddTranslation(GameCulture.Chinese, CNM + "魔石");
            Tooltip.SetDefault(TT);
            Tooltip.AddTranslation(GameCulture.Chinese, CTT);
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.accessory = true;
            item.Calamity().customRarity = CalamityRarity.RareVariant;
            item.value = Item.sellPrice(0,5);
            SetEnchDefaults();
        }
        public virtual void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Basic";
            ChineseName = "基础";
            Tooltip = "Equip to get some Effects.";
            ChineseTooltip = "装备来获得一些效果。";
        }
        public virtual void SetEnchDefaults()
        {
        }
        public static void QuickModiLine(ref List<TooltipLine> tooltips, int line = 1, string text = "")
        {
            foreach (TooltipLine ttline in tooltips)
            {
                if (ttline.mod == "Terraria" && ttline.Name == "Tooltip"+line.ToString())
                {
                    ttline.text = text;
                }
            }
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            maxFallSpeed = 0;
        }
    }
}