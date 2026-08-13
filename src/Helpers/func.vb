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
    ''' Queries Windows Management Instrumentation (WMI) to aggregate comprehensive system hardware specifications
    ''' including OS architecture, motherboard model, CPU cores/threads, memory module speeds, GPU VRAM, and storage drives.
    ''' </summary>
    ''' <returns>A formatted multi-line String containing system specifications.</returns>
    Function GetSpecs() As String
        If Not String.IsNullOrEmpty(_cachedSpecs) Then
            Return _cachedSpecs
        End If

        Dim sb As New System.Text.StringBuilder()

        sb.AppendLine("==================================")
        sb.AppendLine("                   SYSTEM SPECIFICATIONS                  ")
        sb.AppendLine("==================================" & vbNewLine)

        Dim scope As New ManagementScope("\\.\root\cimv2")

        ' OS Info
        Try
            Using osSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption, OSArchitecture, Version, BuildNumber FROM Win32_OperatingSystem"))
                Using osCollection As ManagementObjectCollection = osSearcher.Get()
                    For Each os As ManagementObject In osCollection
                        sb.AppendLine("  OS:           " & os("Caption") & " (" & os("OSArchitecture") & ")")
                        sb.AppendLine("  Version:      " & os("Version") & " (Build " & os("BuildNumber") & ")")
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
                        sb.AppendLine("  Motherboard:  " & mb("Manufacturer") & " " & mb("Product"))
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
                        Dim cores As String = If(cpu("NumberOfCores") IsNot Nothing, cpu("NumberOfCores").ToString() & " Cores / " & cpu("NumberOfLogicalProcessors").ToString() & " Threads", "")
                        sb.AppendLine("  Processor:    " & cpu("Name") & " [" & cores & "]")
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
                            sb.AppendLine("  Total RAM:    " & FormatBytes(CLng(sys("TotalPhysicalMemory"))))
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
                        Dim speed As String = If(mem("Speed") IsNot Nothing, mem("Speed").ToString() & " MHz", "")
                        sb.AppendLine("   └─ Stick #" & stickIndex & ": " & cap & " @ " & speed)
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
                        Dim vram As String = ""
                        If gpu("AdapterRAM") IsNot Nothing AndAlso CLng(gpu("AdapterRAM")) > 0 Then
                            vram = " (" & FormatBytes(CLng(gpu("AdapterRAM"))) & " VRAM)"
                        End If
                        Dim driver As String = If(gpu("DriverVersion") IsNot Nothing, " [Driver: " & gpu("DriverVersion").ToString() & "]", "")
                        sb.AppendLine("  Graphics:     " & gpu("Name") & vram & driver)
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        sb.AppendLine(vbNewLine & "==================================")
        sb.AppendLine("                   STORAGE & DISK DRIVES                  ")
        sb.AppendLine("==================================" & vbNewLine)

        Try
            Using driveSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption, Size, InterfaceType FROM Win32_DiskDrive"))
                Using driveCol As ManagementObjectCollection = driveSearcher.Get()
                    Dim driveIdx As Integer = 1
                    For Each drive As ManagementObject In driveCol
                        Dim sizeStr As String = "Unknown"
                        If drive("Size") IsNot Nothing Then
                            sizeStr = FormatBytes(CLng(drive("Size")))
                        End If
                        Dim interfaceType As String = If(drive("InterfaceType") IsNot Nothing, " [" & drive("InterfaceType").ToString() & "]", "")
                        sb.AppendLine("  Drive #" & driveIdx & ":       " & drive("Caption") & interfaceType & " - " & sizeStr)
                        driveIdx += 1
                    Next
                End Using
            End Using
        Catch ex As Exception
        End Try

        _cachedSpecs = sb.ToString()
        Return _cachedSpecs
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
End Class