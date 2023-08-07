using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace GoldenMod
{
    public class GoldenProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (GoldenConfig.Instance.GoldenProjectiles)
            {
                GoldenMod.AddShaderFromItemID(Main.spriteBatch, GoldenMod.DyeID);
            }
            return base.PreDraw(projectile, ref lightColor);
        }
        public override void PostDraw(Projectile projectile, Color lightColor)
        {
            if (GoldenConfig.Instance.GoldenProjectiles)
            {
                GoldenMod.AddShaderFromItemID(Main.spriteBatch);
            }
        }
    }
}
