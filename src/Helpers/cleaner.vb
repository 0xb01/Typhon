Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Runtime.InteropServices

''' <summary>
''' Full-fledged system cleaner supporting 13 customizable target categories across selected system drives,
''' with persistent clean_state.config settings stored in AppData.
''' </summary>
Public Class cleaner

    ''' <summary>
    ''' Win32 P/Invoke to empty Windows Recycle Bin.
    ''' </summary>
    <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function SHEmptyRecycleBin( _
        ByVal hwnd As IntPtr, _
        ByVal pszRootPath As String, _
        ByVal dwFlags As UInteger) As Integer
    End Function

    Public Const SHERB_NOCONFIRMATION As UInteger = &H1
    Public Const SHERB_NOPROGRESSUI As UInteger = &H2
    Public Const SHERB_NOSOUND As UInteger = &H4

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Private Structure WIN32_FILE_ATTRIBUTE_DATA
        Public dwFileAttributes As UInteger
        Public ftCreationTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public ftLastAccessTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public ftLastWriteTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public nFileSizeHigh As UInteger
        Public nFileSizeLow As UInteger
    End Structure

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function GetFileAttributesEx( _
        ByVal lpFileName As String, _
        ByVal fInfoLevelId As Integer, _
        ByRef lpFileInformation As WIN32_FILE_ATTRIBUTE_DATA) As Boolean
    End Function

    ''' <summary>
    ''' Fast Win32 file size lookup that reads directory table entries without taking file locks or throwing security exceptions.
    ''' </summary>
    Public Shared Function GetFileSizeFast(filePath As String) As Long
        Try
            Dim data As New WIN32_FILE_ATTRIBUTE_DATA()
            If GetFileAttributesEx(filePath, 0, data) Then
                Return (CLng(data.nFileSizeHigh) * 4294967296L) + CLng(data.nFileSizeLow)
            End If
        Catch ex As Exception
        End Try

        Try
            Dim fi As New FileInfo(filePath)
            Return fi.Length
        Catch ex As Exception
        End Try

        Return 0
    End Function

    ''' <summary>
    ''' Represents a detailed scanned file item with filename, size, category type, absolute path, and exact byte length.
    ''' </summary>
    Public Class CleanItem
        Public Property FileName As String
        Public Property FormattedSize As String
        Public Property CategoryName As String
        Public Property FilePath As String
        Public Property ByteSize As Long

        Public Sub New(fileName As String, formattedSize As String, categoryName As String, filePath As String, Optional byteSize As Long = 0)
            Me.FileName = fileName
            Me.FormattedSize = formattedSize
            Me.CategoryName = categoryName
            Me.FilePath = filePath
            Me.ByteSize = byteSize
        End Sub
    End Class

    ''' <summary>
    ''' Represents a category scan item with target path, description, and file search pattern.
    ''' </summary>
    Public Class CleanCategory
        Public Property Name As String
        Public Property Path As String
        Public Property SearchPatterns As String()
        Public Property Recursive As Boolean

        Public Sub New(name As String, path As String, patterns() As String, Optional recursive As Boolean = False)
            Me.Name = name
            Me.Path = path
            Me.SearchPatterns = patterns
            Me.Recursive = recursive
        End Sub
    End Class

    ''' <summary>
    ''' Returns absolute path to clean_state.config file in AppData\Typhon directory.
    ''' </summary>
    Public Shared Function GetConfigFilePath() As String
        Dim dirPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Typhon")
        If Not Directory.Exists(dirPath) Then
            Directory.CreateDirectory(dirPath)
        End If
        Return Path.Combine(dirPath, "clean_state.config")
    End Function

    ''' <summary>
    ''' Gets all 13 standard category names supported by the cleaner.
    ''' </summary>
    Public Shared ReadOnly Property StandardCategoryNames As String()
        Get
            Return New String() {
                "Temporary Files",
                "Recycle Bin",
                "Incompatible Files",
                "Thumbnail Caches",
                "Game Caches",
                "Folder Config Files",
                "Internet Cookies",
                "Internet Cache",
                "Internet History",
                "Windows Logs",
                "Memory Dumps",
                "Recent Files",
                "Application Caches",
                "Windows Update Cache",
                "GPU Driver Cache",
                "Dev Package Caches"
            }
        End Get
    End Property

    ''' <summary>
    ''' Loads enabled category states from clean_state.config file. Defaults all to True if config missing.
    ''' </summary>
    Public Shared Function LoadConfig() As Dictionary(Of String, Boolean)
        Dim config As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)

        Dim defaultFalseCategories As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
            "Game Caches",
            "Folder Config Files",
            "Internet Cookies",
            "Application Caches",
            "GPU Driver Cache",
            "Dev Package Caches"
        }

        For Each catName As String In StandardCategoryNames
            config(catName) = Not defaultFalseCategories.Contains(catName)
        Next

        Try
            Dim cfgPath As String = GetConfigFilePath()
            If File.Exists(cfgPath) Then
                Dim lines() As String = File.ReadAllLines(cfgPath)
                For Each line As String In lines
                    If String.IsNullOrWhiteSpace(line) OrElse Not line.Contains("=") Then Continue For
                    Dim parts() As String = line.Split("="c)
                    If parts.Length >= 2 Then
                        Dim key As String = parts(0).Trim()
                        Dim val As Boolean
                        If Boolean.TryParse(parts(1).Trim(), val) Then
                            config(key) = val
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ' Fallback to default True configuration on read error
        End Try

        Return config
    End Function

    ''' <summary>
    ''' Saves selected category states to clean_state.config file in AppData.
    ''' </summary>
    Public Shared Sub SaveConfig(config As Dictionary(Of String, Boolean))
        Try
            Dim cfgPath As String = GetConfigFilePath()
            Dim lines As New List(Of String)()
            For Each kvp In config
                lines.Add(kvp.Key & "=" & kvp.Value.ToString())
            Next
            File.WriteAllLines(cfgPath, lines.ToArray())
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Gets the list of active cleaning targets for all enabled categories across selected drive roots.
    ''' </summary>
    Public Shared Function GetCategories(selectedDrives As List(Of String), config As Dictionary(Of String, Boolean)) As List(Of CleanCategory)
        Dim categories As New List(Of CleanCategory)()

        Dim localAppData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim windir As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)

        If selectedDrives Is Nothing OrElse selectedDrives.Count = 0 Then
            selectedDrives = New List(Of String) From {"C:\"}
        End If

        ' 1. Temporary Files
        If config.ContainsKey("Temporary Files") AndAlso config("Temporary Files") Then
            categories.Add(New CleanCategory("Temporary Files", Path.GetTempPath(), {"*.tmp", "*.log", "*.bak", "*.old", "*.chk"}, True))
            categories.Add(New CleanCategory("Windows Temp", Path.Combine(windir, "Temp"), {"*.*"}, True))

            For Each drv As String In selectedDrives
                Dim tempSubDir As String = Path.Combine(drv, "Temp")
                If Directory.Exists(tempSubDir) Then
                    categories.Add(New CleanCategory("Drive Temp (" & drv.TrimEnd("\"c) & ")", tempSubDir, {"*.tmp", "*.log", "*.bak", "*.old", "*.chk"}, True))
                End If
                categories.Add(New CleanCategory("Drive Root Temp (" & drv.TrimEnd("\"c) & ")", drv, {"*.tmp", "*.bak", "*.old", "*.chk"}, False))
            Next
        End If

        ' 2. Recycle Bin
        If config.ContainsKey("Recycle Bin") AndAlso config("Recycle Bin") Then
            For Each drv As String In selectedDrives
                categories.Add(New CleanCategory("Recycle Bin (" & drv.TrimEnd("\"c) & ")", Path.Combine(drv, "$Recycle.Bin"), {"*.*"}, True))
                categories.Add(New CleanCategory("Recycle Bin (" & drv.TrimEnd("\"c) & ")", Path.Combine(drv, "RECYCLER"), {"*.*"}, True))
            Next
        End If

        ' 3. Incompatible Files
        If config.ContainsKey("Incompatible Files") AndAlso config("Incompatible Files") Then
            categories.Add(New CleanCategory("Crash Dumps", Path.Combine(localAppData, "CrashDumps"), {"*.dmp", "*.hdmp"}, True))
            categories.Add(New CleanCategory("Windows Error Reporting", "C:\ProgramData\Microsoft\Windows\WER", {"*.*"}, True))
        End If

        ' 4. Thumbnail Caches
        If config.ContainsKey("Thumbnail Caches") AndAlso config("Thumbnail Caches") Then
            categories.Add(New CleanCategory("Thumbnail Caches", Path.Combine(localAppData, "Microsoft\Windows\Explorer"), {"thumbcache_*.db", "iconcache_*.db"}, False))
        End If

        ' 5. Game Caches
        If config.ContainsKey("Game Caches") AndAlso config("Game Caches") Then
            categories.Add(New CleanCategory("Steam Web Cache", Path.Combine(localAppData, "Steam\htmlcache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Epic Games Cache", Path.Combine(localAppData, "EpicGamesLauncher\Saved\webcache"), {"*.*"}, True))
            categories.Add(New CleanCategory("DirectX Shader Cache", Path.Combine(localAppData, "D3DSCache"), {"*.*"}, True))
        End If

        ' 6. Folder Config Files
        If config.ContainsKey("Folder Config Files") AndAlso config("Folder Config Files") Then
            For Each drv As String In selectedDrives
                categories.Add(New CleanCategory("Folder Config Files (" & drv.TrimEnd("\"c) & ")", drv, {"desktop.ini", "Thumbs.db"}, True))
            Next
        End If

        ' 7. Internet Cookies
        If config.ContainsKey("Internet Cookies") AndAlso config("Internet Cookies") Then
            categories.Add(New CleanCategory("INet Cookies", Path.Combine(localAppData, "Microsoft\Windows\INetCookies"), {"*.*"}, True))
            categories.Add(New CleanCategory("Chrome Cookies", Path.Combine(localAppData, "Google\Chrome\User Data\Default\Network"), {"Cookies*"}, False))
        End If

        ' 8. Internet Cache
        If config.ContainsKey("Internet Cache") AndAlso config("Internet Cache") Then
            categories.Add(New CleanCategory("INetCache", Path.Combine(localAppData, "Microsoft\Windows\INetCache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Chrome Cache", Path.Combine(localAppData, "Google\Chrome\User Data\Default\Cache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Edge Cache", Path.Combine(localAppData, "Microsoft\Edge\User Data\Default\Cache"), {"*.*"}, True))
        End If

        ' 9. Internet History
        If config.ContainsKey("Internet History") AndAlso config("Internet History") Then
            categories.Add(New CleanCategory("INet History", Path.Combine(localAppData, "Microsoft\Windows\History"), {"*.*"}, True))
            categories.Add(New CleanCategory("INet WebCache", Path.Combine(localAppData, "Microsoft\Windows\WebCache"), {"*.*"}, False))
        End If

        ' 10. Windows Logs
        If config.ContainsKey("Windows Logs") AndAlso config("Windows Logs") Then
            categories.Add(New CleanCategory("Windows Logs", windir, {"*.log"}, False))
            categories.Add(New CleanCategory("Windows Log Directory", Path.Combine(windir, "Logs"), {"*.*"}, True))
            categories.Add(New CleanCategory("Windows Prefetch", Path.Combine(windir, "Prefetch"), {"*.pf", "*.log"}, False))
            For Each drv As String In selectedDrives
                categories.Add(New CleanCategory("Drive Logs (" & drv.TrimEnd("\"c) & ")", drv, {"*.log"}, False))
            Next
        End If

        ' 11. Memory Dumps
        If config.ContainsKey("Memory Dumps") AndAlso config("Memory Dumps") Then
            categories.Add(New CleanCategory("System Memory Dump", windir, {"MEMORY.DMP"}, False))
            categories.Add(New CleanCategory("Minidump Files", Path.Combine(windir, "Minidump"), {"*.dmp"}, True))
        End If

        ' 12. Recent Files
        If config.ContainsKey("Recent Files") AndAlso config("Recent Files") Then
            categories.Add(New CleanCategory("Recent Files", Path.Combine(appData, "Microsoft\Windows\Recent"), {"*.lnk", "*.*"}, True))
        End If

        ' 13. Application Caches
        If config.ContainsKey("Application Caches") AndAlso config("Application Caches") Then
            categories.Add(New CleanCategory("Discord Cache", Path.Combine(localAppData, "Discord\Cache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Spotify Cache", Path.Combine(localAppData, "Spotify\Storage"), {"*.*"}, True))
            categories.Add(New CleanCategory("Adobe Media Cache", Path.Combine(appData, "Adobe\Common\Media Cache Files"), {"*.*"}, True))
        End If

        ' 14. Windows Update Cache
        If config.ContainsKey("Windows Update Cache") AndAlso config("Windows Update Cache") Then
            categories.Add(New CleanCategory("Windows Update Download", Path.Combine(windir, "SoftwareDistribution\Download"), {"*.*"}, True))
        End If

        ' 15. GPU Driver Cache
        If config.ContainsKey("GPU Driver Cache") AndAlso config("GPU Driver Cache") Then
            categories.Add(New CleanCategory("NVIDIA DXCache", Path.Combine(localAppData, "NVIDIA\DXCache"), {"*.*"}, True))
            categories.Add(New CleanCategory("NVIDIA GLCache", Path.Combine(localAppData, "NVIDIA\GLCache"), {"*.*"}, True))
            categories.Add(New CleanCategory("AMD DxCache", Path.Combine(localAppData, "AMD\DxCache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Intel ShaderCache", Path.Combine(localAppData, "Intel\ShaderCache"), {"*.*"}, True))
        End If

        ' 16. Dev Package Caches
        If config.ContainsKey("Dev Package Caches") AndAlso config("Dev Package Caches") Then
            categories.Add(New CleanCategory("Pip Cache", Path.Combine(localAppData, "pip\Cache"), {"*.*"}, True))
            categories.Add(New CleanCategory("Npm Cache", Path.Combine(localAppData, "npm-cache"), {"*.*"}, True))
            Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            categories.Add(New CleanCategory("NuGet Scratch Cache", Path.Combine(userProfile, ".nuget\packages"), {"*.tmp", "*.log"}, True))
        End If

        Return categories
    End Function

    Public Shared Function FormatBytes(bytes As Long) As String
        Dim sizes() As String = {"B", "KB", "MB", "GB", "TB"}
        Dim dblBytes As Double = CDbl(bytes)
        Dim i As Integer = 0
        While dblBytes >= 1024.0 AndAlso i < sizes.Length - 1
            dblBytes /= 1024.0
            i += 1
        End While
        Return dblBytes.ToString("F1") & " " & sizes(i)
    End Function

    ''' <summary>
    ''' Safely enumerates files in a directory tree without crashing on UnauthorizedAccessException or locked system folders.
    ''' Periodically reports visited subdirectories with directory count to keep UI alive and calculate smooth progress.
    ''' </summary>
    Private Shared Iterator Function SafeEnumerateFiles(rootPath As String, patterns() As String, recursive As Boolean, dirVisitedCallback As Action(Of String, Integer), cancelCheck As Func(Of Boolean)) As IEnumerable(Of String)
        Dim dirsToVisit As New Queue(Of String)()
        dirsToVisit.Enqueue(rootPath)
        Dim dirCounter As Integer = 0

        While dirsToVisit.Count > 0
            If cancelCheck IsNot Nothing AndAlso cancelCheck() Then Exit Function

            Dim currentDir As String = dirsToVisit.Dequeue()
            dirCounter += 1

            If dirCounter Mod 25 = 0 AndAlso dirVisitedCallback IsNot Nothing Then
                dirVisitedCallback(currentDir, dirCounter)
            End If

            If recursive Then
                Try
                    Dim subDirs() As String = Directory.GetDirectories(currentDir)
                    For Each sd As String In subDirs
                        Try
                            Dim di As New DirectoryInfo(sd)
                            If Not di.Attributes.HasFlag(FileAttributes.ReparsePoint) Then
                                dirsToVisit.Enqueue(sd)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            End If

            For Each pattern As String In patterns
                If cancelCheck IsNot Nothing AndAlso cancelCheck() Then Exit Function
                Dim files() As String = Nothing
                Try
                    files = Directory.GetFiles(currentDir, pattern, SearchOption.TopDirectoryOnly)
                Catch ex As Exception
                End Try

                If files IsNot Nothing Then
                    For Each f As String In files
                        Yield f
                    Next
                End If
            Next
        End While
    End Function

    ''' <summary>
    ''' Scans active categories across selected system drives and returns detailed CleanItem objects (Filename, Size, Type, Path),
    ''' streaming each found item via itemFoundCallback in real time.
    ''' </summary>
    Public Shared Function ScanDetailedFiles(selectedDrives As List(Of String), config As Dictionary(Of String, Boolean), progressCallback As Action(Of Integer, Integer, String), Optional itemFoundCallback As Action(Of CleanItem) = Nothing, Optional cancelCheck As Func(Of Boolean) = Nothing) As List(Of CleanItem)
        Dim itemsList As New List(Of CleanItem)()
        Dim seenPaths As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim categories As List(Of CleanCategory) = GetCategories(selectedDrives, config)
        Dim total As Integer = categories.Count

        For i As Integer = 0 To total - 1
            If cancelCheck IsNot Nothing AndAlso cancelCheck() Then Exit For

            Dim cat As CleanCategory = categories(i)
            Dim catIndex As Integer = i
            Dim initPct As Integer = CInt((catIndex / CDbl(total)) * 100.0)
            If progressCallback IsNot Nothing Then
                progressCallback(initPct, 100, "Scanning: " & cat.Name)
            End If

            Try
                If Directory.Exists(cat.Path) Then
                    For Each f As String In SafeEnumerateFiles(cat.Path, cat.SearchPatterns, cat.Recursive, Sub(currentDir, dirCount)
                                                                                                                If progressCallback IsNot Nothing Then
                                                                                                                    Dim subProgress As Double = Math.Min(0.95, dirCount / (dirCount + 100.0))
                                                                                                                    Dim smoothPct As Integer = CInt(Math.Min(99.0, (((catIndex + subProgress) / CDbl(total)) * 100.0)))
                                                                                                                    progressCallback(smoothPct, 100, currentDir)
                                                                                                                End If
                                                                                                            End Sub, cancelCheck)
                        If cancelCheck IsNot Nothing AndAlso cancelCheck() Then Exit For
                        If Not seenPaths.Contains(f) Then
                            seenPaths.Add(f)
                            Dim fName As String = Path.GetFileName(f)
                            Dim fileLen As Long = GetFileSizeFast(f)
                            Dim sizeStr As String = FormatBytes(fileLen)
                            Dim cleanObj As New CleanItem(fName, sizeStr, cat.Name, f, fileLen)
                            itemsList.Add(cleanObj)
                            If itemFoundCallback IsNot Nothing Then
                                itemFoundCallback(cleanObj)
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                ' Skip inaccessible root category
            End Try
        Next

        If progressCallback IsNot Nothing Then
            progressCallback(100, 100, "Scan complete. Found " & itemsList.Count & " items.")
        End If

        Return itemsList
    End Function

    ''' <summary>
    ''' Deletes detailed scanned items and empties Windows Recycle Bin, updating progress callbacks.
    ''' </summary>
    Public Shared Function CleanDetailedFiles(items As List(Of CleanItem), progressCallback As Action(Of Integer, Integer, String)) As Integer
        Dim cleanedCount As Integer = 0
        Dim total As Integer = items.Count

        ' Empty Recycle Bin via Shell API
        Try
            SHEmptyRecycleBin(IntPtr.Zero, Nothing, SHERB_NOCONFIRMATION Or SHERB_NOPROGRESSUI Or SHERB_NOSOUND)
        Catch ex As Exception
            ' Fallback if shell API is restricted
        End Try

        If total = 0 Then
            If progressCallback IsNot Nothing Then
                progressCallback(100, 100, "Clean complete.")
            End If
            Return 0
        End If

        For i As Integer = 0 To total - 1
            Dim item As CleanItem = items(i)
            If progressCallback IsNot Nothing AndAlso (i Mod 50 = 0 OrElse i = total - 1) Then
                progressCallback(i + 1, total, "Cleaning item " & (i + 1) & " of " & total)
            End If

            Try
                If File.Exists(item.FilePath) Then
                    File.Delete(item.FilePath)
                    cleanedCount += 1
                End If
            Catch ex As Exception
                ' Skip locked or in-use files
            End Try
        Next

        If progressCallback IsNot Nothing Then
            progressCallback(total, total, "Cleaned " & cleanedCount & " of " & total & " items.")
        End If

        Return cleanedCount
    End Function
End Class
