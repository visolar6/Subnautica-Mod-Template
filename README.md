# Subnautica Mod Template


Welcome to the Subnautica Mod Template repository!

This template provides a modern, maintainable starting point for Subnautica mod development. It features a modular directory structure, clear naming conventions, and practical example files for common modding tasks. Whether you're new to Subnautica modding or want to streamline your workflow, this template helps you:

- Quickly bootstrap new mods with a ready-to-eject structure
- Follow best practices for code organization, asset management, and localization
- Utilize popular Subnautica libraries, such as Nautilus
- Integrate with popular modding sites using GitHub workflows (NexusMods, OpenMods)
- Collaborate more easily with other developers

While not all Subnautica mods follow this structure, this template reflects the author's best attempt at a scalable, maintainable workflow. Use it as a strong foundation, adapt as needed, and enjoy faster, cleaner mod development!

## ⚙️ Requirements / Prerequisites

- **.NET SDK 4.7.2+**
- **Python 3** (only needed for the eject script)
- **Make** (optional, for using the Makefile)

Make sure these tools are installed before you begin.

## 🛠️ Recommended Software & Tools

- **Visual Studio Code** — Recommended for programming. See the recommended extensions in `.vscode/extensions.json` for a better development experience.
- **Unity 2019.4.41f2** — Required for asset bundling (if you are adding assets). Make sure to use this exact version for compatibility with Subnautica.

## 🌟 Helpful Modding Resources

- [BepInEx Plugin Documentation](https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/index.html) - Additional info about setting up your plugin.
- [Nautilus API Documentation](https://subnauticamodding.github.io/Nautilus/index.html) — Essential reference for Subnautica modding with Nautilus.
- [SN1 Prefab Class IDs](https://raw.githubusercontent.com/32Kallies/Lee23-LegacySubnauticaMods/8e1451f5e064711834af464315cc3c17ea53d3e7/Resources/SN1-PrefabPaths.json) — List of base-game prefab class IDs, useful for making clone templates.
- [Subnautica PDA Voice Generator](https://subnauticapdavoice.com) — Generate new PDA voice lines (most accurate representation I've found).
- [Meshy](https://www.meshy.ai/?utm_source=meshy&utm_medium=referral-program&utm_content=C02VG9&share_type=invite-friends) — Generate 3D models (great for prototyping, but watch out for high poly count).
- [ElevenLabs](https://try.elevenlabs.io/m7vxp0vomdh9) — Generate custom voice lines for story-driven mods, if not using real voice actors.

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


## 📁 Project Structure & Example Files
This template features a thoughtfully organized directory structure, with each folder containing practical example files to help you implement common mod features:

- `Assets/` — Asset bundles, images, audio, etc.
- `Config/` — Configuration/state files for persistent state between reloads.
- `Localization/` — Translation/localization resources.
- `Mono/` — Unity MonoBehaviour scripts for custom game components.
- `Patches/` — Harmony patch classes for modifying game methods.
- `Prefabs/` — Example prefabs, organized by type (e.g., `Equipment/`, `Resources/`, `Vehicles/`, etc.).
- `Utilities/` — Generic helper classes, not specific to any feature.

Each example is designed as a reference for implementing similar features in your own mod, helping you get started quickly and follow best practices.

## 🤝 Contributing

Contributions to improve this template are welcome! Please see [CONTRIBUTING.md](.github/CONTRIBUTING.md) for guidelines.

## 📄 License

This template is provided under the GNU General Public License v3.0 (GPLv3). You are free to use, modify, and distribute it as part of your own Subnautica mods, provided you comply with the terms of the GPL. See the [LICENSE](LICENSE) file for details.

## 🌐 Contact & Community

- For help, suggestions, or to show off your mod, join the Subnautica modding community on Discord or visit the forums.
- Issues and pull requests are welcome on this repository.

Happy modding! If you have suggestions for improving this template, feel free to open an issue or pull request.
