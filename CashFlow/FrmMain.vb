Public Class FrmMain



    Private Sub AssentamentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssentamentsToolStripMenuItem1.Click
        Dim frm As New FrmEntries()
        frm.MdiParent = Me
        frm.Show()
        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub
    End Sub

End Class
