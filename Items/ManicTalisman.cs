using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalamitySouls.Items
{
  public  class ManicTalisman:ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Manic Talisman");
            Tooltip.SetDefault(
                "Activates Manic Mode, which makes NPC's ai speed * 210%, reduce NPC's damage taken by 30% , and you take 50% more damage\n" +
                "Your adrenaline boosts 50% more damage and your defense blocks 0.5 damage instead of 0.75\n" + 
                "NPC AI boost, damage reduction is cancelled when no boss is alive before any boss is taken down\n" + 
                "Can be used in Revenge Mode only");
            DisplayName.AddTranslation(GameCulture.Chinese, "欠抽护符");
            Tooltip.AddTranslation(GameCulture.Chinese, 
                "激活欠抽模式，让NPC的ai速度乘210%，减少30%NPC受到伤害，你多受到50%伤害\n" +
                "你的肾上腺素伤害增加50%，你的防御阻挡0.5伤害而非0.75\n" + 
                "击败任意boss前前且没有boss存在时，NPC的AI速度和免伤增幅被取消\n" + 
                "只能在复仇模式下使用");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.useAnimation = item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item120;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach(TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = Color.SkyBlue;
                }
            }
        }
        public override bool CanUseItem(Player player) => CalamityMod.World.CalamityWorld.revenge;
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation == player.itemAnimationMax-1) 
            {
                string text = CSUtils.GameCultureChinese ? "欠抽模式关闭" : "Manic Mode deactivated.";
                if (!CSWorld.HyperMode) text = CSUtils.GameCultureChinese ? "欠抽模式开启" : "Manic Mode activated.";
                if (!CSUtils.AnyBossAlive) CSWorld.HyperMode = !CSWorld.HyperMode;
                else text = CSUtils.GameCultureChinese ? "Boss战中不能改变模式" : "You cannot switch the mode during a boss fight";
                Main.NewText(text, Color.SkyBlue);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
