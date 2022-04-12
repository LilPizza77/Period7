﻿Public Class Ngon

    Public Property Pen As Pen
    Public Property sides As Integer
    Public Property radius As Integer
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
        Dim points(sides - 1) As Point
        For index = 0 To sides - 1
            Dim x As Integer
            Dim y As Integer
            x = Math.Cos(index * 2 * Math.PI / sides) * radius
            y = Math.Sin(index * 2 * Math.PI / sides) * radius
            points(index) = New Point(m_a.X + x + xoffset, m_a.Y + y + yoffset)
        Next

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
