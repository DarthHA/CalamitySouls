using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Utilities;

namespace CalamitySouls.Items
{
    public class ChineseCovidVaccines : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chinese Covid-19 Vaccines");
            Tooltip.SetDefault("You have 80% chance to evade damage, reduce 99% damage taken and 100% immune to crit");
            DisplayName.AddTranslation(GameCulture.Chinese, "中国新冠疫苗");
            Tooltip.AddTranslation(GameCulture.Chinese, "80%几率闪避攻击，减少99%受到伤害并且100%不会被暴击");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }
        public override bool? PrefixChance(int pre, UnifiedRandom rand) => new bool?(false);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().cCVaccines = true;
            //for (int i = 0; i < player.buffImmune.Length; i++)
            //{
            //    if (Main.debuff[i]) player.buffImmune[i] = true;
            //}
        }
    }
}