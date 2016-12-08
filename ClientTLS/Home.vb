Imports System.Net.Sockets
Imports System.Threading

Public Class Home
    Dim serverIp As String = "127.0.0.1"
    Dim crypto As CryptoTLS
    Dim socketTLS As SocketTLS
    Dim studyField As New List(Of String)
    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        Try
            establishConnecion()
            Dim builder As New ClientBuilder
            Dim socketSendBuilder As New List(Of Object)
            socketSendBuilder.Add(socketTLS)
            socketSendBuilder.Add(builder.studyField())
            Dim th As New Thread(AddressOf sendThreaded)
            th.Start(socketSendBuilder)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub connectinButton_Click(sender As Object, e As EventArgs) Handles connectinButton.Click
        Dim builder As New ClientBuilder
        Dim socketSendBuilder As New List(Of Object)
        socketSendBuilder.Add(socketTLS)
        socketSendBuilder.Add(builder.connection(idTextbox.Text(), pwdTextbox.Text()))
        Dim th As New Thread(AddressOf sendThreaded)
        th.Start(socketSendBuilder)

    End Sub
    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        reader.read(request.getRequest())
        If Not reader.getStudyFields().Count = 0 Then
            studyField = reader.getStudyFields()
        End If

    End Sub

    Private Sub onConnect(ByVal request As EtudiantsRequest)

    End Sub

    Private Sub onDisconnect(ByVal endpoint As String)

    End Sub
    Private Sub establishConnecion()
        crypto = New CryptoTLS(False)
        Try
            socketTLS = New SocketTLS(SocketTLSType.Client, crypto, serverIp, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect)
        Catch ex As KeyPairChanged

            If MessageBox.Show("La clé publique a changé. Ceci peut poser un risque de sécurité. Voulez vous continuer malgré les circonstances?", "Avertissement", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    socketTLS = New SocketTLS(SocketTLSType.Client, crypto, serverIp, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect, True)
                Catch ex2 As SocketException
                    MessageBox.Show("Le serveur n'est pas trouvable", "Erreur")
                End Try
            End If

        Catch ex As SocketException
            MessageBox.Show("Le serveur n'est pas trouvable", "Erreur")
        End Try
    End Sub
    Private Sub sendThreaded(ByVal socketAndBuilder As List(Of Object))
        socketAndBuilder(0).send(socketAndBuilder(1))
    End Sub

    Private Sub createAccountLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles createAccountLabel.LinkClicked
        Dim createAccount As New CreateAccount(socketTLS, studyField)
        createAccount.ShowDialog()
    End Sub
End Class