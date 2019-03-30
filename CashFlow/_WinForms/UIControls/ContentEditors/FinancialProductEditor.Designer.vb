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
        Me.CashFlowNewEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeEntradasDeCashFlowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovaPlantillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LlistaDePlantillesXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ObrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancellarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PageGeneral = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.iOwner = New CashFlow.ListBox_Owner()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbDocStatus = New System.Windows.Forms.ComboBox()
        Me.teRegistrationDate = New CashFlow.TextEditor_Date()
        Me.PageFinancials = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkManualProductDeposit = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.iBaseImport = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.iProductDeposit = New CashFlow.ListBox_Deposit()
        Me.iBaseDeposit = New CashFlow.ListBox_Deposit()
        Me.iDeposit = New CashFlow.ListBox_Deposit()
        Me.PageEvaluation = New System.Windows.Forms.TabPage()
        Me.iEvaluation = New CashFlow.ListBox_Evaluation()
        Me.PageDocuments = New System.Windows.Forms.TabPage()
        Me.DbFilesEditor1 = New CashFlow.DBFilesEditor()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TraspàsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PageGeneral.SuspendLayout()
        Me.PageFinancials.SuspendLayout()
        Me.PageEvaluation.SuspendLayout()
        Me.PageDocuments.SuspendLayout()
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
        Me.Label4.Location = New System.Drawing.Point(10, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Comentaris"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(106, 126)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(332, 133)
        Me.txtComments.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Alta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 70)
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
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(106, 15)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 0
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(106, 70)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(332, 20)
        Me.txtName.TabIndex = 3
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
        Me.TabControl1.Controls.Add(Me.PageDocuments)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(788, 291)
        Me.TabControl1.TabIndex = 17
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CashFlowNewEntryToolStripMenuItem, Me.ListaDeEntradasDeCashFlowToolStripMenuItem, Me.NovaPlantillaToolStripMenuItem, Me.LlistaDePlantillesXToolStripMenuItem, Me.ToolStripSeparator1, Me.ObrirToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.CancellarToolStripMenuItem, Me.ToolStripSeparator2, Me.TraspàsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(268, 214)
        '
        'CashFlowNewEntryToolStripMenuItem
        '
        Me.CashFlowNewEntryToolStripMenuItem.Name = "CashFlowNewEntryToolStripMenuItem"
        Me.CashFlowNewEntryToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.CashFlowNewEntryToolStripMenuItem.Text = "Crear una nova entrada de CashFlow"
        '
        'ListaDeEntradasDeCashFlowToolStripMenuItem
        '
        Me.ListaDeEntradasDeCashFlowToolStripMenuItem.Name = "ListaDeEntradasDeCashFlowToolStripMenuItem"
        Me.ListaDeEntradasDeCashFlowToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ListaDeEntradasDeCashFlowToolStripMenuItem.Text = "Llista de entrades de CashFlow"
        '
        'NovaPlantillaToolStripMenuItem
        '
        Me.NovaPlantillaToolStripMenuItem.Name = "NovaPlantillaToolStripMenuItem"
        Me.NovaPlantillaToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.NovaPlantillaToolStripMenuItem.Text = "Crear una nova plantilla"
        '
        'LlistaDePlantillesXToolStripMenuItem
        '
        Me.LlistaDePlantillesXToolStripMenuItem.Name = "LlistaDePlantillesXToolStripMenuItem"
        Me.LlistaDePlantillesXToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.LlistaDePlantillesXToolStripMenuItem.Text = "Llista de plantilles"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(264, 6)
        '
        'ObrirToolStripMenuItem
        '
        Me.ObrirToolStripMenuItem.Name = "ObrirToolStripMenuItem"
        Me.ObrirToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ObrirToolStripMenuItem.Text = "Obrir"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.CancelarToolStripMenuItem.Text = "Tancar"
        '
        'CancellarToolStripMenuItem
        '
        Me.CancellarToolStripMenuItem.Name = "CancellarToolStripMenuItem"
        Me.CancellarToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.CancellarToolStripMenuItem.Text = "Cancel·lar"
        '
        'PageGeneral
        '
        Me.PageGeneral.Controls.Add(Me.Label12)
        Me.PageGeneral.Controls.Add(Me.iOwner)
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Propietari"
        '
        'iOwner
        '
        Me.iOwner.EntitiesScopeCollection = Nothing
        Me.iOwner.Location = New System.Drawing.Point(106, 41)
        Me.iOwner.Name = "iOwner"
        Me.iOwner.Size = New System.Drawing.Size(425, 21)
        Me.iOwner.TabIndex = 2
        Me.iOwner.Value = Nothing
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
        Me.teRegistrationDate.Location = New System.Drawing.Point(106, 96)
        Me.teRegistrationDate.Name = "teRegistrationDate"
        Me.teRegistrationDate.Size = New System.Drawing.Size(100, 24)
        Me.teRegistrationDate.TabIndex = 4
        Me.teRegistrationDate.Value = Nothing
        '
        'PageFinancials
        '
        Me.PageFinancials.Controls.Add(Me.Label7)
        Me.PageFinancials.Controls.Add(Me.chkManualProductDeposit)
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
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(758, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "* Marca la casella per informar del dipòdit del producte manualment, si no es cre" &
    "arà automàticament quan s'obri el producte financer"
        '
        'chkManualProductDeposit
        '
        Me.chkManualProductDeposit.AutoSize = True
        Me.chkManualProductDeposit.Location = New System.Drawing.Point(11, 73)
        Me.chkManualProductDeposit.Name = "chkManualProductDeposit"
        Me.chkManualProductDeposit.Size = New System.Drawing.Size(103, 17)
        Me.chkManualProductDeposit.TabIndex = 52
        Me.chkManualProductDeposit.Text = "Dipòsit producte"
        Me.chkManualProductDeposit.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Import"
        '
        'iBaseImport
        '
        Me.iBaseImport.Location = New System.Drawing.Point(129, 125)
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
        Me.iProductDeposit.EntitiesScopeCollection = Nothing
        Me.iProductDeposit.Location = New System.Drawing.Point(129, 73)
        Me.iProductDeposit.Name = "iProductDeposit"
        Me.iProductDeposit.Size = New System.Drawing.Size(332, 21)
        Me.iProductDeposit.TabIndex = 2
        Me.iProductDeposit.Value = Nothing
        '
        'iBaseDeposit
        '
        Me.iBaseDeposit.EntitiesScopeCollection = Nothing
        Me.iBaseDeposit.Location = New System.Drawing.Point(129, 17)
        Me.iBaseDeposit.Name = "iBaseDeposit"
        Me.iBaseDeposit.Size = New System.Drawing.Size(332, 21)
        Me.iBaseDeposit.TabIndex = 0
        Me.iBaseDeposit.Value = Nothing
        '
        'iDeposit
        '
        Me.iDeposit.EntitiesScopeCollection = Nothing
        Me.iDeposit.Location = New System.Drawing.Point(129, 44)
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
        Me.PageEvaluation.Controls.Add(Me.iEvaluation)
        Me.PageEvaluation.Location = New System.Drawing.Point(4, 22)
        Me.PageEvaluation.Name = "PageEvaluation"
        Me.PageEvaluation.Padding = New System.Windows.Forms.Padding(3)
        Me.PageEvaluation.Size = New System.Drawing.Size(780, 265)
        Me.PageEvaluation.TabIndex = 1
        Me.PageEvaluation.Text = "Valoració"
        Me.PageEvaluation.UseVisualStyleBackColor = True
        '
        'iEvaluation
        '
        Me.iEvaluation.EntitiesScopeCollection = Nothing
        Me.iEvaluation.Location = New System.Drawing.Point(102, 12)
        Me.iEvaluation.Name = "iEvaluation"
        Me.iEvaluation.Size = New System.Drawing.Size(332, 21)
        Me.iEvaluation.TabIndex = 45
        Me.iEvaluation.Value = Nothing
        '
        'PageDocuments
        '
        Me.PageDocuments.Controls.Add(Me.DbFilesEditor1)
        Me.PageDocuments.Location = New System.Drawing.Point(4, 22)
        Me.PageDocuments.Name = "PageDocuments"
        Me.PageDocuments.Padding = New System.Windows.Forms.Padding(3)
        Me.PageDocuments.Size = New System.Drawing.Size(780, 265)
        Me.PageDocuments.TabIndex = 3
        Me.PageDocuments.Text = "Documents"
        Me.PageDocuments.UseVisualStyleBackColor = True
        '
        'DbFilesEditor1
        '
        Me.DbFilesEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DbFilesEditor1.Location = New System.Drawing.Point(3, 3)
        Me.DbFilesEditor1.Name = "DbFilesEditor1"
        Me.DbFilesEditor1.ObjectID = 0
        Me.DbFilesEditor1.ObjectTable = Nothing
        Me.DbFilesEditor1.Size = New System.Drawing.Size(774, 259)
        Me.DbFilesEditor1.TabIndex = 0
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(264, 6)
        '
        'TraspàsToolStripMenuItem
        '
        Me.TraspàsToolStripMenuItem.Name = "TraspàsToolStripMenuItem"
        Me.TraspàsToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.TraspàsToolStripMenuItem.Text = "Traspàs"
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
        Me.PageDocuments.ResumeLayout(False)
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
    Friend WithEvents iEvaluation As ListBox_Evaluation
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
    Friend WithEvents iProductDeposit As ListBox_Deposit
    Friend WithEvents CashFlowNewEntryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListaDeEntradasDeCashFlowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label12 As Label
    Friend WithEvents iOwner As ListBox_Owner
    Friend WithEvents NovaPlantillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LlistaDePlantillesXToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PageDocuments As TabPage
    Friend WithEvents DbFilesEditor1 As DBFilesEditor
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ObrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents chkManualProductDeposit As CheckBox
    Friend WithEvents CancelarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancellarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TraspàsToolStripMenuItem As ToolStripMenuItem
End Class
