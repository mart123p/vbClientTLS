Imports Newtonsoft.Json.Linq
Public Class ClientBuilder
    Dim _auth As String
    Dim _request As String
    Dim _managerJO As JObject

    Public Function createAccount(ByVal usr As User) As String
        Dim jo As New JObject
        jo.Add("firstName", usr.getFirstName())
        jo.Add("lastname", usr.getLastName())
        jo.Add("email", usr.getEmail())
        jo.Add("studyField", usr.getStudyField())
        jo.Add("birthday", usr.getBirthday())
        jo.Add("password", usr.getPassword())
        Return "POST /User" & vbCrLf & jo.ToString()
    End Function
    Public Function studyField() As String

        Return "GET /studyField" & vbCrLf
    End Function
    Public Function connection(ByVal id As String, ByVal pwd As String) As String
        Dim jo As New JObject
        jo.Add("id", id)
        jo.Add("password", pwd)
        Return "CONNECT /" & vbCrLf & jo.ToString()
    End Function
    Public Function disconnect(ByVal usr As User) As String

        Return "DISCONNECT /" & vbCrLf & "AUTH: " & usr.getAuth() & vbCrLf
    End Function
    Public Function studentDirectory(ByVal usr As User, ByVal studyField As String) As String
        Dim jo As New JObject
        jo.Add("studyField", studyField)
        Return "GET /students" & vbCrLf & "AUTH: " & usr.getAuth() & vbCrLf & jo.ToString()
    End Function
    Public Function profileManager(ByVal usr As User) As String

        Return "PUT /user" & vbCrLf & "Auth: " & usr.getAuth() & vbCrLf & _managerJO.ToString()
    End Function
    Public Sub setEmail(ByVal email As String)
        _managerJO.Add("email", email)
    End Sub
    Public Sub setPassword(ByVal password As String)
        _managerJO.Add("password", password)
    End Sub
    Public Sub setStudyField(ByVal studyField As String)
        _managerJO.Add("studyField", studyField)
    End Sub
    Public Sub reset()
        _managerJO.RemoveAll()
    End Sub
End Class
