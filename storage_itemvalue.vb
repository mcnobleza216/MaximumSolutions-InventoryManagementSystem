Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class storage_itemvalue
    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True

    Private Sub storage_itemvalue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
        FilterData("")

        dtp_dateadded.MaxDate = Date.Today
        dtp_dateadded.Value = Convert.ToDateTime(Date.Today)
        dtp_purchased.MaxDate = Date.Today
        dtp_purchased.Value = Convert.ToDateTime(Date.Today)

    End Sub
    Public Sub FilterData(valueToSearch As String)
        strcon.Close()
        strcon.Open()

        Dim searchquery As String = "select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number WHERE CONCAT(tbl_allstocksvalue.serial_number,tbl_allstocksvalue.model,tbl_allstocksvalue.brand_name,tbl_allstocksvalue.unit_type,tbl_allstocksvalue.purchased_value,tbl_allstocksvalue.depreciation_value) LIKE '%" & txtbx_search.Text & "%'"
        Dim command As New MySqlCommand(searchquery, strcon)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        dgv_stockunit.DataSource = table
        strcon.Close()
    End Sub

    Private Sub txtbx_search_TextChanged(sender As Object, e As EventArgs) Handles txtbx_search.TextChanged
        FilterData(txtbx_search.Text)
    End Sub

    Private Sub dgv_stockunit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_stockunit.CellContentClick
        ' lbl_unittype.Visible = True
        txtbx_purchasedval.Text = dgv_stockunit.CurrentRow.Cells(5).Value

        If txtbx_purchasedval.Text = "0" Then
            MessageBox.Show("This item doesn't have a value in our record, must be an old item", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cleartext()

        Else
            lbl_unitid.Text = dgv_stockunit.CurrentRow.Cells(0).Value
            txtbx_serialno.Text = dgv_stockunit.CurrentRow.Cells(1).Value
            txtbx_brand.Text = dgv_stockunit.CurrentRow.Cells(2).Value
            txtbx_model.Text = dgv_stockunit.CurrentRow.Cells(3).Value
            txtbx_unittype.Text = dgv_stockunit.CurrentRow.Cells(4).Value
            txtbx_purchasedval.Text = dgv_stockunit.CurrentRow.Cells(5).Value
            dtp_purchased.Text = dgv_stockunit.CurrentRow.Cells(7).Value
            dtp_dateadded.Text = dgv_stockunit.CurrentRow.Cells(8).Value

            lbl_purchasedvalue.Text = txtbx_purchasedval.Text
            lbl_dtpvalue.Text = dtp_purchased.Text

            'txtbx_depreciatedval.Text = dgv_stockunit.CurrentRow.Cells(6).Value
            GetDateDiff()
            ' reload("select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
            '  txtb_depreciatedvalue.Text = dgv_stockunit.CurrentRow.Cells(9).Value
        End If
       
    End Sub

    Public Sub GetDateDiff()
        Try
            Dim depreciationspan As Integer

            strcon.Open()

            cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = '" & txtbx_unittype.Text & "'"
            cmd.Connection = strcon

            depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())



            Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
            Dim purchaseddate As DateTime = Convert.ToDateTime(dtp_purchased.Text)


            Dim swapped = False

            If purchaseddate > currdate Then
                Dim temp = purchaseddate

                purchaseddate = currdate
                currdate = temp

                swapped = True
            End If

            Dim months As Integer = 0

            Do Until currdate.AddMonths(-1) < purchaseddate
                months += 1
                currdate = currdate.AddMonths(-1)
            Loop

            If swapped Then
                months = -months
            End If
            lbl_monthdiff.Text = months

            Dim purchasedvalue As Double
            Dim depreciation_year As Double
            Dim depreciation_month As Double

            purchasedvalue = Convert.ToDouble(txtbx_purchasedval.Text)

            depreciation_year = purchasedvalue / depreciationspan
            depreciation_month = depreciation_year / 12

            Dim totaldepreciation As Double
            Dim depreciatedvalue As Double

            totaldepreciation = months * depreciation_month

            depreciatedvalue = Convert.ToDouble(txtbx_purchasedval.Text) - totaldepreciation

            txtbx_depreciatedval.Text = Math.Round(depreciatedvalue, 2)
            lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

            strcon.Close()


            ' updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & txtbx_depreciatedval.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
            'reload("select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
            '   strcon.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub disabletext()
        txtbx_unittype.ReadOnly = True
        txtbx_brand.ReadOnly = True
        txtbx_depreciatedval.ReadOnly = True
        txtbx_model.ReadOnly = True
        txtbx_serialno.ReadOnly = True
        txtbx_depreciatedval.ReadOnly = True
        txtbx_purchasedval.ReadOnly = True
        dtp_dateadded.Enabled = False
        dtp_purchased.Enabled = False
    End Sub

    Public Sub cleartext()
        txtbx_unittype.Text = ""
        lbl_unitid.Text = "-------"
        txtbx_model.Text = ""
        txtbx_serialno.Text = ""
        txtbx_brand.Text = ""

        txtbx_purchasedval.Text = "0"
        txtbx_depreciatedval.Text = "0"
        dtp_dateadded.Value = Convert.ToDateTime(Date.Today)
        dtp_purchased.Value = Convert.ToDateTime(Date.Today)
    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        disabletext()
        txtbx_purchasedval.Enabled = False
        dtp_purchased.Enabled = False
        cleartext()

        btn_update2.Hide()
        btn_update.Show()
        btn_cancel.Hide()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If txtbx_unittype.Text = "" Then
            MessageBox.Show("Select an item from the record first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            disabletext()
            btn_update.Hide()
            btn_update2.Enabled = True
            btn_update2.Show()
            btn_cancel.Enabled = True
            btn_cancel.Show()
            dtp_purchased.Enabled = True
            txtbx_purchasedval.ReadOnly = False
            txtbx_purchasedval.Enabled = True
        End If
    End Sub

    Private Sub btn_update2_Click(sender As Object, e As EventArgs) Handles btn_update2.Click
        If txtbx_purchasedval.Text = lbl_purchasedvalue.Text And dtp_purchased.Text = lbl_dtpvalue.Text Then
            MessageBox.Show("There is no changes made in the fields", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            storage_updateitemvalue.lbl_unittype.Text = txtbx_unittype.Text
            storage_updateitemvalue.lbl_serialno.Text = txtbx_serialno.Text
            storage_updateitemvalue.lbl_purchasedvalue.Text = txtbx_purchasedval.Text
            storage_updateitemvalue.lbl_depreciatedvalue.Text = txtbx_depreciatedval.Text
            storage_updateitemvalue.lbl_datepurchased.Text = dtp_purchased.Text
            storage_updateitemvalue.Show()
        End If
     



    End Sub

    Private Sub dtp_purchased_CloseUp(sender As Object, e As EventArgs) Handles dtp_purchased.CloseUp
        GetDateDiff()
    End Sub

    Private Sub txtbx_purchasedval_TextChanged(sender As Object, e As EventArgs) Handles txtbx_purchasedval.TextChanged
        If txtbx_purchasedval.Text <> "" Then
            GetDateDiff()
        End If
    End Sub

    Private Sub cmb_sortby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_sortby.SelectedIndexChanged
        reload("select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number WHERE tbl_allstocksvalue.unit_type = '" & cmb_sortby.Text & "'", dgv_stockunit)
    End Sub

    Private Sub cmb_sortby_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_sortby.KeyPress
        e.Handled = True
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
        'storage_itemvalue.lbl_userid.Text = lbl_userid.Text
        'storage_itemvalue.lbl_fname.Text = lbl_fname.Text
        'storage_itemvalue.lbl_lname.Text = lbl_lname.Text
        'storage_itemvalue.lbl_username.Text = lbl_username.Text
        'storage_itemvalue.lbl_position.Text = lbl_position.Text
        'storage_itemvalue.lbl_fullname.Text = lbl_fullname.Text
        'storage_itemvalue.Show()
        'Me.Close()
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

    Private Sub txtbx_purchasedval_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class