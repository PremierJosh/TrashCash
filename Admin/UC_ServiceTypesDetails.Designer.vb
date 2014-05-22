Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UC_ServiceTypesDetails
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
            Dim ServiceNameLabel As System.Windows.Forms.Label
            Dim ServiceRateLabel As System.Windows.Forms.Label
            Dim ServiceDescriptionLabel As System.Windows.Forms.Label
            Dim ServiceBillLengthLabel As System.Windows.Forms.Label
            Me.DataSet = New TrashCash.DataSet()
            Me.ServiceTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ServiceTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter()
            Me.tb_ServiceName = New System.Windows.Forms.TextBox()
            Me.tb_ServiceDescription = New System.Windows.Forms.TextBox()
            Me.tb_ServiceBillLength = New System.Windows.Forms.TextBox()
            Me.btn_SaveChanges = New System.Windows.Forms.Button()
            Me.ServiceActiveCheckBox = New System.Windows.Forms.CheckBox()
            Me.lbl_Account = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmb_IncomeAcc = New System.Windows.Forms.ComboBox()
            Me.tb_ServiceRate = New System.Windows.Forms.TextBox()
            ServiceNameLabel = New System.Windows.Forms.Label()
            ServiceRateLabel = New System.Windows.Forms.Label()
            ServiceDescriptionLabel = New System.Windows.Forms.Label()
            ServiceBillLengthLabel = New System.Windows.Forms.Label()
            CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ServiceNameLabel
            '
            ServiceNameLabel.AutoSize = True
            ServiceNameLabel.Location = New System.Drawing.Point(11, 14)
            ServiceNameLabel.Name = "ServiceNameLabel"
            ServiceNameLabel.Size = New System.Drawing.Size(77, 13)
            ServiceNameLabel.TabIndex = 3
            ServiceNameLabel.Text = "Service Name:"
            '
            'ServiceRateLabel
            '
            ServiceRateLabel.AutoSize = True
            ServiceRateLabel.Location = New System.Drawing.Point(11, 70)
            ServiceRateLabel.Name = "ServiceRateLabel"
            ServiceRateLabel.Size = New System.Drawing.Size(72, 13)
            ServiceRateLabel.TabIndex = 9
            ServiceRateLabel.Text = "Service Rate:"
            '
            'ServiceDescriptionLabel
            '
            ServiceDescriptionLabel.AutoSize = True
            ServiceDescriptionLabel.Location = New System.Drawing.Point(11, 122)
            ServiceDescriptionLabel.Name = "ServiceDescriptionLabel"
            ServiceDescriptionLabel.Size = New System.Drawing.Size(102, 13)
            ServiceDescriptionLabel.TabIndex = 11
            ServiceDescriptionLabel.Text = "Service Description:"
            '
            'ServiceBillLengthLabel
            '
            ServiceBillLengthLabel.AutoSize = True
            ServiceBillLengthLabel.Location = New System.Drawing.Point(11, 96)
            ServiceBillLengthLabel.Name = "ServiceBillLengthLabel"
            ServiceBillLengthLabel.Size = New System.Drawing.Size(98, 13)
            ServiceBillLengthLabel.TabIndex = 13
            ServiceBillLengthLabel.Text = "Service Bill Length:"
            '
            'DataSet
            '
            Me.DataSet.DataSetName = "DataSet"
            Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ServiceTypesBindingSource
            '
            Me.ServiceTypesBindingSource.DataMember = "ServiceTypes"
            Me.ServiceTypesBindingSource.DataSource = Me.DataSet
            '
            'ServiceTypesTableAdapter
            '
            Me.ServiceTypesTableAdapter.ClearBeforeFill = True
            '
            'tb_ServiceName
            '
            Me.tb_ServiceName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceTypesBindingSource, "ServiceName", True))
            Me.tb_ServiceName.Location = New System.Drawing.Point(138, 11)
            Me.tb_ServiceName.Name = "tb_ServiceName"
            Me.tb_ServiceName.Size = New System.Drawing.Size(172, 20)
            Me.tb_ServiceName.TabIndex = 4
            '
            'tb_ServiceDescription
            '
            Me.tb_ServiceDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceTypesBindingSource, "ServiceDescription", True))
            Me.tb_ServiceDescription.Location = New System.Drawing.Point(136, 119)
            Me.tb_ServiceDescription.Multiline = True
            Me.tb_ServiceDescription.Name = "tb_ServiceDescription"
            Me.tb_ServiceDescription.Size = New System.Drawing.Size(172, 68)
            Me.tb_ServiceDescription.TabIndex = 12
            '
            'tb_ServiceBillLength
            '
            Me.tb_ServiceBillLength.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceTypesBindingSource, "ServiceBillLength", True))
            Me.tb_ServiceBillLength.Location = New System.Drawing.Point(136, 93)
            Me.tb_ServiceBillLength.Name = "tb_ServiceBillLength"
            Me.tb_ServiceBillLength.Size = New System.Drawing.Size(49, 20)
            Me.tb_ServiceBillLength.TabIndex = 14
            '
            'btn_SaveChanges
            '
            Me.btn_SaveChanges.AutoSize = True
            Me.btn_SaveChanges.Location = New System.Drawing.Point(158, 206)
            Me.btn_SaveChanges.Name = "btn_SaveChanges"
            Me.btn_SaveChanges.Size = New System.Drawing.Size(87, 23)
            Me.btn_SaveChanges.TabIndex = 15
            Me.btn_SaveChanges.Text = "Save Changes"
            Me.btn_SaveChanges.UseVisualStyleBackColor = True
            '
            'ServiceActiveCheckBox
            '
            Me.ServiceActiveCheckBox.AutoSize = True
            Me.ServiceActiveCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.ServiceTypesBindingSource, "ServiceActive", True))
            Me.ServiceActiveCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ServiceActiveCheckBox.ForeColor = System.Drawing.Color.Red
            Me.ServiceActiveCheckBox.Location = New System.Drawing.Point(24, 165)
            Me.ServiceActiveCheckBox.Name = "ServiceActiveCheckBox"
            Me.ServiceActiveCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ServiceActiveCheckBox.Size = New System.Drawing.Size(64, 20)
            Me.ServiceActiveCheckBox.TabIndex = 16
            Me.ServiceActiveCheckBox.Text = "Active"
            Me.ServiceActiveCheckBox.UseVisualStyleBackColor = True
            '
            'lbl_Account
            '
            Me.lbl_Account.AutoSize = True
            Me.lbl_Account.Location = New System.Drawing.Point(11, 41)
            Me.lbl_Account.Name = "lbl_Account"
            Me.lbl_Account.Size = New System.Drawing.Size(110, 13)
            Me.lbl_Account.TabIndex = 17
            Me.lbl_Account.Text = "Quickbooks Account:"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(141, 190)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(162, 13)
            Me.Label1.TabIndex = 19
            Me.Label1.Text = "This is what prints on an Invoice."
            '
            'cmb_IncomeAcc
            '
            Me.cmb_IncomeAcc.FormattingEnabled = True
            Me.cmb_IncomeAcc.Location = New System.Drawing.Point(138, 37)
            Me.cmb_IncomeAcc.Name = "cmb_IncomeAcc"
            Me.cmb_IncomeAcc.Size = New System.Drawing.Size(172, 21)
            Me.cmb_IncomeAcc.TabIndex = 20
            '
            'tb_ServiceRate
            '
            Me.tb_ServiceRate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceTypesBindingSource, "ServiceRate", True))
            Me.tb_ServiceRate.Location = New System.Drawing.Point(136, 67)
            Me.tb_ServiceRate.Name = "tb_ServiceRate"
            Me.tb_ServiceRate.Size = New System.Drawing.Size(77, 20)
            Me.tb_ServiceRate.TabIndex = 10
            '
            'UC_ServiceTypesDetails
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.cmb_IncomeAcc)
            Me.Controls.Add(Me.lbl_Account)
            Me.Controls.Add(Me.ServiceActiveCheckBox)
            Me.Controls.Add(Me.btn_SaveChanges)
            Me.Controls.Add(ServiceNameLabel)
            Me.Controls.Add(Me.tb_ServiceName)
            Me.Controls.Add(ServiceRateLabel)
            Me.Controls.Add(Me.tb_ServiceRate)
            Me.Controls.Add(ServiceDescriptionLabel)
            Me.Controls.Add(Me.tb_ServiceDescription)
            Me.Controls.Add(ServiceBillLengthLabel)
            Me.Controls.Add(Me.tb_ServiceBillLength)
            Me.Name = "UC_ServiceTypesDetails"
            Me.Size = New System.Drawing.Size(321, 232)
            CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents DataSet As TrashCash.DataSet
        Friend WithEvents ServiceTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ServiceTypesTableAdapter As TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter
        Friend WithEvents tb_ServiceName As System.Windows.Forms.TextBox
        Friend WithEvents tb_ServiceDescription As System.Windows.Forms.TextBox
        Friend WithEvents tb_ServiceBillLength As System.Windows.Forms.TextBox
        Friend WithEvents btn_SaveChanges As System.Windows.Forms.Button
        Friend WithEvents ServiceActiveCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents lbl_Account As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmb_IncomeAcc As System.Windows.Forms.ComboBox
        Friend WithEvents tb_ServiceRate As System.Windows.Forms.TextBox

    End Class
End Namespace