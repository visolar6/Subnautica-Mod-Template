using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using static LootDistributionData;

namespace MODNAME.Prefabs.Resources
{
    internal static class Emerald
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("Emerald", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("EmeraldIcon"));

        internal static void Register()
        {
            var prefab = new CustomPrefab(Info);
            prefab.SetGameObject(ModifyPrefab);
            prefab.SetPdaGroupCategoryAfter(TechGroup.Resources, TechCategory.BasicMaterials, TechType.AluminumOxide);
            prefab.SetSpawns(new BiomeData[] {
                new BiomeData { biome = BiomeType.GhostTree_Ceiling, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_Grass, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_Ground, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_Ground_Lower, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_LedgeSide, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_LedgeTop, count = 5, probability = 0.5f },
                new BiomeData { biome = BiomeType.GhostTree_Wall, count = 5, probability = 0.5f },
            });
            prefab.Register();
        }

        private static GameObject ModifyPrefab()
        {
            var prefab = new GameObject("Emerald");
            foreach (var renderer in prefab.GetComponentsInChildren<Renderer>())
            {
                foreach (var material in renderer.materials)
                {
                    material.color = Color.green;
                }
            }
            return prefab;
        }
    }
}
