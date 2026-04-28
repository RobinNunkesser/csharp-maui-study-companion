SHELL := /bin/sh

PROJECT := StudyCompanion/StudyCompanion.csproj
CONFIG ?= Debug
DOTNET ?= $(shell /bin/sh -c 'command -v dotnet 2>/dev/null || echo /usr/local/share/dotnet/dotnet')

TFM_MACCATALYST := net10.0-maccatalyst
TFM_ANDROID := net10.0-android
TFM_IOS := net10.0-ios
TFM_WINDOWS := net10.0-windows10.0.19041.0

# Optional: for iOS run target, e.g. IOS_DEVICE=:v2:udid=YOUR_SIMULATOR_UDID
IOS_DEVICE ?=

# Optional: override Java location for Android builds, e.g. JAVA_SDK_DIR=$$(/usr/libexec/java_home -v 17)
JAVA_SDK_DIR ?=
ANDROID_JAVA_ARG := $(if $(JAVA_SDK_DIR),-p:JavaSdkDirectory=$(JAVA_SDK_DIR),)

.PHONY: help restore test clean \
	build build-maccatalyst build-maccatalyst-release build-android build-ios build-windows \
	run-maccatalyst run-maccatalyst-release run-android run-ios

help:
	@echo "Study Companion MAUI targets"
	@echo ""
	@echo "General:"
	@echo "  make restore"
	@echo "  make test"
	@echo "  make clean"
	@echo ""
	@echo "Build:"
	@echo "  make build                    # builds solution default"
	@echo "  make build-maccatalyst"
	@echo "  make build-maccatalyst-release"
	@echo "  make build-android            # optional JAVA_SDK_DIR"
	@echo "  make build-ios"
	@echo "  make build-windows            # only works on Windows"
	@echo ""
	@echo "Run:"
	@echo "  make run-maccatalyst"
	@echo "  make run-maccatalyst-release"
	@echo "  make run-android              # device/emulator required"
	@echo "  make run-ios IOS_DEVICE=:v2:udid=<SIM_UDID>"

restore:
	$(DOTNET) restore StudyCompanion.sln

test:
	$(DOTNET) test StudyCompanion.Core.Tests/StudyCompanion.Core.Tests.csproj -c $(CONFIG)
	$(DOTNET) test StudyCompanion.Infra.Tests/StudyCompanion.Infra.Tests.csproj -c $(CONFIG)

clean:
	$(DOTNET) clean StudyCompanion.sln -c $(CONFIG)

build:
	$(DOTNET) build StudyCompanion.sln -c $(CONFIG)

build-maccatalyst:
	$(DOTNET) build $(PROJECT) -f $(TFM_MACCATALYST) -c $(CONFIG)

build-maccatalyst-release:
	$(DOTNET) build $(PROJECT) -f $(TFM_MACCATALYST) -c Release

build-android:
	$(DOTNET) build $(PROJECT) -f $(TFM_ANDROID) -c $(CONFIG) $(ANDROID_JAVA_ARG)

build-ios:
	$(DOTNET) build $(PROJECT) -f $(TFM_IOS) -c $(CONFIG)

build-windows:
	$(DOTNET) build $(PROJECT) -f $(TFM_WINDOWS) -c $(CONFIG)

run-maccatalyst:
	$(DOTNET) build $(PROJECT) -f $(TFM_MACCATALYST) -c $(CONFIG)
	@APP_PATH=$$(find StudyCompanion/bin/$(CONFIG)/$(TFM_MACCATALYST) -type d -name "StudyCompanion.app" | head -n 1); \
	if [ -z "$$APP_PATH" ]; then \
		echo "Konnte StudyCompanion.app nicht finden (Build-Ausgabe fehlt)."; \
		exit 1; \
	fi; \
	open "$$APP_PATH" || { \
		echo "App wurde gebaut, aber macOS konnte sie nicht starten. Pfad: $$APP_PATH"; \
		echo "Starte sie ggf. manuell mit: open \"$$APP_PATH\""; \
		exit 1; \
	}

run-maccatalyst-release:
	$(MAKE) run-maccatalyst CONFIG=Release

run-android:
	$(DOTNET) build $(PROJECT) -t:Run -f $(TFM_ANDROID) -c $(CONFIG) $(ANDROID_JAVA_ARG)

run-ios:
	@if [ -z "$(IOS_DEVICE)" ]; then \
		echo "Bitte IOS_DEVICE setzen, z.B. IOS_DEVICE=:v2:udid=<SIM_UDID>"; \
		exit 1; \
	fi
	$(DOTNET) build $(PROJECT) -t:Run -f $(TFM_IOS) -c $(CONFIG) -p:_DeviceName=$(IOS_DEVICE)
