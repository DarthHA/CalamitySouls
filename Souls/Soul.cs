using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod;
using Microsoft.Xna.Framework;

namespace CalamitySouls.Souls
{
    public abstract class BasicSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            SetName(out string NM, out string CNM, out int ttAmt);
            DisplayName.SetDefault("Soul of the " + NM);
            DisplayName.AddTranslation(GameCulture.Chinese, CNM + "之魂");
            string tt = "0";
            for (int i = 1; i < ttAmt; i++)
            {
                tt += "\ni";
            }
            Tooltip.SetDefault(tt);
            SetSoulStaticDefaults();
        }
        public virtual void SetSoulStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.Calamity().customRarity = CalamityRarity.Rainbow;
            item.value = Item.sellPrice(5);
            SetSoulDefaults();
        }
        public virtual void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Basic";
            ChineseName = "基础";
            ttAmt = 1;
        }
        public virtual void SetSoulDefaults()
        {
        }
        public static void QuickModiLine(ref List<TooltipLine> tooltips, ref int line, string text = "", Color? color = null)
        {
            foreach (TooltipLine ttline in tooltips)
            {
                if (ttline.mod == "Terraria" && ttline.Name == "Tooltip" + line.ToString())
                {
                    ttline.text = text;
                    ttline.overrideColor = color;
                }
            }
            line++;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            maxFallSpeed = 0;
        }
    }
}