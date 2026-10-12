using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Typhon.Lite.Services;

public class TrayService : IDisposable
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool DestroyIcon(IntPtr hIcon);

    private readonly NotifyIcon _notifyIcon;
    private readonly Action _onFreeMemory;
    private readonly Action _onRestoreWindow;
    private readonly Action _onExitApp;

    private DispatcherTimer? _clickTimer;
    private IntPtr _currentHIcon = IntPtr.Zero;
    private bool _isDisposed;

    public TrayService(Action onFreeMemory, Action onRestoreWindow, Action onExitApp)
    {
        _onFreeMemory = onFreeMemory;
        _onRestoreWindow = onRestoreWindow;
        _onExitApp = onExitApp;

        var contextMenu = new ContextMenuStrip();
        var openItem = new ToolStripMenuItem("Open Typhon Lite", null, (s, e) => _onRestoreWindow())
        {
            Font = new Font("Segoe UI", 9f, FontStyle.Bold)
        };
        contextMenu.Items.Add(openItem);
        contextMenu.Items.Add(new ToolStripMenuItem("Free Memory", null, (s, e) => _onFreeMemory()));
        contextMenu.Items.Add(new ToolStripSeparator());
        contextMenu.Items.Add(new ToolStripMenuItem("Exit", null, (s, e) => _onExitApp()));

        _notifyIcon = new NotifyIcon
        {
            Visible = true,
            Text = "Typhon Lite",
            ContextMenuStrip = contextMenu
        };

        _notifyIcon.MouseClick += OnTrayMouseClick;
        _notifyIcon.DoubleClick += OnTrayDoubleClick;
    }

    private void OnTrayMouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _clickTimer?.Stop();
            _clickTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime + 30)
            };
            _clickTimer.Tick += (s, args) =>
            {
                _clickTimer.Stop();
                _clickTimer = null;
                // Single-click -> Free memory
                _onFreeMemory();
            };
            _clickTimer.Start();
        }
    }

    private void OnTrayDoubleClick(object? sender, EventArgs e)
    {
        _clickTimer?.Stop();
        _clickTimer = null;
        // Double-click -> Open app
        _onRestoreWindow();
    }

    public void UpdateTrayIcon(IReadOnlyList<double> history, double usedGB, double totalGB, uint loadPercent)
    {
        if (_isDisposed) return;

        try
        {
            double exactPercent = totalGB > 0 ? (usedGB / totalGB * 100.0) : (double)loadPercent;
            IntPtr newHIcon = CreateGraphIconHandle(history, exactPercent);
            if (newHIcon == IntPtr.Zero) return;

            Icon newIcon = Icon.FromHandle(newHIcon);

            IntPtr oldHIcon = _currentHIcon;
            _currentHIcon = newHIcon;

            _notifyIcon.Icon = newIcon;

            // Safely clean up previous icon handle now that new icon is applied
            if (oldHIcon != IntPtr.Zero)
            {
                DestroyIcon(oldHIcon);
            }

            string tooltip = $"Typhon: {usedGB:F1} GB/{totalGB:F1} GB ({loadPercent}%)";
            if (tooltip.Length >= 64)
            {
                tooltip = $"{usedGB:F1} GB/{totalGB:F1} GB ({loadPercent}%)";
            }
            _notifyIcon.Text = tooltip;
        }
        catch
        {
        }
    }

    public void ShowNotification(string title, string message)
    {
        if (_isDisposed) return;
        try
        {
            _notifyIcon.ShowBalloonTip(2000, title, message, ToolTipIcon.Info);
        }
        catch
        {
        }
    }

    /// <summary>
    /// Generates a crisp pixel-perfect 16x16 scrolling memory graph for the Windows system tray.
    /// Updates dynamically every second with scrolling historical columns and live head indicator.
    /// </summary>
    private static IntPtr CreateGraphIconHandle(IReadOnlyList<double> history, double currentPercent)
    {
        const int size = 16;
        using var bitmap = new Bitmap(size, size, PixelFormat.Format32bppPArgb);
        using var g = Graphics.FromImage(bitmap);
        g.SmoothingMode = SmoothingMode.None;

        // Dark slate background
        using (var bgBrush = new SolidBrush(Color.FromArgb(255, 10, 15, 26)))
        {
            g.FillRectangle(bgBrush, 0, 0, size, size);
        }

        // 1px border
        using (var borderPen = new Pen(Color.FromArgb(255, 30, 41, 59), 1f))
        {
            g.DrawRectangle(borderPen, 0, 0, size - 1, size - 1);
        }

        int count = history.Count;
        int colCount = 12; // 12 historical columns (x: 2..13)
        int startIndex = Math.Max(0, count - colCount);

        for (int i = 0; i < colCount; i++)
        {
            int histIndex = startIndex + i;
            double val = histIndex < count ? history[histIndex] : currentPercent;
            val = Math.Clamp(val, 0.0, 100.0);

            // Bar height: 1 to 11 pixels (y: 13 down to 3)
            int barHeight = Math.Max(1, (int)Math.Round((val / 100.0) * 10.0) + 1);
            int x = 2 + i;
            int topY = 13 - barHeight + 1;

            // Draw vertical column with gradient and highlighted tip
            for (int y = 13; y >= topY; y--)
            {
                float ratio = (float)(13 - y) / Math.Max(1, barHeight);
                Color col;
                if (y == topY)
                {
                    // Top ridge pixel: live sample on right is bright white; history is neon cyan
                    col = (i == colCount - 1)
                        ? Color.FromArgb(255, 255, 255, 255)
                        : Color.FromArgb(255, 56, 189, 248);
                }
                else
                {
                    // Gradient body: emerald green to deep teal
                    int r = (int)(5 * (1 - ratio) + 0 * ratio);
                    int gVal = (int)(140 * (1 - ratio) + 230 * ratio);
                    int b = (int)(110 * (1 - ratio) + 250 * ratio);
                    col = Color.FromArgb(255, Math.Clamp(r, 0, 255), Math.Clamp(gVal, 0, 255), Math.Clamp(b, 0, 255));
                }

                bitmap.SetPixel(x, y, col);
            }
        }

        // Live heartbeat status dot at top right
        bitmap.SetPixel(14, 1, Color.FromArgb(255, 52, 211, 153));

        return bitmap.GetHicon();
    }

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        _clickTimer?.Stop();
        _notifyIcon.Visible = false;
        _notifyIcon.Dispose();

        if (_currentHIcon != IntPtr.Zero)
        {
            DestroyIcon(_currentHIcon);
            _currentHIcon = IntPtr.Zero;
        }
    }
}
