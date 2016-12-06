<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.idLabel = New System.Windows.Forms.Label()
        Me.pwdLabel = New System.Windows.Forms.Label()
        Me.idTextbox = New System.Windows.Forms.TextBox()
        Me.pwdTextbox = New System.Windows.Forms.TextBox()
        Me.connectinButton = New System.Windows.Forms.Button()
        Me.createAccountLabel = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'idLabel
        '
        Me.idLabel.AutoSize = True
        Me.idLabel.Location = New System.Drawing.Point(3, 22)
        Me.idLabel.Name = "idLabel"
        Me.idLabel.Size = New System.Drawing.Size(50, 13)
        Me.idLabel.TabIndex = 0
        Me.idLabel.Text = "Matricule"
        '
        'pwdLabel
        '
        Me.pwdLabel.AutoSize = True
        Me.pwdLabel.Location = New System.Drawing.Point(3, 54)
        Me.pwdLabel.Name = "pwdLabel"
        Me.pwdLabel.Size = New System.Drawing.Size(53, 13)
        Me.pwdLabel.TabIndex = 1
        Me.pwdLabel.Text = "Password"
        '
        'idTextbox
        '
        Me.idTextbox.Location = New System.Drawing.Point(88, 19)
        Me.idTextbox.Name = "idTextbox"
        Me.idTextbox.Size = New System.Drawing.Size(162, 20)
        Me.idTextbox.TabIndex = 2
        '
        'pwdTextbox
        '
        Me.pwdTextbox.Location = New System.Drawing.Point(88, 51)
        Me.pwdTextbox.Name = "pwdTextbox"
        Me.pwdTextbox.Size = New System.Drawing.Size(162, 20)
        Me.pwdTextbox.TabIndex = 3
        '
        'connectinButton
        '
        Me.connectinButton.Location = New System.Drawing.Point(175, 77)
        Me.connectinButton.Name = "connectinButton"
        Me.connectinButton.Size = New System.Drawing.Size(75, 23)
        Me.connectinButton.TabIndex = 4
        Me.connectinButton.Text = "Connection"
        Me.connectinButton.UseVisualStyleBackColor = True
        '
        'createAccountLabel
        '
        Me.createAccountLabel.AutoSize = True
        Me.createAccountLabel.Location = New System.Drawing.Point(98, 113)
        Me.createAccountLabel.Name = "createAccountLabel"
        Me.createAccountLabel.Size = New System.Drawing.Size(85, 13)
        Me.createAccountLabel.TabIndex = 5
        Me.createAccountLabel.TabStop = True
        Me.createAccountLabel.Text = "Créer un compte"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.idTextbox)
        Me.Panel1.Controls.Add(Me.createAccountLabel)
        Me.Panel1.Controls.Add(Me.pwdLabel)
        Me.Panel1.Controls.Add(Me.connectinButton)
        Me.Panel1.Controls.Add(Me.idLabel)
        Me.Panel1.Controls.Add(Me.pwdTextbox)
        Me.Panel1.Location = New System.Drawing.Point(15, 112)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 138)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 37)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Bienvenue!"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 262)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Home"
        Me.Text = "Home"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idLabel As Label
    Friend WithEvents pwdLabel As Label
    Friend WithEvents idTextbox As TextBox
    Friend WithEvents pwdTextbox As TextBox
    Friend WithEvents connectinButton As Button
    Friend WithEvents createAccountLabel As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
