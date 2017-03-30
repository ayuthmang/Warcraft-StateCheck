Imports System.Runtime.InteropServices
Imports System.Threading

Public Class frm_Main

    Dim Radio_Checked As Integer = -1
    Public _Memory As GFunction.Memory
    <DllImport("user32.dll")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Private Declare Auto Function IsIconic Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As ShowWindowCommands) As Boolean
    End Function
    Enum ShowWindowCommands As Integer
        ''' <summary>
        ''' Hides the window and activates another window.
        ''' </summary>
        Hide = 0
        ''' <summary>
        ''' Activates and displays a window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when displaying the window
        ''' for the first time.
        ''' </summary>
        Normal = 1
        ''' <summary>
        ''' Activates the window and displays it as a minimized window.
        ''' </summary>
        ShowMinimized = 2
        ''' <summary>
        ''' Maximizes the specified window.
        ''' </summary>
        Maximize = 3
        ' is this the right value?
        ''' <summary>
        ''' Activates the window and displays it as a maximized window.
        ''' </summary>      
        ShowMaximized = 3
        ''' <summary>
        ''' Displays a window in its most recent size and position. This value
        ''' is similar to <see cref="Win32.ShowWindowCommands.Normal"/>, except
        ''' the window is not actived.
        ''' </summary>
        ShowNoActivate = 4
        ''' <summary>
        ''' Activates the window and displays it in its current size and position.
        ''' </summary>
        Show = 5
        ''' <summary>
        ''' Minimizes the specified window and activates the next top-level
        ''' window in the Z order.
        ''' </summary>
        Minimize = 6
        ''' <summary>
        ''' Displays the window as a minimized window. This value is similar to
        ''' <see cref="Win32.ShowWindowCommands.ShowMinimized"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowMinNoActive = 7
        ''' <summary>
        ''' Displays the window in its current size and position. This value is
        ''' similar to <see cref="Win32.ShowWindowCommands.Show"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowNA = 8
        ''' <summary>
        ''' Activates and displays the window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when restoring a minimized window.
        ''' </summary>
        Restore = 9
        ''' <summary>
        ''' Sets the show state based on the SW_* value specified in the
        ''' STARTUPINFO structure passed to the CreateProcess function by the
        ''' program that started the application.
        ''' </summary>
        ShowDefault = 10
        ''' <summary>
        '''  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        ''' that owns the window is not responding. This flag should only be
        ''' used when minimizing windows from a different thread.
        ''' </summary>
        ForceMinimize = 11
    End Enum

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr,
            ByVal Msg As UInteger,
            ByVal wParam As IntPtr,
            ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImportAttribute("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function


    Private Sub rdb_Autofocus_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Autofocus.MouseEnter
        ToolTip_Info.Show("Auto focus when Game started.", rdb_Autofocus)
    End Sub
    Private Sub rdb_Autofocus_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Autofocus.MouseLeave
        ToolTip_Info.Hide(rdb_Autofocus)
    End Sub
    Private Sub ThemeMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ThemeMain.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            'SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 1) '112 'F012
            SendMessage(Me.Handle, &H112, &HF012, 1)
        End If
    End Sub


    Private Sub rdb_Msgbox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Msgbox.MouseEnter
        ToolTip_Info.Show("Show messagebox when Game Started.", rdb_Msgbox)
    End Sub

    Private Sub rdb_Msgbox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Msgbox.MouseLeave
        ToolTip_Info.Hide(rdb_Msgbox)
    End Sub

    Private Sub rdb_Soundplayer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Soundplayer.MouseEnter
        ToolTip_Info.Show("Show messagebox when Game Started.", rdb_Soundplayer)
    End Sub

    Private Sub rdb_Soundplayer_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Soundplayer.MouseLeave
        ToolTip_Info.Hide(rdb_Soundplayer)
    End Sub

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub bbtn_Minimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Enable.Click
        If btn_Enable.Text.ToLower = "enable state check" Then
            tmr_ReadMemory.Start()
            btn_Enable.Text = "Disable state check"

        Else
            tmr_ReadMemory.Stop()
            tmr_ReadMemory2.Stop()
            btn_Enable.Text = "Enable state check"
        End If
    End Sub

    Private Sub tmr_CheckAvalibleProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_CheckAvalibleProcess.Tick
        If Process.GetProcessesByName("Cybergames").Length > 0 Then
            If Process.GetProcessesByName("war3").Length > 0 Then
                btn_Enable.Enabled = True
            Else
                btn_Enable.Enabled = False
            End If
        Else : btn_Enable.Enabled = False
        End If
    End Sub

    Private Sub frm_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case My.Settings.radioSave
            Case 1
                rdb_Autofocus.Checked = True
            Case 2
                rdb_Msgbox.Checked = True
            Case 3
                rdb_Soundplayer.Checked = True
        End Select
        tmr_CheckAvalibleProcess.Start()
    End Sub

    Private Sub tmr_ReadMemory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_ReadMemory.Tick
        If Process.GetProcessesByName("Cybergames").Length > 0 Then
            If Process.GetProcessesByName("war3").Length > 0 Then
                _Memory.GetProcessHandle("war3")
                Dim adr As Integer = (_Memory.GetBaseAddress("Game.dll") + &HACE638)
                Dim value As Integer = _Memory.ReadInteger(adr)
                Select Case value
                    Case 229
                        lb_State.Text = "Waiting host start game"
                        tmr_ReadMemory2.Start()
                        tmr_ReadMemory.Stop()
                End Select
            End If
        End If

    End Sub

    Private Sub tmr_ReadMemory2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_ReadMemory2.Tick
        If Process.GetProcessesByName("Cybergames").Length > 0 Then
            If Process.GetProcessesByName("war3").Length > 0 Then
                _Memory.GetProcessHandle("war3")
                Dim adr As Integer = (_Memory.GetBaseAddress("Game.dll") + &HACE638)
                Dim value As Integer = _Memory.ReadInteger(adr)
                Select Case value
                    Case 63
                        tmr_ReadMemory2.Stop()
                        tmr_ReadMemory.Start()
                        tmr_AddText.Stop()
                        lb_State.Text = "You were kicked"
                        If Radio_Checked = 1 Then
                            If IsIconic(Process.GetProcessesByName("war3")(0).MainWindowHandle) = True Then
                                ShowWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle, ShowWindowCommands.Restore)
                                SetForegroundWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle)
                            Else
                                SetForegroundWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle)
                            End If
                          ElseIf Radio_Checked = 2 Then
                            MessageBox.Show("You were kicked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Radio_Checked = 3 Then
                            My.Computer.Audio.Play(My.Resources.You_were_kicked, AudioPlayMode.Background)
                        End If
                    Case 14
                        tmr_AddText.Stop()
                        lb_State.Text = "Loading map"
                    Case 404
                        tmr_ReadMemory2.Stop()
                        tmr_ReadMemory.Start()
                        tmr_AddText.Stop()
                        lb_State.Text = "Game started"
                        If Radio_Checked = 1 Then
                            If IsIconic(Process.GetProcessesByName("war3")(0).MainWindowHandle) = True Then
                                ShowWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle, ShowWindowCommands.Restore)
                                SetForegroundWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle)
                            Else
                                SetForegroundWindow(Process.GetProcessesByName("war3")(0).MainWindowHandle)
                            End If
                        ElseIf Radio_Checked = 2 Then
                            MessageBox.Show("Game started", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        ElseIf Radio_Checked = 3 Then
                            My.Computer.Audio.Play(My.Resources.Game_Started, AudioPlayMode.Background)
                        End If
                End Select
            End If
        End If
    End Sub


    Private Sub lb_State_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lb_State.TextChanged
        Select Case lb_State.Text
            Case "Waiting host start game"
                lb_State.ForeColor = Color.DarkGoldenrod
                tmr_AddText.Start()
            Case "Waiting host start game.........."
                lb_State.Text = "Waiting host start game"
            Case "You were kicked"
                lb_State.ForeColor = Color.HotPink
                tmr_AddText.Stop()
            Case "Loading map"
                lb_State.ForeColor = Color.Lime
            Case "Loading map..................."
                lb_State.Text = "Loading map"
                lb_State.ForeColor = Color.Lime
            Case "Game started"
                lb_State.ForeColor = Color.LimeGreen
        End Select
    End Sub

    Private Sub tmr_AddText_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_AddText.Tick
        lb_State.Text += "."
    End Sub

    Private Sub rdb_Autofocus_CheckedChanged(ByVal sender As System.Object) Handles rdb_Autofocus.CheckedChanged
        If rdb_Autofocus.Checked = True Then
            Radio_Checked = 1
        End If
    End Sub

    Private Sub rdb_Msgbox_CheckedChanged(ByVal sender As System.Object) Handles rdb_Msgbox.CheckedChanged
        If rdb_Msgbox.Checked = True Then
            Radio_Checked = 2
        End If
    End Sub

    Private Sub rdb_Soundplayer_CheckedChanged(ByVal sender As System.Object) Handles rdb_Soundplayer.CheckedChanged
        If rdb_Soundplayer.Checked = True Then
            Radio_Checked = 3
        End If
    End Sub

    Private Sub frm_Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.radioSave = Radio_Checked
    End Sub

End Class