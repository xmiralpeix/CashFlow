<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pContentUI = New System.Windows.Forms.Panel()
        Me.pButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pButtons
        '
        Me.pButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pButtons.Controls.Add(Me.btnCancel)
        Me.pButtons.Controls.Add(Me.btnOK)
        Me.pButtons.Location = New System.Drawing.Point(2, 371)
        Me.pButtons.Name = "pButtons"
        Me.pButtons.Size = New System.Drawing.Size(644, 33)
        Me.pButtons.TabIndex = 13
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
        Me.btnOK.Text = "Afegir"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'pContentUI
        '
        Me.pContentUI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pContentUI.Location = New System.Drawing.Point(2, 3)
        Me.pContentUI.Name = "pContentUI"
        Me.pContentUI.Size = New System.Drawing.Size(644, 362)
        Me.pContentUI.TabIndex = 14
        '
        'FrmEdit
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 407)
        Me.Controls.Add(Me.pContentUI)
        Me.Controls.Add(Me.pButtons)
        Me.Name = "FrmEdit"
        Me.Text = "FrmEdit"
        Me.pButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents pContentUI As Panel
End Class
