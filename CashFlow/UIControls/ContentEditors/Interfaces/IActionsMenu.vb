Public Interface IActionsMenu

    Sub PerformAvailable(ParamArray appEventNames() As String)
    Sub DisableAll()
    '
    Event DeleteObject()
    Event DuplicateObject()

End Interface

