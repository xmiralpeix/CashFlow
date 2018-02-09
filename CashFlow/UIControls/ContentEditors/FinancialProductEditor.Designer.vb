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
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.teRegistrationDate = New CashFlow.TextEditor_Date()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.ListBox_Evaluation1 = New CashFlow.ListBox_Evaluation()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Page1 = New System.Windows.Forms.TabPage()
        Me.ListBox_Deposit1 = New CashFlow.ListBox_Deposit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Page2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.Page1.SuspendLayout()
        Me.Page2.SuspendLayout()
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
        Me.Label4.Location = New System.Drawing.Point(10, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Comentaris"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(106, 124)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(332, 135)
        Me.txtComments.TabIndex = 41
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
        'teRegistrationDate
        '
        Me.teRegistrationDate.Location = New System.Drawing.Point(106, 67)
        Me.teRegistrationDate.Name = "teRegistrationDate"
        Me.teRegistrationDate.Size = New System.Drawing.Size(100, 24)
        Me.teRegistrationDate.TabIndex = 39
        Me.teRegistrationDate.Value = Nothing
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
        Me.txtID.TabIndex = 35
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(106, 41)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(332, 20)
        Me.txtName.TabIndex = 34
        '
        'ListBox_Evaluation1
        '
        Me.ListBox_Evaluation1.Location = New System.Drawing.Point(102, 12)
        Me.ListBox_Evaluation1.Name = "ListBox_Evaluation1"
        Me.ListBox_Evaluation1.Size = New System.Drawing.Size(332, 21)
        Me.ListBox_Evaluation1.TabIndex = 45
        Me.ListBox_Evaluation1.Value = Nothing
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
        Me.TabControl1.Controls.Add(Me.Page1)
        Me.TabControl1.Controls.Add(Me.Page2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(788, 291)
        Me.TabControl1.TabIndex = 17
        '
        'Page1
        '
        Me.Page1.Controls.Add(Me.ListBox_Deposit1)
        Me.Page1.Controls.Add(Me.Label7)
        Me.Page1.Controls.Add(Me.Label4)
        Me.Page1.Controls.Add(Me.txtID)
        Me.Page1.Controls.Add(Me.txtComments)
        Me.Page1.Controls.Add(Me.txtName)
        Me.Page1.Controls.Add(Me.Label2)
        Me.Page1.Controls.Add(Me.Label1)
        Me.Page1.Controls.Add(Me.teRegistrationDate)
        Me.Page1.Controls.Add(Me.Label3)
        Me.Page1.Location = New System.Drawing.Point(4, 22)
        Me.Page1.Name = "Page1"
        Me.Page1.Padding = New System.Windows.Forms.Padding(3)
        Me.Page1.Size = New System.Drawing.Size(780, 265)
        Me.Page1.TabIndex = 0
        Me.Page1.Text = "General"
        Me.Page1.UseVisualStyleBackColor = True
        '
        'ListBox_Deposit1
        '
        Me.ListBox_Deposit1.Location = New System.Drawing.Point(106, 97)
        Me.ListBox_Deposit1.Name = "ListBox_Deposit1"
        Me.ListBox_Deposit1.Size = New System.Drawing.Size(332, 21)
        Me.ListBox_Deposit1.TabIndex = 44
        Me.ListBox_Deposit1.Value = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Dipòsit"
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.Label6)
        Me.Page2.Controls.Add(Me.Label5)
        Me.Page2.Controls.Add(Me.ListBox_Evaluation1)
        Me.Page2.Controls.Add(Me.txtResult)
        Me.Page2.Location = New System.Drawing.Point(4, 22)
        Me.Page2.Name = "Page2"
        Me.Page2.Padding = New System.Windows.Forms.Padding(3)
        Me.Page2.Size = New System.Drawing.Size(780, 265)
        Me.Page2.TabIndex = 1
        Me.Page2.Text = "Valoració"
        Me.Page2.UseVisualStyleBackColor = True
        '
        'FinancialProductEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FinancialProductEditor"
        Me.Size = New System.Drawing.Size(788, 291)
        Me.TabControl1.ResumeLayout(False)
        Me.Page1.ResumeLayout(False)
        Me.Page1.PerformLayout()
        Me.Page2.ResumeLayout(False)
        Me.Page2.PerformLayout()
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
    Friend WithEvents Page1 As TabPage
    Friend WithEvents Page2 As TabPage
    Friend WithEvents ListBox_Deposit1 As ListBox_Deposit
    Friend WithEvents Label7 As Label
End Class
