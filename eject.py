#!/usr/bin/env python3
"""
Eject script for Subnautica Mod Template
Prompts for author, modid, modname, modlongname, does replacements, and deletes itself
"""

import os
import sys
import re
import signal

try:
    import questionary
except ImportError:
    print("questionary not found. Installing...")
    import subprocess
    subprocess.check_call([sys.executable, "-m", "pip", "install", "questionary"])
    import questionary

def abort(message=None):
    if message:
        print(f"\nEject aborted: {message}")
    sys.exit(1)

def signal_abort(signum, frame):
    abort(f"Received interrupt signal: {signum}")

def prompt_abort(q):
    result = q.ask()
    if result is None:
        abort()
    return result

example_map = {
    "Patches": {
        ""
    },
    "Prefabs": {
        "Resource": { "requires": [], "files": ["./MODNAME/Assets/SomeResource.png"] },
        "Chip": { "requires": ["ChipLibrary"], "files": ["./MODNAME/Prefabs/Tools/SomeChip.cs"] },
        "Suit": { "requires": ["SuitLibrary"], "files": ["./MODNAME/Prefabs/Equipment/SomeSuit.cs", "./MODNAME/Prefabs/Equipment/SomeGloves.cs"] },
        "Vehicle": { "requires": ["VehicleFramework"], "files": ["./MODNAME/Prefabs/Vehicles/SomeVehicle.cs"] },
    }
}

def prompt():
    YELLOW = '\033[93m'
    RESET = '\033[0m'
    print(YELLOW + "="*53)
    print(" WARNING: This script will personalize your mod template by replacing template naming occurrences in your project files.")
    print(" It will DELETE ITSELF after running. This action cannot be undone!")
    print(" Make sure you are ready to eject before proceeding.")
    print(" If you have the C# Dev Kit extension installed in VS Code, please temporarily disable it before running this script. It may lock files and prevent renaming or deleting during the eject process.")
    print("="*53 + RESET)
    print()
    modauthor = prompt_abort(questionary.text("Mod Author (your name or handle, e.g. visolar6):", validate=lambda t: bool(t.strip())))
    modid = prompt_abort(questionary.text("Mod ID (lowercase, used in GUID, e.g. mymod):", validate=lambda t: bool(t.strip())))
    modname = prompt_abort(questionary.text("Mod Name (no spaces, used for namespaces/classes, e.g. MyMod):", validate=lambda t: bool(t.strip())))
    modlongname = prompt_abort(questionary.text("Mod Long Name (display name, can have spaces, e.g. My Mod):", validate=lambda t: bool(t.strip())))
    print()
    game_dir_options = [
        "C:/Program Files (x86)/Steam/steamapps/common/Subnautica",
        "C:/Program Files/Steam/steamapps/common/Subnautica",
        "D:/Steam/steamapps/common/Subnautica",
        "D:/SteamLibrary/steamapps/common/Subnautica",
        "Enter custom path"
    ]
    game_dir_choice = prompt_abort(questionary.select(
        "Where is your Subnautica game directory located?",
        choices=game_dir_options
    ))
    if game_dir_choice == "Enter custom path":
        gamedir = prompt_abort(questionary.text("Enter the full path to your Subnautica game directory:", validate=lambda t: bool(t.strip())))
    else:
        gamedir = game_dir_choice
    return modauthor, modid, modname, modlongname, gamedir

def find_files():
    files = []
    # Only walk the MODNAME directory, but skip bin and obj subfolders
    if os.path.isdir('./MODNAME'):
        for root, dirs, filenames in os.walk('./MODNAME'):
            # Remove bin and obj from dirs so os.walk doesn't descend into them
            dirs[:] = [d for d in dirs if d not in {'bin', 'obj'}]
            for fname in filenames:
                files.append(os.path.join(root, fname))
    return files

def preview_replacements(files):
    print("\nThe following files will have replacements applied (MODAUTHOR, MODID, MODNAME, MODLONGNAME):")
    for f in files:
        try:
            with open(f, encoding='utf-8', errors='ignore') as fp:
                content = fp.read()
                if any(x in content for x in ["MODAUTHOR", "MODID", "MODNAME", "MODLONGNAME"]):
                    print(f"  {f}")
        except Exception:
            continue

