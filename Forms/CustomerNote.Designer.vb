<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerNote
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
        Dim Label1 As System.Windows.Forms.Label
        Me.addNoteBtn = New System.Windows.Forms.Button()
        Me.countLbl = New System.Windows.Forms.Label()
        Me.noteTextBox = New System.Windows.Forms.TextBox()
        Me.lbl_CustName = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(247, 235)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(87, 13)
        Label1.TabIndex = 63
        Label1.Text = "Character Count:"
        '
        'addNoteBtn
        '
        Me.addNoteBtn.AutoSize = True
        Me.addNoteBtn.Location = New System.Drawing.Point(12, 238)
        Me.addNoteBtn.Name = "addNoteBtn"
        Me.addNoteBtn.Size = New System.Drawing.Size(62, 23)
        Me.addNoteBtn.TabIndex = 65
        Me.addNoteBtn.Text = "Add Note"
        Me.addNoteBtn.UseVisualStyleBackColor = True
        '
        'countLbl
        '
        Me.countLbl.Location = New System.Drawing.Point(341, 235)
        Me.countLbl.Name = "countLbl"
        Me.countLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.countLbl.Size = New System.Drawing.Size(27, 14)
        Me.countLbl.TabIndex = 66
        Me.countLbl.Text = "0"
        '
        'noteTextBox
        '
        Me.noteTextBox.Location = New System.Drawing.Point(12, 55)
        Me.noteTextBox.MaxLength = 500
        Me.noteTextBox.Multiline = True
        Me.noteTextBox.Name = "noteTextBox"
        Me.noteTextBox.Size = New System.Drawing.Size(353, 177)
        Me.noteTextBox.TabIndex = 67
        '
        'lbl_CustName
        '
        Me.lbl_CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CustName.Location = New System.Drawing.Point(12, 18)
        Me.lbl_CustName.Name = "lbl_CustName"
        Me.lbl_CustName.Size = New System.Drawing.Size(353, 23)
        Me.lbl_CustName.TabIndex = 68
        Me.lbl_CustName.Text = "Label2"
        Me.lbl_CustName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomerNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 273)
        Me.Controls.Add(Me.lbl_CustName)
        Me.Controls.Add(Me.noteTextBox)
        Me.Controls.Add(Me.countLbl)
        Me.Controls.Add(Me.addNoteBtn)
        Me.Controls.Add(Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomerNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Customer Note"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents addNoteBtn As System.Windows.Forms.Button
    Friend WithEvents countLbl As System.Windows.Forms.Label
    Friend WithEvents noteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CustName As System.Windows.Forms.Label
End Class
