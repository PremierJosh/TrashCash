<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerSearch
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
        Me.tb_Search = New System.Windows.Forms.TextBox()
        Me.lbl_SearchHeader = New System.Windows.Forms.Label()
        Me.dg_SearchRet = New System.Windows.Forms.DataGridView()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Addr1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Addr2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Addr3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerSearchAddressBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Customer = New TrashCash.ds_Customer()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.CustomerSearch_AddressTableAdapter = New TrashCash.ds_CustomerTableAdapters.CustomerSearch_AddressTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dg_SearchRet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerSearchAddressBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_Search
        '
        Me.tb_Search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_Search.Location = New System.Drawing.Point(256, 12)
        Me.tb_Search.Name = "tb_Search"
        Me.tb_Search.Size = New System.Drawing.Size(352, 20)
        Me.tb_Search.TabIndex = 0
        '
        'lbl_SearchHeader
        '
        Me.lbl_SearchHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_SearchHeader.AutoSize = True
        Me.lbl_SearchHeader.Location = New System.Drawing.Point(165, 14)
        Me.lbl_SearchHeader.Name = "lbl_SearchHeader"
        Me.lbl_SearchHeader.Size = New System.Drawing.Size(85, 13)
        Me.lbl_SearchHeader.TabIndex = 1
        Me.lbl_SearchHeader.Text = "Address Search:"
        '
        'dg_SearchRet
        '
        Me.dg_SearchRet.AllowUserToAddRows = False
        Me.dg_SearchRet.AllowUserToDeleteRows = False
        Me.dg_SearchRet.AllowUserToResizeRows = False
        Me.dg_SearchRet.AutoGenerateColumns = False
        Me.dg_SearchRet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg_SearchRet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullNameDataGridViewTextBoxColumn, Me.Addr1DataGridViewTextBoxColumn, Me.Addr2DataGridViewTextBoxColumn, Me.Addr3DataGridViewTextBoxColumn, Me.CityDataGridViewTextBoxColumn, Me.StateDataGridViewTextBoxColumn, Me.ZipDataGridViewTextBoxColumn})
        Me.dg_SearchRet.DataSource = Me.CustomerSearchAddressBindingSource
        Me.dg_SearchRet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_SearchRet.Location = New System.Drawing.Point(0, 49)
        Me.dg_SearchRet.Name = "dg_SearchRet"
        Me.dg_SearchRet.ReadOnly = True
        Me.dg_SearchRet.RowHeadersVisible = False
        Me.dg_SearchRet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_SearchRet.Size = New System.Drawing.Size(883, 334)
        Me.dg_SearchRet.TabIndex = 2
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Customer Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Addr1DataGridViewTextBoxColumn
        '
        Me.Addr1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Addr1DataGridViewTextBoxColumn.DataPropertyName = "Addr1"
        Me.Addr1DataGridViewTextBoxColumn.HeaderText = "Address 1"
        Me.Addr1DataGridViewTextBoxColumn.Name = "Addr1DataGridViewTextBoxColumn"
        Me.Addr1DataGridViewTextBoxColumn.ReadOnly = True
        Me.Addr1DataGridViewTextBoxColumn.Width = 79
        '
        'Addr2DataGridViewTextBoxColumn
        '
        Me.Addr2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Addr2DataGridViewTextBoxColumn.DataPropertyName = "Addr2"
        Me.Addr2DataGridViewTextBoxColumn.HeaderText = "Address 2"
        Me.Addr2DataGridViewTextBoxColumn.Name = "Addr2DataGridViewTextBoxColumn"
        Me.Addr2DataGridViewTextBoxColumn.ReadOnly = True
        Me.Addr2DataGridViewTextBoxColumn.Width = 79
        '
        'Addr3DataGridViewTextBoxColumn
        '
        Me.Addr3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Addr3DataGridViewTextBoxColumn.DataPropertyName = "Addr3"
        Me.Addr3DataGridViewTextBoxColumn.HeaderText = "Address 3"
        Me.Addr3DataGridViewTextBoxColumn.Name = "Addr3DataGridViewTextBoxColumn"
        Me.Addr3DataGridViewTextBoxColumn.ReadOnly = True
        Me.Addr3DataGridViewTextBoxColumn.Width = 79
        '
        'CityDataGridViewTextBoxColumn
        '
        Me.CityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CityDataGridViewTextBoxColumn.DataPropertyName = "City"
        Me.CityDataGridViewTextBoxColumn.HeaderText = "City"
        Me.CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
        Me.CityDataGridViewTextBoxColumn.ReadOnly = True
        Me.CityDataGridViewTextBoxColumn.Width = 49
        '
        'StateDataGridViewTextBoxColumn
        '
        Me.StateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.StateDataGridViewTextBoxColumn.DataPropertyName = "State"
        Me.StateDataGridViewTextBoxColumn.HeaderText = "State"
        Me.StateDataGridViewTextBoxColumn.Name = "StateDataGridViewTextBoxColumn"
        Me.StateDataGridViewTextBoxColumn.ReadOnly = True
        Me.StateDataGridViewTextBoxColumn.Width = 57
        '
        'ZipDataGridViewTextBoxColumn
        '
        Me.ZipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ZipDataGridViewTextBoxColumn.DataPropertyName = "Zip"
        Me.ZipDataGridViewTextBoxColumn.HeaderText = "Zip"
        Me.ZipDataGridViewTextBoxColumn.Name = "ZipDataGridViewTextBoxColumn"
        Me.ZipDataGridViewTextBoxColumn.ReadOnly = True
        Me.ZipDataGridViewTextBoxColumn.Width = 47
        '
        'CustomerSearchAddressBindingSource
        '
        Me.CustomerSearchAddressBindingSource.DataMember = "CustomerSearch_Address"
        Me.CustomerSearchAddressBindingSource.DataSource = Me.Ds_Customer
        '
        'Ds_Customer
        '
        Me.Ds_Customer.DataSetName = "ds_Customer"
        Me.Ds_Customer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btn_Search
        '
        Me.btn_Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Search.Location = New System.Drawing.Point(614, 10)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(93, 23)
        Me.btn_Search.TabIndex = 3
        Me.btn_Search.Text = "Search"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'CustomerSearch_AddressTableAdapter
        '
        Me.CustomerSearch_AddressTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tb_Search)
        Me.Panel1.Controls.Add(Me.btn_Search)
        Me.Panel1.Controls.Add(Me.lbl_SearchHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 49)
        Me.Panel1.TabIndex = 4
        '
        'CustomerSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 383)
        Me.Controls.Add(Me.dg_SearchRet)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CustomerSearch"
        Me.Text = "Customer Search"
        CType(Me.dg_SearchRet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerSearchAddressBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tb_Search As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SearchHeader As System.Windows.Forms.Label
    Friend WithEvents dg_SearchRet As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents Ds_Customer As TrashCash.ds_Customer
    Friend WithEvents CustomerSearch_AddressTableAdapter As TrashCash.ds_CustomerTableAdapters.CustomerSearch_AddressTableAdapter
    Friend WithEvents CustomerSearchAddressBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Addr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Addr2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Addr3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
