<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JournalEntryEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.chkImport = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtConcept = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblIncomes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblExpenses = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBalance = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtEntryDate = New CashFlow.TextEditor_Date()
        Me.ListBox_SubGroup1 = New CashFlow.ListBox_SubGroup()
        Me.ListBox_FinancialProduct1 = New CashFlow.ListBox_FinancialProduct()
        Me.ListBox_Deposit1 = New CashFlow.ListBox_Deposit()
        Me.chkDeposit = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "ID"
        '
        'txtImport
        '
        Me.txtImport.Location = New System.Drawing.Point(131, 166)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.Size = New System.Drawing.Size(100, 20)
        Me.txtImport.TabIndex = 48
        '
        'chkImport
        '
        Me.chkImport.AutoSize = True
        Me.chkImport.Checked = True
        Me.chkImport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImport.Location = New System.Drawing.Point(14, 168)
        Me.chkImport.Name = "chkImport"
        Me.chkImport.Size = New System.Drawing.Size(55, 17)
        Me.chkImport.TabIndex = 47
        Me.chkImport.Text = "Import"
        Me.chkImport.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(14, 145)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox4.TabIndex = 46
        Me.CheckBox4.Text = "Concepte"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(14, 93)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(110, 17)
        Me.CheckBox3.TabIndex = 45
        Me.CheckBox3.Text = "Producte financer"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(14, 67)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(49, 17)
        Me.CheckBox2.TabIndex = 44
        Me.CheckBox2.Text = "Grup"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(14, 41)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(49, 17)
        Me.CheckBox1.TabIndex = 43
        Me.CheckBox1.Text = "Data"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtConcept
        '
        Me.txtConcept.Location = New System.Drawing.Point(130, 142)
        Me.txtConcept.Name = "txtConcept"
        Me.txtConcept.Size = New System.Drawing.Size(417, 20)
        Me.txtConcept.TabIndex = 38
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(130, 9)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 36
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblIncomes, Me.lblExpenses, Me.lblBalance})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 226)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(565, 22)
        Me.StatusStrip1.TabIndex = 55
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblIncomes
        '
        Me.lblIncomes.Name = "lblIncomes"
        Me.lblIncomes.Size = New System.Drawing.Size(405, 17)
        Me.lblIncomes.Spring = True
        Me.lblIncomes.Text = "Ingressos: 0.00"
        Me.lblIncomes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExpenses
        '
        Me.lblExpenses.Name = "lblExpenses"
        Me.lblExpenses.Size = New System.Drawing.Size(82, 17)
        Me.lblExpenses.Text = "Despeses: 0.00"
        '
        'lblBalance
        '
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(63, 17)
        Me.lblBalance.Text = "Saldo: 0.00"
        '
        'txtEntryDate
        '
        Me.txtEntryDate.Location = New System.Drawing.Point(130, 34)
        Me.txtEntryDate.Name = "txtEntryDate"
        Me.txtEntryDate.Size = New System.Drawing.Size(118, 24)
        Me.txtEntryDate.TabIndex = 56
        Me.txtEntryDate.Value = Nothing
        '
        'ListBox_SubGroup1
        '
        Me.ListBox_SubGroup1.Location = New System.Drawing.Point(130, 60)
        Me.ListBox_SubGroup1.Name = "ListBox_SubGroup1"
        Me.ListBox_SubGroup1.Size = New System.Drawing.Size(425, 21)
        Me.ListBox_SubGroup1.TabIndex = 57
        Me.ListBox_SubGroup1.Value = Nothing
        '
        'ListBox_FinancialProduct1
        '
        Me.ListBox_FinancialProduct1.Location = New System.Drawing.Point(130, 86)
        Me.ListBox_FinancialProduct1.Name = "ListBox_FinancialProduct1"
        Me.ListBox_FinancialProduct1.Size = New System.Drawing.Size(425, 21)
        Me.ListBox_FinancialProduct1.TabIndex = 58
        Me.ListBox_FinancialProduct1.Value = Nothing
        '
        'ListBox_Deposit1
        '
        Me.ListBox_Deposit1.Location = New System.Drawing.Point(130, 115)
        Me.ListBox_Deposit1.Name = "ListBox_Deposit1"
        Me.ListBox_Deposit1.Size = New System.Drawing.Size(425, 21)
        Me.ListBox_Deposit1.TabIndex = 59
        Me.ListBox_Deposit1.Value = Nothing
        '
        'chkDeposit
        '
        Me.chkDeposit.AutoSize = True
        Me.chkDeposit.Checked = True
        Me.chkDeposit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDeposit.Location = New System.Drawing.Point(14, 118)
        Me.chkDeposit.Name = "chkDeposit"
        Me.chkDeposit.Size = New System.Drawing.Size(58, 17)
        Me.chkDeposit.TabIndex = 60
        Me.chkDeposit.Text = "Dipòsit"
        Me.chkDeposit.UseVisualStyleBackColor = True
        '
        'JournalEntryEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkDeposit)
        Me.Controls.Add(Me.ListBox_Deposit1)
        Me.Controls.Add(Me.ListBox_FinancialProduct1)
        Me.Controls.Add(Me.ListBox_SubGroup1)
        Me.Controls.Add(Me.txtEntryDate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtImport)
        Me.Controls.Add(Me.chkImport)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtConcept)
        Me.Controls.Add(Me.txtID)
        Me.Name = "JournalEntryEditor"
        Me.Size = New System.Drawing.Size(565, 248)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtImport As TextBox
    Friend WithEvents chkImport As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtConcept As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblIncomes As ToolStripStatusLabel
    Friend WithEvents lblExpenses As ToolStripStatusLabel
    Friend WithEvents lblBalance As ToolStripStatusLabel
    Friend WithEvents txtEntryDate As TextEditor_Date
    Friend WithEvents ListBox_SubGroup1 As ListBox_SubGroup
    Friend WithEvents ListBox_FinancialProduct1 As ListBox_FinancialProduct
    Friend WithEvents ListBox_Deposit1 As ListBox_Deposit
    Friend WithEvents chkDeposit As CheckBox
End Class
