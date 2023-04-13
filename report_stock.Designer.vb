<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class report_stock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(report_stock))
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.paneluser = New System.Windows.Forms.Panel()
        Me.btn_designateexternal = New System.Windows.Forms.Button()
        Me.btn_designateinternal = New System.Windows.Forms.Button()
        Me.btn_dashuser = New System.Windows.Forms.Button()
        Me.panelstorage = New System.Windows.Forms.Panel()
        Me.btn_storagemanage = New System.Windows.Forms.Button()
        Me.btn_storagecheckval = New System.Windows.Forms.Button()
        Me.btn_storagereturn = New System.Windows.Forms.Button()
        Me.btn_dashstorage = New System.Windows.Forms.Button()
        Me.btn_dashstock = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.paneluser.SuspendLayout()
        Me.panelstorage.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_logout.FlatAppearance.BorderSize = 0
        Me.btn_logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_logout.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_logout.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_logout.Image = CType(resources.GetObject("btn_logout.Image"), System.Drawing.Image)
        Me.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_logout.Location = New System.Drawing.Point(0, 906)
        Me.btn_logout.MaximumSize = New System.Drawing.Size(255, 54)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(255, 54)
        Me.btn_logout.TabIndex = 28
        Me.btn_logout.Text = "RETURN TO DASHBOARD"
        Me.btn_logout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_logout.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.Panel1.Controls.Add(Me.paneluser)
        Me.Panel1.Controls.Add(Me.panelstorage)
        Me.Panel1.Controls.Add(Me.btn_dashstock)
        Me.Panel1.Controls.Add(Me.btn_logout)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Location = New System.Drawing.Point(2, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 960)
        Me.Panel1.TabIndex = 48
        '
        'paneluser
        '
        Me.paneluser.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.paneluser.Controls.Add(Me.btn_designateexternal)
        Me.paneluser.Controls.Add(Me.btn_designateinternal)
        Me.paneluser.Controls.Add(Me.btn_dashuser)
        Me.paneluser.Dock = System.Windows.Forms.DockStyle.Top
        Me.paneluser.Location = New System.Drawing.Point(0, 108)
        Me.paneluser.MaximumSize = New System.Drawing.Size(257, 150)
        Me.paneluser.MinimumSize = New System.Drawing.Size(257, 54)
        Me.paneluser.Name = "paneluser"
        Me.paneluser.Size = New System.Drawing.Size(257, 54)
        Me.paneluser.TabIndex = 31
        '
        'btn_designateexternal
        '
        Me.btn_designateexternal.BackColor = System.Drawing.Color.Transparent
        Me.btn_designateexternal.FlatAppearance.BorderSize = 0
        Me.btn_designateexternal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_designateexternal.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_designateexternal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_designateexternal.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_designateexternal.ForeColor = System.Drawing.Color.White
        Me.btn_designateexternal.Image = CType(resources.GetObject("btn_designateexternal.Image"), System.Drawing.Image)
        Me.btn_designateexternal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_designateexternal.Location = New System.Drawing.Point(-1, 102)
        Me.btn_designateexternal.Name = "btn_designateexternal"
        Me.btn_designateexternal.Size = New System.Drawing.Size(255, 47)
        Me.btn_designateexternal.TabIndex = 20
        Me.btn_designateexternal.Text = "            EXTERNAL USER"
        Me.btn_designateexternal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_designateexternal.UseVisualStyleBackColor = False
        '
        'btn_designateinternal
        '
        Me.btn_designateinternal.BackColor = System.Drawing.Color.Transparent
        Me.btn_designateinternal.FlatAppearance.BorderSize = 0
        Me.btn_designateinternal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_designateinternal.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_designateinternal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_designateinternal.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_designateinternal.ForeColor = System.Drawing.Color.White
        Me.btn_designateinternal.Image = CType(resources.GetObject("btn_designateinternal.Image"), System.Drawing.Image)
        Me.btn_designateinternal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_designateinternal.Location = New System.Drawing.Point(0, 55)
        Me.btn_designateinternal.Name = "btn_designateinternal"
        Me.btn_designateinternal.Size = New System.Drawing.Size(255, 46)
        Me.btn_designateinternal.TabIndex = 19
        Me.btn_designateinternal.Text = "            INTERNAL USER"
        Me.btn_designateinternal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_designateinternal.UseVisualStyleBackColor = False
        '
        'btn_dashuser
        '
        Me.btn_dashuser.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashuser.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_dashuser.FlatAppearance.BorderSize = 0
        Me.btn_dashuser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashuser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_dashuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_dashuser.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_dashuser.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_dashuser.Image = CType(resources.GetObject("btn_dashuser.Image"), System.Drawing.Image)
        Me.btn_dashuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashuser.Location = New System.Drawing.Point(0, 0)
        Me.btn_dashuser.MaximumSize = New System.Drawing.Size(255, 54)
        Me.btn_dashuser.Name = "btn_dashuser"
        Me.btn_dashuser.Size = New System.Drawing.Size(255, 54)
        Me.btn_dashuser.TabIndex = 13
        Me.btn_dashuser.Text = "             DESIGNATION"
        Me.btn_dashuser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashuser.UseVisualStyleBackColor = False
        '
        'panelstorage
        '
        Me.panelstorage.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.panelstorage.Controls.Add(Me.btn_storagemanage)
        Me.panelstorage.Controls.Add(Me.btn_storagecheckval)
        Me.panelstorage.Controls.Add(Me.btn_storagereturn)
        Me.panelstorage.Controls.Add(Me.btn_dashstorage)
        Me.panelstorage.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelstorage.Location = New System.Drawing.Point(0, 54)
        Me.panelstorage.MaximumSize = New System.Drawing.Size(257, 245)
        Me.panelstorage.MinimumSize = New System.Drawing.Size(257, 54)
        Me.panelstorage.Name = "panelstorage"
        Me.panelstorage.Size = New System.Drawing.Size(257, 54)
        Me.panelstorage.TabIndex = 30
        '
        'btn_storagemanage
        '
        Me.btn_storagemanage.BackColor = System.Drawing.Color.Transparent
        Me.btn_storagemanage.FlatAppearance.BorderSize = 0
        Me.btn_storagemanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_storagemanage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_storagemanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_storagemanage.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_storagemanage.ForeColor = System.Drawing.Color.White
        Me.btn_storagemanage.Image = CType(resources.GetObject("btn_storagemanage.Image"), System.Drawing.Image)
        Me.btn_storagemanage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagemanage.Location = New System.Drawing.Point(1, 150)
        Me.btn_storagemanage.Name = "btn_storagemanage"
        Me.btn_storagemanage.Size = New System.Drawing.Size(254, 47)
        Me.btn_storagemanage.TabIndex = 21
        Me.btn_storagemanage.Text = "            STORED ITEMS"
        Me.btn_storagemanage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagemanage.UseVisualStyleBackColor = False
        '
        'btn_storagecheckval
        '
        Me.btn_storagecheckval.BackColor = System.Drawing.Color.Transparent
        Me.btn_storagecheckval.FlatAppearance.BorderSize = 0
        Me.btn_storagecheckval.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_storagecheckval.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_storagecheckval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_storagecheckval.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_storagecheckval.ForeColor = System.Drawing.Color.White
        Me.btn_storagecheckval.Image = CType(resources.GetObject("btn_storagecheckval.Image"), System.Drawing.Image)
        Me.btn_storagecheckval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagecheckval.Location = New System.Drawing.Point(-1, 100)
        Me.btn_storagecheckval.Name = "btn_storagecheckval"
        Me.btn_storagecheckval.Size = New System.Drawing.Size(254, 47)
        Me.btn_storagecheckval.TabIndex = 20
        Me.btn_storagecheckval.Text = "             ITEM VALUE"
        Me.btn_storagecheckval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagecheckval.UseVisualStyleBackColor = False
        '
        'btn_storagereturn
        '
        Me.btn_storagereturn.BackColor = System.Drawing.Color.Transparent
        Me.btn_storagereturn.FlatAppearance.BorderSize = 0
        Me.btn_storagereturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_storagereturn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_storagereturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_storagereturn.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_storagereturn.ForeColor = System.Drawing.Color.White
        Me.btn_storagereturn.Image = CType(resources.GetObject("btn_storagereturn.Image"), System.Drawing.Image)
        Me.btn_storagereturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagereturn.Location = New System.Drawing.Point(-1, 57)
        Me.btn_storagereturn.Name = "btn_storagereturn"
        Me.btn_storagereturn.Size = New System.Drawing.Size(255, 46)
        Me.btn_storagereturn.TabIndex = 19
        Me.btn_storagereturn.Text = "             RETURNED ITEM"
        Me.btn_storagereturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagereturn.UseVisualStyleBackColor = False
        '
        'btn_dashstorage
        '
        Me.btn_dashstorage.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashstorage.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_dashstorage.FlatAppearance.BorderSize = 0
        Me.btn_dashstorage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashstorage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_dashstorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_dashstorage.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_dashstorage.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_dashstorage.Image = CType(resources.GetObject("btn_dashstorage.Image"), System.Drawing.Image)
        Me.btn_dashstorage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashstorage.Location = New System.Drawing.Point(0, 0)
        Me.btn_dashstorage.MaximumSize = New System.Drawing.Size(255, 54)
        Me.btn_dashstorage.Name = "btn_dashstorage"
        Me.btn_dashstorage.Size = New System.Drawing.Size(255, 54)
        Me.btn_dashstorage.TabIndex = 13
        Me.btn_dashstorage.Text = "             STORAGE"
        Me.btn_dashstorage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashstorage.UseVisualStyleBackColor = False
        '
        'btn_dashstock
        '
        Me.btn_dashstock.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashstock.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_dashstock.FlatAppearance.BorderSize = 0
        Me.btn_dashstock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_dashstock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_dashstock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_dashstock.Font = New System.Drawing.Font("Dubai", 11.0!)
        Me.btn_dashstock.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_dashstock.Image = CType(resources.GetObject("btn_dashstock.Image"), System.Drawing.Image)
        Me.btn_dashstock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashstock.Location = New System.Drawing.Point(0, 0)
        Me.btn_dashstock.MaximumSize = New System.Drawing.Size(255, 54)
        Me.btn_dashstock.Name = "btn_dashstock"
        Me.btn_dashstock.Size = New System.Drawing.Size(255, 54)
        Me.btn_dashstock.TabIndex = 29
        Me.btn_dashstock.Text = "            STOCK"
        Me.btn_dashstock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_dashstock.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Panel8.Controls.Add(Me.btn_home)
        Me.Panel8.Location = New System.Drawing.Point(2, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(255, 43)
        Me.Panel8.TabIndex = 51
        '
        'btn_home
        '
        Me.btn_home.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_home.FlatAppearance.BorderSize = 0
        Me.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_home.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_home.ForeColor = System.Drawing.Color.White
        Me.btn_home.Location = New System.Drawing.Point(0, 6)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(253, 32)
        Me.btn_home.TabIndex = 52
        Me.btn_home.Text = "REPORT VIEWER"
        Me.btn_home.UseVisualStyleBackColor = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(257, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1276, 1003)
        Me.ReportViewer1.TabIndex = 52
        '
        'report_stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1533, 1001)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "report_stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.paneluser.ResumeLayout(False)
        Me.panelstorage.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_logout As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btn_home As System.Windows.Forms.Button
    Friend WithEvents btn_dashstock As System.Windows.Forms.Button
    Friend WithEvents panelstorage As System.Windows.Forms.Panel
    Friend WithEvents btn_storagemanage As System.Windows.Forms.Button
    Friend WithEvents btn_storagecheckval As System.Windows.Forms.Button
    Friend WithEvents btn_storagereturn As System.Windows.Forms.Button
    Friend WithEvents btn_dashstorage As System.Windows.Forms.Button
    Friend WithEvents paneluser As System.Windows.Forms.Panel
    Friend WithEvents btn_designateexternal As System.Windows.Forms.Button
    Friend WithEvents btn_designateinternal As System.Windows.Forms.Button
    Friend WithEvents btn_dashuser As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
