using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MODNAME.Prefabs.Equipment;
using Nautilus.Handlers;
using Nautilus.Utility;
using UnityEngine;

namespace MODNAME
{
    [BepInPlugin(GUID, Name, Version)]
    [BepInDependency(ChipLibrary.PluginInfo.PLUGIN_GUID)]
    internal class Plugin : BaseUnityPlugin
    {
        internal const string GUID = "com.MODAUTHOR.MODID";

        internal const string Name = "MODNAME";

        internal const string Version = "0.1.0";

        internal static ManualLogSource Log;

        internal static Options Options { get; private set; }

        internal static AssetBundle AssetBundle { get; private set; }

        private readonly Harmony _harmony = new Harmony(GUID);

        private void Awake()
        {
            Log = Logger;
            Options = OptionsPanelHandler.RegisterModOptions<Options>();
            AssetBundle = AssetBundleLoadingUtils.LoadFromAssetsFolder(Assembly.GetExecutingAssembly(), "MODID");
            LanguageHandler.RegisterLocalizationFolder("Localization");
        }

        private void Start()
        {
            _harmony.PatchAll();
            RegisterPrefabs();
        }

        private void RegisterPrefabs()
        {
            SomeChip.Register();
        }
    }
}
