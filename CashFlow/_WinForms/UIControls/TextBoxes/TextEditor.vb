Public Class TextEditor

    Public Data As ITextBoxData

    Public Function HasValue() As Boolean
        Try
            Return Not mUtils.IsEmpty(Data.Value)
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub txtEditor_Leave(sender As Object, e As EventArgs) Handles txtEditor.Leave

        Data.AssignValue(Me.txtEditor.Text)

    End Sub

    Public Sub LoadData()

        Me.txtEditor.Clear()
        Try
            Me.txtEditor.Text = Data.VisualText
        Catch ex As Exception
            Me.txtEditor.Clear()
        End Try

    End Sub

End Class
