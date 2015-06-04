Imports System.Runtime.InteropServices

Public Class ManagedPower
    ' GetSystemPowerStatus() is the only unmanaged API called.
    Declare Auto Function GetSystemPowerStatus Lib "kernel32.dll" Alias "GetSystemPowerStatus" (ByRef sps As SystemPowerStatus) As Boolean

    Dim sysPowerStatus As SystemPowerStatus

    Public Sub New()

        MyBase.New()
    End Sub

    Public Function powerSource() As String

        Dim text As String = ""

        If ManagedPower.GetSystemPowerStatus(sysPowerStatus) Then
            text += "Power source: " + sysPowerStatus.ACLineStatus.ToString() + Environment.NewLine
        End If

        powerSource = text
    End Function

    Public Function powerStatus() As String

        Dim text As String = ""

        If sysPowerStatus.BatteryFlag = ManagedPower._BatteryFlag.NoSystemBattery Then
            text = "No System Battery"
        Else

            ' Print out power level
            ' If the power is not High, Low, or Critical, report it as "Medium".
            Dim currentPowerLevel As String
            If sysPowerStatus.BatteryFlag = 0 Then
                currentPowerLevel = "Medium"
            Else
                currentPowerLevel = sysPowerStatus.BatteryFlag.ToString()
            End If
            text = "Power Status: " & currentPowerLevel

        End If

        powerStatus = text
    End Function

    Public Function chargingStatus() As String

        Dim text As String = ""

        If Not sysPowerStatus.BatteryFlag = ManagedPower._BatteryFlag.NoSystemBattery Then

            ' Print the percentage of the battery life remaining.
            Dim currentBatteryPercentage = sysPowerStatus.BatteryLifePercent
            text += Environment.NewLine + "Battery life remaining is " + sysPowerStatus.BatteryLifePercent.ToString() + "%"

        End If

        chargingStatus = text
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SystemPowerStatus
        Public ACLineStatus As _ACLineStatus
        Public BatteryFlag As _BatteryFlag
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As System.UInt32
        Public BatteryFullLifeTime As System.UInt32
    End Structure

    Public Enum _ACLineStatus As Byte
        Battery = 0
        AC = 1
        Unknown = 255
    End Enum

    <Flags()> _
    Public Enum _BatteryFlag As Byte
        High = 1
        Low = 2
        Critical = 4
        Charging = 8
        NoSystemBattery = 128
        Unknown = 255
    End Enum
End Class
