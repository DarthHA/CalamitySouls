using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamitySouls.Buffs;
using System.Collections.Generic;
using Terraria.ModLoader.IO;

namespace CalamitySouls
{
    public class CSWorld : ModWorld
    {
        public override void Initialize()
        {
            HyperMode = false;
        }
        public override void PreUpdate()
        {
            if (!CalamityMod.World.CalamityWorld.revenge && HyperMode) 
            {
                HyperMode = false;
                string text = CSUtils.GameCultureChinese ? "欠抽模式关闭" : "Manic Mode deactivated.";
                Main.NewText(text, Color.SkyBlue);
            }
        }
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound
            {
                { "HyperMode", HyperMode }
            };
            return tag;
        }
        public override void Load(TagCompound tag)
        {
            HyperMode = tag.GetBool("HyperMode");
        }
        public static bool HyperMode;
    }
}