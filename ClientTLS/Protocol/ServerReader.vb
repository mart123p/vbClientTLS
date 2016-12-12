Imports Newtonsoft.Json.Linq
Public Class ServerReader
    Dim studyfields_ As New List(Of String)
    Dim auth As String = ""
    Dim user As User
    Dim id As String = ""
    Dim etudiants As New List(Of Etudiants)

    Public Function getStudyFields() As List(Of String)
        Return studyfields_
    End Function

    Public Function getAuth() As String
        Return auth
    End Function

    Public Function getUser() As User
        Return user
    End Function

    Public Function getId() As String
        Return id
    End Function

    Public Function getEtudiants() As Etudiants()
        Return etudiants.ToArray
    End Function
    Public Function read(ByVal request As String) As ServerResponses
        Dim requestArray As String() = request.Split(vbCrLf)
        Dim statusCode As Integer = requestArray(0).Substring(0, 3)
        Dim firstLine As String = requestArray(0).Substring(4)
        Select Case firstLine
            Case "POST /user"
                If statusCode = ProtocolStatus.OK Then
                    Dim o As JObject = JObject.Parse(requestArray(1))
                    id = o.GetValue("id").ToString
                    Return ServerResponses.SignUp
                Else
                    Return ServerResponses.erreur
                End If
            Case "CONNECT /"
                If statusCode = ProtocolStatus.OK Then
                    auth = requestArray(1).Substring(7)
                    Return ServerResponses.Connection
                Else
                    Return ServerResponses.erreur
                End If
            Case "GET /studyField"
                If statusCode = ProtocolStatus.OK Then
                    Dim o As JArray = JArray.Parse(requestArray(1))

                    For i = 0 To o.Count - 1
                        studyfields_.Add(o(i))
                    Next
                    Return ServerResponses.StudyField
                Else
                    Return ServerResponses.erreur
                End If
            Case "GET /user"
                Dim o As JObject = JObject.Parse(requestArray(1))
                user = New User("", "", o.GetValue("email"), o.GetValue("studyField"), "", "")
                Return ServerResponses.GetUserDetails
            Case "DISCONNECT /"
                Return ServerResponses.Disconnect
            Case "GET /students"
                Dim a As JArray = JArray.Parse(requestArray(1))
                For i = 0 To a.Count - 1
                    Dim o As JObject = a(i)
                    etudiants.Add(New Etudiants(o.GetValue("firstName"), o.GetValue("lastName"), o.GetValue("email"), o.GetValue("studyField")))
                Next

                Return ServerResponses.StudentDirectory
            Case "PUT /user"
                If statusCode = ProtocolStatus.OK Then
                    Return ServerResponses.ModifyProfile
                Else
                    Return ServerResponses.erreur
                End If
            Case Else
                Return ServerResponses.erreur
        End Select
    End Function


End Class
