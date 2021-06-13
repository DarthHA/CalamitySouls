using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using CalamityMod.World;
using System.Collections.Generic;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace CalamitySouls
{
    public class CSNPC : GlobalNPC
    {
        private List<int> notDeadBossList => new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMindP2>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverHeadNaked>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverBodyNaked>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverTailNaked>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsHeadS>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsBodyS>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsTailS>(),
            ModContent.NPCType<CalamityMod.NPCs.Calamitas.CalamitasRun3>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusHeadSpectral>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusBodySpectral>(),
            ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusTailSpectral>()
        };
        private List<int> notDeadBossList2 => new List<int>
        {
            ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMind>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>(),
            ModContent.NPCType<CalamityMod.NPCs.Leviathan.Siren>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverHead>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverBody>(),
            ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverTail>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsHead>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsBody>(),
            ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsTail>(),
            ModContent.NPCType<CalamityMod.NPCs.Calamitas.Calamitas>(),
        };
        public override void SetDefaults(NPC npc)
        {
            if (npc.boss && CalamityWorld.revenge && !notDeadBossList.Contains(npc.type) && npc.Calamity().newAI[0] != 0f
                && Main.netMode != NetmodeID.Server && !Main.LocalPlayer.dead && Main.LocalPlayer.active)
            {
                Main.LocalPlayer.CS().PlagueReaperHasAdrenalineCurrently = false;
            }
        }
        public override void ResetEffects(NPC npc)
        {
            Frozen = false;
            if (CSWorld.HyperMode && !CSUtils.ManicModeNerf) ExtraUpdate = CSUtils.TransFloatToInt(1.1f);
        }
        public override void PostAI(NPC npc)
        {
            if (CSWorld.HyperMode)
            {
                if (npc.type == NPCID.CultistBoss)
                {
                    if (npc.target >= 0 && npc.target < 255)
                    {
                        Player player = Main.player[npc.target];
                        if (player.active && !player.dead)
                        {
                            npc.Center = Vector2.Lerp(npc.Center, player.Center - Vector2.UnitY * 300f, 0.01f);
                        }
                    }
                }
                if (npc.type == NPCID.CultistBossClone)
                {
                    if (npc.target >= 0 && npc.target < 255)
                    {
                        Player player = Main.player[npc.target];
                        if (player.active && !player.dead)
                        {
                            npc.Center = Vector2.Lerp(npc.Center, player.Center - new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(450, 601)), 0.01f);
                        }
                    }
                }
            }
            if (ExtraUpdate > 0)
            {
                ExtraUpdate--;
                if (npc.active)
                {
                if (NPCLoader.PreAI(npc))
                {
                    NPCLoader.AI(npc);
                    NPCLoader.PostAI(npc);
                }
                }
            }
            if (Frozen)
            {
                Lighting.AddLight(npc.Center, new Vector3(1, 1, 1));
                if (!CSUtils.AnyBossAlive)
                {
                    npc.Center -= npc.velocity;
                    npc.velocity.X = 0;
                    npc.velocity.Y += 0.05f;
                    if (npc.velocity.Y > 15f)
                    {
                        npc.velocity.Y = 15f;
                    }
                }
            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.boss && CalamityWorld.revenge && !notDeadBossList2.Contains(npc.type)
                && Main.netMode != NetmodeID.Server && !Main.player[Main.myPlayer].dead && Main.player[Main.myPlayer].active)
            {
                Main.LocalPlayer.CS().PlagueReaperHasAdrenalineCurrently = false;
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (CSWorld.HyperMode && CSUtils.ManicModeNerf)
            {
                spawnRate *= 2;
                maxSpawns /= 2;
            }
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (CSWorld.HyperMode && !CSUtils.ManicModeNerf) 
            {
                damage *= 0.7f;
            }
            return true;
        }
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.LocalPlayer.CS().PrismaticTrail && !npc.friendly && npc.active)
            {
                Texture2D prism = Main.itemTexture[ItemType<Ench.EnchPrismatic>()];
                Rectangle sRect = new Rectangle(14, 8, 4, 2);
                Vector2 origin = new Vector2(0, 1);
                Rectangle dRect = new Rectangle((int)(npc.Center - Main.screenPosition).X, (int)(npc.Center - Main.screenPosition).Y,
                    (int)(npc.velocity.Length() * npc.timeLeft), 2);
                spriteBatch.Draw(prism, dRect, sRect, Color.White * 0.5f, npc.velocity.ToRotation(), origin, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Frozen)
            {
                Texture2D texture = CSTexture.Frozen;
                float length = System.Math.Max(npc.width, npc.height);
                Vector2 position = npc.position - Main.screenPosition - new Vector2(length) * 0.25f;
                Rectangle desRec = new Rectangle((int)position.X, (int)position.Y, (int)(length * 1.5f), (int)(length * 1.5f));
                spriteBatch.Draw(texture, desRec, new Color(150, 150, 150, 150));
            }
            if (npc.whoAmI == Main.LocalPlayer.CS().FearmongerMark)
            {
                spriteBatch.Draw(CSTexture.FearmongerMark, npc.Center - Vector2.UnitY * (npc.height / 2f + 14f) - Main.screenPosition, null, drawColor,
                    0f, CSTexture.FearmongerMark.Size() / 2f, 1f, SpriteEffects.None, 0f);
            }
        }
        public override bool InstancePerEntity => true;
        public bool Frozen;
        public int ExtraUpdate = 0;
    }
}