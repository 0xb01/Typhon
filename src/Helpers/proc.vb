Imports System
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Collections.Specialized

''' <summary>
''' Provides process management, memory optimization, and native Win32 P/Invoke functions.
''' </summary>
Public Class proc

    ''' <summary>
    ''' Queries MS-DOS device names mapped to physical drive paths.
    ''' </summary>
    <DllImport("kernel32.dll", EntryPoint:="QueryDosDevice")> _
    Shared Function DosDevice( _
        ByVal name As String, _
        ByVal path As StringBuilder, _
        ByVal length As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Retrieves the full device file path for the specified process handle.
    ''' </summary>
    <DllImport("psapi.dll", EntryPoint:="GetProcessImageFileName")> _
    Shared Function ProcessFileName( _
        ByVal handle As IntPtr, _
        ByVal name As StringBuilder, _
        ByVal size As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Sets minimum and maximum working set sizes for a process. Passing (-1, -1) forces memory trimming.
    ''' </summary>
    <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize")> _
    Shared Function SetWorkingSet( _
        ByVal handle As IntPtr, _
        ByVal minimum As IntPtr, _
        ByVal maximum As IntPtr) As Boolean
    End Function

    ''' <summary>
    ''' Resolves the full file system path for a process handle by mapping DOS device paths.
    ''' </summary>
    ''' <param name="handle">Process handle pointer.</param>
    ''' <returns>Full executable file path as a String.</returns>
    Private Function ProcessHandle(ByVal handle As IntPtr) As String
        Dim rawName As New StringBuilder(512)
        If ProcessFileName(handle, rawName, 512) > 0 Then
            Dim procStr As String = rawName.ToString
            For Each drv As String In Environment.GetLogicalDrives
                If DosDevice(drv.Substring(0, 2), rawName, 512) > 0 Then
                    If procStr.StartsWith(rawName.ToString, StringComparison.OrdinalIgnoreCase) Then
                        Return Path.GetFullPath(drv & procStr.Remove(0, rawName.Length)).ToLower
                    End If
                End If
            Next
        End If
        Return String.Empty
    End Function

    ''' <summary>
    ''' Gets the total number of running system processes.
    ''' </summary>
    ''' <returns>Process count as an Integer.</returns>
    Function GetTotalProcesses() As Integer
        Dim processes() As Process = Process.GetProcesses
        Return processes.Length
    End Function

    ''' <summary>
    ''' Formats current system RAM usage in gigabytes and percentage string.
    ''' </summary>
    ''' <returns>RAM usage summary String.</returns>
    Function GetRAMUsage() As String
        Dim currentRAM As ULong = My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory
        Dim ramUsage As Double = currentRAM / (1024.0 * 1024.0 * 1024.0)
        Return (ramUsage.ToString("N1") & Space(1) & "GB" & Space(1) & "(" & GetRAMPercentage() & "%)")
    End Function

    ''' <summary>
    ''' Calculates current system physical memory usage as a percentage.
    ''' </summary>
    ''' <returns>RAM usage percentage String.</returns>
    Function GetRAMPercentage() As String
        Dim maxRAM As ULong = My.Computer.Info.TotalPhysicalMemory
        Dim currentRAM As ULong = My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory
        Dim ramPercent As Double = (currentRAM / CDbl(maxRAM)) * 100.0
        Return ramPercent.ToString("N0")
    End Function

    ''' <summary>
    ''' Forces memory working set trimming on all accessible processes to release unallocated RAM.
    ''' </summary>
    ''' <returns>Number of processes successfully trimmed.</returns>
    Function FreeProcesses() As Integer
        Dim processSize As Integer = 0
        Dim minusOne As New IntPtr(-1)
        For Each procItem As Process In Process.GetProcesses
            Try
                If SetWorkingSet(procItem.Handle, minusOne, minusOne) Then
                    processSize += 1
                End If
            Catch ex As Exception
                ' Protected or system process handle access error
            End Try
        Next
        Return processSize
    End Function

    ''' <summary>
    ''' Scans active processes and returns executable file names eligible to be safely terminated.
    ''' </summary>
    ''' <param name="ignoreList">Optional list of process executable names to exclude.</param>
    ''' <returns>Array of killable process executable names.</returns>
    Function GetKillableProcesses(Optional ignoreList As StringCollection = Nothing) As String()
        Dim processes As New List(Of String)()
        Dim exclusions As String() = {Environment.SystemDirectory.ToLower, Path.GetDirectoryName(Environment.SystemDirectory).ToLower}
        Dim mutex As String = ProcessHandle(Process.GetCurrentProcess.Handle)
        For Each procItem As Process In Process.GetProcesses
            Try
                Dim handle As String = ProcessHandle(procItem.Handle)
                If Not String.IsNullOrEmpty(handle) AndAlso Not handle.Equals(mutex, StringComparison.OrdinalIgnoreCase) Then
                    Dim dirName As String = Path.GetDirectoryName(handle)
                    If Not String.IsNullOrEmpty(dirName) AndAlso Array.IndexOf(exclusions, dirName.ToLower()) = -1 Then
                        Dim fileName As String = Path.GetFileName(handle)
                        If ignoreList Is Nothing OrElse Not ignoreList.Contains(fileName) Then
                            processes.Add(fileName)
                        End If
                    End If
                End If
            Catch ex As Exception
                ' Protected or system process handle access error
            End Try
        Next
        Return processes.ToArray
    End Function

    ''' <summary>
    ''' Terminates all non-system killable background processes excluding items in the ignore list.
    ''' </summary>
    ''' <param name="ignoreList">Optional list of process executable names to exclude from termination.</param>
    ''' <returns>Count of processes successfully terminated.</returns>
    Function KillProcesses(Optional ignoreList As StringCollection = Nothing) As Integer
        Dim processSize As Integer = 0
        Dim exclusions As String() = {Environment.SystemDirectory.ToLower, Path.GetDirectoryName(Environment.SystemDirectory).ToLower}
        Dim mutex As String = ProcessHandle(Process.GetCurrentProcess.Handle)
        For Each procItem As Process In Process.GetProcesses
            Try
                Dim handle As String = ProcessHandle(procItem.Handle)
                If Not String.IsNullOrEmpty(handle) AndAlso Not handle.Equals(mutex, StringComparison.OrdinalIgnoreCase) Then
                    Dim dirName As String = Path.GetDirectoryName(handle)
                    If Not String.IsNullOrEmpty(dirName) AndAlso Array.IndexOf(exclusions, dirName.ToLower()) = -1 Then
                        Dim fileName As String = Path.GetFileName(handle)
                        If ignoreList Is Nothing OrElse Not ignoreList.Contains(fileName) Then
                            procItem.Kill()
                            processSize += 1
                        End If
                    End If
                End If
            Catch ex As Exception
                ' Protected or system process handle access error
            End Try
        Next

        Return processSize
    End Function
End Class
