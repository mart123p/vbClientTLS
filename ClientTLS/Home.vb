Imports System.Net.Sockets
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class Home
    Dim serverIp As String = "127.0.0.1"
    Dim crypto As CryptoTLS
    Dim socketTLS As SocketTLS
    Dim studyField As New List(Of String)
    Delegate Sub disableButton()
    Delegate Sub enableButton()
    Delegate Sub hideWindow()
    Delegate Sub showWindow()
    Delegate Sub dMessageBox(ByVal message As String, ByVal title As String)
    Dim threadLoader As New Thread(AddressOf establishConnection)

    Private Sub connectinButton_Click(sender As Object, e As EventArgs) Handles connectinButton.Click
        Dim builder As New ClientBuilder
        Dim th As New Thread(AddressOf sendThreaded)
        th.IsBackground = True
        th.Start(builder.connection(idTextbox.Text, pwdTextbox.Text))
        idTextbox.Text = ""
        pwdTextbox.Text = ""
    End Sub
    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        Select Case (reader.read(request.getRequest()))
            Case ServerResponses.StudyField
                studyField = reader.getStudyFields()
            Case ServerResponses.Connection
                Dim studentsDirectory As New StudentsDirectory(socketTLS, Me, reader.getAuth, studyField)
                Invoke(New hideWindow(AddressOf Hide))
                studentsDirectory.ShowDialog()

        End Select

    End Sub

    Private Sub onConnect(ByVal request As EtudiantsRequest)
        Invoke(New enableButton(AddressOf showButtons))
    End Sub

    Private Sub onDisconnect(ByVal endpoint As String)
        MessageBox.Show("Le serveur a fermé la connexion. Le programme va se fermer.")
        End
    End Sub
    Private Sub establishConnection()
        Dim tryconnect As Boolean = True
        Dim asErrors As Boolean = False
        Do
            asErrors = False
            crypto = New CryptoTLS(False)
            Dim builder As New ClientBuilder
            Try
                socketTLS = New SocketTLS(SocketTLSType.Client, crypto, serverIp, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect)

                sendThreaded(builder.studyField)
            Catch ex As KeyPairChanged

                If MessageBox.Show("La clé publique a changé. Ceci peut poser un risque de sécurité. Voulez vous continuer malgré les circonstances?", "Avertissement", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Try
                        socketTLS = New SocketTLS(SocketTLSType.Client, crypto, serverIp, 5000, AddressOf receiver, AddressOf onConnect, AddressOf onDisconnect, True)
                        sendThreaded(builder.studyField)
                    Catch ex2 As SocketException
                        If MsgBox("Le serveur n'est pas trouvable" & vbCrLf & "Voulez vous réessayer de vous connecter?", vbYesNo, "Réessayer la connexion") = vbNo Then
                            tryconnect = False
                            Invoke(New dMessageBox(AddressOf ModalMessageBox), "Le serveur n'est pas trouvable", "Erreur")
                            Invoke(New disableButton(AddressOf serverNotFound))
                        Else
                            asErrors = True
                            serverIpAdress()
                        End If
                    End Try
                Else
                    Invoke(New disableButton(AddressOf serverNotFound))
                End If

            Catch ex As SocketException
                If MsgBox("Le serveur n'est pas trouvable" & vbCrLf & "Voulez vous réessayer de vous connecter?", vbYesNo, "Réessayer la connexion") = vbNo Then
                    tryconnect = False
                    Invoke(New dMessageBox(AddressOf ModalMessageBox), "Le serveur n'est pas trouvable", "Erreur")
                    Invoke(New disableButton(AddressOf serverNotFound))
                Else
                    asErrors = True
                    serverIpAdress()
                End If
            End Try
        Loop While tryconnect And asErrors
    End Sub

    Private Sub sendThreaded(ByVal request As String)
        Try
            socketTLS.Send(request, AddressOf receiver)
        Catch ex As Exception
            MessageBox.Show("Le serveur a planté. Le programme va maintenant se fermer")
            End
        End Try
    End Sub
    Private Sub ModalMessageBox(ByVal message As String, ByVal title As String)
        MessageBox.Show(Me, message, title)
    End Sub
    Public Overloads Sub Show()
        Invoke(New showWindow(AddressOf MyBase.Show))
    End Sub

    Private Sub showButtons()
        connectinButton.Enabled = True
        createAccountLabel.Enabled = True
    End Sub

    Private Sub serverNotFound()
        connectinButton.Enabled = False
        createAccountLabel.Enabled = False
        connectionLabel.Visible = True
    End Sub

    Private Sub createAccountLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles createAccountLabel.LinkClicked
        Dim createAccount As New CreateAccount(socketTLS, studyField)
        Try
            createAccount.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        threadLoader.IsBackground = True
        threadLoader.Start()
    End Sub

    Private Sub serverIpAdress()
        Dim message, title, defaultValue As String
        Dim AdrIp As String
        message = "Entrez l'adresse du serveur"
        title = "Adresse du serveur"
        defaultValue = serverIp
        Dim regexIp As Regex = New Regex("^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
        Do
            AdrIp = InputBox(message, title, defaultValue)
            If AdrIp.Length = 0 Then
                threadLoader.Abort()
            End If
            If Not regexIp.IsMatch(AdrIp) Then
                MsgBox("Adresse Ip invalide. Ex: 127.0.0.1")
            End If

        Loop Until regexIp.IsMatch(AdrIp)
        serverIp = AdrIp
    End Sub
End Class