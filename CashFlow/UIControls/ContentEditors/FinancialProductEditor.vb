Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class FinancialProductEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Productes financers", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.FinancialProducts)
        End Get
    End Property

    Private ReadOnly Property FindBehaviour As IFindBehaviour Implements IEditContent.FindBehaviour
        Get
            Return New EntityIDsFinder(Me)
        End Get
    End Property

    Public ReadOnly Property PrintBehaviour As IPrintBehaviour Implements IEditContent.PrintBehaviour
        Get
            Return New NoPrint()
        End Get
    End Property

    Private _entry As FinancialProduct

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.FinancialProducts.Include(NameOf(FinancialProduct.ProductDeposit)).Include(NameOf(FinancialProduct.Evaluation)).Include(NameOf(FinancialProduct.Deposit)).Include(NameOf(FinancialProduct.BaseDeposit))
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New FinancialProduct()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtName.Text = _entry.Name
            Me.txtComments.Text = _entry.Comments
            Me.teRegistrationDate.AssignValue(_entry.RegistrationDate)
            '
            Me.iBaseDeposit.AssignValue(_entry.BaseDeposit)
            Me.iDeposit.AssignValue(_entry.Deposit)
            Me.iProductDeposit.AssignValue(_entry.ProductDeposit)
            Me.iBaseImport.Text = _entry.BaseImport
            '
            Me.ListBox_Evaluation1.AssignValue(_entry.Evaluation)
            Me.txtResult.Text = _entry.ResultComments
            Me.cbDocStatus.SelectedValue = _entry.Status


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtName.Select()
        End Try

    End Sub

    Private Function AppEvents() As IEnumerable(Of String) Implements IEditContent.AppEvents
        Return {
            NameOf(SearchAppEvent),
            NameOf(NewAppEvent),
            NameOf(FirstAppEvent),
            NameOf(PreviousAppEvent),
            NameOf(NextAppEvent),
            NameOf(LastAppEvent)}

    End Function

    Private Function GetUI() As IContainerControl Implements IEditContent.GetUI

        ' Configure controls
        Me.cbDocStatus.ValueMember = "Code"
        Me.cbDocStatus.DisplayMember = "Name"
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
        Me.cbDocStatus.DataSource = dt


        Return Me

    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtName) Then
            msgError = Locate("El nom del propietari és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        If Not Me.teRegistrationDate.HasValue Then
            msgError = Locate("El camp de data d'alta del producte és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        If Not Me.iDeposit.HasValue Then
            msgError = Locate("El dipòsit és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Name = Me.txtName.Text
        _entry.Comments = Me.txtComments.Text
        _entry.RegistrationDate = Me.teRegistrationDate.Value
        ' tag 2
        If Me.iBaseDeposit.HasValue Then
            _entry.BaseDeposit = ctx.Deposits.Where(Function(x) x.ID = Me.iBaseDeposit.Entity.ID).FirstOrDefault()
        Else
            ctx.Entry(_entry).Reference(NameOf(FinancialProduct.BaseDeposit)).CurrentValue = Nothing
        End If
        _entry.Deposit = ctx.Deposits.Include(NameOf(Deposit.FinancialEntity)).Include(NameOf(Deposit.Owner)).Where(Function(x) x.ID = Me.iDeposit.Entity.ID).FirstOrDefault()
        Try
            _entry.ProductDeposit = ctx.Deposits.Where(Function(x) x.ID = Me.iProductDeposit.Entity.ID).First()
        Catch ex As Exception
            Dim dep As New Deposit()
            dep.FinancialEntity = _entry.Deposit.FinancialEntity
            dep.Owner = _entry.Deposit.Owner
            dep.Name = _entry.Name
            ctx.Deposits.Add(dep)
            _entry.ProductDeposit = dep
        End Try

        _entry.BaseImport = Me.iBaseImport.Text

        If Me.ListBox_Evaluation1.HasValue Then
            _entry.Evaluation = ctx.Evaluations.Where(Function(x) x.ID = Me.ListBox_Evaluation1.Entity.ID).FirstOrDefault()
        Else
            ctx.Entry(_entry).Reference(NameOf(FinancialProduct.Evaluation)).CurrentValue = Nothing
        End If
        '
        _entry.ResultComments = Me.txtResult.Text
        _entry.Status = Me.cbDocStatus.SelectedValue

    End Sub


    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            If _entry.ID <> 0 Then
                ' UPDATE
                _entry = ctx.FinancialProducts.Where(Function(x) x.ID = _entry.ID).FirstOrDefault()
                FillEntry(ctx)
                ctx.SaveChanges()
            Else
                ' ADD
                FillEntry(ctx)
                ctx.FinancialProducts.Add(_entry)
                '
                ctx.SaveChanges()
            End If

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal IDs As IEnumerable(Of Integer)) As Boolean

        msgError = Locate("No es poden eliminar productes financers. Valora la possibilitat d'anul·lar-lo", CAT)
        Return False

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.FinancialProducts.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of FinancialProduct)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oEntity In ctx.FinancialProducts
                                    Select oEntity).ToList()
            Else

                entityCollection = (From oEntity In ctx.FinancialProducts
                                    Where (oEntity.Name).Contains(textSearch)
                                    Select oEntity).ToList()
            End If

        End Using

        Return entityCollection

    End Function

    Public Function GetColumns() As IEnumerable(Of DataGridViewColumn) Implements IFindContent.GetColumns

        Dim col As New List(Of DataGridViewColumn)()
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = "ID"
            .DataPropertyName = NameOf(FinancialProduct.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = NameOf(FinancialProduct.Name)
        End With


        Return col

    End Function

    Private Sub CashFlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashFlowToolStripMenuItem.Click


        Dim oProductDeposit As Deposit

        Dim cashFlowEntryID As Integer

        Using ctx As New CashFlow.CashFlowContext()



            Dim linkedEntity = (From entity In ctx.CashFlowEntries.Include(NameOf(CashFlowEntry.FinancialProduct))
                                Where entity.FinancialProduct.ID = _entry.ID).FirstOrDefault()

            If Not IsEmpty(linkedEntity) Then
                cashFlowEntryID = linkedEntity.ID
            Else

                oProductDeposit = (From entity In ctx.Deposits.Include(NameOf(Deposit.Owner))
                                   Where entity.ID = _entry.Deposit.ID).First

                Dim oCashFlowEntry = New CashFlowEntry()
                oCashFlowEntry.Concept = _entry.Name
                oCashFlowEntry.FromDate = _entry.RegistrationDate
                oCashFlowEntry.Owner = oProductDeposit.Owner
                oCashFlowEntry.FinancialProduct = _entry
                oCashFlowEntry.AssetsImport = _entry.BaseImport
                ctx.CashFlowEntries.Add(oCashFlowEntry)
                ctx.SaveChanges()
                '
                cashFlowEntryID = oCashFlowEntry.ID

            End If

        End Using



        Dim frm As New FrmEdit
        Dim defaultAppEvent As New MoveToIDAppEvent()
        defaultAppEvent.ID = cashFlowEntryID
        frm.DefaultAppEvent = defaultAppEvent
        frm.MdiParent = Me.ParentForm.MdiParent
        frm.Content = New CashFlow.CashFlowEntryEditor()
        frm.Show()

        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub

    End Sub

End Class
