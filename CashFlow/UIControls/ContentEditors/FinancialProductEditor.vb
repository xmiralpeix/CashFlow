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

    Public Property EntitiesScopeCollection As IEnumerable(Of Object) Implements IFindContent.EntitiesScopeCollection

    Private _entry As FinancialProduct

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.FinancialProducts.Include(NameOf(FinancialProduct.Owner)).Include(NameOf(FinancialProduct.ProductDeposit)).Include(NameOf(FinancialProduct.Evaluation)).Include(NameOf(FinancialProduct.Deposit)).Include(NameOf(FinancialProduct.BaseDeposit))
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New FinancialProduct()
            End If

            Me.txtID.Text = _entry.ID

            Dim AssignScopes = Sub()
                                   Dim oOwner = Me.iOwner.Entity
                                   Me.iBaseDeposit.EntitiesScopeCollection = {oOwner}
                                   Me.iDeposit.EntitiesScopeCollection = {oOwner}
                                   Me.iProductDeposit.EntitiesScopeCollection = {oOwner}
                                   '
                                   Me.DbFilesEditor1.ObjectTable = Me.Table
                                   Me.DbFilesEditor1.ObjectID = _entry.ID
                               End Sub
            Me.iOwner.AssignValue(_entry.Owner)
            AddHandler Me.iOwner.OnEntityChanged, AssignScopes
            iOwner.Enabled = Not iOwner.HasValue
            Me.txtName.Text = _entry.Name
            Me.txtComments.Text = _entry.Comments
            Me.teRegistrationDate.AssignValue(_entry.RegistrationDate)
            '
            ' Deposits
            Me.iBaseDeposit.AssignValue(_entry.BaseDeposit)
            iBaseDeposit.Enabled = Not iBaseDeposit.HasValue
            '
            Me.iDeposit.AssignValue(_entry.Deposit)
            iDeposit.Enabled = Not iDeposit.HasValue
            '
            Me.iProductDeposit.AssignValue(_entry.ProductDeposit)
            Me.chkManualProductDeposit.Enabled = Not iProductDeposit.HasValue
            Me.iProductDeposit.Enabled = Me.chkManualProductDeposit.Checked AndAlso Me.chkManualProductDeposit.Enabled

            '
            AssignScopes()
            '
            ' Import
            Me.iBaseImport.Text = _entry.BaseImport
            '
            ' Evaluation
            Me.iEvaluation.AssignValue(_entry.Evaluation)
            Me.txtResult.Text = _entry.ResultComments
            '
            '  Status
            Me.cbDocStatus.SelectedValue = _entry.Status
            Me.cbDocStatus.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtName.Select()
            Me.iOwner.Select()
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

        If IsEmpty(Me.iOwner) Then
            msgError = Locate("El nom del propietari és un camp obligatori", CAT)
            invalidControl = iOwner
            Return False
        End If

        If IsEmpty(Me.txtName) Then
            msgError = Locate("El nom del producte financer és un camp obligatori", CAT)
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

        Using ctx As New CashFlow.CashFlowContext()

            Dim CommonOwnerId As Integer = Me.iOwner.Entity.ID

            Dim deposit As Deposit = ctx.Deposits.Include(NameOf(deposit.Owner)).Where(Function(x) x.ID = Me.iDeposit.Entity.ID).FirstOrDefault()
            If deposit.Owner.ID <> CommonOwnerId Then
                msgError = Locate("El propietari entre els dipòsits no coincideix. Valida el propietari del dipòsit base.", CAT)
                invalidControl = txtName
                Return False
            End If

            If Me.iBaseDeposit.HasValue() Then
                Dim bDeposit = ctx.Deposits.Include(NameOf(deposit.Owner)).Where(Function(x) x.ID = Me.iBaseDeposit.Entity.ID).FirstOrDefault()
                If bDeposit.Owner.ID <> CommonOwnerId Then
                    msgError = Locate("El propietari entre els dipòsits no coincideix. Valida el propietari del dipòsit base.", CAT)
                    invalidControl = txtName
                    Return False
                End If
            End If

            If Me.iProductDeposit.HasValue() Then
                Dim pDeposit = ctx.Deposits.Include(NameOf(deposit.Owner)).Where(Function(x) x.ID = Me.iProductDeposit.Entity.ID).FirstOrDefault()
                If pDeposit.Owner.ID <> CommonOwnerId Then
                    msgError = Locate("El propietari entre els dipòsits no coincideix. Valida el propietari del dipòsit del producte.", CAT)
                    invalidControl = txtName
                    Return False
                End If
            End If

        End Using


        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Name = Me.txtName.Text
        _entry.Owner = ctx.Owners.Where(Function(x) x.ID = Me.iOwner.Entity.ID).FirstOrDefault()
        _entry.Comments = Me.txtComments.Text
        _entry.RegistrationDate = Me.teRegistrationDate.Value
        _entry.ResultComments = Me.txtResult.Text
        _entry.Status = Me.cbDocStatus.SelectedValue
        '
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
            If _entry.Status = Status.Open Then
                If MsgBox(Locate("Vols que el sistema et crei el dipòsit automàticament?", CAT), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                End If
            End If
        End Try

        _entry.BaseImport = Me.iBaseImport.Text

        If Me.iEvaluation.HasValue Then
            _entry.Evaluation = ctx.Evaluations.Where(Function(x) x.ID = Me.iEvaluation.Entity.ID).FirstOrDefault()
        Else
            ctx.Entry(_entry).Reference(NameOf(FinancialProduct.Evaluation)).CurrentValue = Nothing
        End If
        '

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

    Private Sub CashFlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashFlowNewEntryToolStripMenuItem.Click

        If IsEmpty(Me._entry.ID) Then
            MsgBox(Locate("Opció disponible només en mode de consulta", CAT))
            Return
        End If

        Dim cashFlowEntryID As Integer

        Using ctx As New CashFlow.CashFlowContext()

            ' 
            Dim oOwner As Owner = (From dbOwner In ctx.Owners
                                   Where dbOwner.ID = Me.iOwner.Entity.ID).First()
            ctx.Owners.Attach(oOwner)

            '
            Dim oFinancialProduct As FinancialProduct = (From dbFinancialProduct In ctx.FinancialProducts
                                                         Where dbFinancialProduct.ID = _entry.ID).First()
            ctx.FinancialProducts.Attach(oFinancialProduct)

            '
            Dim oCashFlowEntry = New CashFlowEntry()
            oCashFlowEntry.Concept = _entry.Name
            oCashFlowEntry.FromDate = Today
            oCashFlowEntry.Owner = oOwner
            oCashFlowEntry.FinancialProduct = oFinancialProduct
            oCashFlowEntry.AssetsImport = _entry.BaseImport
            oCashFlowEntry.Status = Status.Open
            ctx.CashFlowEntries.Add(oCashFlowEntry)
            ctx.SaveChanges()
            '
            cashFlowEntryID = oCashFlowEntry.ID

        End Using

        OpenCashFlowEntry(cashFlowEntryID)

    End Sub

    Public Sub OpenCashFlowEntry(ByVal cashFlowEntryID? As Integer)

        If IsEmpty(Me._entry.ID) Then
            MsgBox(Locate("Opció disponible només en mode de consulta", CAT))
            Return
        End If

        Dim frm As New FrmEdit()
        Dim defaultAppEvent As AppEvent
        If cashFlowEntryID.HasValue Then
            Dim specificEvent = New MoveToIDAppEvent()
            specificEvent.ID = cashFlowEntryID
            '
            defaultAppEvent = specificEvent
        Else
            defaultAppEvent = New SearchAppEvent()
        End If
        frm.DefaultAppEvent = defaultAppEvent
        Dim content = New CashFlow.CashFlowEntryEditor()
        content.EntitiesScopeCollection = {_entry}
        frm.MdiParent = Me.ParentForm.MdiParent
        frm.Content = content
        frm.Show()

        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub

    End Sub


    Private Sub ListaDeEntradasDeCashFlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeEntradasDeCashFlowToolStripMenuItem.Click

        OpenCashFlowEntry(Nothing)

    End Sub

    Private Sub NovaPlantillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovaPlantillaToolStripMenuItem.Click

        If IsEmpty(Me._entry.ID) Then
            MsgBox(Locate("Opció disponible només en mode de consulta", CAT))
            Return
        End If

        Dim templateID As Integer
        Try


            Using ctx As New CashFlowContext()

                Dim oDividendsSubGroup As SubGroup = ctx.SubGroups.Where(Function(x) x.AccessKey = SubGroup.DividendAccessKey).First
                ctx.Deposits.Attach(_entry.Deposit)
                ctx.SubGroups.Attach(oDividendsSubGroup)
                ctx.FinancialProducts.Attach(_entry)
                '
                Dim oTemplate As New JournalEntryTemplatev2()
                oTemplate.Concept = _entry.Name
                oTemplate.Deposit = _entry.Deposit
                oTemplate.Import = 0
                oTemplate.Name = Locate("Plantilla ", CAT) & $"{Now:dd/MM/yyyy HH:mm:ss}"
                oTemplate.SubGroup = oDividendsSubGroup
                oTemplate.FinancialProduct = _entry

                ctx.JournalEntryTemplatesv2.Add(oTemplate)
                ctx.SaveChanges()
                '
                templateID = oTemplate.ID
            End Using


            OpenTemplate(templateID)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub OpenTemplate(ByVal templateID? As Integer)

        If IsEmpty(Me._entry.ID) Then
            MsgBox(Locate("Opció disponible només en mode de consulta", CAT))
            Return
        End If

        Dim frm As New FrmEdit()
        Dim defaultAppEvent As AppEvent
        If templateID.HasValue Then
            Dim specificEvent = New MoveToIDAppEvent()
            specificEvent.ID = templateID
            '
            defaultAppEvent = specificEvent
        Else
            defaultAppEvent = New SearchAppEvent()
        End If
        frm.DefaultAppEvent = defaultAppEvent
        Dim content = New CashFlow.JournalEntryTemplateEditor()
        content.EntitiesScopeCollection = {_entry}
        frm.MdiParent = Me.ParentForm.MdiParent
        frm.Content = content
        frm.Show()

        AddHandler frm.FormClosed, Sub()
                                       frm.Dispose()
                                   End Sub

    End Sub

    Private Sub ObrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObrirToolStripMenuItem.Click

        If IsEmpty(Me._entry.ID) Then
            MsgBox(Locate("Opció disponible només en mode de consulta", CAT))
            Return
        End If

        Try
            FinancialProduct.OpenProduct(_entry.ID)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            LoadFormByID(_entry.ID)
        End Try


    End Sub

    Private Sub chkManualProductDeposit_CheckedChanged(sender As Object, e As EventArgs) Handles chkManualProductDeposit.CheckedChanged
        Me.iProductDeposit.Enabled = Me.chkManualProductDeposit.Checked
    End Sub

End Class
