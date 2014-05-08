<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankMaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankMaint))
        Me.ts_Top = New System.Windows.Forms.ToolStrip()
        Me.btn_AddBank = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Ts_cmb_BadCheckBanks = New TrashCash.Database_ComboBoxes.ts_cmb_BadCheckBanks()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_ModBank = New System.Windows.Forms.ToolStripButton()
        Me.btn_SaveChanges = New System.Windows.Forms.ToolStripButton()
        Me.btn_DeleteBank = New System.Windows.Forms.ToolStripButton()
        Me.pnl_Spacer = New System.Windows.Forms.Panel()
        Me.UC_BankMaint = New TrashCash.UC_BankMaint()
        Me.ts_Top.SuspendLayout()
        Me.pnl_Spacer.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_Top
        '
        Me.ts_Top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_AddBank, Me.ToolStripSeparator1, Me.Ts_cmb_BadCheckBanks, Me.ToolStripSeparator2, Me.btn_ModBank, Me.btn_SaveChanges, Me.btn_DeleteBank})
        Me.ts_Top.Location = New System.Drawing.Point(0, 0)
        Me.ts_Top.Name = "ts_Top"
        Me.ts_Top.Size = New System.Drawing.Size(582, 25)
        Me.ts_Top.TabIndex = 0
        Me.ts_Top.Text = "ToolStrip1"
        '
        'btn_AddBank
        '
        Me.btn_AddBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_AddBank.Image = CType(resources.GetObject("btn_AddBank.Image"), System.Drawing.Image)
        Me.btn_AddBank.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_AddBank.Name = "btn_AddBank"
        Me.btn_AddBank.Size = New System.Drawing.Size(89, 22)
        Me.btn_AddBank.Text = "Add New Bank"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Ts_cmb_BadCheckBanks
        '
        Me.Ts_cmb_BadCheckBanks.Name = "Ts_cmb_BadCheckBanks"
        Me.Ts_cmb_BadCheckBanks.Size = New System.Drawing.Size(200, 25)
        Me.Ts_cmb_BadCheckBanks.Text = "testing2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btn_ModBank
        '
        Me.btn_ModBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_ModBank.Image = CType(resources.GetObject("btn_ModBank.Image"), System.Drawing.Image)
        Me.btn_ModBank.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ModBank.Name = "btn_ModBank"
        Me.btn_ModBank.Size = New System.Drawing.Size(49, 22)
        Me.btn_ModBank.Text = "Modify"
        '
        'btn_SaveChanges
        '
        Me.btn_SaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_SaveChanges.Image = CType(resources.GetObject("btn_SaveChanges.Image"), System.Drawing.Image)
        Me.btn_SaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_SaveChanges.Name = "btn_SaveChanges"
        Me.btn_SaveChanges.Size = New System.Drawing.Size(84, 22)
        Me.btn_SaveChanges.Text = "Save Changes"
        Me.btn_SaveChanges.Visible = False
        '
        'btn_DeleteBank
        '
        Me.btn_DeleteBank.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_DeleteBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_DeleteBank.ForeColor = System.Drawing.Color.Red
        Me.btn_DeleteBank.Image = CType(resources.GetObject("btn_DeleteBank.Image"), System.Drawing.Image)
        Me.btn_DeleteBank.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_DeleteBank.Name = "btn_DeleteBank"
        Me.btn_DeleteBank.Size = New System.Drawing.Size(73, 22)
        Me.btn_DeleteBank.Text = "Delete Bank"
        Me.btn_DeleteBank.Visible = False
        '
        'pnl_Spacer
        '
        Me.pnl_Spacer.Controls.Add(Me.UC_BankMaint)
        Me.pnl_Spacer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Spacer.Location = New System.Drawing.Point(0, 25)
        Me.pnl_Spacer.Name = "pnl_Spacer"
        Me.pnl_Spacer.Padding = New System.Windows.Forms.Padding(5)
        Me.pnl_Spacer.Size = New System.Drawing.Size(582, 163)
        Me.pnl_Spacer.TabIndex = 1
        '
        'UC_BankMaint
        '
        Me.UC_BankMaint.CurrentBankID = 0
        Me.UC_BankMaint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_BankMaint.Location = New System.Drawing.Point(5, 5)
        Me.UC_BankMaint.Name = "UC_BankMaint"
        Me.UC_BankMaint.Size = New System.Drawing.Size(572, 153)
        Me.UC_BankMaint.TabIndex = 0
        Me.UC_BankMaint.Visible = False
        '
        'BankMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 188)
        Me.Controls.Add(Me.pnl_Spacer)
        Me.Controls.Add(Me.ts_Top)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BankMaint"
        Me.Text = "Bank Maintenance"
        Me.ts_Top.ResumeLayout(False)
        Me.ts_Top.PerformLayout()
        Me.pnl_Spacer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_AddBank As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_ModBank As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_SaveChanges As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnl_Spacer As System.Windows.Forms.Panel
    Friend WithEvents btn_DeleteBank As System.Windows.Forms.ToolStripButton
    Friend WithEvents UC_BankMaint As TrashCash.UC_BankMaint
    Friend WithEvents Ts_cmb_BadCheckBanks As TrashCash.Database_ComboBoxes.ts_cmb_BadCheckBanks
End Class
