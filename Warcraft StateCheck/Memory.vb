Imports System.IO
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class GFunction
    Public Structure Memory
        Dim qlvkoelbfkla23i928awefvfsf As Byte

        Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal Handle As Integer, ByVal address As Integer, ByRef Value As Int32, ByVal Size As Integer, ByRef lpNumberOfBytesWritten As Long) As Long
        Private Declare Function WriteFloatMemory Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
        Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal Handle As Integer, ByVal address As Integer, ByRef Value As Int32, ByVal Size As Integer, ByRef lpNumberOfBytesWritten As Long) As Long
        Private Declare Function ReadFloatMemory Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
        Public Declare Function VirtualProtectEx Lib "KERNEL32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal newProtect As MemroyProtection, ByRef oldProtect As Integer) As Boolean
        'Public Declare Function VirtualProtectEx Lib "KERNEL32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal newProtect As Integer, ByRef oldProtect As Integer) As Boolean
        Public Declare Function OpenProcess Lib "KERNEL32" (ByVal DesiredAccess As ProcessAccess, ByVal InheritHandle As Boolean, ByVal ProcessId As Int32) As Int32
        Public Shared pHandle As Integer
        Public Shared process_id As Int32

        Dim FlagValue As Integer

        <Flags()> _
        Public Enum ProcessAccess As Integer
            PROCESS_ALL_ACCESS = &H1F0FFF&
            PROCESS_CREATE_PROCESS = &H80
            PROCESS_CREATE_THREAD = &H2
            PROCESS_DUP_HANDLE = &H40
            PROCESS_HEAP_ENTRY_BUSY = &H4
            PROCESS_HEAP_ENTRY_DDESHARE = &H20
            PROCESS_HEAP_ENTRY_MOVEABLE = &H10
            PROCESS_HEAP_REGION = &H1
            PROCESS_HEAP_UNCOMMITTED_RANGE = &H2
            PROCESS_QUERY_INFORMATION = &H400
            PROCESS_SET_INFORMATION = &H200
            PROCESS_SET_QUOTA = &H100
            PROCESS_TERMINATE = &H1
            PROCESS_VM_OPERATION = &H8
            PROCESS_VM_READ = &H10
            PROCESS_VM_WRITE = &H20
            PROCESS_Synchronize = &H100000
            PROCESS_SUSPEND_RESUME = 2048
        End Enum
        <Flags()> _
        Public Enum MemroyProtection As Integer
            PAGE_NOACCESS = 1
            PAGE_READONLY = 2
            PAGE_READWRITE = 4
            PAGE_WRITECOPY = 8
            PAGE_EXECUTE = 16
            PAGE_EXECUTE_READ = 32
            PAGE_EXECUTE_READWRITE = 64
            PAGE_EXECUTE_WRITECOPY = 128
            PAGE_GUARD = 256
            PAGE_NOCACHE = 512
        End Enum
        Public Function GetProcessHandle(ByVal ProcessName As String) As Boolean 'Checks to see if the game is running (returns True or False) and sets the pHandle *REQUIRED TO USE*
            On Error Resume Next
            For Each p As Process In Process.GetProcessesByName(ProcessName)
                process_id = p.Id
                pHandle = OpenProcess(ProcessAccess.PROCESS_ALL_ACCESS, False, p.Id)
                Return True
            Next
            Return False
        End Function
        Public Sub RemoveProtection(ByVal AddressOfStart As Integer) 'Changes the protection of the page with the specified starting address to PAGE_EXECUTE_READWRITE
            On Error Resume Next
            Dim oldProtect As Integer
            If Not VirtualProtectEx(pHandle, New IntPtr(AddressOfStart), New IntPtr(2048), MemroyProtection.PAGE_EXECUTE_READWRITE, oldProtect) Then Throw New Win32Exception
        End Sub
        Public Function GetBaseAddress(ByVal ModuleName As String) As Integer
            Dim base As Integer
            For Each PM As ProcessModule In Process.GetProcessById(process_id).Modules
                If ModuleName.ToLower = PM.ModuleName.ToLower Then base = PM.BaseAddress
            Next
            Return base
        End Function
