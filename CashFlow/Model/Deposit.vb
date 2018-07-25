Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Deposit

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(150)>
    Public Property Name As String
    Public Property CreationDate As System.DateTime
    Public Property CancelDate As System.DateTime?
    Public Property Owner As Owner
    Public Property FinancialEntity As FinancialEntity
    Public Property IsCash As Boolean

    Public Sub New()
        CreationDate = Now
    End Sub


    Public Shared Sub LoadBalance(ByVal DepositID As Integer,
                                  ByRef Incomes As Decimal,
                                  ByRef Expenses As Decimal,
                                  ByRef Balance As Decimal)

        Using ctx As New CashFlowContext()

            Dim qry = From entry As JournalEntry In ctx.JournalEntries
                      Where 1 = 1 AndAlso
                          entry.CancelDate Is Nothing AndAlso
                          entry.FiscalYear Is Nothing AndAlso
                          entry.Deposit.ID = DepositID

            Try
                Incomes = qry.Where(Function(x) x.Import > 0).Sum(Function(x) x.Import)
            Catch ex As Exception
                Incomes = 0
            End Try

            Try
                Expenses = qry.Where(Function(x) x.Import < 0).Sum(Function(x) x.Import)
            Catch ex As Exception
                Expenses = 0
            End Try

            Balance = Incomes + Expenses

        End Using

    End Sub


End Class