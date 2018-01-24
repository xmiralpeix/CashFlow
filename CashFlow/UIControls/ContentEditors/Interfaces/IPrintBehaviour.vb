Imports System.Globalization
Imports CashFlow

Public Interface IPrintBehaviour
    Sub Print(ByVal FromID As Integer,
              ByVal ToID As Integer,
              ByVal culture As System.Globalization.CultureInfo)
End Interface

Public Class NoPrint
    Implements IPrintBehaviour

    Public Sub Print(FromID As Integer, ToID As Integer, culture As CultureInfo) Implements IPrintBehaviour.Print
        ' NO print
    End Sub

End Class


Public Class EntityIDsPrinter
    Implements IPrintBehaviour

    Private _printContent As IPrintContent
    Public Sub New(ByVal printContent As IPrintContent)
        _printContent = printContent
    End Sub

    Public Sub Print(FromID As Integer,
                     ToID As Integer,
                     Culture As CultureInfo) Implements IPrintBehaviour.Print

        Using frm As New FrmViewerReport()
            _printContent.Culture = Culture
            _printContent.SetIDRange(FromID, ToID)
            frm.PrintableContent = _printContent
            frm.ShowDialog()
        End Using

    End Sub

End Class
