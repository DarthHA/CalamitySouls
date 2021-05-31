using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamitySouls.Buffs;
using System.Collections.Generic;

namespace CalamitySouls
{
	public class CSPlayerDrawEffect : ModPlayer
	{
		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			layers.Add(FrozenOverLayer);
			layers.Add(WulfrumShieldLayer);
		}
		public static readonly PlayerLayer WulfrumShieldLayer = new PlayerLayer("CS", "Shield2", PlayerLayer.Skin, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			int index = -1;
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.owner == drawPlayer.whoAmI && projectile.type == ModContent.ProjectileType<Projectiles.WulfrumShield>())
				{
					index = i;
					break;
				}
			}
			if (index != -1)
			{
				Projectile projectile = Main.projectile[index];
				Texture2D texture = ModContent.GetTexture(projectile.modProjectile.Texture);
				Rectangle sourceRectangle = new Rectangle(0, 64 * projectile.frame, 62, 62);
				DrawData data = new DrawData(texture, projectile.Center - Main.screenPosition, sourceRectangle, Color.White * 0.5f,
					projectile.rotation, new Vector2(31, 31), 1.5f, SpriteEffects.None, 0);
				Main.playerDrawData.Add(data);
			}
		});
		public static readonly PlayerLayer FrozenOverLayer = new PlayerLayer("CS", "Frozen", PlayerLayer.Skin, delegate (PlayerDrawInfo drawInfo)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			if (drawPlayer.CS().Frozen)
			{
				Texture2D texture = CSTexture.Frozen;
				Vector2 position = drawPlayer.Center - Main.screenPosition;
				SpriteEffects spriteEffects = (drawPlayer.direction != -1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
				DrawData data = new DrawData(texture, position, null, new Color(150, 150, 150, 150), 0f,
					texture.Size() / 2, 1f, spriteEffects, 0);
				Main.playerDrawData.Add(data);
			}
		});
	}
}