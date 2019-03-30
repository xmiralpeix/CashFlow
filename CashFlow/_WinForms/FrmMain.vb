Imports CashFlow

Public Class FrmMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ApplicationEvents.RegisterEvents(Me.NavigateToolStrip1)
        'ApplicationEvents.RegisterEvents(Me.DadesToolStripMenuItem)
        'DataEvent.RegisterEvents(AccionsToolStripMenuItem)
        '
        CashFlow.Group.AddDefaults()

        Dim extAppCollection As List(Of ExternalApplication)
        Using ctx As New CashFlow.CashFlowContext()
            extAppCollection = (From oEntity In ctx.ExternalApplications
                                Select oEntity).ToList()
        End Using


        For Each oEntity In extAppCollection

            Try
                Dim nodes() As String = oEntity.ParentMenuID.Split(">")
                Dim findMenuItem = Function(nodeIdx As Integer, itemCollection As ToolStripItemCollection) As ToolStripMenuItem
                                       Try
                                           Return (From itemIdx As ToolStripItem In itemCollection
                                                   Where String.Compare(itemIdx.Text, nodes(nodeIdx), True) = 0).FirstOrDefault()
                                       Catch ex As Exception
                                           Return Nothing
                                       End Try
                                   End Function

                Dim currentMenu As ToolStripMenuItem = findMenuItem(0, Me.ApplicationMenu.Items)
                For idx As Integer = 1 To nodes.Count - 1
                    currentMenu = findMenuItem(idx, currentMenu.dropdownitems)
                Next

                Dim x As New ToolStripMenuItem()
                x.Name = oEntity.Name
                x.Text = oEntity.Name
                x.Tag = oEntity.ApplicationPath
                '
                AddHandler x.Click, Sub(sender As Object, e As EventArgs)
                                        Try
                                            Dim menu As ToolStripMenuItem = sender
                                            System.Diagnostics.Process.Start(menu.Tag)
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                    End Sub

                currentMenu.DropDownItems.Add(x)

            Catch ex As Exception

            End Try

        Next

    End Sub

    Public Sub OpenApplication()

    End Sub


    Private Sub AssentamentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssentamentsToolStripMenuItem1.Click

        Dim frm As New FrmEdit()
        frm.MdiParent = Me
        frm.Content = New JournalEntryEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub

    End Sub

    Private Sub GrupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrupsToolStripMenuItem.Click

        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New GroupEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub EntitatsFinanceresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntitatsFinanceresToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New FinancialEntityEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub PropietarisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropietarisToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New OwnerEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub ProductesFinancersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductesFinancersToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New FinancialProductEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub DipòsitsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DipòsitsToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New DepositEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub ValoraciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValoraciosToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New EvaluationEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub InformesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InformesToolStripMenuItem1.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New ExternalApplicationEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

    Private Sub FacturesDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturesDeCompraToolStripMenuItem.Click
        Dim frm As New FrmEdit
        frm.MdiParent = Me
        frm.Content = New PurchaseInvoiceEditor()
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

End Class
