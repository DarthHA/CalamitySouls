using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod;

namespace CalamitySouls.Force
{
    public abstract class BasicForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            SetName(out string NM, out string CNM, out int ttAmt);
            DisplayName.SetDefault("Force of " + NM);
            DisplayName.AddTranslation(GameCulture.Chinese, CNM + "之力");
            string tt = "0";
            for (int i = 1; i < ttAmt; i++)
            {
                tt += "\ni";
            }
            Tooltip.SetDefault(tt);
        }
        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 50;
            item.accessory = true;
            item.Calamity().customRarity = CalamityRarity.RareVariant;
            item.value = Item.sellPrice(1, 50);
            SetForceDefaults();
        }
        public virtual void SetName(out string DisplayName, out string ChineseName, out int ttAmt)
        {
            DisplayName = "Basic";
            ChineseName = "基础";
            ttAmt = 1;
        }
        public virtual void SetForceDefaults()
        {
        }
        public static void QuickModiLine(ref List<TooltipLine> tooltips,ref int line, string text = "")
        {
            foreach (TooltipLine ttline in tooltips)
            {
                if (ttline.mod == "Terraria" && ttline.Name == "Tooltip" + line.ToString())
                {
                    ttline.text = text;
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