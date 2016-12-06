Imports Newtonsoft.Json.Linq
Public Class ServerReader
    Public Function getSubscribe(ByVal request As Dictionary(Of String, String)) As String
        If (request("errCode") = "200") Then
            Dim o As JObject = JObject.Parse(request("json"))
            Return o.GetValue("id").ToString
        End If
    End Function
    Public Function separate(ByVal request As String) As Dictionary(Of String, String)
        Dim dic As New Dictionary(Of String, String)
        Try
            Dim requestArray As String() = request.Split(vbCrLf)
            Dim firstLine As String() = requestArray(0).Split(" ")
            dic.Add("ErrCode", firstLine(0))
            dic.Add("reqType", firstLine(1))
            dic.Add("path", firstLine(2))
            dic.Add("json", requestArray(1))
        Catch ex As Exception
            Throw New BadRequestException("200 POST /User" & vbCrLf & "{json}")
            Return Nothing
        End Try
        Return dic
    End Function
End Class
