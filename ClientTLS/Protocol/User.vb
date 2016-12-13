﻿Public Class User
    Inherits Etudiants
    Dim _birthday As String
    Dim _password As String
    Dim _auth As String
    Dim mat As String
    Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal email As String, ByVal studyField As String, ByVal birthday As String, ByVal password As String)
        MyBase.New(firstName, lastName, email, studyField)
        _birthday = birthday
        _password = password
    End Sub
    Public Sub setBirthday(ByVal birthday As String)
        _birthday = birthday
    End Sub
    Public Sub setPassword(ByVal password As String)
        _password = password
    End Sub
    Public Sub setAuth(ByVal auth As String)
        _auth = auth
    End Sub
    Public Sub setMat(ByVal mat As String)
        Me.mat = mat
    End Sub
    Public Function getAuth() As String
        Return _auth
    End Function
    Public Function getMat() As String
        Return mat
    End Function
    Public Function getBirthday() As String

        Return _birthday
    End Function
    Public Function getPassword() As String
        Return _password
    End Function
End Class
