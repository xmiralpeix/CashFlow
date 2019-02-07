<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompany
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.pButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Servidor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuari"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contrasenya"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(104, 18)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 20)
        Me.txtUser.TabIndex = 2
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(294, 18)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtPwd.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Base de dades"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(104, 50)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(290, 20)
        Me.txtServer.TabIndex = 6
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(104, 76)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(78, 23)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Actualitzar"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'grid
        '
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(15, 105)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(420, 172)
        Me.grid.TabIndex = 8
        '
        'pButtons
        '
        Me.pButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pButtons.Controls.Add(Me.btnCancel)
        Me.pButtons.Controls.Add(Me.btnOK)
        Me.pButtons.Location = New System.Drawing.Point(1, 283)
        Me.pButtons.Name = "pButtons"
        Me.pButtons.Size = New System.Drawing.Size(446, 33)
        Me.pButtons.TabIndex = 9
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(94, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(13, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FrmCompany
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 317)
        Me.Controls.Add(Me.pButtons)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmCompany"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecció de societat"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPwd As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents grid As DataGridView
    Friend WithEvents pButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
