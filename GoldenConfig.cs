using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace GoldenMod
{
    [Label("Config")]
    class GoldenConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static GoldenConfig Instance;
        public override void OnLoaded()
        {
            Instance = this;
        }
        [DefaultValue(true)]
        [Label("Golden Items in world")]
        public bool GoldenItemsInWorld { get; set; }

        /*[DefaultValue(true)]
        [Label("Golden Items in inventory")]
        public bool GoldenItemsInInventory { get; set; }

        [DefaultValue(true)]
        [Label("Golden Item names")]
        public bool GoldenItemNames { get; set; }*/

        [DefaultValue(true)]
        [Label("Golden Projectiles")]
        public bool GoldenProjectiles { get; set; }

        [DefaultValue(true)]
        [Label("Golden NPCs")]
        public bool GoldenNPCs { get; set; }

        [DefaultValue(true)]
        [Label("Golden Tiles")]
        public bool GoldenTiles { get; set; }

        [DefaultValue(true)]
        [Label("Golden Walls")]
        public bool GoldenWalls { get; set; }

        [DefaultValue(true)]
        [Label("Golden Dusts")]
        public bool GoldenDusts { get; set; }
    }
}
