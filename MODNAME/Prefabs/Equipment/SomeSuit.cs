using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    internal static class SomeSuit
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("SomeSuit", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("SomeSuitIcon"));

        public static void Patch()
        {
            var prefab = new CustomPrefab(Info);
            var cloneTemplate = new CloneTemplate(Info, TechType.ReinforcedDiveSuit);
            cloneTemplate.ModifyPrefab += gameObject =>
            {
                var renderer = gameObject.GetComponentInChildren<Renderer>();
                renderer.materials[0].SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("SomeSuitMain"));
                renderer.materials[0].SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("SomeSuitSpec"));
                renderer.materials[1].SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("SomeSuitArmsMain"));
                renderer.materials[1].SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("SomeSuitArmsSpec"));
            };
            prefab.SetGameObject(cloneTemplate);
            prefab.SetUnlock(TechType.JellyPlant).WithAnalysisTech(null);
            prefab.SetEquipment(EquipmentType.Body);
            prefab.SetRecipe(new RecipeData(new Ingredient[]
            {
                new Ingredient(TechType.ReinforcedDiveSuit, 1),
                new Ingredient(TechType.JellyPlantSeed, 1),
            }))
                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithCraftingTime(6f);
            prefab.SetPdaGroupCategory(TechGroup.Workbench, TechCategory.Workbench);
            prefab.Register();
        }
    }
}
