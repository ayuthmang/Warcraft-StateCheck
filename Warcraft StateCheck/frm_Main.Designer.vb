<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.ToolTip_Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmr_CheckAvalibleProcess = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_ReadMemory = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_ReadMemory2 = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_AddText = New System.Windows.Forms.Timer(Me.components)
        Me.ThemeMain = New Warcraft_StateCheck.PositronTheme()
        Me.PositronDivider1 = New Warcraft_StateCheck.PositronDivider()
        Me.btn_Enable = New Warcraft_StateCheck.PositronButton()
        Me.btn_Minimize = New Warcraft_StateCheck.PositronButton()
        Me.btn_Close = New Warcraft_StateCheck.PositronButton()
        Me.lb_State = New Warcraft_StateCheck.PositronLabel()
        Me.lb_Status = New Warcraft_StateCheck.PositronLabel()
        Me.rdb_Soundplayer = New Warcraft_StateCheck.PositronRadioButton()
        Me.rdb_Msgbox = New Warcraft_StateCheck.PositronRadioButton()
        Me.rdb_Autofocus = New Warcraft_StateCheck.PositronRadioButton()
        Me.ThemeMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip_Info
        '
        Me.ToolTip_Info.ToolTipTitle = "Info"
        '
        'tmr_CheckAvalibleProcess
        '
        '
        'tmr_ReadMemory
        '
        '
        'tmr_ReadMemory2
        '
        '
        'tmr_AddText
        '
        Me.tmr_AddText.Interval = 250
        '
        'ThemeMain
        '
        Me.ThemeMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ThemeMain.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ThemeMain.Controls.Add(Me.PositronDivider1)
        Me.ThemeMain.Controls.Add(Me.btn_Enable)
        Me.ThemeMain.Controls.Add(Me.btn_Minimize)
        Me.ThemeMain.Controls.Add(Me.btn_Close)
        Me.ThemeMain.Controls.Add(Me.lb_State)
        Me.ThemeMain.Controls.Add(Me.lb_Status)
        Me.ThemeMain.Controls.Add(Me.rdb_Soundplayer)
        Me.ThemeMain.Controls.Add(Me.rdb_Msgbox)
        Me.ThemeMain.Controls.Add(Me.rdb_Autofocus)
        Me.ThemeMain.Customization = "0NDQ/2RkZP8AAAD/0tLS/9zc3P/IyMj/lpaW/w=="
        Me.ThemeMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThemeMain.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ThemeMain.Image = Nothing
        Me.ThemeMain.Location = New System.Drawing.Point(0, 0)
        Me.ThemeMain.Movable = True
        Me.ThemeMain.Name = "ThemeMain"
        Me.ThemeMain.NoRounding = False
        Me.ThemeMain.Sizable = False
        Me.ThemeMain.Size = New System.Drawing.Size(290, 164)
        Me.ThemeMain.SmartBounds = True
        Me.ThemeMain.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ThemeMain.TabIndex = 0
        Me.ThemeMain.Text = "Warcraft State Check 1.26a for DotA"
        Me.ThemeMain.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ThemeMain.Transparent = False
        '
        'PositronDivider1
        '
        Me.PositronDivider1.BackColor = System.Drawing.Color.Transparent
        Me.PositronDivider1.Colors = New Warcraft_StateCheck.Bloom(-1) {}
        Me.PositronDivider1.Customization = ""
        Me.PositronDivider1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PositronDivider1.Image = Nothing
        Me.PositronDivider1.Location = New System.Drawing.Point(3, 64)
        Me.PositronDivider1.Name = "PositronDivider1"
        Me.PositronDivider1.NoRounding = False
        Me.PositronDivider1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.PositronDivider1.Size = New System.Drawing.Size(275, 14)
        Me.PositronDivider1.TabIndex = 10
        Me.PositronDivider1.Text = "PositronDivider1"
        Me.PositronDivider1.Transparent = True
        '
        'btn_Enable
        '
        Me.btn_Enable.Customization = "3Nzc/8jIyP9kZGT/lpaW/8jIyP/S0tL/"
        Me.btn_Enable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Enable.Image = Nothing
        Me.btn_Enable.Location = New System.Drawing.Point(54, 32)
        Me.btn_Enable.Name = "btn_Enable"
        Me.btn_Enable.NoRounding = False
        Me.btn_Enable.Size = New System.Drawing.Size(177, 30)
        Me.btn_Enable.TabIndex = 9
        Me.btn_Enable.Text = "Enable state check"
        Me.btn_Enable.Transparent = False
        '
        'btn_Minimize
        '
        Me.btn_Minimize.Customization = "3Nzc/8jIyP9kZGT/lpaW/8jIyP/S0tL/"
        Me.btn_Minimize.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Minimize.Image = Nothing
        Me.btn_Minimize.Location = New System.Drawing.Point(245, 3)
        Me.btn_Minimize.Name = "btn_Minimize"
        Me.btn_Minimize.NoRounding = False
        Me.btn_Minimize.Size = New System.Drawing.Size(20, 20)
        Me.btn_Minimize.TabIndex = 8
        Me.btn_Minimize.Text = "_"
        Me.btn_Minimize.Transparent = False
        '
        'btn_Close
        '
        Me.btn_Close.Customization = "3Nzc/8jIyP9kZGT/lpaW/8jIyP/S0tL/"
        Me.btn_Close.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Close.Image = Nothing
        Me.btn_Close.Location = New System.Drawing.Point(267, 3)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.NoRounding = False
        Me.btn_Close.Size = New System.Drawing.Size(20, 20)
        Me.btn_Close.TabIndex = 7
        Me.btn_Close.Text = "X"
        Me.btn_Close.Transparent = False
        '
        'lb_State
        '
        Me.lb_State.AutoSize = True
        Me.lb_State.BackColor = System.Drawing.Color.Transparent
        Me.lb_State.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lb_State.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lb_State.Location = New System.Drawing.Point(69, 137)
        Me.lb_State.Name = "lb_State"
        Me.lb_State.Size = New System.Drawing.Size(58, 13)
        Me.lb_State.TabIndex = 6
        Me.lb_State.Text = "Unknow"
        '
        'lb_Status
        '
        Me.lb_Status.AutoSize = True
        Me.lb_Status.BackColor = System.Drawing.Color.Transparent
        Me.lb_Status.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lb_Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lb_Status.Location = New System.Drawing.Point(15, 137)
        Me.lb_Status.Name = "lb_Status"
        Me.lb_Status.Size = New System.Drawing.Size(52, 13)
        Me.lb_Status.TabIndex = 5
        Me.lb_Status.Text = "Status:"
        '
        'rdb_Soundplayer
        '
        Me.rdb_Soundplayer.Checked = False
        Me.rdb_Soundplayer.Customization = "ZGRk/6+vr//IyMj/lpaW/w=="
        Me.rdb_Soundplayer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rdb_Soundplayer.Image = Nothing
        Me.rdb_Soundplayer.Location = New System.Drawing.Point(95, 112)
        Me.rdb_Soundplayer.Name = "rdb_Soundplayer"
        Me.rdb_Soundplayer.NoRounding = False
        Me.rdb_Soundplayer.Size = New System.Drawing.Size(111, 22)
        Me.rdb_Soundplayer.TabIndex = 4
        Me.rdb_Soundplayer.Text = "Sound player"
        Me.rdb_Soundplayer.Transparent = False
        '
        'rdb_Msgbox
        '
        Me.rdb_Msgbox.Checked = False
        Me.rdb_Msgbox.Customization = "ZGRk/6+vr//IyMj/lpaW/w=="
        Me.rdb_Msgbox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rdb_Msgbox.Image = Nothing
        Me.rdb_Msgbox.Location = New System.Drawing.Point(140, 84)
        Me.rdb_Msgbox.Name = "rdb_Msgbox"
        Me.rdb_Msgbox.NoRounding = False
        Me.rdb_Msgbox.Size = New System.Drawing.Size(102, 22)
        Me.rdb_Msgbox.TabIndex = 3
        Me.rdb_Msgbox.Text = "Messagebox"
        Me.rdb_Msgbox.Transparent = False
        '
        'rdb_Autofocus
        '
        Me.rdb_Autofocus.Checked = True
        Me.rdb_Autofocus.Customization = "ZGRk/6+vr//IyMj/lpaW/w=="
        Me.rdb_Autofocus.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.rdb_Autofocus.Image = Nothing
        Me.rdb_Autofocus.Location = New System.Drawing.Point(46, 84)
        Me.rdb_Autofocus.Name = "rdb_Autofocus"
        Me.rdb_Autofocus.NoRounding = False
        Me.rdb_Autofocus.Size = New System.Drawing.Size(88, 22)
        Me.rdb_Autofocus.TabIndex = 2
        Me.rdb_Autofocus.Text = "Auto focus"
        Me.rdb_Autofocus.Transparent = False
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 164)
        Me.Controls.Add(Me.ThemeMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warcraft State Check"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ThemeMain.ResumeLayout(False)
        Me.ThemeMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ThemeMain As Warcraft_StateCheck.PositronTheme
    Friend WithEvents rdb_Soundplayer As Warcraft_StateCheck.PositronRadioButton
    Friend WithEvents rdb_Msgbox As Warcraft_StateCheck.PositronRadioButton
    Friend WithEvents rdb_Autofocus As Warcraft_StateCheck.PositronRadioButton
    Friend WithEvents ToolTip_Info As System.Windows.Forms.ToolTip
    Friend WithEvents lb_State As Warcraft_StateCheck.PositronLabel
    Friend WithEvents lb_Status As Warcraft_StateCheck.PositronLabel
    Friend WithEvents btn_Minimize As Warcraft_StateCheck.PositronButton
    Friend WithEvents btn_Close As Warcraft_StateCheck.PositronButton
    Friend WithEvents PositronDivider1 As Warcraft_StateCheck.PositronDivider
    Friend WithEvents btn_Enable As Warcraft_StateCheck.PositronButton
    Friend WithEvents tmr_CheckAvalibleProcess As System.Windows.Forms.Timer
    Friend WithEvents tmr_ReadMemory As System.Windows.Forms.Timer
    Friend WithEvents tmr_ReadMemory2 As System.Windows.Forms.Timer
    Friend WithEvents tmr_AddText As System.Windows.Forms.Timer
End Class
