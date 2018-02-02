<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DepositEditor
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkIsCash = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.ListBox_Owner1 = New CashFlow.ListBox_Owner()
        Me.ListBox_FinancialEntity1 = New CashFlow.ListBox_FinancialEntity()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ListBox_Owner1)
        Me.GroupBox1.Controls.Add(Me.ListBox_FinancialEntity1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkIsCash)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(537, 174)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dades"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Propietari"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Entitat Financera"
        '
        'chkIsCash
        '
        Me.chkIsCash.AutoSize = True
        Me.chkIsCash.Location = New System.Drawing.Point(14, 138)
        Me.chkIsCash.Name = "chkIsCash"
        Me.chkIsCash.Size = New System.Drawing.Size(59, 17)
        Me.chkIsCash.TabIndex = 39
        Me.chkIsCash.Text = "Efectiu"
        Me.chkIsCash.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Nom"
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
        Me.txtID.TabIndex = 35
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(104, 51)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(297, 20)
        Me.txtName.TabIndex = 34
        '
        'ListBox_Owner1
        '
        Me.ListBox_Owner1.Location = New System.Drawing.Point(104, 102)
        Me.ListBox_Owner1.Name = "ListBox_Owner1"
        Me.ListBox_Owner1.Size = New System.Drawing.Size(297, 21)
        Me.ListBox_Owner1.TabIndex = 47
        Me.ListBox_Owner1.Value = Nothing
        '
        'ListBox_FinancialEntity1
        '
        Me.ListBox_FinancialEntity1.Location = New System.Drawing.Point(104, 77)
        Me.ListBox_FinancialEntity1.Name = "ListBox_FinancialEntity1"
        Me.ListBox_FinancialEntity1.Size = New System.Drawing.Size(297, 22)
        Me.ListBox_FinancialEntity1.TabIndex = 46
        Me.ListBox_FinancialEntity1.Value = Nothing
        '
        'DepositEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DepositEditor"
        Me.Size = New System.Drawing.Size(543, 204)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents chkIsCash As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox_FinancialEntity1 As ListBox_FinancialEntity
    Friend WithEvents ListBox_Owner1 As ListBox_Owner
End Class
