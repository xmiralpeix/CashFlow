Imports CashFlow

Public Interface ITransferInfo
    Property Concept As String
    Property FromDeposit As Deposit
    Property EntryDate As Date
    Property Import As Double
    Property ToDeposit As Deposit
End Interface

Friend Class TransferInfo
    Implements ITransferInfo

    Public Property Concept As String Implements ITransferInfo.Concept


    Public Property EntryDate As Date Implements ITransferInfo.EntryDate


    Public Property FromDeposit As Deposit Implements ITransferInfo.FromDeposit


    Public Property Import As Double Implements ITransferInfo.Import


    Public Property ToDeposit As Deposit Implements ITransferInfo.ToDeposit

End Class
