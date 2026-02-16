# Makefile for Subnautica Mod Template

.PHONY: all build eject deploy clean

all: build deploy

build:
	dotnet build -c Release

clean:
	dotnet clean

deploy:
	@SUBNAUTICA_PATH=$${SUBNAUTICA_PATH:-"D:/SteamLibrary/steamapps/common/Subnautica"}; \
	PLUGIN_DIR="$$SUBNAUTICA_PATH/BepInEx/plugins/MODNAME"; \
	DLL_PATH="MODNAME/bin/Release/net472/MODNAME.dll"; \
	LOCALIZATION_PATH="MODNAME/Localization"; \
	ASSETS_PATH="MODNAME/Assets"; \
	if [ -f "$$DLL_PATH" ]; then \
		mkdir -p "$$PLUGIN_DIR"; \
		cp "$$DLL_PATH" "$$PLUGIN_DIR/" && echo "✓ DLL copied to $$PLUGIN_DIR" || (echo "✗ Failed to copy DLL" && exit 1); \
		if [ -d "$$LOCALIZATION_PATH" ]; then cp -r "$$LOCALIZATION_PATH" "$$PLUGIN_DIR/" && echo "✓ Localization copied"; fi; \
		if [ -d "$$ASSETS_PATH" ]; then cp -r "$$ASSETS_PATH" "$$PLUGIN_DIR/" && echo "✓ Assets copied"; fi; \
	else \
		echo "✗ DLL not found at $$DLL_PATH"; \
		exit 1; \
	fi

eject:
	@command -v python > /dev/null 2>&1 || (echo '✗ Python is not installed. Please install Python to run eject.py.' && exit 1)
	python eject.py