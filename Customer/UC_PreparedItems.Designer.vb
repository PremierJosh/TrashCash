<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_PreparedItems
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_PrepInvoices = New System.Windows.Forms.Label()
        Me.dg_PrepInvoices = New System.Windows.Forms.DataGridView()
        Me.InvoiceToBePrinted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dg_PrepPayments = New System.Windows.Forms.DataGridView()
        Me.lbl_Payments = New System.Windows.Forms.Label()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.pnl_TopLeft = New System.Windows.Forms.Panel()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.pnl_TopRight = New System.Windows.Forms.Panel()
        CType(Me.dg_PrepInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_PrepPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Left.SuspendLayout()
        Me.pnl_TopLeft.SuspendLayout()
        Me.pnl_Right.SuspendLayout()
        Me.pnl_TopRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_PrepInvoices
        '
        Me.lbl_PrepInvoices.AutoSize = True
        Me.lbl_PrepInvoices.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrepInvoices.Location = New System.Drawing.Point(3, 3)
        Me.lbl_PrepInvoices.Name = "lbl_PrepInvoices"
        Me.lbl_PrepInvoices.Size = New System.Drawing.Size(66, 16)
        Me.lbl_PrepInvoices.TabIndex = 60
        Me.lbl_PrepInvoices.Text = "Invoices"
        '
        'dg_PrepInvoices
        '
        Me.dg_PrepInvoices.AllowUserToAddRows = False
        Me.dg_PrepInvoices.AllowUserToDeleteRows = False
        Me.dg_PrepInvoices.AllowUserToResizeRows = False
        Me.dg_PrepInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_PrepInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PrepInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceToBePrinted})
        Me.dg_PrepInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_PrepInvoices.Location = New System.Drawing.Point(0, 20)
        Me.dg_PrepInvoices.MultiSelect = False
        Me.dg_PrepInvoices.Name = "dg_PrepInvoices"
        Me.dg_PrepInvoices.RowHeadersVisible = False
        Me.dg_PrepInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_PrepInvoices.Size = New System.Drawing.Size(504, 395)
        Me.dg_PrepInvoices.TabIndex = 62
        '
        'InvoiceToBePrinted
        '
        Me.InvoiceToBePrinted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InvoiceToBePrinted.DataPropertyName = "InvoiceToBePrinted"
        Me.InvoiceToBePrinted.HeaderText = "Print"
        Me.InvoiceToBePrinted.Name = "InvoiceToBePrinted"
        Me.InvoiceToBePrinted.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoiceToBePrinted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.InvoiceToBePrinted.Width = 53
        '
        'dg_PrepPayments
        '
        Me.dg_PrepPayments.AllowUserToAddRows = False
        Me.dg_PrepPayments.AllowUserToDeleteRows = False
        Me.dg_PrepPayments.AllowUserToResizeRows = False
        Me.dg_PrepPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_PrepPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PrepPayments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_PrepPayments.Location = New System.Drawing.Point(0, 20)
        Me.dg_PrepPayments.MultiSelect = False
        Me.dg_PrepPayments.Name = "dg_PrepPayments"
        Me.dg_PrepPayments.ReadOnly = True
        Me.dg_PrepPayments.RowHeadersVisible = False
        Me.dg_PrepPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_PrepPayments.Size = New System.Drawing.Size(390, 395)
        Me.dg_PrepPayments.TabIndex = 63
        '
        'lbl_Payments
        '
        Me.lbl_Payments.AutoSize = True
        Me.lbl_Payments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Payments.Location = New System.Drawing.Point(3, 1)
        Me.lbl_Payments.Name = "lbl_Payments"
        Me.lbl_Payments.Size = New System.Drawing.Size(76, 16)
        Me.lbl_Payments.TabIndex = 61
        Me.lbl_Payments.Text = "Payments"
        '
        'pnl_Left
        '
        Me.pnl_Left.Controls.Add(Me.dg_PrepInvoices)
        Me.pnl_Left.Controls.Add(Me.pnl_TopLeft)
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_Left.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Size = New System.Drawing.Size(504, 415)
        Me.pnl_Left.TabIndex = 64
        '
        'pnl_TopLeft
        '
        Me.pnl_TopLeft.Controls.Add(Me.lbl_PrepInvoices)
        Me.pnl_TopLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_TopLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnl_TopLeft.Name = "pnl_TopLeft"
        Me.pnl_TopLeft.Size = New System.Drawing.Size(504, 20)
        Me.pnl_TopLeft.TabIndex = 63
        '
        'pnl_Right
        '
        Me.pnl_Right.Controls.Add(Me.dg_PrepPayments)
        Me.pnl_Right.Controls.Add(Me.pnl_TopRight)
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(510, 0)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(390, 415)
        Me.pnl_Right.TabIndex = 65
        '
        'pnl_TopRight
        '
        Me.pnl_TopRight.Controls.Add(Me.lbl_Payments)
        Me.pnl_TopRight.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_TopRight.Location = New System.Drawing.Point(0, 0)
        Me.pnl_TopRight.Name = "pnl_TopRight"
        Me.pnl_TopRight.Size = New System.Drawing.Size(390, 20)
        Me.pnl_TopRight.TabIndex = 64
        '
        'UC_PreparedItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.pnl_Left)
        Me.Name = "UC_PreparedItems"
        Me.Size = New System.Drawing.Size(900, 415)
        CType(Me.dg_PrepInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_PrepPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Left.ResumeLayout(False)
        Me.pnl_TopLeft.ResumeLayout(False)
        Me.pnl_TopLeft.PerformLayout()
        Me.pnl_Right.ResumeLayout(False)
        Me.pnl_TopRight.ResumeLayout(False)
        Me.pnl_TopRight.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_PrepInvoices As System.Windows.Forms.Label
    Friend WithEvents dg_PrepInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents dg_PrepPayments As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Payments As System.Windows.Forms.Label
    Friend WithEvents pnl_Left As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopLeft As System.Windows.Forms.Panel
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopRight As System.Windows.Forms.Panel
    Friend WithEvents InvoiceToBePrinted As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
