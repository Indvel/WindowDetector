<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.labelId = New System.Windows.Forms.Label()
        Me.labelName = New System.Windows.Forms.Label()
        Me.labelSize = New System.Windows.Forms.Label()
        Me.labelPath = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Location = New System.Drawing.Point(73, 113)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(87, 31)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Location = New System.Drawing.Point(166, 113)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(87, 31)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'labelId
        '
        Me.labelId.AutoSize = True
        Me.labelId.Location = New System.Drawing.Point(12, 9)
        Me.labelId.Name = "labelId"
        Me.labelId.Size = New System.Drawing.Size(75, 12)
        Me.labelId.TabIndex = 0
        Me.labelId.Text = "ProcessID : "
        '
        'labelName
        '
        Me.labelName.AutoSize = True
        Me.labelName.Location = New System.Drawing.Point(12, 30)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(51, 12)
        Me.labelName.TabIndex = 0
        Me.labelName.Text = "Name : "
        '
        'labelSize
        '
        Me.labelSize.AutoSize = True
        Me.labelSize.Location = New System.Drawing.Point(12, 51)
        Me.labelSize.Name = "labelSize"
        Me.labelSize.Size = New System.Drawing.Size(42, 12)
        Me.labelSize.TabIndex = 0
        Me.labelSize.Text = "Size : "
        '
        'labelPath
        '
        Me.labelPath.Location = New System.Drawing.Point(12, 72)
        Me.labelPath.Name = "labelPath"
        Me.labelPath.Size = New System.Drawing.Size(304, 38)
        Me.labelPath.TabIndex = 0
        Me.labelPath.Text = "Path : "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(328, 158)
        Me.Controls.Add(Me.labelPath)
        Me.Controls.Add(Me.labelSize)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.labelName)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.labelId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Window Detector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents labelId As Label
    Friend WithEvents labelName As Label
    Friend WithEvents labelSize As Label
    Friend WithEvents labelPath As Label
End Class
