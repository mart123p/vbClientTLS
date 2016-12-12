Imports Newtonsoft.Json.Linq
Public Class ClientBuilder
    Dim _request As String
    Dim _managerJO As New JObject

    Public Function createAccount(ByVal usr As User) As String
        Dim jo As New JObject
        jo.Add("firstName", usr.getFirstName())
        jo.Add("lastName", usr.getLastName())
        jo.Add("email", usr.getEmail())
        jo.Add("studyField", usr.getStudyField())
        jo.Add("birthday", usr.getBirthday())
        jo.Add("password", usr.getPassword())
        Return "POST /user" & vbCrLf & jo.ToString().Replace(vbCrLf, "").Replace(vbTab, "")
    End Function
    Public Function studyField() As String

        Return "GET /studyField"
    End Function
    Public Function connection(ByVal id As String, ByVal pwd As String) As String
        Dim jo As New JObject
        jo.Add("id", id)
        jo.Add("password", pwd)
        Return "CONNECT /" & vbCrLf & jo.ToString().Replace(vbCrLf, "").Replace(vbTab, "")
    End Function
    Public Function disconnect(ByVal auth As String) As String
        Return "DISCONNECT /" & vbCrLf & "AUTH: " & auth
    End Function

    Public Function getInfos(ByVal auth As String) As String
        Return "GET /user" & vbCrLf & "AUTH: " & auth
    End Function
    Public Function studentDirectory(ByVal auth As String, ByVal studyField As String) As String
        Dim jo As New JObject
        jo.Add("studyField", studyField)
        Return "GET /students" & vbCrLf & "AUTH: " & auth & vbCrLf & jo.ToString().Replace(vbCrLf, "").Replace(vbTab, "")
    End Function
    Public Function profileManager(ByVal auth As String) As String
        Return "PUT /user" & vbCrLf & "AUTH: " & auth & vbCrLf & _managerJO.ToString().Replace(vbCrLf, "").Replace(vbTab, "")
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
