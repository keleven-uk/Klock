Imports System.IO
Imports System.Globalization
Imports System.Runtime.Serialization.Formatters.Binary

Module DataButtons

    ' **************************************************************************************************** Friends & Events Buttons ***********************
    '   Combined the buttons for both friends and events - they sahe a lot og funcanaslity.
    '   if frmKlock.TbCntrl.SelectedIndex = 5 then operate buttons in friends mode.
    '   if frmKlock.TbCntrl.SelectedIndex = 6 then operate buttons in events mode.
    '
    '   NB :: this saved about 6kb to the executable, but did priduce rather long and comples handler sub routines.
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
    End Sub

    Public Sub btnNew()
        '   Sets up to add new friend / Event.

        frmKlock.btnClear.Enabled = True
        frmKlock.btnNew.Enabled = False
        frmKlock.btnEdit.Enabled = False

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
                frmKlock.savefriends()
            Case 6
                frmKlock.populateEvents("ADD")

                frmKlock.E_ADDING = False

                frmKlock.btnEventsCheck.Enabled = True

                frmKlock.EventsClearText()
                frmKlock.EventsReadOnlyText(True)
                frmKlock.showEvents(0)
                frmKlock.saveEvents()
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
                    frmKlock.savefriends()
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
                    frmKlock.saveEvents()
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
                frmKlock.savefriends()
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
                frmKlock.saveEvents()
        End Select
    End Sub

    Public Sub PanelTop()
        '   Scroll  panel back to top.

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 5
                frmKlock.pnlFriends.ScrollControlIntoView(frmKlock.lblFriendsFirstName)
            Case 6
                frmKlock.pnlEvents.ScrollControlIntoView(frmKlock.lblEventsName)
        End Select
    End Sub

    Public Sub checkDataDirectory()
        '   Check for data directory, which can be user selected [i.e. might not be application starting directory].  if doesn't exist, create it.

        Dim FriendsDirectory As String = frmKlock.usrSettings.usrOptionsSavePath

        If Not My.Computer.FileSystem.DirectoryExists(FriendsDirectory) Then
            frmKlock.displayAction.DisplayReminder("Data", "Creating " & FriendsDirectory)
            My.Computer.FileSystem.CreateDirectory(FriendsDirectory)
        End If
    End Sub
End Module


