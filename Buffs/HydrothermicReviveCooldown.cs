using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class HydrothermicReviveCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hydrothermic Revive Recharge");
            Description.SetDefault("Your daedalus evade is recharging");
            DisplayName.AddTranslation(GameCulture.Chinese, "渊泉重生充能");
            Description.AddTranslation(GameCulture.Chinese, "你的渊泉重生正在充能");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}