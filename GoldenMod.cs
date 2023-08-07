using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace GoldenMod
{
	public class GoldenMod : Mod
	{
        //homepage = https://sakaki529.github.io/golden.github.io/
        internal static GoldenMod Instance;
        public const int DyeID = ItemID.ReflectiveGoldDye;
        public GoldenMod()
        {
            Instance = this;
        }
        public override void Unload()
        {
            Instance = null;
            GoldenConfig.Instance = null;
        }
        public static int GetShaderIDFromItemID(int itemID)
        {
            return GameShaders.Armor.GetShaderIdFromItemId(itemID);
        }
        public static void AddShaderFromItemID(SpriteBatch spriteBatch, int itemID = 0)
        {
            AddShader(spriteBatch, GameShaders.Armor.GetShaderIdFromItemId(itemID));
        }
        public static void AddShader(SpriteBatch spriteBatch, int id = 0)
        {
            if (id > 0)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
                GameShaders.Armor.ApplySecondary(id, Main.player[Main.myPlayer], null);
                return;
            }
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
        }
    }
    public class GoldenSystem : ModSystem
    {
        public override void PreUpdateTime()
        {
            if (GoldenConfig.Instance.GoldenDusts)
            {
                for (int i = 0; i < Main.dust.Length; i++)
                {
                    Main.dust[i].shader = GameShaders.Armor.GetSecondaryShader(GoldenMod.GetShaderIDFromItemID(GoldenMod.DyeID), Main.LocalPlayer);
                }
            }
        }
    }
}