using Microsoft.Xna.Framework.Graphics;

namespace CalamitySouls
{
    public static class CSTexture
    {
        public static Texture2D 寒元
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/寒元"); }
            set { }
        }
        public static Texture2D Frozen
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/Frozen"); }
            set { }
        }
        public static Texture2D FearmongerArea
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/FearmongerArea"); }
            set { }
        }
        public static Texture2D FearmongerMark
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/FearmongerMark"); }
            set { }
        }
        public static Texture2D Shield
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/Shield"); }
            set { }
        }
        public static Texture2D Circle
        {
            get { return CalamitySouls.Instance.GetTexture("Extras/Circle"); }
            set { }
        }
    }
}