#Region "GConvert"
        Public Shared Function GetStringToArrayBytes(ByVal str As String) As Byte()
            Dim encoding As New System.Text.UTF8Encoding()
            Return encoding.GetBytes(str)
        End Function
        Public Shared Function GetArrayBytes(ByVal Value As String) As Byte()
            Dim strArray As String() = Value.Split(New Char() {" "})
            Dim buffer As Byte() = New Byte(strArray.Length - 1) {}
            Dim i As Integer
            For i = 0 To strArray.Length - 1
                buffer(i) = Convert.ToByte(strArray(i), &H10)
            Next i
            Return buffer
        End Function
#End Region
#Region "Write"
        Public Sub WriteMemoryPrivate(ByVal Address As Integer, ByVal Original As String, ByVal Patch As String, ByVal CheckBoxCheck As CheckBox)
            Dim buffori As Byte() = GetArrayBytes(Original)
            Dim buffnew As Byte() = GetArrayBytes(Patch)
            If CheckBoxCheck.Checked = True Then
                WriteASM(Address, buffnew)
            Else
                WriteASM(Address, buffori)
            End If
        End Sub
        Public Shared Function WriteString(ByVal Address As Integer, ByVal Text As String) As Boolean
            Dim sString As Byte() = GFunction.Memory.GetArrayBytes(Text)
            For i As Integer = LBound(sString) To UBound(sString)
                WriteByte(Address + i, sString(i))
            Next
        End Function
        Public Shared Sub WriteByte(ByVal Address As Integer, ByVal Value As Byte) 'Writes a single byte value
            WriteProcessMemory(pHandle, Address, Value, 1, 0)
        End Sub
        Public Sub WriteASM(ByVal Address As Int32, ByVal Value As Byte()) 'Writes assembly using bytes
            For i As Integer = LBound(Value) To UBound(Value)
                WriteByte(Address + i, Value(i))
            Next
        End Sub

        Public Sub WriteInteger(ByVal Address As Integer, ByVal Value As Integer) 'Writes a single byte value
            WriteProcessMemory(pHandle, Address, Value, 4, 0)
        End Sub
        Public Sub WriteFloat(ByVal Address As Integer, ByVal Value As Single) 'Writes a 2 bytes value
            WriteFloatMemory(pHandle, Address, Value, 4, 0)
        End Sub
        Public Sub WriteFloath4x(ByVal Address As Integer, ByVal Value As Long) 'Writes a 2 bytes value
            WriteFloatMemory(pHandle, Address, Value, 4, Nothing)
        End Sub
        Public Function WritePointer(ByVal Pointer As Int32, ByVal Buffer As Int32, ByVal OffSet As Int32()) 'Writes to a pointer
            For Each I As Integer In OffSet
                ReadProcessMemory(pHandle, Pointer, Pointer, 4, 0)
                Pointer += I
            Next
            WriteProcessMemory(pHandle, Pointer, Buffer, 4, 0)
            Return 0
        End Function
        Public Function WriteAddPointer(ByVal Pointer As Int32, ByVal Buffer As Int32, ByVal OffSet() As Int32) 'Adds a value to a pointer
            For Each I As Integer In OffSet
                ReadProcessMemory(pHandle, Pointer, Pointer, 4, 0)
                Pointer += I
            Next
            WriteProcessMemory(pHandle, Pointer, ReadInteger(Pointer) + Buffer, 4, 0)
            Return 0
        End Function
#End Region
#Region "Read"
        Public Shared Function ReadByte(ByVal Address As Int32) As Byte
            Dim value As Integer
            ReadProcessMemory(pHandle, Address, value, 1, 0)
            Return value
        End Function
        Public Function ReadInteger(ByVal Address As Int32) As Int32
            Dim value As Integer
            ReadProcessMemory(pHandle, Address, value, 4, 0)
            Return value
        End Function
        Public Function ReadFloat(ByVal Address As Int32) As Double
            Dim value As Single
            ReadFloatMemory(pHandle, Address, value, 4, 0)
            Return value
        End Function
        Public Function ReadFloath4x(ByVal Address As Int32) As Int32
            Dim value As Single
            ReadFloatMemory(pHandle, Address, value, 4, 0)
            Return value
        End Function
        Public Function ReadPointer(ByVal Pointer As Int32, ByRef Buffer As Int32, ByVal OffSet() As Int32) 'Reads a pointer value and returns it
            For Each I As Integer In OffSet
                ReadProcessMemory(pHandle, Pointer, Pointer, 4, 0)
                Pointer += I
            Next
            ReadProcessMemory(pHandle, Pointer, Buffer, 4, 0)
            Return 0
        End Function


