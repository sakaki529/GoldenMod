using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace GoldenMod
{
    class GoldenConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static GoldenConfig Instance;
        public override void OnLoaded()
        {
            Instance = this;
        }
        [DefaultValue(true)]
        public bool GoldenItemsInWorld { get; set; }

        // TODO
        /*[DefaultValue(true)]
        [Label("Golden Items in inventory")]
        public bool GoldenItemsInInventory { get; set; }

        [DefaultValue(true)]
        [Label("Golden Item names")]
        public bool GoldenItemNames { get; set; }*/

        [DefaultValue(true)]
        public bool GoldenProjectiles { get; set; }

        [DefaultValue(true)]
        public bool GoldenNPCs { get; set; }

        [DefaultValue(true)]
        public bool GoldenTiles { get; set; }

        [DefaultValue(false)]
        public bool GoldenWalls { get; set; }

        [DefaultValue(true)]
        public bool GoldenDusts { get; set; }
    }
}
