using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace GoldenMod
{
    public class GoldenNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (GoldenConfig.Instance.GoldenNPCs && !npc.IsABestiaryIconDummy)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch, GoldenMod.DyeID);
            }
            return base.PreDraw(npc, spriteBatch, screenPos, drawColor);
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (GoldenConfig.Instance.GoldenNPCs && !npc.IsABestiaryIconDummy)
            {
                GoldenMod.AddShader(spriteBatch);
            }
        }
    }
}
