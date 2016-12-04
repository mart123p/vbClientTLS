Imports System.Net.Sockets

Public Class Form1
    Dim crypto As CryptoTLS
    Dim socketTLS As SocketTLS
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        crypto = New CryptoTLS(False)
        Try
            socketTLS = New SocketTLS(SocketTLSType.Client, crypto, TextBox1.Text, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect)
        Catch ex As KeyPairChanged

            If MessageBox.Show("La clé publique a changé. Ceci peut poser un risque de sécurité. Voulez vous continuer malgré les circonstances?", "Avertissement", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    socketTLS = New SocketTLS(SocketTLSType.Client, crypto, TextBox1.Text, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect, True)
                Catch ex2 As SocketException
                    MessageBox.Show("Le serveur n'est pas trouvable", "Erreur")
                End Try
            End If

        Catch ex As SocketException
            MessageBox.Show("Le serveur n'est pas trouvable", "Erreur")
        End Try

    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        TextBox3.Text = request.getRequest
    End Sub

    Private Sub onConnect(ByVal request As EtudiantsRequest)

    End Sub

    Private Sub onDisconnect(ByVal endpoint As String)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        socketTLS.Send(TextBox2.Text)
    End Sub

End Class
