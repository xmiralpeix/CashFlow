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

                    _entry = (From g1 In ctx.FinancialProducts.Include(NameOf(FinancialProduct.Deposit)).Include(NameOf(FinancialProduct.Evaluation)).Include(NameOf(FinancialProduct.SubGroup))
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New FinancialProduct()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtName.Text = _entry.Name
            Me.txtComments.Text = _entry.Comments
            Me.teRegistrationDate.AssignValue(_entry.RegistrationDate)
            Me.ListBox_Deposit1.AssignValue(_entry.Deposit)
            Me.ListBox_SubGroup1.AssignValue(_entry.SubGroup)
            Me.ListBox_Evaluation1.AssignValue(_entry.Evaluation)
            Me.txtResult.Text = _entry.ResultComments


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

        If Not Me.ListBox_Deposit1.HasValue Then
            msgError = Locate("El dipòsit és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        If Not Me.ListBox_SubGroup1.HasValue Then
            msgError = Locate("El subgrup és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Name = Me.txtName.Text
        _entry.Comments = Me.txtComments.Text
        _entry.RegistrationDate = Me.teRegistrationDate.Value
        '
        _entry.Deposit = ctx.Deposits.Where(Function(x) x.ID = Me.ListBox_Deposit1.Entity.ID).FirstOrDefault()
        _entry.SubGroup = ctx.SubGroups.Where(Function(x) x.ID = Me.ListBox_SubGroup1.Entity.ID).FirstOrDefault()
        _entry.Evaluation = ctx.Evaluations.Where(Function(x) x.ID = Me.ListBox_Evaluation1.Entity.ID).FirstOrDefault()
        '
        _entry.ResultComments = Me.txtResult.Text

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


End Class
