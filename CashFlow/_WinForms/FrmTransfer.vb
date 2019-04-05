Imports CashFlow

Public Class FrmTransfer

    Friend Function GetTransferInfo() As ITransferInfo
        Return _transferInfo
    End Function

    Private _transferInfo As ITransferInfo

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        _transferInfo = mSubscribers.CreateInstance(Of ITransferInfo)()
        ' Concept
        If IsEmpty(Me.txtConcept) Then
            Locate("El concepte és una dada obligatòria", CAT)
            Return
        End If
        _transferInfo.Concept = Me.txtConcept.Text
        ' Date
        If IsEmpty(Me.txtEntryDate) Then
            Locate("La data és una dada obligatòria", CAT)
            Return
        End If
        _transferInfo.EntryDate = Me.txtEntryDate.Data.Value
        ' From deposit
        If IsEmpty(Me.lbFromDeposit) Then
            Locate("El dipòsit d'orígen és una dada obligatòria", CAT)
            Return
        End If
        _transferInfo.FromDeposit = lbFromDeposit.Data.Value
        '
        If IsEmpty(Me.lbToDeposit) Then
            Locate("El dipòsit de destí és una dada obligatòria", CAT)
            Return
        End If
        _transferInfo.ToDeposit = lbToDeposit.Data.Value
        '
        If IsEmpty(Me.txtImport) Then
            Locate("L'import és una dada obligatòria", CAT)
            Return
        End If
        _transferInfo.Import = Me.txtImport.Text
        '
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class