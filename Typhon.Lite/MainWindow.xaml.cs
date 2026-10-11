using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;
using Typhon.Lite.Services;
using Typhon.Lite.ViewModels;

namespace Typhon.Lite;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : FluentWindow
{
    public MainViewModel ViewModel { get; }
    private readonly TrayService _trayService;

    public MainWindow()
    {
        ViewModel = new MainViewModel();
        DataContext = ViewModel;

        _trayService = new TrayService(
            onFreeMemory: () =>
            {
                Dispatcher.InvokeAsync(async () =>
                {
                    await ViewModel.ExecuteFreeMemoryAsync();
                });
            },
            onRestoreWindow: () =>
            {
                Dispatcher.InvokeAsync(RestoreFromTray);
            },
            onExitApp: () =>
            {
                Dispatcher.InvokeAsync(ExitApplication);
            }
        );

        ViewModel.TelemetryUpdated += (history, used, total, load) =>
        {
            _trayService.UpdateTrayIcon(history, used, total, load);
        };

        ViewModel.MemoryFreedNotification += (title, message) =>
        {
            if (WindowState == WindowState.Minimized || !IsVisible)
            {
                _trayService.ShowNotification(title, message);
            }
        };

        InitializeComponent();

        // Push initial telemetry to tray icon
        _trayService.UpdateTrayIcon(ViewModel.History, ViewModel.UsedMemoryGB, ViewModel.TotalMemoryGB, ViewModel.MemoryPercentage);

        // Check if launched with --minimized startup argument
        string[] args = Environment.GetCommandLineArgs();
        if (args.Any(a => string.Equals(a, "--minimized", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(a, "-minimized", StringComparison.OrdinalIgnoreCase)))
        {
            WindowState = WindowState.Minimized;
            Visibility = Visibility.Hidden;
            ShowInTaskbar = false;
        }
    }

    protected override void OnStateChanged(EventArgs e)
    {
        if (WindowState == WindowState.Minimized)
        {
            Hide();
            ShowInTaskbar = false;
        }
        base.OnStateChanged(e);
    }

    public void RestoreFromTray()
    {
        Show();
        WindowState = WindowState.Normal;
        ShowInTaskbar = true;
        Activate();
        Focus();
    }

    public void ExitApplication()
    {
        _trayService.Dispose();
        System.Windows.Application.Current.Shutdown();
    }

    protected override void OnClosed(EventArgs e)
    {
        _trayService.Dispose();
        base.OnClosed(e);
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed && e.OriginalSource is not System.Windows.Controls.Primitives.ButtonBase)
        {
            try
            {
                DragMove();
            }
            catch
            {
            }
        }
    }
}