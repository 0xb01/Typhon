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

        ' Comprehensive, distinct aesthetic color palette for popular file formats
        Private Shared ReadOnly _categoryColors As Dictionary(Of String, Color) = InitializeCategoryColors()

        Private Shared Function InitializeCategoryColors() As Dictionary(Of String, Color)
            Dim dict As New Dictionary(Of String, Color)(StringComparer.OrdinalIgnoreCase)
            ' Executables & Binaries (Crimson / Coral / Ruby)
            dict.Add(".exe", Color.FromArgb(235, 95, 95))
            dict.Add(".dll", Color.FromArgb(220, 110, 110))
            dict.Add(".sys", Color.FromArgb(205, 80, 80))
            dict.Add(".msi", Color.FromArgb(230, 105, 120))
            dict.Add(".bat", Color.FromArgb(215, 120, 95))
            dict.Add(".cmd", Color.FromArgb(215, 120, 95))
            dict.Add(".ps1", Color.FromArgb(200, 130, 80))
            ' Archives & Compressed (Amber / Orange / Ochre)
            dict.Add(".zip", Color.FromArgb(240, 165, 60))
            dict.Add(".rar", Color.FromArgb(235, 150, 50))
            dict.Add(".7z", Color.FromArgb(245, 175, 70))
            dict.Add(".tar", Color.FromArgb(225, 140, 55))
            dict.Add(".gz", Color.FromArgb(215, 135, 60))
            dict.Add(".iso", Color.FromArgb(250, 130, 70))
            dict.Add(".cab", Color.FromArgb(220, 155, 65))
            ' Video (Sapphire / Indigo / Sky)
            dict.Add(".mp4", Color.FromArgb(90, 160, 245))
            dict.Add(".mkv", Color.FromArgb(80, 145, 235))
            dict.Add(".avi", Color.FromArgb(100, 170, 250))
            dict.Add(".mov", Color.FromArgb(70, 130, 220))
            dict.Add(".wmv", Color.FromArgb(95, 155, 230))
            dict.Add(".flv", Color.FromArgb(110, 165, 235))
            dict.Add(".webm", Color.FromArgb(85, 175, 240))
            ' Audio (Violet / Lavender / Magenta)
            dict.Add(".mp3", Color.FromArgb(190, 115, 235))
            dict.Add(".flac", Color.FromArgb(175, 100, 225))
            dict.Add(".wav", Color.FromArgb(160, 90, 210))
            dict.Add(".m4a", Color.FromArgb(200, 130, 240))
            dict.Add(".ogg", Color.FromArgb(165, 105, 215))
            dict.Add(".aac", Color.FromArgb(180, 110, 230))
            ' Images (Emerald / Mint / Turquoise)
            dict.Add(".jpg", Color.FromArgb(65, 195, 165))
            dict.Add(".jpeg", Color.FromArgb(65, 195, 165))
            dict.Add(".png", Color.FromArgb(55, 185, 155))
            dict.Add(".gif", Color.FromArgb(75, 205, 180))
            dict.Add(".bmp", Color.FromArgb(85, 190, 150))
            dict.Add(".webp", Color.FromArgb(70, 200, 170))
            dict.Add(".svg", Color.FromArgb(90, 210, 160))
            dict.Add(".ico", Color.FromArgb(80, 180, 140))
            dict.Add(".psd", Color.FromArgb(60, 165, 190))
            ' Documents & Books (Blue / Teal / Cyan)
            dict.Add(".pdf", Color.FromArgb(240, 85, 95))
            dict.Add(".doc", Color.FromArgb(75, 150, 215))
            dict.Add(".docx", Color.FromArgb(75, 150, 215))
            dict.Add(".xls", Color.FromArgb(65, 175, 115))
            dict.Add(".xlsx", Color.FromArgb(65, 175, 115))
            dict.Add(".ppt", Color.FromArgb(235, 115, 75))
            dict.Add(".pptx", Color.FromArgb(235, 115, 75))
            dict.Add(".txt", Color.FromArgb(160, 170, 185))
            dict.Add(".log", Color.FromArgb(150, 160, 175))
            dict.Add(".md", Color.FromArgb(145, 180, 205))
            ' Code & Config (Teal / Lime / Gold)
            dict.Add(".vb", Color.FromArgb(120, 200, 110))
            dict.Add(".cs", Color.FromArgb(140, 195, 95))
            dict.Add(".cpp", Color.FromArgb(105, 185, 130))
            dict.Add(".h", Color.FromArgb(100, 175, 120))
            dict.Add(".py", Color.FromArgb(135, 210, 100))
            dict.Add(".js", Color.FromArgb(235, 210, 80))
            dict.Add(".ts", Color.FromArgb(85, 180, 230))
            dict.Add(".html", Color.FromArgb(240, 130, 80))
            dict.Add(".css", Color.FromArgb(90, 175, 235))
            dict.Add(".json", Color.FromArgb(220, 190, 90))
            dict.Add(".xml", Color.FromArgb(215, 160, 100))
            dict.Add(".sql", Color.FromArgb(170, 140, 210))
            ' Virtual Disks & Databases (Deep Slate / Plum)
            dict.Add(".vmdk", Color.FromArgb(135, 125, 215))
            dict.Add(".vhdx", Color.FromArgb(135, 125, 215))
            dict.Add(".vdi", Color.FromArgb(125, 115, 205))
            dict.Add(".mdf", Color.FromArgb(80, 185, 140))
            dict.Add(".ldf", Color.FromArgb(70, 170, 130))
            dict.Add(".db", Color.FromArgb(100, 180, 160))
            dict.Add(".sqlite", Color.FromArgb(95, 175, 155))
            Return dict
        End Function

        Private Shared ReadOnly _folderColors() As Color = {
            Color.FromArgb(70, 130, 190),
            Color.FromArgb(65, 160, 135),
            Color.FromArgb(145, 105, 175),
            Color.FromArgb(195, 130, 75),
            Color.FromArgb(60, 155, 150),
            Color.FromArgb(180, 95, 95),
            Color.FromArgb(90, 115, 150)
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

        ''' <summary>
        ''' Returns the distinct visual color for a folder or file node.
        ''' </summary>
        Public Shared Function GetNodeColor(node As SpaceNode) As Color
            If node Is Nothing Then Return Color.FromArgb(170, 175, 185)

            If node.IsDirectory Then
                Dim idx As Integer = Math.Abs(node.Name.ToLowerInvariant().GetHashCode()) Mod _folderColors.Length
                Return _folderColors(idx)
            Else
                Dim ext As String = Path.GetExtension(node.Name).ToLowerInvariant()
                If Not String.IsNullOrEmpty(ext) AndAlso _categoryColors.ContainsKey(ext) Then
                    Return _categoryColors(ext)
                End If

                ' Dynamic harmonious HSL generation for any unique/uncommon extension
                If Not String.IsNullOrEmpty(ext) Then
                    Dim hash As Integer = Math.Abs(ext.GetHashCode())
                    Dim hue As Single = CSng((hash * 137.508) Mod 360.0) ' Golden angle distribution
                    Dim sat As Single = 0.55!
                    Dim lum As Single = 0.62!
                    Return FromHsl(hue, sat, lum)
                End If

                Return Color.FromArgb(165, 170, 180)
            End If
        End Function

        ''' <summary>
        ''' Converts HSL values to a System.Drawing.Color.
        ''' </summary>
        Private Shared Function FromHsl(h As Single, s As Single, l As Single) As Color
            Dim r, g, b As Single
            If s = 0 Then
                r = l : g = l : b = l
            Else
                Dim q As Single = If(l < 0.5!, l * (1.0! + s), (l + s) - (l * s))
                Dim p As Single = (2.0! * l) - q
                Dim hk As Single = h / 360.0!

                r = HueToRgb(p, q, hk + (1.0! / 3.0!))
                g = HueToRgb(p, q, hk)
                b = HueToRgb(p, q, hk - (1.0! / 3.0!))
            End If

            Return Color.FromArgb(CInt(Math.Max(0, Math.Min(255, r * 255.0!))),
                                  CInt(Math.Max(0, Math.Min(255, g * 255.0!))),
                                  CInt(Math.Max(0, Math.Min(255, b * 255.0!))))
        End Function

        Private Shared Function HueToRgb(p As Single, q As Single, tc As Single) As Single
            If tc < 0 Then tc += 1.0!
            If tc > 1 Then tc -= 1.0!
            If (6.0! * tc) < 1.0! Then Return p + ((q - p) * 6.0! * tc)
            If (2.0! * tc) < 1.0! Then Return q
            If (3.0! * tc) < 2.0! Then Return p + ((q - p) * ((2.0! / 3.0!) - tc) * 6.0!)
            Return p
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
