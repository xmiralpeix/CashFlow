Imports CashFlow

Public Class FrmEdit
    Implements IAppEventListener

    Private _ID As Integer?
    Public ReadOnly Property ID As Integer?
        Get
            Return _ID
        End Get
    End Property


    Public Enum eStatus
        Finding = 0
        Adding = 1
        Updating = 2
    End Enum

    Public Status As eStatus = eStatus.Adding
    Public Content As IEditContent

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmEdit_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Me.ConfigureControls()
            Me.MoveToNew()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ConfigureControls()

        Me.pContentUI.SuspendLayout()
        Me.SuspendLayout()

        Me.pContentUI.Controls.Add(Content.GetUI())
        Me.pContentUI.Controls(Me.pContentUI.Controls.Count - 1).Dock = DockStyle.Fill
        Me.Text = Content.Text

        ChangeStatus(eStatus.Adding)

        Me.pContentUI.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub ChangeStatus(ByVal newStatus As eStatus)

        Select Case newStatus
            Case eStatus.Adding
                Me.btnOK.Text = "Afegir" ' TODO Traduir

            Case eStatus.Finding
                Me.btnOK.Text = "OK"

            Case eStatus.Updating
                Me.btnOK.Text = "Actualitzar" ' TODO Traduir

        End Select

    End Sub

    Public Sub PerformEvent(appEvent As AppEvent) Implements IAppEventListener.PerformEvent

        ' TODO Perform event
        Select Case True
            Case TypeOf (appEvent) Is SearchAppEvent : ProcessSearchBehaviour()
            Case TypeOf (appEvent) Is NewAppEvent : MoveToNew()
            Case TypeOf (appEvent) Is FirstAppEvent : MoveToFirst()
            Case TypeOf (appEvent) Is PreviousAppEvent : MoveToPrevious()
            Case TypeOf (appEvent) Is NextAppEvent : MoveToNext()
            Case TypeOf (appEvent) Is LastAppEvent : MoveToLast()
            Case TypeOf (appEvent) Is PrintAppEvent : ProcessPrintBehaviour()
        End Select

    End Sub

    Private Sub ProcessPrintBehaviour()

        Content.PrintBehaviour.Print(_ID.Value, _ID.Value, CAT)

    End Sub

    Public Sub ProcessSearchBehaviour()

        Dim IDscollection As IEnumerable(Of Integer) = Content.FindBehaviour.Find()
        If IDscollection Is Nothing Then
            Return
        End If

        Me._ID = IDscollection.First()
        Content.LoadFormByID(Me.ID)
        ChangeStatus(eStatus.Updating)

    End Sub

    Private Sub MoveToNew()
        Me._ID = Nothing
        Content.LoadFormByID(Me._ID)
        ChangeStatus(eStatus.Adding)
    End Sub

    Public Sub MoveToPrevious()

        If Not ID.HasValue OrElse ID = 0 Then
            MoveToFirst()
            Return
        End If

        Dim newID = QryValue(Of Integer?)($"SELECT MAX(ID) AS R0 FROM ""{Content.Table}"" WHERE ID < {ID.Value}")

        If Not newID.HasValue Then
            MsgBox(Locate("No s'han trobat registres", CAT))
            Return
        End If

        _ID = newID
        Content.LoadFormByID(Me.ID)
        ChangeStatus(eStatus.Updating)

    End Sub


    Public Sub MoveToNext()

        If Not ID.HasValue OrElse ID = 0 Then
            MoveToLast()
            Return
        End If

        Dim newID = QryValue(Of Integer?)($"SELECT MIN(ID) AS R0 FROM ""{Content.Table}"" WHERE ID > {ID.Value}")

        If Not newID.HasValue Then
            MsgBox(Locate("No s'han trobat registres", CAT))
            Return
        End If

        _ID = newID
        Content.LoadFormByID(Me.ID)
        ChangeStatus(eStatus.Updating)

    End Sub

    Public Sub MoveToFirst()

        Dim newID = QryValue(Of Integer?)($"SELECT MIN(ID) AS R0 FROM ""{Content.Table}"" ")

        If Not newID.HasValue Then
            MsgBox(Locate("No s'han trobat registres", CAT))
            Return
        End If

        _ID = newID
        Content.LoadFormByID(Me.ID)
        ChangeStatus(eStatus.Updating)

    End Sub

    Public Sub MoveToLast()

        Dim newID = QryValue(Of Integer?)($"SELECT MAX(ID) AS R0 FROM ""{Content.Table}"" ")

        If Not newID.HasValue Then
            MsgBox(Locate("No s'han trobat registres", CAT))
            Return
        End If

        _ID = newID
        Content.LoadFormByID(Me.ID)
        ChangeStatus(eStatus.Updating)

    End Sub

    Private Sub FrmEdit_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        Try

            For Each appEvent In Content.AppEvents
                Select Case appEvent
                    Case NameOf(SearchAppEvent) : ApplicationEvents.ChangeToSearch.Attach(Me)
                    Case NameOf(NewAppEvent) : ApplicationEvents.ChangeToNew.Attach(Me)
                    Case NameOf(FirstAppEvent) : ApplicationEvents.ChangeToFirst.Attach(Me)
                    Case NameOf(PreviousAppEvent) : ApplicationEvents.ChangeToPrevious.Attach(Me)
                    Case NameOf(NextAppEvent) : ApplicationEvents.ChangeToNext.Attach(Me)
                    Case NameOf(LastAppEvent) : ApplicationEvents.ChangeToLast.Attach(Me)
                    Case NameOf(PrintAppEvent) : ApplicationEvents.ChangeToPrint.Attach(Me)
                End Select
            Next
            '
            ApplicationEvents.RefreshStatus(Me)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmEdit_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        '
        ApplicationEvents.ChangeToSearch.Detach(Me)
        ApplicationEvents.ChangeToNew.Detach(Me)
        ApplicationEvents.ChangeToFirst.Detach(Me)
        ApplicationEvents.ChangeToPrevious.Detach(Me)
        ApplicationEvents.ChangeToNext.Detach(Me)
        ApplicationEvents.ChangeToLast.Detach(Me)
        ApplicationEvents.ChangeToPrint.Detach(Me)
        '
        ApplicationEvents.RefreshStatus(Me)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Try

            Dim msgError As String = Nothing
            Dim invalidControl As Control = Nothing
            If Not Content.IsValidContent(msgError, invalidControl) Then
                invalidControl.Select()
                Throw New Exception(msgError)
            End If

            Content.SaveEntry()
            Me.MoveToNew()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class



