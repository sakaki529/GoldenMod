using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace GoldenMod
{
    public class GoldenItem : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        /*public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (SinsItem.AddShaderOnNameFromItemID(Item, line, GoldenMod.DyeID))
                return false;
            return base.PreDrawTooltipLine(item, line, ref yOffset);
        }
        public override void PostDrawTooltipLine(Item item, DrawableTooltipLine line)
        {
            if (GoldenConfig.Instance.GoldenItemNames)
            {
                AddShaderOnNameFromItemId(item, line);
            }
        }
        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (GoldenConfig.Instance.GoldenItemsInInventory)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch, GoldenMod.DyeID);
            }
            return base.PreDrawInInventory(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }
        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (GoldenConfig.Instance.GoldenItemsInInventory)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch);
            }
        }*/
        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            if (GoldenConfig.Instance.GoldenItemsInWorld)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch, GoldenMod.DyeID);
            }
            return base.PreDrawInWorld(item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }
        public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (GoldenConfig.Instance.GoldenItemsInWorld)
            {
                GoldenMod.AddShaderFromItemID(spriteBatch);
            }
        }
        public static void AddShaderOnNameFromItemId(Item item, DrawableTooltipLine line, int itemID = 0)
        {
            if (itemID == 0)
            {
                AddShaderOnName(item, line, null);
                return;
            }
            AddShaderOnName(item, line, GameShaders.Armor.GetShaderFromItemId(itemID));
        }
        public static bool AddShaderOnName(Item item, DrawableTooltipLine line, ArmorShaderData shaderData)
        {
            if (line.Mod == "Terraria" && line.Name == "ItemName")
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.UIScaleMatrix);
                Vector2 itemNameV = ChatManager.GetStringSize(line.Font, item.Name, line.BaseScale, -1f);
                shaderData.Shader.Parameters["uImageSize0"].SetValue(new Vector2(itemNameV.X, itemNameV.Y));
                shaderData.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0f, 0f, itemNameV.X, itemNameV.Y));
                shaderData.Apply(null, null);
                Utils.DrawBorderString(Main.spriteBatch, line.Text, new Vector2(line.X, line.Y), Color.White);
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.UIScaleMatrix);
                return true;
            }
            return false;
        }
    }
}
