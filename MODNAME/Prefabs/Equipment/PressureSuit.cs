using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    internal static class PressureSuit
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("PressureSuit", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("PressureSuitIcon"));

        internal static void Register()
        {
            var prefab = new CustomPrefab(Info);
            var cloneTemplate = new CloneTemplate(Info, TechType.ReinforcedDiveSuit);
            cloneTemplate.ModifyPrefab += ModifyPrefab;
            prefab.SetGameObject(cloneTemplate);
            prefab.SetUnlock(TechType.JellyPlant).WithAnalysisTech(null);
            prefab.SetEquipment(EquipmentType.Body);
            prefab.SetRecipe(new RecipeData(new Ingredient[]
            {
                new Ingredient(TechType.ReinforcedDiveSuit, 1),
                new Ingredient(TechType.PlasteelIngot, 1),
                new Ingredient(TechType.Nickel, 1),
                new Ingredient(TechType.Kyanite, 2),
            }))
                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithCraftingTime(6f);
            prefab.SetPdaGroupCategory(TechGroup.Workbench, TechCategory.Workbench);
            prefab.Register();
        }

        private static void ModifyPrefab(GameObject gameObject)
        {
            var renderer = gameObject.GetComponentInChildren<Renderer>();
            renderer.materials[0].SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("PressureSuitMain"));
            renderer.materials[0].SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("PressureSuitSpec"));
            renderer.materials[1].SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("PressureSuitArmsMain"));
            renderer.materials[1].SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("PressureSuitArmsSpec"));
        }
    }
}
