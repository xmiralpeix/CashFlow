Public Interface IActionsMenu

    Sub PerformAvailable(ParamArray appEventNames() As String)
    Sub DisableAll()
    '
    Event DeleteObject()
    Event DuplicateObject()
    Event CancelObject()

End Interface

