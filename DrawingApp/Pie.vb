﻿Public Class Pie


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
                g.FillPie(New SolidBrush(Pen.Color), m_a.X, m_b.Y, 100, 100, 0, 90)
            Else

                g.DrawPie(Pen, m_a.X + xoffset, m_a.Y + yoffset, 100, 100, 0, 90)
            End If
        End Using
        End Sub




End Class
