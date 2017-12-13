Public Class FrmCompany

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.Hide()

        Using frm As New FrmMain()
            frm.ShowDialog()
        End Using

    End Sub

End Class