Imports System.Globalization
Imports Microsoft.Reporting.WinForms

Public Interface IPrintContent
    Function ReportDataSource() As ReportDataSource
    ReadOnly Property ReportEmbeddedResource As String
    Property Culture As CultureInfo
    Sub SetIDRange(FromID As Integer, ToID As Integer)
End Interface
