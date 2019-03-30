Imports CashFlow

Public Class ListBox_Deposit
    Inherits ListBox
    Implements IListBoxData

    Public Entity As Deposit

    Public Property Value As Object Implements IListBoxData.Value
        Get
            Return Entity
        End Get
        Set(value As Object)
            Entity = value
            LoadVisualProperties()
        End Set
    End Property

    Public ReadOnly Property VisualText As String Implements IListBoxData.VisualText

    Public ReadOnly Property VisualValue As String Implements IListBoxData.VisualValue

    Public Property EntitiesScopeCollection As IEnumerable(Of Object) Implements IListBoxData.EntitiesScopeCollection

    Public Sub New()
        MyBase.New()
        '
        MyBase.Data = Me

    End Sub


    Public Sub AssignValue(InputValue As Deposit)
        Entity = InputValue
        LoadVisualProperties()
        LoadData()
    End Sub

    Public Sub AssignValue(InputValue As Integer)

        Using ctx As New CashFlow.CashFlowContext()
            Dim ID As Integer = InputValue
            Dim qry = From entiy In ctx.Deposits
                      Where entiy.ID = ID
            Entity = qry.FirstOrDefault()
        End Using
        '
        LoadVisualProperties()
        LoadData()

    End Sub

    Public Sub AssignValue(InputValue As String) Implements IListBoxData.AssignValue


        Try

            If mUtils.IsEmpty(InputValue) Then
                Entity = Nothing
            Else

                If InputValue.IsNumeric() Then
                    AssignValue(CInt(InputValue))
                    Return
                End If

                Using ctx As New CashFlow.CashFlowContext()
                    Dim qry = From entiy In ctx.Deposits
                              Where entiy.Name.Contains(InputValue)
                              Order By Len(entiy.Name) Ascending

                    If Not IsEmpty(EntitiesScopeCollection) Then
                        For Each oEntity In EntitiesScopeCollection
                            If TypeOf oEntity Is Owner Then
                                Dim oOwner As Owner = oEntity
                                qry = qry.Where(Function(x) x.Owner.ID = oOwner.ID)
                                Continue For
                            End If
                        Next
                    End If

                    Entity = qry.FirstOrDefault()
                End Using

            End If

        Catch ex As Exception
            Entity = Nothing
        End Try

        LoadVisualProperties()
        LoadData()

    End Sub

    Public Overrides Sub OnSearchClick()

        Dim findContent = New DepositEditor()
        findContent.EntitiesScopeCollection = Me.EntitiesScopeCollection

        Dim findBehaviour As IFindBehaviour = New EntityIDsFinder(findContent)
        Dim IDscollection = findBehaviour.Find()
        If IsEmpty(IDscollection) Then
            Return
        End If

        Me.AssignValue(IDscollection.First())

    End Sub

    Private Sub LoadVisualProperties()

        If Not IsEmpty(Entity) Then
            _VisualValue = Entity.ID
            _VisualText = Entity.Name
        Else
            _VisualValue = String.Empty
            _VisualText = String.Empty
        End If

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ListBox 
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ListBox"
        Me.Size = New System.Drawing.Size(426, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
