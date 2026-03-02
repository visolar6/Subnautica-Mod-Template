
# Publishing Mods: OpenMods & NexusMods

Automated workflows are available for updating mod listings and uploading new releases to both OpenMods and NexusMods.

## API Integration
To enable automated publishing, configure these secrets:
- `OPENMODS_API_KEY` and `OPENMODS_MOD_ID`
- `NEXUSMODS_API_KEY` and `NEXUSMODS_MOD_ID`

## Asset & Content Organization
- `.openmods/img/`: Store images for your mod's gallery on openmods.net. These images appear in the gallery section of your mod page.
- `.nexusmods/summary.txt`: A short summary of your mod (max 200 characters) for NexusMods.
- `.nexusmods/details.bbcode`: Place your NexusMods full mod description here for easy copy-pasting when updating your NexusMods page.

Ensure all assets and secrets are in place before publishing.
