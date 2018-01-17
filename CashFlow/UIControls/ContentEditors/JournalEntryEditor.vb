'Imports CashFlow

'Public Class JournalEntryEditor
'    Implements IEditContent(Of JournalEntry)

'    Private ReadOnly Property Table As String Implements IEditContent(Of JournalEntry).Table
'        Get
'            Return NameOf(CashFlow.CashFlowContext.JournalEntries)
'        End Get
'    End Property



'    Private ReadOnly Property Text As String Implements IEditContent(Of JournalEntry).Text
'        Get
'            Return "Assentaments" ' TODO Translate
'        End Get
'    End Property

'    Public Sub LoadEntryByForm(ByRef entry As JournalEntry) Implements IEditContent(Of JournalEntry).LoadEntryByForm
'        MsgBox("Loading LoadEntryByForm ")
'    End Sub

'    Public Sub LoadFormByEntry(entry As JournalEntry) Implements IEditContent(Of JournalEntry).LoadFormByEntry
'        MsgBox("Loading LoadFormByEntry ")
'    End Sub

'    Private Function AppEvents() As IEnumerable(Of String) Implements IEditContent(Of JournalEntry).AppEvents
'        Return {
'            NameOf(SearchAppEvent),
'            NameOf(NewAppEvent),
'            NameOf(FirstAppEvent),
'            NameOf(PreviousAppEvent),
'            NameOf(NextAppEvent),
'            NameOf(LastAppEvent)}
'    End Function

'    Private Function GetUI() As IContainerControl Implements IEditContent(Of JournalEntry).GetUI
'        Return Me
'    End Function
'End Class
