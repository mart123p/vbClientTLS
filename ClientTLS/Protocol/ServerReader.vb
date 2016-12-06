Imports Newtonsoft.Json.Linq
Public Class ServerReader
    Public Sub read(ByVal request As String)
        Dim requestArray As String() = request.Split(vbCrLf)
        Dim errorCode As Integer = requestArray(0).Substring(0, 3)
        Dim firstLine As String = requestArray(0).Substring(4)

        Select Case firstLine
            Case "POST /user"
                If errorCode = ProtocolStatus.OK Then
                    Dim o As JObject = JObject.Parse(requestArray(1))
                    'Here pass o.getValue("id")
                End If
            Case "CONNECT /"
                'Return ServerResponses.Connection
            Case "GET /StudyField"
                'Return ServerResponses.StudyField
            Case "GET /user"
                'Return ServerResponses.GetUserDetails
            Case "DISCONNECT /"
                'Return ServerResponses.Disconnect
            Case "GET /students"
                'Return ServerResponses.StudentDirectory
            Case "PUT /USER"
                'Return ServerResponses.ModifyProfile
            Case Else
                'Return ServerResponses.erreur
        End Select
    End Sub


End Class
