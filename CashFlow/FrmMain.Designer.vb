<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.statusbar = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PrimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssentamentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropietarisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinancesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntitatsFinanceresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductesFinancersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssentamentsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracióToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParàmetresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.statusbar.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusbar
        '
        Me.statusbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusbar.Location = New System.Drawing.Point(0, 471)
        Me.statusbar.Name = "statusbar"
        Me.statusbar.Size = New System.Drawing.Size(802, 22)
        Me.statusbar.TabIndex = 3
        Me.statusbar.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrimerToolStripMenuItem, Me.DadesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(802, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PrimerToolStripMenuItem
        '
        Me.PrimerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssentamentsToolStripMenuItem, Me.FinancesToolStripMenuItem, Me.ConfiguracióToolStripMenuItem1})
        Me.PrimerToolStripMenuItem.Name = "PrimerToolStripMenuItem"
        Me.PrimerToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.PrimerToolStripMenuItem.Text = "Menú"
        '
        'AssentamentsToolStripMenuItem
        '
        Me.AssentamentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrupsToolStripMenuItem, Me.PropietarisToolStripMenuItem})
        Me.AssentamentsToolStripMenuItem.Name = "AssentamentsToolStripMenuItem"
        Me.AssentamentsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AssentamentsToolStripMenuItem.Text = "Definicions"
        '
        'GrupsToolStripMenuItem
        '
        Me.GrupsToolStripMenuItem.Name = "GrupsToolStripMenuItem"
        Me.GrupsToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.GrupsToolStripMenuItem.Text = "Grups"
        '
        'PropietarisToolStripMenuItem
        '
        Me.PropietarisToolStripMenuItem.Name = "PropietarisToolStripMenuItem"
        Me.PropietarisToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.PropietarisToolStripMenuItem.Text = "Propietaris"
        '
        'FinancesToolStripMenuItem
        '
        Me.FinancesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntitatsFinanceresToolStripMenuItem, Me.ProductesFinancersToolStripMenuItem, Me.AssentamentsToolStripMenuItem1})
        Me.FinancesToolStripMenuItem.Name = "FinancesToolStripMenuItem"
        Me.FinancesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.FinancesToolStripMenuItem.Text = "Finances"
        '
        'EntitatsFinanceresToolStripMenuItem
        '
        Me.EntitatsFinanceresToolStripMenuItem.Name = "EntitatsFinanceresToolStripMenuItem"
        Me.EntitatsFinanceresToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EntitatsFinanceresToolStripMenuItem.Text = "Entitats financeres"
        '
        'ProductesFinancersToolStripMenuItem
        '
        Me.ProductesFinancersToolStripMenuItem.Name = "ProductesFinancersToolStripMenuItem"
        Me.ProductesFinancersToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ProductesFinancersToolStripMenuItem.Text = "Productes financers"
        '
        'AssentamentsToolStripMenuItem1
        '
        Me.AssentamentsToolStripMenuItem1.Name = "AssentamentsToolStripMenuItem1"
        Me.AssentamentsToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.AssentamentsToolStripMenuItem1.Text = "Assentaments"
        '
        'ConfiguracióToolStripMenuItem1
        '
        Me.ConfiguracióToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParàmetresToolStripMenuItem})
        Me.ConfiguracióToolStripMenuItem1.Name = "ConfiguracióToolStripMenuItem1"
        Me.ConfiguracióToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.ConfiguracióToolStripMenuItem1.Text = "Configuració"
        '
        'ParàmetresToolStripMenuItem
        '
        Me.ParàmetresToolStripMenuItem.Name = "ParàmetresToolStripMenuItem"
        Me.ParàmetresToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ParàmetresToolStripMenuItem.Text = "Paràmetres"
        '
        'DadesToolStripMenuItem
        '
        Me.DadesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.DadesToolStripMenuItem.Name = "DadesToolStripMenuItem"
        Me.DadesToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.DadesToolStripMenuItem.Text = "Dades"
        '
        'DuplicarToolStripMenuItem
        '
        Me.DuplicarToolStripMenuItem.Name = "DuplicarToolStripMenuItem"
        Me.DuplicarToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DuplicarToolStripMenuItem.Text = "Duplicar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.ToolStripButton7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(802, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton5.Text = "Buscar"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton6.Text = "Nou"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton1.Text = "Primer"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripButton2.Text = "Anterior"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripButton3.Text = "Següent"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton4.Text = "Últim"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripButton7.Text = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 493)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.statusbar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CashFlow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusbar.ResumeLayout(False)
        Me.statusbar.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents statusbar As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PrimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DadesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents AssentamentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrupsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropietarisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinancesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntitatsFinanceresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductesFinancersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssentamentsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConfiguracióToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ParàmetresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton7 As ToolStripButton
End Class
