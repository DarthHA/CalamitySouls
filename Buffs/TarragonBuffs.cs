using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamitySouls;

namespace CalamitySouls.Buffs
{
    public class TarragonCloak : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tarragon Cloak");
            Description.SetDefault("Enermy damage is reduced");
            DisplayName.AddTranslation(GameCulture.Chinese, "龙蒿保护");
            Description.AddTranslation(GameCulture.Chinese, "敌人伤害减少");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.5f;
        }
    }
    public class TarragonImmunity : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tarragon Immunity");
            Description.SetDefault("You are immune");
            DisplayName.AddTranslation(GameCulture.Chinese, "龙蒿无敌");
            Description.AddTranslation(GameCulture.Chinese, "你无敌了");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.CS().ImmunityTime < player.buffTime[buffIndex]) player.CS().ImmunityTime = player.buffTime[buffIndex];
        }
    }
}