using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using static LootDistributionData;

namespace MODNAME.Prefabs.Resources
{
    // https://subnauticamodding.github.io/Nautilus/tutorials/prefabs-overview.html
    internal class SomeResource
    {
        internal PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("SomeResource", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("SomeResourceIcon"));

        internal void Register()
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

        internal GameObject ModifyPrefab()
        {
            var prefab = new GameObject("SomeResource");
            return prefab;
        }
    }
}