<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_CustomerNotes
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dg_CustNotes = New System.Windows.Forms.DataGridView()
        Me.Ds_Display = New TrashCash.ds_Display()
        Me.CustomerNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerNotesTableAdapter = New TrashCash.ds_DisplayTableAdapters.CustomerNotesTableAdapter()
        Me.CustomerNoteTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsertedByUserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerNoteDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dg_CustNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerNotesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_CustNotes
        '
        Me.dg_CustNotes.AllowUserToAddRows = False
        Me.dg_CustNotes.AllowUserToDeleteRows = False
        Me.dg_CustNotes.AutoGenerateColumns = False
        Me.dg_CustNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_CustNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNoteTextDataGridViewTextBoxColumn, Me.InsertedByUserDataGridViewTextBoxColumn, Me.CustomerNoteDateDataGridViewTextBoxColumn})
        Me.dg_CustNotes.DataSource = Me.CustomerNotesBindingSource
        Me.dg_CustNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_CustNotes.Location = New System.Drawing.Point(0, 0)
        Me.dg_CustNotes.Name = "dg_CustNotes"
        Me.dg_CustNotes.ReadOnly = True
        Me.dg_CustNotes.RowHeadersVisible = False
        Me.dg_CustNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_CustNotes.Size = New System.Drawing.Size(900, 171)
        Me.dg_CustNotes.TabIndex = 0
        '
        'Ds_Display
        '
        Me.Ds_Display.DataSetName = "ds_Display"
        Me.Ds_Display.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomerNotesBindingSource
        '
        Me.CustomerNotesBindingSource.DataMember = "CustomerNotes"
        Me.CustomerNotesBindingSource.DataSource = Me.Ds_Display
        '
        'CustomerNotesTableAdapter
        '
        Me.CustomerNotesTableAdapter.ClearBeforeFill = True
        '
        'CustomerNoteTextDataGridViewTextBoxColumn
        '
        Me.CustomerNoteTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerNoteTextDataGridViewTextBoxColumn.DataPropertyName = "CustomerNoteText"
        Me.CustomerNoteTextDataGridViewTextBoxColumn.HeaderText = "Note"
        Me.CustomerNoteTextDataGridViewTextBoxColumn.Name = "CustomerNoteTextDataGridViewTextBoxColumn"
        Me.CustomerNoteTextDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InsertedByUserDataGridViewTextBoxColumn
        '
        Me.InsertedByUserDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InsertedByUserDataGridViewTextBoxColumn.DataPropertyName = "InsertedByUser"
        Me.InsertedByUserDataGridViewTextBoxColumn.HeaderText = "User"
        Me.InsertedByUserDataGridViewTextBoxColumn.Name = "InsertedByUserDataGridViewTextBoxColumn"
        Me.InsertedByUserDataGridViewTextBoxColumn.ReadOnly = True
        Me.InsertedByUserDataGridViewTextBoxColumn.Width = 54
        '
        'CustomerNoteDateDataGridViewTextBoxColumn
        '
        Me.CustomerNoteDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CustomerNoteDateDataGridViewTextBoxColumn.DataPropertyName = "CustomerNoteDate"
        DataGridViewCellStyle1.Format = "d"
        Me.CustomerNoteDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CustomerNoteDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.CustomerNoteDateDataGridViewTextBoxColumn.Name = "CustomerNoteDateDataGridViewTextBoxColumn"
        Me.CustomerNoteDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerNoteDateDataGridViewTextBoxColumn.Width = 55
        '
        'UC_CustomerNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dg_CustNotes)
        Me.Name = "UC_CustomerNotes"
        Me.Size = New System.Drawing.Size(900, 171)
        CType(Me.dg_CustNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerNotesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_CustNotes As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerNoteTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertedByUserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNoteDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNotesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Display As TrashCash.ds_Display
    Friend WithEvents CustomerNotesTableAdapter As TrashCash.ds_DisplayTableAdapters.CustomerNotesTableAdapter

End Class
