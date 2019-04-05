<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransfer
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
        Me.pContentUI = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConcept = New System.Windows.Forms.TextBox()
        Me.txtEntryDate = New CashFlow.TextEditor_Date()
        Me.lbFromDeposit = New CashFlow.ListBox_Deposit()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.lbToDeposit = New CashFlow.ListBox_Deposit()
        Me.pContentUI.SuspendLayout()
        Me.pButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pContentUI
        '
        Me.pContentUI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pContentUI.Controls.Add(Me.lbToDeposit)
        Me.pContentUI.Controls.Add(Me.txtImport)
        Me.pContentUI.Controls.Add(Me.txtConcept)
        Me.pContentUI.Controls.Add(Me.Label5)
        Me.pContentUI.Controls.Add(Me.Label4)
        Me.pContentUI.Controls.Add(Me.Label3)
        Me.pContentUI.Controls.Add(Me.Label2)
        Me.pContentUI.Controls.Add(Me.Label1)
        Me.pContentUI.Controls.Add(Me.lblDate)
        Me.pContentUI.Controls.Add(Me.txtEntryDate)
        Me.pContentUI.Controls.Add(Me.lbFromDeposit)
        Me.pContentUI.Location = New System.Drawing.Point(0, 1)
        Me.pContentUI.Name = "pContentUI"
        Me.pContentUI.Size = New System.Drawing.Size(598, 200)
        Me.pContentUI.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Concepte"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(17, 38)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Data"
        '
        'pButtons
        '
        Me.pButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pButtons.Controls.Add(Me.btnCancel)
        Me.pButtons.Controls.Add(Me.btnOK)
        Me.pButtons.Location = New System.Drawing.Point(0, 204)
        Me.pButtons.Name = "pButtons"
        Me.pButtons.Size = New System.Drawing.Size(598, 33)
        Me.pButtons.TabIndex = 15
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Dipòsit orígen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Dipòsit destí"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Import"
        '
        'txtConcept
        '
        Me.txtConcept.Location = New System.Drawing.Point(94, 57)
        Me.txtConcept.Name = "txtConcept"
        Me.txtConcept.Size = New System.Drawing.Size(425, 20)
        Me.txtConcept.TabIndex = 1
        '
        'txtEntryDate
        '
        Me.txtEntryDate.Location = New System.Drawing.Point(94, 27)
        Me.txtEntryDate.Name = "txtEntryDate"
        Me.txtEntryDate.Size = New System.Drawing.Size(90, 24)
        Me.txtEntryDate.TabIndex = 0
        Me.txtEntryDate.Value = Nothing
        '
        'lbFromDeposit
        '
        Me.lbFromDeposit.EntitiesScopeCollection = Nothing
        Me.lbFromDeposit.Location = New System.Drawing.Point(94, 87)
        Me.lbFromDeposit.Name = "lbFromDeposit"
        Me.lbFromDeposit.Size = New System.Drawing.Size(425, 21)
        Me.lbFromDeposit.TabIndex = 2
        Me.lbFromDeposit.Value = Nothing
        '
        'txtImport
        '
        Me.txtImport.Location = New System.Drawing.Point(94, 141)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.Size = New System.Drawing.Size(100, 20)
        Me.txtImport.TabIndex = 4
        '
        'lbToDeposit
        '
        Me.lbToDeposit.EntitiesScopeCollection = Nothing
        Me.lbToDeposit.Location = New System.Drawing.Point(94, 114)
        Me.lbToDeposit.Name = "lbToDeposit"
        Me.lbToDeposit.Size = New System.Drawing.Size(425, 21)
        Me.lbToDeposit.TabIndex = 3
        Me.lbToDeposit.Value = Nothing
        '
        'FrmTransfer
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 240)
        Me.Controls.Add(Me.pContentUI)
        Me.Controls.Add(Me.pButtons)
        Me.Name = "FrmTransfer"
        Me.Text = "Transferència"
        Me.pContentUI.ResumeLayout(False)
        Me.pContentUI.PerformLayout()
        Me.pButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pContentUI As Panel
    Friend WithEvents pButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents lbFromDeposit As ListBox_Deposit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents txtEntryDate As TextEditor_Date
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtConcept As TextBox
    Friend WithEvents txtImport As TextBox
    Friend WithEvents lbToDeposit As ListBox_Deposit
End Class
