# Subnautica Mod Development Instructions

1. Run `make eject` or `python eject.py` before editing files.
2. After ejection, the `MODNAME` folder and references will be renamed to your chosen mod name. Use this new name for all code and assets.
3. Use .NET Framework 4.7.2 or newer to build the mod project.
4. Build asset bundles with Unity 2019.4.41f2 for compatibility.
5. Organize scripts by type: for example, Harmony patches in `Patches/`, MonoBehaviours in `Mono/`, prefabs in `Prefabs/`. Other folders may be used as needed for organization.
6. Test your mod in-game after building. Automated tests are not supported.
7. The Subnautica game directory DLLs provide almost every package you will need. Only add external dependencies if they are common Subnautica modding libraries (such as BepInEx, Nautilus, or SuitLib) and are distributed on modding sites like NexusMods. Avoid adding arbitrary NuGet packages or libraries, as this complicates installation for users.
8. Keep the file structure clean and modular for maintainability.
