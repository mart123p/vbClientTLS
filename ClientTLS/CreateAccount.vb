Imports System.Threading
Public Class CreateAccount
    Dim socketTLS_ As SocketTLS
    Delegate Sub dDispose()
    Sub New(ByRef socketTLS As SocketTLS, ByRef studyField As List(Of String))

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        socketTLS_ = socketTLS
        For Each sf As String In studyField
            ComboBox1.Items.Add(sf)
        Next
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
            If TextBox4.Text = TextBox5.Text Then
                If validateEmail(TextBox3.Text) Then
                    If TextBox1.Text.Length > 2 And TextBox2.Text.Length > 2 Then
                        Dim builder As New ClientBuilder
                        Dim usr As New User(TextBox1.Text, TextBox2.Text, TextBox3.Text, ComboBox1.Text, DateTimePicker1.Text, TextBox4.Text)
                        Button2.Enabled = False
                        Dim th As New Thread(AddressOf sendThreaded)
                        th.IsBackground = True
                        th.Start(builder.createAccount(usr))
                    Else
                        MessageBox.Show("Les noms doivent être d'au moins trois charactères")
                    End If
                Else
                    MessageBox.Show("L'addrese courriel n'est pas valide")
                End If
            Else
                MessageBox.Show(Me, "Les mots de passe doivent être identique", "Erreur")
            End If
        Else
            MessageBox.Show(Me, "Tous les champs doivent être remplis", "Erreur")
        End If
    End Sub
    Private Function validateEmail(ByVal email As String) As Boolean
        Try
            Dim mail As New Net.Mail.MailAddress(email)
            Return True
        Catch ex As FormatException
            Return False
        End Try
    End Function

    Private Sub sendThreaded(ByVal request As String)
        Try
            socketTLS_.Send(request, AddressOf receiver)
        Catch ex As Exception
            MessageBox.Show("Le serveur a planté. Le programme va maintenant se fermer")
            End
        End Try

    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        Select Case reader.read(request.getRequest)
            Case ServerResponses.SignUp
                MessageBox.Show("Le compte a été crée voici votre matricule: " & reader.getId)
                Invoke(New dDispose(AddressOf Dispose))
            Case ServerResponses.erreur
                Button2.Enabled = True
                MessageBox.Show("Une erreur est survenue")

        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()
    End Sub
End Class