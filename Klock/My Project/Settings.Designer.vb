﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.276
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Control")>  _
        Public Property usrFormColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("usrFormColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("usrFormColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Tahoma, 9.75pt")>  _
        Public Property usrFormFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("usrFormFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("usrFormFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Black")>  _
        Public Property usrFormFontColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("usrFormFontColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("usrFormFontColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property usrFormTop() As Integer
            Get
                Return CType(Me("usrFormTop"),Integer)
            End Get
            Set
                Me("usrFormTop") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property usrFormLeft() As Integer
            Get
                Return CType(Me("usrFormLeft"),Integer)
            End Get
            Set
                Me("usrFormLeft") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrSavePos() As Boolean
            Get
                Return CType(Me("usrSavePos"),Boolean)
            End Get
            Set
                Me("usrSavePos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimerHigh() As Boolean
            Get
                Return CType(Me("usrTimerHigh"),Boolean)
            End Get
            Set
                Me("usrTimerHigh") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimerClearSplit() As Boolean
            Get
                Return CType(Me("usrTimerClearSplit"),Boolean)
            End Get
            Set
                Me("usrTimerClearSplit") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeSwatchCentibeats() As Boolean
            Get
                Return CType(Me("usrTimeSwatchCentibeats"),Boolean)
            End Get
            Set
                Me("usrTimeSwatchCentibeats") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeNETSeconds() As Boolean
            Get
                Return CType(Me("usrTimeNETSeconds"),Boolean)
            End Get
            Set
                Me("usrTimeNETSeconds") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeDisplayMinimised() As Boolean
            Get
                Return CType(Me("usrTimeDisplayMinimised"),Boolean)
            End Get
            Set
                Me("usrTimeDisplayMinimised") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property usrTimeHourPips() As Boolean
            Get
                Return CType(Me("usrTimeHourPips"),Boolean)
            End Get
            Set
                Me("usrTimeHourPips") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Control")>  _
        Public Property usrNotificationBackColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("usrNotificationBackColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("usrNotificationBackColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Tahoma, 9.75pt")>  _
        Public Property usrNotificationFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("usrNotificationFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("usrNotificationFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Black")>  _
        Public Property usrNotificationFontColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("usrNotificationFontColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("usrNotificationFontColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5000")>  _
        Public Property usrNotificationTimeOut() As Integer
            Get
                Return CType(Me("usrNotificationTimeOut"),Integer)
            End Get
            Set
                Me("usrNotificationTimeOut") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("80")>  _
        Public Property usrNotificationOpacity() As Integer
            Get
                Return CType(Me("usrNotificationOpacity"),Integer)
            End Get
            Set
                Me("usrNotificationOpacity") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeHourlyChimes() As Boolean
            Get
                Return CType(Me("usrTimeHourlyChimes"),Boolean)
            End Get
            Set
                Me("usrTimeHourlyChimes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeQuarterChimes() As Boolean
            Get
                Return CType(Me("usrTimeQuarterChimes"),Boolean)
            End Get
            Set
                Me("usrTimeQuarterChimes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrReminderTimeChecked() As Boolean
            Get
                Return CType(Me("usrReminderTimeChecked"),Boolean)
            End Get
            Set
                Me("usrReminderTimeChecked") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeHalfChimes() As Boolean
            Get
                Return CType(Me("usrTimeHalfChimes"),Boolean)
            End Get
            Set
                Me("usrTimeHalfChimes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeThreeQuarterChimes() As Boolean
            Get
                Return CType(Me("usrTimeThreeQuarterChimes"),Boolean)
            End Get
            Set
                Me("usrTimeThreeQuarterChimes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property usrSoundVolume() As Integer
            Get
                Return CType(Me("usrSoundVolume"),Integer)
            End Get
            Set
                Me("usrSoundVolume") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public Property usrTimeDisplayMinutes() As Integer
            Get
                Return CType(Me("usrTimeDisplayMinutes"),Integer)
            End Get
            Set
                Me("usrTimeDisplayMinutes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrStartMinimised() As Boolean
            Get
                Return CType(Me("usrStartMinimised"),Boolean)
            End Get
            Set
                Me("usrStartMinimised") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrRunOnStartup() As Boolean
            Get
                Return CType(Me("usrRunOnStartup"),Boolean)
            End Get
            Set
                Me("usrRunOnStartup") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrReminderAdd() As Boolean
            Get
                Return CType(Me("usrReminderAdd"),Boolean)
            End Get
            Set
                Me("usrReminderAdd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimerAdd() As Boolean
            Get
                Return CType(Me("usrTimerAdd"),Boolean)
            End Get
            Set
                Me("usrTimerAdd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrCountdownAdd() As Boolean
            Get
                Return CType(Me("usrCountdownAdd"),Boolean)
            End Get
            Set
                Me("usrCountdownAdd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property usrFriendsDirectory() As String
            Get
                Return CType(Me("usrFriendsDirectory"),String)
            End Get
            Set
                Me("usrFriendsDirectory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property usrFriendsFile() As String
            Get
                Return CType(Me("usrFriendsFile"),String)
            End Get
            Set
                Me("usrFriendsFile") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeHexIntuitor() As Boolean
            Get
                Return CType(Me("usrTimeHexIntuitor"),Boolean)
            End Get
            Set
                Me("usrTimeHexIntuitor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property usrTimeTwoFormats() As Boolean
            Get
                Return CType(Me("usrTimeTwoFormats"),Boolean)
            End Get
            Set
                Me("usrTimeTwoFormats") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Klock.My.MySettings
            Get
                Return Global.Klock.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
