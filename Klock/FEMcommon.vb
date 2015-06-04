Imports System.IO
Imports System.Globalization
Imports System.Runtime.Serialization.Formatters.Binary

Module FEMcommon

    ' **************************************************************************************************** Friends & Events Buttons ***********************
    '   Code that is common to Freinds, Events & Memo tabs.
    '   if frmKlock.TbCntrl.SelectedIndex = 5 then operate buttons in friends mode.
    '   if frmKlock.TbCntrl.SelectedIndex = 6 then operate buttons in events mode.
    '   if frmKlock.TbCntrl.SelectedIndex = 7 then operate buttons in memo mode.
    '
    '   NB :: this saved about 6kb to the executable, but does produce rather long and complex sub routines.
    '       [would be even more now then memo added]
    '
    '   Moved the guts of each routing into a seperate module, trying to reduce clutter in main program file - [added about 2k to executable].

    Public Sub ButtonsVisible(ByVal b As Boolean)
        '   Switch on the editing buttons.

        frmKlock.btnNew.Visible = b
        frmKlock.btnAdd.Visible = b
        frmKlock.btnClear.Visible = b
        frmKlock.btnEdit.Visible = b
        frmKlock.btnDelete.Visible = b
        frmKlock.btnEventsCheck.Visible = b

        If frmKlock.TbCntrl.SelectedIndex = 5 Then frmKlock.btnEventsCheck.Visible = False
        If frmKlock.TbCntrl.SelectedIndex = 6 Then frmKlock.btnEventsCheck.Visible = b
        If frmKlock.TbCntrl.SelectedIndex = 7 Then frmKlock.btnEventsCheck.Visible = False
    End Sub

    Public Sub btnNew()
        '   Sets up to add new friend / Event.

        frmKlock.btnClear.Enabled = True
        frmKlock.btnAdd.Enabled = True
        frmKlock.btnNew.Enabled = False
        frmKlock.btnEdit.Enabled = False
        frmKlock.btnDelete.Enabled = False

        PanelTop()

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                frmKlock.txtbxFriendsFirstName.Focus()

                frmKlock.FriendsClearText()
                frmKlock.FriendsReadOnlyText(False)

                frmKlock.F_ADDING = True
            Case 6
                frmKlock.TxtBxEventsName.Focus()

                frmKlock.EventsClearText()
                frmKlock.EventsReadOnlyText(True)

                frmKlock.E_ADDING = True
            Case 7
                frmKlock.TxtBxMemoName.Focus()

                frmKlock.btnMemoDecrypt.Enabled = True
                frmKlock.ChckBxMemoEncypt.Enabled = True

                frmKlock.MemoClearText()
                frmKlock.memoReadOnlyText(True)
        End Select
    End Sub

    Public Sub btnAdd()
        '   Adds a new friend / Event to listview box and saves a new friend / Event file.

        frmKlock.btnNew.Enabled = True
        frmKlock.btnDelete.Enabled = True
        frmKlock.btnEdit.Enabled = True
        frmKlock.btnClear.Enabled = False
        frmKlock.btnAdd.Enabled = False

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                frmKlock.populateFriend("ADD")

                frmKlock.F_ADDING = False

                frmKlock.FriendsClearText()
                frmKlock.FriendsReadOnlyText(True)
                frmKlock.showFriends(0)                       '   Display first friend :: TODO should display new friend ??
                IOcommon.saveFriends()
            Case 6
                frmKlock.populateEvents("ADD")

                frmKlock.E_ADDING = False

                frmKlock.btnEventsCheck.Enabled = True

                frmKlock.EventsClearText()
                frmKlock.EventsReadOnlyText(True)
                frmKlock.showEvents(0)
                IOcommon.saveEvents()
            Case 7
                frmKlock.populateMemo("ADD")

                frmKlock.M_ADDING = False

                frmKlock.MemoClearText()
                frmKlock.memoReadOnlyText(True)
                frmKlock.showMemo(0)
                IOcommon.saveMemo()
        End Select
    End Sub

    Public Sub btnClear()
        '   Clears everything [not sure when called].

        frmKlock.btnEdit.Enabled = False
        frmKlock.btnEdit.Text = "Edit"
        frmKlock.btnClear.Enabled = False
        frmKlock.btnAdd.Enabled = False
        frmKlock.btnNew.Enabled = True

        PanelTop()

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                frmKlock.F_ADDING = False

                If frmKlock.LstBxFriends.Items.Count > 0 Then
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.showFriends(0)
                Else
                    frmKlock.btnEdit.Enabled = False
                    frmKlock.FriendsClearText()
                End If

                frmKlock.FriendsReadOnlyText(True)
            Case 6
                frmKlock.E_ADDING = False

                If frmKlock.LstBxEvents.Items.Count > 0 Then
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.btnEventsCheck.Enabled = True
                    frmKlock.showEvents(0)
                    frmKlock.tmrEvents.Interval = frmKlock.usrSettings.usrEventsTimerInterval * 60      '   interval is held in minutes
                    frmKlock.tmrEvents.Enabled = True                                                   '   enable events timer.
                Else
                    frmKlock.btnEdit.Enabled = False
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnEventsCheck.Enabled = False
                    frmKlock.EventsClearText()
                    frmKlock.tmrEvents.Enabled = False                                                  '   disable events timer.
                End If

                frmKlock.EventsReadOnlyText(False)
            Case 7
                frmKlock.M_ADDING = False

                frmKlock.btnMemoDecrypt.Enabled = False
                frmKlock.ChckBxMemoEncypt.Enabled = False

                If frmKlock.LstBxMemo.Items.Count > 0 Then
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.showMemo(0)
                Else
                    frmKlock.btnEdit.Enabled = False
                    frmKlock.MemoClearText()
                End If
                frmKlock.memoReadOnlyText(False)
        End Select
    End Sub

    Public Sub btnEdit()
        '   allows selected entry in listveiw box to be edited.
        '   Changed button to "Save", which then will save new data to selected entry and save new friend / Event file.

        PanelTop()

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                If frmKlock.btnEdit.Text = "Edit" Then
                    frmKlock.txtbxFriendsFirstName.Focus()
                    frmKlock.btnEdit.Text = "Save"
                    frmKlock.btnClear.Enabled = True
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnNew.Enabled = False

                    frmKlock.FriendsReadOnlyText(False)
                Else
                    frmKlock.populateFriend("EDIT")                         '   Save new data back to listview box

                    frmKlock.btnEdit.Text = "Edit"
                    frmKlock.btnClear.Enabled = False
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnNew.Enabled = True

                    frmKlock.FriendsReadOnlyText(True)
                    IOcommon.saveFriends()
                End If
            Case 6
                If frmKlock.btnEdit.Text = "Edit" Then
                    frmKlock.TxtBxEventsName.Focus()
                    frmKlock.btnEdit.Text = "Save"
                    frmKlock.btnClear.Enabled = True
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnNew.Enabled = False

                    frmKlock.EventsReadOnlyText(False)
                Else
                    frmKlock.populateEvents("Edit")                           '   Save new data back to listview box

                    frmKlock.btnEdit.Text = "Edit"
                    frmKlock.btnClear.Enabled = False
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnNew.Enabled = True

                    frmKlock.EventsReadOnlyText(True)                         '   Saves new events file.
                    IOcommon.saveEvents()
                End If
            Case 7
                If frmKlock.btnEdit.Text = "Edit" Then
                    frmKlock.TxtBxMemoName.Focus()
                    frmKlock.btnEdit.Text = "Save"
                    frmKlock.btnClear.Enabled = True
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnNew.Enabled = False

                    frmKlock.memoReadOnlyText(True)
                Else
                    frmKlock.populateMemo("EDIT")                         '   Save new data back to listview box

                    frmKlock.btnEdit.Text = "Edit"
                    frmKlock.btnClear.Enabled = False
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnNew.Enabled = True

                    frmKlock.memoReadOnlyText(False)
                    IOcommon.saveMemo()
                End If
        End Select
    End Sub

    Public Sub btnDelete()
        '   Deletes the currently selected entry form the listviewbox.
        '   Saves new friend / Event file and display first entry [if exists].

        Dim reply As MsgBoxResult

        reply = MsgBox("Are you sure to DELETE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")
        If reply = MsgBoxResult.No Then Exit Sub '   Not to delete, exit sub.

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                If frmKlock.LstBxFriends.SelectedIndex > -1 Then                                        '   If entries in listview box.
                    frmKlock.LstBxFriends.Items.RemoveAt(frmKlock.LstBxFriends.SelectedIndex)
                    frmKlock.FriendsClearText()
                    frmKlock.FriendsReadOnlyText(True)
                End If

                If frmKlock.LstBxFriends.Items.Count > 0 Then                                           '   If entries in list view box, after delete.
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.showFriends(0)
                Else                                                                                    '   No entries in listview box after delete.
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnEdit.Enabled = False
                End If
                IOcommon.saveFriends()
            Case 6
                If frmKlock.LstBxEvents.SelectedIndex > -1 Then                                         '   If entries in listview box.
                    frmKlock.LstBxEvents.Items.RemoveAt(frmKlock.LstBxEvents.SelectedIndex)
                    frmKlock.EventsClearText()
                    frmKlock.EventsReadOnlyText(True)
                End If

                If frmKlock.LstBxEvents.Items.Count > 0 Then                                            '   If entries in list view box, after delete.
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.btnEventsCheck.Enabled = True
                    frmKlock.showEvents(0)
                    frmKlock.tmrEvents.Interval = frmKlock.usrSettings.usrEventsTimerInterval * 60      '   interval is held in minutes
                    frmKlock.tmrEvents.Enabled = True                                                   '   enable events timer.
                Else                                                                                    '   No entries in listview box after delete.
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnEdit.Enabled = False
                    frmKlock.btnEventsCheck.Enabled = False
                    frmKlock.tmrEvents.Enabled = False                                                  '   enable events timer.
                End If
                IOcommon.saveEvents()
            Case 7
                If frmKlock.LstBxMemo.SelectedIndex > -1 Then                                        '   If entries in listview box.
                    frmKlock.LstBxMemo.Items.RemoveAt(frmKlock.LstBxMemo.SelectedIndex)
                    frmKlock.MemoClearText()
                    frmKlock.memoReadOnlyText(True)
                End If

                If frmKlock.LstBxMemo.Items.Count > 0 Then                                           '   If entries in list view box, after delete.
                    frmKlock.btnDelete.Enabled = True
                    frmKlock.btnEdit.Enabled = True
                    frmKlock.showMemo(0)
                Else                                                                                    '   No entries in listview box after delete.
                    frmKlock.btnDelete.Enabled = False
                    frmKlock.btnEdit.Enabled = False
                End If
                IOcommon.saveMemo()
        End Select
    End Sub

    Public Sub PanelTop()
        '   Scroll  panel back to top.

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                frmKlock.pnlFriends.ScrollControlIntoView(frmKlock.lblFriendsFirstName)
            Case 6
                frmKlock.pnlEvents.ScrollControlIntoView(frmKlock.lblEventsName)
            Case 7
                frmKlock.pnlMemo.ScrollControlIntoView(frmKlock.lblMemoName)
        End Select
    End Sub

End Module


