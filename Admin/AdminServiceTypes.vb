Namespace Admin

    Public Class AdminServiceTypes
        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            UC_ServiceTypesDetails1._HomeForm = homeForm
        End Sub

        Private Sub ServiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ServiceTypesTableAdapter.Fill(ds_Types.ServiceTypes)
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

        Private Sub CatchUpdate(ByVal message As String) Handles UC_ServiceTypesDetails1.UpdateComplete
            MsgBox(message)
            grp_ServiceEdit.Visible = False
            ServiceTypesTableAdapter.Fill(ds_Types.ServiceTypes)
            If (dg_Item.RowCount > 0) Then
                ColorRows(dg_Item)
            End If
        End Sub

        Private Sub NewItemToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewItemToolStripMenuItem.Click
            UC_ServiceTypesDetails1.PrepNew()
            grp_ServiceEdit.Visible = True
        End Sub
    End Class
End Namespace