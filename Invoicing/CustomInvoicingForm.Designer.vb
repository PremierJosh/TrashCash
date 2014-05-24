<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomInvoicingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_1 = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.Ts_M_Customer = New TrashCash.ts_M_Customer()
        Me.pnl_2 = New System.Windows.Forms.Panel()
        Me.cmb_LineTypes = New System.Windows.Forms.ComboBox()
        Me.Ds_Invoicing = New TrashCash.ds_Invoicing()
        Me.CustomInvoiceLineTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomInvoice_LineTypesTableAdapter = New TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter()
        Me.lbl_LineType = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel.SuspendLayout()
        Me.pnl_1.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        Me.pnl_2.SuspendLayout()
        CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_1)
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_2)
        Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(972, 523)
        Me.FlowLayoutPanel.TabIndex = 0
        '
        'pnl_1
        '
        Me.pnl_1.Controls.Add(Me.pnl_TopContent)
        Me.pnl_1.Location = New System.Drawing.Point(3, 3)
        Me.pnl_1.Name = "pnl_1"
        Me.pnl_1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnl_1.Size = New System.Drawing.Size(850, 53)
        Me.pnl_1.TabIndex = 98
        '
        'pnl_TopContent
        '
        Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopContent.Controls.Add(Me.Ts_M_Customer)
        Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
        Me.pnl_TopContent.Name = "pnl_TopContent"
        Me.pnl_TopContent.Size = New System.Drawing.Size(810, 33)
        Me.pnl_TopContent.TabIndex = 2
        '
        'Ts_M_Customer
        '
        Me.Ts_M_Customer.CurrentCustomer = 0
        Me.Ts_M_Customer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ts_M_Customer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Ts_M_Customer.HomeForm = Nothing
        Me.Ts_M_Customer.Location = New System.Drawing.Point(0, 0)
        Me.Ts_M_Customer.Name = "Ts_M_Customer"
        Me.Ts_M_Customer.Size = New System.Drawing.Size(808, 31)
        Me.Ts_M_Customer.TabIndex = 2
        Me.Ts_M_Customer.Text = "Ts_M_Customer1"
        '
        'pnl_2
        '
        Me.pnl_2.Controls.Add(Me.lbl_LineType)
        Me.pnl_2.Controls.Add(Me.cmb_LineTypes)
        Me.pnl_2.Location = New System.Drawing.Point(3, 62)
        Me.pnl_2.Name = "pnl_2"
        Me.pnl_2.Size = New System.Drawing.Size(850, 118)
        Me.pnl_2.TabIndex = 99
        '
        'cmb_LineTypes
        '
        Me.cmb_LineTypes.DataSource = Me.CustomInvoiceLineTypesBindingSource
        Me.cmb_LineTypes.DisplayMember = "Name"
        Me.cmb_LineTypes.FormattingEnabled = True
        Me.cmb_LineTypes.Location = New System.Drawing.Point(36, 29)
        Me.cmb_LineTypes.Name = "cmb_LineTypes"
        Me.cmb_LineTypes.Size = New System.Drawing.Size(243, 21)
        Me.cmb_LineTypes.TabIndex = 0
        Me.cmb_LineTypes.ValueMember = "CI_TypeID"
        '
        'Ds_Invoicing
        '
        Me.Ds_Invoicing.DataSetName = "ds_Invoicing"
        Me.Ds_Invoicing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomInvoiceLineTypesBindingSource
        '
        Me.CustomInvoiceLineTypesBindingSource.DataMember = "CustomInvoice_LineTypes"
        Me.CustomInvoiceLineTypesBindingSource.DataSource = Me.Ds_Invoicing
        '
        'CustomInvoice_LineTypesTableAdapter
        '
        Me.CustomInvoice_LineTypesTableAdapter.ClearBeforeFill = True
        '
        'lbl_LineType
        '
        Me.lbl_LineType.AutoSize = True
        Me.lbl_LineType.Location = New System.Drawing.Point(33, 13)
        Me.lbl_LineType.Name = "lbl_LineType"
        Me.lbl_LineType.Size = New System.Drawing.Size(110, 13)
        Me.lbl_LineType.TabIndex = 1
        Me.lbl_LineType.Text = "What type of charge?"
        '
        'CustomInvoicing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 523)
        Me.Controls.Add(Me.FlowLayoutPanel)
        Me.Name = "CustomInvoicing"
        Me.Text = "Custom Invoicing"
        Me.FlowLayoutPanel.ResumeLayout(False)
        Me.pnl_1.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        Me.pnl_2.ResumeLayout(False)
        Me.pnl_2.PerformLayout()
        CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_1 As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents Ts_M_Customer As TrashCash.ts_M_Customer
    Friend WithEvents pnl_2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_LineType As System.Windows.Forms.Label
    Friend WithEvents cmb_LineTypes As System.Windows.Forms.ComboBox
    Friend WithEvents CustomInvoiceLineTypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Invoicing As TrashCash.ds_Invoicing
    Friend WithEvents CustomInvoice_LineTypesTableAdapter As TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
End Class
