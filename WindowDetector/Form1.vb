Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Public Class Form1

    <DllImport("user32.dll")>
    Public Shared Function WindowFromPoint(pt As Point) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowThreadProcessId")>
    Private Shared Function GetWindowThreadProcessId(<InAttribute()> ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
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

    Declare Function GetWindowRect Lib "user32.dll" Alias "GetWindowRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer

    Public Overloads Declare Function InvalidateRect Lib "user32.dll" Alias "InvalidateRect" (ByVal hWnd As IntPtr, ByRef lpRect As RECT, ByVal bErase As Boolean) As Boolean

    Dim hwnd As IntPtr
    Dim prevHwnd As IntPtr
    Dim stroke As Pen = New Pen(Color.Red, 2)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim pos As Point
        GetCursorPos(pos)
        hwnd = WindowFromPoint(pos)

        If hwnd <> IntPtr.Zero Then
            Dim len As Integer = GetWindowTextLength(hwnd)
            Dim title As New StringBuilder("None", len + 1)
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

            If Not hwnd = prevHwnd Then
                prevHwnd = hwnd
                InvalidateRect(IntPtr.Zero, rect, False)
            End If

            Dim font As Font
            If Thread.CurrentThread.CurrentCulture.Name = "ko-KR" Then
                font = New Font("맑은 고딕", 10)
            Else
                font = New Font("Arial", 10)
            End If

            Dim rta As Rectangle = New Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top)
            Dim g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            g.DrawRectangle(stroke, rta)
            g.DrawString(title.ToString & " (" & (rect.right - rect.left) & " X " & (rect.bottom - rect.top) & ")", font, Brushes.Red, New Point(rect.left, rect.top - 18))
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
            Me.TopMost = True
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If Timer1.Enabled Then
            Timer1.Enabled = False
            Me.TopMost = False
        End If
    End Sub
End Class
