using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class UmbraphileUndetected : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Undetected");
            Description.SetDefault("Creature become friendly to you");
            DisplayName.AddTranslation(GameCulture.Chinese, "不可检测");
            Description.AddTranslation(GameCulture.Chinese, "所有生物对你友好");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}