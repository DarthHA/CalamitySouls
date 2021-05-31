using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class GodslayerAncientOtherworld : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Otherworldly");
            Description.SetDefault("With the buff your speed and acceleration is doubled, and when moving quickly you are immnue and can reflect projectiles");
            DisplayName.AddTranslation(GameCulture.Chinese, "异界");
            Description.AddTranslation(GameCulture.Chinese, "你的移速和加速度翻倍，高速移动时你处于无敌状态且能反弹弹幕");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}