Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module conversionThings

    '   Based on article in http://www.dreamincode.net/forums/topic/121316-an-updatable-unit-conversion-calculator/

    '   A Helper module that contains functions linked to the convert tab.

    Dim UnitConvVal As Double                                                                       '   Global Variable for Unit Value.
    Dim unitsFile As String = Path.Combine(frmKlock.usrSettings.usrOptionsSavePath(), "units.txt")  '   file is in user area


    Public Sub unitsLoad(ByVal Switch As String)
        '   Loads the data file units.txt, which contains the data for the conversions
        '   The file is then parsed into its separate parts.

        '   Category, Weight
        '   Category, Distance
        '   Weight, LB To KG, 0.45359237
        '   Weight, KG To LB, 2.20462262
        '   Distance, Mile To KM, 1.609344
        '   Distance, KN To Mile, 0.621371192

        Try
            Dim tfp As New TextFieldParser(unitsFile)
            tfp.Delimiters = New String() {","}
            tfp.TextFieldType = FieldType.Delimited

            While tfp.EndOfData = False
                Dim fields = tfp.ReadFields()

                Select Case Switch
                    Case "LoadCategory"
                        If fields(0) = "Category" Then
                            frmKlock.CmbBxConvertCategory.Items.Add(fields(1))
                            frmKlock.CmbBxConvertCategory.SelectedIndex = 0             '   Auto Select first Category.
                        End If
                    Case "LoadUnits"
                        If fields(0) = frmKlock.CmbBxConvertCategory.SelectedItem Then
                            frmKlock.CmbBxConvertTo.Items.Add(fields(1))
                            frmKlock.CmbBxConvertTo.SelectedIndex = 0                   '   Auto Select first Unit.
                        End If
                    Case "SelectUnit"
                        If fields(1) = frmKlock.CmbBxConvertTo.SelectedItem Then
                            UnitConvVal = CDbl(fields(2))                                '   Load Unit's Conversion value, store in UnitConvVal as Double.
                        End If
                End Select
            End While
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Units File Error", "Sorry, can't find units.txt. " & ex.Message, "G")
        End Try
    End Sub

    Public Sub calculate()
        '   Called when the convert button is called.
        '   There should always be a value to convert, checks whether numeric.

        If Not IsNumeric(frmKlock.TxtBxConvertValue.Text) Then
            MessageBox.Show("Please Enter A Numeric Value to Convert", "Numeric Error", MessageBoxButtons.OK, MessageBoxIcon.Error) '   Display error message, if no value is entered.
        Else
            unitsLoad("SelectUnit")                                                                         '   Parse file to locate conversion rate.
            frmKlock.TxtBxConvertResult.Text = CStr(CDbl(frmKlock.TxtBxConvertValue.Text) * UnitConvVal)    '   If Value has been entered, compute conversion for unit.
        End If
    End Sub

    Public Sub clearTextBoxes()
        '   Clear both text boxes on the convert tab.

        frmKlock.TxtBxConvertResult.Text = ""
        frmKlock.TxtBxConvertValue.Text = ""
    End Sub

    Public Sub addUnits()
        '   called when the add units button is pressed.
        '   Loads the file units.txt into the default text editor.
        '   re-loads the combo boxes when finished.

        Dim ps As New ProcessStartInfo()
        With ps
            .FileName = Path.Combine(unitsFile)
            .UseShellExecute = True
        End With

        Try
            Dim p As New Process
            p.StartInfo = ps
            p.Start()

            frmKlock.CmbBxConvertCategory.Items.Clear()
            unitsLoad("LoadCategory")
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Units File Error", "Sorry, can't find units.txt. " & ex.Message, "G")
        End Try
    End Sub

    Public Sub checkUnitsFile()
        '   Data directory in usrOptionsSavepath(), should already be there..
        '   Checks for settings file in above directory, if not there create it.

        If Not My.Computer.FileSystem.FileExists(unitsFile) Then
            writeDefaultUnits()
        End If
    End Sub

    Private Sub writeDefaultUnits()
        '   If units file not present, write a default one.

        Using uFile As StreamWriter = New StreamWriter(unitsFile)
            uFile.WriteLine("Category,Weight")
            uFile.WriteLine("Category,Distance")
            uFile.WriteLine("Category,Area")
            uFile.WriteLine("Category,Liquid")
            uFile.WriteLine("Category,Volume")
            uFile.WriteLine("category,Power")
            uFile.WriteLine("Weight,LB to KG, 0.45359237")
            uFile.WriteLine("Weight,KG to LB, 2.20462262")
            uFile.WriteLine("Weight,Ton to KG, 6.350293")
            uFile.WriteLine("Weight,KG to Ton, 0.157473")
            uFile.WriteLine("Distance,Mile to KM, 1.609344")
            uFile.WriteLine("Distance,KM to Mile, 0.621371192")
            uFile.WriteLine("Distance,Inch to CM, 2.54")
            uFile.WriteLine("Distance,CM to Inch, 0.3937")
            uFile.WriteLine("Distance,Furlong to Metre, 201.168")
            uFile.WriteLine("Distance,Metre to Furlong, .0004970970")
            uFile.WriteLine("Distance,Fathom to Metre, 1.8288")
            uFile.WriteLine("Distance,Metre to Fathom, 0.546806")
            uFile.WriteLine("Area,Square Foot to Square Metre, 0.029280304")
            uFile.WriteLine("Area,Square Metre to Square Foot, 10.763910")
            uFile.WriteLine("Area,Square Yard to Square Metre, 0.836127")
            uFile.WriteLine("Area,Square Metre to Square Yard, 1.19599")
            uFile.WriteLine("Liquid,Gallon to Litre, 4.546")
            uFile.WriteLine("Liquid,Litre to Gallon, 0.22")
            uFile.WriteLine("Liquid,Pint to Litre, 0.56826125")
            uFile.WriteLine("Liquid,Litre to Pint, 1.7597538772348")
            uFile.WriteLine("Volume,Cubic Centimetres to Cubic Inches, 0.061")
            uFile.WriteLine("Volume,Cubic Inches to Cubic Centimetres, 16.39")
            uFile.WriteLine("Power,Horse power to Watts, 745.7")
            uFile.WriteLine("Power,Watts to Horse Power, 0.001341022")
        End Using
    End Sub
End Module
