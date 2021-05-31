using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class SilvaRecharge : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Silva Recharge");
            DisplayName.AddTranslation(GameCulture.Chinese, "林海充能");
            Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            longerExpertDebuff = false;
        }
    }
    public class SilvaInvulnerable : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Silva Invulnerable");
            DisplayName.AddTranslation(GameCulture.Chinese, "林海无敌");
            Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            longerExpertDebuff = false;
        }
    }
}