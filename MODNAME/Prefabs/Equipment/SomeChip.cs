using System.Reflection;
using ChipLibrary;
using ChipLibrary.Handler;
using MODNAME.Mono;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    // https://github.com/Alexius25/ChipLibrary/blob/master/Docs/CreateChip.md
    internal static class SomeChip
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("SomeChip", unlockAtStart: false, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("SomeChipIcon"));

        internal static void Register()
        {
            var prefab = new CustomPrefab(Info);
            prefab.SetEquipment(EquipmentType.Chip);
            prefab.SetGameObject(new CloneTemplate(Info, TechType.ComputerChip));
            prefab.SetPdaGroupCategoryAfter(TechGroup.Personal, TechCategory.Equipment, TechType.AluminumOxide);
            prefab.Register();

            ChipHandler.RegisterChip<SomeChipBehaviour>(Info.TechType);
        }
    }
}