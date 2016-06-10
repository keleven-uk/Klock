Imports System.Runtime.InteropServices

Public Class frmKlock

    Public CL_MONITORED As Boolean = False

    Public CountDownTime As Integer                 '   Holds number of minutes for the countdown timer.
    Public displayAction As selectAction            '   instance of selectAction, allows different actions to be performed.

    Public displayOneTime As selectTime             '   instance of selectTime, allows different time formats.
    Public displayTimer As Timer                    '   instance of timer, a wrapper of the stopwatch class.
    Public displayTwoTime As selectTime             '   instance of selectTime, allows different time formats.
    Public E_ADDING As Boolean = False              '   Will be true if adding an event, false if editing.
    Public errLogger As Logger

    Public F_ADDING As Boolean = False              '   Will be true if adding an friend, false if editing.

    Public grphcs As Graphics = CreateGraphics()      '   create graphic object globally, used to measure time text width
    Public hours() As String = {"twelve.mp3", "one.mp3", "two.mp3", "three.mp3", "four.mp3", "five.mp3", "six.mp3", "seven.mp3", "eight.mp3",
                                "nine.mp3", "ten.mp3", "eleven.mp3", "twelve.mp3"}    '   create global, not every time.
    Public knownAddress1 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 1.
    Public knownAddress2 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 2.
    Public knownCities As New AutoCompleteStringCollection          '   Auto Complete for friends address city.
    Public knownCounties As New AutoCompleteStringCollection        '   Auto Complete for friends address county.

    Public knownFirstNames As New AutoCompleteStringCollection      '   Auto Complete for friends first name.
    Public knownLastnames As New AutoCompleteStringCollection       '   Auto Complete for friends last name.
    Public knownMiddleNames As New AutoCompleteStringCollection     '   Auto Complete for friends middle name.
    Public knownPostCode As New AutoCompleteStringCollection        '   Auto Complete for friends address post code.
    Public M_ADDING As Boolean = False              '   Will be true if adding an memo, false if editing.
    Public M_SHOW As Boolean = False                '   Will be true if displaying a secret memo test.
    Public myManagedPower As ManagedPower           '   instance of managed Power
    Public myStickyNotes As stickyNotes
    Public reloadEvents As Boolean = True           '   if true, events file will be re-loaded.

    Public reloadFriends As Boolean = True          '   if true, friends file will be re-loaded
    Public reloadMemo As Boolean = True             '   if true, memo file will be re-loaded.
    Public ReminderDateTime As DateTime             '   Holds the date [and time] of the set reminder.

    Public sayings As New List(Of String)

    '   Main Klock application.       K. Scott    November 2012
    '
    '   March 2013      V1.0.1 - added contacts tab                                         [build 14]
    '   June 2013       V1.0.2 - added user settings                                        [build 22]
    '   July 2013       V1.0.3 - added reminder & events tab                                [build 27]
    '   October 2013    V1.0.4 - added memo tab                                             [build 33]
    '   November 2013   V1.0.5 - added Double Agent                                         [build 37] :: parked for now
    '   July 2014       V1.0.6 - added Text Klock                                           [build 39] :: copied from V1.0.4
    '   June 2015       V1.1.0 - Moved to VS2013 & GitHub                                   [build 42]
    '   September 2015  V1.1.1 - Moved to VS2015, added idle time & disable monitor sleep   [build 47]
    '   November 2015   V1.1.2 - added convert tab                                          [build 56]
    '   December 2015   V1.1.3 - Added Big text Klock - more words                          [build 58]
    '   December 2015   V1.1.4 - Added Analogue Klock                                       [build 61]
    '   January 2016    V1.1.5 - Added Sayings                                              [build 64]
    '   February 2016   V1.1.6 - Added clipboard manager                                    [build 65]
    '   March 2016      V1.1.7 - Added [error] logging                                      [build 71]
    '   May 2016        V1.1.8 - added Binary Klock                                         [build 74]
    '   May 2016        V1.1.9 - added Sticky Notes                                         [build 75]


    Public startTime As Integer
    Public usrFonts As UserFonts                    '   instance of user fonts.
    Public usrSettings As UserSettings              '   instance of user settings.
    Public usrVoice As Voice                        '   instance of user voice
    Private Const WM_CHANGECBCHAIN As Integer = &H30D



    ' ** The following code is for the Clipboard Monitor stuff.
    ' ** It is placed here, because it has to register the main form [klock] in the Clipboard viewer chain.

    Private Const WM_DRAWCLIPBOARD As Integer = &H308

    Private mNextClipBoardViewerHWnd As IntPtr
    Private Event OnClipboardChanged()

    Public Sub ClipboardMonitorOff()
        '   Remove yourself from the clipboard viewer chain.
        '   CL_MONITORED is used to we don't try and remove ourselves twice.

        If Not CL_MONITORED Then Exit Sub

        Try
            ChangeClipboardChain(Me.Handle, mNextClipBoardViewerHWnd)
            CL_MONITORED = False
        Catch ex As ArgumentException
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.ClipboardMonitorOff", ex)
            MessageBox.Show("ERROR :: Removing from  clipboard viewer chain" & ex.Message, "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub EventsClearText()
        '   Clears all date entry fields.

        TxtBxEventsName.Text = String.Empty
        txtbxEventNotes.Text = String.Empty

        DtTmPckrEventsDate.Value = Today
    End Sub

    Public Sub EventsReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on text-boxes.
        '   true = can be input of edit.
        '   false = display only

        TxtBxEventsName.ReadOnly = Not b
        CmbBxEventTypes.Enabled = b
        DtTmPckrEventsDate.Enabled = b
        txtbxEventNotes.ReadOnly = Not b
    End Sub

    Public Sub FriendsAddToKnown(ByVal p As Person)
        '   A number of collections are maintained for the auto complete.
        '   One array for each text-box.
        '   Each time a friend is added, the contents of the text box is added to the relevant collections.

        If Not knownFirstNames.Contains(p.FirstName) Then knownFirstNames.Add(p.FirstName)
        If Not knownMiddleNames.Contains(p.MiddleName) Then knownMiddleNames.Add(p.MiddleName)
        If Not knownLastnames.Contains(p.LastName) Then knownLastnames.Add(p.LastName)
        If Not knownAddress1.Contains(p.Address1) Then knownAddress1.Add(p.Address1)
        If Not knownAddress2.Contains(p.Address2) Then knownAddress2.Add(p.Address2)
        If Not knownPostCode.Contains(p.PostCode) Then knownPostCode.Add(p.PostCode)
        If Not knownCities.Contains(p.City) Then knownCities.Add(p.City)
        If Not knownCounties.Contains(p.County) Then knownCounties.Add(p.County)

    End Sub

    Public Sub FriendsClearText()
        '   Clears all date entry fields.

        FEMcommon.PanelTop()

        txtbxFriendsFirstName.Text = String.Empty
        txtbxFriendsMiddleName.Text = String.Empty
        txtbxFriendsLastName.Text = String.Empty
        txtbxFriendsEmail1.Text = String.Empty
        txtbxFriendsEmail2.Text = String.Empty
        txtbxFriendsEmail3.Text = String.Empty
        txtbxFriendsTelephone1.Text = String.Empty
        txtbxFriendsTelephone2.Text = String.Empty
        txtbxFriendsTelephone3.Text = String.Empty
        txtbxFriendsAddressNo.Text = String.Empty
        txtbxFriendsAddressLine1.Text = String.Empty
        txtbxFriendsAddressLine2.Text = String.Empty
        txtbxFriendsAddressCity.Text = String.Empty
        txtbxFriendsAddressPostCode.Text = String.Empty
        txtbxFriendsAddressCounty.Text = String.Empty
        txtbxFriendsHomePage.Text = String.Empty
        txtbxFriendsNotes.Text = String.Empty

        blankFriendsDate()
    End Sub

    Public Sub FriendsReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on the text-boxes.
        '   True = can be input or edit.
        '   False = display only

        txtbxFriendsFirstName.ReadOnly = b
        txtbxFriendsMiddleName.ReadOnly = b
        txtbxFriendsLastName.ReadOnly = b
        txtbxFriendsEmail1.ReadOnly = b
        txtbxFriendsEmail2.ReadOnly = b
        txtbxFriendsEmail3.ReadOnly = b
        txtbxFriendsTelephone1.ReadOnly = b
        txtbxFriendsTelephone2.ReadOnly = b
        txtbxFriendsTelephone3.ReadOnly = b
        txtbxFriendsAddressNo.ReadOnly = b
        txtbxFriendsAddressLine1.ReadOnly = b
        txtbxFriendsAddressLine2.ReadOnly = b
        txtbxFriendsAddressCity.ReadOnly = b
        txtbxFriendsAddressPostCode.ReadOnly = b
        txtbxFriendsAddressCounty.ReadOnly = b
        txtbxFriendsHomePage.ReadOnly = b
        txtbxFriendsNotes.ReadOnly = b

        DtPckrFriendsDOB.Enabled = Not b
    End Sub

    ' ************************************************************************************************************************************** Memo ********

    Public Sub MemoClearText()
        '   Clears all date entry fields.

        TxtBxMemoName.Text = ""
        TxtBxMemo.Text = ""
        ChckBxMemoEncypt.Checked = False
    End Sub

    Public Sub memoReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on text-boxes.
        '   true = can be input of edit.
        '   false = display only

        TxtBxMemoName.ReadOnly = Not b
        TxtBxMemo.ReadOnly = Not b
    End Sub

    Public Sub populateEvents(ByVal mode As String)
        '   populates the events class with the corresponding data from the form.
        '   If adding, the event is added to the list view box, if not the current entry is updated.

        Dim e As New Events

        Try
            e.EventName = TxtBxEventsName.Text
            e.EventType = CmbBxEventTypes.SelectedIndex
            e.EventDate = DtTmPckrEventsDate.Value.ToShortDateString
            e.EventNotes = txtbxEventNotes.Text
            e.EventFirstReminder = True
            e.EventSecondreminder = True
            e.EventThirdReminder = True

            If mode = "ADD" Then
                LstBxEvents.Items.Add(e)                             '   populate list box
                ListBoxEnsureVisible(LstBxEvents)                    '   Scowl list box if needed.
            Else
                LstBxEvents.Items(LstBxEvents.SelectedIndex) = e
                ListBoxEnsureVisible(LstBxEvents)                    '   Scowl list box if needed.
            End If
        Catch ex As Exception
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.populateEvents", ex)
            displayAction.DisplayReminder(ex.Message, "G", "ERROR :: populating event")
        End Try
    End Sub

    Public Sub populateFriend(ByVal mode As String)
        '   populates the person class with the corresponding data from the form.
        '   If adding, the person is added to the list view box, if not the current entry is updated.

        Dim p As New Person

        Try
            p.FirstName = txtbxFriendsFirstName.Text
            p.MiddleName = txtbxFriendsMiddleName.Text
            p.LastName = txtbxFriendsLastName.Text
            p.Email1 = txtbxFriendsEmail1.Text
            p.Email2 = txtbxFriendsEmail2.Text
            p.Email3 = txtbxFriendsEmail3.Text
            p.TelNo1 = txtbxFriendsTelephone1.Text
            p.TelNo2 = txtbxFriendsTelephone2.Text
            p.TelNo3 = txtbxFriendsTelephone3.Text
            p.HouseNo = txtbxFriendsAddressNo.Text
            p.Address1 = txtbxFriendsAddressLine1.Text
            p.Address2 = txtbxFriendsAddressLine2.Text
            p.City = txtbxFriendsAddressCity.Text
            p.PostCode = txtbxFriendsAddressPostCode.Text
            p.County = txtbxFriendsAddressCounty.Text
            p.Notes = txtbxFriendsNotes.Text
            p.WebPage = txtbxFriendsHomePage.Text

            p.DOB = If(DtPckrFriendsDOB.Format = DateTimePickerFormat.Long, DtPckrFriendsDOB.Value.ToShortDateString, " ")  ' if no date selected, save as an empty string i.e." ".

            If mode = "ADD" Then
                LstBxFriends.Items.Add(p)                               '   Populate list-view.
                ListBoxEnsureVisible(LstBxFriends)                      '   Scowl list box if needed.
                FriendsAddToKnown(p)                                    '   Populate autocomplete collections.
            Else    '   mode = "EDIT"
                LstBxFriends.Items(LstBxFriends.SelectedIndex) = p      '   Update list-view.
                ListBoxEnsureVisible(LstBxFriends)                      '   Scowl list box if needed.
            End If

        Catch ex As Exception
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.populateFriend", ex)
            displayAction.DisplayReminder(ex.Message, "G", "ERROR :: populating friend")
        End Try
    End Sub

    Public Sub populateMemo(ByVal mode As String)
        '   populates the memo class with the corresponding data from the form.
        '   If adding, the event is added to the list view box, if not the current entry is updated.

        Dim m As New Memo

        Try
            m.memoName = TxtBxMemoName.Text
            m.memoSecret = ChckBxMemoEncypt.Checked

            If m.memoSecret Then
                Dim password As String = getMemoPassword()
                If password = "-1" Then Exit Sub                        '   cancel been pressed - abort.

                Dim des As New Simple3Des(password)
                m.memoText = des.EncryptData(TxtBxMemo.Text)
            Else
                m.memoText = TxtBxMemo.Text
            End If

            If mode = "ADD" Then
                LstBxMemo.Items.Add(m)
                ListBoxEnsureVisible(LstBxMemo)                     '   Scowl list box if needed.
            Else
                LstBxMemo.Items(LstBxMemo.SelectedIndex) = m
                ListBoxEnsureVisible(LstBxMemo)                     '   Scowl list box if needed.
            End If
        Catch ex As Exception
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.populateMemo", ex)
            displayAction.DisplayReminder(ex.Message, "G", "ERROR :: populating memo")
        End Try
    End Sub


    Public Sub showEvents(ByVal pos As Integer)
        '   populates the text boxes on the form with the event at the specified position of the list view box.

        PanelTop()

        If pos >= 0 Then
            Dim e As Events = CType(LstBxEvents.Items.Item(pos), Events)

            TxtBxEventsName.Text = e.EventName
            DtTmPckrEventsDate.Value = e.EventDate
            CmbBxEventTypes.SelectedIndex = e.EventType
            txtbxEventNotes.Text = e.EventNotes

            LstBxEvents.SelectedIndex = pos
        End If
    End Sub

    Public Sub showFriends(ByVal pos As Integer)
        '   Populates the text boxes on the form with the person at the specified position of the list-view box.

        PanelTop()

        If pos >= 0 Then
            Dim p As Person = CType(LstBxFriends.Items.Item(pos), Person)

            txtbxFriendsFirstName.Text = p.FirstName
            txtbxFriendsMiddleName.Text = p.MiddleName
            txtbxFriendsLastName.Text = p.LastName
            txtbxFriendsEmail1.Text = p.Email1
            txtbxFriendsEmail2.Text = p.Email2
            txtbxFriendsEmail3.Text = p.Email3
            txtbxFriendsTelephone1.Text = p.TelNo1
            txtbxFriendsTelephone2.Text = p.TelNo2
            txtbxFriendsTelephone3.Text = p.TelNo3
            txtbxFriendsAddressNo.Text = p.HouseNo
            txtbxFriendsAddressLine1.Text = p.Address1
            txtbxFriendsAddressLine2.Text = p.Address2
            txtbxFriendsAddressCity.Text = p.City
            txtbxFriendsAddressPostCode.Text = p.PostCode
            txtbxFriendsAddressCounty.Text = p.County
            txtbxFriendsHomePage.Text = p.WebPage
            txtbxFriendsNotes.Text = p.Notes

            If p.DOB = " " Then
                blankFriendsDate()
            Else
                normalFriendsDate()
                DtPckrFriendsDOB.Value = p.DOB
            End If

            LstBxFriends.SelectedIndex = pos
        End If
    End Sub

    Public Sub showMemo(ByVal pos As Integer)
        '   populates the text boxes on the form with the memo at the specified position of the list view box.

        PanelTop()

        If pos >= 0 Then
            Dim m As Memo = CType(LstBxMemo.Items.Item(pos), Memo)

            TxtBxMemoName.Text = m.memoName
            ChckBxMemoEncypt.Checked = m.memoSecret

            If m.memoSecret Then
                TxtBxMemo.Text = "It's a secret"
                btnMemoDecrypt.Enabled = True
            Else
                TxtBxMemo.Text = m.memoText
                btnMemoDecrypt.Enabled = False
            End If

            If M_SHOW = True Then
                Dim password As String = getMemoPassword()

                If password = "-1" Then                                 '   cancel been pressed - abort.
                    TxtBxMemo.Text = "It's a secret"
                    Exit Sub
                End If

                Dim des As New Simple3Des(password)
                Try
                    TxtBxMemo.Text = des.DecryptData(m.memoText)        '   if wrong password, throw exception.
                    TmrMemo.Enabled = True
                    TlStrpPrgrsBrMemo.Visible = True
                Catch ex As Exception
                    If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.showMemo", ex)
                    displayAction.DisplayReminder("Seems to be the wrong password", "G", "Memo Error")
                End Try

                M_SHOW = False
            End If

            LstBxMemo.SelectedIndex = pos
        End If
    End Sub


    Protected Overrides Sub WndProc(ByRef m As Message)
        '   Override WndProc to get messages...

        MyBase.WndProc(m)

        Select Case m.Msg
            Case WM_DRAWCLIPBOARD
                '   if the wm_drawclipboard is received the clipboard changed do what you want and
                '   send the message to the next window in the chain

                RaiseEvent OnClipboardChanged()
                SendMessage(mNextClipBoardViewerHWnd, m.Msg, m.WParam, m.LParam)

            Case WM_CHANGECBCHAIN
                '   Send to the next window 

                If m.WParam.Equals(mNextClipBoardViewerHWnd) Then
                    mNextClipBoardViewerHWnd = m.LParam
                Else
                    SendMessage(mNextClipBoardViewerHWnd, m.Msg, m.WParam, m.LParam)
                End If
        End Select

    End Sub

    <DllImport("user32")>
    Private Shared Function ChangeClipboardChain(ByVal hWnd As IntPtr, ByVal hWndNext As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr,
        ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32")>
    Private Shared Function SetClipboardViewer(ByVal hWnd As IntPtr) As IntPtr
    End Function

    ' ********************************************************************************************************************** time menu stuff *************
    Private Sub AnalogKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalogKlockToolStripMenuItem.Click

        NtfyIcnKlock.Visible = True
        Visible = False
        frmAnalogueKlock.Show()
    End Sub

    Private Sub BigTextKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BigTextKlockToolStripMenuItem.Click
        '   if chosen from menus, switch on a text klock - appears in a separate window.
        '   Will hide main window when created.

        NtfyIcnKlock.Visible = True
        Visible = False

        frmBigTextKlock.Show()
    End Sub

    Private Sub BinaryKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BinaryKlockToolStripMenuItem.Click
        '   if chosen from menus, switch on binary klock - appears in a separate window.
        '   Will hide main window when created.

        NtfyIcnKlock.Visible = True
        Visible = False

        frmBinaryKlock.Show()
    End Sub

    Private Sub blankFriendsDate()
        '   To achieve a blank date in the date picker, a custom format has to be set to ""

        DtPckrFriendsDOB.Format = DateTimePickerFormat.Custom
        DtPckrFriendsDOB.CustomFormat = " "
        DtPckrFriendsDOB.Checked = False
    End Sub

    Private Sub btnConvertAdd_Click(sender As Object, e As EventArgs) Handles btnConvertAdd.Click
        '   enable more conversion units to be added.

        addUnits()
    End Sub

    Private Sub btnConvertStart_Click(sender As Object, e As EventArgs) Handles btnConvertStart.Click
        '   perform the conversion.

        calculate()
        btnConvertStart.Enabled = False
    End Sub

    Private Sub btnCountdown30_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountdown30.Click
        '   runs the countdown for 30 minutes form the quick start button.

        CountDownTime = 30 * 60                                  '   30 minutes in seconds.
        lblCountDownTime.Text = minsToString(CountDownTime)
        btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub btnCountdown60_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountdown60.Click
        '   runs the countdown for 60 minutes form the quick start button.

        CountDownTime = 60 * 60                                  '   60 minutes in seconds.
        lblCountDownTime.Text = minsToString(CountDownTime)
        btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub btnCountdown90_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountdown90.Click
        '   runs the countdown for 90 minutes form the quick start button.

        CountDownTime = 90 * 60                                  '   90 minutes in seconds.
        lblCountDownTime.Text = minsToString(CountDownTime)
        btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub btnCountDownLoadCommand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountDownLoadCommand.Click
        '   Open file dialogue to load command file.

        OpenFileDialog1.Filter = "All Files|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxCountDowndCommand.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnCountdownLoadSound_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountdownLoadSound.Click
        '   Open file dialogue to load sound file.

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            btnCountDownTestSound.Enabled = True
            TxtBxCountDownAction.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnCountDownStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountDownStart.Click
        '   Start the countdown by enabling the timer.
        '   Also, enable the stop button and countdown label and switch off quick start buttons..

        tmrCountDown.Enabled = True

        btnCountDownStart.Enabled = False
        btnCountDownStop.Enabled = True
        upDwnCntDownValue.Enabled = False
        lblCountDownTime.Enabled = True
        QuickStartButtons(False)
    End Sub

    Private Sub btnCountDownStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountDownStop.Click
        '   Clear the countdown.

        CountDownClear()
    End Sub

    Private Sub btnCountdownSystemAbort_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountdownSystemAbort.Click
        '   If abort pressed,  perform system command abort and start clean up.

        displayAction.AbortSystemCommand()
        btnCountdownSystemAbort.Enabled = False

        CountDownClear()
    End Sub

    Private Sub btnCountDownTestSound_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCountDownTestSound.Click
        '   Play sound in test button is pressed.

        displayAction.PlaySound(TxtBxCountDownAction.Text)
    End Sub

    ' ********************************************************************************************************************************** Sayings ******

    Private Sub btnDisplaySayings_Click(sender As Object, e As EventArgs) Handles btnDisplaySayings.Click
        ' Loads a random sayings and displays on the tab page.

        LoadSaying()
    End Sub
    ' ********************************************************************************************************************************* Events ********

    Private Sub btnEventsCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEventsCheck.Click
        '   force a check of the events.

        checkEvents()
    End Sub

    Private Sub btnFriendsAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        '   Adds a new friend / Event to list-view box and saves a new friend / Event file.

        FEMcommon.btnAdd()
    End Sub

    Private Sub btnFriendsClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        '   Clears everything [not sure when called].

        FEMcommon.btnClear()
    End Sub

    Private Sub btnFriendsDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        '   Deletes the currently selected entry form the list-view box.
        '   Saves new friend / Event file and display first entry [if exists].

        FEMcommon.btnDelete()
    End Sub

    Private Sub btnFriendsEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        '   allows selected entry in list-view box to be edited.
        '   Changed button to "Save", which then will save new data to selected entry and save new friend / Event file.

        FEMcommon.btnEdit()
    End Sub

    ' ********************************************************************************************************************** help menu stuff *************
    Private Sub btnHelp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHelp.Click,
                                                                                                  MnItmSubHelp.Click,
                                                                                                  TlStrpMnItmHelp.Click,
                                                                                                  MnItmLicense.Click,
                                                                                                  MnItmHistory.Click,
                                                                                                  MnItmAbout.Click
        '   A Generic handler for the Help menu.

        HelpCommon.displayInfo(sender.ToString)
    End Sub


    Private Sub btnHide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHide.Click
        '   Hides main form and call system tray icon.

        NtfyIcnKlock.Visible = True
        Visible = False
    End Sub

    Private Sub btnMemoDecrypt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMemoDecrypt.Click

        M_SHOW = True
        showMemo(LstBxMemo.SelectedIndex)
    End Sub

    ' **************************************************************************************************** Friends & Events Buttons ***********************
    '   Combined the buttons for both friends and events - they share a lot of functionality.
    '   Moved the guts of each routing into a separate module, trying to reduce clutter in main program file.

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
        '   Sets up to add new friend / Event.

        FEMcommon.btnNew()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '   Print the list-box on the current control tab.

        FEMcommon.btnPrint()
    End Sub

    Private Sub btnReLoadSayings_Click(sender As Object, e As EventArgs) Handles btnReLoadSayings.Click
        '   Reload the sayings from text files.

        sayings.Clear()
        loadSayings()

        If sayings.Count = 0 Then
            lblSayingsNumber.Text = "There are no sayings."
        Else
            lblSayingsNumber.Text = String.Format("There are {0} sayings.", sayings.Count)
            LoadSaying()
        End If
    End Sub

    Private Sub btnReminderClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderClear.Click
        '   Clear reminder is pressed.

        clearReminder()
    End Sub

    Private Sub btnReminderLoadCommand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderLoadCommand.Click
        ' Open file dialogue to load command file.

        OpenFileDialog1.Filter = "All Files|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxReminderCommand.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReminderLoadSound_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderLoadSound.Click
        ' Open file dialogue to load sound file.

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            btnReminderTestSound.Enabled = True
            TxtBxReminderAction.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReminderSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderSet.Click
        '   Set a new reminder.  Sets appropriate text and sets the global reminder date for checking.
        '   Also, enables the reminder timer, which checks if reminder is due every minute..

        Dim d As New DateTime(DtPckrRiminder.Value.Year,
                         DtPckrRiminder.Value.Month,
                         DtPckrRiminder.Value.Day,
                         TmPckrRiminder.Value.Hour,
                         TmPckrRiminder.Value.Minute,
                         0)

        tmrReminder.Enabled = True       '   start reminder timer.

        btnReminderSet.Enabled = False
        btnReminderClear.Enabled = True
        DtPckrRiminder.Visible = False
        ChckBxReminderTimeCheck.Visible = False
        TmPckrRiminder.Visible = False

        lblReminderText.Text = If(ChckBxReminderTimeCheck.Checked, String.Format("Reminder set for {0} @ {1}", ReminderDateTime.ToLongDateString, ReminderDateTime.ToShortTimeString),
                                                                   String.Format("Reminder set for {0}", ReminderDateTime.ToLongDateString))

        ReminderDateTime = d            '   set global, so can be checked by reminder timer.
    End Sub

    Private Sub btnReminderSystemAbort_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderSystemAbort.Click
        '   If abort pressed,  perform system command abort and start clean up.

        displayAction.AbortSystemCommand()
        btnReminderSystemAbort.Enabled = False

        clearReminder()
    End Sub

    Private Sub btnReminderTestSound_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReminderTestSound.Click
        ' Play sound in test button is pressed.

        displayAction.PlaySound(TxtBxReminderAction.Text)
    End Sub

    Private Sub btnTimerClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimerClear.Click
        '   Clears down the countdown, if enables also clear split time.

        displayTimer.clearStopWatch()

        btnTimerClear.Enabled = False
        btnTimerSplit.Enabled = False

        btnTimerStart.Text = "Start"
        btnTimerStart.Enabled = True

        If usrSettings.usrTimerClearSplit Then
            If usrSettings.usrTimerHigh Then
                lblTimerTime.Text = "00:00:00:00"
                lblTimerSplit.Text = "00:00:00:00"
            Else
                lblTimerTime.Text = "00:00:00"
                lblTimerSplit.Text = "00:00:00"
            End If
            btnTimerSplitClear.Enabled = False
        Else
            lblTimerTime.Text = If(usrSettings.usrTimerHigh, "00:00:00:00", "00:00:00")
        End If
    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimerSplit.Click
        '   Copies time to split time.

        lblTimerSplit.Text = lblTimerTime.Text

        btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        lblTimerSplit.Text = If(usrSettings.usrTimerHigh, "00:00:00:00", "00:00:00")

        btnTimerSplitClear.Enabled = False
    End Sub
    '   ************************************************************************************************** timer ***************************************

    Private Sub btnTimerStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimerStart.Click
        '   Start the timer

        displayTimer.startStopWatch()

        tmrTimer.Enabled = True

        btnTimerStop.Enabled = True
        btnTimerSplit.Enabled = True
        btnTimerStart.Enabled = False
        btnTimerClear.Enabled = False
    End Sub

    Private Sub btnTimerStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTimerStop.Click
        '   Stop the timer, allows to be resumed by renaming the start button.

        displayTimer.stopStopWatch()

        tmrTimer.Enabled = False

        btnTimerStop.Enabled = False
        btnTimerClear.Enabled = True

        btnTimerStart.Text = "Resume"
        btnTimerStart.Enabled = True
    End Sub

    Private Sub ChckBxCountDownCommand_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxCountDownCommand.CheckedChanged
        '   Selects run command action controls if checked.

        TxtBxCountDowndCommand.Enabled = Not TxtBxCountDowndCommand.Enabled
        btnCountDownLoadCommand.Enabled = Not btnCountDownLoadCommand.Enabled
    End Sub

    Private Sub ChckBxCountDownReminder_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxCountDownReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        TxtBxCountDownReminder.Enabled = Not TxtBxCountDownReminder.Enabled
    End Sub


    Private Sub ChckBxCountDownSound_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxCountDownSound.CheckedChanged
        '   Selects sound action controls if checked.
        '   NB :: every time the checkbox changes, this toggles the state of the enables flag.

        TxtBxCountDownAction.Enabled = Not TxtBxCountDownAction.Enabled
        btnCountdownLoadSound.Enabled = Not btnCountdownLoadSound.Enabled
        btnCountDownTestSound.Enabled = Not btnCountDownTestSound.Enabled
    End Sub

    Private Sub ChckBxCountdownspeech_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxCountdownSpeech.CheckedChanged
        '   Selects speech action controls if desired.

        TxtBxCountdownSpeech.Enabled = Not TxtBxCountdownSpeech.Enabled
    End Sub

    Private Sub ChckBxCountDownSystem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxCountDownSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        CmbBxCountDownSystem.Enabled = Not CmbBxCountDownSystem.Enabled
    End Sub

    Private Sub chckBXReminderCommand_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chckBXReminderCommand.CheckedChanged
        '   Selects run command action controls if checked.

        TxtBxReminderCommand.Enabled = Not TxtBxReminderCommand.Enabled
        btnReminderLoadCommand.Enabled = Not btnReminderLoadCommand.Enabled
    End Sub

    Private Sub ChckBxReminderReminder_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxReminderReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        TxtBxReminderReminder.Enabled = Not TxtBxReminderReminder.Enabled
    End Sub


    Private Sub ChckBxReminderSound_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxReminderSound.CheckedChanged
        '   Selects sound action controls if checked.
        '   NB :: every time the checkbox changes, this toggles the state of the enables flag.

        TxtBxReminderAction.Enabled = Not TxtBxReminderAction.Enabled
        btnReminderLoadSound.Enabled = Not btnReminderLoadSound.Enabled
        btnReminderTestSound.Enabled = Not btnReminderTestSound.Enabled
    End Sub

    Private Sub ChckBxReminderSpeech_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxReminderSpeech.CheckedChanged
        '   Selects speech command action controls if checked.

        TxtBxReminderSpeech.Enabled = Not TxtBxCountdownSpeech.Enabled
    End Sub

    Private Sub ChckBxReminderSystem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxReminderSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        CmbBxReminderSystem.Enabled = Not CmbBxReminderSystem.Enabled
    End Sub

    Private Sub ChckBxReminderTimeCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChckBxReminderTimeCheck.CheckedChanged
        '   Allows the reminder date to include a time component.  But, not change options.

        If ChckBxReminderTimeCheck.Checked Then
            TmPckrRiminder.Enabled = True
            TmPckrRiminder.Value = Now()
        Else
            TmPckrRiminder.Enabled = False
            TmPckrRiminder.Value = Today
        End If
    End Sub

    Private Sub checkEvents()
        '   For each event, check if a reminder is due.

        '   for each event, check if the number of days to go is under the reminder limit, if so then display a message
        '   and set the reminder to false (not to display again).

        Dim e As Events
        Dim reSave As Boolean = False

        For Each e In LstBxEvents.Items        '   Create list.

            If e.EventFirstReminder And (e.DaysToGo < usrSettings.usrEventsFirstReminder) Then
                displayAction.DisplayEvent(e)
                e.EventFirstReminder = False
                reSave = True
            ElseIf e.EventSecondreminder And (e.DaysToGo < usrSettings.usrEventsSecondReminder) Then
                displayAction.DisplayEvent(e)
                e.EventSecondreminder = False
                reSave = True
            ElseIf e.EventThirdReminder And (e.DaysToGo < usrSettings.usrEventsThirdReminder) Then
                displayAction.DisplayEvent(e)
                e.EventThirdReminder = False
                reSave = True
            End If
        Next

        If reSave Then
            IOcommon.saveEvents()
        Else
            displayAction.DisplayReminder("No events near", "G", "Events")
        End If

    End Sub

    Private Sub clearReminder()
        '   Perform the reminder clear.

        ChckBxReminderSound.Checked = False
        ChckBxReminderReminder.Checked = False
        ChckBxReminderSystem.Checked = False
        chckBXReminderCommand.Checked = False

        btnReminderClear.Enabled = False

        tmrReminder.Enabled = False                              '   stop reminder timer.

        DtPckrRiminder.Visible = True
        ChckBxReminderTimeCheck.Visible = True
        TmPckrRiminder.Visible = True

        If usrSettings.usrReminderTimeChecked Then
            ChckBxReminderTimeCheck.Checked = True
            TmPckrRiminder.Enabled = True
            TmPckrRiminder.Value = Now()
        Else
            ChckBxReminderTimeCheck.Checked = False
            TmPckrRiminder.Enabled = False
            TmPckrRiminder.Value = Today
        End If

        lblReminderText.Text = "Reminder Not set"
    End Sub

    Private Sub ClipBoardChanged()
        '   Clipboard has data.
        '   Only adds the data is not already remembered - so only one instance of data is displayed.
        '   This gets around the problem been triggered by klock copying to the clipboard :-)

        '   Handles data as text, file, image

        frmClipboardMonitor.handleClipboardChanged()
    End Sub

    Sub ClipboardMonitorON()
        '   Add yourself to the clipboard viewer chain.
        '   CL_MONITORED is used to we don't add ourself twice.

        If CL_MONITORED Then Exit Sub

        Try
            mNextClipBoardViewerHWnd = SetClipboardViewer(Me.Handle)
            AddHandler Me.OnClipboardChanged, AddressOf ClipBoardChanged
            CL_MONITORED = True
        Catch ex As ArgumentException
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.ClipboardMonitorON", ex)
            MessageBox.Show("ERROR :: adding to clipboard viewer chain" & ex.Message, "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' *************************************************************************************************************************** menu stuff *************
    Private Sub closeKlock(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click, MnItmExit.Click, TlStrpMnItmExit.Click
        '   Close application.
        '   Called from close button, main menu [file / exit] and system tray right click menu.

        If usrSettings.usrLogging Then errLogger.logMessage("closeKlockd", "Klock Closing")

        Close()
    End Sub

    ' ******************************************************************************************************************************** Converter ******
    '   following sub are in conversionThings.vb

    Private Sub CmbBxConvertCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBxConvertCategory.SelectedIndexChanged
        '   The convert categories has changed - re-load the conversion items

        CmbBxConvertTo.Items.Clear()
        unitsLoad("LoadUnits")

        clearTextBoxes()
    End Sub

    Private Sub CmbBxConvertTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBxConvertTo.SelectedIndexChanged
        '   The convert to has changed, clear the test boxes.

        clearTextBoxes()
    End Sub

    Private Sub CmbBxCountDownAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBxCountDownAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate  action controls.

        Select Case CmbBxCountDownAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                CountDownSound(True)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(False)
                CountdownSpeech(False)
                CountdownScreenSaver(False)
            Case 1                                                  '   Reminder chosen
                CountDownSound(False)
                CountDownReminder(True)
                CountDownSystem(False)
                CountDownCommand(False)
                CountdownSpeech(False)
                CountdownScreenSaver(False)
            Case 2                                                  '   System action chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(True)
                CountDownCommand(False)
                CountdownSpeech(False)
                CountdownScreenSaver(False)
            Case 3                                                  '   Run Command chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(True)
                CountdownSpeech(False)
                CountdownScreenSaver(False)
            Case 4                                                  '   Speak chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(False)
                CountdownSpeech(True)
                CountdownScreenSaver(False)
            Case 5                                                  '   Screen Saver chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(False)
                CountdownSpeech(False)
                CountdownScreenSaver(True)
        End Select
    End Sub
    ' **************************************************************************************************** Reminder ****************************************

    Private Sub CmbBxReminderAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBxReminderAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate action controls.

        Select Case CmbBxReminderAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                ReminderSound(True)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(False)
                ReminderSpeech(False)
                ReminderScreenSaver(False)
            Case 1                                                  '   Reminder chosen
                ReminderSound(False)
                ReminderReminder(True)
                ReminderSystem(False)
                ReminderCommand(False)
                ReminderSpeech(False)
                ReminderScreenSaver(False)
            Case 2                                                  '   System action chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(True)
                ReminderCommand(False)
                ReminderSpeech(False)
                ReminderScreenSaver(False)
            Case 3                                                  '   Run Command chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(True)
                ReminderSpeech(False)
                ReminderScreenSaver(False)
            Case 4                                                  '   speech chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(False)
                ReminderSpeech(True)
                ReminderScreenSaver(False)
            Case 5                                                  '   Screen Saver chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(False)
                ReminderSpeech(False)
                ReminderScreenSaver(True)
        End Select
    End Sub

    'TODO :: following two subs should be combined
    Private Sub CmbBxTimeOne_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBxTimeOne.SelectedIndexChanged
        '   Inform displayTime of the chosen time format.

        displayOneTime.setType = CmbBxTimeOne.SelectedIndex
    End Sub

    Private Sub CmbBxTimeTwo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBxTimeTwo.SelectedIndexChanged
        '   Inform displayTime of the chosen time format.

        displayTwoTime.setType = CmbBxTimeTwo.SelectedIndex
    End Sub

    ' ********************************************************************************************************************************* World Klock ******
    Private Sub CmbBxWorldKlockTimeZones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbBxWorldKlockTimeZones.SelectedIndexChanged
        '   Call update on world klock when a new time zone is chosen.
        '   This is called from the main timer if the world klock is visible, following sub's don't then need to call this.

        updateWorldKlock()
    End Sub

    Sub CountDownAction()
        '   When Countdown is finished, perform desired action
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropriate controls.

        If ChckBxCountDownSound.Checked Then                                '   do sound action.
            ChckBxCountDownSound.Checked = False
            displayAction.PlaySound(TxtBxCountDownAction.Text)
        End If
        If ChckBxCountDownReminder.Checked Then                             '   do reminder action.
            ChckBxCountDownReminder.Checked = False
            displayAction.DisplayReminder(TxtBxCountDownReminder.Text, "G", "CountDown")
        End If
        If ChckBxCountDownSystem.Checked Then                               '   do system action.
            If NtfyIcnKlock.Visible Then                                    '   if main form not visible, then show
                NtfyIcnKlock.Visible = False                                '   so abort button can be deployed.
                Visible = True
            End If
            ChckBxCountDownSystem.Checked = False
            btnCountdownSystemAbort.Enabled = True                          '   Allows system command to be aborted.
            displayAction.DoSystemCommand(CmbBxCountDownSystem.SelectedIndex)
        End If
        If ChckBxCountDownCommand.Checked Then                              '   do run command action.
            ChckBxCountDownCommand.Checked = False
            displayAction.DoCommand(TxtBxCountDowndCommand.Text)
        End If
        If ChckBxCountdownSpeech.Checked Then                               '   do speech action.
            ChckBxCountdownSpeech.Checked = False
            usrVoice.Say(TxtBxCountdownSpeech.Text)
        End If
        If ChckBxCountdownScreenSaver.CheckAlign Then                       '   call screen saver
            ChckBxCountdownScreenSaver.Checked = False
            displayAction.ScreenSaver()
        End If
    End Sub

    Sub CountDownClear()
        '   Clear down Countdown.

        ChckBxCountDownSound.Checked = False
        ChckBxCountDownReminder.Checked = False
        ChckBxCountDownSystem.Checked = False
        ChckBxCountDownCommand.Checked = False

        tmrCountDown.Enabled = False
        lblCountDownTime.Text = "00:00"
        lblCountDownTime.Enabled = False
        upDwnCntDownValue.Enabled = True
        upDwnCntDownValue.Value = 0

        btnCountDownStart.Enabled = False
        btnCountDownStop.Enabled = False

        QuickStartButtons(True)
    End Sub

    Sub CountDownCommand(ByVal b As Boolean)
        '   Sets visible to b for all command components

        ChckBxCountDownCommand.Visible = b
        TxtBxCountDowndCommand.Visible = b
        btnCountDownLoadCommand.Visible = b
    End Sub

    Sub CountDownReminder(ByVal b As Boolean)
        '   Sets visible to b for all reminder components

        ChckBxCountDownReminder.Visible = b
        TxtBxCountDownReminder.Visible = b
    End Sub

    Sub CountdownScreenSaver(ByVal b As Boolean)
        '   set visible to b for all screen saver components

        ChckBxCountdownScreenSaver.Visible = b
    End Sub

    Sub CountDownSound(ByVal b As Boolean)
        '   Sets visible to b for all sound components

        ChckBxCountDownSound.Visible = b
        TxtBxCountDownAction.Visible = b
        btnCountdownLoadSound.Visible = b
        btnCountDownTestSound.Visible = b
    End Sub

    Sub CountdownSpeech(ByVal b As Boolean)
        '   sets visible to b for all speech components

        ChckBxCountdownSpeech.Visible = b
        TxtBxCountdownSpeech.Visible = b
    End Sub

    Sub CountDownSystem(ByVal b As Boolean)
        '   Sets visible to b for all system components

        ChckBxCountDownSystem.Visible = b
        CmbBxCountDownSystem.Visible = b
        btnCountdownSystemAbort.Visible = b
    End Sub

    ' ********************************************************************************************************************** monitor menu stuff *************

    Private Sub DisableSleepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitorDisableSleep.Click
        '   If chosen from menus, disable the monitor from going to sleep.

        If MonitorDisableSleep.Checked Then
            usrSettings.usrDisableMonitorSleep = True
            KlockThings.KeepMonitorActive()
        Else
            usrSettings.usrDisableMonitorSleep = False
            KlockThings.RestoreMonitorSettings()
        End If
    End Sub

    Private Sub DisplayIdleTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayIdleTime.Click
        '   If chosen from menus, display idle time in status bar.

        usrSettings.usrTimeIdleTime = DisplayIdleTime.Checked
    End Sub


    Private Sub DisplayTwoTimeFormatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayTwoTimeFormatsToolStripMenuItem.Click
        '   If chosen from menus, switch on two time formats.

        usrSettings.usrTimeTwoFormats = DisplayTwoTimeFormatsToolStripMenuItem.Checked
        CmbBxTimeTwo.Visible = DisplayTwoTimeFormatsToolStripMenuItem.Checked
        LblTimeTwoTime.Visible = DisplayTwoTimeFormatsToolStripMenuItem.Checked
        GroupBox14.Visible = DisplayTwoTimeFormatsToolStripMenuItem.Checked                    '   sorry i don't name group-boxes
        GroupBox15.Visible = DisplayTwoTimeFormatsToolStripMenuItem.Checked

    End Sub

    Private Sub DtPckrFriendsDOB_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DtPckrFriendsDOB.ValueChanged
        '   If the value of the date picker is altered, reset then date format back to long.

        normalFriendsDate()

        '   only allow to be added to events, if first name and dob contain data - does not check if valid.
        ChckBxAddToEvents.Enabled = DtPckrFriendsDOB.Checked And txtbxFriendsFirstName.Text <> ""
    End Sub

    ' **************************************************************************************************** Friends ****************************************

    Private Sub FirstAndLastName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtbxFriendsFirstName.TextChanged, txtbxFriendsLastName.TextChanged
        '   Only allow adding if first and last name exist.

        If F_ADDING Then btnAdd.Enabled = If((txtbxFriendsFirstName.Text <> "" And txtbxFriendsLastName.Text <> ""), True, False)
    End Sub

    Private Sub FriendsTelephone1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtbxFriendsTelephone1.KeyPress, txtbxFriendsTelephone2.KeyPress, txtbxFriendsTelephone3.KeyPress
        '   Telephone numbers may only contain numbers.

        If Char.IsNumber(e.KeyChar) Then

        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmKlock_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   On form close and if needed, [order seems to be important] 
        '       Turn off clipboard monitoring and removed form from clipboard viewer chain.
        '       Save Form position.
        '       Write settings.
        '       Restore monitor settings.
        '       Dispose of graphics object.

        If usrSettings.usrLogging Then errLogger.logMessage("frmKlock_FormClosing", "Klock Closing")

        If CL_MONITORED Then ClipboardMonitorOff()       '   turn off clipboard monitoring

        If usrSettings.usrSavePosition Then
            usrSettings.usrFormTop = Top
            usrSettings.usrFormLeft = Left
        End If

        KlockThings.RestoreMonitorSettings()            '   restore system monitor sleep settings, just in case been altered.

        usrSettings.writeSettings()                     '   save settings, not sure if anything has changed.

        grphcs.Dispose()

    End Sub

    Private Sub frmKlock_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        '   Processes key presses at form level, before passed to components.
        '   The rest of the codes is so that enter is handled correctly when inputting a new friend / event / memo.  
        '   Pressing Enter Or hitting the tab key will do the same thing, that is move focus to the next data entry box.

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


        HotKeys(e, Me)              '   in KlockThings.vb

        If TbCntrl.SelectedIndex < 5 Then   '   if not friends / events / memo tab - ignore reminder of sub.
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then
            e.SuppressKeyPress = True

            ' Make sure that the active control is a TextBox control
            ' Do not use the Enter key as tab when a button has the focus!
            If ActiveControl.GetType Is GetType(TextBox) Or ActiveControl.GetType Is GetType(CheckBox) Or ActiveControl.GetType Is GetType(DateTimePicker) Then
                ProcessTabKey(e.Shift)                     ' Use Shift + Enter to move backwards through the tab order
            End If
        End If
    End Sub

    ' ******************************************************************************************************************************** Global Stuff ******

    Private Sub frmKlock_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '   Apply current setting on form load.

        TmrMain.Enabled = False                         '   Turn off main timer while we sort things out.

        startTime = My.Computer.Clock.TickCount         '   used for app running time.
        displayOneTime = New selectTime                 '   user selected time I
        displayTwoTime = New selectTime                 '   user selected time II
        displayAction = New selectAction                '   user selected actions
        displayTimer = New Timer                        '   timer stuff
        usrSettings = New UserSettings                  '   user settings
        usrFonts = New UserFonts                        '   user fonts
        usrVoice = New Voice                            '   user voice
        myManagedPower = New ManagedPower               '   system power source
        errLogger = New Logger
        myStickyNotes = New stickyNotes(usrSettings.usrStickyNoteSavePath)

        errLogger.useLogging = usrSettings.usrLogging
        errLogger.logdaysKeep = usrSettings.usrLogDaysKeep
        errLogger.logFilePath = usrSettings.usrLogFilePath

        If usrSettings.usrLogging Then errLogger.logMessage("frmKlock_Load", "Klock Starting")

        setSettings()                                   '   load user settings
        setTimeTypes()                                  '   load time types into combo box.
        setActionTypes()                                '   load action types into combo box.
        setTimeZones(0)                                 '   load time zones into combo box, making index 0 active.

        DtPckrFriendsDOB.MaxDate = Now()                '   nobody is born after today :-)

        checkUnitsFile()                                '   check for units file - from conversionThings.ucheckUnitsFile()
        unitsLoad("LoadCategory")                       '   load conversion units - from conversionThings.unitsLoad()

        loadSayings()                                   '   Loads the jokes, sayings etc.

        setTitleText()                                  '   set app title text

        HlpPrvdrKlock.HelpNamespace = System.IO.Path.Combine(Application.StartupPath, "klock.chm") '   set up help location

        LstBxFriends.Font = usrFonts.getFont()
        LstBxEvents.Font = usrFonts.getFont()
        LstBxMemo.Font = usrFonts.getFont()

        FEMcommon.ButtonsVisible(False, 0, 0, 0)

        If Not myStickyNotes.isEmpty() Then myStickyNotes.Load()

        TmrMain.Enabled = True                          '   Turn on main timer now things are sorted out.
    End Sub

    Private Sub frmKlock_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        '   If desired, start klock minimised i.e. in system tray.
        '   Did not seem to work in form load, so stuffed in here.
        '
        '   These things don't seem to work in frmKlock_Load

        If usrSettings.usrStartMinimised Then
            NtfyIcnKlock.Visible = True
            Visible = False
        ElseIf usrSettings.usrRememberKlockMode Then
            Select Case usrSettings.usrStartKlockMode
                Case 0
                    '                                                       move along nothing to see - start normal klock.
                Case 1                                                  '   Start analogue klock
                    AnalogKlockToolStripMenuItem.PerformClick()
                Case 2                                                  '   start small text klock.
                    TextKlockToolStripMenuItem.PerformClick()
                Case 3                                                  '   start big text klock.
                    BigTextKlockToolStripMenuItem.PerformClick()
                Case 4
                    BinaryKlockToolStripMenuItem.PerformClick()
                Case Else
                    If usrSettings.usrLogging Then errLogger.logMessage("frmKlock_frmKlock_Shown", "usrSettings.usrRememberKlockMode outside range")
            End Select
        End If
    End Sub

    Private Function getMemoPassword() As String
        '   asks a password for the user.
        '   returns either the password or the default password if allowed.
        '   returns -1 if cancel is pressed - unlikely to be a password.


        Dim password As String = String.Empty

        If usrSettings.usrMemoUseDefaultPassword Then                            '   system set up to use default password.
            password = usrSettings.usrMemoDefaultPassword                        '   return default password.
        Else                                                                        '   prompt user for password.
            frmMemoPassword.ShowDialog()                                            '   display password form.

            '   user pressed ok on password.  return user entered password.
            '   user pressed cancel on password form.  return -1 to tell the world, user pressed cancel.
            password = If(frmMemoPassword.DialogResult = Windows.Forms.DialogResult.OK, frmMemoPassword.TxtBxMemoPassword.Text, "-1")                                                    '   return -1 to tell the world, user pressed cancel.
        End If  '   Me.usrSettings.usrMemoUseDefaultPassword

        Return password
    End Function

    ' ********************************************************************************************************************** info menu stuff *************

    Private Sub InfoMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DaylightSavingToolStripMenuItem.Click,
                                                                                                       CultureToolStripMenuItem.Click,
                                                                                                       OSToolStripMenuItem.Click,
                                                                                                       PowerSourceToolStripMenuItem.Click,
                                                                                                       EasterToolStripMenuItem.Click,
                                                                                                       LentToolStripMenuItem.Click
        '   A Generic handler for the Info menu.

        InfoCommon.displayInfo(sender.ToString)
    End Sub

    Private Sub InternetTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InternetTimeToolStripMenuItem.Click
        '   If chosen from menus, display the time from an internet time server.
        '   Although in the time menu, it calls the info form - more designed to display the time date.
        '   If user settings checkInternet is false, will display no internet connection.


        InfoCommon.displayInfo(sender.ToString)
    End Sub

    Private Sub LoadAutoCompleteStuff()
        '   Attach the relevant auto complete collections to the text boxes.

        txtbxFriendsFirstName.AutoCompleteCustomSource = knownFirstNames
        txtbxFriendsFirstName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsFirstName.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsMiddleName.AutoCompleteCustomSource = knownMiddleNames
        txtbxFriendsMiddleName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsMiddleName.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsLastName.AutoCompleteCustomSource = knownLastnames
        txtbxFriendsLastName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsLastName.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsAddressLine1.AutoCompleteCustomSource = knownAddress1
        txtbxFriendsAddressLine1.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsAddressLine1.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsAddressLine2.AutoCompleteCustomSource = knownAddress2
        txtbxFriendsAddressLine2.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsAddressLine2.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsAddressCity.AutoCompleteCustomSource = knownCities
        txtbxFriendsAddressCity.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsAddressCity.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsAddressPostCode.AutoCompleteCustomSource = knownPostCode
        txtbxFriendsAddressPostCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsAddressPostCode.AutoCompleteMode = AutoCompleteMode.Append

        txtbxFriendsAddressCounty.AutoCompleteCustomSource = knownCounties
        txtbxFriendsAddressCounty.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbxFriendsAddressCounty.AutoCompleteMode = AutoCompleteMode.Append
    End Sub

    Private Sub LstBxEvents_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstBxEvents.SelectedIndexChanged
        '   A new entry has been selected in the list-view box, display new entry.

        showEvents(LstBxEvents.SelectedIndex)
    End Sub

    Private Sub LstBxFriends_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstBxFriends.SelectedIndexChanged
        '   A new entry has been selected in the list-view box, display new entry.

        showFriends(LstBxFriends.SelectedIndex)
    End Sub

    Private Sub LstBxMemo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstBxMemo.SelectedIndexChanged
        '   A new memo has been selected in the list-view box, display new entry.
        '   If timer and progress bar are running - stop.

        If TlStrpPrgrsBrMemo.Visible Then           '   if progress bar is running, so must timer.
            TmrMemo.Enabled = False
            TlStrpPrgrsBrMemo.Visible = False
            TlStrpPrgrsBrMemo.Value = 0
        End If

        showMemo(LstBxMemo.SelectedIndex)
    End Sub

    ' ********************************************************************************************************************************* Sticky Notes *****

    Private Sub NewStickyNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStickyNoteToolStripMenuItem.Click, NewSticktNoteToolStripMenuItem.Click, btnStickyNote.Click
        '   Create a new sticky note.

        newStickyNote()
    End Sub

    Private Sub normalFriendsDate()
        '   To display a date in the date picker, the custom format has to be removed.

        DtPckrFriendsDOB.Format = DateTimePickerFormat.Long
        DtPckrFriendsDOB.CustomFormat = Now().Date
    End Sub

    Private Sub NotificationDispaly(m As Integer)
        '   If desired, check the status of notifications - should display the time every ?? minutes.
        '   Also, display result to time and countdown, if there running.  TO DO, should they be on their own settings?

        displayOneTime.set24Hour = usrSettings.usrTimeOne24Hour
        Try
            NtfyIcnKlock.Text = displayOneTime.getTitle & " : " & displayOneTime.getTime()    '   set icon tool tip to current time [must be less then 64 chars].
        Catch ex As Exception
            If usrSettings.usrLogging Then errLogger.LogExceptionError("frmKlock.NotificationDispaly", ex)
            displayAction.DisplayReminder(ex.Message, "G", "Notification Error")
        End Try

        Dim noSecs As Integer = usrSettings.usrTimeDisplayMinutes * 60

        If usrSettings.usrTimeDisplayMinimised And (Math.Floor(m Mod noSecs) = 0) Then

            Dim text As String = displayOneTime.getTime() & Environment.NewLine & setExtaraTitletext(True)

            displayAction.DisplayReminder(text, "G", "Time")  '   display current time as a toast notification,if desired

            If usrSettings.usrWorldKlockAdd Then

                Dim wctext As String

                If RdBtnWorldClockTimeZoneLongName.Checked Then
                    Dim TzInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(CmbBxWorldKlockTimeZones.SelectedItem.id)
                    wctext = TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongDateString & " :: " & TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongTimeString
                Else
                    wctext = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, CmbBxWorldKlockTimeZones.SelectedItem).ToLongDateString & " :: " & TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, CmbBxWorldKlockTimeZones.SelectedItem).ToLongTimeString
                End If

                displayAction.DisplayReminder(wctext, "G", "World Klock :: " & CmbBxWorldKlockTimeZones.SelectedItem.ToString)
            End If

        End If          '   If Me.usrsettings.usrTimeDislayMinimised
    End Sub

    Private Sub Notificationspeech(ByVal m As Integer)
        '   if desired, check the status of speak time - should speak time every ?? minutes.

        Dim noSecs As Integer = usrSettings.usrTimeVoiceMinutes * 60

        If usrSettings.usrTimeVoiceMinimised And (Math.Floor(m Mod noSecs) = 0) Then usrVoice.Say(displayOneTime.getTime())
    End Sub


    Private Sub OptionsKlock(ByVal sender As Object, ByVal e As EventArgs) Handles MnItmOptions.Click, TlStrpMnItmOptions.Click
        '   Display Settings Screen and apply settings, they may have changed.
        '   Called from main menu [file / options] and system tray right click menu.

        usrSettings.writeSettings()      '   save settings, not sure if anything has changed.
        frmOptions.tbCntrlOptions.SelectedIndex = 0
        frmOptions.ShowDialog()
    End Sub

    Private Sub playHourlyChimes(ByVal m As Integer)
        '   Depending upon user settings, will play hourly pips or chimes.
        '   The chimes can sound on the hour and every quarter hour if desired.

        If usrSettings.usrTimeHourPips And (Math.Floor(m Mod 3600) = 0) Then                                 '    will this work at midnight???

            displayAction.PlaySound(IO.Path.Combine(Application.StartupPath, "sounds\thepips.mp3"))          '    Play the Pips on the hour, if desired.
        ElseIf usrSettings.usrTimeHourChimes And (Math.Floor(m Mod 3600) = 0) Then                           '    Play hourly chimes, if desired.

            Dim hour As Integer = Now.Hour

            If hour > 12 Then hour -= 12

            displayAction.PlaySound(IO.Path.Combine(Application.StartupPath, "sounds\" & hours(hour)))
        ElseIf usrSettings.usrTimeQuarterChimes And (Math.Floor(m Mod 900) = 0) Then                         '    Play quarter chimes, if desired.

            displayAction.PlaySound(IO.Path.Combine(Application.StartupPath, "sounds\quarterchime.mp3"))
        ElseIf usrSettings.usrTimeHalfChimes And (Math.Floor(m Mod 1800) = 0) Then                           '    Play half hourly chimes, if desired.

            displayAction.PlaySound(IO.Path.Combine(Application.StartupPath, "sounds\halfchime.mp3"))
        ElseIf usrSettings.usrTimeQuarterChimes And (Math.Floor(m Mod 2700) = 0) Then                        '    Play three quarter chimes, if desired.

            displayAction.PlaySound(IO.Path.Combine(Application.StartupPath, "sounds\threequarterchime.mp3"))
        End If
    End Sub

    Private Sub QuickStartButtons(ByVal b As Boolean)
        '   toggles the quick start buttons on/off.

        btnCountdown30.Enabled = b
        btnCountdown60.Enabled = b
        btnCountdown90.Enabled = b
    End Sub

    Private Sub RdBtnWorldClockTimeZoneLongName_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RdBtnWorldClockTimeZoneLongName.CheckedChanged, RdBtnWorldClockTimeZoneID.CheckedChanged
        '   reload the combo box with time zones, in either long names or time zone id's.

        Dim pos As Integer = CmbBxWorldKlockTimeZones.SelectedIndex
        setTimeZones(pos)
    End Sub

    Private Sub reminder_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DtPckrRiminder.ValueChanged, TmPckrRiminder.ValueChanged
        '   Checks to see if the reminder date if in the future [> now()], only then enable the set button.

        Dim d As New DateTime(DtPckrRiminder.Value.Year,
                         DtPckrRiminder.Value.Month,
                         DtPckrRiminder.Value.Day,
                         TmPckrRiminder.Value.Hour,
                         TmPckrRiminder.Value.Minute,
                         0)

        btnReminderSet.Enabled = If(d > Now(), True, False)
    End Sub

    Sub ReminderAction()
        '   When Reminder is finished, perform desired action
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropriate controls.

        If ChckBxReminderSound.Checked Then                                  '   do sound action.
            ChckBxReminderSound.Checked = False
            displayAction.PlaySound(TxtBxReminderAction.Text)
        End If
        If ChckBxReminderReminder.Checked Then                               '   do reminder action.
            ChckBxReminderReminder.Checked = False
            displayAction.DisplayReminder(TxtBxReminderReminder.Text, "G", "Reminder")
        End If
        If ChckBxReminderSystem.Checked Then                                 '   do system action.
            If NtfyIcnKlock.Visible Then                                     '   if main form not visible, then show
                NtfyIcnKlock.Visible = False                                 '   so abort button can be deployed.
                Visible = True
            End If
            ChckBxReminderSystem.Checked = False
            btnReminderSystemAbort.Enabled = True                            '   Allows system command to be aborted.
            displayAction.DoSystemCommand(CmbBxReminderSystem.SelectedIndex)
        End If
        If chckBXReminderCommand.Checked Then                                '   do run command action.
            chckBXReminderCommand.Checked = False
            displayAction.DoCommand(TxtBxReminderCommand.Text)
        End If
        If ChckBxReminderSpeech.Checked Then                                 '   do speech action.
            ChckBxReminderSpeech.Checked = False
            usrVoice.Say(TxtBxReminderSpeech.Text)
        End If
        If ChckBxReminderScreenSaver.Checked Then                           '   call screen saver.
            ChckBxReminderScreenSaver.Checked = False
            displayAction.ScreenSaver()
        End If
    End Sub

    Private Sub ReminderCommand(ByVal b As Boolean)
        '   Sets visible to b for all command components

        chckBXReminderCommand.Visible = b
        TxtBxReminderCommand.Visible = b
        btnReminderLoadCommand.Visible = b
    End Sub

    Private Sub ReminderReminder(ByVal b As Boolean)
        '   Sets visible to b for all reminder components

        ChckBxReminderReminder.Visible = b
        TxtBxReminderReminder.Visible = b
    End Sub

    Private Sub ReminderScreenSaver(ByVal b As Boolean)
        '   Sets visible to b for all screen saver components

        ChckBxReminderScreenSaver.Visible = b
    End Sub

    Sub ReminderSound(ByVal b As Boolean)
        '   Sets visible to b for all sound components

        ChckBxReminderSound.Visible = b
        TxtBxReminderAction.Visible = b
        btnReminderLoadSound.Visible = b
        btnReminderTestSound.Visible = b
    End Sub

    Private Sub ReminderSpeech(ByVal b As Boolean)
        '   Sets visible to b for all command components

        ChckBxReminderSpeech.Visible = b
        TxtBxReminderSpeech.Visible = b
    End Sub

    Private Sub ReminderSystem(ByVal b As Boolean)
        '   Sets visible to b for all system components

        ChckBxReminderSystem.Visible = b
        CmbBxReminderSystem.Visible = b
        btnReminderSystemAbort.Visible = b
    End Sub

    Sub setActionTypes()
        '   Loads the different action types and load into combo box.
        '   Loads the different system action types and load into combo box.
        '   Also use this sub to load the event types and periods into there respective combo boxes.


        Dim actionNames = System.Enum.GetNames(GetType(selectAction.ActionTypes))
        Dim systemNames = System.Enum.GetNames(GetType(selectAction.SystemTypes))
        Dim eventTypes = System.Enum.GetNames(GetType(Events.EventTypes))

        CmbBxCountDownAction.Items.AddRange(actionNames)
        CmbBxCountDownSystem.Items.AddRange(systemNames)

        CmbBxReminderAction.Items.AddRange(actionNames)
        CmbBxReminderSystem.Items.AddRange(systemNames)

        CmbBxEventTypes.Items.AddRange(eventTypes)

        CmbBxCountDownAction.SelectedIndex = 0       '   until I know how to do this at design time :o)
        CmbBxReminderAction.SelectedIndex = 0
        CmbBxEventTypes.SelectedIndex = 0
    End Sub

    Sub setSettings()
        '   Apply current settings,

        usrSettings.readSettings()           '   read settings file, if not there a default one will be created.

        TbCntrl.SelectedIndex = usrSettings.usrDefaultTab

        BackColor = usrSettings.usrFormColour
        StsStrpInfo.BackColor = usrSettings.usrFormColour
        MainMenuStrip.BackColor = usrSettings.usrFormColour

        TbPgTime.BackColor = usrSettings.usrFormColour
        TbPgCountDown.BackColor = usrSettings.usrFormColour
        TbPgTimer.BackColor = usrSettings.usrFormColour
        TbPgReminder.BackColor = usrSettings.usrFormColour

        If usrSettings.usrSavePosition Then
            Top = usrSettings.usrFormTop
            Left = usrSettings.usrFormLeft
        End If

        If usrSettings.usrTimerHigh Then
            lblTimerTime.Text = "00:00:00:00"
            lblTimerSplit.Text = "00:00:00:00"
        Else
            lblTimerTime.Text = "00:00:00"
            lblTimerSplit.Text = "00:00:00"
        End If

        TlStrpMnItmTime.Checked = usrSettings.usrTimeDisplayMinimised
        ChckBxReminderTimeCheck.Checked = usrSettings.usrReminderTimeChecked
        DisplayIdleTime.Checked = usrSettings.usrTimeIdleTime
        MonitorDisableSleep.Checked = usrSettings.usrDisableMonitorSleep

        CmbBxTimeTwo.Visible = usrSettings.usrTimeTwoFormats                                '   switch on second time format, if desired.
        LblTimeTwoTime.Visible = usrSettings.usrTimeTwoFormats
        GroupBox14.Visible = usrSettings.usrTimeTwoFormats                                  '   sorry i don't name group-boxes
        GroupBox15.Visible = usrSettings.usrTimeTwoFormats
        DisplayTwoTimeFormatsToolStripMenuItem.Checked = usrSettings.usrTimeTwoFormats      '   Set menu check accordingly.
        DisplayIdleTime.Checked = usrSettings.usrTimeIdleTime                               '   

        If reloadFriends Then
            IOcommon.loadFriends()
            blankFriendsDate()
            LoadAutoCompleteStuff()

            If TbCntrl.SelectedIndex = 5 And LstBxFriends.Items.Count > 0 Then
                btnDelete.Enabled = True
                btnEdit.Enabled = True
                showFriends(0)
            End If
        End If

        If reloadEvents Then IOcommon.loadEvents()
        If LstBxEvents.Items.Count > 0 Then checkEvents()
        If reloadMemo Then IOcommon.loadMemo()

        reloadFriends = False                                           '   set to re-load friends file to false.
        reloadEvents = False                                            '   set to re-load events file to false.
        reloadMemo = False                                              '   set to re-load memo file to false

        TlStrpPrgrsBrMemo.Minimum = 0                                   '   set up memo
        TlStrpPrgrsBrMemo.Step = 1
        TlStrpPrgrsBrMemo.Maximum = usrSettings.usrMemoDecyptTimeOut

        tmrSayings.Enabled = usrSettings.usrSayingsDisplay              '   set up saying timer.

        My.Computer.Clipboard.Clear()                                   '   Clear clipboard on start up.

        If usrSettings.usrClipboardMonitor Then    '   set up clipboard monitoring
            ClipboardMonitorON()
        Else
            ClipboardMonitorOff()
        End If

        If usrSettings.usrDisableMonitorSleep Then
            If usrSettings.usrLogging Then errLogger.logMessage("frmKlock_setSettings", "Keep Monitor Active")
            KeepMonitorActive()
        Else
            If usrSettings.usrLogging Then errLogger.logMessage("frmKlock_setSettings", "Restore Monitor Settings")
            RestoreMonitorSettings()
        End If
    End Sub

    '   ************************************************************************************************** time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        CmbBxTimeOne.Items.AddRange(names)
        CmbBxTimeTwo.Items.AddRange(names)
        frmOptions.cmbBxDefaultTimeFormat.Items.AddRange(names)
        frmOptions.cmbBxDefaultTimeTwoFormat.Items.AddRange(names)

        CmbBxTimeOne.SelectedIndex = usrSettings.usrTimeDefaultFormat
        CmbBxTimeTwo.SelectedIndex = usrSettings.usrTimeTWODefaultFormat
        frmOptions.cmbBxDefaultTimeFormat.SelectedIndex = usrSettings.usrTimeDefaultFormat
        frmOptions.cmbBxDefaultTimeTwoFormat.SelectedIndex = usrSettings.usrTimeTWODefaultFormat
    End Sub

    Private Sub setTimeZones(ByVal pos As Integer)
        '   Load the time zones into the World Klock Combo Box.
        '   Slightly different update, depending on if long name of id's are being used for time zones.
        '   Argument passed in is the position of the current time zone, so it can be restored.

        Dim f As System.TimeZoneInfo

        CmbBxWorldKlockTimeZones.Items.Clear()

        For Each f In TimeZoneInfo.GetSystemTimeZones
            If RdBtnWorldClockTimeZoneLongName.Checked Then
                CmbBxWorldKlockTimeZones.Items.Add(f)
            Else
                CmbBxWorldKlockTimeZones.Items.Add(f.Id)
            End If
        Next

        CmbBxWorldKlockTimeZones.SelectedIndex = pos
    End Sub

    '
    '   End Of Clock Routines
    '
    '
    '   *************************************************************************************** Global Tab Change ****************************************

    Private Sub TbCntrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TbCntrl.SelectedIndexChanged
        '    Performed when ever the main tab is changed, used for any tab initialisation.

        Select Case TbCntrl.SelectedIndex
            Case 0                                              '   time tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)
            Case 1                                              '   World Klock
                FEMcommon.ButtonsVisible(False, 0, 0, 0)
                updateWorldKlock()
            Case 2                                              '   countdown tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)
            Case 3                                              '   timer tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)
            Case 4                                              '   reminder tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)

                If usrSettings.usrReminderTimeChecked Then
                    TmPckrRiminder.Enabled = True
                    TmPckrRiminder.Value = Now()
                Else
                    TmPckrRiminder.Enabled = False
                    TmPckrRiminder.Value = Today
                End If
            Case 5                                              '   friends tab         NB: only pass the list-box count of the relevant tab - saves stuff.
                FEMcommon.ButtonsVisible(True, LstBxFriends.Items.Count, 0, 0)

                If reloadFriends Then
                    IOcommon.loadFriends()
                    blankFriendsDate()
                    LoadAutoCompleteStuff()
                    reloadFriends = False                    ' do not reload, if not necessary
                End If

                If LstBxFriends.Items.Count > 0 Then
                    btnDelete.Enabled = True
                    btnEdit.Enabled = True
                    showFriends(0)
                End If
            Case 6                                              '   Events tab
                FEMcommon.ButtonsVisible(True, 0, LstBxEvents.Items.Count, 0)

                If reloadEvents Then
                    IOcommon.loadEvents()
                    reloadEvents = False
                End If

                If LstBxEvents.Items.Count > 0 Then
                    btnDelete.Enabled = True
                    btnEdit.Enabled = True
                    showEvents(0)
                End If
            Case 7                                              '   Memo tab
                FEMcommon.ButtonsVisible(True, 0, 0, LstBxMemo.Items.Count)

                If reloadMemo Then
                    IOcommon.loadMemo()
                    reloadMemo = False
                End If

                If LstBxMemo.Items.Count > 0 Then
                    btnDelete.Enabled = True
                    btnEdit.Enabled = True
                    showMemo(0)
                End If
            Case 8                                              '   Convert tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)
            Case 9                                              '   Sayings tab
                FEMcommon.ButtonsVisible(False, 0, 0, 0)

                If usrSettings.usrSayingsDisplay Then
                    TbPgSayings.Enabled = True
                    If sayings.Count = 0 Then
                        btnDisplaySayings.Enabled = False
                        txtBxSayings.Enabled = False
                        lblSayingsNumber.Text = "There are no sayings."
                    Else
                        btnDisplaySayings.Enabled = True
                        txtBxSayings.Enabled = True
                        lblSayingsNumber.Text = String.Format("There are {0} sayings.", sayings.Count)
                        LoadSaying()
                    End If
                Else
                    TbPgSayings.Enabled = False
                    txtBxSayings.Clear()
                    lblSayingsNumber.Text = "Sayings are not enabled."
                End If
        End Select

        setTitleText()
    End Sub

    Private Sub TextKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextKlockToolStripMenuItem.Click
        '   if chosen from menus, switch on a text klock - appears in a separate window.
        '   Will hide main window when created.

        NtfyIcnKlock.Visible = True
        Visible = False

        frmSmallTextKlock.Show()
    End Sub

    Private Sub TimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeToolStripMenuItem.Click
        '   Only enable time server menu item if connected t the internet.

        InternetTimeToolStripMenuItem.Enabled = KlockThings.HaveInternetConnection()
    End Sub

    ' ****************************************************************************************************** context Strip Menu **************************
    ' menu loads when right clicking on tray icon

    Private Sub TlStrpMnItmShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TlStrpMnItmShow.Click, NtfyIcnKlock.MouseDoubleClick
        '   Hide system tray icon and show main form.
        '   Called from system tray right click menu and double clicking the tray icon.

        NtfyIcnKlock.Visible = False
        Visible = True
    End Sub

    Private Sub TlStrpMnItmTime_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TlStrpMnItmTime.CheckedChanged
        '   if checked, the system tray icon tooltip will be set to correct time [by main clock]

        usrSettings.usrTimeDisplayMinimised = If(TlStrpMnItmTime.Checked, True, False)
    End Sub

    ' ******************************************************************************************************************* Countdown clock ****************

    Private Sub tmrCountDown_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrCountDown.Tick
        '   If enabled, countdown is running - clock ticks every second.

        CountDownTime -= 1                                           '   decrement countdown every second.
        lblCountDownTime.Text = minsToString(CountDownTime)       '   update countdown label.

        If CountDownTime = 0 Then                                    '   countdown has finished.
            CountDownAction()                                        '   perform action.
            CountDownClear()                                         '   clear down countdown.
        End If
    End Sub

    ' ******************************************************************************************************************* Event clock ******************

    Private Sub tmrEvents_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrEvents.Tick
        '   if enabled, there is events that need checking.
        '   The timer fires every minute, the sub keeps score of the minutes.
        '   If the number of minutes exceeds the stores value, the events are checked.

        Static noOfMinutes As Integer = 0

        noOfMinutes += 1

        If noOfMinutes > usrSettings.usrEventsTimerInterval Then
            noOfMinutes = 0
            checkEvents()
        End If
    End Sub

    ' ************************************************************************************** clock routines **************************
    '
    ' Separate clocks are used for each function, to reduce load on main clock

    Private Sub TmrMain_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to the status bar.
        '   Checks for Caps Lock, Num Lock & Scroll Lock - set message in status bar.

        Dim currentSecond As Integer = Now.TimeOfDay.TotalSeconds                       '  so, all use the same time.
        Dim tmStr As String = ""

        If Visible Then                                                              '   Only update if form is visible, can't see if in system tray.
            updateStatusBar()
            updateTitleText()

            If TbCntrl.SelectedIndex = 0 Then

                displayOneTime.set24Hour = usrSettings.usrTimeOne24Hour
                tmStr = displayOneTime.getTime()

                LblTimeOneTime.Font = usrFonts.getFont(tmStr, displayOneTime.getTitle, grphcs)
                LblTimeOneTime.Text = tmStr                                          '   Update local time in desired time format.

                If usrSettings.usrTimeTwoFormats Then

                    displayTwoTime.set24Hour = usrSettings.usrTimeTwo24Hour
                    tmStr = displayTwoTime.getTime()

                    LblTimeTwoTime.Font = usrFonts.getFont(tmStr, displayTwoTime.getTitle, grphcs)
                    LblTimeTwoTime.Text = tmStr                                      '   display local time in desired time format.

                End If                                                               '   If Me.usrSettings.usrTimeTwoFormats Then
            ElseIf TbCntrl.SelectedIndex = 1 Then
                updateWorldKlock()                                                   '   Update World Klock.
            End If                                                                   '   If Me.TbCntrl.SelectedIndex = 0 [or 1] Then
        Else                                                                         '   else If Me.Visible Then
            If klocksNotVisable() Then
                NotificationDispaly(currentSecond)                                   '   display a notification, if desired and no extra klocks are running.
            Else                                                                     '   extra klocks is running
                setToolTip()                                                         '   are any extras running?  if so, set tool tip
            End If
        End If                                                                       '   If Me.Visible Then

        playHourlyChimes(currentSecond)                                              '   Play a hourly chime,  if desired.
        Notificationspeech(currentSecond)                                            '   Speak time, if desired.
    End Sub

    ' ******************************************************************************************************************* Memo clock ******************

    Private Sub TmrMemo_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrMemo.Tick
        '   if enabled, a secret memo test has been decrypted.
        '   The timer fires every second, the sub keeps score of the seconds.
        '   If the number of seconds exceeds the stores value, the memo text is changed to "Its a secret".

        Static noOfSeconds As Integer = 0

        noOfSeconds += 1
        TlStrpPrgrsBrMemo.Value = noOfSeconds

        If noOfSeconds = usrSettings.usrMemoDecyptTimeOut Then
            noOfSeconds = 0
            showMemo(LstBxMemo.SelectedIndex)
            TmrMemo.Enabled = False
            TlStrpPrgrsBrMemo.Value = 0
            TlStrpPrgrsBrMemo.Visible = False
        End If
    End Sub

    ' ******************************************************************************************************************* Reminder clock ******************

    Private Sub tmrReminder_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrReminder.Tick
        '   If enabled, a reminder has been set.

        If Now() > ReminderDateTime Then
            ReminderAction()
            clearReminder()                                              '   clear down reminder tab after action.
        Else
            Dim hms As TimeSpan = ReminderDateTime.Subtract(Now())
            Dim tmStr As String = ""

            If ChckBxReminderTimeCheck.Checked Then                      '   tack on the remaining time
                tmStr = String.Format("Reminder set for {0} @ {1} : {2:%d}d {2:%h}h {2:%m}m {2:%s}s", ReminderDateTime.ToLongDateString, ReminderDateTime.ToShortTimeString, hms)

                lblReminderText.Font = usrFonts.getFont(tmStr, "Reminder", grphcs)
                lblReminderText.Text = tmStr
            Else
                tmStr = String.Format("Reminder set for {0} : {1:%d}d {1:%h}h {1:%m}m {1:%s}s", ReminderDateTime.ToLongDateString, hms)
                lblReminderText.Font = usrFonts.getFont(tmStr, "Reminder", grphcs)
                lblReminderText.Text = tmStr
            End If
        End If
    End Sub

    ' ******************************************************************************************************************* Sayings clock ******************

    Private Sub tmrSayings_Tick(sender As Object, e As EventArgs) Handles tmrSayings.Tick
        '   If enabled, will display a random saying.  Enabled by checkbox in sayings option tab.
        '   The timer fires every minute, the sub keeps score of the minutes.
        '   If the number of minutes exceeds the stores value, the random saying is displayed.
        Static noOfMinutes As Integer = 0

        noOfMinutes += 1

        If noOfMinutes > (usrSettings.usrSayingsDisplayTime) Then
            noOfMinutes = 0
            displayAction.DisplayReminder(randomSayings(), "S", "Sayings")
        End If
    End Sub

    ' *************************************************************************************************************** Timer clock ***********************

    Private Sub tmrTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrTimer.Tick
        '   If enabled, timer is running - update timer label

        lblTimerTime.Text = If(usrSettings.usrTimerHigh, displayTimer.getHighElapsedTime(), displayTimer.getLowElapsedTime())
    End Sub

    Private Sub TxtBxConvertValue_TextChanged(sender As Object, e As EventArgs) Handles TxtBxConvertValue.TextChanged
        '   A value has been entered, enable convert button.


        btnConvertStart.Enabled = True
    End Sub


    Private Sub TxtBxEventsName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtBxEventsName.TextChanged
        '   Only allow adding if name contains some text.

        If E_ADDING Then btnAdd.Enabled = If(TxtBxEventsName.Text <> "", True, False)
    End Sub

    Private Sub txtbxFriendsAddressPostCode_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtbxFriendsAddressPostCode.KeyPress
        '   Post code may only contain upper case letters and numbers.

        If Char.IsLetterOrDigit(e.KeyChar) Then
            txtbxFriendsAddressPostCode.SelectedText = If(Char.IsLetter(e.KeyChar), UCase(e.KeyChar), e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        '                                               if running on battery, change status info colour to red as a warning.
        If myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = Color.Black
            StsLblDate.ForeColor = Color.Black
            StsLblKeys.ForeColor = Color.Black
        Else
            stsLblTime.ForeColor = Color.Red
            StsLblDate.ForeColor = Color.Red
            StsLblKeys.ForeColor = Color.Red
        End If

        stsLblTime.Text = statusTime()
        StsLblDate.Text = Format(Now, "Long Date")
        StsLblKeys.Text = statusInfo()

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If usrSettings.usrTimeIdleTime Or usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = "Idle Time :: " & KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If

    End Sub

    Private Sub updateTitleText()
        '   Updates application title.

        setTitleText()
    End Sub

    Private Sub updateWorldKlock()
        '   Update the world klock, with local time and time of chosen time zone.
        '   Slightly different update, depending on if long name of id;s are being used for time zones.

        Dim wt As String
        Dim ct As String

        If RdBtnWorldClockTimeZoneLongName.Checked Then
            Dim TzInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(CmbBxWorldKlockTimeZones.SelectedItem.id)
            wt = String.Format("  World Time : {0} :: {1}", TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongDateString, TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongTimeString)
        Else
            wt = String.Format("  World Time : {0} :: {1}", TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, CmbBxWorldKlockTimeZones.SelectedItem).ToLongDateString, TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, CmbBxWorldKlockTimeZones.SelectedItem).ToLongTimeString)
        End If

        ct = String.Format("Current Time : {0} :: {1}", Now.ToLongDateString, Now.ToLongTimeString)

        LblWorldKlockLocal.Text = ct
        LblWorldKlockWorld.Text = wt
    End Sub

    ' ************************************************************************************************************ Countdown ******************************
    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   When the up down counter has been changed, enable the start button and update the countdown label.

        btnCountDownStart.Enabled = If(upDwnCntDownValue.Value = 0, False, True)

        CountDownTime = upDwnCntDownValue.Value * 60
        lblCountDownTime.Text = minsToString(CountDownTime)
    End Sub


    ' ********************************************************************************************************************************* END **************
End Class
