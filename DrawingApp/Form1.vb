Public Class CircleRadio
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim type As String

    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim d As Object
        If m_Previous IsNot Nothing And SquareRadio.Checked Then
            Dim l As New Square(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
            l.fill = CheckBox2.Checked
        ElseIf m_Previous IsNot Nothing And lineRadio.Checked Then
            Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.xspeed = xspeedTrackBar.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And CircleRad.Checked Then
            Dim l As New Circle(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And PieRadio.Checked Then
            Dim l As New Pie(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And TriangleRadio.Checked Then
            Dim l As New Triangle(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And PolygonRadio.Checked Then
            Dim l As New Polygon(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And NgonRadio.Checked Then
            Dim l As New Ngon(PictureBox1.Image, m_Previous, e.Location)
            l.Pen = New Pen(c, w)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            l.radius = RadiusTrackBar.Value
            l.sides = SidesTrackBar.Value
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        ElseIf m_Previous IsNot Nothing And PictureRadio.Checked Then
            Dim l As New PBox(PictureBox1.Image, m_Previous, e.Location)
            l.w = TrackBar2.Value
            l.h = TrackBar3.Value
            PictureBox1.Invalidate()
            m_Previous = e.Location
            m_shapes.Add(l)
            l.Picture = PictureBox2.Image
        ElseIf type = "picture" Then
            d = New PBox(PictureBox1.Image, m_Previous, e.Location)
        End If

    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
        If (CheckBox1.checked) Then
            Refresh()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button5.Click, Button6.Click, Button4.Click, Button7.Click, Button8.Click, Button9.Click
        c = sender.backcolor
    End Sub


    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)


    End Sub

    Private Sub PolygonRadio_CheckedChanged(sender As Object, e As EventArgs) Handles PolygonRadio.CheckedChanged
        type = "polygon"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "picture"
    End Sub
End Class
