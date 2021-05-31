using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class BrimFrenzy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Brimflame Frenzy");
            Description.SetDefault("You are blessed by brimstone flames.\nYour attack deal 25% more damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "硫火暴乱");
            Description.AddTranslation(GameCulture.Chinese, "你使用了硫火的力量。\n你的攻击多造成25%伤害");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class BrimFrenzyCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Brimflame Cooldown");
            Description.SetDefault("You are banned by brimstone flames.");
            DisplayName.AddTranslation(GameCulture.Chinese, "硫火冷却");
            Description.AddTranslation(GameCulture.Chinese, "你不能使用硫火的力量。");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}
