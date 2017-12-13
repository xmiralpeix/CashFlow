Imports CashFlow

Public Interface IDeposit
    Property AccessKey As String
    Property CancelDate As Date?
    Property CreationDate As Date
    Property ID As Integer
    Property Name As String
    Property Owner As Owner
End Interface
