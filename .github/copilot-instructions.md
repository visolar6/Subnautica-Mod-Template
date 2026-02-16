
# Copilot Instructions for Subnautica Mod Template

## Project Overview
This is a template for Subnautica mod development, designed to be ejected and customized for new mods. It provides a clean, modular structure and example files for common modding tasks.

## Key Architecture & Structure
- The root `MODNAME/` directory contains all mod source code and assets.
- Major subfolders:
  - `Assets/`: Asset bundles, images, audio, etc.
  - `Config/`: Persistent config/state files.
  - `Localization/`: Translation/localization resources (e.g., `English.json`).
  - `Mono/`: Unity MonoBehaviour scripts for custom game components.
  - `Patches/`: Harmony patch classes for modifying game methods.
  - `Prefabs/`: Example prefab scripts, organized by type (e.g., `Equipment/`, `Resources/`).
    - More prefab categories can be added as needed (e.g., `Decorations/`).
  - `Utilities/`: Helper and utility classes.
- Example files in each folder demonstrate best practices for that feature.

## Developer Workflows
- **Eject Before Development:**
  - Run `make eject` or `python eject.py` before making any changes. This personalizes the template and removes placeholders.
- **Build:**
  - Use .NET 4.7.2+ to build the mod (`MODNAME.csproj`).
  - Asset bundles should be built with Unity 2019.4.41f2 for compatibility.
- **Testing:**
  - No built-in test framework; test mods in-game after building.

## Project Conventions
- Folder and file naming follows clear, descriptive patterns (e.g., `SomePatch.cs`, `SomeBuildable.cs`).
- Harmony patches are placed in `Patches/` and use clear class/method names.
- Prefabs are organized by type for clarity and scalability.
- Asset bundles and localization files follow consistent naming for easy reference.
- All code is C# targeting .NET Framework 4.7.2.

## Integration Points
- **OpenMods & NexusMods:**
  - Automated workflows for refreshing mod listings and uploading new releases.
  - Secrets required for API integration: `OPENMODS_API_KEY`, `OPENMODS_MOD_ID`, `NEXUSMODS_API_KEY`, `NEXUSMODS_MOD_ID`.
- **Unity:**
  - Asset bundles must be built with the specified Unity version for Subnautica compatibility.
- **Nautilus API:**
  - Commonly used for mod/game integration (see [Nautilus API Docs](https://subnauticamodding.github.io/Nautilus/index.html)).

## Special Notes

- Automated testing is very limited for Subnautica mods, as most features depend on UnityEngine and in-game behavior that cannot be unit-tested outside the game. Manual in-game testing is the standard workflow.
- Example files currently use placeholder names (e.g., `SomePatch.cs`, `SomeTool.cs`). These may be updated in the future to use more realistic examples (e.g., `Emerald.cs` for a resource), but serve as clear references for now.
- Do not edit or add files before running the eject script.
  - You can verify if the eject script has run by checking for the presence of `eject.py`
- Do not add any external dependencies, except for custom modding libraries (e.g. SuitLib)
  - Subnautica mods are best kept minimal and self-contained to avoid compatibility issues.
- Keep file structure modular and organized for maintainability.

---
For more details, see the README.md and example files in each directory.
