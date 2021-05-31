using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class AuricReviveCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Auric Revive Cooldown");
            Description.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "金源复活冷却");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}