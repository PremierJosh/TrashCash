<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Testing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Testing))
        Me.QBDataSet = New TrashCash.QBDataSet()
        Me.sendToQBBtn = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.CustomerNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerListIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerEditSeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerPhoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerAltPhoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerContactDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingAddr1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingAddr2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingAddr3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingCityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingStateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBillingZipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipAddr1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipAddr2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipAddr3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipCityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipStateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShipZipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerStartDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerInvoiceDOMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerLastInvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerServiceTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerTableAdapter = New TrashCash.QBDataSetTableAdapters.CustomerTableAdapter()
        Me.queryCustomer = New System.Windows.Forms.Button()
        Me.customerQueryGrid = New System.Windows.Forms.DataGridView()
        Me.queryItem = New System.Windows.Forms.Button()
        Me.itemGrid = New System.Windows.Forms.DataGridView()
        Me.AttachedTxnsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttachedTxnsTableAdapter = New TrashCash.QBDataSetTableAdapters.AttachedTxnsTableAdapter()
        Me.TableAdapterManager = New TrashCash.QBDataSetTableAdapters.TableAdapterManager()
        Me.WorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LineItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LineItemTableAdapter = New TrashCash.QBDataSetTableAdapters.LineItemTableAdapter()
        Me.WorkingInvoiceTableAdapter = New TrashCash.QBDataSetTableAdapters.WorkingInvoiceTableAdapter()
        Me.testBtn = New System.Windows.Forms.Button()
        Me.testGrid1 = New System.Windows.Forms.DataGridView()
        Me.testGrid2 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.QBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customerQueryGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.itemGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachedTxnsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LineItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QBDataSet
        '
        Me.QBDataSet.DataSetName = "QBDataSet"
        Me.QBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'sendToQBBtn
        '
        Me.sendToQBBtn.Location = New System.Drawing.Point(13, 321)
        Me.sendToQBBtn.Name = "sendToQBBtn"
        Me.sendToQBBtn.Size = New System.Drawing.Size(75, 23)
        Me.sendToQBBtn.TabIndex = 5
        Me.sendToQBBtn.Text = "Send to QB"
        Me.sendToQBBtn.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNumberDataGridViewTextBoxColumn, Me.CustomerListIDDataGridViewTextBoxColumn, Me.CustomerEditSeqDataGridViewTextBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn, Me.CustomerPhoneDataGridViewTextBoxColumn, Me.CustomerAltPhoneDataGridViewTextBoxColumn, Me.CustomerContactDataGridViewTextBoxColumn, Me.CustomerBillingAddr1DataGridViewTextBoxColumn, Me.CustomerBillingAddr2DataGridViewTextBoxColumn, Me.CustomerBillingAddr3DataGridViewTextBoxColumn, Me.CustomerBillingCityDataGridViewTextBoxColumn, Me.CustomerBillingStateDataGridViewTextBoxColumn, Me.CustomerBillingZipDataGridViewTextBoxColumn, Me.CustomerShipAddr1DataGridViewTextBoxColumn, Me.CustomerShipAddr2DataGridViewTextBoxColumn, Me.CustomerShipAddr3DataGridViewTextBoxColumn, Me.CustomerShipCityDataGridViewTextBoxColumn, Me.CustomerShipStateDataGridViewTextBoxColumn, Me.CustomerShipZipDataGridViewTextBoxColumn, Me.CustomerStartDateDataGridViewTextBoxColumn, Me.CustomerInvoiceDOMDataGridViewTextBoxColumn, Me.CustomerLastInvoiceDateDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.CustomerBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(12, 350)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(686, 143)
        Me.DataGridView2.TabIndex = 6
        '
        'CustomerNumberDataGridViewTextBoxColumn
        '
        Me.CustomerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber"
        Me.CustomerNumberDataGridViewTextBoxColumn.HeaderText = "CustomerNumber"
        Me.CustomerNumberDataGridViewTextBoxColumn.Name = "CustomerNumberDataGridViewTextBoxColumn"
        Me.CustomerNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerListIDDataGridViewTextBoxColumn
        '
        Me.CustomerListIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerListID"
        Me.CustomerListIDDataGridViewTextBoxColumn.HeaderText = "CustomerListID"
        Me.CustomerListIDDataGridViewTextBoxColumn.Name = "CustomerListIDDataGridViewTextBoxColumn"
        '
        'CustomerEditSeqDataGridViewTextBoxColumn
        '
        Me.CustomerEditSeqDataGridViewTextBoxColumn.DataPropertyName = "CustomerEditSeq"
        Me.CustomerEditSeqDataGridViewTextBoxColumn.HeaderText = "CustomerEditSeq"
        Me.CustomerEditSeqDataGridViewTextBoxColumn.Name = "CustomerEditSeqDataGridViewTextBoxColumn"
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        '
        'CustomerPhoneDataGridViewTextBoxColumn
        '
        Me.CustomerPhoneDataGridViewTextBoxColumn.DataPropertyName = "CustomerPhone"
        Me.CustomerPhoneDataGridViewTextBoxColumn.HeaderText = "CustomerPhone"
        Me.CustomerPhoneDataGridViewTextBoxColumn.Name = "CustomerPhoneDataGridViewTextBoxColumn"
        '
        'CustomerAltPhoneDataGridViewTextBoxColumn
        '
        Me.CustomerAltPhoneDataGridViewTextBoxColumn.DataPropertyName = "CustomerAltPhone"
        Me.CustomerAltPhoneDataGridViewTextBoxColumn.HeaderText = "CustomerAltPhone"
        Me.CustomerAltPhoneDataGridViewTextBoxColumn.Name = "CustomerAltPhoneDataGridViewTextBoxColumn"
        '
        'CustomerContactDataGridViewTextBoxColumn
        '
        Me.CustomerContactDataGridViewTextBoxColumn.DataPropertyName = "CustomerContact"
        Me.CustomerContactDataGridViewTextBoxColumn.HeaderText = "CustomerContact"
        Me.CustomerContactDataGridViewTextBoxColumn.Name = "CustomerContactDataGridViewTextBoxColumn"
        '
        'CustomerBillingAddr1DataGridViewTextBoxColumn
        '
        Me.CustomerBillingAddr1DataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingAddr1"
        Me.CustomerBillingAddr1DataGridViewTextBoxColumn.HeaderText = "CustomerBillingAddr1"
        Me.CustomerBillingAddr1DataGridViewTextBoxColumn.Name = "CustomerBillingAddr1DataGridViewTextBoxColumn"
        '
        'CustomerBillingAddr2DataGridViewTextBoxColumn
        '
        Me.CustomerBillingAddr2DataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingAddr2"
        Me.CustomerBillingAddr2DataGridViewTextBoxColumn.HeaderText = "CustomerBillingAddr2"
        Me.CustomerBillingAddr2DataGridViewTextBoxColumn.Name = "CustomerBillingAddr2DataGridViewTextBoxColumn"
        '
        'CustomerBillingAddr3DataGridViewTextBoxColumn
        '
        Me.CustomerBillingAddr3DataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingAddr3"
        Me.CustomerBillingAddr3DataGridViewTextBoxColumn.HeaderText = "CustomerBillingAddr3"
        Me.CustomerBillingAddr3DataGridViewTextBoxColumn.Name = "CustomerBillingAddr3DataGridViewTextBoxColumn"
        '
        'CustomerBillingCityDataGridViewTextBoxColumn
        '
        Me.CustomerBillingCityDataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingCity"
        Me.CustomerBillingCityDataGridViewTextBoxColumn.HeaderText = "CustomerBillingCity"
        Me.CustomerBillingCityDataGridViewTextBoxColumn.Name = "CustomerBillingCityDataGridViewTextBoxColumn"
        '
        'CustomerBillingStateDataGridViewTextBoxColumn
        '
        Me.CustomerBillingStateDataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingState"
        Me.CustomerBillingStateDataGridViewTextBoxColumn.HeaderText = "CustomerBillingState"
        Me.CustomerBillingStateDataGridViewTextBoxColumn.Name = "CustomerBillingStateDataGridViewTextBoxColumn"
        '
        'CustomerBillingZipDataGridViewTextBoxColumn
        '
        Me.CustomerBillingZipDataGridViewTextBoxColumn.DataPropertyName = "CustomerBillingZip"
        Me.CustomerBillingZipDataGridViewTextBoxColumn.HeaderText = "CustomerBillingZip"
        Me.CustomerBillingZipDataGridViewTextBoxColumn.Name = "CustomerBillingZipDataGridViewTextBoxColumn"
        '
        'CustomerShipAddr1DataGridViewTextBoxColumn
        '
        Me.CustomerShipAddr1DataGridViewTextBoxColumn.DataPropertyName = "CustomerShipAddr1"
        Me.CustomerShipAddr1DataGridViewTextBoxColumn.HeaderText = "CustomerShipAddr1"
        Me.CustomerShipAddr1DataGridViewTextBoxColumn.Name = "CustomerShipAddr1DataGridViewTextBoxColumn"
        '
        'CustomerShipAddr2DataGridViewTextBoxColumn
        '
        Me.CustomerShipAddr2DataGridViewTextBoxColumn.DataPropertyName = "CustomerShipAddr2"
        Me.CustomerShipAddr2DataGridViewTextBoxColumn.HeaderText = "CustomerShipAddr2"
        Me.CustomerShipAddr2DataGridViewTextBoxColumn.Name = "CustomerShipAddr2DataGridViewTextBoxColumn"
        '
        'CustomerShipAddr3DataGridViewTextBoxColumn
        '
        Me.CustomerShipAddr3DataGridViewTextBoxColumn.DataPropertyName = "CustomerShipAddr3"
        Me.CustomerShipAddr3DataGridViewTextBoxColumn.HeaderText = "CustomerShipAddr3"
        Me.CustomerShipAddr3DataGridViewTextBoxColumn.Name = "CustomerShipAddr3DataGridViewTextBoxColumn"
        '
        'CustomerShipCityDataGridViewTextBoxColumn
        '
        Me.CustomerShipCityDataGridViewTextBoxColumn.DataPropertyName = "CustomerShipCity"
        Me.CustomerShipCityDataGridViewTextBoxColumn.HeaderText = "CustomerShipCity"
        Me.CustomerShipCityDataGridViewTextBoxColumn.Name = "CustomerShipCityDataGridViewTextBoxColumn"
        '
        'CustomerShipStateDataGridViewTextBoxColumn
        '
        Me.CustomerShipStateDataGridViewTextBoxColumn.DataPropertyName = "CustomerShipState"
        Me.CustomerShipStateDataGridViewTextBoxColumn.HeaderText = "CustomerShipState"
        Me.CustomerShipStateDataGridViewTextBoxColumn.Name = "CustomerShipStateDataGridViewTextBoxColumn"
        '
        'CustomerShipZipDataGridViewTextBoxColumn
        '
        Me.CustomerShipZipDataGridViewTextBoxColumn.DataPropertyName = "CustomerShipZip"
        Me.CustomerShipZipDataGridViewTextBoxColumn.HeaderText = "CustomerShipZip"
        Me.CustomerShipZipDataGridViewTextBoxColumn.Name = "CustomerShipZipDataGridViewTextBoxColumn"
        '
        'CustomerStartDateDataGridViewTextBoxColumn
        '
        Me.CustomerStartDateDataGridViewTextBoxColumn.DataPropertyName = "CustomerStartDate"
        Me.CustomerStartDateDataGridViewTextBoxColumn.HeaderText = "CustomerStartDate"
        Me.CustomerStartDateDataGridViewTextBoxColumn.Name = "CustomerStartDateDataGridViewTextBoxColumn"
        '
        'CustomerInvoiceDOMDataGridViewTextBoxColumn
        '
        Me.CustomerInvoiceDOMDataGridViewTextBoxColumn.DataPropertyName = "CustomerInvoiceDOM"
        Me.CustomerInvoiceDOMDataGridViewTextBoxColumn.HeaderText = "CustomerInvoiceDOM"
        Me.CustomerInvoiceDOMDataGridViewTextBoxColumn.Name = "CustomerInvoiceDOMDataGridViewTextBoxColumn"
        '
        'CustomerLastInvoiceDateDataGridViewTextBoxColumn
        '
        Me.CustomerLastInvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "CustomerLastInvoiceDate"
        Me.CustomerLastInvoiceDateDataGridViewTextBoxColumn.HeaderText = "CustomerLastInvoiceDate"
        Me.CustomerLastInvoiceDateDataGridViewTextBoxColumn.Name = "CustomerLastInvoiceDateDataGridViewTextBoxColumn"
        '
        'CustomerBindingSource
        '
        Me.CustomerBindingSource.DataMember = "Customer"
        Me.CustomerBindingSource.DataSource = Me.QBDataSet
        '
        'CustomerServiceTypeDataGridViewTextBoxColumn
        '
        Me.CustomerServiceTypeDataGridViewTextBoxColumn.DataPropertyName = "CustomerServiceType"
        Me.CustomerServiceTypeDataGridViewTextBoxColumn.HeaderText = "CustomerServiceType"
        Me.CustomerServiceTypeDataGridViewTextBoxColumn.Name = "CustomerServiceTypeDataGridViewTextBoxColumn"
        '
        'CustomerTableAdapter
        '
        Me.CustomerTableAdapter.ClearBeforeFill = True
        '
        'queryCustomer
        '
        Me.queryCustomer.AutoSize = True
        Me.queryCustomer.Location = New System.Drawing.Point(157, 132)
        Me.queryCustomer.Name = "queryCustomer"
        Me.queryCustomer.Size = New System.Drawing.Size(92, 23)
        Me.queryCustomer.TabIndex = 7
        Me.queryCustomer.Text = "Customer Query"
        Me.queryCustomer.UseVisualStyleBackColor = True
        '
        'customerQueryGrid
        '
        Me.customerQueryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.customerQueryGrid.Location = New System.Drawing.Point(157, 161)
        Me.customerQueryGrid.Name = "customerQueryGrid"
        Me.customerQueryGrid.Size = New System.Drawing.Size(240, 150)
        Me.customerQueryGrid.TabIndex = 8
        '
        'queryItem
        '
        Me.queryItem.Location = New System.Drawing.Point(10, 132)
        Me.queryItem.Name = "queryItem"
        Me.queryItem.Size = New System.Drawing.Size(75, 23)
        Me.queryItem.TabIndex = 9
        Me.queryItem.Text = "Item Query"
        Me.queryItem.UseVisualStyleBackColor = True
        '
        'itemGrid
        '
        Me.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemGrid.Location = New System.Drawing.Point(11, 161)
        Me.itemGrid.Name = "itemGrid"
        Me.itemGrid.Size = New System.Drawing.Size(140, 150)
        Me.itemGrid.TabIndex = 10
        '
        'AttachedTxnsBindingSource
        '
        Me.AttachedTxnsBindingSource.DataMember = "AttachedTxns"
        Me.AttachedTxnsBindingSource.DataSource = Me.QBDataSet
        '
        'AttachedTxnsTableAdapter
        '
        Me.AttachedTxnsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AttachedTxnsTableAdapter = Me.AttachedTxnsTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CalendarTableAdapter = Nothing
        Me.TableAdapterManager.CreditsTableAdapter = Nothing
        Me.TableAdapterManager.CustomerListTableAdapter = Nothing
        Me.TableAdapterManager.CustomerNotesTableAdapter = Nothing
        Me.TableAdapterManager.CustomerServiceTableAdapter = Nothing
        Me.TableAdapterManager.CustomerTableAdapter = Me.CustomerTableAdapter
        Me.TableAdapterManager.InvoicingTableAdapter = Nothing
        Me.TableAdapterManager.LineItemTableAdapter = Nothing
        Me.TableAdapterManager.NoteTypesTableAdapter = Nothing
        Me.TableAdapterManager.OverpaymentsTableAdapter = Nothing
        Me.TableAdapterManager.ServiceNotesTableAdapter = Nothing
        Me.TableAdapterManager.ServiceTypesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrashCash.QBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WorkingInvoiceTableAdapter = Nothing
        Me.TableAdapterManager.WorkingPaymentsTableAdapter = Nothing
        '
        'WorkingInvoiceBindingSource
        '
        Me.WorkingInvoiceBindingSource.DataMember = "WorkingInvoice"
        Me.WorkingInvoiceBindingSource.DataSource = Me.QBDataSet
        '
        'LineItemBindingSource
        '
        Me.LineItemBindingSource.DataMember = "LineItem"
        Me.LineItemBindingSource.DataSource = Me.QBDataSet
        '
        'LineItemTableAdapter
        '
        Me.LineItemTableAdapter.ClearBeforeFill = True
        '
        'WorkingInvoiceTableAdapter
        '
        Me.WorkingInvoiceTableAdapter.ClearBeforeFill = True
        '
        'testBtn
        '
        Me.testBtn.Location = New System.Drawing.Point(509, 113)
        Me.testBtn.Name = "testBtn"
        Me.testBtn.Size = New System.Drawing.Size(75, 23)
        Me.testBtn.TabIndex = 11
        Me.testBtn.Text = "Button1"
        Me.testBtn.UseVisualStyleBackColor = True
        '
        'testGrid1
        '
        Me.testGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.testGrid1.Location = New System.Drawing.Point(432, 161)
        Me.testGrid1.Name = "testGrid1"
        Me.testGrid1.Size = New System.Drawing.Size(215, 150)
        Me.testGrid1.TabIndex = 12
        '
        'testGrid2
        '
        Me.testGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.testGrid2.Location = New System.Drawing.Point(653, 161)
        Me.testGrid2.Name = "testGrid2"
        Me.testGrid2.Size = New System.Drawing.Size(215, 150)
        Me.testGrid2.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(205, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '
        'Testing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 505)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.testGrid2)
        Me.Controls.Add(Me.testGrid1)
        Me.Controls.Add(Me.testBtn)
        Me.Controls.Add(Me.itemGrid)
        Me.Controls.Add(Me.queryItem)
        Me.Controls.Add(Me.customerQueryGrid)
        Me.Controls.Add(Me.queryCustomer)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.sendToQBBtn)
        Me.Name = "Testing"
        Me.Text = "Testing"
        CType(Me.QBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customerQueryGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.itemGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachedTxnsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LineItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QBDataSet As TrashCash.QBDataSet
    Friend WithEvents sendToQBBtn As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerTableAdapter As TrashCash.QBDataSetTableAdapters.CustomerTableAdapter
    Friend WithEvents CustomerNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerEditSeqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPhoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerAltPhoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerContactDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingAddr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingAddr2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingAddr3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingCityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingStateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerBillingZipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipAddr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipAddr2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipAddr3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipCityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipStateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShipZipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerServiceTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDiscountPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPickupDayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerInvoiceDOMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerLastBillingPeriodDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerLastInvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerInvoiceScheduleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIsActiveDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents queryCustomer As System.Windows.Forms.Button
    Friend WithEvents customerQueryGrid As System.Windows.Forms.DataGridView
    Friend WithEvents queryItem As System.Windows.Forms.Button
    Friend WithEvents itemGrid As System.Windows.Forms.DataGridView
    Friend WithEvents AttachedTxnsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AttachedTxnsTableAdapter As TrashCash.QBDataSetTableAdapters.AttachedTxnsTableAdapter
    Friend WithEvents TableAdapterManager As TrashCash.QBDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LineItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LineItemTableAdapter As TrashCash.QBDataSetTableAdapters.LineItemTableAdapter
    Friend WithEvents WorkingInvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingInvoiceTableAdapter As TrashCash.QBDataSetTableAdapters.WorkingInvoiceTableAdapter
    Friend WithEvents testBtn As System.Windows.Forms.Button
    Friend WithEvents testGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents testGrid2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
