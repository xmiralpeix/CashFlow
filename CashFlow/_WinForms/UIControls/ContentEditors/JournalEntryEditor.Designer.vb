﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.chkImport = New System.Windows.Forms.CheckBox()
        Me.chkConcept = New System.Windows.Forms.CheckBox()
        Me.chkGroup = New System.Windows.Forms.CheckBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.txtConcept = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblIncomes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblExpenses = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBalance = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chkDeposit = New System.Windows.Forms.CheckBox()
        Me.txtBaseObjectID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbObjTypes = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CrearUnTraspàsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.ListBox_Deposit1 = New CashFlow.ListBox_Deposit()
        Me.ListBox_SubGroup1 = New CashFlow.ListBox_SubGroup()
        Me.txtEntryDate = New CashFlow.TextEditor_Date()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.txtImport.Location = New System.Drawing.Point(131, 138)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.Size = New System.Drawing.Size(100, 20)
        Me.txtImport.TabIndex = 5
        '
        'chkImport
        '
        Me.chkImport.AutoSize = True
        Me.chkImport.Location = New System.Drawing.Point(14, 140)
        Me.chkImport.Name = "chkImport"
        Me.chkImport.Size = New System.Drawing.Size(55, 17)
        Me.chkImport.TabIndex = 47
        Me.chkImport.TabStop = False
        Me.chkImport.Text = "Import"
        Me.chkImport.UseVisualStyleBackColor = True
        '
        'chkConcept
        '
        Me.chkConcept.AutoSize = True
        Me.chkConcept.Location = New System.Drawing.Point(14, 117)
        Me.chkConcept.Name = "chkConcept"
        Me.chkConcept.Size = New System.Drawing.Size(72, 17)
        Me.chkConcept.TabIndex = 46
        Me.chkConcept.TabStop = False
        Me.chkConcept.Text = "Concepte"
        Me.chkConcept.UseVisualStyleBackColor = True
        '
        'chkGroup
        '
        Me.chkGroup.AutoSize = True
        Me.chkGroup.Location = New System.Drawing.Point(14, 67)
        Me.chkGroup.Name = "chkGroup"
        Me.chkGroup.Size = New System.Drawing.Size(49, 17)
        Me.chkGroup.TabIndex = 44
        Me.chkGroup.TabStop = False
        Me.chkGroup.Text = "Grup"
        Me.chkGroup.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(14, 41)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(49, 17)
        Me.chkDate.TabIndex = 43
        Me.chkDate.TabStop = False
        Me.chkDate.Text = "Data"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'txtConcept
        '
        Me.txtConcept.Location = New System.Drawing.Point(130, 114)
        Me.txtConcept.Name = "txtConcept"
        Me.txtConcept.Size = New System.Drawing.Size(417, 20)
        Me.txtConcept.TabIndex = 4
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(130, 9)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblIncomes, Me.ToolStripStatusLabel2, Me.lblExpenses, Me.ToolStripStatusLabel1, Me.lblBalance})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 226)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(565, 22)
        Me.StatusStrip1.TabIndex = 55
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblIncomes
        '
        Me.lblIncomes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIncomes.Name = "lblIncomes"
        Me.lblIncomes.Size = New System.Drawing.Size(378, 17)
        Me.lblIncomes.Spring = True
        Me.lblIncomes.Text = "Ingressos: 0.00"
        Me.lblIncomes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'lblExpenses
        '
        Me.lblExpenses.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExpenses.Name = "lblExpenses"
        Me.lblExpenses.Size = New System.Drawing.Size(82, 17)
        Me.lblExpenses.Text = "Despeses: 0.00"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel1.Text = "||"
        '
        'lblBalance
        '
        Me.lblBalance.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.lblBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(67, 17)
        Me.lblBalance.Text = "Saldo: 0.00"
        '
        'chkDeposit
        '
        Me.chkDeposit.AutoSize = True
        Me.chkDeposit.Location = New System.Drawing.Point(14, 90)
        Me.chkDeposit.Name = "chkDeposit"
        Me.chkDeposit.Size = New System.Drawing.Size(58, 17)
        Me.chkDeposit.TabIndex = 60
        Me.chkDeposit.TabStop = False
        Me.chkDeposit.Text = "Dipòsit"
        Me.chkDeposit.UseVisualStyleBackColor = True
        '
        'txtBaseObjectID
        '
        Me.txtBaseObjectID.Enabled = False
        Me.txtBaseObjectID.Location = New System.Drawing.Point(257, 165)
        Me.txtBaseObjectID.Name = "txtBaseObjectID"
        Me.txtBaseObjectID.ReadOnly = True
        Me.txtBaseObjectID.Size = New System.Drawing.Size(100, 20)
        Me.txtBaseObjectID.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Orígen"
        '
        'cbObjTypes
        '
        Me.cbObjTypes.Enabled = False
        Me.cbObjTypes.FormattingEnabled = True
        Me.cbObjTypes.Location = New System.Drawing.Point(130, 165)
        Me.cbObjTypes.Name = "cbObjTypes"
        Me.cbObjTypes.Size = New System.Drawing.Size(121, 21)
        Me.cbObjTypes.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearUnTraspàsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'CrearUnTraspàsToolStripMenuItem
        '
        Me.CrearUnTraspàsToolStripMenuItem.Name = "CrearUnTraspàsToolStripMenuItem"
        Me.CrearUnTraspàsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CrearUnTraspàsToolStripMenuItem.Text = "Nou traspàs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(387, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Estat"
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(424, 13)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(131, 20)
        Me.txtStatus.TabIndex = 66
        '
        'ListBox_Deposit1
        '
        Me.ListBox_Deposit1.EntitiesScopeCollection = Nothing
        Me.ListBox_Deposit1.Location = New System.Drawing.Point(130, 87)
        Me.ListBox_Deposit1.Name = "ListBox_Deposit1"
        Me.ListBox_Deposit1.Size = New System.Drawing.Size(425, 21)
        Me.ListBox_Deposit1.TabIndex = 3
        Me.ListBox_Deposit1.Value = Nothing
        '
        'ListBox_SubGroup1
        '
        Me.ListBox_SubGroup1.EntitiesScopeCollection = Nothing
        Me.ListBox_SubGroup1.Location = New System.Drawing.Point(130, 60)
        Me.ListBox_SubGroup1.Name = "ListBox_SubGroup1"
        Me.ListBox_SubGroup1.Size = New System.Drawing.Size(425, 21)
        Me.ListBox_SubGroup1.TabIndex = 2
        Me.ListBox_SubGroup1.Value = Nothing
        '
        'txtEntryDate
        '
        Me.txtEntryDate.Location = New System.Drawing.Point(130, 34)
        Me.txtEntryDate.Name = "txtEntryDate"
        Me.txtEntryDate.Size = New System.Drawing.Size(118, 24)
        Me.txtEntryDate.TabIndex = 1
        Me.txtEntryDate.Value = Nothing
        '
        'JournalEntryEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbObjTypes)
        Me.Controls.Add(Me.txtBaseObjectID)
        Me.Controls.Add(Me.chkDeposit)
        Me.Controls.Add(Me.ListBox_Deposit1)
        Me.Controls.Add(Me.ListBox_SubGroup1)
        Me.Controls.Add(Me.txtEntryDate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtImport)
        Me.Controls.Add(Me.chkImport)
        Me.Controls.Add(Me.chkConcept)
        Me.Controls.Add(Me.chkGroup)
        Me.Controls.Add(Me.chkDate)
        Me.Controls.Add(Me.txtConcept)
        Me.Controls.Add(Me.txtID)
        Me.Name = "JournalEntryEditor"
        Me.Size = New System.Drawing.Size(565, 248)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtImport As TextBox
    Friend WithEvents chkImport As CheckBox
    Friend WithEvents chkConcept As CheckBox
    Friend WithEvents chkGroup As CheckBox
    Friend WithEvents chkDate As CheckBox
    Friend WithEvents txtConcept As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblIncomes As ToolStripStatusLabel
    Friend WithEvents lblExpenses As ToolStripStatusLabel
    Friend WithEvents lblBalance As ToolStripStatusLabel
    Friend WithEvents txtEntryDate As TextEditor_Date
    Friend WithEvents ListBox_SubGroup1 As ListBox_SubGroup
    Friend WithEvents ListBox_Deposit1 As ListBox_Deposit
    Friend WithEvents chkDeposit As CheckBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents txtBaseObjectID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbObjTypes As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label2 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents CrearUnTraspàsToolStripMenuItem As ToolStripMenuItem
End Class
