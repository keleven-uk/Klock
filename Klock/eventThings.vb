Public Class eventThings
    '   A collection of things to manage the event class.

    Public weddingAnniversaryGifts As New Dictionary(Of Integer, String)

    Public Sub New()

        MyBase.New()
        Me.PopulateGifts()
    End Sub

    Public Function eventTitle(ByVal e As Events) As String
        '   Set the event title according to which reminder is being called

        Dim s As String = ""
        If e.EventFirstReminder Then
            s = "First Reminder"
        ElseIf e.EventSecondreminder Then
            s = "Second Reminder"
        ElseIf e.EventThirdReminder Then
            s = "Third reminder"
        End If

        Return s
    End Function

    Public Function eventmessage(ByVal e As Events) As String
        '   Set an appropriate message according to the event type.

        Dim s As String = "d"

        Select Case e.EventType
            Case 0                          '   Anniversaries Chosen
                Dim age As Integer = e.NoOfYears()

                If age = 0 Then
                    s = String.Format("{0} have a wedding anniversary in {1} days", e.EventName, e.DaysToGo())
                Else
                    s = String.Format("{0} have a {1} wedding anniversary in {2} days", e.EventName, Me.weddingAnniversary(e.NoOfYears()), e.DaysToGo())
                End If

            Case 1                          '   Appointment Chosen
                s = String.Format("{0} appointment in {1} days", e.EventName, e.DaysToGo())
            Case 2                          '   Birthdays Chosen
                Dim age As Integer = e.NoOfYears()

                If age = 0 Then
                    s = String.Format("{0} has a birthday in {1} days", e.EventName, e.DaysToGo())
                Else
                    s = String.Format("{0} is {1} in {2} days", e.EventName, age, e.DaysToGo())
                End If

            Case 3                          '   Holidays Chosen
                s = String.Format("{0} has a Holiday in {1} days", e.EventName, e.DaysToGo())
            Case 4                          '   Meeting Chosen
                s = String.Format("{0} has a Meeting in {1} days", e.EventName, e.DaysToGo())
            Case 5                          '   Motor Chosen
                s = String.Format("{0} is due in {1} days", e.EventName, e.DaysToGo())
            Case 6                          '   OneOff Event Chosen
                s = e.EventName + e.EventType.ToString
            Case 7                          '   Other Chosen
                s = e.EventName + e.EventType.ToString
            Case Else
                s = e.EventName + e.EventType.ToString
        End Select

        Return s
    End Function

    Private Function weddingAnniversary(ByVal n As Integer) As String
        '   Selects the appropriate wedding gift, if known - otherwise returns the year number in words.

        Return If(Me.weddingAnniversaryGifts.ContainsKey(n), Me.weddingAnniversaryGifts(n), Me.toOrdinal(n))
    End Function


    Private Function toOrdinal(ByVal n As Integer) As String
        '   returns the value in words.

        Dim units() As String = {"Zeroth", "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth", _
                                "Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth", "Sixteenth", "Seventeenth", "Eighteenth", "Nineteenth"}

        Dim tens() As String = {"", "", "twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "ninety"}

        Dim s As String = ""
        Dim unit As Integer
        Dim ten As Integer

        If n < 20 Then
            s = units(n)
        Else
            ten = n / 10
            unit = (n = unit) / 10

            s = If(unit = 0, tens(ten) + "th", tens(ten) + units(unit))
        End If

        Return s
    End Function

    Private Sub PopulateGifts()
        '   A list of traditional and modern anniversary gifts.

        Me.weddingAnniversaryGifts.Add(1, "Cotton")
        Me.weddingAnniversaryGifts.Add(2, "Paper")
        Me.weddingAnniversaryGifts.Add(3, "Leather")
        Me.weddingAnniversaryGifts.Add(4, "Fruit and Flowers")
        Me.weddingAnniversaryGifts.Add(5, "Wood")
        Me.weddingAnniversaryGifts.Add(6, "Sugar")
        Me.weddingAnniversaryGifts.Add(7, "Woollen")
        Me.weddingAnniversaryGifts.Add(9, "Salt")
        Me.weddingAnniversaryGifts.Add(10, "Tin")
        Me.weddingAnniversaryGifts.Add(11, "Steel")
        Me.weddingAnniversaryGifts.Add(12, "Silk")
        Me.weddingAnniversaryGifts.Add(13, "Lace")
        Me.weddingAnniversaryGifts.Add(14, "ivory")
        Me.weddingAnniversaryGifts.Add(15, "Crystal")
        Me.weddingAnniversaryGifts.Add(16, "Silver Hollowware")
        Me.weddingAnniversaryGifts.Add(17, "Furniture")
        Me.weddingAnniversaryGifts.Add(18, "Porcelain")
        Me.weddingAnniversaryGifts.Add(19, "Bronze")
        Me.weddingAnniversaryGifts.Add(20, "China")
        Me.weddingAnniversaryGifts.Add(21, "Brass")
        Me.weddingAnniversaryGifts.Add(22, "Copper")
        Me.weddingAnniversaryGifts.Add(23, "Silver Plate")
        Me.weddingAnniversaryGifts.Add(24, "Musical Instruments")
        Me.weddingAnniversaryGifts.Add(25, "Silver")
        Me.weddingAnniversaryGifts.Add(26, "Original Pictures")
        Me.weddingAnniversaryGifts.Add(27, "Sculpture")
        Me.weddingAnniversaryGifts.Add(28, "Orchids")
        Me.weddingAnniversaryGifts.Add(29, "New Furniture")
        Me.weddingAnniversaryGifts.Add(30, "Pearl")
        Me.weddingAnniversaryGifts.Add(31, "Timepieces")
        Me.weddingAnniversaryGifts.Add(32, "Conveyances")
        Me.weddingAnniversaryGifts.Add(33, "Amethyst")
        Me.weddingAnniversaryGifts.Add(34, "Opal")
        Me.weddingAnniversaryGifts.Add(35, "Coral")
        Me.weddingAnniversaryGifts.Add(36, "Bone China")
        Me.weddingAnniversaryGifts.Add(37, "Alabaster")
        Me.weddingAnniversaryGifts.Add(38, "Beryl")
        Me.weddingAnniversaryGifts.Add(39, "lace")
        Me.weddingAnniversaryGifts.Add(40, "Ruby")
        Me.weddingAnniversaryGifts.Add(41, "land")
        Me.weddingAnniversaryGifts.Add(42, "Improved Real Estate")
        Me.weddingAnniversaryGifts.Add(43, "Travel")
        Me.weddingAnniversaryGifts.Add(44, "Groceries")
        Me.weddingAnniversaryGifts.Add(45, "Sapphire")
        Me.weddingAnniversaryGifts.Add(46, "Original Poetry Tribute")
        Me.weddingAnniversaryGifts.Add(47, "Books")
        Me.weddingAnniversaryGifts.Add(48, "Optical Goods")
        Me.weddingAnniversaryGifts.Add(49, "Luxuries")
        Me.weddingAnniversaryGifts.Add(50, "Gold")
        Me.weddingAnniversaryGifts.Add(55, "Emerald")
        Me.weddingAnniversaryGifts.Add(60, "Diamond")
        Me.weddingAnniversaryGifts.Add(65, "Blue Sapphire")
        Me.weddingAnniversaryGifts.Add(70, "Platinum")
        Me.weddingAnniversaryGifts.Add(75, "Gold")
        Me.weddingAnniversaryGifts.Add(80, "Oak")
        Me.weddingAnniversaryGifts.Add(85, "Wine")
        Me.weddingAnniversaryGifts.Add(90, "Stone")
    End Sub
End Class
