<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrashCash_Admin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrashCash_Admin))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lbl_AdminUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_Admin = New System.Windows.Forms.ToolStrip()
        Me.btn_AdminPay = New System.Windows.Forms.ToolStripButton()
        Me.btn_ServiceTypes = New System.Windows.Forms.ToolStripButton()
        Me.btn_Banks = New System.Windows.Forms.ToolStripButton()
        Me.btn_Defaults = New System.Windows.Forms.ToolStripButton()
        Me.btn_ExportImport = New System.Windows.Forms.ToolStripButton()
        Me.btn_InvTypes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip.SuspendLayout()
        Me.ts_Admin.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_AdminUser})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(848, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lbl_AdminUser
        '
        Me.lbl_AdminUser.Name = "lbl_AdminUser"
        Me.lbl_AdminUser.Size = New System.Drawing.Size(115, 17)
        Me.lbl_AdminUser.Text = "Current Admin User:"
        '
        'ts_Admin
        '
        Me.ts_Admin.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_Admin.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_AdminPay, Me.ToolStripSeparator5, Me.btn_ServiceTypes, Me.ToolStripSeparator4, Me.btn_Banks, Me.ToolStripSeparator2, Me.btn_Defaults, Me.btn_ExportImport, Me.ToolStripSeparator3, Me.btn_InvTypes, Me.ToolStripSeparator1})
        Me.ts_Admin.Location = New System.Drawing.Point(0, 0)
        Me.ts_Admin.Name = "ts_Admin"
        Me.ts_Admin.Size = New System.Drawing.Size(848, 25)
        Me.ts_Admin.TabIndex = 9
        Me.ts_Admin.Text = "ToolStrip1"
        '
        'btn_AdminPay
        '
        Me.btn_AdminPay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_AdminPay.Image = CType(resources.GetObject("btn_AdminPay.Image"), System.Drawing.Image)
        Me.btn_AdminPay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_AdminPay.Name = "btn_AdminPay"
        Me.btn_AdminPay.Size = New System.Drawing.Size(63, 22)
        Me.btn_AdminPay.Text = "Payments"
        '
        'btn_ServiceTypes
        '
        Me.btn_ServiceTypes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_ServiceTypes.Image = CType(resources.GetObject("btn_ServiceTypes.Image"), System.Drawing.Image)
        Me.btn_ServiceTypes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ServiceTypes.Name = "btn_ServiceTypes"
        Me.btn_ServiceTypes.Size = New System.Drawing.Size(82, 22)
        Me.btn_ServiceTypes.Text = "Service Types"
        '
        'btn_Banks
        '
        Me.btn_Banks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Banks.Image = CType(resources.GetObject("btn_Banks.Image"), System.Drawing.Image)
        Me.btn_Banks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Banks.Name = "btn_Banks"
        Me.btn_Banks.Size = New System.Drawing.Size(141, 22)
        Me.btn_Banks.Text = "Banks (Bounced Checks)"
        '
        'btn_Defaults
        '
        Me.btn_Defaults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Defaults.Image = CType(resources.GetObject("btn_Defaults.Image"), System.Drawing.Image)
        Me.btn_Defaults.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Defaults.Name = "btn_Defaults"
        Me.btn_Defaults.Size = New System.Drawing.Size(103, 22)
        Me.btn_Defaults.Text = "Program Defaults"
        '
        'btn_ExportImport
        '
        Me.btn_ExportImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_ExportImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_ExportImport.ForeColor = System.Drawing.Color.Red
        Me.btn_ExportImport.Image = CType(resources.GetObject("btn_ExportImport.Image"), System.Drawing.Image)
        Me.btn_ExportImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ExportImport.Name = "btn_ExportImport"
        Me.btn_ExportImport.Size = New System.Drawing.Size(85, 22)
        Me.btn_ExportImport.Text = "Import/Export"
        '
        'btn_InvTypes
        '
        Me.btn_InvTypes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_InvTypes.Image = CType(resources.GetObject("btn_InvTypes.Image"), System.Drawing.Image)
        Me.btn_InvTypes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_InvTypes.Name = "btn_InvTypes"
        Me.btn_InvTypes.Size = New System.Drawing.Size(83, 22)
        Me.btn_InvTypes.Text = "Invoice Types"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'TrashCash_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 453)
        Me.Controls.Add(Me.ts_Admin)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.Name = "TrashCash_Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administration Home"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ts_Admin.ResumeLayout(False)
        Me.ts_Admin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_AdminUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ts_Admin As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_AdminPay As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ServiceTypes As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Banks As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Defaults As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ExportImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_InvTypes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
