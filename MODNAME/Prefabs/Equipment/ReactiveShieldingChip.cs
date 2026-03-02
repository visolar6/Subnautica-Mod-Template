using System.Reflection;
using ChipLibrary;
using ChipLibrary.Handler;
using MODNAME.Mono;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    internal static class ReactiveShieldingChip
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("ReactiveShieldingChip", unlockAtStart: false, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("ReactiveShieldingChipIcon"));

        internal static void Register()
        {
            var prefab = new CustomPrefab(Info);
            prefab.SetRecipe(new RecipeData(new Ingredient[]
            {
                new Ingredient(TechType.ComputerChip, 1),
                new Ingredient(TechType.PrecursorIonCrystal, 1),
                new Ingredient(TechType.Kyanite, 1),
            }))
                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithCraftingTime(4f);
            prefab.SetEquipment(EquipmentType.Chip);
            prefab.SetGameObject(new CloneTemplate(Info, TechType.ComputerChip));
            prefab.SetPdaGroupCategoryAfter(TechGroup.Personal, TechCategory.Equipment, TechType.AluminumOxide);
            prefab.Register();

            ChipHandler.RegisterChip<ReactiveShieldingChipBehaviour>(Info.TechType);
        }
    }
}
