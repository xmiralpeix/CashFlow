Imports CashFlow

Public Class JournalEntryEditor
    Implements IEditContent

    Public ReadOnly Property FindBehaviour As IFindBehaviour Implements IEditContent.FindBehaviour
        Get
            'Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property PrintBehaviour As IPrintBehaviour Implements IEditContent.PrintBehaviour
        Get
            ' Throw New NotImplementedException()
        End Get
    End Property

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            ' Throw New NotImplementedException()
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.JournalEntries)
        End Get
    End Property


    Public Sub LoadFormByID(ID As Integer?) Implements IEditContent.LoadFormByID
        '  Throw New NotImplementedException()
    End Sub

    Public Sub SaveEntry() Implements IEditContent.SaveEntry
        ' Throw New NotImplementedException()
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
End Class
