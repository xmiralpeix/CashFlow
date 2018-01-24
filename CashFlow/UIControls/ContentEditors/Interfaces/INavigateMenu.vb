Public Interface INavigateMenu

    Sub PerformAvailable(ParamArray appEventNames() As String)
    Sub DisableAll()
    '
    Event SearchObject()
    Event NewObject()
    Event FirstObject()
    Event PreviousObject()
    Event NextObject()
    Event LastObject()
    Event Print()
    Event ImportExport()

End Interface

