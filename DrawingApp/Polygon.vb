Public Class Polygon
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
        Using g As Graphics = Graphics.FromImage(m_image)
            xoffset += xspeed
            yoffset += yspeed
            If fill Then
                Dim points(4) As Point
                points(0) = New Point(m_a.X, m_a.Y)
                points(1) = New Point(m_a.X + 21, m_a.Y + 40)
                points(2) = New Point(m_a.X + +52, m_a.Y + 25)
                points(3) = New Point(m_a.X + 60, m_a.Y + 95)
                points(4) = New Point(m_a.X + 75, m_a.Y + 55)
                g.FillPolygon(New SolidBrush(Pen.Color), points)



            Else

                Dim points(4) As Point
                points(0) = New Point(m_a.X + xoffset, m_a.Y + yoffset)
                points(1) = New Point(m_a.X + 21 + xoffset, m_a.Y + 40 + yoffset)
                points(2) = New Point(m_a.X + +52 + xoffset, m_a.Y + 25 + yoffset)
                points(3) = New Point(m_a.X + 60 + xoffset, m_a.Y + 95 + yoffset)
                points(4) = New Point(m_a.X + 75 + xoffset, m_a.Y + 55 + yoffset)
                g.DrawPolygon(Pen, points)
            End If
        End Using

    End Sub
End Class
