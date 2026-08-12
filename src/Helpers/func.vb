Imports System.Management
Imports System.Runtime.Serialization

''' <summary>
''' Provides system information and hardware hardware specification helper functions using WMI.
''' </summary>
Public Class func

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
    ''' including OS, CPU, GPU, RAM, and attached storage drives.
    ''' </summary>
    ''' <returns>A formatted multi-line String containing system specifications.</returns>
    Function GetSpecs() As String
        Dim systemInfo As New System.Text.StringBuilder()

        systemInfo.AppendLine("===== SPECS =====" & vbNewLine)

        Dim scope As New ManagementScope("\\.\root\cimv2")

        Dim osQuery As New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
        Dim osSearcher As New ManagementObjectSearcher(scope, osQuery)
        Dim osCollection As ManagementObjectCollection = osSearcher.Get()

        For Each os As ManagementObject In osCollection
            systemInfo.AppendLine("Operating System: " & os("Caption"))
        Next

        Dim cpuQuery As New ObjectQuery("SELECT * FROM Win32_Processor")
        Dim cpuSearcher As New ManagementObjectSearcher(scope, cpuQuery)
        Dim cpuCollection As ManagementObjectCollection = cpuSearcher.Get()

        For Each cpu As ManagementObject In cpuCollection
            systemInfo.AppendLine("Processor: " & cpu("Name"))
        Next

        Dim gpuQuery As New ObjectQuery("SELECT * FROM Win32_VideoController")
        Dim gpuSearcher As New ManagementObjectSearcher(scope, gpuQuery)
        Dim gpuCollection As ManagementObjectCollection = gpuSearcher.Get()

        For Each gpu As ManagementObject In gpuCollection
            systemInfo.AppendLine("Graphics Card: " & gpu("Name"))
        Next

        Dim query As New ObjectQuery("SELECT * FROM Win32_ComputerSystem")
        Dim searcher As New ManagementObjectSearcher(scope, query)

        Dim queryCollection As ManagementObjectCollection = searcher.Get()

        For Each m As ManagementObject In queryCollection
            systemInfo.AppendLine("User Name: " & m("UserName"))
            systemInfo.AppendLine("Total Physical Memory (RAM): " & FormatBytes(CLng(m("TotalPhysicalMemory"))))
        Next

        systemInfo.AppendLine(vbNewLine & "===== STORAGE =====" & vbNewLine)

        Dim driveQuery As New ObjectQuery("SELECT * FROM Win32_DiskDrive")
        Dim driveSearcher As New ManagementObjectSearcher(scope, driveQuery)
        Dim driveCollection As ManagementObjectCollection = driveSearcher.Get()

        Dim drives As Integer = 1
        For Each drive As ManagementObject In driveCollection
            systemInfo.AppendLine("Drive #" & drives & ": " & drive("Caption") & Space(1) & "(" & FormatBytes(CLng(drive("Size"))) & ")")
            drives += 1
        Next

        Return systemInfo.ToString()
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