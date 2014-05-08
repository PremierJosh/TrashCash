Imports Calendar
Imports Calendar.NET
Imports Calendar.NET.CalendarViews
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalendarView
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
        Me.Calendar = New Calendar.NET.Calendar()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.pnl_Left.SuspendLayout()
        Me.SuspendLayout()
        '
        'Calendar
        '
        Me.Calendar.AllowEditingEvents = False
        Me.Calendar.CalendarDate = New Date(2014, 1, 31, 0, 0, 0, 0)
        Me.Calendar.CalendarView = CalendarViews.Month
        Me.Calendar.DateHeaderFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar.DayOfWeekFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar.DaysFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar.DayViewTimeFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar.DimDisabledEvents = True
        Me.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calendar.HighlightCurrentDay = True
        Me.Calendar.LoadPresetHolidays = True
        Me.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.Calendar.Name = "Calendar"
        Me.Calendar.ShowArrowControls = True
        Me.Calendar.ShowDashedBorderOnDisabledEvents = True
        Me.Calendar.ShowDateInHeader = True
        Me.Calendar.ShowDisabledEvents = False
        Me.Calendar.ShowEventTooltips = True
        Me.Calendar.ShowTodayButton = True
        Me.Calendar.Size = New System.Drawing.Size(579, 508)
        Me.Calendar.TabIndex = 0
        Me.Calendar.TodayFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_Left
        '
        Me.pnl_Left.Controls.Add(Me.Calendar)
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_Left.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Size = New System.Drawing.Size(579, 508)
        Me.pnl_Left.TabIndex = 1
        '
        'CalendarView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 508)
        Me.Controls.Add(Me.pnl_Left)
        Me.Name = "CalendarView"
        Me.Text = "CalendarView"
        Me.pnl_Left.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendar As Calendar.NET.Calendar
    Friend WithEvents pnl_Left As System.Windows.Forms.Panel
End Class
