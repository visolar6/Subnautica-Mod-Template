using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace MODNAME.Prefabs.Equipment
{
    internal static class PressureGloves
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("PressureGloves", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("PressureGlovesIcon"));

        public static void Register()
        {
            var prefab = new CustomPrefab(Info);
            var cloneTemplate = new CloneTemplate(Info, TechType.ReinforcedGloves);
            cloneTemplate.ModifyPrefab += gameObject =>
            {
                var renderer = gameObject.GetComponentInChildren<Renderer>();
                renderer.material.SetTexture("_MainTex", Plugin.AssetBundle.LoadAsset<Texture2D>("PressureGlovesMain"));
                renderer.material.SetTexture(ShaderPropertyID._SpecTex, Plugin.AssetBundle.LoadAsset<Texture2D>("PressureGlovesSpec"));
            };
            prefab.SetGameObject(cloneTemplate);
            prefab.SetEquipment(EquipmentType.Gloves);
            prefab.Register();
        }
    }
}
