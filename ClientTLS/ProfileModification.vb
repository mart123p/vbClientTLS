Imports System.Threading
Public Class ProfileModification
    Dim socketTLS As SocketTLS
    Dim auth As String
    Dim emailCurrent As String
    Dim studyFieldCurrent As String
    Delegate Sub dUpdateTextFields(ByVal email As String, ByVal studyField As String, ByVal firstName As String, ByVal lastName As String, ByVal id As String, ByVal birthday As String)
    Delegate Sub dDispose()

    Sub New(ByRef socketTLS As SocketTLS, ByVal auth As String, ByVal studyFields As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.socketTLS = socketTLS
        Me.auth = auth
        Dim builder As New ClientBuilder
        Dim th As New Thread(AddressOf sendRequest)
        th.Start(builder.getInfos(auth))

        For i = 0 To studyFields.Count - 1
            ComboBox1.Items.Add(studyFields(i))
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim builder As New ClientBuilder
        Dim requestHasToBeMade As Boolean

        If txtEmail.Text <> emailCurrent Then
            Try
                Dim email As New Net.Mail.MailAddress(txtEmail.Text)
                requestHasToBeMade = True
                builder.setEmail(txtEmail.Text)

            Catch ex As FormatException
                MessageBox.Show("Le courriel n'est pas valide.", "Erreur")
                Exit Sub
            Catch ex As ArgumentException
                MessageBox.Show("Le courriel ne peut être vide.", "Erreur")
                txtEmail.Text = emailCurrent
                Exit Sub
            End Try
        End If
        If txtPassword1.Text <> "" And txtPassword2.Text <> "" Then
            If txtPassword1.Text = txtPassword2.Text Then
                requestHasToBeMade = True
                builder.setPassword(txtPassword1.Text)
            Else
                MessageBox.Show("Les mots de passes ne sont pas identiques", "Erreur")
                Exit Sub
            End If
        End If
        If ComboBox1.SelectedItem.ToString <> studyFieldCurrent Then
            requestHasToBeMade = True
            builder.setStudyField(ComboBox1.SelectedItem.ToString)
        End If

        If requestHasToBeMade Then
            Dim th As New Thread(AddressOf sendRequest)
            th.IsBackground = True
            th.Start(builder.profileManager(auth))
        Else
            MessageBox.Show("Aucune modification n'a été trouvée", "Erreur")
        End If
    End Sub
    Private Sub sendRequest(ByVal request As String)
        Try
            socketTLS.Send(request, AddressOf receiver)
        Catch ex As Exception
            MessageBox.Show("Le serveur a planté. Le programme va maintenant se fermer")
            End
        End Try
    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        Select Case (reader.read(request.getRequest))
            Case ServerResponses.GetUserDetails
                Dim user As User = reader.getUser()
                Invoke(New dUpdateTextFields(AddressOf UpdateTextField), user.getEmail, user.getStudyField, user.getFirstName, user.getLastName, user.getMat, user.getBirthday)
            Case ServerResponses.ModifyProfile
                MessageBox.Show("Les modifications ont été faites.")
                Invoke(New dDispose(AddressOf Dispose))
            Case ServerResponses.erreurUtilisateurPareil
                MessageBox.Show("Le courriel existe déjà dans la base de données.")
        End Select
    End Sub
    Private Sub UpdateTextField(ByVal email As String, ByVal studyField As String, ByVal firstName As String, ByVal lastName As String, ByVal id As String, ByVal birthday As String)
        txtEmail.Text = email
        txtBirthday.Text = birthday
        txtFirstName.Text = firstName
        txtLastName.Text = lastName
        txtId.Text = id
        emailCurrent = email
        studyFieldCurrent = studyField
        For i = 0 To ComboBox1.Items.Count - 1
            If ComboBox1.Items(i) = studyField Then
                ComboBox1.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
End Class