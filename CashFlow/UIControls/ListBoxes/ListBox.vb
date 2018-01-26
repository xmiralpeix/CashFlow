﻿Imports System.ComponentModel
Imports CashFlow

Public Class ListBox

    Public Data As IListBoxData

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txtValue_Leave(sender As Object, e As EventArgs) Handles txtVisualValue.Leave

        Data.AssignValue(Me.txtVisualValue.Text)
        LoadData()

    End Sub

    Public Sub LoadData()

        Me.txtVisualValue.Clear()
        Me.txtVisualValue.Clear()

        Try
            Me.txtVisualValue.Text = Data.VisualValue
            Me.txtDisplay.Text = Data.VisualText
        Catch ex As Exception
            Me.txtVisualValue.Clear()
            Me.txtVisualValue.Clear()
        End Try

    End Sub

    Public Overridable Sub OnSearchClick()
        MsgBox("Click")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            OnSearchClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
