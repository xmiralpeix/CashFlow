Imports CashFlow

Public Interface IRequestDataCollection
    Function RequestTransferInfo() As ITransferInfo
End Interface

Friend Class RequestDataCollection
    Implements IRequestDataCollection

    Public Function RequestTransferInfo() As ITransferInfo Implements IRequestDataCollection.RequestTransferInfo

        Dim result As ITransferInfo = Nothing

        Using frm As New FrmTransfer()
            If frm.ShowDialog() = DialogResult.OK Then
                result = frm.GetTransferInfo
            End If
        End Using

        Return result

    End Function

End Class
