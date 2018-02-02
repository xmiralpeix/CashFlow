Imports CashFlow

Public Class ListBox_Date
    Inherits ListBox
    Implements IListBoxData

    Private dValue? As Date

    Public Property Value As Object Implements IListBoxData.Value
        Get
            Return dValue
        End Get
        Set(value As Object)
            dValue = value
            LoadVisualProperties()
        End Set
    End Property

    Public ReadOnly Property VisualText As String Implements IListBoxData.VisualText

    Public ReadOnly Property VisualValue As String Implements IListBoxData.VisualValue


    Public Sub New()
        MyBase.New()
        '
        MyBase.Data = Me

    End Sub


    Public Sub AssignValue(InputValue As String) Implements IListBoxData.AssignValue


        Try

            If String.IsNullOrWhiteSpace(InputValue) Then
                dValue = Nothing
            Else
                dValue = BuildDate_DDMMYYYY(InputValue)
            End If

        Catch ex As Exception
            dValue = Today.Date
        End Try

        LoadVisualProperties()

    End Sub

    Public Overrides Sub OnSearchClick()

        Dim frm As New FrmCalendar()
        If frm.ShowDialog() = DialogResult.OK Then
            Me.dValue = frm.SelectedDate()
            LoadVisualProperties()
            MyBase.LoadData()
        End If

    End Sub

    Private Sub LoadVisualProperties()

        If Me.dValue.HasValue Then
            _VisualValue = dValue.Value.ToString("dd/MM/yyyy")
            _VisualText = dValue.Value.ToString("ddd dd MMMM yyyy", CAT)
        Else
            _VisualValue = String.Empty
            _VisualText = String.Empty
        End If

    End Sub

    Private Shared Function BuildDate_DDMMYYYY(ByVal inputValue As String) As Date

        ' take of first or last characters
        inputValue = New String(inputValue _
            .SkipWhile(Function(s) s < "0" OrElse s > "9") _
            .Reverse() _
            .SkipWhile(Function(s) s < "0" OrElse s > "9") _
            .Reverse() _
            .ToArray()).Trim()

        If String.IsNullOrEmpty(inputValue) Then
            Throw New Exception()
        End If

        Dim numericValues As String = New String((From charvalue In inputValue
                                                  Where charvalue >= "0"c AndAlso charvalue <= "9"c).ToArray())

        If numericValues.Length = inputValue.Length Then
            Return BuildAllDate(numericValues)
        End If

        Dim dayPart = "", monthPart = "", yearPart = ""
        Dim acum As String = ""

        For idx As Integer = 0 To inputValue.Length - 1
            Dim currentString = inputValue(idx)
            If currentString >= "0" AndAlso currentString <= "9" Then
                acum &= currentString
            Else
                Select Case ""
                    Case dayPart : dayPart = acum
                    Case monthPart : monthPart = acum
                End Select
                acum = ""
            End If
        Next

        If dayPart <> "" AndAlso monthPart <> "" Then
            yearPart = AddRestOfYear(acum)
            Return New Date(yearPart, monthPart, dayPart)
        End If

        Try
            monthPart = acum(0) & acum(1)
            yearPart = AddRestOfYear(acum.Substring(2))
            Return New Date(yearPart, monthPart, dayPart)
        Catch ex As Exception
        End Try

        Try
            monthPart = acum(0)
            yearPart = AddRestOfYear(acum.Substring(1))
            Return New Date(yearPart, monthPart, dayPart)
        Catch ex As Exception
        End Try


        Throw New Exception() ' no more options

    End Function

    Private Shared Function AddRestOfYear(ByVal values As String) As String

        Select Case values.Length
            Case 3 : Return Now.Year.ToString.Substring(0, 1) & values
            Case 2 : Return Now.Year.ToString.Substring(0, 2) & values
            Case 1 : Return Now.Year.ToString.Substring(0, 3) & values
            Case 0 : Return Now.Year
            Case Else : Return values
        End Select

    End Function


    Private Shared Function BuildAllDate(ByVal numericValues As String) As Date

        Dim nowValue As Date = Today


        Select Case numericValues.Length

            Case 1
                Return New Date(nowValue.Year, nowValue.Month, nowValue.Day)

            Case 2
                Try
                    Return New Date(nowValue.Year, nowValue.Month, String.Concat(Val(numericValues(0)), Val(numericValues(1))))
                Catch ex As Exception
                    Return New Date(nowValue.Year, Val(numericValues(1)), Val(numericValues(0)))
                End Try

            Case 3
                Try
                    Return New Date(nowValue.Year, Val(numericValues(2)), String.Concat(Val(numericValues(0)), Val(numericValues(1))))
                Catch ex As Exception
                End Try

                Try
                    Return New Date(nowValue.Year, String.Concat(numericValues(1), numericValues(2)), String.Concat(numericValues(0), ""))
                Catch ex As Exception
                End Try

                Return New Date(CStr(nowValue.Year)(0) & "00" & numericValues(2), String.Concat(numericValues(1), ""), String.Concat(numericValues(0), ""))

            Case 4
                Try
                    Return New Date(nowValue.Year, String.Concat(numericValues(2), numericValues(3)), String.Concat(numericValues(0), numericValues(1)))
                Catch ex As Exception
                End Try

                Try
                    Return New Date(CStr(nowValue.Year)(0) & "00" & numericValues(3), String.Concat(numericValues(1), numericValues(2)), String.Concat(numericValues(0), ""))
                Catch ex As Exception
                End Try

                Return New Date(CStr(nowValue.Year)(0) & "0" & numericValues(2) & numericValues(3), String.Concat(numericValues(1), ""), String.Concat(numericValues(0), ""))

            Case 5
                Try
                    Return New Date(String.Concat(CStr(nowValue.Year)(0), "00", numericValues(4)), String.Concat(numericValues(2), numericValues(3)), String.Concat(numericValues(0), numericValues(1)))
                Catch ex As Exception
                End Try

                Try
                    Return New Date(String.Concat(CStr(nowValue.Year)(0), "0", numericValues(3), numericValues(4)), String.Concat(numericValues(1), numericValues(2)), String.Concat(numericValues(0), ""))
                Catch ex As Exception
                End Try

                Return New Date(String.Concat(CStr(nowValue.Year)(0), numericValues(2), numericValues(3), numericValues(4)), String.Concat(numericValues(1), ""), String.Concat(numericValues(0), ""))

            Case 6
                Try
                    Return New Date(String.Concat(CStr(nowValue.Year)(0), "0", numericValues(4), numericValues(5)),
                                    String.Concat(numericValues(2), numericValues(3)),
                                    String.Concat(numericValues(0), numericValues(1)))
                Catch ex As Exception
                End Try

                Try
                    Return New Date(String.Concat(CStr(nowValue.Year)(0), numericValues(3), numericValues(4), numericValues(5)),
                                    String.Concat(numericValues(1), numericValues(2)),
                                    String.Concat(numericValues(0), ""))
                Catch ex As Exception
                End Try

                Return New Date(String.Concat(numericValues(2), numericValues(3), numericValues(4), numericValues(5)),
                                    String.Concat(numericValues(1), ""),
                                    String.Concat(numericValues(0), ""))

            Case 7
                Try
                    Return New Date(String.Concat(CStr(nowValue.Year)(0), numericValues(4), numericValues(5), numericValues(6)),
                                    String.Concat(numericValues(2), numericValues(3)),
                                    String.Concat(numericValues(0), numericValues(1)))
                Catch ex As Exception
                End Try

                Try
                    Return New Date(String.Concat(numericValues(3), numericValues(4), numericValues(5), numericValues(6)),
                                    String.Concat(numericValues(1), numericValues(2)),
                                    String.Concat(numericValues(0), ""))
                Catch ex As Exception
                    Throw New Exception ' No more options
                End Try

            Case 8
                Try
                    Return New Date(String.Concat(numericValues(4), numericValues(5), numericValues(6), numericValues(7)),
                                String.Concat(numericValues(2), numericValues(3)),
                                String.Concat(numericValues(0), numericValues(1)))

                Catch ex As Exception
                    Throw New Exception ' No more options
                End Try

            Case Else
                Throw New Exception ' No more options

        End Select



    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ListBox_Date
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ListBox_Date"
        Me.Size = New System.Drawing.Size(426, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
