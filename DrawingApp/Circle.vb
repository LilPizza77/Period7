Public Class Circle

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
                g.FillEllipse(New SolidBrush(Pen.Color), m_a.X, m_b.Y, w, h)
            Else

                g.DrawEllipse(Pen, m_a.X + xoffset, m_b.Y + yoffset, w, h)
            End If
        End Using
    End Sub



End Class
