Imports System.Threading
Public Class StudentsDirectory
    Dim auth As String
    Dim socketTLS As SocketTLS
    Dim form As Home
    Dim builder As New ClientBuilder
    Dim studyField As List(Of String)
    Delegate Sub dUpdateList(ByVal itm As ListViewItem)
    Delegate Sub dClearList()

    Sub New(ByRef socketTLS As SocketTLS, ByRef form As Home, ByVal auth As String, ByVal studyField As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()
        Me.auth = auth
        Me.socketTLS = socketTLS
        Me.form = form
        Me.studyField = studyField
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Prénom", 75)
        ListView1.Columns.Add("Nom", 75)
        ListView1.Columns.Add("Courriel", 150)
        ListView1.Columns.Add("Champ d'étude", 200)

        ComboBox1.Items.Add("Tous les programmes")
        For i = 0 To studyField.Count - 1
            ComboBox1.Items.Add(studyField(i))
        Next
        ComboBox1.SelectedIndex = 0
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadEtudiants()
    End Sub

    Private Sub ModifierMonProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifierMonProfileToolStripMenuItem.Click
        If studyField.Count = 0 Then
            MsgBox("Le serveur ne possède pas de programme d'étude, veuillez réessayer plus-tard...")
        Else
            Dim modify As New ProfileModification(socketTLS, auth, studyField)
            modify.ShowDialog()
        End If

    End Sub

    Private Sub LoadEtudiants()
        Dim studyField As String = ""
        If ComboBox1.SelectedItem.ToString <> "Tous les programmes" Then
            studyField = ComboBox1.SelectedItem.ToString
        End If
        Dim th As New Thread(AddressOf sendRequest)
        th.IsBackground = True
        th.Start(builder.studentDirectory(auth, studyField))
    End Sub

    Private Sub StudentsDirectory_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Dim th As New Thread(AddressOf sendRequest)
        th.IsBackground = True
        th.Start(builder.disconnect(auth))
        form.Show()
        Dispose()
    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        Select Case (reader.read(request.getRequest))
            Case ServerResponses.StudentDirectory
                Dim etudiants As Etudiants() = reader.getEtudiants
                Invoke(New dClearList(AddressOf deleteListView))
                If etudiants.Count = 0 Then
                    MessageBox.Show("Aucun étudiant est dans ce programme d'étude")
                End If
                For i = 0 To etudiants.Count - 1
                    Dim itm As ListViewItem
                    Dim arr(3) As String
                    arr(0) = etudiants(i).getFirstName
                    arr(1) = etudiants(i).getLastName
                    arr(2) = etudiants(i).getEmail
                    arr(3) = etudiants(i).getStudyField
                    itm = New ListViewItem(arr)
                    Invoke(New dUpdateList(AddressOf updateListView), itm)
                Next
        End Select

    End Sub

    Private Sub updateListView(ByVal itm As ListViewItem)
        ListView1.Items.Add(itm)
    End Sub

    Private Sub deleteListView()
        ListView1.Items.Clear()
    End Sub

    Private Sub sendRequest(ByVal request As String)
        Try
            socketTLS.Send(request, AddressOf receiver)
        Catch ex As Exception
            MessageBox.Show("Le serveur a planté. Le programme va maintenant se fermer")
            End
        End Try
    End Sub

    Private Sub DéconnexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DéconnexionToolStripMenuItem.Click
        Dispose()
    End Sub
End Class