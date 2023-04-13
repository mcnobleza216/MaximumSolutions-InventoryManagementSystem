Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text


Public Class storage_return

    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True
    Dim IsCollapsed7 As Boolean = True

    Private Sub storage_return_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("SELECT * FROM tbl_unitdesignation", dgv_designation)

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

        FilterData("")
        'Try
        '    Dim cmd3 As New MySqlCommand
        '    Dim daa3 As New MySqlDataAdapter
        '    Dim dtt3 As New DataTable

        '    strcon.Open()

        '    cmd3.CommandText = "SELECT * FROM tbl_departments"
        '    cmd3.Connection = strcon

        '    daa3.SelectCommand = cmd3
        '    daa3.Fill(dtt3)

        '    cmb_departlocate.DataSource = dtt3
        '    cmb_departlocate.ValueMember = "department_id"
        '    cmb_departlocate.DisplayMember = "department_name"
        '    cmb_departlocate.Text = ""

        '    strcon.Close()
        '    daa3.Dispose()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    strcon.Close()
        'End Try
    End Sub

    Private Sub dgv_designation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_designation.CellContentClick
        lbl_assignedno.Text = dgv_designation.CurrentRow.Cells(0).Value
        lbl_unitid.Text = dgv_designation.CurrentRow.Cells(1).Value
        txtb_serialno.Text = dgv_designation.CurrentRow.Cells(2).Value
        txtb_model.Text = dgv_designation.CurrentRow.Cells(3).Value
        lbl_unittype.Text = dgv_designation.CurrentRow.Cells(4).Value
        lbl_employeeno.Text = dgv_designation.CurrentRow.Cells(6).Value
        lbl_dateassigned.Text = dgv_designation.CurrentRow.Cells(7).Value
        txtb_designation.Text = dgv_designation.CurrentRow.Cells(8).Value

        strcon.Close()
        strcon.Open()

        cmd.CommandText = "SELECT * FROM tbl_allstocks WHERE unit_id = '" & lbl_unitid.Text & "'"
        cmd.Connection = strcon

        Dim dr2 As MySqlDataReader = cmd.ExecuteReader()

        dr2.Read()
        txtb_brand.Text = dr2.GetValue(3).ToString
        dr2.Dispose()

        If txtb_designation.Text = "Internal" Then
            Try
                strcon.Close()
                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_employee WHERE employee_no = '" & lbl_employeeno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    txtb_firstname.Text = dr.GetValue(1).ToString
                    txtb_middlename.Text = dr.GetValue(2).ToString
                    txtb_surname.Text = dr.GetValue(3).ToString
                    txtb_suffix.Text = dr.GetValue(4).ToString
                    cmb_departlocate.Text = dr.GetValue(5).ToString
                    dr.Dispose()
                    strcon.Close()
                End If
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        ElseIf txtb_designation.Text = "External" Then
            lbl_department.Text = "LOCATION"
            Try
                strcon.Close()
                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_employeeexternal WHERE employee_no = '" & lbl_employeeno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    txtb_firstname.Text = dr.GetValue(1).ToString
                    txtb_middlename.Text = dr.GetValue(2).ToString
                    txtb_surname.Text = dr.GetValue(3).ToString
                    txtb_suffix.Text = dr.GetValue(4).ToString
                    cmb_departlocate.Text = dr.GetValue(5).ToString
                    dr.Dispose()
                    strcon.Close()
                End If
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub

    Public Sub RETURNFUNCTION()
        If txtb_designation.Text = "Internal" Then
            Dim fullname As String = txtb_firstname.Text + " " + txtb_surname.Text + " " + txtb_suffix.Text
            Try
                strcon.Close()
                deletes("DELETE FROM tbl_unitdesignation WHERE assigned_no = '" & lbl_assignedno.Text & "'")
                deletes("DELETE FROM tbl_designateinternal WHERE assigned_no = '" & lbl_assignedno.Text & "'")
                updates("UPDATE tbl_allstocks SET unit_condition = '" & cmb_condition.Text & "', availability = '" & lbl_availability.Text & "' WHERE unit_id = '" & lbl_unitid.Text & "'")
                create("INSERT INTO tbl_inventorystorage(unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES('" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_brand.Text & "','" & txtb_model.Text & "','" & lbl_unittype.Text & "','" & cmb_condition.Text & "')")
                create("INSERT INTO tbl_returnedunit(assigned_no,unit_id,serial_number,model,unit_condition,return_reason,assigned_to,employee_no,designation,date_assigned,date_returned) VALUES('" & lbl_assignedno.Text & "','" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_model.Text & "','" & cmb_condition.Text & "','" & cmb_reason.Text & "','" & fullname & "','" & lbl_employeeno.Text & "','" & cmb_departlocate.Text & "','" & lbl_dateassigned.Text & "','" & lbl_datetoday.Text & "')")
                reload("SELECT * FROM tbl_unitdesignation", dgv_designation)
                MessageBox.Show("Item successfully returned!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf txtb_designation.Text = "External" Then
            Dim fullname As String = txtb_firstname.Text + " " + txtb_surname.Text + " " + txtb_suffix.Text
            Try
                strcon.Close()
                deletes("DELETE FROM tbl_unitdesignation WHERE assigned_no = '" & lbl_assignedno.Text & "'")
                deletes("DELETE FROM tbl_designateexternal WHERE assigned_no = '" & lbl_assignedno.Text & "'")
                updates("UPDATE tbl_allstocks SET unit_condition = '" & cmb_condition.Text & "', availability = '" & lbl_availability.Text & "' WHERE unit_id = '" & lbl_unitid.Text & "'")
                create("INSERT INTO tbl_inventorystorage(unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES('" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_brand.Text & "','" & txtb_model.Text & "','" & lbl_unittype.Text & "','" & cmb_condition.Text & "')")
                create("INSERT INTO tbl_returnedunit(assigned_no,unit_id,serial_number,model,unit_condition,return_reason,assigned_to,employee_no,designation,date_assigned,date_returned) VALUES('" & lbl_assignedno.Text & "','" & lbl_unitid.Text & "','" & txtb_serialno.Text & "','" & txtb_model.Text & "','" & cmb_condition.Text & "','" & cmb_reason.Text & "','" & fullname & "','" & lbl_employeeno.Text & "','" & cmb_departlocate.Text & "','" & lbl_dateassigned.Text & "','" & lbl_datetoday.Text & "')")
                reload("SELECT * FROM tbl_unitdesignation", dgv_designation)
                MessageBox.Show("Item successfully returned!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
       
    End Sub

    
    Private Sub cmb_condition_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_condition.SelectedValueChanged
        If cmb_condition.Text = "Defective" Then
            lbl_availability.Text = "Not Available"
        ElseIf cmb_condition.Text = "Working" Then
            lbl_availability.Text = "Available"
        End If
    End Sub

    Private Sub cmb_reason_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_reason.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_condition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_condition.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtb_model_TextChanged(sender As Object, e As EventArgs) Handles txtb_model.TextChanged
        If txtb_model.Text = "" Then
            btn_return.Enabled = False
            btn_cancel.Enabled = False
            ' cmb_condition.Enabled = False
            cmb_reason.Enabled = False
        Else
            btn_return.Enabled = True
            btn_cancel.Enabled = True
            ' cmb_condition.Enabled = True
            cmb_reason.Enabled = True
        End If
    End Sub

    Private Sub btn_return_Click(sender As Object, e As EventArgs) Handles btn_return.Click
        If cmb_reason.Text = "" And cmb_condition.Text = "" Then
            MessageBox.Show("Please complete the required information first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf cmb_condition.Text = "" Then
            MessageBox.Show("Please include the item's current condition", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf cmb_reason.Text = "" Then
            MessageBox.Show("Please choose the reason for return", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            RETURNFUNCTION()
            cleartext()
        End If

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
       
    End Sub
    Public Sub cleartext()
        lbl_unittype.Text = ""
        lbl_unitid.Text = ""
        txtb_serialno.Text = ""
        txtb_model.Text = ""
        txtb_brand.Text = ""
        lbl_assignedno.Text = ""
        lbl_employeeno.Text = ""
        txtb_firstname.Text = ""
        txtb_middlename.Text = ""
        txtb_surname.Text = ""
        txtb_suffix.Text = ""
        lbl_availability.Text = ""
        lbl_dateassigned.Text = ""
        txtb_designation.Text = ""
        cmb_departlocate.Text = ""
        cmb_reason.Text = ""
        cmb_condition.Text = ""
    End Sub

    Private Sub cmb_reason_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_reason.SelectedValueChanged
        If cmb_reason.Text = "Replacement" Or cmb_reason.Text = "Slow Performance" Then
            cmb_condition.Text = "Working"
        ElseIf cmb_reason.Text = "Need for Repair" Then
            cmb_condition.Text = "Defective"
        End If
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

    'Iscollapse'
    Private Sub btn_dashassign_Click(sender As Object, e As EventArgs) Handles btn_dashassign.Click
        IsCollapsed3 = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer6.Start()
        Timer5.Start()
    End Sub
    'Iscollapse3'
    Private Sub btn_dashstock_Click(sender As Object, e As EventArgs) Handles btn_dashstock.Click
        IsCollapsed = False
        IsCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer6.Start()
        Timer5.Start()
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
        'storage_return.lbl_userid.Text = lbl_userid.Text
        'storage_return.lbl_fname.Text = lbl_fname.Text
        'storage_return.lbl_lname.Text = lbl_lname.Text
        'storage_return.lbl_username.Text = lbl_username.Text
        'storage_return.lbl_position.Text = lbl_position.Text
        'storage_return.lbl_fullname.Text = lbl_fullname.Text
        'storage_return.Show()
        'Me.Close()
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        settings_account.lbl_userid.Text = lbl_userid.Text
        settings_account.lbl_fname.Text = lbl_fname.Text
        settings_account.lbl_lname.Text = lbl_lname.Text
        settings_account.lbl_username.Text = lbl_username.Text
        settings_account.lbl_position.Text = lbl_position.Text
        settings_account.lbl_fullname.Text = lbl_fullname.Text
        settings_account.Show()
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
        assign_external.lbl_userid.Text = lbl_userid.Text
        assign_external.lbl_fname.Text = lbl_fname.Text
        assign_external.lbl_lname.Text = lbl_lname.Text
        assign_external.lbl_username.Text = lbl_username.Text
        assign_external.lbl_position.Text = lbl_position.Text
        assign_external.lbl_fullname.Text = lbl_fullname.Text
        assign_external.Show()
        Me.Close()
    End Sub

    'HOVER DESIGNATION'
    Private Sub btn_designateinternal_Click(sender As Object, e As EventArgs) Handles btn_designateinternal.Click
        designation_internal.lbl_userid.Text = lbl_userid.Text
        designation_internal.lbl_fname.Text = lbl_fname.Text
        designation_internal.lbl_lname.Text = lbl_lname.Text
        designation_internal.lbl_username.Text = lbl_username.Text
        designation_internal.lbl_position.Text = lbl_position.Text
        designation_internal.lbl_fullname.Text = lbl_fullname.Text
        designation_internal.Show()
        Me.Close()
    End Sub

    Private Sub btn_designateexternal_Click(sender As Object, e As EventArgs) Handles btn_designateexternal.Click
        designate_external.lbl_userid.Text = lbl_userid.Text
        designate_external.lbl_fname.Text = lbl_fname.Text
        designate_external.lbl_lname.Text = lbl_lname.Text
        designate_external.lbl_username.Text = lbl_username.Text
        designate_external.lbl_position.Text = lbl_position.Text
        designate_external.lbl_fullname.Text = lbl_fullname.Text
        designate_external.Show()
        Me.Close()
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

    Private Sub txtbx_search_TextChanged(sender As Object, e As EventArgs) Handles txtbx_search.TextChanged
        FilterData(txtbx_search.Text)
    End Sub

    'FOR SEARCH FUNCTION
    Public Sub FilterData(valueToSearch As String)
     
        strcon.Close()
        strcon.Open()
        Dim searchquery As String = "SELECT * FROM tbl_unitdesignation WHERE CONCAT(serial_number,unit_id,model,unit_type,assigned_to,employee_no) LIKE '%" & txtbx_search.Text & "%'"
        Dim command As New MySqlCommand(searchquery, strcon)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)

        dgv_designation.DataSource = table
        strcon.Close()
    End Sub

   
 
   
    Private Sub btn_settingsaccount_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class