using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class Frozen : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frozen");
            Description.SetDefault("You are frozen.\n+15 defense, cannot move");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰冻");
            Description.AddTranslation(GameCulture.Chinese, "你被冰冻了\n15防御，无法移动");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.CS().Frozen = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.CS().Frozen = true;
        }
    }
}