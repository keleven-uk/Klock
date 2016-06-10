Imports System.Runtime.InteropServices

Public Class ManagedPower
    ' GetSystemPowerStatus() is the only unmanaged API called.
    Declare Auto Function GetSystemPowerStatus Lib "kernel32.dll" Alias "GetSystemPowerStatus" (ByRef sps As SystemPowerStatus) As Boolean

    Dim sysPowerStatus As SystemPowerStatus

    Public Sub New()

        MyBase.New()
    End Sub

    Public Enum _ACLineStatus As Byte
        Battery = 0
        AC = 1
        Unknown = 255
    End Enum

    <Flags()>
    Public Enum _BatteryFlag As Byte
        High = 1
        Low = 2
        Critical = 4
        Charging = 8
        NoSystemBattery = 128
        Unknown = 255
    End Enum

    Public Function chargingStatus() As String

        Dim text As String = String.Empty

        If Not sysPowerStatus.BatteryFlag = ManagedPower._BatteryFlag.NoSystemBattery Then

            ' Print the percentage of the battery life remaining.
            Dim currentBatteryPercentage = sysPowerStatus.BatteryLifePercent
            text = Environment.NewLine + "Battery life remaining is " + sysPowerStatus.BatteryLifePercent.ToString() + "%"

        End If

        Return text
    End Function

    Public Function powerSource() As String

        Dim text As String = String.Empty

        If ManagedPower.GetSystemPowerStatus(sysPowerStatus) Then
            text = "Power source: " + sysPowerStatus.ACLineStatus.ToString() + Environment.NewLine
        End If

        Return text
    End Function

    Public Function powerStatus() As String

        Dim text As String = String.Empty

        If sysPowerStatus.BatteryFlag = ManagedPower._BatteryFlag.NoSystemBattery Then
            text = "No System Battery"
        Else

            ' Print out power level
            ' If the power is not High, Low, or Critical, report it as "Medium".

            text = "Power Status: " & If(sysPowerStatus.BatteryFlag = 0, "Medium", sysPowerStatus.BatteryFlag.ToString())

        End If

        Return text
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SystemPowerStatus
        Public ACLineStatus As _ACLineStatus
        Public BatteryFlag As _BatteryFlag
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As UInt32
        Public BatteryFullLifeTime As UInt32
    End Structure
End Class
