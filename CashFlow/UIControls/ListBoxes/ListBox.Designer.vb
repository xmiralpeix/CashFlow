﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListBox
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
        Me.txtDisplay = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtVisualValue = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(132, 3)
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ReadOnly = True
        Me.txtDisplay.Size = New System.Drawing.Size(289, 20)
        Me.txtDisplay.TabIndex = 2
        Me.txtDisplay.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(105, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(17, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "*"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtVisualValue
        '
        Me.txtVisualValue.Location = New System.Drawing.Point(4, 4)
        Me.txtVisualValue.Name = "txtVisualValue"
        Me.txtVisualValue.Size = New System.Drawing.Size(100, 20)
        Me.txtVisualValue.TabIndex = 0
        '
        'ListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtVisualValue)
        Me.Name = "ListBox"
        Me.Size = New System.Drawing.Size(425, 28)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDisplay As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtVisualValue As TextBox
End Class
