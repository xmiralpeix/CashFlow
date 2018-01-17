Public Class FrmViewerReport




    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim rds = New Microsoft.Reporting.WinForms.ReportDataSource("RptData", RptGroupsRow.LoadData())
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.LocalReport.ReportEmbeddedResource = "CashFlow.RptGroups.rdlc"
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
End Class