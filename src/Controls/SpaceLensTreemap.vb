Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms
Imports Typhon.Helpers

Namespace Controls

    ''' <summary>
    ''' High-performance double-buffered Squarified Treemap visualization control for disk space breakdown.
    ''' Features muted, professional dark-theme colors with clean borders.
    ''' </summary>
    Public Class SpaceLensTreemap
        Inherits Control

        Private _rootNode As SpaceNode
        Private _currentNode As SpaceNode
        Private _hoveredNode As SpaceNode
        Private _selectedNode As SpaceNode

        Public Event NodeSelected As Action(Of SpaceNode)
        Public Event NodeHovered As Action(Of SpaceNode)
        Public Event NodeDoubleClicked As Action(Of SpaceNode)

        ' Toned-down, refined color palette for file types
        Private ReadOnly _categoryColors As New Dictionary(Of String, Color)(StringComparer.OrdinalIgnoreCase) From {
            {".exe", Color.FromArgb(170, 70, 70)},
            {".dll", Color.FromArgb(150, 75, 70)},
            {".sys", Color.FromArgb(140, 50, 50)},
            {".zip", Color.FromArgb(180, 120, 50)},
            {".rar", Color.FromArgb(180, 120, 50)},
            {".7z", Color.FromArgb(180, 120, 50)},
            {".tar", Color.FromArgb(180, 120, 50)},
            {".gz", Color.FromArgb(180, 120, 50)},
            {".iso", Color.FromArgb(190, 90, 50)},
            {".mp4", Color.FromArgb(75, 95, 160)},
            {".mkv", Color.FromArgb(75, 95, 160)},
            {".avi", Color.FromArgb(75, 95, 160)},
            {".mov", Color.FromArgb(65, 80, 150)},
            {".mp3", Color.FromArgb(135, 75, 155)},
            {".flac", Color.FromArgb(135, 75, 155)},
            {".wav", Color.FromArgb(120, 70, 140)},
            {".jpg", Color.FromArgb(45, 135, 135)},
            {".jpeg", Color.FromArgb(45, 135, 135)},
            {".png", Color.FromArgb(45, 135, 135)},
            {".gif", Color.FromArgb(40, 100, 120)},
            {".psd", Color.FromArgb(35, 110, 130)},
            {".doc", Color.FromArgb(50, 125, 170)},
            {".docx", Color.FromArgb(50, 125, 170)},
            {".pdf", Color.FromArgb(185, 70, 70)},
            {".txt", Color.FromArgb(80, 85, 95)},
            {".log", Color.FromArgb(90, 95, 105)},
            {".vmdk", Color.FromArgb(70, 75, 155)},
            {".vhdx", Color.FromArgb(70, 75, 155)},
            {".mdf", Color.FromArgb(50, 145, 95)},
            {".ldf", Color.FromArgb(45, 130, 85)}
        }

        Private ReadOnly _folderColors() As Color = {
            Color.FromArgb(45, 85, 125),
            Color.FromArgb(45, 115, 85),
            Color.FromArgb(105, 65, 125),
            Color.FromArgb(145, 85, 45),
            Color.FromArgb(35, 115, 105),
            Color.FromArgb(135, 55, 55),
            Color.FromArgb(55, 65, 80)
        }

        Public Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.UserPaint Or
                     ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.ResizeRedraw, True)
            UpdateStyles()
            BackColor = Color.FromArgb(32, 32, 32)
            Font = New Font("Segoe UI", 8.25!, FontStyle.Regular)
        End Sub

        Public Property RootNode As SpaceNode
            Get
                Return _rootNode
            End Get
            Set(value As SpaceNode)
                _rootNode = value
                _currentNode = value
                _hoveredNode = Nothing
                _selectedNode = Nothing
                RecalculateLayout()
                Invalidate()
            End Set
        End Property

        Public Property CurrentNode As SpaceNode
            Get
                Return _currentNode
            End Get
            Set(value As SpaceNode)
                _currentNode = value
                _hoveredNode = Nothing
                _selectedNode = Nothing
                RecalculateLayout()
                Invalidate()
            End Set
        End Property

        Public Property SelectedNode As SpaceNode
            Get
                Return _selectedNode
            End Get
            Set(value As SpaceNode)
                _selectedNode = value
                Invalidate()
            End Set
        End Property

        Public ReadOnly Property HoveredNode As SpaceNode
            Get
                Return _hoveredNode
            End Get
        End Property

        ''' <summary>
        ''' Navigates one level up in the hierarchy.
        ''' </summary>
        Public Function NavigateUp() As Boolean
            If _currentNode IsNot Nothing AndAlso _currentNode.Parent IsNot Nothing Then
                _currentNode = _currentNode.Parent
                _hoveredNode = Nothing
                _selectedNode = Nothing
                RecalculateLayout()
                Invalidate()
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            RecalculateLayout()
            Invalidate()
        End Sub

        ''' <summary>
        ''' Recomputes the squarified treemap bounding rectangles for current node's children.
        ''' </summary>
        Public Sub RecalculateLayout()
            If _currentNode Is Nothing OrElse _currentNode.Children.Count = 0 OrElse Width <= 4 OrElse Height <= 4 Then
                Return
            End If

            Dim totalSize As Long = _currentNode.Size
            If totalSize <= 0 Then Return

            Dim rect As New RectangleF(2, 2, Width - 4, Height - 4)
            LayoutSquarified(_currentNode.Children, rect, totalSize)
        End Sub

        ''' <summary>
        ''' Squarified Treemap Algorithm implementation.
        ''' </summary>
        Private Sub LayoutSquarified(nodes As List(Of SpaceNode), container As RectangleF, totalSize As Long)
            If nodes.Count = 0 OrElse container.Width <= 0 OrElse container.Height <= 0 OrElse totalSize <= 0 Then
                Return
            End If

            Dim activeNodes As List(Of SpaceNode) = nodes.Where(Function(n) n.Size > 0).ToList()
            If activeNodes.Count = 0 Then Return

            Dim totalArea As Double = container.Width * container.Height
            Dim areas As New List(Of Double)()
            For Each node In activeNodes
                areas.Add((CDbl(node.Size) / CDbl(totalSize)) * totalArea)
            Next

            Squarify(activeNodes, areas, New List(Of SpaceNode)(), New List(Of Double)(), container)
        End Sub

        Private Sub Squarify(children As List(Of SpaceNode), areas As List(Of Double), currentRow As List(Of SpaceNode), rowAreas As List(Of Double), bounds As RectangleF)
            If children.Count = 0 Then
                If currentRow.Count > 0 Then
                    LayoutRow(currentRow, rowAreas, bounds)
                End If
                Return
            End If

            Dim c As SpaceNode = children(0)
            Dim cArea As Double = areas(0)

            Dim remChildren As List(Of SpaceNode) = children.Skip(1).ToList()
            Dim remAreas As List(Of Double) = areas.Skip(1).ToList()

            Dim shortestSide As Double = Math.Min(bounds.Width, bounds.Height)

            If currentRow.Count = 0 Then
                Dim newRow As New List(Of SpaceNode) From {c}
                Dim newAreas As New List(Of Double) From {cArea}
                Squarify(remChildren, remAreas, newRow, newAreas, bounds)
            Else
                Dim currentWorst As Double = WorstRatio(rowAreas, shortestSide)
                Dim testAreas As New List(Of Double)(rowAreas) From {cArea}
                Dim testWorst As Double = WorstRatio(testAreas, shortestSide)

                If testWorst <= currentWorst Then
                    Dim newRow As New List(Of SpaceNode)(currentRow) From {c}
                    Squarify(remChildren, remAreas, newRow, testAreas, bounds)
                Else
                    Dim remainingBounds As RectangleF = LayoutRow(currentRow, rowAreas, bounds)
                    Dim newRow As New List(Of SpaceNode) From {c}
                    Dim newAreas As New List(Of Double) From {cArea}
                    Squarify(remChildren, remAreas, newRow, newAreas, remainingBounds)
                End If
            End If
        End Sub

        Private Function WorstRatio(rowAreas As List(Of Double), sideLength As Double) As Double
            If rowAreas.Count = 0 OrElse sideLength <= 0 Then Return Double.MaxValue
            Dim sum As Double = rowAreas.Sum()
            If sum <= 0 Then Return Double.MaxValue

            Dim s2 As Double = sideLength * sideLength
            Dim sum2 As Double = sum * sum
            Dim maxArea As Double = rowAreas.Max()
            Dim minArea As Double = rowAreas.Min()

            Return Math.Max((s2 * maxArea) / sum2, sum2 / (s2 * minArea))
        End Function

        Private Function LayoutRow(row As List(Of SpaceNode), rowAreas As List(Of Double), bounds As RectangleF) As RectangleF
            Dim rowSum As Double = rowAreas.Sum()
            If rowSum <= 0 Then Return bounds

            Dim isHorizontal As Boolean = bounds.Width >= bounds.Height

            If isHorizontal Then
                Dim rowWidth As Single = CSng(rowSum / bounds.Height)
                If rowWidth > bounds.Width Then rowWidth = bounds.Width

                Dim currentY As Single = bounds.Y
                For i As Integer = 0 To row.Count - 1
                    Dim itemHeight As Single = CSng((rowAreas(i) / rowSum) * bounds.Height)
                    row(i).Bounds = New RectangleF(bounds.X, currentY, rowWidth, itemHeight)
                    currentY += itemHeight
                Next

                Return New RectangleF(bounds.X + rowWidth, bounds.Y, Math.Max(0, bounds.Width - rowWidth), bounds.Height)
            Else
                Dim rowHeight As Single = CSng(rowSum / bounds.Width)
                If rowHeight > bounds.Height Then rowHeight = bounds.Height

                Dim currentX As Single = bounds.X
                For i As Integer = 0 To row.Count - 1
                    Dim itemWidth As Single = CSng((rowAreas(i) / rowSum) * bounds.Width)
                    row(i).Bounds = New RectangleF(currentX, bounds.Y, itemWidth, rowHeight)
                    currentX += itemWidth
                Next

                Return New RectangleF(bounds.X, bounds.Y + rowHeight, bounds.Width, Math.Max(0, bounds.Height - rowHeight))
            End If
        End Function

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.HighQuality
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            g.PixelOffsetMode = PixelOffsetMode.HighQuality

            g.Clear(BackColor)

            If _currentNode Is Nothing OrElse _currentNode.Children.Count = 0 Then
                Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    Using b As New SolidBrush(Color.FromArgb(130, 130, 130))
                        g.DrawString("No files scanned or folder is empty.", Font, b, ClientRectangle, sf)
                    End Using
                End Using
                Return
            End If

            For Each child In _currentNode.Children
                If child.Bounds.Width >= 1 AndAlso child.Bounds.Height >= 1 Then
                    DrawNode(g, child)
                End If
            Next
        End Sub

        Private Sub DrawNode(g As Graphics, node As SpaceNode)
            Dim rect As Rectangle = Rectangle.Round(node.Bounds)
            If rect.Width <= 1 OrElse rect.Height <= 1 Then Return

            Dim baseColor As Color = GetNodeColor(node)
            Dim isHovered As Boolean = (node Is _hoveredNode)
            Dim isSelected As Boolean = (node Is _selectedNode)

            If isHovered Then
                baseColor = ControlPaint.Light(baseColor, 0.2!)
            End If

            Using b As New SolidBrush(baseColor)
                g.FillRectangle(b, rect)
            End Using

            ' Border
            Dim borderColor As Color = If(isSelected, Color.FromArgb(235, 235, 235), If(isHovered, Color.FromArgb(180, 180, 180), Color.FromArgb(25, 25, 25)))
            Using p As New Pen(borderColor, If(isSelected, 2.0!, 1.0!))
                g.DrawRectangle(p, rect)
            End Using

            ' Node text
            If rect.Width > 45 AndAlso rect.Height > 24 Then
                Dim displayText As String = node.Name
                Dim sizeText As String = node.FormattedSize

                Dim textRect As New Rectangle(rect.X + 4, rect.Y + 3, rect.Width - 8, rect.Height - 6)
                Using sf As New StringFormat() With {.Trimming = StringTrimming.EllipsisCharacter, .LineAlignment = StringAlignment.Near}
                    Using boldFont As New Font("Segoe UI", 8.0!, FontStyle.Bold)
                        Using regularFont As New Font("Segoe UI", 7.5!, FontStyle.Regular)
                            ' Drop shadow for name
                            Using shadowBrush As New SolidBrush(Color.FromArgb(160, 0, 0, 0))
                                g.DrawString(displayText, boldFont, shadowBrush, New RectangleF(textRect.X + 1, textRect.Y + 1, textRect.Width, 16), sf)
                            End Using
                            ' Highlight bold name
                            Using tb As New SolidBrush(Color.FromArgb(255, 255, 255))
                                g.DrawString(displayText, boldFont, tb, New RectangleF(textRect.X, textRect.Y, textRect.Width, 16), sf)
                            End Using

                            ' Regular unbolded size text
                            If rect.Height > 36 Then
                                Using dimBrush As New SolidBrush(Color.FromArgb(210, 210, 210))
                                    g.DrawString(sizeText, regularFont, dimBrush, New PointF(textRect.X, textRect.Y + 16))
                                End Using
                            End If
                        End Using
                    End Using
                End Using
            End If
        End Sub

        Private Function GetNodeColor(node As SpaceNode) As Color
            If node.IsDirectory Then
                Dim idx As Integer = Math.Abs(node.Name.GetHashCode()) Mod _folderColors.Length
                Return _folderColors(idx)
            Else
                Dim ext As String = Path.GetExtension(node.Name)
                If Not String.IsNullOrEmpty(ext) AndAlso _categoryColors.ContainsKey(ext) Then
                    Return _categoryColors(ext)
                End If
                Return Color.FromArgb(70, 75, 82)
            End If
        End Function

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            Dim foundNode As SpaceNode = HitTest(e.Location)

            If foundNode IsNot _hoveredNode Then
                _hoveredNode = foundNode
                RaiseEvent NodeHovered(_hoveredNode)
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            If _hoveredNode IsNot Nothing Then
                _hoveredNode = Nothing
                RaiseEvent NodeHovered(Nothing)
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim foundNode As SpaceNode = HitTest(e.Location)
            _selectedNode = foundNode
            RaiseEvent NodeSelected(_selectedNode)
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
            MyBase.OnMouseDoubleClick(e)
            Dim foundNode As SpaceNode = HitTest(e.Location)
            If foundNode IsNot Nothing Then
                If foundNode.IsDirectory AndAlso foundNode.Children.Count > 0 Then
                    _currentNode = foundNode
                    _hoveredNode = Nothing
                    _selectedNode = Nothing
                    RecalculateLayout()
                    RaiseEvent NodeDoubleClicked(foundNode)
                    Invalidate()
                End If
            End If
        End Sub

        Private Function HitTest(pt As Point) As SpaceNode
            If _currentNode Is Nothing Then Return Nothing
            For Each child In _currentNode.Children
                If child.Bounds.Contains(pt) Then
                    Return child
                End If
            Next
            Return Nothing
        End Function

    End Class

End Namespace
