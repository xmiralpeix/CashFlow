<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FinancialProductEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CashFlowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PageGeneral = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbDocStatus = New System.Windows.Forms.ComboBox()
        Me.teRegistrationDate = New CashFlow.TextEditor_Date()
        Me.PageFinancials = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.iBaseImport = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.iProductDeposit = New CashFlow.ListBox_Deposit()
        Me.iBaseDeposit = New CashFlow.ListBox_Deposit()
        Me.iDeposit = New CashFlow.ListBox_Deposit()
        Me.PageEvaluation = New System.Windows.Forms.TabPage()
        Me.ListBox_Evaluation1 = New CashFlow.ListBox_Evaluation()
        Me.TabControl1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PageGeneral.SuspendLayout()
        Me.PageFinancials.SuspendLayout()
        Me.PageEvaluation.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtResult
        '
        Me.txtResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtResult.Location = New System.Drawing.Point(102, 38)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(332, 221)
        Me.txtResult.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Valoració final"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Comentaris"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(106, 97)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(332, 162)
        Me.txtComments.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Alta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Nom"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(106, 15)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 0
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(106, 41)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(332, 20)
        Me.txtName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Comentaris"
        '
        'TabControl1
        '
        Me.TabControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TabControl1.Controls.Add(Me.PageGeneral)
        Me.TabControl1.Controls.Add(Me.PageFinancials)
        Me.TabControl1.Controls.Add(Me.PageEvaluation)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(788, 291)
        Me.TabControl1.TabIndex = 17
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CashFlowToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'CashFlowToolStripMenuItem
        '
        Me.CashFlowToolStripMenuItem.Name = "CashFlowToolStripMenuItem"
        Me.CashFlowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CashFlowToolStripMenuItem.Text = "CashFlow"
        '
        'PageGeneral
        '
        Me.PageGeneral.Controls.Add(Me.Label9)
        Me.PageGeneral.Controls.Add(Me.cbDocStatus)
        Me.PageGeneral.Controls.Add(Me.Label4)
        Me.PageGeneral.Controls.Add(Me.txtID)
        Me.PageGeneral.Controls.Add(Me.txtComments)
        Me.PageGeneral.Controls.Add(Me.txtName)
        Me.PageGeneral.Controls.Add(Me.Label2)
        Me.PageGeneral.Controls.Add(Me.Label1)
        Me.PageGeneral.Controls.Add(Me.teRegistrationDate)
        Me.PageGeneral.Controls.Add(Me.Label3)
        Me.PageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.PageGeneral.Name = "PageGeneral"
        Me.PageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.PageGeneral.Size = New System.Drawing.Size(780, 265)
        Me.PageGeneral.TabIndex = 0
        Me.PageGeneral.Text = "General"
        Me.PageGeneral.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(263, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Estat"
        '
        'cbDocStatus
        '
        Me.cbDocStatus.FormattingEnabled = True
        Me.cbDocStatus.Location = New System.Drawing.Point(317, 10)
        Me.cbDocStatus.Name = "cbDocStatus"
        Me.cbDocStatus.Size = New System.Drawing.Size(121, 21)
        Me.cbDocStatus.TabIndex = 1
        '
        'teRegistrationDate
        '
        Me.teRegistrationDate.Location = New System.Drawing.Point(106, 67)
        Me.teRegistrationDate.Name = "teRegistrationDate"
        Me.teRegistrationDate.Size = New System.Drawing.Size(100, 24)
        Me.teRegistrationDate.TabIndex = 3
        Me.teRegistrationDate.Value = Nothing
        '
        'PageFinancials
        '
        Me.PageFinancials.Controls.Add(Me.Label7)
        Me.PageFinancials.Controls.Add(Me.Label11)
        Me.PageFinancials.Controls.Add(Me.iBaseImport)
        Me.PageFinancials.Controls.Add(Me.Label10)
        Me.PageFinancials.Controls.Add(Me.Label8)
        Me.PageFinancials.Controls.Add(Me.iProductDeposit)
        Me.PageFinancials.Controls.Add(Me.iBaseDeposit)
        Me.PageFinancials.Controls.Add(Me.iDeposit)
        Me.PageFinancials.Location = New System.Drawing.Point(4, 22)
        Me.PageFinancials.Name = "PageFinancials"
        Me.PageFinancials.Padding = New System.Windows.Forms.Padding(3)
        Me.PageFinancials.Size = New System.Drawing.Size(780, 265)
        Me.PageFinancials.TabIndex = 2
        Me.PageFinancials.Text = "Finances"
        Me.PageFinancials.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Dipòsit producte"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Import"
        '
        'iBaseImport
        '
        Me.iBaseImport.Location = New System.Drawing.Point(104, 96)
        Me.iBaseImport.Name = "iBaseImport"
        Me.iBaseImport.Size = New System.Drawing.Size(100, 20)
        Me.iBaseImport.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Dipòsit orígen"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Dipòsit"
        '
        'iProductDeposit
        '
        Me.iProductDeposit.Enabled = False
        Me.iProductDeposit.Location = New System.Drawing.Point(104, 69)
        Me.iProductDeposit.Name = "iProductDeposit"
        Me.iProductDeposit.Size = New System.Drawing.Size(332, 21)
        Me.iProductDeposit.TabIndex = 2
        Me.iProductDeposit.Value = Nothing
        '
        'iBaseDeposit
        '
        Me.iBaseDeposit.Location = New System.Drawing.Point(104, 15)
        Me.iBaseDeposit.Name = "iBaseDeposit"
        Me.iBaseDeposit.Size = New System.Drawing.Size(332, 21)
        Me.iBaseDeposit.TabIndex = 0
        Me.iBaseDeposit.Value = Nothing
        '
        'iDeposit
        '
        Me.iDeposit.Location = New System.Drawing.Point(104, 42)
        Me.iDeposit.Name = "iDeposit"
        Me.iDeposit.Size = New System.Drawing.Size(332, 21)
        Me.iDeposit.TabIndex = 1
        Me.iDeposit.Value = Nothing
        '
        'PageEvaluation
        '
        Me.PageEvaluation.Controls.Add(Me.Label6)
        Me.PageEvaluation.Controls.Add(Me.Label5)
        Me.PageEvaluation.Controls.Add(Me.txtResult)
        Me.PageEvaluation.Controls.Add(Me.ListBox_Evaluation1)
        Me.PageEvaluation.Location = New System.Drawing.Point(4, 22)
        Me.PageEvaluation.Name = "PageEvaluation"
        Me.PageEvaluation.Padding = New System.Windows.Forms.Padding(3)
        Me.PageEvaluation.Size = New System.Drawing.Size(780, 265)
        Me.PageEvaluation.TabIndex = 1
        Me.PageEvaluation.Text = "Valoració"
        Me.PageEvaluation.UseVisualStyleBackColor = True
        '
        'ListBox_Evaluation1
        '
        Me.ListBox_Evaluation1.Location = New System.Drawing.Point(102, 12)
        Me.ListBox_Evaluation1.Name = "ListBox_Evaluation1"
        Me.ListBox_Evaluation1.Size = New System.Drawing.Size(332, 21)
        Me.ListBox_Evaluation1.TabIndex = 45
        Me.ListBox_Evaluation1.Value = Nothing
        '
        'FinancialProductEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FinancialProductEditor"
        Me.Size = New System.Drawing.Size(788, 291)
        Me.TabControl1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PageGeneral.ResumeLayout(False)
        Me.PageGeneral.PerformLayout()
        Me.PageFinancials.ResumeLayout(False)
        Me.PageFinancials.PerformLayout()
        Me.PageEvaluation.ResumeLayout(False)
        Me.PageEvaluation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents teRegistrationDate As TextEditor_Date
    Friend WithEvents txtResult As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ListBox_Evaluation1 As ListBox_Evaluation
    Friend WithEvents Label6 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PageGeneral As TabPage
    Friend WithEvents PageEvaluation As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents cbDocStatus As ComboBox
    Friend WithEvents PageFinancials As TabPage
    Friend WithEvents iBaseDeposit As ListBox_Deposit
    Friend WithEvents Label10 As Label
    Friend WithEvents iDeposit As ListBox_Deposit
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents iBaseImport As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CashFlowEditor1 As CashFlowEntryEditor
    Friend WithEvents Label7 As Label
    Friend WithEvents iProductDeposit As ListBox_Deposit
    Friend WithEvents CashFlowToolStripMenuItem As ToolStripMenuItem
End Class
