Module listBoxThings


    ' ensure that a listbox item is visible
    ' if the second argument is omitted, the index of current item is used
    '
    ' Stolen from http://www.devx.com/vb2themax/Tip/19170

    Sub ListBoxEnsureVisible(lst As ListBox, Optional ByVal itemIndex As Long = -1)

        ' get the number of visible items
        Dim visibleCount As Long = lst.Height / lst.ItemHeight

        ' provide a default for the 2nd argument
        If itemIndex < 0 Then itemIndex = lst.Items.Count

        If itemIndex < lst.TopIndex Then
            ' scroll up
            lst.TopIndex = itemIndex
        ElseIf itemIndex >= lst.TopIndex + visibleCount Then
            ' scroll down
            lst.TopIndex = itemIndex - visibleCount + 1
        End If

    End Sub

End Module
