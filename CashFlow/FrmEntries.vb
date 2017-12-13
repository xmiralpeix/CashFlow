Public Class FrmEntries

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Try
            CreateTestGroup()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


    Private Sub CreateTestGroup()

        Using ctx As New CashFlowContext()
            Dim g As [Group] = New [Group]()
            g.Name = "test"
            ctx.Groups.Add(g)
            ctx.SaveChanges()
        End Using

    End Sub
End Class