Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Namespace Helpers

    ''' <summary>
    ''' Represents a file or folder node in the directory space tree.
    ''' </summary>
    Public Class SpaceNode
        Public Property Name As String
        Public Property FullPath As String
        Public Property Size As Long
        Public Property IsDirectory As Boolean
        Public Property Children As New List(Of SpaceNode)()
        Public Property Parent As SpaceNode

        Public Property Bounds As RectangleF
        Public Property Depth As Integer

        Public ReadOnly Property FormattedSize As String
            Get
                Return FormatBytes(Size)
            End Get
        End Property

        Public ReadOnly Property ItemCount As Integer
            Get
                If IsDirectory Then
                    Return Children.Count
                End If
                Return 0
            End Get
        End Property

        Public Shared Function FormatBytes(bytes As Long) As String
            If bytes < 0 Then Return "0 B"
            Dim sizes() As String = {"B", "KB", "MB", "GB", "TB"}
            Dim order As Integer = 0
            Dim len As Double = CDbl(bytes)
            While len >= 1024.0 AndAlso order < sizes.Length - 1
                order += 1
                len /= 1024.0
            End While
            Return String.Format("{0:0.##} {1}", len, sizes(order))
        End Function
    End Class

    ''' <summary>
    ''' Progress report data during scanning.
    ''' </summary>
    Public Class ScanProgress
        Public Property CurrentPath As String
        Public Property FilesScanned As Long
        Public Property FoldersScanned As Long
        Public Property TotalBytes As Long
        Public Property EstimatedPercent As Integer
    End Class

    ''' <summary>
    ''' Fast recursive filesystem scanner building hierarchical SpaceNode tree with cancellation support.
    ''' </summary>
    Public Class DiskTreeScanner

        Public Event ProgressChanged As Action(Of ScanProgress)

        Private _cancelToken As CancellationToken
        Private _filesScanned As Long = 0
        Private _foldersScanned As Long = 0
        Private _totalBytes As Long = 0
        Private _targetTotalBytes As Long = 0
        Private _lastProgressUpdate As Long = 0

        ''' <summary>
        ''' Scans target directory path and builds an aggregated SpaceNode tree.
        ''' </summary>
        Public Function ScanDirectory(rootPath As String, token As CancellationToken) As SpaceNode
            _cancelToken = token
            _filesScanned = 0
            _foldersScanned = 0
            _totalBytes = 0
            _lastProgressUpdate = DateTime.UtcNow.Ticks

            Dim rootDir As New DirectoryInfo(rootPath)
            If Not rootDir.Exists Then
                Throw New DirectoryNotFoundException("Directory does not exist: " & rootPath)
            End If

            ' Determine total target bytes if drive root
            _targetTotalBytes = 0
            Try
                Dim drive As New DriveInfo(rootDir.Root.FullName)
                If drive.IsReady Then
                    _targetTotalBytes = drive.TotalSize - drive.TotalFreeSpace
                End If
            Catch
            End Try

            Dim rootNode As New SpaceNode With {
                .Name = If(String.IsNullOrEmpty(rootDir.Name), rootDir.FullName, rootDir.Name),
                .FullPath = rootDir.FullName,
                .IsDirectory = True,
                .Depth = 0
            }

            ScanNode(rootNode, 0)
            Return rootNode
        End Function

        Private Sub ScanNode(parentNode As SpaceNode, currentDepth As Integer)
            _cancelToken.ThrowIfCancellationRequested()

            Dim dirInfo As New DirectoryInfo(parentNode.FullPath)

            ' 1. Scan files in current directory
            Try
                Dim files = dirInfo.GetFiles()
                For Each fi As FileInfo In files
                    _cancelToken.ThrowIfCancellationRequested()

                    Dim fileSize As Long = 0
                    Try
                        fileSize = fi.Length
                    Catch
                    End Try

                    Dim fileNode As New SpaceNode With {
                        .Name = fi.Name,
                        .FullPath = fi.FullName,
                        .Size = fileSize,
                        .IsDirectory = False,
                        .Parent = parentNode,
                        .Depth = currentDepth + 1
                    }
                    parentNode.Children.Add(fileNode)
                    parentNode.Size += fileSize
                    _totalBytes += fileSize
                    _filesScanned += 1
                Next
            Catch ex As UnauthorizedAccessException
            Catch ex As PathTooLongException
            Catch ex As Exception
            End Try

            ' 2. Scan subdirectories
            Try
                Dim subDirs = dirInfo.GetDirectories()
                For Each di As DirectoryInfo In subDirs
                    _cancelToken.ThrowIfCancellationRequested()

                    ' Skip reparse points / junctions to prevent infinite loops
                    If (di.Attributes And FileAttributes.ReparsePoint) = FileAttributes.ReparsePoint Then
                        Continue For
                    End If

                    Dim dirNode As New SpaceNode With {
                        .Name = di.Name,
                        .FullPath = di.FullName,
                        .IsDirectory = True,
                        .Parent = parentNode,
                        .Depth = currentDepth + 1
                    }

                    _foldersScanned += 1
                    ScanNode(dirNode, currentDepth + 1)

                    parentNode.Children.Add(dirNode)
                    parentNode.Size += dirNode.Size
                Next
            Catch ex As UnauthorizedAccessException
            Catch ex As PathTooLongException
            Catch ex As Exception
            End Try

            ' Sort children by size descending for optimal treemap packing
            parentNode.Children.Sort(Function(a, b) b.Size.CompareTo(a.Size))

            ' Throttled progress event (~50ms)
            Dim nowTicks As Long = DateTime.UtcNow.Ticks
            If nowTicks - _lastProgressUpdate > 500000 Then
                _lastProgressUpdate = nowTicks

                Dim pct As Integer = 0
                If _targetTotalBytes > 0 Then
                    pct = CInt(Math.Min(99, Math.Max(1, (_totalBytes / CDbl(_targetTotalBytes)) * 100.0)))
                Else
                    ' Monotonic progress curve based on file count
                    pct = CInt(Math.Min(95, Math.Log10(Math.Max(10, _filesScanned)) * 20.0))
                End If

                Dim p As New ScanProgress With {
                    .CurrentPath = parentNode.FullPath,
                    .FilesScanned = _filesScanned,
                    .FoldersScanned = _foldersScanned,
                    .TotalBytes = _totalBytes,
                    .EstimatedPercent = pct
                }
                RaiseEvent ProgressChanged(p)
            End If
        End Sub

    End Class

End Namespace
