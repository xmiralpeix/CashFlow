Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class PurchaseInvoiceEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Factures rebudes", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.PurchaseInvoices)
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


    Private _entry As PurchaseInvoice

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    Dim qry = PurchaseInvoice.GetDBQuery(ctx).Where(Function(entity) entity.ID = ID.Value)

                    If Not IsEmpty(EntitiesScopeCollection) Then
                        For Each oEntity In EntitiesScopeCollection
                            If TypeOf oEntity Is Owner Then
                                Dim oOwner As Owner = oEntity
                                qry = qry.Where(Function(x) x.Owner.ID = oOwner.ID)
                                Continue For
                            End If
                        Next
                    End If

                    _entry = qry.First()

                End Using

            Else
                _entry = New PurchaseInvoice()
            End If

            Dim AssignScopes = Sub()
                                   Dim oOwner = Me.lstOwner.Entity
                                   Me.lstDeposit.EntitiesScopeCollection = {oOwner}
                               End Sub

            Me.txtID.Text = _entry.ID
            Me.txtConcept.Text = _entry.Concept
            ' Deposit
            If IsEmpty(_entry.Deposit) Then
                Me.lstDeposit.AssignValue(String.Empty)
            Else
                Me.lstDeposit.AssignValue(_entry.Deposit.ID)
            End If
            lstDeposit.Enabled = IsEmpty(Me._entry.ID)
            ' Group
            If IsEmpty(_entry.SubGroup) Then
                Me.lstSubGroup.AssignValue(String.Empty)
            Else
                Me.lstSubGroup.AssignValue(_entry.SubGroup.ID)
            End If
            lstSubGroup.Enabled = IsEmpty(Me._entry.ID)
            '
            Me.txtDate.AssignValue(If(IsEmpty(_entry.DocDate), DirectCast(Nothing, DateTime?), _entry.DocDate))
            txtDate.Enabled = IsEmpty(Me._entry.ID)
            '
            txtImport.Text = _entry.Import
            txtImport.Enabled = IsEmpty(Me._entry.ID)
            '
            txtLicTradNum.Text = _entry.LicTradNum
            '
            txtNumAtCard.Text = _entry.NumAtCard
            ' Owner
            If IsEmpty(_entry.Owner) Then
                Me.lstOwner.AssignValue(String.Empty)
            Else
                Me.lstOwner.AssignValue(_entry.Owner.ID)
            End If
            AddHandler lstOwner.OnEntityChanged, AssignScopes
            lstOwner.Enabled = IsEmpty(Me._entry.ID)
            ' Document status
            cbDocStatus.SelectedValue = _entry.Status
                                                     If IsEmpty(_entry.SubGroup) Then
                                                         Me.lstSubGroup.AssignValue(String.Empty)
                                                     Else
                                                         Me.lstSubGroup.AssignValue(_entry.SubGroup.ID)
                                                     End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtConcept.Select()
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
        DocumentStatus.ConfigureCombo(Me.cbDocStatus)
        Return Me
    End Function


    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.lstOwner) Then
            invalidControl = Me.lstOwner
            msgError = Locate("El propietari és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.txtConcept) Then
            invalidControl = Me.txtConcept
            msgError = Locate("El nom dipòsit, és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.lstDeposit) Then
            invalidControl = Me.lstDeposit
            msgError = Locate("El dipòsit és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.txtDate) Then
            invalidControl = Me.txtDate
            msgError = Locate("La data és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.txtImport) Then
            invalidControl = Me.txtImport
            msgError = Locate("L'import és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.txtNumAtCard) Then
            invalidControl = Me.txtNumAtCard
            msgError = Locate("El número de factura és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.lstSubGroup) Then
            invalidControl = Me.lstSubGroup
            msgError = Locate("El grup és un camp obligatori", CAT)
            Return False
        End If

        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Concept = txtConcept.Text
        _entry.Deposit = ctx.Deposits.Where(Function(x) x.ID = Me.lstDeposit.Entity.ID).FirstOrDefault
        _entry.DocDate = txtDate.Value
        _entry.Import = txtImport.Text
        _entry.LicTradNum = txtLicTradNum.Text
        _entry.NumAtCard = txtNumAtCard.Text
        _entry.Owner = ctx.Owners.Where(Function(x) x.ID = Me.lstOwner.Entity.ID).FirstOrDefault
        _entry.Status = cbDocStatus.SelectedValue
        _entry.SubGroup = ctx.SubGroups.Where(Function(x) x.ID = Me.lstSubGroup.Entity.ID).FirstOrDefault

    End Sub

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            If _entry.ID <> 0 Then
                ' UPDATE
                _entry = PurchaseInvoice.GetDBQuery(ctx).Where(Function(entity) entity.ID = _entry.ID).First()

                FillEntry(ctx)
                '
                ctx.SaveChanges()
            Else
                ' ADD
                FillEntry(ctx)
                ctx.PurchaseInvoices.Add(_entry)
                '
                ctx.SaveChanges()
                _entry.AddJournalEntry(ctx)
                ctx.SaveChanges()

            End If

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal OwnerIDs As IEnumerable(Of Integer)) As Boolean


        Return False

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.PurchaseInvoices.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of PurchaseInvoice)
        Using ctx As New CashFlow.CashFlowContext()

            Dim qry = PurchaseInvoice.GetDBQuery(ctx)

            If Not IsEmpty(textSearch) Then
                qry = qry.Where(Function(x) (x.Concept).Contains(textSearch))
            End If

            If Not IsEmpty(EntitiesScopeCollection) Then
                For Each oEntity In EntitiesScopeCollection
                    If TypeOf oEntity Is Owner Then
                        Dim oOwner As Owner = oEntity
                        qry = qry.Where(Function(x) x.Owner.ID = oOwner.ID)
                        Continue For
                    End If
                Next
            End If

            entityCollection = qry.ToList()

        End Using

        Return entityCollection

    End Function

    Public Function GetColumns() As IEnumerable(Of DataGridViewColumn) Implements IFindContent.GetColumns

        Dim col As New List(Of DataGridViewColumn)()
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = "ID"
            .DataPropertyName = NameOf(PurchaseInvoice.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Data", CAT)
            .DataPropertyName = NameOf(PurchaseInvoice.DocDate)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("NIF", CAT)
            .DataPropertyName = NameOf(PurchaseInvoice.LicTradNum)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Factura", CAT)
            .DataPropertyName = NameOf(PurchaseInvoice.NumAtCard)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Concepte", CAT)
            .DataPropertyName = NameOf(PurchaseInvoice.Concept)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Import", CAT)
            .DataPropertyName = NameOf(PurchaseInvoice.Import)
        End With

        Return col

    End Function


End Class
