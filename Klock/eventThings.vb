Public Class eventThings
    '   A collection of things to manage the event class.

    Public weddingAnniversaryGifts As New Dictionary(Of Integer, String)

    Public Sub New()

        MyBase.New()
        PopulateGifts()
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
                    s = String.Format("{0} have a {1} wedding anniversary in {2} days", e.EventName, weddingAnniversary(e.NoOfYears()), e.DaysToGo())
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

        Return If(weddingAnniversaryGifts.ContainsKey(n), weddingAnniversaryGifts(n), toOrdinal(n))
    End Function


    Private Function toOrdinal(ByVal n As Integer) As String
        '   returns the value in words.

        Dim units() As String = {"Zeroth", "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth",
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

        weddingAnniversaryGifts.Add(1, "Cotton")
        weddingAnniversaryGifts.Add(2, "Paper")
        weddingAnniversaryGifts.Add(3, "Leather")
        weddingAnniversaryGifts.Add(4, "Fruit and Flowers")
        weddingAnniversaryGifts.Add(5, "Wood")
        weddingAnniversaryGifts.Add(6, "Sugar")
        weddingAnniversaryGifts.Add(7, "Woollen")
        weddingAnniversaryGifts.Add(9, "Salt")
        weddingAnniversaryGifts.Add(10, "Tin")
        weddingAnniversaryGifts.Add(11, "Steel")
        weddingAnniversaryGifts.Add(12, "Silk")
        weddingAnniversaryGifts.Add(13, "Lace")
        weddingAnniversaryGifts.Add(14, "ivory")
        weddingAnniversaryGifts.Add(15, "Crystal")
        weddingAnniversaryGifts.Add(16, "Silver Hollowware")
        weddingAnniversaryGifts.Add(17, "Furniture")
        weddingAnniversaryGifts.Add(18, "Porcelain")
        weddingAnniversaryGifts.Add(19, "Bronze")
        weddingAnniversaryGifts.Add(20, "China")
        weddingAnniversaryGifts.Add(21, "Brass")
        weddingAnniversaryGifts.Add(22, "Copper")
        weddingAnniversaryGifts.Add(23, "Silver Plate")
        weddingAnniversaryGifts.Add(24, "Musical Instruments")
        weddingAnniversaryGifts.Add(25, "Silver")
        weddingAnniversaryGifts.Add(26, "Original Pictures")
        weddingAnniversaryGifts.Add(27, "Sculpture")
        weddingAnniversaryGifts.Add(28, "Orchids")
        weddingAnniversaryGifts.Add(29, "New Furniture")
        weddingAnniversaryGifts.Add(30, "Pearl")
        weddingAnniversaryGifts.Add(31, "Timepieces")
        weddingAnniversaryGifts.Add(32, "Conveyances")
        weddingAnniversaryGifts.Add(33, "Amethyst")
        weddingAnniversaryGifts.Add(34, "Opal")
        weddingAnniversaryGifts.Add(35, "Coral")
        weddingAnniversaryGifts.Add(36, "Bone China")
        weddingAnniversaryGifts.Add(37, "Alabaster")
        weddingAnniversaryGifts.Add(38, "Beryl")
        weddingAnniversaryGifts.Add(39, "lace")
        weddingAnniversaryGifts.Add(40, "Ruby")
        weddingAnniversaryGifts.Add(41, "land")
        weddingAnniversaryGifts.Add(42, "Improved Real Estate")
        weddingAnniversaryGifts.Add(43, "Travel")
        weddingAnniversaryGifts.Add(44, "Groceries")
        weddingAnniversaryGifts.Add(45, "Sapphire")
        weddingAnniversaryGifts.Add(46, "Original Poetry Tribute")
        weddingAnniversaryGifts.Add(47, "Books")
        weddingAnniversaryGifts.Add(48, "Optical Goods")
        weddingAnniversaryGifts.Add(49, "Luxuries")
        weddingAnniversaryGifts.Add(50, "Gold")
        weddingAnniversaryGifts.Add(55, "Emerald")
        weddingAnniversaryGifts.Add(60, "Diamond")
        weddingAnniversaryGifts.Add(65, "Blue Sapphire")
        weddingAnniversaryGifts.Add(70, "Platinum")
        weddingAnniversaryGifts.Add(75, "Gold")
        weddingAnniversaryGifts.Add(80, "Oak")
        weddingAnniversaryGifts.Add(85, "Wine")
        weddingAnniversaryGifts.Add(90, "Stone")
    End Sub
End Class
