Imports CashFlow

Public Class NavigateToolStrip
    Inherits ToolStrip
    Implements INavigateMenu

    Public Sub New()
        MyBase.New()
        '
        ConfigureControls()
    End Sub


    Public WithEvents menuSearch As New ToolStripButton()
    Public WithEvents menuNewObject As New ToolStripButton()
    Public WithEvents menuFirstObject As New ToolStripButton()
    Public WithEvents menuPreviousObject As New ToolStripButton()
    Public WithEvents menuNextObject As New ToolStripButton()
    Public WithEvents menuLastObject As New ToolStripButton()
    Public WithEvents menuPrint As New ToolStripButton()
    Public WithEvents menuImportExport As New ToolStripButton()

    Public Sub ConfigureControls()

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))

        '
        'menuSearch
        '
        Me.menuSearch.Image = CType(Resources.GetObject("menuSearch.Image"), System.Drawing.Image)
        Me.menuSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuSearch.Name = NameOf(menuSearch)
        Me.menuSearch.Size = New System.Drawing.Size(62, 22)
        Me.menuSearch.Text = "Buscar" ' TODO Translate
        '
        AddHandler Me.menuSearch.Click, Sub() RaiseEvent SearchObject()

        '
        'menuSearch
        '
        Me.menuNewObject.Image = CType(resources.GetObject("menuNewObject.Image"), System.Drawing.Image)
        Me.menuNewObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuNewObject.Name = NameOf(menuNewObject)
        Me.menuNewObject.Size = New System.Drawing.Size(62, 22)
        Me.menuNewObject.Text = "Nou" ' TODO Translate
        '
        AddHandler Me.menuNewObject.Click, Sub() RaiseEvent NewObject()

        '
        'menuFirstObject
        '
        Me.menuFirstObject.Image = CType(resources.GetObject("menuFirstObject.Image"), System.Drawing.Image)
        Me.menuFirstObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuFirstObject.Name = NameOf(menuFirstObject)
        Me.menuFirstObject.Size = New System.Drawing.Size(62, 22)
        Me.menuFirstObject.Text = "Primer" ' TODO Translate
        '
        AddHandler Me.menuFirstObject.Click, Sub() RaiseEvent FirstObject()

        '
        'menupreviousObject
        '
        Me.menuPreviousObject.Image = CType(resources.GetObject("menuPreviousObject.Image"), System.Drawing.Image)
        Me.menuPreviousObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuPreviousObject.Name = NameOf(menuPreviousObject)
        Me.menuPreviousObject.Size = New System.Drawing.Size(62, 22)
        Me.menuPreviousObject.Text = "Anterior" ' TODO Translate
        '
        AddHandler Me.menuPreviousObject.Click, Sub() RaiseEvent PreviousObject()

        '
        'menunextObject
        '
        Me.menuNextObject.Image = CType(resources.GetObject("menuNextObject.Image"), System.Drawing.Image)
        Me.menuNextObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuNextObject.Name = NameOf(menuNextObject)
        Me.menuNextObject.Size = New System.Drawing.Size(62, 22)
        Me.menuNextObject.Text = "Següent" ' TODO Translate
        '
        AddHandler Me.menuNextObject.Click, Sub() RaiseEvent NextObject()

        '
        'menulastObject
        '
        Me.menuLastObject.Image = CType(resources.GetObject("menuLastObject.Image"), System.Drawing.Image)
        Me.menuLastObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuLastObject.Name = NameOf(menuLastObject)
        Me.menuLastObject.Size = New System.Drawing.Size(62, 22)
        Me.menuLastObject.Text = "Últim" ' TODO Translate
        '
        AddHandler Me.menuLastObject.Click, Sub() RaiseEvent LastObject()

        '
        'menuprintObject
        '
        Me.menuPrint.Image = CType(resources.GetObject("menuPrint.Image"), System.Drawing.Image)
        Me.menuPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuPrint.Name = NameOf(menuPrint)
        Me.menuPrint.Size = New System.Drawing.Size(62, 22)
        Me.menuPrint.Text = "Imprimir" ' TODO Translate
        '
        AddHandler Me.menuPrint.Click, Sub() RaiseEvent Print()

        '
        'menuImportExport
        '
        Me.menuImportExport.Image = CType(resources.GetObject("menuImportExport.Image"), System.Drawing.Image)
        Me.menuImportExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuImportExport.Name = NameOf(menuPrint)
        Me.menuImportExport.Size = New System.Drawing.Size(62, 22)
        Me.menuImportExport.Text = Locate("Importar/Exportar", CAT)
        '
        AddHandler Me.menuImportExport.Click, Sub() RaiseEvent ImportExport()


        '
        Me.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSearch,
                                                                    Me.menuNewObject,
                                                                    New ToolStripSeparator(),
                                                                    Me.menuFirstObject,
                                                                    Me.menuPreviousObject,
                                                                    Me.menuNextObject,
                                                                    Me.menuLastObject,
                                                                    New ToolStripSeparator(),
                                                                    Me.menuPrint(),
                                                                    Me.menuImportExport})
        DisableAll()

    End Sub

    Public Sub PerformAvailable(ParamArray appEventNames() As String) Implements INavigateMenu.PerformAvailable

        DisableAll()
        '
        For Each appEventName In appEventNames
            Select Case appEventName
                Case NameOf(INavigateMenu.SearchObject) : menuSearch.Enabled = True
                Case NameOf(INavigateMenu.NewObject) : menuNewObject.Enabled = True
                Case NameOf(INavigateMenu.FirstObject) : menuFirstObject.Enabled = True
                Case NameOf(INavigateMenu.PreviousObject) : menuPreviousObject.Enabled = True
                Case NameOf(INavigateMenu.NextObject) : menuNextObject.Enabled = True
                Case NameOf(INavigateMenu.LastObject) : menuLastObject.Enabled = True
                Case NameOf(INavigateMenu.Print) : menuPrint.Enabled = True
                Case NameOf(INavigateMenu.ImportExport) : menuImportExport.Enabled = True
            End Select
        Next

    End Sub

    Private _toolStripButtonItems = From item In Me.Items
                                    Where item.GetType Is GetType(ToolStripButton)

    Public Sub DisableAll() Implements INavigateMenu.DisableAll

        For Each item As ToolStripButton In _toolStripButtonItems
            item.Enabled = False
        Next

    End Sub


    Public Event SearchObject() Implements INavigateMenu.SearchObject
    Public Event NewObject() Implements INavigateMenu.NewObject
    Public Event FirstObject() Implements INavigateMenu.FirstObject
    Public Event PreviousObject() Implements INavigateMenu.PreviousObject
    Public Event NextObject() Implements INavigateMenu.NextObject
    Public Event LastObject() Implements INavigateMenu.LastObject
    Public Event Print() Implements INavigateMenu.Print
    Public Event ImportExport() Implements INavigateMenu.ImportExport

End Class
