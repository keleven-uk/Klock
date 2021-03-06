﻿Imports System.Globalization

'   A Person class.
'   Holds the data for an event and the functions to expose them.

'   the <Serializable()> bit, allows it to be stored easily in a binary file.
'   the tostring function allows it to be stored in a list-box.

'   Names & Addresses have to be title case i.e. first letter has to be a capital.
'   Emails have to contain the @ character.

<Serializable()> Public Class Person
    Private _address1 As String
    Private _address2 As String
    Private _city As String
    Private _county As String
    Private _dob As String
    Private _email1 As String
    Private _email2 As String
    Private _email3 As String

    Private _fName As String
    Private _houseNo As String
    Private _lName As String
    Private _mName As String
    Private _notes As String
    Private _postCode As String
    Private _telNo1 As String
    Private _telNo2 As String
    Private _telNo3 As String
    Private _webpage As String

    ' Creates a TextInfo based on the "en-GB" culture.
    Private myTI As TextInfo = New CultureInfo("en-GB", False).TextInfo


    Public Sub New()

        MyBase.New()
    End Sub

    Public Property Address1() As String
        Get
            Return _address1
        End Get
        Set(ByVal value As String)
            _address1 = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return _address2
        End Get
        Set(ByVal value As String)
            _address2 = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property County() As String
        Get
            Return _county
        End Get
        Set(ByVal value As String)
            _county = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property DOB() As String
        Get
            Return _dob
        End Get
        Set(ByVal value As String)
            _dob = value
        End Set
    End Property

    Public Property Email1() As String
        Get
            Return _email1
        End Get
        Set(ByVal value As String)
            If value.Contains("@") Then
                _email1 = value
            End If
        End Set
    End Property

    Public Property Email2() As String
        Get
            Return _email2
        End Get
        Set(ByVal value As String)
            If value.Contains("@") Then
                _email2 = value
            End If
        End Set
    End Property

    Public Property Email3() As String
        Get
            Return _email3
        End Get
        Set(ByVal value As String)
            If value.Contains("@") Then
                _email3 = value
            End If
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _fName
        End Get
        Set(ByVal value As String)
            _fName = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property HouseNo() As String
        Get
            Return _houseNo
        End Get
        Set(ByVal value As String)
            _houseNo = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _lName
        End Get
        Set(ByVal value As String)
            _lName = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property MiddleName() As String
        Get
            Return _mName
        End Get
        Set(ByVal value As String)
            _mName = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property

    Public Property PostCode() As String
        Get
            Return _postCode
        End Get
        Set(ByVal value As String)
            _postCode = Trim(myTI.ToUpper(value))
        End Set
    End Property

    Public Property TelNo1() As String
        Get
            Return _telNo1
        End Get
        Set(ByVal value As String)
            _telNo1 = value
        End Set
    End Property

    Public Property TelNo2() As String
        Get
            Return _telNo2
        End Get
        Set(ByVal value As String)
            _telNo2 = value
        End Set
    End Property

    Public Property TelNo3() As String
        Get
            Return _telNo3
        End Get
        Set(ByVal value As String)
            _telNo3 = value
        End Set
    End Property

    Public Property WebPage() As String
        Get
            Return _webpage
        End Get
        Set(ByVal value As String)
            _webpage = Trim(value)
        End Set
    End Property

    Public Overrides Function toString() As String

        Dim first As String = LastName().PadRight(14, " ")
        Dim second As String = FirstName().PadRight(10, " ")

        Return String.Format("{0}{1}", first, second)
    End Function
End Class

