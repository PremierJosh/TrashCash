<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecSrvcNote
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.srvcEndDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.srvcStartDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.srvcTotalBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.custNameBox = New System.Windows.Forms.TextBox()
        Me.srvcNameBox = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(269, 298)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(87, 13)
        Label1.TabIndex = 63
        Label1.Text = "Character Count:"
        '
        'addNoteBtn
        '
        Me.addNoteBtn.AutoSize = True
        Me.addNoteBtn.Location = New System.Drawing.Point(10, 302)
        Me.addNoteBtn.Name = "addNoteBtn"
        Me.addNoteBtn.Size = New System.Drawing.Size(62, 23)
        Me.addNoteBtn.TabIndex = 65
        Me.addNoteBtn.Text = "Add Note"
        Me.addNoteBtn.UseVisualStyleBackColor = True
        '
        'countLbl
        '
        Me.countLbl.Location = New System.Drawing.Point(351, 299)
        Me.countLbl.Name = "countLbl"
        Me.countLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.countLbl.Size = New System.Drawing.Size(27, 14)
        Me.countLbl.TabIndex = 66
        Me.countLbl.Text = "0"
        '
        'noteTextBox
        '
        Me.noteTextBox.Location = New System.Drawing.Point(12, 106)
        Me.noteTextBox.MaxLength = 500
        Me.noteTextBox.Multiline = True
        Me.noteTextBox.Name = "noteTextBox"
        Me.noteTextBox.Size = New System.Drawing.Size(363, 190)
        Me.noteTextBox.TabIndex = 67
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(144, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "End:"
        '
        'srvcEndDatePicker
        '
        Me.srvcEndDatePicker.Enabled = False
        Me.srvcEndDatePicker.Location = New System.Drawing.Point(179, 82)
        Me.srvcEndDatePicker.Name = "srvcEndDatePicker"
        Me.srvcEndDatePicker.Size = New System.Drawing.Size(196, 20)
        Me.srvcEndDatePicker.TabIndex = 72
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Start:"
        '
        'srvcStartDatePicker
        '
        Me.srvcStartDatePicker.Enabled = False
        Me.srvcStartDatePicker.Location = New System.Drawing.Point(179, 60)
        Me.srvcStartDatePicker.Name = "srvcStartDatePicker"
        Me.srvcStartDatePicker.Size = New System.Drawing.Size(196, 20)
        Me.srvcStartDatePicker.TabIndex = 70
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Total:"
        '
        'srvcTotalBox
        '
        Me.srvcTotalBox.Location = New System.Drawing.Point(67, 66)
        Me.srvcTotalBox.Name = "srvcTotalBox"
        Me.srvcTotalBox.ReadOnly = True
        Me.srvcTotalBox.Size = New System.Drawing.Size(48, 20)
        Me.srvcTotalBox.TabIndex = 68
        Me.srvcTotalBox.Text = "$100.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Customer:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Service:"
        '
        'custNameBox
        '
        Me.custNameBox.Location = New System.Drawing.Point(67, 6)
        Me.custNameBox.Name = "custNameBox"
        Me.custNameBox.ReadOnly = True
        Me.custNameBox.Size = New System.Drawing.Size(308, 20)
        Me.custNameBox.TabIndex = 76
        Me.custNameBox.Text = "Fife Abby - 1000"
        '
        'srvcNameBox
        '
        Me.srvcNameBox.Location = New System.Drawing.Point(67, 32)
        Me.srvcNameBox.Name = "srvcNameBox"
        Me.srvcNameBox.ReadOnly = True
        Me.srvcNameBox.Size = New System.Drawing.Size(308, 20)
        Me.srvcNameBox.TabIndex = 77
        Me.srvcNameBox.Text = "2yd Dumpster - Wednesday"
        '
        'RecSrvcNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 333)
        Me.Controls.Add(Me.srvcNameBox)
        Me.Controls.Add(Me.custNameBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.srvcEndDatePicker)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.srvcStartDatePicker)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.srvcTotalBox)
        Me.Controls.Add(Me.noteTextBox)
        Me.Controls.Add(Me.countLbl)
        Me.Controls.Add(Me.addNoteBtn)
        Me.Controls.Add(Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecSrvcNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Recurring Service Note"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents addNoteBtn As System.Windows.Forms.Button
    Friend WithEvents countLbl As System.Windows.Forms.Label
    Friend WithEvents noteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents srvcEndDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents srvcStartDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents srvcTotalBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents custNameBox As System.Windows.Forms.TextBox
    Friend WithEvents srvcNameBox As System.Windows.Forms.TextBox
End Class
