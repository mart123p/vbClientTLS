Public Class Form1
    Dim crypto As CryptoTLS
    Dim socketTLS As SocketTLS
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        crypto = New CryptoTLS(False)
        socketTLS = New SocketTLS(SocketTLSType.Client, crypto, TextBox1.Text, 5000, AddressOf receiver, AddressOf onConnect)
    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        Console.WriteLine(request.getRequest)
    End Sub

    Private Sub onConnect(ByVal request As EtudiantsRequest)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        socketTLS.Send("TEstTEstTEsstTEstTEstTEstTEstTEstTEstTEstTEst")
    End Sub
End Class
