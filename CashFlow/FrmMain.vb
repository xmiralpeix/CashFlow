Imports CashFlow

Public Class FrmMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ApplicationEvents.RegisterEvents(Me.NavigateToolStrip1)
        ApplicationEvents.RegisterEvents(Me.DadesToolStripMenuItem)

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

End Class
