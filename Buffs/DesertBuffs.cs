using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamitySouls;
using Microsoft.Xna.Framework;

namespace CalamitySouls.Buffs
{
    public class DesertDodgeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sandstorm Dodge");
            Description.SetDefault("You are holding the power of sandstorm\nDodge any damage once");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙暴闪避");
            Description.AddTranslation(GameCulture.Chinese, "你掌握着沙尘暴的威力\n闪避一次任意伤害");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.CS().DesertDodgeBuff = true;
        }
    }
    public class DesertDodgeCD : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sandstorm Dodge Cooldown");
            Description.SetDefault("You are banned by sandstorm dodge by now");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙暴闪避冷却");
            Description.AddTranslation(GameCulture.Chinese, "你被暂时禁止使用沙暴的能力");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.CS().DesertDodgeCD = true;
            player.CS().DesertDodgeTimer = 0;
        }
    }
}
