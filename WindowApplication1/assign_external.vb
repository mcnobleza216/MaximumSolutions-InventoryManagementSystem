Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class assign_external
    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True
    Dim IsCollapsed7 As Boolean = True

    Private Sub assign_external_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("SELECT * FROM tbl_inventorystorage", dgv_storage)
        reload("SELECT * FROM tbl_employeeexternal", dgv_employee)

        FilterDataEmployee("")
        FilterDataStorage("")

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT assigned_no FROM tbl_designations ORDER BY assigned_no DESC LIMIT 1"
            cmd.Connection = strcon

            Dim assignedno As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If assignedno >= 1 Then
                Dim finalunitid As Integer
                finalunitid = assignedno + 1
                lbl_assignedno.Text = finalunitid
                strcon.Close()
            Else
                Dim finalunitid2 As Integer
                finalunitid2 = 1
                lbl_assignedno.Text = finalunitid2
                strcon.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim cmdd As New MySqlCommand
            Dim daa As New MySqlDataAdapter
            Dim dtt As New DataTable

            strcon.Open()

            cmdd.Connection = strcon
            cmdd.CommandText = "SELECT * FROM tbl_externallocation"

            daa.SelectCommand = cmdd
            daa.Fill(dtt)

            strcon.Close()
            ComboBox2.DataSource = dtt
            ComboBox2.ValueMember = "location_ID"
            ComboBox2.DisplayMember = "name"
            ComboBox2.Text = "SELECT LOCATION"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
            da.Dispose()
        End Try
    End Sub

    Private Sub dgv_storage_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_storage.CellContentClick
        ' lbl_assignedno.Text = ""
        lbl_employeeno.Text = ""
        txtb_firstname.Text = ""
        txtb_middlename.Text = ""
        txtb_suffix.Text = ""
        txtb_surname.Text = ""
        cmb_location.Text = ""

        If dgv_storage.CurrentRow.Cells(5).Value = "Defective" Then
            MessageBox.Show("The device you selected was defective", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lbl_unitid.Text = "-------"
            lbl_unittype.Text = ""
            txtb_serialno.Text = ""
            txtb_brand.Text = ""
            txtb_model.Text = ""
            txtb_condition.Text = ""
        Else
            dgv_employee.Enabled = True
            cmb_location.Enabled = True
            lbl_unitid.Text = dgv_storage.CurrentRow.Cells(0).Value
            lbl_unittype.Text = dgv_storage.CurrentRow.Cells(4).Value
            txtb_serialno.Text = dgv_storage.CurrentRow.Cells(1).Value
            txtb_brand.Text = dgv_storage.CurrentRow.Cells(2).Value
            txtb_model.Text = dgv_storage.CurrentRow.Cells(3).Value
            txtb_condition.Text = dgv_storage.CurrentRow.Cells(5).Value
        End If
    End Sub

    Private Sub dgv_employee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_employee.CellContentClick
        Try
            lbl_employeeno.Text = dgv_employee.CurrentRow.Cells(0).Value

            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT * FROM tbl_designations WHERE employee_no = '" & lbl_employeeno.Text & "' AND unit_type = 'System unit'"
            cmd.Connection = strcon

            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                Dim result As DialogResult = MessageBox.Show("This extenal employee already has an assigned system unit, are you sure you want to assign another system unit to this employee?", "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    lbl_employeeno.Text = dgv_employee.CurrentRow.Cells(0).Value
                    txtb_firstname.Text = dgv_employee.CurrentRow.Cells(1).Value
                    txtb_middlename.Text = dgv_employee.CurrentRow.Cells(2).Value
                    txtb_surname.Text = dgv_employee.CurrentRow.Cells(3).Value
                    txtb_suffix.Text = dgv_employee.CurrentRow.Cells(4).Value
                    cmb_location.Text = dgv_employee.CurrentRow.Cells(5).Value
                End If
            Else
                lbl_employeeno.Text = dgv_employee.CurrentRow.Cells(0).Value
                txtb_firstname.Text = dgv_employee.CurrentRow.Cells(1).Value
                txtb_middlename.Text = dgv_employee.CurrentRow.Cells(2).Value
                txtb_surname.Text = dgv_employee.CurrentRow.Cells(3).Value
                txtb_suffix.Text = dgv_employee.CurrentRow.Cells(4).Value
                cmb_location.Text = dgv_employee.CurrentRow.Cells(5).Value
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ASSIGNED()
        Try
            strcon.Close()
            strcon.Open()
            cmd.CommandText = "SELECT * FROM tbl_unitdesignation WHERE serial_number = '" & txtb_serialno.Text & "'"
            cmd.Connection = strcon

            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                MessageBox.Show("The selected device was already assigned to somebody else", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                strcon.Close()
            Else
                '  Dim datetoday As String = DateTime.Now.ToString()
                '    Dim action1 As String = "Assigned " + lbl_unittype.Text + " to employee no: " + lbl_employeeno.Text
                Dim fullname As String = txtb_firstname.Text + " " + txtb_surname.Text + " " + txtb_suffix.Text
                create("INSERT INTO tbl_unitdesignation (assigned_no,unit_id,serial_number,model,unit_type,assigned_to,employee_no,date_assigned,designation_type) VALUES('" & lbl_assignedno.Text & "','" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_model.Text & "','" & lbl_unittype.Text & "','" & fullname & "','" & lbl_employeeno.Text & "','" & lbl_datetoday.Text & "','External')")
                create("INSERT INTO tbl_designations (assigned_no,unit_id,serial_number,model,unit_type,assigned_to,employee_no,date_assigned,designation_type) VALUES('" & lbl_assignedno.Text & "','" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_model.Text & "','" & lbl_unittype.Text & "','" & fullname & "','" & lbl_employeeno.Text & "','" & lbl_datetoday.Text & "','External')")
                'MARKEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD'
                create("INSERT INTO tbl_designateexternal (assigned_no,unit_id,serial_number,brand_name,model,unit_type,assigned_to,employee_no,department,date_assigned) VALUES('" & lbl_assignedno.Text & "','" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_brand.Text & "','" & txtb_model.Text & "','" & lbl_unittype.Text & "','" & fullname & "','" & lbl_employeeno.Text & "','" & cmb_location.Text & "','" & lbl_datetoday.Text & "')")
                strcon.Close()
                deletes("DELETE FROM tbl_inventorystorage WHERE serial_number = '" & txtb_serialno.Text & "'")
                updates("UPDATE tbl_allstocks SET availability = 'Not Available' WHERE serial_number = '" & txtb_serialno.Text & "'")
                'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action1 & "','" & datetoday & "')")
                strcon.Close()
                reload("SELECT * FROM tbl_inventorystorage", dgv_storage)
                MessageBox.Show(lbl_unittype.Text + " assigned successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cleartext()
        lbl_unittype.Text = ""
        lbl_unitid.Text = "-------"
        txtb_serialno.Text = ""
        txtb_brand.Text = ""
        txtb_model.Text = ""
        cmb_location.Text = ""

        lbl_employeeno.Text = "-------"
        txtb_firstname.Text = ""
        txtb_middlename.Text = ""
        txtb_surname.Text = ""
        txtb_suffix.Text = ""
        cmb_location.Text = ""
    End Sub

    Private Sub lbl_employeeno_TextChanged(sender As Object, e As EventArgs) Handles lbl_employeeno.TextChanged
        If lbl_employeeno.Text <> "-------" Then
            btn_assign.Enabled = True
        Else
            btn_assign.Enabled = False
        End If
    End Sub
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        reload("SELECT * FROM tbl_inventorystorage WHERE unit_type = '" & ComboBox1.Text & "'", dgv_storage)
    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub
    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        reload("SELECT * FROM tbl_employeeexternal WHERE location = '" & ComboBox2.Text & "'", dgv_employee)
    End Sub

    Public Sub FilterDataStorage(valueToSearch As String)
        strcon.Close()
        strcon.Open()

        Dim searchquery As String = "SELECT * FROM tbl_inventorystorage WHERE CONCAT(unit_id,serial_number,brand_name,model,unit_type,unit_condition) LIKE '%" & txtb_searchstorage.Text & "%'"
        Dim command As New MySqlCommand(searchquery, strcon)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        dgv_storage.DataSource = table
        strcon.Close()
    End Sub

    Public Sub FilterDataEmployee(valueToSearch As String)
        strcon.Close()
        strcon.Open()

        Dim searchquery As String = "SELECT * FROM tbl_employeeexternal WHERE CONCAT(employee_no,first_name,middle_name,last_name,suffix,location) LIKE '%" & txtb_searchstorage.Text & "%'"
        Dim command As New MySqlCommand(searchquery, strcon)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        dgv_employee.DataSource = table
        strcon.Close()
    End Sub

    Private Sub txtb_searchstorage_TextChanged(sender As Object, e As EventArgs) Handles txtb_searchstorage.TextChanged
        FilterDataStorage(txtb_searchstorage.Text)
    End Sub

    Private Sub txtb_searchemployee_TextChanged(sender As Object, e As EventArgs) Handles txtb_searchemployee.TextChanged
        FilterDataEmployee(txtb_searchemployee.Text)
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        cleartext()
        dgv_employee.Enabled = False
    End Sub

    Private Sub btn_assign_Click(sender As Object, e As EventArgs) Handles btn_assign.Click
        ASSIGNED()
        cleartext()
        dgv_employee.Enabled = False
        cmb_location.Enabled = False
    End Sub

    'DROP DOWN MENU'
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If IsCollapsed Then

            panelassign.Height += 10
            If panelassign.Size = panelassign.MaximumSize Then
                Timer1.Stop()
                IsCollapsed = False
            End If
        Else
            panelassign.Height -= 10
            If panelassign.Size = panelassign.MinimumSize Then
                Timer1.Stop()
                IsCollapsed = True
            End If
        End If
    End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    If IsCollapsed2 Then

    '        NewPanelSlide.Height += 10
    '        If NewPanelSlide.Size = NewPanelSlide.MaximumSize Then
    '            Timer2.Stop()
    '            IsCollapsed2 = False
    '        End If
    '    Else
    '        NewPanelSlide.Height -= 10
    '        If NewPanelSlide.Size = NewPanelSlide.MinimumSize Then
    '            Timer2.Stop()
    '            IsCollapsed2 = True
    '        End If
    '    End If
    'End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If IsCollapsed3 Then

            panelstock.Height += 10
            If panelstock.Size = panelstock.MaximumSize Then
                Timer3.Stop()
                IsCollapsed3 = False
            End If
        Else
            panelstock.Height -= 10
            If panelstock.Size = panelstock.MinimumSize Then
                Timer3.Stop()
                IsCollapsed3 = True
            End If
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If IsCollapsed4 Then

            panelstorage.Height += 10
            If panelstorage.Size = panelstorage.MaximumSize Then
                Timer4.Stop()
                IsCollapsed4 = False
            End If
        Else
            panelstorage.Height -= 10
            If panelstorage.Size = panelstorage.MinimumSize Then
                Timer4.Stop()
                IsCollapsed4 = True
            End If
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If IsCollapsed5 Then

            paneluser.Height += 10
            If paneluser.Size = paneluser.MaximumSize Then
                Timer5.Stop()
                IsCollapsed5 = False
            End If
        Else
            paneluser.Height -= 10
            If paneluser.Size = paneluser.MinimumSize Then
                Timer5.Stop()
                IsCollapsed5 = True
            End If
        End If
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        If IsCollapsed6 Then

            panelsettings.Height += 10
            If panelsettings.Size = panelsettings.MaximumSize Then
                Timer6.Stop()
                IsCollapsed6 = False
            End If
        Else
            panelsettings.Height -= 10
            If panelsettings.Size = panelsettings.MinimumSize Then
                Timer6.Stop()
                IsCollapsed6 = True
            End If
        End If
    End Sub

    'Private Sub Timer7_Tick(sender As Object, e As EventArgs)
    '    If IsCollapsed7 Then

    '        panel_report.Height += 10
    '        If panel_report.Size = panel_report.MaximumSize Then
    '            Timer7.Stop()
    '            IsCollapsed7 = False
    '        End If
    '    Else
    '        panel_report.Height -= 10
    '        If panel_report.Size = panel_report.MinimumSize Then
    '            Timer7.Stop()
    '            IsCollapsed7 = True
    '        End If
    '    End If
    'End Sub

    'Iscollapse'
    Private Sub btn_dashassign_Click(sender As Object, e As EventArgs) Handles btn_dashassign.Click
        IsCollapsed3 = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False
        IsCollapsed7 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub
    'Iscollapse3'
    Private Sub btn_dashstock_Click(sender As Object, e As EventArgs) Handles btn_dashstock.Click
        IsCollapsed = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False
        IsCollapsed7 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub
    'Iscollapse4'
    Private Sub btn_dashstorage_Click(sender As Object, e As EventArgs) Handles btn_dashstorage.Click
        IsCollapsed3 = False
        IsCollapsed = False
        IsCollapsed5 = False
        IsCollapsed6 = False


        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub

    'iscollapsed5
    Private Sub btn_dashuser_Click(sender As Object, e As EventArgs) Handles btn_dashuser.Click
        IsCollapsed3 = False
        IsCollapsed = False
        IsCollapsed4 = False
        IsCollapsed6 = False


        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub

    'iscollapsed6
    Private Sub btn_dashsetting_Click(sender As Object, e As EventArgs) Handles btn_dashsetting.Click
        IsCollapsed3 = False
        IsCollapsed = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed7 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub

    'iscollapsed7'
    Private Sub btn_dashreport_Click(sender As Object, e As EventArgs) Handles btn_dashreport.Click
        IsCollapsed3 = False
        IsCollapsed = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()

    End Sub



    'HOVER HOME
    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Home.lbl_userid.Text = lbl_userid.Text
        Home.lbl_fname.Text = lbl_fname.Text
        Home.lbl_lname.Text = lbl_lname.Text
        Home.lbl_username.Text = lbl_username.Text
        Home.lbl_position.Text = lbl_position.Text
        Home.lbl_fullname.Text = lbl_fullname.Text
        Home.Show()
        Me.Close()
    End Sub

    'HOVER STOCKS'
    Private Sub btn_addstock_Click(sender As Object, e As EventArgs) Handles btn_addstock.Click
        stock_systemunit.lbl_userid.Text = lbl_userid.Text
        stock_systemunit.lbl_fname.Text = lbl_fname.Text
        stock_systemunit.lbl_lname.Text = lbl_lname.Text
        stock_systemunit.lbl_username.Text = lbl_username.Text
        stock_systemunit.lbl_position.Text = lbl_position.Text
        stock_systemunit.lbl_fullname.Text = lbl_fullname.Text
        stock_systemunit.Show()
        Me.Close()
    End Sub

    'HOVER STORAGE'
    Private Sub btn_storageadd_Click(sender As Object, e As EventArgs) Handles btn_storageadd.Click
        storage_addolditem.lbl_userid.Text = lbl_userid.Text
        storage_addolditem.lbl_fname.Text = lbl_fname.Text
        storage_addolditem.lbl_lname.Text = lbl_lname.Text
        storage_addolditem.lbl_username.Text = lbl_username.Text
        storage_addolditem.lbl_position.Text = lbl_position.Text
        storage_addolditem.lbl_fullname.Text = lbl_fullname.Text
        storage_addolditem.Show()
        Me.Close()
    End Sub
    Private Sub btn_storagecheckval_Click(sender As Object, e As EventArgs) Handles btn_storagecheckval.Click
        storage_itemvalue.lbl_userid.Text = lbl_userid.Text
        storage_itemvalue.lbl_fname.Text = lbl_fname.Text
        storage_itemvalue.lbl_lname.Text = lbl_lname.Text
        storage_itemvalue.lbl_username.Text = lbl_username.Text
        storage_itemvalue.lbl_position.Text = lbl_position.Text
        storage_itemvalue.lbl_fullname.Text = lbl_fullname.Text
        storage_itemvalue.Show()
        Me.Close()
    End Sub
    Private Sub btn_storagemanage_Click(sender As Object, e As EventArgs) Handles btn_storagemanage.Click
        storage_manage.lbl_userid.Text = lbl_userid.Text
        storage_manage.lbl_fname.Text = lbl_fname.Text
        storage_manage.lbl_lname.Text = lbl_lname.Text
        storage_manage.lbl_username.Text = lbl_username.Text
        storage_manage.lbl_position.Text = lbl_position.Text
        storage_manage.lbl_fullname.Text = lbl_fullname.Text
        storage_manage.Show()
        Me.Close()
    End Sub
    Private Sub btn_storagereturn_Click(sender As Object, e As EventArgs) Handles btn_storagereturn.Click
        storage_return.lbl_userid.Text = lbl_userid.Text
        storage_return.lbl_fname.Text = lbl_fname.Text
        storage_return.lbl_lname.Text = lbl_lname.Text
        storage_return.lbl_username.Text = lbl_username.Text
        storage_return.lbl_position.Text = lbl_position.Text
        storage_return.lbl_fullname.Text = lbl_fullname.Text
        storage_return.Show()
        Me.Close()
    End Sub

    'HOVER SETTINGS'
    Private Sub btn_settingsemployee_Click(sender As Object, e As EventArgs) Handles btn_settingsemployee.Click
        settings_employee.lbl_userid.Text = lbl_userid.Text
        settings_employee.lbl_fname.Text = lbl_fname.Text
        settings_employee.lbl_lname.Text = lbl_lname.Text
        settings_employee.lbl_username.Text = lbl_username.Text
        settings_employee.lbl_position.Text = lbl_position.Text
        settings_employee.lbl_fullname.Text = lbl_fullname.Text
        settings_employee.Show()
        Me.Close()
    End Sub

    'HOVER ASSIGN'
    Private Sub btn_assigninternal_Click(sender As Object, e As EventArgs) Handles btn_assigninternal.Click
        assign_internal.lbl_userid.Text = lbl_userid.Text
        assign_internal.lbl_fname.Text = lbl_fname.Text
        assign_internal.lbl_lname.Text = lbl_lname.Text
        assign_internal.lbl_username.Text = lbl_username.Text
        assign_internal.lbl_position.Text = lbl_position.Text
        assign_internal.lbl_fullname.Text = lbl_fullname.Text
        assign_internal.Show()
        Me.Close()
    End Sub

    Private Sub btn_assignexternal_Click(sender As Object, e As EventArgs) Handles btn_assignexternal.Click
        'assign_external.lbl_userid.Text = lbl_userid.Text
        'assign_external.lbl_fname.Text = lbl_fname.Text
        'assign_external.lbl_lname.Text = lbl_lname.Text
        'assign_external.lbl_username.Text = lbl_username.Text
        'assign_external.lbl_position.Text = lbl_position.Text
        'assign_external.lbl_fullname.Text = lbl_fullname.Text
        'assign_external.Show()
        'Me.Close()
    End Sub

    'LOGOUT
    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Form1.Show()
            Me.Close()
        End If
    End Sub

    'UPDATE DEPRECIATION'
    Public Sub depreciateitems()
        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'System unit'"
            cmd.Connection = strcon

            Dim systemunitspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If systemunitspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & systemunitspan & "))) WHERE unit_type = 'System unit' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'System unit' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Monitor'"
            cmd.Connection = strcon

            Dim monitorspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If monitorspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & monitorspan & "))) WHERE unit_type = 'Monitor' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Monitor' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Printer'"
            cmd.Connection = strcon

            Dim printerspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If printerspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & printerspan & "))) WHERE unit_type = 'Printer' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Printer' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Peripherals'"
            cmd.Connection = strcon

            Dim peripheralspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If peripheralspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & peripheralspan & "))) WHERE unit_type = 'Peripherals' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Peripherals' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'RAM'"
            cmd.Connection = strcon

            Dim memoryspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If memoryspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & memoryspan & "))) WHERE unit_type = 'Memory' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Memory' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Storage drive'"
            cmd.Connection = strcon

            Dim storagespan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If storagespan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & storagespan & "))) WHERE unit_type = 'Storage drive' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Storage drive' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Laptop'"
            cmd.Connection = strcon

            Dim laptopspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If laptopspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & laptopspan & "))) WHERE unit_type = 'Laptop' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Laptop' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT lifespan FROM tbl_stockdepreciationspan WHERE unit_type = 'Networking'"
            cmd.Connection = strcon

            Dim networkspan As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            strcon.Close()

            If networkspan > 1 Then
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12 * " & networkspan & "))) WHERE unit_type = 'Networking' AND depreciation_value != 0")
            Else
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = GREATEST(0, purchased_value - (purchased_value * TIMESTAMPDIFF(MONTH, date_purchased, NOW()) / (12))) WHERE unit_type = 'Networking' AND depreciation_value != 0")
            End If

            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

 
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick

    End Sub
End Class