using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace MODNAME.Prefabs.Modules
{
    internal static class CyclopsWarpModule
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("CyclopsWarpModule", unlockAtStart: false, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("CyclopsWarpModuleIcon"));

        internal static void Register()
        {
            var prefab = new CustomPrefab(Info);
            prefab.SetGameObject(new CloneTemplate(Info, TechType.CyclopsHullModule1));
            prefab.SetPdaGroupCategoryAfter(TechGroup.VehicleUpgrades, TechCategory.CyclopsUpgrades, TechType.CyclopsHullModule1);
            prefab.Register();
        }
    }
}
