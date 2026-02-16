# Subnautica Mod Template

> **Note:** This template is highly opinionated. Not all Subnautica mods follow this structure or set of conventions—this template reflects the author's best attempt at a maintainable, scalable, and modern modding workflow. Use it as a strong starting point, but be aware that other mods in the community may look very different.

Welcome to the Subnautica Mod Template repository! This project is designed to help Subnautica mod developers quickly bootstrap their next mod with a clean, organized, and opinionated structure. The directory and file naming conventions used here are based on best practices and good etiquette for mod development, making it easier to maintain, share, and collaborate on your mod projects.

## ⚙️ Requirements / Prerequisites

- **Python 3** (only needed for the eject script)
- **.NET SDK 4.7.2+** (for building the mod)
- **Unity** (for asset bundle creation, if needed)
- **Make** (optional, for using the Makefile)
- Recommended: Visual Studio, Rider, or VSCode with C# support

Make sure these tools are installed before you begin.

## 🛠️ Recommended Software & Tools

- **Visual Studio Code** — Recommended for programming. See the recommended extensions in `.vscode/extensions.json` for a better development experience.
- **Unity 2019.4.41f2** — Required for asset bundling. Make sure to use this exact version for compatibility with Subnautica.

## 🚨 Eject Before You Begin
**Before making any changes or starting development, you must run `make eject` (or execute the `eject.py` script).**

- The eject process will prompt you for your mod's author, ID, name, and display name, as well as the location of your Subnautica installation.
- It will automatically personalize the template, replace all placeholder values, and rename files and folders as needed.
- The script will then delete itself and remove the eject command from the Makefile, ensuring you can't accidentally run it again.
- **Do not modify any files or folders until you have completed the eject process.**

## ❓ FAQ / Troubleshooting

- **The eject script fails or is missing:**
  - Ensure you have Python 3 installed and available in your PATH.
  - If you accidentally deleted the script before ejecting, re-clone the repository to start over.
- **Build errors after ejecting:**
  - Make sure you have the correct .NET SDK and Unity version installed.
  - Check that all required dependencies are present in your Subnautica installation.
- **Other issues:**
  - See the [CONTRIBUTING.md](CONTRIBUTING.md) for more help or to report a problem.

## 🌟 Helpful Modding Resources

- [Nautilus API Documentation](https://subnauticamodding.github.io/Nautilus/index.html) — Essential reference for Subnautica modding with Nautilus.
- [SN1 Prefab Class IDs](https://raw.githubusercontent.com/32Kallies/Lee23-LegacySubnauticaMods/8e1451f5e064711834af464315cc3c17ea53d3e7/Resources/SN1-PrefabPaths.json) — List of base-game prefab class IDs, useful for making clone templates.
- [Subnautica PDA Voice Generator](https://subnauticapdavoice.com) — Generate new PDA voice lines (most accurate representation).
- [Meshy](https://www.meshy.ai) — Generate meshes (great for prototyping, but watch out for high poly count).
- [ElevenLabs](https://elevenlabs.io) — Generate custom voice lines.

## 📁 Project Structure & Conventions
This template features a thoughtfully organized directory structure:

- `Assets/` — For images, icons, and other asset files.
- `Config/` — For configuration/state files.
- `Localization/` — For translation and localization resources.
- `Mono/` — For MonoBehaviour scripts and Unity components.
- `Patches/` — For Harmony patch classes and method patches.
- `Prefabs/` — For example prefabs, organized by type (e.g., `Equipment/`, `Resources/`, `Vehicles/`, etc.).
- `Utilities/` — For utility/helper classes.

These conventions help keep your mod organized and make it easier for others to understand and contribute to your project.

## 📝 Example Files
This template includes a variety of example files to provide a baseline for common mod features:

- **Patches:** Example Harmony patch classes in `Patches/` show how to patch game methods and classes.
- **Prefabs:** Example prefab scripts in `Prefabs/` demonstrate how to add new equipment, resources, vehicles, and more.
- **MonoBehaviours:** Example Unity MonoBehaviour scripts in `Mono/` illustrate how to create custom game components.
- **Config & State:** Example configuration/state files in `Config/` show how to manage mod state that persists between reloads.
- **Assets:** Example asset bundle in `Assets/` provides a naming convention for asset bundle files.
- **Localization:** Example localization files in `Localization/` help you support multiple languages.
- **Utilities:** Example utility classes in `Utilities/` offer reusable helpers for your mod logic.

Each example is designed to be a reference for implementing similar features in your own mod, helping you get started quickly and follow best practices.

## 🤝 Contributing

Contributions to improve this template are welcome! Please see [CONTRIBUTING.md](.github/CONTRIBUTING.md) for guidelines.

## 📄 License

This template is provided under the GNU General Public License v3.0 (GPLv3). You are free to use, modify, and distribute it as part of your own Subnautica mods, provided you comply with the terms of the GPL. See the [LICENSE](LICENSE) file for details.

## 🌐 Contact & Community

- For help, suggestions, or to show off your mod, join the Subnautica modding community on Discord or visit the forums.
- Issues and pull requests are welcome on this repository.

Happy modding! If you have suggestions for improving this template, feel free to open an issue or pull request.