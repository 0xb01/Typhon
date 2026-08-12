# Typhon

A lightweight Windows application built in VB.NET designed to boost PC performance by optimizing memory, scanning and managing background processes, and cleaning system temporary files.

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey.svg)](https://microsoft.com/windows)
[![Target](https://img.shields.io/badge/.NET_Framework-4.8-purple.svg)](https://dotnet.microsoft.com/)

---

## ⚡ Features

- **Memory Optimizer**: Force-trims the working set memory across active processes to free up RAM instantly.
- **Process Manager**: Scans for killable user-space processes with support for custom process exclusion / ignore lists.
- **System Junk Cleaner**: Safely identifies and removes temporary files (`*.tmp`), log files (`*.log`), and prefetch cache.
- **Resource Monitoring**: Live graph and real-time indicators for RAM usage, memory percentage, and active process count.
- **System Information**: Displays hardware specifications (CPU, GPU, RAM, OS, Storage drives).

---

## 🛠️ Building & Running

### Requirements
- **OS**: Windows 7 / 10 / 11 (x86 or x64)
- **Runtime**: .NET Framework 4.8 or higher
- **IDE / Tools**: Visual Studio 2019+ or .NET SDK / MSBuild

### Build via Command Line
```powershell
# Using dotnet CLI
dotnet build Typhon.sln

# Or using MSBuild
MSBuild.exe Typhon.sln /t:Rebuild /p:Configuration=Release
```

### Build via Visual Studio
1. Open `Typhon.sln` in Visual Studio.
2. Select **Release** or **Debug** configuration.
3. Build and run (`F5`).

---

## 📁 Repository Structure

```
Typhon/
├── LICENSE                 # MIT License
├── README.md               # Documentation
├── Typhon.sln              # Visual Studio solution file
└── src/                    # Project source directory
    ├── App.config          # Application configuration
    ├── ApplicationEvents.vb# App lifecycle event handlers
    ├── Typhon.vbproj       # VB.NET project file
    ├── typhon_ico.ico      # Main app icon
    ├── Controls/           # Custom UI controls
    │   └── theme.vb        # Theme component implementation
    ├── Forms/              # Application WinForms UI
    │   ├── WinKill.vb      # Process killer form
    │   └── WinMain.vb      # Main application window
    ├── Helpers/            # Core system logic and native API helpers
    │   ├── func.vb         # WMI hardware specs query helper
    │   └── proc.vb         # Native P/Invoke & process manager helper
    ├── My Project/         # Assembly metadata and settings
    └── Resources/          # Asset files (images, icons)
```

---

## 📄 License

This project is open-source software licensed under the [MIT License](LICENSE).