#End Region
#Region "Other"
        Private Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As Integer, ByVal lpAddress As Integer, ByVal dwSize As Integer, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As Integer
        Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer() As Byte, ByVal nSize As Integer, ByVal lpNumberOfBytesWritten As UInteger) As Boolean
        Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
        Private Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Integer
        Private Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByVal lpThreadId As Integer) As Integer
        Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
        Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer

        Private Function Die(Optional ByVal hProc As Integer = Nothing, Optional ByVal libThread As Integer = Nothing) As Boolean
            If Not hProc = Nothing Then CloseHandle(hProc)
            If Not libThread = Nothing Then CloseHandle(libThread)
            Return False
        End Function
        Public Function InjectDll(ByVal dllLocation As String) As Boolean
            If IO.File.Exists(dllLocation) = False Then Return False 'if the dll doesn't exist, no point in continuing. So we return false.
            If IntPtr.Size = 8 Then Return False 'If the size of an IntPtr is 8, then is program was compiled as x64. x64 processes can't access x86 processes properly, so we just return false. You need to compile this program as x86.
            Dim hProcess As Integer = OpenProcess(&H1F0FFF, 1, process_id) 'We'll open the process specified by the input process ID. With PROCESS_ALL_ACCESS access, seeing as we only need to write.
            If hProcess = 0 Then Return Die() 'If we didn't get the handle, we exit and return false. No cleanup so no params for die()
            Dim dllBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(dllLocation + ControlChars.NullChar) 'As I mentioned earlier, we have to write the dll location as bytes to the process memory, so we take the bytes of the string using the standard encoding, adding a null byte at the end.
            Dim pathLocation As Integer = VirtualAllocEx(hProcess, 0, dllBytes.Length, &H1000, &H4) 'Allocate memory the size of the string we need to write to memory. pathLocation now holds the address of where the memory was allocated.
            If pathLocation = Nothing Then Return Die(hProcess) 'VirtualAllocEx returns Nothing when it fails, so we check for that and return false if we find it. We've opened a process handle so we have to pass that to Die to clean it up.
            Dim wpm As Integer = WriteProcessMemory(hProcess, pathLocation, dllBytes, dllBytes.Length, 0) 'write the contents of dllBytes to the memory allocated at pathLocation.
            If wpm = 0 Then Return Die(hProcess) ' WriteProcessMemory returns 0 if it fails.
            Dim kernelMod As Integer = GetModuleHandle("kernel32.dll") 'Remember what I was saying about kernel32 being loaded into the same address space for every normal process? This means we don't have to do any fancy crap to find its location in our target process, we can get the location in our own process and safely assume it will be the same for all process. This means we can use GetModuleHandle, which only works internally.
            Dim loadLibAddr As Integer = GetProcAddress(kernelMod, "LoadLibraryA") ' GetProcAddress gives us the address of the specified function within the module.
            If loadLibAddr = 0 Then Return Die(hProcess) 'If GetProcAddress failed it'll return 0.
            Dim procThread As Integer = CreateRemoteThread(hProcess, 0, 0, loadLibAddr, pathLocation, 0, 0) 'Okay, this is the thread creation. We pass our process handle to tell what process to create the thread on. the third param is the handle of the function to call. In this case we choose the LoadLibrary function. The next param is the arguments to pass to the function (omg remember we wrote that to memory? NOW WE PASS THE ADDRESS BACK!)
            If procThread = 0 Then Return Die(hProcess) 'unable to create the thread. Return false
            Dim waitVal As Integer = WaitForSingleObject(procThread, 5000) 'allow the LoadLibrary function 5 seconds to process.
            If Not waitVal = &H0UI Then Return Die(hProcess, procThread) 'Function didn't signal completion. Fuck that shit abort ABORT
            CloseHandle(procThread) 'close the handle to the LoadLibrary function
            CloseHandle(hProcess) 'close the handle to the process
            Return True 'made it, yay.
        End Function

#End Region
    End Structure


End Class
