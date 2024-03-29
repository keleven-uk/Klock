﻿Imports AnalogClock

Public Class frmAnalogueKlock

    Dim _pt As Point

    Dim drag As Boolean                     '   Global variables used to make the form dragable.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '

    Enum Months As Integer
        Jan = 1
        Feb = 2
        Mar = 3
        Apr = 4
        May = 5
        Jun = 6
        Jul = 7
        Aug = 8
        Sep = 9
        Oct = 10
        Nov = 11
        Dec = 12
    End Enum

    ' ------------------------------------------------------------------------------------------------------------------- Custom Painting -----------------

    Public Sub analogueKlockRefresh()
        '   preform a analogue klock refresh i.e. re-draw.
        '   if set up to draw background image and it exists then display it, otherwise clear image.

        Dim currentDate As Date = Date.Now
        Dim localZone As TimeZone = TimeZone.CurrentTimeZone
        Dim offset As TimeSpan

        offset = If(localZone.IsDaylightSavingTime(currentDate), New TimeSpan(0, 1, 0, 0, 0), New TimeSpan(0, 0, 0, 0, 0))
        analogueKlock.UtcOffset = offset

        If frmKlock.usrSettings.usrAnalogueKlockDisplayPicture And My.Computer.FileSystem.FileExists(frmKlock.usrSettings.usrAnalogueKlockPicture) Then
            analogueKlock.BackgroundImageLayout = ImageLayout.Zoom
            analogueKlock.BackgroundImage = System.Drawing.Bitmap.FromFile(frmKlock.usrSettings.usrAnalogueKlockPicture)
            analogueKlock.Refresh()
        Else
            analogueKlock.BackgroundImage = Nothing
            analogueKlock.Refresh()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        '   Display the about form.

        HelpCommon.displayInfo(sender.ToString)
    End Sub

    Private Sub analogKlock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, analogueKlock.KeyDown
        '   Processes key presses at form level, before passed to components.

        '   Pressing F1, will open klock's help.
        '   Pressing alt + F2, will open the options screen.
        '   Pressing alt + F3, will open the analogue klock.
        '   Pressing alt + F4, will open the small text klock.
        '   Pressing alt + F5, will open the big text klock.
        '   Pressing alt + F6, will open the binary klock.
        '   Pressing alt + F7, will close all child klock and return to main klock.
        '   Pressing alt + F8, will disable the monitor from going to sleep.
        '   Pressing alt + F9, will restore system settings for the monitor.
        '   Pressing alt + F10, will open the clipboard manager.
        '   Pressing alt + F12, will shown total number of friends.

        '   pressing + [on numeric keyboard or main keyboard] will increase the size of the analogue klock.
        '   pressing - [on numeric keyboard or main keyboard] will increase the size of the analogue klock.

        'MessageBox.Show(e.KeyCode.ToString)
        Select Case e.KeyCode
            Case Keys.Add, Keys.Oemplus And (e.Shift)
                Dim rect As Rectangle = Screen.FromControl(Me).Bounds   '   should be size on screen containing analogue klock.
                If Width < rect.Width And Height < rect.Height Then
                    Width += 1
                    Height += 1
                End If
                e.Handled = True
            Case Keys.Subtract, Keys.OemMinus And (e.Shift)
                If Width > 100 And Height > 100 Then
                    Width -= 1
                    Height -= 1
                End If
                e.Handled = True
            Case Else
                HotKeys(e, Me)              '   in KlockThings.vb
        End Select
    End Sub


    ' -------------------------------------------------------------------------------- procedures used to make form dragable -----------------

    Private Sub analogKlock_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, analogueKlock.MouseDown
        '   update mouse position when form is dragged i.e. left mouse button down.

        drag = True
        mousex = Cursor.Position.X - Left
        mousey = Cursor.Position.Y - Top
    End Sub

    Private Sub analogKlock_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, analogueKlock.MouseMove
        '   make klock follow the mouse, when left button is held down.

        If drag Then
            Top = Cursor.Position.Y - mousey
            Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub analogKlock_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, analogueKlock.MouseUp
        '   Left mouse button released, stop dragging.

        drag = False
    End Sub

    Private Sub analogueKlock_BackgroundPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles analogueKlock.BackgroundPaint
        '   Set background colour of klock

        analogueKlock.BackColor = If(frmKlock.usrSettings.usrAnalogueKlcokTransparent, Color.Transparent, frmKlock.usrSettings.usrAnalogueKlockBackColour)

        '   Painting some stuff on the clock's background.

        Dim x, y As Single
        Dim sz As SizeF
        Dim sbr As New SolidBrush(analogueKlock.ForeColor)
        Dim t As String = ""

        '   Draw your name on the top, clock's background

        If frmKlock.usrSettings.usrAnalogueKlockText <> "" Then
            Dim klockText As String = frmKlock.usrSettings.usrAnalogueKlockText

            sz = e.Graphics.MeasureString(klockText, New Font("Lucida Calligraphy", 12, FontStyle.Italic), New PointF(0, 0), StringFormat.GenericDefault)
            x = analogueKlock.CenterPoint.PivotalPoint.X - sz.Width / 2
            y = CSng(analogueKlock.Radius * 0.3)
            e.Graphics.DrawString(klockText, New Font("Lucida Calligraphy", 12, FontStyle.Italic), sbr, x, y)
        End If

        If frmKlock.usrSettings.usrAnalogueKlockShowTime Then
            'Draw digital time on the bottom, clock's background

            t = If(frmKlock.usrSettings.usrAnalogueKlockShowIdleTime, KlockThings.idleTime(), analogueKlock.Value.ToShortTimeString)

            sz = e.Graphics.MeasureString(t, New Font("Lucida Calligraphy", 10, FontStyle.Italic), New PointF(0, 0), StringFormat.GenericDefault)
            x = analogueKlock.CenterPoint.PivotalPoint.X - sz.Width / 2
            y = CSng(analogueKlock.Rectangle.Height - analogueKlock.Radius * 0.3 - sz.Height)
            e.Graphics.DrawString(t, Me.Font, sbr, x, y)
            sbr.Dispose()
        End If

        If frmKlock.usrSettings.usrAnalogueKlockShowDate Then
            'Draw month-day box on the clock's background
            Dim str As String = CType(analogueKlock.Value.Month, Months).ToString & " " & analogueKlock.Value.Day
            sz = e.Graphics.MeasureString(str, New Font("Tahoma", 10, FontStyle.Bold), New PointF(0, 0), StringFormat.GenericDefault)
            Dim rec As New Rectangle(CInt(analogueKlock.Rectangle.Width - analogueKlock.Radius * 0.3 - sz.Width), CInt(analogueKlock.CenterPoint.PivotalPoint.Y - 7.5), CInt(sz.Width), CInt(sz.Height))
            Dim br As New Drawing2D.LinearGradientBrush(rec, SystemColors.ControlDark, Color.White, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(br, rec)
            br.Dispose()
            e.Graphics.DrawString(str, New Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, rec, StringFormat.GenericTypographic)
            rec.Inflate(1, 1)
            e.Graphics.DrawRectangle(Pens.White, rec)
        End If
    End Sub

    Private Sub analogueKlock_BigMarkerPainting(ByVal sender As Object, ByVal e As AnalogClock.PaintEventArgs) Handles analogueKlock.BigMarkerPainting, analogueKlock.SmallMarkerPainting
        '   Painting all big-marker objects with different brushes.
        '   With the same fashion you can paint the small-markers.

        Dim m As Marker = DirectCast(sender, AnalogClock.Marker)
        Dim gp As Drawing2D.GraphicsPath = CType(m.Path.Clone, Drawing2D.GraphicsPath)
        Dim p As New Pen(Color.Gray, 2)
        gp.Widen(p)
        p.Dispose()
        e.Graphics.FillPath(Brushes.LightGray, gp)
        gp.Dispose()
        'Make sure the marker's graphics path contains more than 2 points.
        If m.Path.PointCount > 2 Then
            'Make the marker gradient
            Dim br As New Drawing2D.PathGradientBrush(m.Path)
            br.CenterColor = Color.White
            br.SurroundColors = New Color() {m.Color}
            e.Brush = br
            br.Dispose()

        End If
    End Sub

    Private Sub analogueKlock_CenterPointPainting(ByVal sender As Object, ByVal e As AnalogClock.PaintEventArgs) Handles analogueKlock.CenterPointPainting
        '   Painting the centre object with different brushes.

        Dim c As Center = DirectCast(sender, AnalogClock.Center)

        'Make the centre point gradient
        Dim br As New Drawing2D.PathGradientBrush(c.Path)
        br.WrapMode = Drawing2D.WrapMode.Tile
        br.CenterColor = Color.White
        br.SurroundColors = New Color() {c.Color}
        br.CenterPoint = c.PivotalPoint
        e.Brush = br
        br.Dispose()

    End Sub

    ' ------------------------------------------------------------------------------------------------------------------- Providing Custom Elements -----------------

    'Note this events will fire only if an element's style is set to "Custom".

    Private Sub analogueKlock_CustomElementRequest(ByVal sender As Object, ByVal e As AnalogClock.CustomElementEventArgs) Handles analogueKlock.CustomElementRequest

        If sender.GetType Is GetType(AnalogClock.Center) Then
            'The clock's centre-point requests a custom GrapicsPath object.

            'The custom centre GraphicsPath object must be constructed
            'head up position and the midpoint at the clock's centre.
            'Use the centre's properties (pivotal-point, radius etc.) for consistency.


            'This is an octagon style.
            Dim radius As Single = analogueKlock.CenterPoint.Radius
            Dim gPath As New Drawing2D.GraphicsPath
            Dim helper As Single
            Dim points(7) As PointF
            Dim pPoint As PointF = analogueKlock.CenterPoint.PivotalPoint

            helper = CSng(radius * Math.Sin((45.0F * Math.PI) / 180))
            'Create(points)
            points(0) = New PointF(pPoint.X, pPoint.Y - radius)
            points(1) = New PointF(pPoint.X + helper, pPoint.Y - helper)
            points(2) = New PointF(pPoint.X + radius, pPoint.Y)
            points(3) = New PointF(pPoint.X + helper, pPoint.Y + helper)
            points(4) = New PointF(pPoint.X, pPoint.Y + radius)
            points(5) = New PointF(pPoint.X - helper, pPoint.Y + helper)
            points(6) = New PointF(pPoint.X - radius, pPoint.Y)
            points(7) = New PointF(pPoint.X - helper, pPoint.Y - helper)
            'Add lines to the path.
            gPath.AddLines(points)
            gPath.CloseAllFigures()
            e.CustomPath = gPath


        ElseIf sender.GetType Is GetType(AnalogClock.Hand) Then
            'A clock' hand requests a custom GrapicsPath object.

            'The custom hour, minute and second hands GraphicsPath objects
            'must be constructed at 12 o'clock position.
            'Use the hand's properties (with, lengths, pivotal-point etc.) for consistency.

            'This is a pointed style.
            Dim h As Hand = DirectCast(sender, Hand)
            Dim points(3) As PointF
            Dim gPath As New Drawing2D.GraphicsPath
            Dim pPoint As PointF = h.PivotalPoint
            'Create(points)
            points(0) = New PointF(pPoint.X, pPoint.Y - h.PrimeLength)
            points(1) = New PointF(pPoint.X + h.Width / 2, pPoint.Y)
            points(2) = New PointF(pPoint.X, pPoint.Y + h.TailLength)
            points(3) = New PointF(pPoint.X - h.Width / 2, pPoint.Y)
            'Add lines to the path.
            gPath.AddLines(points)
            gPath.CloseAllFigures()
            e.CustomPath = gPath
        ElseIf sender.GetType Is GetType(AnalogClock.Marker) Then
            'A clock' marker requests a custom GrapicsPath object.

            'The custom big and small markers GraphicsPath objects
            'must be constructed at 12 o'clock position.
            'Use the marker's properties (with, length, pivotal-point, radius etc.) for consistency.

            'This is a triangle style.
            Dim m As Marker = DirectCast(sender, Marker)
            Dim pOuter, pInner As PointF
            Dim points(2) As PointF
            Dim gPath As New Drawing2D.GraphicsPath
            Dim pPoint As PointF = m.PivotalPoint

            'Create(points)
            pOuter = New PointF(pPoint.X, analogueKlock.Radius - m.Radius)
            pInner = New PointF(pPoint.X, analogueKlock.Radius - (m.Radius - m.Length))
            points(0) = New PointF(pOuter.X - m.Width / 2, pOuter.Y)
            points(1) = New PointF(pOuter.X + m.Width / 2, pOuter.Y)
            points(2) = pInner
            'Add lines to the path.
            gPath.AddLines(points)
            gPath.CloseAllFigures()
            e.CustomPath = gPath
        End If
    End Sub

    Private Sub analogueKlock_HandPainting(ByVal sender As System.Object, ByVal e As AnalogClock.PaintEventArgs) _
    Handles analogueKlock.SecondHandPainting, analogueKlock.MinuteHandPainting, analogueKlock.HourHandPainting

        'Painting the hour, minute and second hand objects with different brushes.

        Dim h As Hand = DirectCast(sender, Hand)
        Dim gp As Drawing2D.GraphicsPath = CType(h.Path.Clone, Drawing2D.GraphicsPath)
        Dim p As New Pen(Color.Gray, 2)
        gp.Widen(p)
        p.Dispose()
        e.Graphics.FillPath(Brushes.Gray, gp)
        gp.Dispose()
        'Make sure the hand's graphics path contains more than 2 points.
        If h.Path.PointCount > 2 Then
            'Make the hand gradient
            Dim br As New Drawing2D.PathGradientBrush(h.Path)
            br.CenterColor = Color.White
            br.SurroundColors = New Color() {h.Color}
            e.Brush = br
            br.Dispose()
        End If

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        '   Close both analogue and the main klock form.

        Close()
        frmKlock.Close()
    End Sub

    Private Sub frmAnalogueKlock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '   When form is closed turn off timer and re-load main form.
        '   and save analogue klock position if needed.
        '   and save analogue klock mode if needed.
        '   and save analogue klock size if needed.

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        If frmKlock.usrSettings.usrAnalogueKlockSavePosition Then
            frmKlock.usrSettings.usrAnalogueKlockTop = Top
            frmKlock.usrSettings.usrAnalogueKlockLeft = Left
        End If

        If frmKlock.usrSettings.usrAnalogueKlockSizePosition Then
            frmKlock.usrSettings.usrAnalogueKlockWidth = Width
            frmKlock.usrSettings.usrAnalogueKlockHeight = Height
        End If

        frmKlock.usrSettings.writeSettings()                     '   save settings, not sure if anything has changed.
    End Sub

    Private Sub frmAnalogueKlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Set Transparency key on load - makes the form disappear.
        '   and load analogue klock position and size, if needed.

        Me.TransparencyKey = Color.LightBlue
        Me.BackColor = Color.LightBlue

        If frmKlock.usrSettings.usrAnalogueKlockSavePosition Then
            Top = frmKlock.usrSettings.usrAnalogueKlockTop
            Left = frmKlock.usrSettings.usrAnalogueKlockLeft
        End If

        If frmKlock.usrSettings.usrAnalogueKlockSizePosition Then
            Width = frmKlock.usrSettings.usrAnalogueKlockWidth
            Height = frmKlock.usrSettings.usrAnalogueKlockHeight
        End If

        analogueKlockRefresh()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        '   Display the help file.

        Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub

    Private Sub NewStickyNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStickyNoteToolStripMenuItem.Click
        '   Create a new sticky note.

        newStickyNote()
    End Sub

    ' ------------------------------------------------------------------------------------------------------------------------- Context menu -----------------

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        '   Load the options screen.

        frmOptions.tbCntrlOptions.SelectedIndex = 4
        frmOptions.ShowDialog()
    End Sub

    Private Sub ReturnToKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToKlockToolStripMenuItem.Click
        '   Close analogue klock and return to the main klock form.

        Close()
    End Sub
End Class