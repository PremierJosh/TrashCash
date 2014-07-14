Namespace Batching
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BatchInterruption
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
            Me.pb_Batch = New System.Windows.Forms.ProgressBar()
            Me.lbl_Count = New System.Windows.Forms.Label()
            Me.lbl_CustName = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btn_FinBatch = New System.Windows.Forms.Button()
            Me.BatchWorker = New System.ComponentModel.BackgroundWorker()
            Me.SuspendLayout()
            '
            'pb_Batch
            '
            Me.pb_Batch.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pb_Batch.Location = New System.Drawing.Point(3, 117)
            Me.pb_Batch.Name = "pb_Batch"
            Me.pb_Batch.Size = New System.Drawing.Size(503, 23)
            Me.pb_Batch.TabIndex = 1
            '
            'lbl_Count
            '
            Me.lbl_Count.AutoSize = True
            Me.lbl_Count.Location = New System.Drawing.Point(440, 99)
            Me.lbl_Count.Name = "lbl_Count"
            Me.lbl_Count.Size = New System.Drawing.Size(60, 13)
            Me.lbl_Count.TabIndex = 2
            Me.lbl_Count.Text = "1000/1000"
            Me.lbl_Count.Visible = False
            '
            'lbl_CustName
            '
            Me.lbl_CustName.AutoSize = True
            Me.lbl_CustName.Location = New System.Drawing.Point(15, 100)
            Me.lbl_CustName.Name = "lbl_CustName"
            Me.lbl_CustName.Size = New System.Drawing.Size(134, 13)
            Me.lbl_CustName.TabIndex = 3
            Me.lbl_CustName.Text = "Customer Full Name - 1000"
            Me.lbl_CustName.Visible = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Location = New System.Drawing.Point(3, 3)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(503, 61)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "The previous batch did not complete. Please click the button below to finish it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You will be unable to use the application until the batch is completed."
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btn_FinBatch
            '
            Me.btn_FinBatch.Location = New System.Drawing.Point(217, 67)
            Me.btn_FinBatch.Name = "btn_FinBatch"
            Me.btn_FinBatch.Size = New System.Drawing.Size(75, 23)
            Me.btn_FinBatch.TabIndex = 5
            Me.btn_FinBatch.Text = "Finish Batch"
            Me.btn_FinBatch.UseVisualStyleBackColor = True
            '
            'BatchWorker
            '
            Me.BatchWorker.WorkerReportsProgress = True
            Me.BatchWorker.WorkerSupportsCancellation = True
            '
            'BatchInterruption
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(509, 143)
            Me.Controls.Add(Me.btn_FinBatch)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lbl_CustName)
            Me.Controls.Add(Me.lbl_Count)
            Me.Controls.Add(Me.pb_Batch)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "BatchInterruption"
            Me.Padding = New System.Windows.Forms.Padding(3)
            Me.Text = "Batch Correction"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents pb_Batch As System.Windows.Forms.ProgressBar
        Friend WithEvents lbl_Count As System.Windows.Forms.Label
        Friend WithEvents lbl_CustName As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btn_FinBatch As System.Windows.Forms.Button
        Friend WithEvents BatchWorker As System.ComponentModel.BackgroundWorker
    End Class
End Namespace