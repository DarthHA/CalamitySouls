using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CalamitySouls.Buffs
{
    public class GodslayerCrit : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Godslayer Crit");
            Description.SetDefault("Your attack has 50% chance to crit");
            DisplayName.AddTranslation(GameCulture.Chinese, "弑神者暴击");
            Description.AddTranslation(GameCulture.Chinese, "你的攻击有50%几率暴击");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class GodslayerDefense : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Godslayer Defense");
            Description.SetDefault("+80 defense");
            DisplayName.AddTranslation(GameCulture.Chinese, "弑神者防御");
            Description.AddTranslation(GameCulture.Chinese, "+80防御");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class GodslayerResource : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Godslayer Resource");
            Description.SetDefault("Rapidly regen life and mana");
            DisplayName.AddTranslation(GameCulture.Chinese, "弑神者资源");
            Description.AddTranslation(GameCulture.Chinese, "快速回复生命和魔力");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class GodslayerSpeed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Godslayer Speed");
            Description.SetDefault("+50% weapon fire rate");
            DisplayName.AddTranslation(GameCulture.Chinese, "弑神者速度");
            Description.AddTranslation(GameCulture.Chinese, "+50%武器使用速度");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
    public class GodslayerSplit : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Godslayer Velocity");
            Description.SetDefault("Your projectiles become incredibly fast");
            DisplayName.AddTranslation(GameCulture.Chinese, "弑神者弹速");
            Description.AddTranslation(GameCulture.Chinese, "你的弹幕变得超级快");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
    }
}
