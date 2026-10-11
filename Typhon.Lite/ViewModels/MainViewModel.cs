using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Typhon.Lite.Services;
using Point = System.Windows.Point;

namespace Typhon.Lite.ViewModels;

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
        : this(_ => execute(), canExecute != null ? _ => canExecute() : null)
    {
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
    public void Execute(object? parameter) => _execute(parameter);
}

public class MainViewModel : INotifyPropertyChanged
{
    private readonly DispatcherTimer _monitorTimer;
    private readonly DispatcherTimer _autoFreeTimer;
    private readonly List<double> _history = new();
    private const int MaxHistoryPoints = 35;
    private const double VirtualWidth = 400.0;
    private const double VirtualHeight = 180.0;

    private double _usedMemoryGB;
    private double _totalMemoryGB;
    private string _memoryUsageFormatted = "0.0 / 0.0 GB";
    private uint _memoryPercentage;
    private string _memoryPercentageFormatted = "0%";
    private int _processCount;
    private string _statusMessage = "";
    private bool _isFreeing;
    private bool _isAutoFreeEnabled;
    private bool _runOnStartup;
    private int _autoFreeCountdown = 30;
    private string _autoFreeStatusText = "30s";
    private bool _isTopmost = false;
    private Geometry? _silhouetteGeometry;
    private Geometry? _silhouetteStrokeGeometry;

    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action<IReadOnlyList<double>, double, double, uint>? TelemetryUpdated;
    public event Action<string, string>? MemoryFreedNotification;

    public IReadOnlyList<double> History => _history;

    public double UsedMemoryGB
    {
        get => _usedMemoryGB;
        private set => SetField(ref _usedMemoryGB, value);
    }

    public double TotalMemoryGB
    {
        get => _totalMemoryGB;
        private set => SetField(ref _totalMemoryGB, value);
    }

    public string MemoryUsageFormatted
    {
        get => _memoryUsageFormatted;
        private set => SetField(ref _memoryUsageFormatted, value);
    }

    public uint MemoryPercentage
    {
        get => _memoryPercentage;
        private set => SetField(ref _memoryPercentage, value);
    }

    public string MemoryPercentageFormatted
    {
        get => _memoryPercentageFormatted;
        private set => SetField(ref _memoryPercentageFormatted, value);
    }

