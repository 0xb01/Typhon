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
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool DestroyIcon(IntPtr handle);

    private readonly NotifyIcon _notifyIcon;
    private readonly Action _onFreeMemory;
    private readonly Action _onRestoreWindow;
    private readonly Action _onExitApp;

    private DispatcherTimer? _clickTimer;
    private Icon? _currentIcon;
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
            Icon newIcon = CreateGraphIcon(history, loadPercent);
            Icon? oldIcon = _currentIcon;

            _notifyIcon.Icon = newIcon;
            _currentIcon = newIcon;

            oldIcon?.Dispose();

            string tooltip = $"Typhon: {usedGB:F1}/{totalGB:F1}GB ({loadPercent}%)\n1-Click: Free | 2-Click: Open";
            if (tooltip.Length >= 64)
            {
                tooltip = $"Typhon: {usedGB:F1}/{totalGB:F1}GB ({loadPercent}%)";
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

    private static Icon CreateGraphIcon(IReadOnlyList<double> history, uint currentPercent)
    {
        const int size = 32;
        using var bitmap = new Bitmap(size, size, PixelFormat.Format32bppPArgb);
        using var g = Graphics.FromImage(bitmap);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Dark background with slate/zinc tone
        using (var bgBrush = new SolidBrush(Color.FromArgb(250, 15, 23, 42)))
        {
            g.FillRectangle(bgBrush, 0, 0, size, size);
        }

        // Draw subtle accent border
        using (var borderPen = new Pen(Color.FromArgb(100, 56, 189, 248), 1f))
        {
            g.DrawRectangle(borderPen, 0, 0, size - 1, size - 1);
        }

        int count = history.Count;
        if (count >= 2)
        {
            int displayCount = Math.Min(count, 14);
            var points = new PointF[displayCount + 2];
            float stepX = (float)(size - 4) / (displayCount - 1);

            int startIndex = count - displayCount;
            for (int i = 0; i < displayCount; i++)
            {
                double val = Math.Clamp(history[startIndex + i], 0.0, 100.0);
                float y = (size - 3) - (float)(val / 100.0 * (size - 7)) - 1;
                points[i] = new PointF(2 + i * stepX, y);
            }

            // Close polygon at the bottom
            points[displayCount] = new PointF(size - 2, size - 2);
            points[displayCount + 1] = new PointF(2, size - 2);

            // Glowing area fill
            using (var fillBrush = new LinearGradientBrush(
                new PointF(0, 0),
                new PointF(0, size),
                Color.FromArgb(220, 0, 229, 255),
                Color.FromArgb(90, 16, 185, 129)))
            {
                g.FillPolygon(fillBrush, points);
            }

            // Ridge line
            var linePoints = new PointF[displayCount];
            Array.Copy(points, linePoints, displayCount);
            using (var pen = new Pen(Color.FromArgb(255, 125, 211, 252), 1.6f))
            {
                g.DrawLines(pen, linePoints);
            }
        }
        else
        {
            float barH = (float)(currentPercent / 100.0 * (size - 6));
            using var fill = new SolidBrush(Color.FromArgb(0, 229, 255));
            g.FillRectangle(fill, 4, size - 3 - barH, size - 8, barH);
        }

        IntPtr hIcon = bitmap.GetHicon();
        Icon icon = (Icon)Icon.FromHandle(hIcon).Clone();
        DestroyIcon(hIcon);
        return icon;
    }

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        _clickTimer?.Stop();
        _notifyIcon.Visible = false;
        _notifyIcon.Dispose();
        _currentIcon?.Dispose();
    }
}
