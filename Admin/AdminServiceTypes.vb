Imports System.IO

Public Class AdminServiceTypes
    Private _home As TrashCash_Home

    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
        UC_ServiceTypesDetails1._HomeForm = HomeForm
    End Sub
    Private Sub ServiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ServiceTypesTableAdapter.FillWithAll(Me.DataSet.ServiceTypes)
        If (dg_Item.RowCount > 0) Then
            ColorRows(dg_Item)
        End If

    End Sub

    Private Sub ColorRows(ByRef grid As DataGridView)
        ' loop through all grid rows
        For i As Integer = 0 To grid.RowCount - 1
            Dim row As DataRowView = grid.Rows(i).DataBoundItem
            ' checking end date for colorization
            If (row.Item("ServiceActive") = 0) Then
                grid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
            End If
        Next i
    End Sub


    Private Sub EditItemToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditItemToolStripMenuItem.Click
        If (dg_Item.SelectedRows.Count = 1) Then
            Dim row As DataRowView = dg_Item.SelectedRows(0).DataBoundItem
            UC_ServiceTypesDetails1.Prep(row.Item("ServiceTypeID"))
            grp_ServiceEdit.Visible = True
        End If
    End Sub

    Private Sub CatchUpdate(ByVal Message As String) Handles UC_ServiceTypesDetails1.UpdateComplete
        MsgBox(Message)
        grp_ServiceEdit.Visible = False
        Me.ServiceTypesTableAdapter.FillWithAll(Me.DataSet.ServiceTypes)
        If (dg_Item.RowCount > 0) Then
            ColorRows(dg_Item)
        End If
    End Sub

    Private Sub NewItemToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewItemToolStripMenuItem.Click
        UC_ServiceTypesDetails1.PrepNew()
        grp_ServiceEdit.Visible = True
    End Sub
End Class