def preview_renames(modid, modname, modlongname):
    hyplongname = modlongname.replace(' ', '-')
    print("\nThe following folders/files will be renamed:")
    if os.path.isdir("./MODNAME"):
        print(f"  Folder: ./MODNAME -> ./{modname}")
    if os.path.isfile("./MODNAME/Assets/MODID"):
        print(f"  File: ./MODNAME/Assets/MODID -> ./{modname}/Assets/{modid}")
    if os.path.isfile("./MODNAME/MODNAME.csproj"):
        print(f"  File: ./MODNAME/MODNAME.csproj -> ./{modname}/{modname}.csproj")
    if os.path.isfile("./MODLONGNAME.sln"):
        print(f"  File: ./MODLONGNAME.sln -> ./{hyplongname}.sln")

def do_replacements(files, modauthor, modid, modname, modlongname, gamedir):
    for f in files:
        try:
            with open(f, 'r', encoding='utf-8', errors='ignore') as fp:
                content = fp.read()
            content = content.replace('MODAUTHOR', modauthor)
            content = content.replace('MODID', modid)
            content = content.replace('MODNAME', modname)
            content = content.replace('MODLONGNAME', modlongname)
            # Replace <GameDir>...</GameDir> in .csproj
            if f.endswith('.csproj'):
                content = re.sub(r'<GameDir>.*?</GameDir>', f'<GameDir>{gamedir}</GameDir>', content)
            with open(f, 'w', encoding='utf-8') as fp:
                fp.write(content)
        except Exception as e:
            print(f"  Skipped {f}: {e}")

def main():
    # Register signal handlers
    signal.signal(signal.SIGINT, signal_abort)
    signal.signal(signal.SIGTERM, signal_abort)
    # SIGKILL cannot be caught or handled in Python

    modauthor, modid, modname, modlongname, gamedir = prompt()
    hyplongname = modlongname.replace(' ', '-')
    files = find_files()
    preview_replacements(files)
    preview_renames(modid, modname, modlongname)
    print("\nReplacement values:")
    print(f"  MODAUTHOR     -> {modauthor}")
    print(f"  MODID        -> {modid}")
    print(f"  MODNAME      -> {modname}")
    print(f"  MODLONGNAME  -> {modlongname}")
    print(f"  GameDir      -> {gamedir}")
    print("\nMake sure none of the affected files are open before proceeding.")
    print()
    confirm = questionary.confirm("Continue with these replacements and renames?").ask()
    if not confirm:
        abort("User cancelled the eject process.")
    do_replacements(files, modauthor, modid, modname, modlongname, gamedir)
    # Also do replacements in Makefile
    makefile_path = 'Makefile'
    if os.path.isfile(makefile_path):
        try:
            with open(makefile_path, 'r', encoding='utf-8', errors='ignore') as fp:
                content = fp.read()
            content = content.replace('MODAUTHOR', modauthor)
            content = content.replace('MODID', modid)
            content = content.replace('MODNAME', modname)
            content = content.replace('MODLONGNAME', modlongname)
            with open(makefile_path, 'w', encoding='utf-8') as fp:
                fp.write(content)
        except Exception as e:
            print(f"  Skipped Makefile: {e}")
    # Wipe README.md and set to # <MODLONGNAME>
    with open('README.md', 'w', encoding='utf-8') as fp:
        fp.write(f"# {modlongname}\n")
    # Rename MODNAME/Assets/MODID
    if os.path.isfile("./MODNAME/Assets/MODID"):
        os.rename("./MODNAME/Assets/MODID", f"./MODNAME/Assets/{modid}")
    # Rename MODNAME/MODNAME.csproj
    if os.path.isfile("./MODNAME/MODNAME.csproj"):
        os.rename("./MODNAME/MODNAME.csproj", f"./MODNAME/{modname}.csproj")
    # Rename MODNAME folder
    if os.path.isdir("./MODNAME"):
        os.rename("./MODNAME", f"./{modname}")
    # Rename MODLONGNAME.sln
    if os.path.isfile("./MODLONGNAME.sln"):
        os.rename("./MODLONGNAME.sln", f"./{hyplongname}.sln")

    # Remove the 'eject' command/target from the Makefile (assumes eject is the last target)
    try:
        with open('Makefile', 'r', encoding='utf-8') as mf:
            lines = mf.readlines()
        for idx, line in enumerate(lines):
            if line.strip().startswith('eject:'):
                # Remove from this line to the end
                lines = lines[:idx]
                break
        with open('Makefile', 'w', encoding='utf-8') as mf:
            mf.writelines(lines)
    except Exception as e:
        print(f"Warning: Could not update Makefile to remove eject target: {e}")

    # Delete this script
    try:
        os.remove(__file__)
    except Exception as e:
        print(f"Warning: Could not delete {__file__}: {e}")

if __name__ == "__main__":
    main()
