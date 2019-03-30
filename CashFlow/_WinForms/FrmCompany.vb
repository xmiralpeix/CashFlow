Public Class FrmCompany

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Me.txtPwd.Text <> "MRB" Then
            MsgBox("Contraseña incorrecta")
            Return
        End If

        Me.Hide()

        Using frm As New FrmMain()
            frm.ShowDialog()
        End Using

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class