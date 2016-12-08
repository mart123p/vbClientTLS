﻿Imports Newtonsoft.Json.Linq
Public Class ServerReader
    Dim studyfields_ As New List(Of String)
    Public Function getStudyFields() As List(Of String)
        Return studyfields_
    End Function
    Public Sub read(ByVal request As String)
        Dim requestArray As String() = request.Split(vbCrLf)
        Dim errorCode As Integer = requestArray(0).Substring(0, 3)
        Dim firstLine As String = requestArray(0).Substring(4)
        MsgBox(request)
        Select Case firstLine
            Case "POST /user"
                If errorCode = ProtocolStatus.OK Then
                    Dim o As JObject = JObject.Parse(requestArray(1))
                    MsgBox(o.GetValue("id"))
                Else
                    MessageBox.Show("Une erreur s'est produite...")
                End If
            Case "CONNECT /"
                If errorCode = ProtocolStatus.OK Then
                    MsgBox("connected" & requestArray(1).Substring(6))
                Else
                    MessageBox.Show("Une erreur s'est produite...")
                End If
                'Return ServerResponses.Connection
            Case "GET /studyField"
                If errorCode = ProtocolStatus.OK Then
                    Dim o As JArray = JArray.Parse(requestArray(1))

                    For i = 0 To o.Count - 1
                        studyfields_.Add(o(i))
                    Next
                Else
                    MessageBox.Show("Une erreur s'est produite...")
                End If
            Case "GET /user"
                'Return ServerResponses.GetUserDetails
            Case "DISCONNECT /"
                'Return ServerResponses.Disconnect
            Case "GET /students"
                'Return ServerResponses.StudentDirectory
            Case "PUT /user"
                'Return ServerResponses.ModifyProfile
            Case Else
                'Return ServerResponses.erreur
        End Select
    End Sub


End Class
