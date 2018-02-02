Imports CashFlow

Public Class ListBox_Owner
    Inherits ListBox
    Implements IListBoxData

    Private _entity As Owner

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


    Public Sub AssignValue(InputValue As String) Implements IListBoxData.AssignValue


        Try

            If IsEmpty(InputValue) Then
                _entity = Nothing
            Else
                Using ctx As New CashFlow.CashFlowContext()

                    If InputValue.IsNumeric() Then
                        Dim ID As Integer = CInt(InputValue)
                        Dim qry = From entiy In ctx.Owners
                                  Where entiy.ID = ID
                        _entity = qry.FirstOrDefault()
                    Else
                        Dim qry = From entiy In ctx.Owners
                                  Where entiy.Name.Contains(InputValue)
                                  Order By Len(entiy.Name) Ascending
                        _entity = qry.FirstOrDefault()
                    End If

                End Using

            End If

        Catch ex As Exception
            _entity = Nothing
        End Try

        LoadVisualProperties()
        LoadData()

    End Sub

    Public Overrides Sub OnSearchClick()

        Dim findBehaviour As IFindBehaviour = New EntityIDsFinder(New OwnerEditor())
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
        'ListBox_Date
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ListBox_Owner"
        Me.Size = New System.Drawing.Size(426, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
