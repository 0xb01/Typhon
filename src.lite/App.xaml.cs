using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Typhon.Lite;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private const string MutexName = @"Global\TyphonLite_SingleInstance_Mutex";
    private const string EventName = @"Global\TyphonLite_RestoreEvent";

    private static Mutex? _singleInstanceMutex;
    private static EventWaitHandle? _restoreEvent;

    protected override void OnStartup(StartupEventArgs e)
    {
        _singleInstanceMutex = new Mutex(true, MutexName, out bool isNewInstance);

        if (!isNewInstance)
        {
            // Second instance detected -> signal existing instance to restore, then exit
            try
            {
                if (EventWaitHandle.TryOpenExisting(EventName, out var existingEvent))
                {
                    existingEvent.Set();
                    existingEvent.Dispose();
                }
            }
            catch
            {
            }

            Shutdown();
            return;
        }

        // Primary instance -> listen for restore signals from duplicate launch attempts
        try
        {
            _restoreEvent = new EventWaitHandle(false, EventResetMode.AutoReset, EventName);
            Task.Run(() =>
            {
                while (_restoreEvent != null)
                {
                    try
                    {
                        if (_restoreEvent.WaitOne())
                        {
                            Dispatcher.Invoke(() =>
                            {
                                if (MainWindow is MainWindow win)
                                {
                                    win.RestoreFromTray();
                                }
                            });
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            });
        }
        catch
        {
        }

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _restoreEvent?.Dispose();
        _restoreEvent = null;

        if (_singleInstanceMutex != null)
        {
            try
            {
                _singleInstanceMutex.ReleaseMutex();
            }
            catch
            {
            }
            _singleInstanceMutex.Dispose();
            _singleInstanceMutex = null;
        }

        base.OnExit(e);
    }
}
