using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class TitanPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Titan Power");
            Description.SetDefault("POWER!\n+100% damage, +20% mult damage and +500% knockback\nHalves weapon fire rate and minion slots");
            DisplayName.AddTranslation(GameCulture.Chinese, "泰坦之力");
            Description.AddTranslation(GameCulture.Chinese, "抛瓦！\n+100%伤害, +20%敌人易伤和+500%击退\n减半武器使用速度和召唤栏。");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}
