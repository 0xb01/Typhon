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
    ''' Queries Windows Management Instrumentation (WMI) to aggregate system specifications 
    ''' including OS, CPU, GPU, RAM, and attached storage drives. Caches results to prevent UI freezing.
    ''' </summary>
    ''' <returns>A formatted multi-line String containing system specifications.</returns>
    Function GetSpecs() As String
        If Not String.IsNullOrEmpty(_cachedSpecs) Then
            Return _cachedSpecs
        End If

        Dim systemInfo As New System.Text.StringBuilder()

        systemInfo.AppendLine("===== SPECS =====" & vbNewLine)

        Dim scope As New ManagementScope("\\.\root\cimv2")

        Using osSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption FROM Win32_OperatingSystem"))
            Using osCollection As ManagementObjectCollection = osSearcher.Get()
                For Each os As ManagementObject In osCollection
                    systemInfo.AppendLine("Operating System: " & os("Caption"))
                Next
            End Using
        End Using

        Using cpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_Processor"))
            Using cpuCollection As ManagementObjectCollection = cpuSearcher.Get()
                For Each cpu As ManagementObject In cpuCollection
                    systemInfo.AppendLine("Processor: " & cpu("Name"))
                Next
            End Using
        End Using

        Using gpuSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Name FROM Win32_VideoController"))
            Using gpuCollection As ManagementObjectCollection = gpuSearcher.Get()
                For Each gpu As ManagementObject In gpuCollection
                    systemInfo.AppendLine("Graphics Card: " & gpu("Name"))
                Next
            End Using
        End Using

        Using searcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT UserName, TotalPhysicalMemory FROM Win32_ComputerSystem"))
            Using queryCollection As ManagementObjectCollection = searcher.Get()
                For Each m As ManagementObject In queryCollection
                    systemInfo.AppendLine("User Name: " & m("UserName"))
                    If m("TotalPhysicalMemory") IsNot Nothing Then
                        systemInfo.AppendLine("Total Physical Memory (RAM): " & FormatBytes(CLng(m("TotalPhysicalMemory"))))
                    End If
                Next
            End Using
        End Using

        systemInfo.AppendLine(vbNewLine & "===== STORAGE =====" & vbNewLine)

        Using driveSearcher As New ManagementObjectSearcher(scope, New ObjectQuery("SELECT Caption, Size FROM Win32_DiskDrive"))
            Using driveCollection As ManagementObjectCollection = driveSearcher.Get()
                Dim drives As Integer = 1
                For Each drive As ManagementObject In driveCollection
                    Dim sizeStr As String = "Unknown"
                    If drive("Size") IsNot Nothing Then
                        sizeStr = FormatBytes(CLng(drive("Size")))
                    End If
                    systemInfo.AppendLine("Drive #" & drives & ": " & drive("Caption") & Space(1) & "(" & sizeStr & ")")
                    drives += 1
                Next
            End Using
        End Using

        _cachedSpecs = systemInfo.ToString()
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