Imports Newtonsoft.Json.Linq
Public Class ClientBuilder
    Dim _auth As String
    Dim _request As String

    Public Function createAccount(ByVal etudiant As Etudiants) As String
        Dim jo As New JObject
        jo.Add("firstName", etudiant.firstName)
        Return ""
    End Function
    Public Function studyField() As String

        Return ""
    End Function
    Public Function connection() As String

        Return ""
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
