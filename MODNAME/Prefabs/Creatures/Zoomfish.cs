using System.Collections;
using System.Reflection;
using ECCLibrary;
using ECCLibrary.Data;
using Nautilus.Assets;
using UnityEngine;

namespace MODNAME.Prefabs.Creatures
{
    internal static class Zoomfish
    {
        internal static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("Zoomfish", unlockAtStart: true, techTypeOwner: Assembly.GetExecutingAssembly())
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(Plugin.AssetBundle.LoadAsset<Sprite>("ZoomfishIcon"));

        internal static void Register()
        {
            var asset = new ZoomfishAsset(Info);
            asset.Register();
        }
    }

    internal class ZoomfishAsset : CreatureAsset
    {
        public ZoomfishAsset(PrefabInfo prefabInfo) : base(prefabInfo)
        {
            CreatureDataUtils.AddCreaturePDAEncyclopediaEntry(this, "Lifeforms/Fauna/SmallHerbivores", null, null, 3, Plugin.AssetBundle.LoadAsset<Texture2D>("ZoomfishImage"), Plugin.AssetBundle.LoadAsset<Sprite>("ZoomfishPopupImage"));
        }

        protected override CreatureTemplate CreateTemplate()
        {
            var template = new CreatureTemplate(TechType.Peeper, 100);
            CreatureTemplateUtils.SetPreyEssentials(template, 8f, null, null);

            return template;
        }

        protected override IEnumerator ModifyPrefab(GameObject prefab, CreatureComponents components)
        {
            foreach (var renderer in prefab.GetComponentsInChildren<Renderer>())
            {
                foreach (var material in renderer.materials)
                {
                    material.color = Color.cyan;
                }
            }

            yield break;
        }
    }
}
