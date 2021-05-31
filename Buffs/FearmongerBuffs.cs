using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class FearmongerArea : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frigid Area");
            DisplayName.AddTranslation(GameCulture.Chinese, "霜冻区域");
            Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class FearmongerAreaCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frigid Area Cooldown");
            DisplayName.AddTranslation(GameCulture.Chinese, "霜冻区域冷却");
            Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class FearmongerMarkCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Target Switch Cooldown");
            DisplayName.AddTranslation(GameCulture.Chinese, "目标切换冷却");
            Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}