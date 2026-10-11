# Typhon

## About the app
Typhon is a simple Windows application made in VB.NET. It helps you boost your PC performance by freeing up memory (RAM), closing unnecessary background programs, cleaning temporary junk files, viewing detailed hardware specs, and testing game compatibility.

## How it helps the PC and the user
- **Frees up RAM & Standby List:** Trims working sets and purges Windows Standby Cache to eliminate micro-stuttering.
- **Game Booster Engine:** 1-click real-time game mode with 0.5ms timer resolution, Ultimate Power Plan, CPU priority/affinity, and background app throttling.
- **Game Library Hub:** Discovers installed Steam, Epic Games, and GOG titles with 1-click "Boost & Launch".
- **Mini In-Game HUD:** Floating draggable overlay displaying real-time FPS, CPU, GPU, RAM, and timer resolution.
- **Low-Latency Network Tweaks:** Toggles TCP NoDelay (Nagle's algorithm) and disables multimedia network throttling for lowest multiplayer ping.
- **Closes background apps:** Helps you find and close heavy programs that slow down your system.
- **Cleans junk files:** Removes temporary files, crash dumps, and shader caches to free up disk space.
- **Visualizes disk usage:** Typhon Sight interactive treemap to locate large files and reclaim storage.
- **Monitors PC usage:** Shows live graphs for CPU, RAM, and GPU usage.
- **Views PC Specs & Peripherals:** Displays your hardware details, plugged-in devices, and lets you open drives directly in File Explorer.
- **Checks Game Performance:** One-click check to see if your PC can run games on PC Game Benchmark.

## File structure
```
Typhon/
├── Typhon.sln              # Visual Studio solution file
├── Typhon.Lite/            # Simplified WPF Fluent edition (.NET 8)
│   ├── App.xaml            # WPF-UI Fluent theme configuration
│   ├── MainWindow.xaml     # Compact widget with blurred silhouette graph
│   ├── Services/
│   │   └── MemoryOptimizer.cs # Standby purge & working set trimmer
│   └── ViewModels/
│       └── MainViewModel.cs   # Live RAM monitor, auto-free 30s timer, curve geometry
└── src/                    # Full Classic WinForms edition
    ├── App.config          # App settings configuration
    ├── Controls/
    │   ├── theme.vb        # Custom dark UI controls and styling
    │   └── SpaceLensTreemap.vb # Interactive disk treemap visualizer
    ├── Forms/
    │   ├── WinMain.vb      # Main window (RAM, Graph, Gaming, Settings, Specs, About)
    │   ├── WinGameBoost.vb # Real-time Game Booster & Library window
    │   ├── WinHUD.vb       # Floating in-game performance HUD overlay
    │   ├── WinKill.vb      # Process killer window
    │   ├── WinCleaner.vb   # System junk cleaner window
    │   ├── WinSight.vb     # Typhon Sight disk visualizer window
    │   ├── WinDiskSelector.vb # Storage drive selection dialog
    │   ├── WinExceptions.vb# Ignored processes window
    │   └── DialogMessage.vb# Custom styled dark message dialog
    └── Helpers/
        ├── proc.vb         # RAM, Standby purge, timer resolution, and process management
        ├── gaming.vb       # Power schemes, network tweaks, game scanner, and boost engine
        ├── cleaner.vb      # Junk file & cache cleaner code
        ├── DiskTreeScanner.vb # Async multi-threaded storage scanner
        └── func.vb         # System specs, peripherals, and benchmark logic
```

## How to build
### Requirements
- Windows 7, 10, or 11
- .NET Framework 4.8 or Visual Studio 2019+

### Steps
1. Open `Typhon.sln` in Visual Studio.
2. Select **Release** or **Debug** mode.
3. Click **Build Solution** or press `F5` to run.

Or build using MSBuild in command line:
```cmd
MSBuild.exe Typhon.sln /t:Rebuild /p:Configuration=Release
```

## How to contribute
1. Fork this repository on GitHub.
2. Create a new feature branch for your changes.
3. Make your changes and test your code.
4. Send a Pull Request with a short description of what you fixed or added.

## Thanks
- Special thanks to **aeonhack** for the NetSeal Theme.
- Special thanks to **icons8.com** for the icons.
