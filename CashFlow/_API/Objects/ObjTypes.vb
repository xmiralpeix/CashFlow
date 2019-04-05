Public Class ObjTypes

    Public Shared Sub ConfigureCombo(ByRef cbDocStatus As ComboBox)

        cbDocStatus.ValueMember = "Code"
        cbDocStatus.DisplayMember = "Name"
        '
        Dim dt As New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        '
        dt.Rows.Add(NameOf(IsEmpty), Locate("", CAT))
        dt.Rows.Add(NameOf(FinancialProduct), Locate("Producte financer", CAT))
        dt.Rows.Add(NameOf(IJournalEntry), Locate("Moviment financer", CAT))
        dt.Rows.Add(NameOf(PurchaseInvoice), Locate("Factura rebuda", CAT))
        '
        cbDocStatus.DataSource = dt

    End Sub

End Class
