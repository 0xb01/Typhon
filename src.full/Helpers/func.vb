Imports System.Management
Imports System.Runtime.Serialization

''' <summary>
''' Provides system information and hardware specification helper functions using WMI.
''' </summary>
Public Class func

    Private Shared _cachedSpecs As String = String.Empty

    ''' <summary>
    ''' Retrieves the name of the currently logged-in Windows user.
    ''' </summary>
    ''' <returns>The active user name as a String.</returns>
    Function GetPCName() As String
        Return Environment.UserName
    End Function

    ''' <summary>
    ''' Retrieves the full operating system title and version string.
    ''' </summary>
    ''' <returns>The OS full name as a String.</returns>
    Function GetOS() As String
        Return My.Computer.Info.OSFullName
    End Function

    ''' <summary>
    ''' Queries WMI to retrieve primary Graphics Card name string.
    ''' </summary>
    Function GetGPUName() As String
        Try
            Dim scope As New ManagementScope("\\.\root\cimv2")
            Using gpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_VideoController"))
                Using gpuCol As ManagementObjectCollection = gpuSearcher.Get()
                    For Each gpu As ManagementObject In gpuCol
                        If gpu("Name") IsNot Nothing Then
                            Dim nameStr As String = gpu("Name").ToString().Trim()
                            If Not String.IsNullOrEmpty(nameStr) Then Return nameStr
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return String.Empty
    End Function

    ''' <summary>
    ''' Formats total physical installed system RAM into human-readable string (e.g. 32 GB).
    ''' </summary>
    Function GetTotalRAM() As String
        Try
            Dim totalBytes As Long = CLng(My.Computer.Info.TotalPhysicalMemory)
            Dim gb As Double = totalBytes / (1024.0 * 1024.0 * 1024.0)
            Return Math.Round(gb).ToString() & " GB"
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Class SpecItem
        Property Category As String = ""
        Property Value As String = ""
        Property DrivePath As String = ""
    End Class

    Private Shared _cachedStructuredSpecs As List(Of SpecItem) = Nothing

    ''' <summary>
    ''' Clears cached system specifications to force re-querying hardware and peripherals.
    ''' </summary>
    Public Sub ClearSpecsCache()
        _cachedStructuredSpecs = Nothing
    End Sub

    ''' <summary>
    ''' Queries WMI to retrieve structured key-value pairs of system hardware specifications.
    ''' </summary>
    Function GetStructuredSpecs() As List(Of SpecItem)
        If _cachedStructuredSpecs IsNot Nothing Then
            Return _cachedStructuredSpecs
        End If

        Dim list As New List(Of SpecItem)()
        Dim scope As New ManagementScope("\\.\root\cimv2")

        ' OS Info
        Try
            Using osSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption, OSArchitecture, Version, BuildNumber FROM Win32_OperatingSystem"))
                Using osCollection As ManagementObjectCollection = osSearcher.Get()
                    For Each os As ManagementObject In osCollection
                        Dim osName As String = If(os("Caption") IsNot Nothing, os("Caption").ToString().Trim(), "Windows")
                        Dim osArch As String = If(os("OSArchitecture") IsNot Nothing, " (" & os("OSArchitecture").ToString() & ")", "")
                        Dim osVer As String = If(os("Version") IsNot Nothing, os("Version").ToString(), "")
                        Dim osBuild As String = If(os("BuildNumber") IsNot Nothing, " (Build " & os("BuildNumber").ToString() & ")", "")

                        list.Add(New SpecItem() With {.Category = "OS", .Value = osName & osArch})
                        list.Add(New SpecItem() With {.Category = "OS Version", .Value = osVer & osBuild})
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Motherboard Info
        Try
            Using mbSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Manufacturer, Product FROM Win32_BaseBoard"))
                Using mbCol As ManagementObjectCollection = mbSearcher.Get()
                    For Each mb As ManagementObject In mbCol
                        Dim mfg As String = If(mb("Manufacturer") IsNot Nothing, mb("Manufacturer").ToString().Trim(), "")
                        Dim prod As String = If(mb("Product") IsNot Nothing, mb("Product").ToString().Trim(), "")
                        list.Add(New SpecItem() With {.Category = "Motherboard", .Value = (mfg & " " & prod).Trim()})
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' CPU Info
        Try
            Using cpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name, NumberOfCores, NumberOfLogicalProcessors FROM Win32_Processor"))
                Using cpuCol As ManagementObjectCollection = cpuSearcher.Get()
                    For Each cpu As ManagementObject In cpuCol
                        Dim cpuName As String = If(cpu("Name") IsNot Nothing, cpu("Name").ToString().Trim(), "")
                        Dim cores As String = If(cpu("NumberOfCores") IsNot Nothing, " [" & cpu("NumberOfCores").ToString() & " Cores / " & cpu("NumberOfLogicalProcessors").ToString() & " Threads]", "")
                        list.Add(New SpecItem() With {.Category = "Processor", .Value = cpuName & cores})
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Memory Info
        Try
            Using sysSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem"))
                Using sysCol As ManagementObjectCollection = sysSearcher.Get()
                    For Each sys As ManagementObject In sysCol
                        If sys("TotalPhysicalMemory") IsNot Nothing Then
                            list.Add(New SpecItem() With {.Category = "Total RAM", .Value = FormatBytes(CLng(sys("TotalPhysicalMemory")))})
                        End If
                    Next
                End Using
            End Using

            ' Memory Modules
            Using memSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Capacity, Speed FROM Win32_PhysicalMemory"))
                Using memCol As ManagementObjectCollection = memSearcher.Get()
                    Dim stickIndex As Integer = 1
                    For Each mem As ManagementObject In memCol
                        Dim cap As String = FormatBytes(CLng(mem("Capacity")))
                        Dim speed As String = If(mem("Speed") IsNot Nothing, " @ " & mem("Speed").ToString() & " MHz", "")
                        list.Add(New SpecItem() With {.Category = "RAM Stick #" & stickIndex, .Value = cap & speed})
                        stickIndex += 1
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' GPU Info
        Try
            Using gpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name, DriverVersion, AdapterRAM FROM Win32_VideoController"))
                Using gpuCol As ManagementObjectCollection = gpuSearcher.Get()
                    For Each gpu As ManagementObject In gpuCol
                        Dim gpuName As String = If(gpu("Name") IsNot Nothing, gpu("Name").ToString().Trim(), "")
                        Dim vram As String = ""
                        If gpu("AdapterRAM") IsNot Nothing AndAlso CLng(gpu("AdapterRAM")) > 0 Then
                            vram = " (" & FormatBytes(CLng(gpu("AdapterRAM"))) & " VRAM)"
                        End If
                        list.Add(New SpecItem() With {.Category = "Graphics", .Value = gpuName & vram})
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Logical Storage Volumes
        Try
            For Each d As IO.DriveInfo In IO.DriveInfo.GetDrives()
                If d.IsReady Then
                    Dim label As String = If(Not String.IsNullOrEmpty(d.VolumeLabel), d.VolumeLabel & " ", "")
                    Dim valStr As String = label & "(" & FormatBytes(d.AvailableFreeSpace) & " free of " & FormatBytes(d.TotalSize) & ") [" & d.DriveFormat & "]"
                    list.Add(New SpecItem() With {
                        .Category = "Drive " & d.Name,
                        .Value = valStr,
                        .DrivePath = d.Name
                    })
                End If
            Next
        Catch ex As Exception
        End Try

        ' Physical Disk Drives
        Try
            Using driveSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption, Size, InterfaceType FROM Win32_DiskDrive"))
                Using driveCol As ManagementObjectCollection = driveSearcher.Get()
                    Dim driveIdx As Integer = 1
                    For Each drive As ManagementObject In driveCol
                        Dim model As String = If(drive("Caption") IsNot Nothing, drive("Caption").ToString().Trim(), "Disk Drive")
                        Dim sizeStr As String = If(drive("Size") IsNot Nothing, " (" & FormatBytes(CLng(drive("Size"))) & ")", "")
                        Dim interfaceType As String = If(drive("InterfaceType") IsNot Nothing, " [" & drive("InterfaceType").ToString() & "]", "")
                        list.Add(New SpecItem() With {.Category = "Disk #" & driveIdx, .Value = model & interfaceType & sizeStr})
                        driveIdx += 1
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Peripherals: Displays / Monitors
        Try
            Using monSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_PnPEntity WHERE PNPClass = 'Monitor'"))
                Using monCol As ManagementObjectCollection = monSearcher.Get()
                    Dim monIdx As Integer = 1
                    For Each mon As ManagementObject In monCol
                        If mon("Name") IsNot Nothing Then
                            Dim nameStr As String = mon("Name").ToString().Trim()
                            If Not String.IsNullOrEmpty(nameStr) Then
                                list.Add(New SpecItem() With {.Category = "Display #" & monIdx, .Value = nameStr})
                                monIdx += 1
                            End If
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Peripherals: Keyboards
        Try
            Using kbdSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Description, Name FROM Win32_Keyboard"))
                Using kbdCol As ManagementObjectCollection = kbdSearcher.Get()
                    Dim kbdIdx As Integer = 1
                    For Each kbd As ManagementObject In kbdCol
                        Dim nameStr As String = If(kbd("Description") IsNot Nothing, kbd("Description").ToString().Trim(), If(kbd("Name") IsNot Nothing, kbd("Name").ToString().Trim(), ""))
                        If Not String.IsNullOrEmpty(nameStr) Then
                            list.Add(New SpecItem() With {.Category = "Keyboard #" & kbdIdx, .Value = nameStr})
                            kbdIdx += 1
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Peripherals: Pointing Devices / Mice
        Try
            Using mouseSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Description, Name FROM Win32_PointingDevice"))
                Using mouseCol As ManagementObjectCollection = mouseSearcher.Get()
                    Dim mouseIdx As Integer = 1
                    For Each mouse As ManagementObject In mouseCol
                        Dim nameStr As String = If(mouse("Description") IsNot Nothing, mouse("Description").ToString().Trim(), If(mouse("Name") IsNot Nothing, mouse("Name").ToString().Trim(), ""))
                        If Not String.IsNullOrEmpty(nameStr) Then
                            list.Add(New SpecItem() With {.Category = "Mouse #" & mouseIdx, .Value = nameStr})
                            mouseIdx += 1
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Peripherals: Audio & Sound Devices
        Try
            Using soundSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_SoundDevice"))
                Using soundCol As ManagementObjectCollection = soundSearcher.Get()
                    Dim soundIdx As Integer = 1
                    For Each sound As ManagementObject In soundCol
                        If sound("Name") IsNot Nothing Then
                            Dim nameStr As String = sound("Name").ToString().Trim()
                            If Not String.IsNullOrEmpty(nameStr) Then
                                list.Add(New SpecItem() With {.Category = "Audio #" & soundIdx, .Value = nameStr})
                                soundIdx += 1
                            End If
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Peripherals: Webcams / Cameras
        Try
            Using camSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_PnPEntity WHERE PNPClass = 'Camera' OR PNPClass = 'Image'"))
                Using camCol As ManagementObjectCollection = camSearcher.Get()
                    Dim camIdx As Integer = 1
                    For Each cam As ManagementObject In camCol
                        If cam("Name") IsNot Nothing Then
                            Dim nameStr As String = cam("Name").ToString().Trim()
                            If Not String.IsNullOrEmpty(nameStr) Then
                                list.Add(New SpecItem() With {.Category = "Camera #" & camIdx, .Value = nameStr})
                                camIdx += 1
                            End If
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        _cachedStructuredSpecs = list
        Return _cachedStructuredSpecs
    End Function

    ''' <summary>
    ''' Formats structured specs into clean plain text for clipboard copying.
    ''' </summary>
    Function GetFormattedSpecsText() As String
        Dim items As List(Of SpecItem) = GetStructuredSpecs()
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("Typhon PC Booster - Hardware Specifications")
        sb.AppendLine("==========================================")
        For Each item In items
            sb.AppendLine(item.Category.PadRight(15) & ": " & item.Value)
        Next
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Queries Windows Management Instrumentation (WMI) to aggregate comprehensive system hardware specifications.
    ''' </summary>
    Function GetSpecs() As String
        Return GetFormattedSpecsText()
    End Function

    ''' <summary>
    ''' Converts raw byte counts into formatted byte size strings with appropriate units (B, KB, MB, GB, TB).
    ''' </summary>
    ''' <param name="bytes">Total bytes to format.</param>
    ''' <returns>Human-readable formatted byte string.</returns>
    Private Function FormatBytes(bytes As Long) As String
        Dim sizes() As String = {"B", "KB", "MB", "GB", "TB"}
        Dim dblBytes As Double = CDbl(bytes)
        Dim i As Integer = 0
        While dblBytes >= 1024.0 AndAlso i < sizes.Length - 1
            dblBytes /= 1024.0
            i += 1
        End While
        Return dblBytes.ToString("F2") & " " & sizes(i)
    End Function

    ''' <summary>
    ''' Constructs pcgamebenchmark.com detection handoff URL populated with processor name, GPU name(s), and total RAM in MB.
    ''' </summary>
    Function GetGameBenchmarkUrl() As String
        Dim cpuName As String = ""
        Dim gpus As New List(Of String)()
        Dim totalMemoryMB As Long = 0

        Dim scope As New ManagementScope("\\.\root\cimv2")

        ' CPU
        Try
            Using cpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_Processor"))
                Using cpuCol As ManagementObjectCollection = cpuSearcher.Get()
                    For Each cpu As ManagementObject In cpuCol
                        If cpu("Name") IsNot Nothing Then
                            cpuName = cpu("Name").ToString().Trim()
                            Exit For
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' GPUs
        Try
            Using gpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_VideoController"))
                Using gpuCol As ManagementObjectCollection = gpuSearcher.Get()
                    For Each gpu As ManagementObject In gpuCol
                        If gpu("Name") IsNot Nothing Then
                            Dim gName As String = gpu("Name").ToString().Trim()
                            If Not String.IsNullOrEmpty(gName) AndAlso Not gpus.Contains(gName) Then
                                gpus.Add(gName)
                            End If
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Total RAM in MB
        Try
            Dim totalBytes As Long = CLng(My.Computer.Info.TotalPhysicalMemory)
            totalMemoryMB = totalBytes \ (1024L * 1024L)
        Catch ex As Exception
        End Try

        Dim query As New List(Of String)()

        If Not String.IsNullOrEmpty(cpuName) Then
            query.Add("processor=" & Uri.EscapeDataString(cpuName))
        End If

        If gpus.Count > 0 Then
            Dim gpuCombined As String = String.Join("|", gpus.ToArray())
            query.Add("graphicsCards=" & Uri.EscapeDataString(gpuCombined))
        End If

        If totalMemoryMB > 0 Then
            query.Add("memorySize=" & totalMemoryMB.ToString())
        End If

        Return "https://www.pcgamebenchmark.com/detect/handoff/?" & String.Join("&", query.ToArray())
    End Function
End Class