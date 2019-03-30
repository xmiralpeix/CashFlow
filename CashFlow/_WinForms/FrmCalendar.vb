Public Class FrmCalendar

    ReadOnly Property SelectedDate As Date
        Get
            Return Me.DateTimePicker1.Value
        End Get
    End Property

    Private Sub FrmCalendar_Load(sender As Object, e As EventArgs) Handles Me.Load

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "ddd dd MMMM yyyy"
        '
        Me.DateTimePicker1.Focus()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub DateTimePicker1_GotFocus(sender As Object, e As EventArgs) Handles DateTimePicker1.GotFocus
        System.Windows.Forms.SendKeys.Send("%{DOWN}")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.DialogResult = DialogResult.OK
    End Sub
End Class