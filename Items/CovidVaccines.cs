using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Utilities;

namespace CalamitySouls.Items
{
    public class CovidVaccines : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chinese Covid-19 Vaccines");
            Tooltip.SetDefault("There's a meme in China:\n" +
                "Doctor: \"The Chinese Covid-19 Vaccine provides 74.8% protection.\"\n" +
                "Audience: \"Wait, only 75%? Isn't that too unreliable?'\n" +
                "Doctor: \"No, it's not what you think.\"\n" +
                "Doctor: \"74.8% means'80% chance prevent you from being infestated, 99% chance to prevent the virus from causing an illness, 100% prevent the illness from turning worse.\"\n" +
                "Doctor: \"To make it more apparent, that's like a permanent potion which provides you 80% chance to evade an attack, 99% damage resistance along with crit immunity.\"\n" +
                "Doctor: \"Do you still think it not reliable? Obviously it's more than OP!\"\n" +
                "And that's this accessory.\n" +
                "You have 80% chance to evade attack, reduce 99% damage taken and 100% immune to crit\n" +
                "Unobtainable, just for fun");
            DisplayName.AddTranslation(GameCulture.Chinese, "中国新冠疫苗");
            Tooltip.AddTranslation(GameCulture.Chinese, "医生：“中国新冠疫苗提供74.8%的保护。”\n" +
                "观众：“才75%？这么少的吗？”\n" +
                "医生：“这还少？80%不感染，感染99%不发病，发病100%不转重症。”\n" +
                "医生：“换句话说，80%闪避几率，加99%免伤还免疫暴击。”\n" +
                "医生：“这妥妥神器啊！”\n" +
                "所以就有了这个物品\n" +
                "80%几率闪避攻击，减少99%受到伤害并且100%不会被暴击");
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
        }
    }
}