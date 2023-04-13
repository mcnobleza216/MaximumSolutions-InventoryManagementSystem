Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text
Public Class settings_employee
    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True

    Private Sub settings_employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("SELECT * FROM tbl_employee", dgv_internal)

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

    End Sub

    Public Sub cleartext()
        lbl_employeeno.Text = "-------"
        '      lbl_employeeno2.Text = ""
        txtb_firstname.Text = ""
        '     txtb_firstname2.Text = ""
        txtb_middlename.Text = ""
        '    txtb_middlename2.Text = ""
        txtb_lastname.Text = ""
        '   txtb_lastname2.Text = ""
        cmb_suffix.Text = "Select"
        '   cmb_suffix2.Text = ""
        cmb_department.Text = "Select"
        '  cmb_location.Text = ""
    End Sub

    Public Sub disabletext()
        txtb_firstname.Enabled = False
        '   txtb_firstname2.Enabled = False
        txtb_middlename.Enabled = False
        '   txtb_middlename2.Enabled = False
        txtb_lastname.Enabled = False
        '    txtb_lastname2.Enabled = False
        cmb_suffix.Enabled = False
        '    cmb_suffix2.Enabled = False
        cmb_department.Enabled = False
        ' cmb_location.Enabled = False
    End Sub

    Public Sub enabletext()
        txtb_firstname.Enabled = True
        '   txtb_firstname2.Enabled = True
        txtb_middlename.Enabled = True
        '   txtb_middlename2.Enabled = True
        txtb_lastname.Enabled = True
        '   txtb_lastname2.Enabled = True
        cmb_suffix.Enabled = True
        '  cmb_suffix2.Enabled = True
        cmb_department.Enabled = True
        '  cmb_location.Enabled = True
    End Sub

    Private Sub cmb_employeetype_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_employeetype.SelectedValueChanged
        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            cleartext()
            lbl_department.Text = "DEPARTMENT:"
            dgv_external.Visible = False
            dgv_internal.Visible = True
            reload("SELECT * FROM tbL_employee", dgv_internal)
        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            cleartext()
            lbl_department.Text = "LOCATION:"
            dgv_external.Visible = True
            dgv_internal.Visible = False
            reload("SELECT * FROM tbL_employeeexternal", dgv_external)
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        enabletext()
        cleartext()
        btn_add2.Show()
        btn_cancel.Show()
        ' btn_clear.Show()

        btn_add.Hide()
        btn_update.Hide()
        btn_update2.Hide()
        btn_remove.Hide()

        cmb_employeetype.Enabled = False

        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            Try
                Dim unitID As String
                strcon.Open()

                cmd.CommandText = "SELECT employee_no FROM tbl_allemployees ORDER BY employee_no DESC LIMIT 1"
                cmd.Connection = strcon

                unitID = Convert.ToInt32(cmd.ExecuteScalar())


                If unitID >= 1 Then
                    Dim finalunitid As Integer
                    finalunitid = unitID + 1
                    lbl_employeeno.Text = finalunitid
                    strcon.Close()
                Else
                    Dim finalunitid2 As Integer
                    finalunitid2 = 10001
                    lbl_employeeno.Text = finalunitid2
                    strcon.Close()
                End If
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try

            Try
                Dim cmdd As New MySqlCommand
                Dim daa As New MySqlDataAdapter
                Dim dtt As New DataTable

                strcon.Open()

                cmdd.Connection = strcon
                cmdd.CommandText = "SELECT * FROM tbl_departments"

                daa.SelectCommand = cmdd
                daa.Fill(dtt)

                cmb_department.DataSource = dtt
                cmb_department.ValueMember = "department_id"
                cmb_department.DisplayMember = "department_name"
                cmb_department.Text = "Select"

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
                da.Dispose()
            End Try

          
        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            Try
                Dim unitID As String
                strcon.Open()

                cmd.CommandText = "SELECT employee_no FROM tbl_allemployees ORDER BY employee_no DESC LIMIT 1"
                cmd.Connection = strcon

                unitID = Convert.ToInt32(cmd.ExecuteScalar())


                If unitID >= 1 Then
                    Dim finalunitid As Integer
                    finalunitid = unitID + 1
                    lbl_employeeno.Text = finalunitid
                    strcon.Close()
                Else
                    Dim finalunitid2 As Integer
                    finalunitid2 = 10001
                    lbl_employeeno.Text = finalunitid2
                    strcon.Close()
                End If
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
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

                cmb_department.DataSource = dtt
                cmb_department.ValueMember = "location_ID"
                cmb_department.DisplayMember = "name"
                cmb_department.Text = "Select"

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
                da.Dispose()
            End Try
        End If
      
    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        cleartext()

        btn_add2.Hide()
        btn_update2.Hide()
        btn_remove.Show()
        btn_add.Show()
        btn_update.Show()
       ' btn_clear.Hide()
        btn_cancel.Hide()
        lbl_employeeno.Text = "-------"
        '  lbl_employeeno.Text = "-------"
        cmb_employeetype.Enabled = True
        disabletext()
    End Sub

    Public Sub ADDEMPLOYEE()
       
        ' Dim action1 As String = "Add Employee No. " + lbl_employeeno.Text
        ' Dim action2 As String = "Add Employee No. " + lbl_employeeno2.Text
        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            Try
                strcon.Close()
                create("INSERT INTO tbl_employee (employee_no,first_name,middle_name,last_name,suffix,department) VALUES ('" & lbl_employeeno.Text & "','" & txtb_firstname.Text & "','" & txtb_middlename.Text & "','" & txtb_lastname.Text & "','" & cmb_suffix.Text & "','" & cmb_department.Text & "')")
                create("INSERT INTO tbl_allemployees (employee_no,first_name,middle_name,last_name,suffix,employee_type,date_added) VALUES ('" & lbl_employeeno.Text & "','" & txtb_firstname.Text & "','" & txtb_middlename.Text & "','" & txtb_lastname.Text & "','" & cmb_suffix.Text & "','Internal','" & lbl_datetoday.Text & "')")
                'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action1 & "','" & lbl_datetoday.Text & "')")
                MessageBox.Show("Internal Employee added successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("SELECT * FROM tbl_employee", dgv_internal)
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            Try
                strcon.Close()
                create("INSERT INTO tbl_employeeexternal (employee_no,first_name,middle_name,last_name,suffix,location) VALUES ('" & lbl_employeeno.Text & "','" & txtb_firstname.Text & "','" & txtb_middlename.Text & "','" & txtb_lastname.Text & "','" & cmb_suffix.Text & "','" & cmb_department.Text & "')")
                create("INSERT INTO tbl_allemployees (employee_no,first_name,middle_name,last_name,suffix,employee_type,date_added) VALUES ('" & lbl_employeeno.Text & "','" & txtb_firstname.Text & "','" & txtb_middlename.Text & "','" & txtb_lastname.Text & "','" & cmb_suffix.Text & "','External','" & lbl_datetoday.Text & "')")
                'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action2 & "','" & lbl_datetoday.Text & "')")
                MessageBox.Show("External Employee added successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("SELECT * FROM tbl_employeeexternal", dgv_external)
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

   

    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click
        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            If txtb_firstname.Text = "" Or txtb_middlename.Text = "" Or txtb_lastname.Text = "" Or cmb_department.Text = "Select" Or cmb_suffix.Text = "Select" Then
                MessageBox.Show("All information must be provided", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If cmb_suffix.Text = "None" Then
                    cmb_suffix.Text = ""
                End If
                ADDEMPLOYEE()
                btn_cancel.Hide()
                btn_add2.Hide()
                btn_add.Show()
                btn_update.Show()
                btn_remove.Show()
                cleartext()
                disabletext()
                cmb_employeetype.Enabled = True
            End If

        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            If txtb_firstname.Text = "" Or txtb_middlename.Text = "" Or txtb_lastname.Text = "" Or cmb_department.Text = "Select" Or cmb_suffix.Text = "Select" Then
                MessageBox.Show("All information must be provided", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If cmb_suffix.Text = "None" Then
                    cmb_suffix.Text = ""
                End If
                ADDEMPLOYEE()
                btn_cancel.Hide()
                btn_add2.Hide()
                btn_add.Show()
                btn_update.Show()
                btn_remove.Show()
                cleartext()
                disabletext()
                cmb_employeetype.Enabled = True
            End If

        End If

    End Sub

    Private Sub cmb_department_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_department.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_suffix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_suffix.KeyPress
        e.Handled = True
    End Sub

    Private Sub dgv_external_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_external.CellContentClick
        lbl_employeeno.Text = dgv_external.CurrentRow.Cells(0).Value
        txtb_firstname.Text = dgv_external.CurrentRow.Cells(1).Value
        txtb_middlename.Text = dgv_external.CurrentRow.Cells(2).Value
        txtb_lastname.Text = dgv_external.CurrentRow.Cells(3).Value
        cmb_suffix.Text = dgv_external.CurrentRow.Cells(4).Value
        cmb_department.Text = dgv_external.CurrentRow.Cells(5).Value

        '   lbl_employeeno.Text = dgv_external.CurrentRow.Cells(0).Value
        lbl_firstname.Text = dgv_external.CurrentRow.Cells(1).Value
        lbl_middlename.Text = dgv_external.CurrentRow.Cells(2).Value
        lbl_lastname.Text = dgv_external.CurrentRow.Cells(3).Value
        lbl_suffix.Text = dgv_external.CurrentRow.Cells(4).Value
        lbl_depart.Text = dgv_external.CurrentRow.Cells(5).Value
    End Sub

    Private Sub dgv_internal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_internal.CellContentClick
        lbl_employeeno.Text = dgv_internal.CurrentRow.Cells(0).Value
        txtb_firstname.Text = dgv_internal.CurrentRow.Cells(1).Value
        txtb_middlename.Text = dgv_internal.CurrentRow.Cells(2).Value
        txtb_lastname.Text = dgv_internal.CurrentRow.Cells(3).Value
        cmb_suffix.Text = dgv_internal.CurrentRow.Cells(4).Value
        cmb_department.Text = dgv_internal.CurrentRow.Cells(5).Value

        lbl_firstname.Text = dgv_internal.CurrentRow.Cells(1).Value
        lbl_middlename.Text = dgv_internal.CurrentRow.Cells(2).Value
        lbl_lastname.Text = dgv_internal.CurrentRow.Cells(3).Value
        lbl_suffix.Text = dgv_internal.CurrentRow.Cells(4).Value
        lbl_depart.Text = dgv_internal.CurrentRow.Cells(5).Value
    End Sub
    Public Sub EDITEMPLOYEE()
        Dim datetoday As String = DateTime.Now.ToString()
        lbl_datetoday.Text = datetoday
        ' Dim action1 As String = "Edit data of Employee No. " + lbl_employeeno.Text
        ' Dim action2 As String = "Edit data ofEmployee No. " + lbl_employeeno2.Text
        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            Try
                strcon.Close()
                updates("UPDATE tbl_employee SET first_name = '" & txtb_firstname.Text & "',middle_name = '" & txtb_middlename.Text & "',last_name = '" & txtb_lastname.Text & "',suffix = '" & cmb_suffix.Text & "',department = '" & cmb_department.Text & "' ")
                'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action2 & "','" & lbl_datetoday.Text & "')")
                MessageBox.Show("Internal Employee data editted successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("SELECT * FROM tbl_employee", dgv_internal)
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            Try
                strcon.Close()
                updates("UPDATE tbl_employeeexternal SET first_name = '" & txtb_firstname.Text & "',middle_name = '" & txtb_middlename.Text & "',last_name = '" & txtb_lastname.Text & "',suffix = '" & cmb_suffix.Text & "',location = '" & cmb_department.Text & "' ")
                'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action2 & "','" & lbl_datetoday.Text & "')")
                MessageBox.Show("External Employee data editted successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("SELECT * FROM tbl_employeeexternal", dgv_external)
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If lbl_employeeno.Text = "-------" Then
            MessageBox.Show("Select an employee's data first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            enabletext()
            '   cleartext()
            btn_update2.Show()
            btn_cancel.Show()
            ' btn_clear.Show()

            btn_add.Hide()
            btn_add2.Hide()
            btn_update.Hide()
            ' btn_update2.Hide()
            btn_remove.Hide()

            cmb_employeetype.Enabled = False

            If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then

                Try
                    Dim cmdd As New MySqlCommand
                    Dim daa As New MySqlDataAdapter
                    Dim dtt As New DataTable

                    strcon.Open()

                    cmdd.Connection = strcon
                    cmdd.CommandText = "SELECT * FROM tbl_departments"

                    daa.SelectCommand = cmdd
                    daa.Fill(dtt)

                    cmb_department.DataSource = dtt
                    cmb_department.ValueMember = "department_id"
                    cmb_department.DisplayMember = "department_name"
                    cmb_department.Text = lbl_depart.Text

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                    da.Dispose()
                End Try

            ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
                Try
                    Dim cmdd As New MySqlCommand
                    Dim daa As New MySqlDataAdapter
                    Dim dtt As New DataTable

                    strcon.Open()

                    cmdd.Connection = strcon
                    cmdd.CommandText = "SELECT * FROM tbl_externallocation"

                    daa.SelectCommand = cmdd
                    daa.Fill(dtt)

                    cmb_department.DataSource = dtt
                    cmb_department.ValueMember = "location_ID"
                    cmb_department.DisplayMember = "name"
                    cmb_department.Text = lbl_depart.Text

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                    da.Dispose()
                End Try
            End If
        End If
    End Sub

    Private Sub btn_update2_Click(sender As Object, e As EventArgs) Handles btn_update2.Click
        If txtb_firstname.Text = "" Or txtb_middlename.Text = "" Or txtb_lastname.Text = "" Or cmb_department.Text = "Select" Or cmb_suffix.Text = "Select" Then
            MessageBox.Show("All information must be provided", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf txtb_firstname.Text = lbl_firstname.Text And txtb_middlename.Text = lbl_middlename.Text And txtb_lastname.Text = lbl_lastname.Text And lbl_suffix.Text = cmb_suffix.Text And lbl_depart.Text = cmb_department.Text Then
            MessageBox.Show("There is no any changes made", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If cmb_suffix.Text = "None" Then
                cmb_suffix.Text = ""
            End If
            EDITEMPLOYEE()
            btn_cancel.Hide()
            btn_update2.Hide()
            btn_add.Show()
            btn_update.Show()
            btn_remove.Show()
            cleartext()
            disabletext()
            cmb_employeetype.Enabled = True
        End If
    End Sub

    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
        If lbl_employeeno.Text = "-------" Then
            MessageBox.Show("Select an employee first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove this employee from the list?", "REMOVE EMPLOYEE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                settings_security.lbl_action.Text = "Remove Employee"
                settings_security.lbl_employeeno.Text = lbl_employeeno.Text
                settings_security.lbl_employeetype.Text = cmb_employeetype.Text

                settings_security.Show()
            End If
        End If
    End Sub

    'FOR SEARCH FUNCTION
    Public Sub FilterData(valueToSearch As String)
        Dim searchby As String
        If cmb_sortby.Text = "Employee No." Then
            searchby = "employee_no"
        ElseIf cmb_sortby.Text = "First Name" Then
            searchby = "first_name"
        ElseIf cmb_sortby.Text = "Middle Name" Then
            searchby = "middle_name"
        ElseIf cmb_sortby.Text = "Last Name" Then
            searchby = "last_name"
        ElseIf cmb_sortby.Text = "Suffix" Then
            searchby = "suffix"
        End If
        strcon.Close()
        strcon.Open()
        If cmb_employeetype.Text = "INTERNAL EMPLOYEE" Then
            Dim searchquery As String = "SELECT * FROM tbl_employee WHERE CONCAT(" & searchby & ") LIKE '%" & txtbx_search.Text & "%'"
            Dim command As New MySqlCommand(searchquery, strcon)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable

            adapter.Fill(table)

            dgv_internal.DataSource = table
            strcon.Close()
        ElseIf cmb_employeetype.Text = "EXTERNAL EMPLOYEE" Then
            Dim searchquery As String = "SELECT * FROM tbl_employeeexternal WHERE CONCAT(" & searchby & ") LIKE '%" & txtbx_search.Text & "%'"
            Dim command As New MySqlCommand(searchquery, strcon)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable

            adapter.Fill(table)

            dgv_external.DataSource = table
            strcon.Close()
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
        'settings_employee.lbl_userid.Text = lbl_userid.Text
        'settings_employee.lbl_fname.Text = lbl_fname.Text
        'settings_employee.lbl_lname.Text = lbl_lname.Text
        'settings_employee.lbl_username.Text = lbl_username.Text
        'settings_employee.lbl_position.Text = lbl_position.Text
        'settings_employee.lbl_fullname.Text = lbl_fullname.Text
        'settings_employee.Show()
        'Me.Close()
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

    Private Sub cmb_employeetype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_employeetype.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtbx_search_TextChanged(sender As Object, e As EventArgs) Handles txtbx_search.TextChanged
        FilterData(txtbx_search.Text)
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
End Class