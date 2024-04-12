# Sentynel-mobile-client

`Sentynel-mobile-client` is a multi-platform client app for the SentynelApi Backend. The app allows you to manage the candidats.

# Dependencies

Though `Sentynel-mobile-client` mobile app relies on the repo [Sentynel] for its backend but by default it uses its internal MockServices for all its functionalities. 

## Architecture

The app architecture consists of :

1. A .NET MAUI mobile app for iOS, macOS, Android, and Windows.

### .NET MAUI App

This project exercises the following platforms, frameworks, and features:

- .NET MAUI
  - XAML
  - Behaviors
  - Bindings
  - Converters
  - Central Styles
  - Animations
  - IoC
  - Messaging Center
  - Custom Controls
  - xUnit Tests
- Azure Mobile Services
  - C# backend
  - WebAPI
  - Entity Framework
  - Identity Server 4


## Supported platforms

The app targets **four** platforms:

- iOS
- Android
- macOS (must build and deploy from Mac)
- Windows (must build and deploy from Windows)

## Requirements

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (2022 or higher) to compile C# language features
  - **Visual Studio Community Edition is fully supported!**
- .NET MAUI add-ons for Visual Studio (available via the Visual Studio installer)

or

- [Visual Studio Code](https://learn.microsoft.com/dotnet/maui/get-started/installation?tabs=visual-studio-code) configured for .NET MAUI development on Mac, Windows, or Linux. 

## Setup

### 1. Ensure the .NET MAUI platform is installed

You can do that by following the steps mentioned in [Installing .NET MAUI](https://learn.microsoft.com/dotnet/maui/get-started/installation)

### 2. Ensure .NET MAUI is updated

Visual Studio will periodically automatically check for updates. You can also manually check for updates using the [Update Visual Studio](https://docs.microsoft.com/visualstudio/install/update-visual-studio) options.

### 3. Project Setup

Restore NuGet packages for the project.

### 4. Ensure Android Emulator is installed or real device is present

You can use any Android emulator or device. Refer to the [Android Emulator documentation](https://learn.microsoft.com/dotnet/maui/android/emulator/device-manager) for details on setup.

> **Note**: Android emulators cannot run well inside a virtual machine or over Remote Desktop or VNC since it relies on virtualization.

To deploy and debug the application on a physical device, refer to the [Debug on an Android device](https://learn.microsoft.com/dotnet/maui/android/device/setup) article.

### 5. Optional iOS Deployment

To deploy to iOS you can directly deploy from a Mac machine or optionally from a Windows machine [directly to a device](https://learn.microsoft.com/dotnet/maui/ios/hot-restart) or by [pairing your Windows machine to a Mac](https://learn.microsoft.com/dotnet/maui/ios/pair-to-mac).

