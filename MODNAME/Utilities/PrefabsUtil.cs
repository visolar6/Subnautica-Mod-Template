using MODNAME.Prefabs.Creatures;
using MODNAME.Prefabs.Equipment;
using MODNAME.Prefabs.Modules;
using MODNAME.Prefabs.Resources;

namespace MODNAME.Utilities
{
    public static class PrefabsUtil
    {
        public static void RegisterAllPrefabs()
        {
            // Buildables

            // Creatures
            Zoomfish.Register();

            // Equipment
            PressureGloves.Register();
            PressureSuit.Register();
            ReactiveShieldingChip.Register();

            // Modules
            CyclopsWarpModule.Register();

            // Resources
            Emerald.Register();

            // Vehicles
        }
    }
}