    public int ProcessCount
    {
        get => _processCount;
        private set => SetField(ref _processCount, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetField(ref _statusMessage, value);
    }

    public bool IsFreeing
    {
        get => _isFreeing;
        private set
        {
            if (SetField(ref _isFreeing, value))
            {
                OnPropertyChanged(nameof(CanFreeMemory));
                OnPropertyChanged(nameof(FreeButtonText));
            }
        }
    }

    public bool CanFreeMemory => !IsFreeing;
    public string FreeButtonText => IsFreeing ? "Freeing..." : "Free Memory";

    public bool IsAutoFreeEnabled
    {
        get => _isAutoFreeEnabled;
        set
        {
            if (SetField(ref _isAutoFreeEnabled, value))
            {
                OnAutoFreeToggled(value);
                SaveSettings();
            }
        }
    }

    public bool RunOnStartup
    {
        get => _runOnStartup;
        set
        {
            if (SetField(ref _runOnStartup, value))
            {
                SettingsService.SetStartupRegistration(value);
                SaveSettings();
            }
        }
    }

    public int AutoFreeCountdown
    {
        get => _autoFreeCountdown;
        private set => SetField(ref _autoFreeCountdown, value);
    }

    public string AutoFreeStatusText
    {
        get => _autoFreeStatusText;
        private set => SetField(ref _autoFreeStatusText, value);
    }

    public bool IsTopmost
    {
        get => _isTopmost;
        set
        {
            if (SetField(ref _isTopmost, value))
            {
                OnPropertyChanged(nameof(PinIconColor));
            }
        }
    }

    public string PinIconColor => IsTopmost ? "#38BDF8" : "#64748B";

    public Geometry? SilhouetteGeometry
    {
        get => _silhouetteGeometry;
        private set => SetField(ref _silhouetteGeometry, value);
    }

    public Geometry? SilhouetteStrokeGeometry
    {
        get => _silhouetteStrokeGeometry;
        private set => SetField(ref _silhouetteStrokeGeometry, value);
    }

    public ICommand FreeMemoryCommand { get; }
    public ICommand ToggleTopmostCommand { get; }

    public MainViewModel()
    {
        FreeMemoryCommand = new RelayCommand(async () => await ExecuteFreeMemoryAsync(), () => CanFreeMemory);
        ToggleTopmostCommand = new RelayCommand(() => IsTopmost = !IsTopmost);

        // Load saved settings from AppData\Local\Banisk\TyphonLite.json
        var settings = SettingsService.Load();
        _isAutoFreeEnabled = settings.AutoFree30s;
        _runOnStartup = settings.RunOnStartup;

        // Initial memory read
        RefreshMemoryInfo();

        // Populate initial graph history baseline
        double currentPercent = _memoryPercentage > 0 ? _memoryPercentage : 40.0;
        for (int i = 0; i < MaxHistoryPoints; i++)
        {
            _history.Add(currentPercent);
        }
        UpdateGraphGeometries();

        // 1-second system monitor timer
        _monitorTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _monitorTimer.Tick += (s, e) =>
        {
            RefreshMemoryInfo();
            UpdateHistory();
        };
        _monitorTimer.Start();

        // Auto-free countdown timer (ticks every second)
        _autoFreeTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _autoFreeTimer.Tick += async (s, e) =>
        {
            if (!IsAutoFreeEnabled) return;

            AutoFreeCountdown--;
            if (AutoFreeCountdown <= 0)
            {
                AutoFreeCountdown = 30;
                AutoFreeStatusText = "30s";
                await ExecuteFreeMemoryAsync(isAuto: true);
            }
            else
            {
                AutoFreeStatusText = $"{AutoFreeCountdown}s";
            }
        };

        if (_isAutoFreeEnabled)
        {
            _autoFreeTimer.Start();
            _autoFreeStatusText = "30s";
        }
    }

    private void SaveSettings()
    {
        SettingsService.Save(new AppSettings
        {
            AutoFree30s = IsAutoFreeEnabled,
            RunOnStartup = RunOnStartup
        });
    }

    private void OnAutoFreeToggled(bool enabled)
    {
        if (enabled)
        {
            AutoFreeCountdown = 30;
            AutoFreeStatusText = "30s";
            _autoFreeTimer.Start();
            StatusMessage = "Auto-free enabled (every 30s)";
        }
        else
        {
            _autoFreeTimer.Stop();
            AutoFreeCountdown = 30;
            AutoFreeStatusText = "Off";
            StatusMessage = "Auto-free disabled";
        }
    }

    public void RefreshMemoryInfo()
    {
        var info = MemoryOptimizer.GetMemoryInfo();
        UsedMemoryGB = info.UsedGB;
        TotalMemoryGB = info.TotalGB;
        MemoryUsageFormatted = $"{info.UsedGB:F1} / {info.TotalGB:F1} GB";
        MemoryPercentage = info.LoadPercentage;
        MemoryPercentageFormatted = $"{info.LoadPercentage}%";
        ProcessCount = info.ProcessCount;
    }

    private void UpdateHistory()
    {
        _history.Add(MemoryPercentage);
        if (_history.Count > MaxHistoryPoints)
        {
            _history.RemoveAt(0);
        }
        UpdateGraphGeometries();

        TelemetryUpdated?.Invoke(_history, UsedMemoryGB, TotalMemoryGB, MemoryPercentage);
    }

    private void UpdateGraphGeometries()
    {
        if (_history.Count < 2) return;

        int count = _history.Count;
        double stepX = VirtualWidth / (count - 1);

        var points = new Point[count];
        for (int i = 0; i < count; i++)
        {
            double pct = Math.Clamp(_history[i], 0.0, 100.0);
            double y = VirtualHeight - (pct / 100.0 * (VirtualHeight * 0.72)) - 10.0;
            points[i] = new Point(i * stepX, y);
        }

        var areaFigure = new PathFigure
        {
            StartPoint = new Point(0, VirtualHeight),
            IsClosed = true,
            IsFilled = true
        };
        areaFigure.Segments.Add(new LineSegment(points[0], false));

        var strokeFigure = new PathFigure
        {
            StartPoint = points[0],
            IsClosed = false,
            IsFilled = false
        };

        for (int i = 0; i < count - 1; i++)
        {
            Point p0 = i > 0 ? points[i - 1] : points[i];
            Point p1 = points[i];
            Point p2 = points[i + 1];
            Point p3 = (i + 2 < count) ? points[i + 2] : p2;

            Point cp1 = new Point(
                p1.X + (p2.X - p0.X) / 6.0,
                p1.Y + (p2.Y - p0.Y) / 6.0
            );
            Point cp2 = new Point(
                p2.X - (p3.X - p1.X) / 6.0,
                p2.Y - (p3.Y - p1.Y) / 6.0
            );

            var bezier = new BezierSegment(cp1, cp2, p2, true);
            areaFigure.Segments.Add(bezier);
            strokeFigure.Segments.Add(bezier);
        }

        areaFigure.Segments.Add(new LineSegment(new Point(VirtualWidth, VirtualHeight), false));
        areaFigure.Segments.Add(new LineSegment(new Point(0, VirtualHeight), false));

        var areaGeo = new PathGeometry();
        areaGeo.Figures.Add(areaFigure);
        areaGeo.Freeze();

        var strokeGeo = new PathGeometry();
        strokeGeo.Figures.Add(strokeFigure);
        strokeGeo.Freeze();

        SilhouetteGeometry = areaGeo;
        SilhouetteStrokeGeometry = strokeGeo;
    }

    public async Task<FreeMemoryResult?> ExecuteFreeMemoryAsync(bool isAuto = false)
    {
        if (IsFreeing) return null;

        IsFreeing = true;
        StatusMessage = isAuto ? "Auto-cleaning memory..." : "Freeing memory...";

        try
        {
            var result = await MemoryOptimizer.FreeMemoryAsync();
            RefreshMemoryInfo();
            UpdateHistory();

            string freedMsg;
            if (result.FreedBytes > 0)
            {
                freedMsg = $"Freed {result.FormatFreed()} ({result.TrimmedProcesses} processes)";
            }
            else
            {
                freedMsg = $"Optimized ({result.TrimmedProcesses} processes checked)";
            }

            StatusMessage = freedMsg;
            MemoryFreedNotification?.Invoke("Typhon Lite", freedMsg);

            if (!isAuto && IsAutoFreeEnabled)
            {
                AutoFreeCountdown = 30;
                AutoFreeStatusText = "30s";
            }

            return result;
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
            return null;
        }
        finally
        {
            IsFreeing = false;
        }
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
