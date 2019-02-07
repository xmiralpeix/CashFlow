<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PurchaseInvoiceEditor
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbDocStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstDeposit = New CashFlow.ListBox_Deposit()
        Me.lstSubGroup = New CashFlow.ListBox_SubGroup()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLicTradNum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumAtCard = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDate = New CashFlow.TextEditor_Date()
        Me.lstOwner = New CashFlow.ListBox_Owner()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtConcept = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancellarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbDocStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lstDeposit)
        Me.GroupBox1.Controls.Add(Me.lstSubGroup)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtImport)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLicTradNum)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNumAtCard)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDate)
        Me.GroupBox1.Controls.Add(Me.lstOwner)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtConcept)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 276)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dades"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(354, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Estat"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Propietari"
        '
        'cbDocStatus
        '
        Me.cbDocStatus.Enabled = False
        Me.cbDocStatus.FormattingEnabled = True
        Me.cbDocStatus.Location = New System.Drawing.Point(408, 24)
        Me.cbDocStatus.Name = "cbDocStatus"
        Me.cbDocStatus.Size = New System.Drawing.Size(121, 21)
        Me.cbDocStatus.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Dipòsit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Grup"
        '
        'lstDeposit
        '
        Me.lstDeposit.EntitiesScopeCollection = Nothing
        Me.lstDeposit.Location = New System.Drawing.Point(104, 214)
        Me.lstDeposit.Name = "lstDeposit"
        Me.lstDeposit.Size = New System.Drawing.Size(425, 21)
        Me.lstDeposit.TabIndex = 8
        Me.lstDeposit.Value = Nothing
        '
        'lstSubGroup
        '
        Me.lstSubGroup.EntitiesScopeCollection = Nothing
        Me.lstSubGroup.Location = New System.Drawing.Point(104, 187)
        Me.lstSubGroup.Name = "lstSubGroup"
        Me.lstSubGroup.Size = New System.Drawing.Size(425, 21)
        Me.lstSubGroup.TabIndex = 7
        Me.lstSubGroup.Value = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Import"
        '
        'txtImport
        '
        Me.txtImport.Location = New System.Drawing.Point(104, 241)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.Size = New System.Drawing.Size(100, 20)
        Me.txtImport.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "NIF"
        '
        'txtLicTradNum
        '
        Me.txtLicTradNum.Location = New System.Drawing.Point(104, 109)
        Me.txtLicTradNum.Name = "txtLicTradNum"
        Me.txtLicTradNum.Size = New System.Drawing.Size(100, 20)
        Me.txtLicTradNum.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Núm. de factura"
        '
        'txtNumAtCard
        '
        Me.txtNumAtCard.Location = New System.Drawing.Point(104, 135)
        Me.txtNumAtCard.Name = "txtNumAtCard"
        Me.txtNumAtCard.Size = New System.Drawing.Size(100, 20)
        Me.txtNumAtCard.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Data"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(104, 80)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(100, 24)
        Me.txtDate.TabIndex = 3
        Me.txtDate.Value = Nothing
        '
        'lstOwner
        '
        Me.lstOwner.EntitiesScopeCollection = Nothing
        Me.lstOwner.Location = New System.Drawing.Point(104, 51)
        Me.lstOwner.Name = "lstOwner"
        Me.lstOwner.Size = New System.Drawing.Size(297, 21)
        Me.lstOwner.TabIndex = 2
        Me.lstOwner.Value = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Concepte"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(104, 25)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 0
        '
        'txtConcept
        '
        Me.txtConcept.Location = New System.Drawing.Point(104, 161)
        Me.txtConcept.Name = "txtConcept"
        Me.txtConcept.Size = New System.Drawing.Size(297, 20)
        Me.txtConcept.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancellarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'CancellarToolStripMenuItem
        '
        Me.CancellarToolStripMenuItem.Name = "CancellarToolStripMenuItem"
        Me.CancellarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CancellarToolStripMenuItem.Text = "Cancel·lar"
        '
        'PurchaseInvoiceEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PurchaseInvoiceEditor"
        Me.Size = New System.Drawing.Size(553, 285)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtConcept As TextBox
    Friend WithEvents lstOwner As ListBox_Owner
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLicTradNum As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNumAtCard As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDate As TextEditor_Date
    Friend WithEvents Label7 As Label
    Friend WithEvents txtImport As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lstDeposit As ListBox_Deposit
    Friend WithEvents lstSubGroup As ListBox_SubGroup
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbDocStatus As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CancellarToolStripMenuItem As ToolStripMenuItem
End Class
