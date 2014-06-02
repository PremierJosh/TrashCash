Imports TrashCash.Classes

Namespace Admin.Payments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UC_BankMaint
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
            Dim BankBounceFeeLabel As System.Windows.Forms.Label
            Dim lbl_vendorSelInfo As System.Windows.Forms.Label
            Dim lbl_BankInvItem As System.Windows.Forms.Label
            Me.BAD_CHECK_BANKSTableAdapter = New TrashCash.ds_PaymentsTableAdapters.BAD_CHECK_BANKSTableAdapter()
            Me.pnl_BankSelection = New System.Windows.Forms.Panel()
            Me.tb_BankFee = New CurrencyTextBox()
            Me.cmb_BankAccs = New System.Windows.Forms.ComboBox()
            Me.cmb_BanksInvItem = New System.Windows.Forms.ComboBox()
            Me.cmb_VendorAcc = New System.Windows.Forms.ComboBox()
            Me.lbl_BankSelecInfo = New System.Windows.Forms.Label()
            Me.lbl_BankName = New System.Windows.Forms.Label()
            Me.tb_BankName = New System.Windows.Forms.TextBox()
            Me.ds_Application = New TrashCash.ds_Application()
            BankBounceFeeLabel = New System.Windows.Forms.Label()
            lbl_vendorSelInfo = New System.Windows.Forms.Label()
            lbl_BankInvItem = New System.Windows.Forms.Label()
            Me.pnl_BankSelection.SuspendLayout()
            CType(Me.ds_Application, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BankBounceFeeLabel
            '
            BankBounceFeeLabel.AutoSize = True
            BankBounceFeeLabel.Location = New System.Drawing.Point(156, 93)
            BankBounceFeeLabel.Name = "BankBounceFeeLabel"
            BankBounceFeeLabel.Size = New System.Drawing.Size(220, 13)
            BankBounceFeeLabel.TabIndex = 48
            BankBounceFeeLabel.Text = "Fee this Bank charges for a Bounced Check."
            '
            'lbl_vendorSelInfo
            '
            lbl_vendorSelInfo.Location = New System.Drawing.Point(174, 67)
            lbl_vendorSelInfo.Name = "lbl_vendorSelInfo"
            lbl_vendorSelInfo.Size = New System.Drawing.Size(202, 17)
            lbl_vendorSelInfo.TabIndex = 46
            lbl_vendorSelInfo.Text = "This is the Vendor account for this Bank."
            '
            'lbl_BankInvItem
            '
            lbl_BankInvItem.Location = New System.Drawing.Point(13, 36)
            lbl_BankInvItem.Name = "lbl_BankInvItem"
            lbl_BankInvItem.Size = New System.Drawing.Size(363, 31)
            lbl_BankInvItem.TabIndex = 50
            lbl_BankInvItem.Text = "This is the Quickbooks Item that relates to this Bank Account for returned items." & _
                                   ""
            '
            '
            'BAD_CHECK_BANKSTableAdapter
            '
            Me.BAD_CHECK_BANKSTableAdapter.ClearBeforeFill = True
            '
            'pnl_BankSelection
            '
            Me.pnl_BankSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_BankSelection.Controls.Add(Me.tb_BankFee)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_BankAccs)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_BanksInvItem)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_VendorAcc)
            Me.pnl_BankSelection.Controls.Add(BankBounceFeeLabel)
            Me.pnl_BankSelection.Controls.Add(Me.lbl_BankSelecInfo)
            Me.pnl_BankSelection.Controls.Add(lbl_vendorSelInfo)
            Me.pnl_BankSelection.Controls.Add(lbl_BankInvItem)
            Me.pnl_BankSelection.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_BankSelection.Location = New System.Drawing.Point(0, 36)
            Me.pnl_BankSelection.Name = "pnl_BankSelection"
            Me.pnl_BankSelection.Size = New System.Drawing.Size(574, 118)
            Me.pnl_BankSelection.TabIndex = 1
            '
            'tb_BankFee
            '
            Me.tb_BankFee.Location = New System.Drawing.Point(382, 91)
            Me.tb_BankFee.Name = "tb_BankFee"
            Me.tb_BankFee.Size = New System.Drawing.Size(62, 20)
            Me.tb_BankFee.TabIndex = 64
            '
            'cmb_BankAccs
            '
            Me.cmb_BankAccs.FormattingEnabled = True
            Me.cmb_BankAccs.Location = New System.Drawing.Point(382, 3)
            Me.cmb_BankAccs.Name = "cmb_BankAccs"
            Me.cmb_BankAccs.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BankAccs.TabIndex = 63
            '
            'cmb_BanksInvItem
            '
            Me.cmb_BanksInvItem.FormattingEnabled = True
            Me.cmb_BanksInvItem.Location = New System.Drawing.Point(382, 33)
            Me.cmb_BanksInvItem.Name = "cmb_BanksInvItem"
            Me.cmb_BanksInvItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BanksInvItem.TabIndex = 62
            '
            'cmb_VendorAcc
            '
            Me.cmb_VendorAcc.FormattingEnabled = True
            Me.cmb_VendorAcc.Location = New System.Drawing.Point(382, 64)
            Me.cmb_VendorAcc.Name = "cmb_VendorAcc"
            Me.cmb_VendorAcc.Size = New System.Drawing.Size(187, 21)
            Me.cmb_VendorAcc.TabIndex = 61
            '
            'lbl_BankSelecInfo
            '
            Me.lbl_BankSelecInfo.AutoSize = True
            Me.lbl_BankSelecInfo.Location = New System.Drawing.Point(10, 6)
            Me.lbl_BankSelecInfo.Name = "lbl_BankSelecInfo"
            Me.lbl_BankSelecInfo.Size = New System.Drawing.Size(366, 13)
            Me.lbl_BankSelecInfo.TabIndex = 59
            Me.lbl_BankSelecInfo.Text = "This is the Quickbooks Bank Account that could recieve a Bounced Check."
            '
            'lbl_BankName
            '
            Me.lbl_BankName.AutoSize = True
            Me.lbl_BankName.Location = New System.Drawing.Point(127, 11)
            Me.lbl_BankName.Name = "lbl_BankName"
            Me.lbl_BankName.Size = New System.Drawing.Size(131, 13)
            Me.lbl_BankName.TabIndex = 67
            Me.lbl_BankName.Text = "Name of this Bank setting:"
            '
            'tb_BankName
            '
            Me.tb_BankName.Location = New System.Drawing.Point(258, 8)
            Me.tb_BankName.Name = "tb_BankName"
            Me.tb_BankName.Size = New System.Drawing.Size(163, 20)
            Me.tb_BankName.TabIndex = 66
            '
            'ds_App
            '
            Me.ds_Application.DataSetName = "ds_App"
            Me.ds_Application.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'UC_BankMaint
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.lbl_BankName)
            Me.Controls.Add(Me.tb_BankName)
            Me.Controls.Add(Me.pnl_BankSelection)
            Me.Name = "UC_BankMaint"
            Me.Size = New System.Drawing.Size(574, 154)
            Me.pnl_BankSelection.ResumeLayout(False)
            Me.pnl_BankSelection.PerformLayout()
            CType(Me.ds_Application, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BAD_CHECK_BANKSTableAdapter As TrashCash.ds_PaymentsTableAdapters.BAD_CHECK_BANKSTableAdapter
        Friend WithEvents pnl_BankSelection As System.Windows.Forms.Panel
        Friend WithEvents tb_BankFee As CurrencyTextBox
        Friend WithEvents cmb_BankAccs As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_BanksInvItem As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_VendorAcc As System.Windows.Forms.ComboBox
        Friend WithEvents lbl_BankSelecInfo As System.Windows.Forms.Label
        Friend WithEvents lbl_BankName As System.Windows.Forms.Label
        Friend WithEvents tb_BankName As System.Windows.Forms.TextBox
        Friend WithEvents ds_Application As TrashCash.ds_Application

    End Class
End Namespace