using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class DaedalusEvadeCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Daedalus Evade Cooldown");
            Description.SetDefault("Your daedalus evade is recharging");
            DisplayName.AddTranslation(GameCulture.Chinese, "代达罗斯闪避冷却");
            Description.AddTranslation(GameCulture.Chinese, "你的代达罗斯闪避正在冷却");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            longerExpertDebuff = false;
        }
    }
}