Imports System.Drawing.Drawing2D

Module RasHag
    Dim g As Graphics
    Dim bmp As Bitmap
    Function EC(ByVal c As Control, ByVal color As Color) As Bitmap
        Dim gpath As New GraphicsPath
        Dim recReg As RectangleF
        recReg = New RectangleF(0, 0, c.Width, c.Height)
        gpath.AddEllipse(recReg)
        c.Region = New Region(gpath)

        Dim br As PathGradientBrush
        br = New PathGradientBrush(gpath)
        br.CenterColor = Color.White
        br.CenterPoint = New PointF(8, 8)
        br.SurroundColors = New Color() {color}


        Dim w, h As Int16
        w = c.Width
        h = c.Height
        Dim bmp As New Bitmap(w, h)

        Dim g As Graphics = Graphics.FromImage(bmp)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.FillEllipse(br, 0, 0, w, h)

        Dim p As New Pen(Color.Black, 2)
        g.DrawEllipse(p, 1, 1, w - 2, h - 2)
        Return bmp
    End Function
End Module
