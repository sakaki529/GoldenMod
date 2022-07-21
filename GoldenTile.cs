using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace GoldenMod
{
    public class GoldenTile : GlobalTile
    {
        public override bool PreDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            if (GoldenConfig.Instance.GoldenTiles)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch, GoldenMod.DyeID);
            }
            return base.PreDraw(i, j, type, spriteBatch);
        }
        public override void PostDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            if (GoldenConfig.Instance.GoldenTiles)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch);
            }
        }
    }
}
