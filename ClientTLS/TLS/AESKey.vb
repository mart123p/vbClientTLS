Public Class AESKey
    Dim key As String
    Dim IV As String

    Sub New(ByVal key As String, ByVal IV As String)
        Me.key = key
        Me.IV = IV
    End Sub


    Public Function getKey() As String
        Return key
    End Function

    Public Function getIV() As String
        Return IV
    End Function

    Public Sub setKey(ByVal key As String)
        Me.key = key
    End Sub

    Public Sub setIV(ByVal iv As String)
        Me.IV = iv
    End Sub
End Class
