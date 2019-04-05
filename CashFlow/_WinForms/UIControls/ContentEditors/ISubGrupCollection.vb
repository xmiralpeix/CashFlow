Imports CashFlow

Friend Interface ISubGroupCollection
    ReadOnly Property Capital As ISubGroup
    ReadOnly Property Transfer As ISubGroup
    ReadOnly Property Dividend As ISubGroup
End Interface

Friend Class SubGroupCollection
    Implements ISubGroupCollection

    Private _ctx As CashFlowContext
    Public Sub New(ctx As CashFlowContext)
        _ctx = ctx
    End Sub

    Public ReadOnly Property Capital As ISubGroup Implements ISubGroupCollection.Capital
        Get
            Return _ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.CapitalAccessKey)
        End Get
    End Property

    Public ReadOnly Property Dividend As ISubGroup Implements ISubGroupCollection.Dividend
        Get
            Return _ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.DividendAccessKey)
        End Get
    End Property

    Public ReadOnly Property Transfer As ISubGroup Implements ISubGroupCollection.Transfer
        Get
            Return _ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.TransferAccessKey)
        End Get
    End Property

End Class
