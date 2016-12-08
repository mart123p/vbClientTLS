Public Class CreateAccount
    Dim socketTLS_ As SocketTLS
    Sub New(ByRef socketTLS As SocketTLS)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        socketTLS_ = socketTLS
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim builder As New ClientBuilder
        Dim usr As New User(TextBox1.Text, TextBox2.Text, TextBox3.Text, ComboBox1.Text, DateTimePicker1.Text, TextBox4.Text)
        socketTLS_.Send(builder.createAccount(usr))
    End Sub
End Class