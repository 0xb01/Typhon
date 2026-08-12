Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

''' <summary>
''' Cleaner Options dialog allowing users to toggle and persist 13 target clean categories in clean_state.config.
''' </summary>
Public Class WinOptions

    Private Sub WinOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim config As Dictionary(Of String, Boolean) = cleaner.LoadConfig()

        chkTemp.Checked = If(config.ContainsKey("Temporary Files"), config("Temporary Files"), True)
        chkRecycle.Checked = If(config.ContainsKey("Recycle Bin"), config("Recycle Bin"), True)
        chkIncompat.Checked = If(config.ContainsKey("Incompatible Files"), config("Incompatible Files"), True)
        chkThumb.Checked = If(config.ContainsKey("Thumbnail Caches"), config("Thumbnail Caches"), True)
        chkGames.Checked = If(config.ContainsKey("Game Caches"), config("Game Caches"), True)
        chkFolderCfg.Checked = If(config.ContainsKey("Folder Config Files"), config("Folder Config Files"), True)
        chkCookies.Checked = If(config.ContainsKey("Internet Cookies"), config("Internet Cookies"), True)
        chkCache.Checked = If(config.ContainsKey("Internet Cache"), config("Internet Cache"), True)
        chkHistory.Checked = If(config.ContainsKey("Internet History"), config("Internet History"), True)
        chkLogs.Checked = If(config.ContainsKey("Windows Logs"), config("Windows Logs"), True)
        chkDumps.Checked = If(config.ContainsKey("Memory Dumps"), config("Memory Dumps"), True)
        chkRecent.Checked = If(config.ContainsKey("Recent Files"), config("Recent Files"), True)
        chkAppCache.Checked = If(config.ContainsKey("Application Caches"), config("Application Caches"), True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim config As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)

        config("Temporary Files") = chkTemp.Checked
        config("Recycle Bin") = chkRecycle.Checked
        config("Incompatible Files") = chkIncompat.Checked
        config("Thumbnail Caches") = chkThumb.Checked
        config("Game Caches") = chkGames.Checked
        config("Folder Config Files") = chkFolderCfg.Checked
        config("Internet Cookies") = chkCookies.Checked
        config("Internet Cache") = chkCache.Checked
        config("Internet History") = chkHistory.Checked
        config("Windows Logs") = chkLogs.Checked
        config("Memory Dumps") = chkDumps.Checked
        config("Recent Files") = chkRecent.Checked
        config("Application Caches") = chkAppCache.Checked

        cleaner.SaveConfig(config)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
