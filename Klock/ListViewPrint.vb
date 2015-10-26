Module ListViewPrint

    Dim WithEvents pd As New System.Drawing.Printing.PrintDocument

    Sub PrintListView()
        'Used printPreviewDialog instead of printdialog
        'to save paper while debugging.  When finished swith out to PrintDialog.

        'frmNECAudit.PageSetupDialog1.PageSettings = pd.PrinterSettings.DefaultPageSettings


        'If frmNECAudit.PageSetupDialog1.ShowDialog() = DialogResult.OK Then

        '    pd.DefaultPageSettings = frmNECAudit.PageSetupDialog1.PageSettings

        'End If

        pd.DefaultPageSettings.Landscape = True

        Dim PrintPreview As New PrintPreviewDialog

        PrintPreview.Document = pd
        PrintPreview.ShowDialog()

    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        'The below is desined for details view.


        If frmNECAudit.LstVwUnder.View = View.Details Then
            e.PageSettings.Landscape = True
            PrintDetails(e)
        End If
    End Sub

    Private Sub PrintDetails(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Static LastIndex As Integer = 0
        Static CurrentPage As Integer = 0


        Dim crntView As ListView

        Select Case frmNECAudit.tabCntrlAudit.SelectedIndex
            Case 1
                crntView = frmNECAudit.LstVwOvr1000
            Case 3
                crntView = frmNECAudit.LstVwNative
            Case 4
                crntView = frmNECAudit.LstVwUnder
        End Select

        'Getting the current dpi so the textleftpad 'will be the same on a different dpi than 'the 96 i'm using.  Won't make much of a difference though.
        Dim DpiX As Integer = e.Graphics.DpiX
        Dim DpiY As Integer = e.Graphics.DpiY

        Dim X, Y As Integer
        Dim ImageWidth As Integer
        Dim TextRect As Rectangle = Rectangle.Empty
        Dim TextLeftPad As Single = CSng(4 * (DpiY / 96))  '4 pixel pad on the left.
        Dim ColumnHeaderHeight As Single = CSng(crntView.Font.Height + (10 * (DpiX / 96)))
        Dim StringFormat As New StringFormat
        Dim PageNumberWidth As Single = e.Graphics.MeasureString(CStr(CurrentPage), crntView.Font).Width

        'Specify the text should be drawn in the center of the line and that the text should not be wrapped and the text should show
        'ellipsis would cut off.

        StringFormat.FormatFlags = StringFormatFlags.NoWrap
        StringFormat.Trimming = StringTrimming.EllipsisCharacter
        StringFormat.LineAlignment = StringAlignment.Center

        CurrentPage += 1

        'Start the x and  y at the top left margin.
        X = CInt(e.MarginBounds.X)
        Y = CInt(e.MarginBounds.Y)

        'Draw the column headers
        For ColumnIndex As Integer = 0 To crntView.Columns.Count - 1
            TextRect.X = X
            TextRect.Y = Y
            TextRect.Width = crntView.Columns(ColumnIndex).Width
            TextRect.Height = ColumnHeaderHeight

            e.Graphics.FillRectangle(Brushes.LightGray, TextRect)
            e.Graphics.DrawRectangle(Pens.DarkGray, TextRect)

            'TextLeftPad adds a little padding from the gridline.  Add it to the left and subtract it from the right.
            TextRect.X += TextLeftPad
            TextRect.Width -= TextLeftPad

            e.Graphics.DrawString(crntView.Columns(ColumnIndex).Text, crntView.Font, Brushes.Black, TextRect, StringFormat)

            'Move the x position over the width of the column width.  Since I subtracted some padding add the padding back when offsetting.
            X += TextRect.Width + TextLeftPad
        Next

        'Just drew the headers.  Move the Y down the height of the column headers.
        Y += ColumnHeaderHeight

        'Now draw the items.  If this is the first page then the last index will be zero.  If its not then the last index
        'will be the last index we tried to draw but had no room.

        For i = LastIndex To crntView.Items.Count - 1

            With crntView.Items(i)
                'Start the x at the pages left margin.
                X = CInt(e.MarginBounds.X)

                'Check for Last Line
                If Y + .Bounds.Height > e.MarginBounds.Bottom Then
                    'This item won't fit.
                    'subtract 1 from i so the next time this sub is entered we can start with this item.
                    LastIndex = i - 1
                    e.HasMorePages = True
                    StringFormat.Dispose()

                    'Draw the current page number before leaving.
                    e.Graphics.DrawString(CStr(CurrentPage), crntView.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - crntView.Font.Height * 2)

                    Exit Sub
                End If

                'Print Images.
                'The image width is used so we can draw the gridline around the image about to be drawn.  You'll see it below.

                ImageWidth = 0

                If crntView.SmallImageList IsNot Nothing Then
                    'If the image key is set then draw the image with the key .  If not draw the image with theindex.  A tiny bit of validation would be good.

                    If Not String.IsNullOrEmpty(.ImageKey) Then
                        e.Graphics.DrawImage(crntView.SmallImageList.Images(.ImageKey), X, Y)
                    Else
                        e.Graphics.DrawImage(crntView.SmallImageList.Images(.ImageIndex), X, Y)
                    End If
                    ImageWidth = crntView.SmallImageList.ImageSize.Width
                End If

                'Now draw the subitems.  using the columns count so the grid lines can be drawn.  If used the subitems count then
                'the table would not be full if some subitems where less than others.

                For ColumnIndex As Integer = 0 To crntView.Columns.Count - 1
                    TextRect.X = X
                    TextRect.Y = Y
                    TextRect.Width = crntView.Columns(ColumnIndex).Width
                    TextRect.Height = .Bounds.Height

                    If crntView.GridLines Then
                        e.Graphics.DrawRectangle(Pens.DarkGray, TextRect)
                    End If

                    'If an image is drawn then shift over the x to accomadate its width. If this was shifted before
                    'now then the gridline with draw rect above would be on the wrong side of the image.
                    If ColumnIndex = 0 Then TextRect.X += ImageWidth

                    'Add a little padding from the gridline.
                    TextRect.X += TextLeftPad
                    TextRect.Width -= TextLeftPad

                    If ColumnIndex < .SubItems.Count Then
                        'This item has at least the same number of subitems as the current column index.
                        e.Graphics.DrawString(.SubItems(ColumnIndex).Text, crntView.Font, Brushes.Black, TextRect, StringFormat)
                    End If

                    'Shift the x of the width of this subitem. Add some padding to the left side of the text so need to add it back.
                    X += TextRect.Width + TextLeftPad
                Next

                'Set the next line
                Y += .Bounds.Height
            End With
        Next

        'Draw the final page number.
        e.Graphics.DrawString(CStr(CurrentPage), crntView.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - crntView.Font.Height * 2)

        StringFormat.Dispose()
        LastIndex = 0
        CurrentPage = 0

    End Sub

End Module
