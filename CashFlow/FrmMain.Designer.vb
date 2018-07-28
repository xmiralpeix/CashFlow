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
        Me.statusbar = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PrimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssentamentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropietarisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValoraciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinancesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntitatsFinanceresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DipòsitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductesFinancersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssentamentsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracióToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParàmetresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplicationMenu = New System.Windows.Forms.MenuStrip()
        Me.DadesToolStripMenuItem = New CashFlow.ActionsMenuStrip()
        Me.NavigateToolStrip1 = New CashFlow.NavigateToolStrip()
        Me.CompresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusbar.SuspendLayout()
        Me.ApplicationMenu.SuspendLayout()
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
        'PrimerToolStripMenuItem
        '
        Me.PrimerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssentamentsToolStripMenuItem, Me.FinancesToolStripMenuItem, Me.ConfiguracióToolStripMenuItem1, Me.CompresToolStripMenuItem})
        Me.PrimerToolStripMenuItem.Name = "PrimerToolStripMenuItem"
        Me.PrimerToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.PrimerToolStripMenuItem.Text = "Menú"
        '
        'AssentamentsToolStripMenuItem
        '
        Me.AssentamentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrupsToolStripMenuItem, Me.PropietarisToolStripMenuItem, Me.ValoraciosToolStripMenuItem, Me.InformesToolStripMenuItem1})
        Me.AssentamentsToolStripMenuItem.Name = "AssentamentsToolStripMenuItem"
        Me.AssentamentsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AssentamentsToolStripMenuItem.Text = "Definicions"
        '
        'GrupsToolStripMenuItem
        '
        Me.GrupsToolStripMenuItem.Name = "GrupsToolStripMenuItem"
        Me.GrupsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.GrupsToolStripMenuItem.Text = "Grups"
        '
        'PropietarisToolStripMenuItem
        '
        Me.PropietarisToolStripMenuItem.Name = "PropietarisToolStripMenuItem"
        Me.PropietarisToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.PropietarisToolStripMenuItem.Text = "Propietaris"
        '
        'ValoraciosToolStripMenuItem
        '
        Me.ValoraciosToolStripMenuItem.Name = "ValoraciosToolStripMenuItem"
        Me.ValoraciosToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ValoraciosToolStripMenuItem.Text = "Valoracions"
        '
        'InformesToolStripMenuItem1
        '
        Me.InformesToolStripMenuItem1.Name = "InformesToolStripMenuItem1"
        Me.InformesToolStripMenuItem1.Size = New System.Drawing.Size(134, 22)
        Me.InformesToolStripMenuItem1.Text = "Informes"
        '
        'FinancesToolStripMenuItem
        '
        Me.FinancesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntitatsFinanceresToolStripMenuItem, Me.DipòsitsToolStripMenuItem, Me.ProductesFinancersToolStripMenuItem, Me.AssentamentsToolStripMenuItem1, Me.InformesToolStripMenuItem})
        Me.FinancesToolStripMenuItem.Name = "FinancesToolStripMenuItem"
        Me.FinancesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FinancesToolStripMenuItem.Text = "Finances"
        '
        'EntitatsFinanceresToolStripMenuItem
        '
        Me.EntitatsFinanceresToolStripMenuItem.Name = "EntitatsFinanceresToolStripMenuItem"
        Me.EntitatsFinanceresToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.EntitatsFinanceresToolStripMenuItem.Text = "Entitats financeres"
        '
        'DipòsitsToolStripMenuItem
        '
        Me.DipòsitsToolStripMenuItem.Name = "DipòsitsToolStripMenuItem"
        Me.DipòsitsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.DipòsitsToolStripMenuItem.Text = "Dipòsits"
        '
        'ProductesFinancersToolStripMenuItem
        '
        Me.ProductesFinancersToolStripMenuItem.Name = "ProductesFinancersToolStripMenuItem"
        Me.ProductesFinancersToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ProductesFinancersToolStripMenuItem.Text = "Productes financers"
        '
        'AssentamentsToolStripMenuItem1
        '
        Me.AssentamentsToolStripMenuItem1.Name = "AssentamentsToolStripMenuItem1"
        Me.AssentamentsToolStripMenuItem1.Size = New System.Drawing.Size(185, 22)
        Me.AssentamentsToolStripMenuItem1.Text = "Moviments financers"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.InformesToolStripMenuItem.Text = "Informes financers"
        '
        'ConfiguracióToolStripMenuItem1
        '
        Me.ConfiguracióToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParàmetresToolStripMenuItem})
        Me.ConfiguracióToolStripMenuItem1.Name = "ConfiguracióToolStripMenuItem1"
        Me.ConfiguracióToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ConfiguracióToolStripMenuItem1.Text = "Configuració"
        '
        'ParàmetresToolStripMenuItem
        '
        Me.ParàmetresToolStripMenuItem.Name = "ParàmetresToolStripMenuItem"
        Me.ParàmetresToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ParàmetresToolStripMenuItem.Text = "Paràmetres"
        '
        'ApplicationMenu
        '
        Me.ApplicationMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrimerToolStripMenuItem, Me.DadesToolStripMenuItem})
        Me.ApplicationMenu.Location = New System.Drawing.Point(0, 0)
        Me.ApplicationMenu.Name = "ApplicationMenu"
        Me.ApplicationMenu.Size = New System.Drawing.Size(802, 24)
        Me.ApplicationMenu.TabIndex = 5
        Me.ApplicationMenu.Text = "ApplicationMenu"
        '
        'DadesToolStripMenuItem
        '
        Me.DadesToolStripMenuItem.Name = "DadesToolStripMenuItem"
        Me.DadesToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.DadesToolStripMenuItem.Text = "Dades"
        '
        'NavigateToolStrip1
        '
        Me.NavigateToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.NavigateToolStrip1.Name = "NavigateToolStrip1"
        Me.NavigateToolStrip1.Size = New System.Drawing.Size(802, 25)
        Me.NavigateToolStrip1.TabIndex = 8
        Me.NavigateToolStrip1.Text = "NavigateToolStrip1"
        '
        'CompresToolStripMenuItem
        '
        Me.CompresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturesDeCompraToolStripMenuItem})
        Me.CompresToolStripMenuItem.Name = "CompresToolStripMenuItem"
        Me.CompresToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CompresToolStripMenuItem.Text = "Compres"
        '
        'FacturesDeCompraToolStripMenuItem
        '
        Me.FacturesDeCompraToolStripMenuItem.Name = "FacturesDeCompraToolStripMenuItem"
        Me.FacturesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.FacturesDeCompraToolStripMenuItem.Text = "Factures de compra"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 493)
        Me.Controls.Add(Me.NavigateToolStrip1)
        Me.Controls.Add(Me.statusbar)
        Me.Controls.Add(Me.ApplicationMenu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.ApplicationMenu
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CashFlow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusbar.ResumeLayout(False)
        Me.statusbar.PerformLayout()
        Me.ApplicationMenu.ResumeLayout(False)
        Me.ApplicationMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents statusbar As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents PrimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssentamentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrupsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropietarisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinancesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntitatsFinanceresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductesFinancersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssentamentsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConfiguracióToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ParàmetresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DadesToolStripMenuItem As ActionsMenuStrip
    Friend WithEvents ApplicationMenu As MenuStrip
    Friend WithEvents NavigateToolStrip1 As NavigateToolStrip
    Friend WithEvents DipòsitsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValoraciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturesDeCompraToolStripMenuItem As ToolStripMenuItem
End Class
