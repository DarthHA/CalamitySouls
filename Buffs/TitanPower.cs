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
            Description.SetDefault("POWER!\n+22% mult damage\nReduce weapon fire rate and minion slots by 35%");
            DisplayName.AddTranslation(GameCulture.Chinese, "泰坦之力");
            Description.AddTranslation(GameCulture.Chinese, "抛瓦！\n+22%敌人易伤\n减少35%武器使用速度和召唤栏。");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}
