Imports System.Threading
Public Class ProfileModification
    Dim socketTLS As SocketTLS
    Dim auth As String
    Dim emailCurrent As String
    Dim studyFieldCurrent As String
    Delegate Sub dUpdateTextFields(ByVal email As String, ByVal studyField As String)

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
        If txtEmail.Text <> emailCurrent Then

        ElseIf txtPassword1.Text <> "" And txtPassword2.Text <> "" Then

        ElseIf ComboBox1.SelectedItem.ToString <> studyFieldCurrent Then

        End If
        Dispose()
    End Sub
    Private Sub sendRequest(ByVal request As String)
        socketTLS.Send(request, AddressOf receiver)
    End Sub

    Private Sub receiver(ByVal request As EtudiantsRequest)
        Dim reader As New ServerReader
        Select Case (reader.read(request.getRequest))
            Case ServerResponses.GetUserDetails
                Dim user As User = reader.getUser()
                Invoke(New dUpdateTextFields(AddressOf UpdateTextField), user.getEmail, user.getStudyField)
        End Select
    End Sub
    Private Sub UpdateTextField(ByVal email As String, ByVal studyField As String)
        txtEmail.Text = email
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