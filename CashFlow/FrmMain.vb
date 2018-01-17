Imports CashFlow

Public Class FrmMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ApplicationEvents.RegisterEvents(Me.NavigateToolStrip1)

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

    End Sub
End Class
