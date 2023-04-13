<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings_security
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settings_security))
        Me.lbl_employeeno = New System.Windows.Forms.Label()
        Me.lbl_action = New System.Windows.Forms.Label()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_remove = New System.Windows.Forms.Button()
        Me.txtbx_securitykey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ptc_check = New System.Windows.Forms.PictureBox()
        Me.lbl_employeetype = New System.Windows.Forms.Label()
        CType(Me.ptc_check, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_employeeno
        '
        Me.lbl_employeeno.AutoSize = True
        Me.lbl_employeeno.ForeColor = System.Drawing.Color.White
        Me.lbl_employeeno.Location = New System.Drawing.Point(478, 48)
        Me.lbl_employeeno.Name = "lbl_employeeno"
        Me.lbl_employeeno.Size = New System.Drawing.Size(64, 13)
        Me.lbl_employeeno.TabIndex = 86
        Me.lbl_employeeno.Text = "employeeno"
        Me.lbl_employeeno.Visible = False
        '
        'lbl_action
        '
        Me.lbl_action.AutoSize = True
        Me.lbl_action.ForeColor = System.Drawing.Color.White
        Me.lbl_action.Location = New System.Drawing.Point(478, 16)
        Me.lbl_action.Name = "lbl_action"
        Me.lbl_action.Size = New System.Drawing.Size(36, 13)
        Me.lbl_action.TabIndex = 85
        Me.lbl_action.Text = "action"
        Me.lbl_action.Visible = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.btn_cancel.FlatAppearance.BorderSize = 0
        Me.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.Color.White
        Me.btn_cancel.Location = New System.Drawing.Point(470, 180)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(82, 29)
        Me.btn_cancel.TabIndex = 78
        Me.btn_cancel.Text = "CANCEL"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_remove
        '
        Me.btn_remove.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_remove.FlatAppearance.BorderSize = 0
        Me.btn_remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_remove.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_remove.ForeColor = System.Drawing.Color.White
        Me.btn_remove.Location = New System.Drawing.Point(384, 180)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(82, 29)
        Me.btn_remove.TabIndex = 77
        Me.btn_remove.Text = "REMOVE"
        Me.btn_remove.UseVisualStyleBackColor = False
        '
        'txtbx_securitykey
        '
        Me.txtbx_securitykey.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtbx_securitykey.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbx_securitykey.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_securitykey.Location = New System.Drawing.Point(16, 130)
        Me.txtbx_securitykey.Multiline = True
        Me.txtbx_securitykey.Name = "txtbx_securitykey"
        Me.txtbx_securitykey.Size = New System.Drawing.Size(398, 32)
        Me.txtbx_securitykey.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(488, 22)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "The security key serves as the protection of important data from any changes to b" & _
    "e made."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(377, 27)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Kindly ask the system administrator for the security key."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 45)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "ENTER THE SECURITY KEY"
        '
        'ptc_check
        '
        Me.ptc_check.BackColor = System.Drawing.Color.Transparent
        Me.ptc_check.Image = CType(resources.GetObject("ptc_check.Image"), System.Drawing.Image)
        Me.ptc_check.Location = New System.Drawing.Point(420, 133)
        Me.ptc_check.Name = "ptc_check"
        Me.ptc_check.Size = New System.Drawing.Size(29, 25)
        Me.ptc_check.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ptc_check.TabIndex = 79
        Me.ptc_check.TabStop = False
        Me.ptc_check.Visible = False
        '
        'lbl_employeetype
        '
        Me.lbl_employeetype.AutoSize = True
        Me.lbl_employeetype.ForeColor = System.Drawing.Color.White
        Me.lbl_employeetype.Location = New System.Drawing.Point(478, 68)
        Me.lbl_employeetype.Name = "lbl_employeetype"
        Me.lbl_employeetype.Size = New System.Drawing.Size(72, 13)
        Me.lbl_employeetype.TabIndex = 87
        Me.lbl_employeetype.Text = "employeetype"
        Me.lbl_employeetype.Visible = False
        '
        'settings_security
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(558, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_employeetype)
        Me.Controls.Add(Me.lbl_employeeno)
        Me.Controls.Add(Me.lbl_action)
        Me.Controls.Add(Me.ptc_check)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_remove)
        Me.Controls.Add(Me.txtbx_securitykey)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "settings_security"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "settings_security"
        Me.TopMost = True
        CType(Me.ptc_check, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_employeeno As System.Windows.Forms.Label
    Friend WithEvents lbl_action As System.Windows.Forms.Label
    Friend WithEvents ptc_check As System.Windows.Forms.PictureBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_remove As System.Windows.Forms.Button
    Friend WithEvents txtbx_securitykey As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_employeetype As System.Windows.Forms.Label
End Class
