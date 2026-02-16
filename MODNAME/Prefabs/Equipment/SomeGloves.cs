using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    internal static class SomeGloves
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("SomeGloves", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("SomeGlovesIcon"));

        public static void Patch()
        {
            var prefab = new CustomPrefab(Info);
            var cloneTemplate = new CloneTemplate(Info, TechType.ReinforcedGloves);
            cloneTemplate.ModifyPrefab += gameObject =>
            {
                var renderer = gameObject.GetComponentInChildren<Renderer>();
                renderer.material.SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("SomeGlovesMain"));
                renderer.material.SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("SomeGlovesSpec"));
            };
            prefab.SetGameObject(cloneTemplate);
            prefab.SetEquipment(EquipmentType.Gloves);
            prefab.Register();
        }
    }
}