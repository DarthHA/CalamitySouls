using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using CalamitySouls.Items;

namespace CalamitySouls.Ench
{
    public class EnchUmbraphile : BasicEnch
    {
        public override void SetName(out string DisplayName, out string ChineseName, out string Tooltip, out string ChineseTooltip)
        {
            DisplayName = "Umbraphile";
            ChineseName = "日影";
            Tooltip = ChineseTooltip = "0\n1\n2\n3";
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = "ED7112";
            if (CSUtils.GameCultureChinese)
            {
                QuickModiLine(ref tooltips, 0, "「黑蚀之日正在等待。」");
                QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.UmbraphileRegalia>(), color) +
                    "攻击有几率产生爆炸，日影药水始终有最大化效果");
                QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                    "+15%武器使用速度，不使用物品一段时间后获得不可检测增益，在没有boss存活时使所有生物变得友好");
                QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                    "这个增益在你击中敌人时失效，但会大大增加那次攻击的伤害");
                return;
            }
            QuickModiLine(ref tooltips, 0, "「The dark sun awaits.」");
            QuickModiLine(ref tooltips, 1, CSUtils.GetModItemText(ModContent.ItemType<CalamityMod.Items.Armor.UmbraphileRegalia>(), color) +
                "Attacks have a chance to create explosions on hit, penumbra potions always build stealth at max effectiveness");
            QuickModiLine(ref tooltips, 2, CSUtils.GetModItemText(item.type, color) +
                "+15% weapon fire rate, after a period of not using items you grant Undetected buff, which makes all creatures friendly while no boss is alive");
            QuickModiLine(ref tooltips, 3, CSUtils.GetModItemText(item.type, color) +
                "The buff breaks when you hit any creature, but greatly boosts the damage that hit deals");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.CS().EnchUmbraphile = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.UmbraphileHood>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.UmbraphileRegalia>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Armor.UmbraphileBoots>());
            recipe.AddIngredient(ModContent.ItemType<PeerlessWindGod>());
            recipe.AddIngredient(ModContent.ItemType<ImpurityWithinOnesBody>());
            recipe.AddIngredient(ModContent.ItemType<ReleaseoftheId>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.DefectiveSphere>());
            recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Weapons.Rogue.FantasyTalisman>(),1500);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}