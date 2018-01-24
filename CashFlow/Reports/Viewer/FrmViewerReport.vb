Public Class FrmViewerReport


    Public Property PrintableContent As IPrintContent


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(PrintableContent.ReportDataSource)
            ReportViewer1.LocalReport.ReportEmbeddedResource = PrintableContent.ReportEmbeddedResource
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class