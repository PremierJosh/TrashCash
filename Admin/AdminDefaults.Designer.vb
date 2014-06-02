Imports TrashCash.Classes

Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminDefaults
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
            Dim lbl_CustInfoDesc As System.Windows.Forms.Label
            Dim lbl_CheckItem As System.Windows.Forms.Label
            Dim CustomerChargeRateLabel As System.Windows.Forms.Label
            Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.hdr_BadCheck = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.tb_BadCheckCustFee = New TrashCash.Classes.CurrencyTextBox()
            Me.cmb_BadCheckItem = New System.Windows.Forms.ComboBox()
            Me.cmb_BadCheckCustInvItem = New System.Windows.Forms.ComboBox()
            Me.btn_Save = New System.Windows.Forms.Button()
            lbl_CustInfoDesc = New System.Windows.Forms.Label()
            lbl_CheckItem = New System.Windows.Forms.Label()
            CustomerChargeRateLabel = New System.Windows.Forms.Label()
            Me.FlowLayoutPanel.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lbl_CustInfoDesc
            '
            lbl_CustInfoDesc.Location = New System.Drawing.Point(14, 32)
            lbl_CustInfoDesc.Name = "lbl_CustInfoDesc"
            lbl_CustInfoDesc.Size = New System.Drawing.Size(356, 22)
            lbl_CustInfoDesc.TabIndex = 56
            lbl_CustInfoDesc.Text = "This is the Quickbooks Item that represents our fee for the returned item."
            '
            'lbl_CheckItem
            '
            lbl_CheckItem.Location = New System.Drawing.Point(70, 5)
            lbl_CheckItem.Name = "lbl_CheckItem"
            lbl_CheckItem.Size = New System.Drawing.Size(300, 21)
            lbl_CheckItem.TabIndex = 47
            lbl_CheckItem.Text = "This is the Quickbooks Item that represents a returned check."
            '
            'CustomerChargeRateLabel
            '
            CustomerChargeRateLabel.AutoSize = True
            CustomerChargeRateLabel.Location = New System.Drawing.Point(155, 59)
            CustomerChargeRateLabel.Name = "CustomerChargeRateLabel"
            CustomerChargeRateLabel.Size = New System.Drawing.Size(205, 13)
            CustomerChargeRateLabel.TabIndex = 52
            CustomerChargeRateLabel.Text = "Our Fee for a Customer bouncing a check"
            '
            'FlowLayoutPanel
            '
            Me.FlowLayoutPanel.Controls.Add(Me.hdr_BadCheck)
            Me.FlowLayoutPanel.Controls.Add(Me.Panel1)
            Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
            Me.FlowLayoutPanel.Size = New System.Drawing.Size(593, 249)
            Me.FlowLayoutPanel.TabIndex = 1
            '
            'hdr_BadCheck
            '
            Me.hdr_BadCheck.AutoSize = True
            Me.hdr_BadCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.hdr_BadCheck.Location = New System.Drawing.Point(3, 0)
            Me.hdr_BadCheck.Name = "hdr_BadCheck"
            Me.hdr_BadCheck.Size = New System.Drawing.Size(143, 16)
            Me.hdr_BadCheck.TabIndex = 5
            Me.hdr_BadCheck.Text = "Bad Check Settings"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.tb_BadCheckCustFee)
            Me.Panel1.Controls.Add(Me.cmb_BadCheckItem)
            Me.Panel1.Controls.Add(Me.cmb_BadCheckCustInvItem)
            Me.Panel1.Controls.Add(lbl_CustInfoDesc)
            Me.Panel1.Controls.Add(lbl_CheckItem)
            Me.Panel1.Controls.Add(CustomerChargeRateLabel)
            Me.Panel1.Location = New System.Drawing.Point(3, 19)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(578, 90)
            Me.Panel1.TabIndex = 4
            '
            'tb_BadCheckCustFee
            '
            Me.tb_BadCheckCustFee.Location = New System.Drawing.Point(376, 56)
            Me.tb_BadCheckCustFee.Name = "tb_BadCheckCustFee"
            Me.tb_BadCheckCustFee.Size = New System.Drawing.Size(100, 20)
            Me.tb_BadCheckCustFee.TabIndex = 61
            '
            'cmb_BadCheckItem
            '
            Me.cmb_BadCheckItem.FormattingEnabled = True
            Me.cmb_BadCheckItem.Location = New System.Drawing.Point(376, 3)
            Me.cmb_BadCheckItem.Name = "cmb_BadCheckItem"
            Me.cmb_BadCheckItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BadCheckItem.TabIndex = 60
            '
            'cmb_BadCheckCustInvItem
            '
            Me.cmb_BadCheckCustInvItem.FormattingEnabled = True
            Me.cmb_BadCheckCustInvItem.Location = New System.Drawing.Point(376, 29)
            Me.cmb_BadCheckCustInvItem.Name = "cmb_BadCheckCustInvItem"
            Me.cmb_BadCheckCustInvItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BadCheckCustInvItem.TabIndex = 59
            '
            'btn_Save
            '
            Me.btn_Save.Location = New System.Drawing.Point(264, 264)
            Me.btn_Save.Name = "btn_Save"
            Me.btn_Save.Size = New System.Drawing.Size(75, 23)
            Me.btn_Save.TabIndex = 2
            Me.btn_Save.Text = "Save"
            Me.btn_Save.UseVisualStyleBackColor = True
            '
            'AdminDefaults
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(593, 299)
            Me.Controls.Add(Me.btn_Save)
            Me.Controls.Add(Me.FlowLayoutPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "AdminDefaults"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "TrashCash Defaults"
            Me.FlowLayoutPanel.ResumeLayout(False)
            Me.FlowLayoutPanel.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cmb_BadCheckItem As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_BadCheckCustInvItem As System.Windows.Forms.ComboBox
        Friend WithEvents hdr_BadCheck As System.Windows.Forms.Label
        Friend WithEvents tb_BadCheckCustFee As CurrencyTextBox
      Friend WithEvents btn_Save As System.Windows.Forms.Button
    End Class
End Namespace