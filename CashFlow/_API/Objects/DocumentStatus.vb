Public Class DocumentStatus

    Public Enum Status
        Open = 0
        Close = 1
        Cancelled = 2
        Pending = 3
    End Enum


    Public Shared Sub ConfigureCombo(ByRef cbDocStatus As ComboBox)

        cbDocStatus.ValueMember = "Code"
        cbDocStatus.DisplayMember = "Name"
        '
        Dim dt As New DataTable()
        dt.Columns.Add("Code", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        '
        dt.Rows.Add(CInt(Status.Pending), Locate("Pendent", CAT))
        dt.Rows.Add(CInt(Status.Open), Locate("Obert", CAT))
        dt.Rows.Add(CInt(Status.Close), Locate("Tancat", CAT))
        dt.Rows.Add(CInt(Status.Cancelled), Locate("Cancel·lat", CAT))
        '
        cbDocStatus.DataSource = dt

    End Sub

End Class
