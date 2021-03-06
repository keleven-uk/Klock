﻿Imports System.Security.Cryptography

Public Class Simple3Des
    '   http://msdn.microsoft.com/en-us/library/ms172831.aspx

    '   private field to store the 3DES cryptographic service provider.
    Private TripleDes As New TripleDESCryptoServiceProvider

    '   a constructor to initialize the 3DES cryptographic service provider.
    '   The key parameter controls the EncryptData and DecryptData methods.
    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    '    a public method that decrypts a string.
    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array. 
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream. 
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plain text stream to a string. 
        Return Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    '   a public method that encrypts a string.
    Public Function EncryptData(
    ByVal plaintext As String) As String

        ' Convert the plain text string to a byte array. 
        Dim plaintextBytes() As Byte =
            Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream. 
        Dim ms As New IO.MemoryStream
        ' Create the encoder to write to the stream. 
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string. 
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    '   private method that creates a byte array of a specified length from the hash of the specified key.
    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key. 
        Dim keyBytes() As Byte =
            Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash. 
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

End Class
