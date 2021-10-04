Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing

Public Class Form1

    <DllImport("user32")>
    Public Shared Function WindowFromPoint(pt As Point) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowThreadProcessId")>
    Private Shared Function GetWindowThreadProcessId(<InAttribute()> ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function

    <DllImport("user32")>
    Private Shared Function GetCursorPos(ByRef pt As Point) As Int32
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function GetWindowTextLength(ByVal hwnd As IntPtr) As Integer
    End Function

    Public Declare Auto Function GetWindowText Lib "user32" _
            (ByVal hWnd As System.IntPtr,
            ByVal lpString As System.Text.StringBuilder,
            ByVal cch As Integer) As Integer

    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Declare Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer

    Declare Function GetClientRect Lib "user32" Alias "GetClientRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer

    <DllImport("user32.dll", SetLastError:=False)>
    Private Shared Function GetDesktopWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Overloads Declare Function InvalidateRect Lib "User32" Alias "InvalidateRect" (ByVal hWnd As IntPtr, ByRef lpRect As RECT, ByVal bErase As Boolean) As Boolean

    Dim hwnd As IntPtr
    Dim stroke As Pen = New Pen(Color.Red, 2)
    Dim prevPid As Integer = Nothing
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim pos As Point
        GetCursorPos(pos)
        hwnd = WindowFromPoint(pos)

        If hwnd <> IntPtr.Zero Then
            Dim len As Integer = GetWindowTextLength(hwnd)
            Dim title As New StringBuilder("", len + 1)
            If len > 0 Then
                GetWindowText(hwnd, title, title.Capacity)
            End If
            Dim pid As Integer = Nothing
            GetWindowThreadProcessId(hwnd, pid)

            Dim proc As Process = Process.GetProcessById(pid)
            Dim fileName As String = ""
            Try
                fileName = proc.MainModule.FileName
            Catch ex As Exception
                fileName = ""
            End Try

            Dim rect As RECT
            GetWindowRect(hwnd, rect)

            If Not pid = prevPid Then
                prevPid = pid
                InvalidateRect(IntPtr.Zero, rect, False)
            End If

            Dim rta As Rectangle = New Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top)
            Dim g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            g.DrawRectangle(stroke, rta)
            g.Dispose()

            labelId.Text = "ProcessID : " & pid.ToString
            labelName.Text = "Name : " & title.ToString
            labelSize.Text = "Size : " & (rect.right - rect.left) & " X " & (rect.bottom - rect.top)
            labelPath.Text = "Path : " & fileName.ToString
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Timer1.Enabled = False Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If Timer1.Enabled Then
            Timer1.Enabled = False
        End If
    End Sub
End Class
