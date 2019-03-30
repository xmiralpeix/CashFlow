<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBFilesEditor
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
        Me.gridDocuments = New System.Windows.Forms.DataGridView()
        Me.btnAddFiles = New System.Windows.Forms.Button()
        CType(Me.gridDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridDocuments
        '
        Me.gridDocuments.AllowUserToAddRows = False
        Me.gridDocuments.AllowUserToDeleteRows = False
        Me.gridDocuments.AllowUserToOrderColumns = True
        Me.gridDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDocuments.Location = New System.Drawing.Point(3, 3)
        Me.gridDocuments.Name = "gridDocuments"
        Me.gridDocuments.ReadOnly = True
        Me.gridDocuments.Size = New System.Drawing.Size(298, 233)
        Me.gridDocuments.TabIndex = 11
        '
        'btnAddFiles
        '
        Me.btnAddFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFiles.Location = New System.Drawing.Point(3, 242)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Size = New System.Drawing.Size(112, 23)
        Me.btnAddFiles.TabIndex = 12
        Me.btnAddFiles.Text = "Afegir documents"
        Me.btnAddFiles.UseVisualStyleBackColor = True
        '
        'DBFilesEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAddFiles)
        Me.Controls.Add(Me.gridDocuments)
        Me.Name = "DBFilesEditor"
        Me.Size = New System.Drawing.Size(304, 268)
        CType(Me.gridDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridDocuments As DataGridView
    Friend WithEvents btnAddFiles As Button
End Class
