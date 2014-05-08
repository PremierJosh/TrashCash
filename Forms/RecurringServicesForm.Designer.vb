<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecurringServicesForm
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
        Me.sc_Master = New System.Windows.Forms.SplitContainer()
        Me.UC_RecSrvcDetails = New TrashCash.UC_RecSrvcDetails()
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
        Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
        Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
        Me.UC_CustomerInfoBoxes = New TrashCash.UC_CustomerInfoBoxes()
        CType(Me.sc_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sc_Master.Panel1.SuspendLayout()
        Me.sc_Master.Panel2.SuspendLayout()
        Me.sc_Master.SuspendLayout()
        Me.tc_Master.SuspendLayout()
        Me.tc_p_CustNotes.SuspendLayout()
        Me.tc_p_CustInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'sc_Master
        '
        Me.sc_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc_Master.IsSplitterFixed = True
        Me.sc_Master.Location = New System.Drawing.Point(0, 0)
        Me.sc_Master.Name = "sc_Master"
        Me.sc_Master.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'sc_Master.Panel1
        '
        Me.sc_Master.Panel1.Controls.Add(Me.UC_RecSrvcDetails)
        '
        'sc_Master.Panel2
        '
        Me.sc_Master.Panel2.Controls.Add(Me.tc_Master)
        Me.sc_Master.Size = New System.Drawing.Size(914, 437)
        Me.sc_Master.SplitterDistance = 217
        Me.sc_Master.TabIndex = 3
        '
        'UC_RecSrvcDetails
        '
        Me.UC_RecSrvcDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_RecSrvcDetails.Location = New System.Drawing.Point(0, 0)
        Me.UC_RecSrvcDetails.Name = "UC_RecSrvcDetails"
        Me.UC_RecSrvcDetails.RecurringServiceID = 0
        Me.UC_RecSrvcDetails.Size = New System.Drawing.Size(914, 217)
        Me.UC_RecSrvcDetails.TabIndex = 5
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
        Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Master.Location = New System.Drawing.Point(0, 0)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(914, 216)
        Me.tc_Master.TabIndex = 2
        '
        'tc_p_CustNotes
        '
        Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
        Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
        Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustNotes.Size = New System.Drawing.Size(906, 190)
        Me.tc_p_CustNotes.TabIndex = 2
        Me.tc_p_CustNotes.Text = "Customer Notes"
        '
        'UC_CustomerNotes
        '
        Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
        Me.UC_CustomerNotes.Size = New System.Drawing.Size(900, 184)
        Me.UC_CustomerNotes.TabIndex = 0
        '
        'tc_p_CustInfo
        '
        Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
        Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
        Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustInfo.Size = New System.Drawing.Size(906, 190)
        Me.tc_p_CustInfo.TabIndex = 0
        Me.tc_p_CustInfo.Text = "Customer Information"
        '
        'UC_CustomerInfoBoxes
        '
        Me.UC_CustomerInfoBoxes.CurrentCustomer = 0
        Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerInfoBoxes.isUpdating = False
        Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
        Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(900, 184)
        Me.UC_CustomerInfoBoxes.TabIndex = 0
        '
        'RecurringServicesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 437)
        Me.Controls.Add(Me.sc_Master)
        Me.Name = "RecurringServicesForm"
        Me.Text = "TrashCash | Recurring Service Details"
        Me.sc_Master.Panel1.ResumeLayout(False)
        Me.sc_Master.Panel2.ResumeLayout(False)
        CType(Me.sc_Master, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc_Master.ResumeLayout(False)
        Me.tc_Master.ResumeLayout(False)
        Me.tc_p_CustNotes.ResumeLayout(False)
        Me.tc_p_CustInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sc_Master As System.Windows.Forms.SplitContainer
    Friend WithEvents UC_RecSrvcDetails As TrashCash.UC_RecSrvcDetails
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerInfoBoxes As TrashCash.UC_CustomerInfoBoxes
    Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
End Class
