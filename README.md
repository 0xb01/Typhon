# Typhon

## About the app
Typhon is a simple Windows application made in VB.NET. It helps you boost your PC performance by freeing up memory (RAM), closing unnecessary background programs, cleaning temporary junk files, viewing detailed hardware specs, and testing game compatibility.

## How it helps the PC and the user
- **Frees up RAM:** Clears unused memory so your computer runs faster.
- **Closes background apps:** Helps you find and close heavy programs that slow down your system.
- **Cleans junk files:** Removes temporary files and log files to free up disk space.
- **Monitors PC usage:** Shows live graphs for CPU, RAM, and GPU usage.
- **Views PC Specs & Peripherals:** Displays your hardware details, plugged-in devices, and lets you open drives directly in File Explorer.
- **Checks Game Performance:** One-click check to see if your PC can run games on PC Game Benchmark.

## Freeing RAM process
When you click **FreeRAM();** or when **Auto FreeRAM();** runs:
1. Typhon scans active programs running on your PC.
2. It calls Windows system functions (`SetProcessWorkingSetSize`) to trim unused memory from those programs.
3. The freed memory is returned back to your system instantly.

## Killing process process
When you open **KillProcesses();**:
1. Typhon scans running background programs and groups them together by name.
2. It excludes important Windows system files (like `C:\Windows\System32`) and your saved ignore list so Windows stays safe.
3. You select the programs you want to close and click **KillProcesses();** to stop them.

## File structure
```
Typhon/
├── Typhon.sln              # Visual Studio solution file
└── src/                    # Source code folder
    ├── App.config          # App settings configuration
    ├── Controls/
    │   └── theme.vb        # Custom dark UI controls and styling
    ├── Forms/
    │   ├── WinMain.vb      # Main window (RAM, Graph, Settings, Specs, About)
    │   ├── WinKill.vb      # Process killer window
    │   ├── WinCleaner.vb   # System junk cleaner window
    │   └── WinExceptions.vb# Ignored processes window
    └── Helpers/
        ├── proc.vb         # RAM and process management code
        ├── cleaner.vb      # Junk file cleaner code
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
