Public Class Triangle
    Dim points(2) As Point
    Public Property Pen As Pen
    Public Property w As Integer
    Public Property h As Integer
    Public Property fill As Boolean
    Public Property xspeed As Integer
    Public Property yspeed As Integer
    Dim xoffset As Integer
    Dim yoffset As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        points(0) = New Point(m_a.X + xoffset, m_a.Y + yoffset)
        points(1) = New Point(m_a.X + xoffset, m_a.Y + 50 + yoffset)
        points(2) = New Point(m_a.X + 50 + xoffset, m_a.Y + yoffset)
        Using g As Graphics = Graphics.FromImage(m_image)
            xoffset += xspeed
            yoffset += yspeed
            If fill Then
                g.FillPolygon(New SolidBrush(Pen.Color), points)
            Else
                g.DrawPolygon(Pen, points)
            End If
        End Using

    End Sub
End Class
