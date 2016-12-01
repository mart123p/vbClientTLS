Imports Newtonsoft.Json.Linq
Public Class ClientBuilder
    Dim _auth As String
    Dim _request As String

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
    Public Function disconnect() As String

        Return ""
    End Function
    Public Function studentDirectory() As String

        Return ""
    End Function
    Public Function profileManager() As String

        Return ""
    End Function
End Class
