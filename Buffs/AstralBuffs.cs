using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class AstralDivision : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astral Division");
            Description.SetDefault("You are divided by two");
            DisplayName.AddTranslation(GameCulture.Chinese, "幻星分裂");
            Description.AddTranslation(GameCulture.Chinese, "你被一分为二");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            longerExpertDebuff = false;
        }
    }
    public class AstralImmunity : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astral Immunity");
            Description.SetDefault("You are invulnerable");
            DisplayName.AddTranslation(GameCulture.Chinese, "幻星无敌");
            Description.AddTranslation(GameCulture.Chinese, "你不会受到伤害");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            longerExpertDebuff = false;
        }
    }
}