Imports CashFlow

Public Class ListBox_Deposit
    Inherits ListBox
    Implements IListBoxData

    Private _entity As Deposit

    Public Property Value As Object Implements IListBoxData.Value
        Get
            Return _entity
        End Get
        Set(value As Object)
            _entity = value
            LoadVisualProperties()
        End Set
    End Property

    Public ReadOnly Property VisualText As String Implements IListBoxData.VisualText

    Public ReadOnly Property VisualValue As String Implements IListBoxData.VisualValue


    Public Sub New()
        MyBase.New()
        '
        MyBase.Data = Me

    End Sub


    Public Sub AssignValue(InputValue As Deposit)
        _entity = InputValue
        LoadVisualProperties()
        LoadData()
    End Sub

    Public Sub AssignValue(InputValue As Integer)

        Using ctx As New CashFlow.CashFlowContext()
            Dim ID As Integer = InputValue
            Dim qry = From entiy In ctx.Deposits
                      Where entiy.ID = ID
            _entity = qry.FirstOrDefault()
        End Using
        '
        LoadVisualProperties()
        LoadData()

    End Sub

    Public Sub AssignValue(InputValue As String) Implements IListBoxData.AssignValue


        Try

            If mUtils.IsEmpty(InputValue) Then
                _entity = Nothing
            Else

                If InputValue.IsNumeric() Then
                    AssignValue(CInt(InputValue))
                    Return
                End If

                Using ctx As New CashFlow.CashFlowContext()
                    Dim qry = From entiy In ctx.Deposits
                              Where entiy.Name.Contains(InputValue)
                              Order By Len(entiy.Name) Ascending
                    _entity = qry.FirstOrDefault()
                End Using

            End If

        Catch ex As Exception
            _entity = Nothing
        End Try

        LoadVisualProperties()
        LoadData()

    End Sub

    Public Overrides Sub OnSearchClick()

        Dim findBehaviour As IFindBehaviour = New EntityIDsFinder(New DepositEditor())
        Dim IDscollection = findBehaviour.Find()
        If IsEmpty(IDscollection) Then
            Return
        End If

        Me.AssignValue(IDscollection.First())

    End Sub

    Private Sub LoadVisualProperties()

        If Not IsEmpty(_entity) Then
            _VisualValue = _entity.ID
            _VisualText = _entity.Name
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
