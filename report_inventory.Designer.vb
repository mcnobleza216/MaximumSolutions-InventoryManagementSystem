<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class report_inventory
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(report_inventory))
        Me.dt_inventoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New InventorySystem.DataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btn_home = New System.Windows.Forms.Button()
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
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_unittype = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_condition = New System.Windows.Forms.ComboBox()
        CType(Me.dt_inventoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.paneluser.SuspendLayout()
        Me.panelstorage.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dt_inventoryBindingSource
        '
        Me.dt_inventoryBindingSource.DataMember = "dt_inventory"
        Me.dt_inventoryBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.BackColor = System.Drawing.Color.Gray
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.dt_inventoryBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "InventorySystem.ReportStorage.rdlc"
        Me.ReportViewer1.LocalReport.ReportPath = "ReportStorage.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(256, 41)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ShowFindControls = False
        Me.ReportViewer1.ShowZoomControl = False
        Me.ReportViewer1.Size = New System.Drawing.Size(1189, 834)
        Me.ReportViewer1.TabIndex = 55
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Panel8.Controls.Add(Me.btn_home)
        Me.Panel8.Location = New System.Drawing.Point(-1, -2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(257, 44)
        Me.Panel8.TabIndex = 54
        '
        'btn_home
        '
        Me.btn_home.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_home.FlatAppearance.BorderSize = 0
        Me.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_home.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_home.ForeColor = System.Drawing.Color.White
        Me.btn_home.Location = New System.Drawing.Point(0, 6)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(258, 32)
        Me.btn_home.TabIndex = 52
        Me.btn_home.Text = "REPORT VIEWER"
        Me.btn_home.UseVisualStyleBackColor = False
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
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(257, 834)
        Me.Panel1.TabIndex = 53
        '
        'paneluser
        '
        Me.paneluser.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.paneluser.Controls.Add(Me.btn_designateexternal)
        Me.paneluser.Controls.Add(Me.btn_designateinternal)
        Me.paneluser.Controls.Add(Me.btn_dashuser)
        Me.paneluser.Dock = System.Windows.Forms.DockStyle.Top
        Me.paneluser.Location = New System.Drawing.Point(0, 244)
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
        Me.btn_designateexternal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
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
        Me.btn_designateinternal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
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
        Me.btn_dashuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
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
        Me.panelstorage.MaximumSize = New System.Drawing.Size(257, 190)
        Me.panelstorage.MinimumSize = New System.Drawing.Size(257, 54)
        Me.panelstorage.Name = "panelstorage"
        Me.panelstorage.Size = New System.Drawing.Size(257, 190)
        Me.panelstorage.TabIndex = 30
        '
        'btn_storagemanage
        '
        Me.btn_storagemanage.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_storagemanage.FlatAppearance.BorderSize = 0
        Me.btn_storagemanage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_storagemanage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_storagemanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_storagemanage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btn_storagemanage.ForeColor = System.Drawing.Color.White
        Me.btn_storagemanage.Image = CType(resources.GetObject("btn_storagemanage.Image"), System.Drawing.Image)
        Me.btn_storagemanage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagemanage.Location = New System.Drawing.Point(-1, 54)
        Me.btn_storagemanage.Name = "btn_storagemanage"
        Me.btn_storagemanage.Size = New System.Drawing.Size(258, 47)
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
        Me.btn_storagecheckval.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btn_storagecheckval.ForeColor = System.Drawing.Color.White
        Me.btn_storagecheckval.Image = CType(resources.GetObject("btn_storagecheckval.Image"), System.Drawing.Image)
        Me.btn_storagecheckval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagecheckval.Location = New System.Drawing.Point(-1, 100)
        Me.btn_storagecheckval.Name = "btn_storagecheckval"
        Me.btn_storagecheckval.Size = New System.Drawing.Size(258, 47)
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
        Me.btn_storagereturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btn_storagereturn.ForeColor = System.Drawing.Color.White
        Me.btn_storagereturn.Image = CType(resources.GetObject("btn_storagereturn.Image"), System.Drawing.Image)
        Me.btn_storagereturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_storagereturn.Location = New System.Drawing.Point(-1, 144)
        Me.btn_storagereturn.Name = "btn_storagereturn"
        Me.btn_storagereturn.Size = New System.Drawing.Size(258, 46)
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
        Me.btn_dashstorage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
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
        Me.btn_dashstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
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
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_logout.FlatAppearance.BorderSize = 0
        Me.btn_logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btn_logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_logout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_logout.Image = CType(resources.GetObject("btn_logout.Image"), System.Drawing.Image)
        Me.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_logout.Location = New System.Drawing.Point(0, 780)
        Me.btn_logout.MaximumSize = New System.Drawing.Size(255, 54)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(255, 54)
        Me.btn_logout.TabIndex = 28
        Me.btn_logout.Text = "       RETURN TO DASHBOARD"
        Me.btn_logout.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(256, -2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1278, 44)
        Me.Panel2.TabIndex = 66
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(294, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 24)
        Me.Label4.TabIndex = 2
        '
        'cmb_unittype
        '
        Me.cmb_unittype.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_unittype.DropDownHeight = 70
        Me.cmb_unittype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_unittype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_unittype.FormattingEnabled = True
        Me.cmb_unittype.IntegralHeight = False
        Me.cmb_unittype.Items.AddRange(New Object() {"System Unit", "Laptop", "Monitor", "Memory", "Storage drive", "Printer", "Peripherals", "Networking", "SELECT ALL"})
        Me.cmb_unittype.Location = New System.Drawing.Point(369, 100)
        Me.cmb_unittype.Name = "cmb_unittype"
        Me.cmb_unittype.Size = New System.Drawing.Size(145, 23)
        Me.cmb_unittype.TabIndex = 67
        Me.cmb_unittype.Text = "SELECT ALL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Gray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(263, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 18)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "CONDITION:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(263, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "SORT BY:"
        '
        'cmb_condition
        '
        Me.cmb_condition.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmb_condition.DropDownHeight = 70
        Me.cmb_condition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_condition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_condition.FormattingEnabled = True
        Me.cmb_condition.IntegralHeight = False
        Me.cmb_condition.Items.AddRange(New Object() {"Working", "Defective"})
        Me.cmb_condition.Location = New System.Drawing.Point(369, 159)
        Me.cmb_condition.Name = "cmb_condition"
        Me.cmb_condition.Size = New System.Drawing.Size(145, 23)
        Me.cmb_condition.TabIndex = 70
        Me.cmb_condition.Text = "SELECT"
        '
        'report_inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1444, 874)
        Me.Controls.Add(Me.cmb_condition)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmb_unittype)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "report_inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dt_inventoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.paneluser.ResumeLayout(False)
        Me.panelstorage.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btn_home As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents paneluser As System.Windows.Forms.Panel
    Friend WithEvents btn_designateexternal As System.Windows.Forms.Button
    Friend WithEvents btn_designateinternal As System.Windows.Forms.Button
    Friend WithEvents btn_dashuser As System.Windows.Forms.Button
    Friend WithEvents panelstorage As System.Windows.Forms.Panel
    Friend WithEvents btn_storagemanage As System.Windows.Forms.Button
    Friend WithEvents btn_storagecheckval As System.Windows.Forms.Button
    Friend WithEvents btn_storagereturn As System.Windows.Forms.Button
    Friend WithEvents btn_dashstorage As System.Windows.Forms.Button
    Friend WithEvents btn_dashstock As System.Windows.Forms.Button
    Friend WithEvents btn_logout As System.Windows.Forms.Button
    Friend WithEvents DataSet1 As InventorySystem.DataSet1
    Friend WithEvents dt_inventoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_unittype As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_condition As System.Windows.Forms.ComboBox
End Class
