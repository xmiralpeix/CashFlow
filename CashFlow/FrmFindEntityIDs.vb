Public Class FrmFindEntityIDs

    Public Property FindContent As IFindContent

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If SelectedIDs.Any Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox(Locate("Primer cal seleccionar un registre del grid.", CAT))
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private _colIDIdx As Integer
    Public Sub LoadData()

        Me.grid.DataSource = FindContent.GetContent(Me.txtSearch.Text)
        '
        Me.grid.Columns.Clear()
        Me.grid.Columns.AddRange(FindContent.GetColumns().ToArray())
        Try
            _colIDIdx = (From col As DataGridViewColumn In Me.grid.Columns
                         Where col.DataPropertyName = "ID").First().Index
        Catch ex As Exception
            Throw New Exception("Column ID it's necessary column")
        End Try

        '
        Me.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grid.ReadOnly = True

    End Sub


    Public ReadOnly Property SelectedIDs() As IEnumerable(Of Integer)
        Get

            Dim qry = From row As DataGridViewRow In Me.grid.SelectedRows
                      Select CInt(row.Cells(_colIDIdx).Value)

            Return qry.ToArray()

        End Get
    End Property

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            LoadData()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmFindEntityIDs_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim qty As Integer = FindContent.GetQuantity()
        If qty < 101 Then
            LoadData()
        End If

    End Sub

    Private Sub grid_DoubleClick(sender As Object, e As EventArgs) Handles grid.DoubleClick
        btnOK.PerformClick()
    End Sub

End Class


