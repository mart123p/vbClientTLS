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
        Me.SuspendLayout()
        '
        'idLabel
        '
        Me.idLabel.AutoSize = True
        Me.idLabel.Location = New System.Drawing.Point(13, 117)
        Me.idLabel.Name = "idLabel"
        Me.idLabel.Size = New System.Drawing.Size(50, 13)
        Me.idLabel.TabIndex = 0
        Me.idLabel.Text = "Matricule"
        '
        'pwdLabel
        '
        Me.pwdLabel.AutoSize = True
        Me.pwdLabel.Location = New System.Drawing.Point(12, 152)
        Me.pwdLabel.Name = "pwdLabel"
        Me.pwdLabel.Size = New System.Drawing.Size(53, 13)
        Me.pwdLabel.TabIndex = 1
        Me.pwdLabel.Text = "Password"
        '
        'idTextbox
        '
        Me.idTextbox.Location = New System.Drawing.Point(84, 114)
        Me.idTextbox.Name = "idTextbox"
        Me.idTextbox.Size = New System.Drawing.Size(100, 20)
        Me.idTextbox.TabIndex = 2
        '
        'pwdTextbox
        '
        Me.pwdTextbox.Location = New System.Drawing.Point(84, 149)
        Me.pwdTextbox.Name = "pwdTextbox"
        Me.pwdTextbox.Size = New System.Drawing.Size(100, 20)
        Me.pwdTextbox.TabIndex = 3
        '
        'connectinButton
        '
        Me.connectinButton.Location = New System.Drawing.Point(109, 188)
        Me.connectinButton.Name = "connectinButton"
        Me.connectinButton.Size = New System.Drawing.Size(75, 23)
        Me.connectinButton.TabIndex = 4
        Me.connectinButton.Text = "Connection"
        Me.connectinButton.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.connectinButton)
        Me.Controls.Add(Me.pwdTextbox)
        Me.Controls.Add(Me.idTextbox)
        Me.Controls.Add(Me.pwdLabel)
        Me.Controls.Add(Me.idLabel)
        Me.Name = "Home"
        Me.Text = "Home"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idLabel As Label
    Friend WithEvents pwdLabel As Label
    Friend WithEvents idTextbox As TextBox
    Friend WithEvents pwdTextbox As TextBox
    Friend WithEvents connectinButton As Button
End Class
