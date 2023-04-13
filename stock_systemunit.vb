﻿Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class stock_systemunit

    Dim con As New MySqlConnection("server=localhost; database=dbinventory;username=root;password=root")

    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True

    Dim dttable As New DataTable
    Dim dr As MySqlDataReader

    Private Sub stock_systemunit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("SELECT * FROM tbl_stockpcunit", dgv_stockunit)
        FilterData("")

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

        Btn_Add2.Hide()
        btn_clear.Hide()
        btn_cancel.Hide()

        txtbx_serialno.Focus()
        txtbx_serialno.Show()
        txtbx_addunit.Hide()
        dtp_purchased.MaxDate = Date.Today
        dtp_purchased.Value = Convert.ToDateTime(Date.Today)
        ' btn_clear2.Enabled = False
        lbl_unitid.Text = "-------"

        Try
            Dim cmdd As New MySqlCommand
            Dim daa As New MySqlDataAdapter
            Dim dtt As New DataTable

            strcon.Open()

            cmdd.Connection = strcon
            cmdd.CommandText = "SELECT * FROM tbl_cpumanufacturer"

            daa.SelectCommand = cmdd
            daa.Fill(dtt)

            cmb_manufacturer.DataSource = dtt
            cmb_manufacturer.ValueMember = "manufacturer_ID"
            cmb_manufacturer.DisplayMember = "name"

            cmb_manufacturer.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
            da.Dispose()

        End Try

        Try
            Dim cmd3 As New MySqlCommand
            Dim daa3 As New MySqlDataAdapter
            Dim dtt3 As New DataTable

            strcon.Open()

            cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'System unit'"
            cmd3.Connection = strcon

            daa3.SelectCommand = cmd3
            daa3.Fill(dtt3)

            cmb_brand.DataSource = dtt3
            cmb_brand.ValueMember = "brand_id"
            cmb_brand.DisplayMember = "brand_name"
            cmb_brand.Text = ""

            strcon.Close()
            daa3.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try


    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Log out success, you will be prompt to Login Screen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub btn_stockadduinit_Click(sender As Object, e As EventArgs) Handles btn_stockadduinit.Click
        dtp_purchased.Show()
        lbl_datepurch.Show()
        DisableText()
        ClearText()
        CMBPlaceHolder()
        Btn_Add2.Show()
        ' Btn_Update2.Hide()
        btn_stockadduinit.Hide()
        ' btn_updatestockunit.Hide()
        btn_clear.Show()
        btn_cancel.Show()
        lbl_depreciation.Hide()
        txtb_depreciatedvalue.Hide()
        dgv_stockunit.Enabled = False
        txtbx_addunit.Show()
        txtbx_serialno.Hide()
        lbl_unitid.Text = "-------"
        'btn_clear2.Hide()
        'lbl_totaldepreciation.Show()
        Button3.Visible = True
        txtbx_addunit.Text = ""
        txtbx_addunit.Enabled = True
    End Sub

    Private Sub dgv_stockunit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_stockunit.CellContentClick

        txtbx_serialno.Text = dgv_stockunit.CurrentRow.Cells(1).Value
       



        '  txtb_depreciatedvalue.Text = dgv_stockunit.CurrentRow.Cells(9).Value
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        ClearText()
        CMBPlaceHolder()
        lbl_unitid.Text = "-------"
        txtbx_addunit.Text = ""
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        btn_stockadduinit.Show()
        ' btn_updatestockunit.Show()
        dgv_stockunit.Enabled = True
        txtbx_serialno.Text = ""
        Btn_Add2.Hide()
        ' Btn_Update2.Hide()
        btn_clear.Hide()
        btn_cancel.Hide()

        ClearText()
        lbl_unitid.Text = "-------"
        cmb_manufacturer.Text = ""
        cmb_cpu.Text = ""
        cmb_memory.Text = ""
        cmb_version.Text = ""
        cmb_brand.Text = ""
        DisableText()
        txtbx_serialno.Show()
        txtbx_addunit.Hide()
        'btn_clear2.Show()
        Button3.Visible = False
        txtbx_serialno.Enabled = True
        dtp_purchased.Value = Convert.ToDateTime(Date.Today)
        If txtbx_serialno.Enabled = False Then
            txtbx_serialno.Enabled = True
        End If


    End Sub

    Private Sub Btn_Add2_Click(sender As Object, e As EventArgs) Handles Btn_Add2.Click
        Dim storage As Integer
        If txtb_storage.Text = "" Then
            storage = 0
        Else
            storage = Convert.ToInt32(txtb_storage.Text)
        End If

        If (lbl_unitid.Text = "" Or txtbx_addunit.Text = "" Or cmb_manufacturer.Text = "" Or cmb_cpu.Text = "" Or cmb_memory.Text = "" Or cmb_version.Text = "" Or txtb_storage.Text = "" Or txtb_purchasedvalue.Text = "" Or dtp_purchased.Text = "") Then
            MessageBox.Show("All information must be provided!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf storage > 5000 Or storage < 60 Then
            MessageBox.Show("Storage size seems incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            AddUnit()
            txtbx_addunit.Text = ""
            ClearText()
            dgv_stockunit.Enabled = True
        End If
    End Sub

    Private Sub btn_updatestockunit_Click(sender As Object, e As EventArgs)

        If txtbx_model.Text = "" Then
            MessageBox.Show("Please select a record first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            'Btn_Add2.Hide()
            'Btn_Delete2.Hide()
            EnableText()
            ' Btn_Update2.Show()
            btn_clear.Show()
            '   btn_cancel2.Show()
            ' btn_clear2.Hide()
            btn_stockadduinit.Hide()
            ' btn_updatestockunit.Hide()
            txtbx_serialno.Enabled = False
            dgv_stockunit.Enabled = False
        End If
    End Sub

    'CLEAR AND ENABLE AND DISABLE TOOLS SHORCUT
    Public Sub ClearText()
        lbl_unitid.Text = "-------"
        ' txtbx_serialno.Text = ""
        txtbx_model.Text = ""
        cmb_manufacturer.Text = "Please Select"
        cmb_cpu.Text = "Please Select"
        cmb_memory.Text = "Please Select"
        cmb_version.Text = "Please Select"
        txtb_storage.Text = ""
        txtb_purchasedvalue.Text = ""
        'dtp_purchased.Text = ""
        txtb_depreciatedvalue.Text = ""
        cmb_brand.Text = "Please Select"
        cmb_unitcondition.Text = ""
    End Sub
    Public Sub EnableText()
        lbl_unitid.Enabled = True
        txtbx_serialno.Enabled = True
        txtbx_model.Enabled = True
        cmb_manufacturer.Enabled = True
        cmb_cpu.Enabled = True
        cmb_memory.Enabled = True
        cmb_version.Enabled = True
        txtb_storage.Enabled = True
        txtb_purchasedvalue.Enabled = True
        dtp_purchased.Enabled = True
        cmb_brand.Enabled = True
        cmb_unitcondition.Enabled = True
        '  txtb_depreciatedvalue.Enabled = True
    End Sub
    Public Sub DisableText()
        ' lbl_unitid.Enabled = False
        ' txtbx_serialno.Enabled = False
        txtbx_model.Enabled = False
        cmb_manufacturer.Enabled = False
        cmb_cpu.Enabled = False
        cmb_memory.Enabled = False
        txtb_storage.Enabled = False
        cmb_version.Enabled = False
        txtb_purchasedvalue.Enabled = False
        dtp_purchased.Enabled = False
        cmb_brand.Enabled = False
        cmb_unitcondition.Enabled = False
        ' txtb_depreciatedvalue.Enabled = False
    End Sub

    Public Sub CMBPlaceHolder()
        cmb_manufacturer.Text = "Please Select"
        cmb_cpu.Text = "Please Select"
        cmb_memory.Text = "Select"
        cmb_version.Text = "Select"
        cmb_brand.Text = "Select"
        cmb_unitcondition.Text = "Select"
    End Sub

    Private Sub Btn_Delete2_Click(sender As Object, e As EventArgs)

    End Sub


    'GET THE DEPRECIATED VALUE'
    Public Sub GetDateDiff()
        Try
            Dim depreciationspan As Integer

            strcon.Open()

            cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'System unit'"
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

            purchasedvalue = Convert.ToDouble(txtb_purchasedvalue.Text)

            depreciation_year = purchasedvalue / depreciationspan
            depreciation_month = depreciation_year / 12

            Dim totaldepreciation As Double
            Dim depreciatedvalue As Double

            totaldepreciation = months * depreciation_month

            depreciatedvalue = Convert.ToDouble(txtb_purchasedvalue.Text) - totaldepreciation

            txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
            lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

            strcon.Close()
            ' updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & txtb_depreciatedvalue.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

            strcon.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub getunitcondition()
        Try

            strcon.Open()

            cmd.CommandText = "SELECT unit_condition from tbl_pcunitcondition WHERE serial_number = '" & txtbx_serialno.Text & "'"
            cmd.Connection = strcon

            Dim condition As String = Convert.ToString(cmd.ExecuteScalar())

            strcon.Close()

            cmb_unitcondition.Text = condition
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtb_storage_TextChanged(sender As Object, e As EventArgs) Handles txtb_storage.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtb_storage.Text = digitsOnly.Replace(txtb_storage.Text, "")
    End Sub

    Private Sub txtb_storage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_storage.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtbx_serialno_TextChanged(sender As Object, e As EventArgs) Handles txtbx_serialno.TextChanged
        Try
            If txtbx_serialno.Text = "" Then
                ' btn_clear2.Enabled = False

            Else
                '   btn_clear2.Enabled = True
                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_stockpcunit WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtbx_model.Text = dr.GetValue(3).ToString()
                    cmb_manufacturer.Text = dr.GetValue(4).ToString()
                    cmb_cpu.Text = dr.GetValue(5).ToString()
                    cmb_memory.Text = dr.GetValue(6).ToString()
                    cmb_version.Text = dr.GetValue(7).ToString()
                    txtb_storage.Text = dr.GetValue(8).ToString()
                    txtb_purchasedvalue.Text = dr.GetValue(9).ToString()
                    'Dim datestring As String = dr.GetValue(10).ToString()

                    If txtb_purchasedvalue.Text = "0" Then
                        txtb_purchasedvalue.Text = "Not Available"
                        dtp_purchased.Hide()
                        lbl_datepurch.Hide()
                        dr.Dispose()
                    Else
                        dtp_purchased.Show()
                        lbl_datepurch.Show()
                        dtp_purchased.Text = dr.GetValue(10).ToString()
                        dr.Dispose()
                        Dim cmdd As New MySqlCommand

                        cmdd.CommandText = "SELECT depreciation_value FROM tbl_stockpcunitvalue WHERE serial_number = '" & txtbx_serialno.Text & "'"
                        cmdd.Connection = strcon

                        Dim depreciatedvalue As Double = Convert.ToDouble(cmdd.ExecuteScalar())

                        txtb_depreciatedvalue.Text = depreciatedvalue

                        strcon.Close()
                        getunitcondition()

                        GetDateDiff()
                    End If

                Else
                    ClearText()
                    strcon.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()

        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtbx_addunit_TextChanged(sender As Object, e As EventArgs) Handles txtbx_addunit.TextChanged

        If txtbx_addunit.Text.Length >= 10 Then
            Try

                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_allstocks WHERE serial_number = '" & txtbx_addunit.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    MessageBox.Show("The inputted serial number already exist, seems like this unit already exist in our record.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbl_unitid.Text = "-------"
                    dr.Dispose()
                    strcon.Close()
                    DisableText()
                ElseIf txtbx_addunit.Text = "" Then
                    lbl_unitid.Text = "-------"
                    DisableText()
                    cmb_brand.Enabled = False
                    cmb_unitcondition.Enabled = False
                Else
                    dr.Dispose()
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockpcunit ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 251201
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        End If
                        strcon.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        strcon.Close()
                    End Try

                    EnableText()
                    strcon.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()

            End Try
        Else
            ClearText()

        End If

     
    End Sub


    Private Sub btn_clear2_Click(sender As Object, e As EventArgs)
        ClearText()
        lbl_unitid.Text = "Fclea"
        txtbx_serialno.Text = ""
        txtbx_serialno.Focus()
        txtbx_addunit.Text = ""
    End Sub

    Private Sub txtbx_model_TextChanged(sender As Object, e As EventArgs) Handles txtbx_model.TextChanged
        If txtbx_model.Text = "" Then
            ' btn_clear2.Enabled = False
        Else
            'btn_clear2.Enabled = True
        End If
    End Sub

    Private Sub Btn_stockunit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GenerateString()

    End Sub
    Private Sub GenerateString()

        Dim xCharArray() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray
        Dim xNoArray() As Char = "0123456789".ToCharArray
        Dim xGenerator As System.Random = New System.Random()
        Dim xStr As String = String.Empty

        While xStr.Length < 12

            If xGenerator.Next(0, 2) = 0 Then
                xStr &= xCharArray(xGenerator.Next(0, xCharArray.Length))
            Else
                xStr &= xNoArray(xGenerator.Next(0, xNoArray.Length))
            End If

        End While


        txtbx_addunit.Text = xStr

    End Sub

    'FOR UPDATE BUTTON

    'Private Sub Btn_Update2_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim storage As Double = Convert.ToDouble(txtb_storage.Text)
    '        If (lbl_unitid.Text = "" Or txtbx_serialno.Text = "" Or cmb_manufacturer.Text = "" Or cmb_cpu.Text = "" Or cmb_memory.Text = "" Or cmb_version.Text = "" Or txtb_storage.Text = "" Or txtb_purchasedvalue.Text = "" Or dtp_purchased.Text = "") Then
    '            MessageBox.Show("All information must be provided!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        ElseIf storage > 5000 Or storage < 60 Then
    '            MessageBox.Show("Storage size seems incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Else
    '            UpdateUnit()
    '            txtbx_addunit.Text = ""

    '            txtbx_serialno.Enabled = True

    '            dgv_stockunit.Enabled = True
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub AddUnit()

        Try
            If (txtbx_model.Text = "") Then
                txtbx_model.Text = "Assembled"
                cmb_brand.Text = "None"
            End If
            strcon.Open()
            cmd.CommandText = "SELECT * FROM tbl_stockpcunit WHERE serial_number = '" & txtbx_addunit.Text & "'"
            cmd.Connection = strcon
            Dim dr As MySqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                MessageBox.Show("The inputted serial number already exist, it looks like this unit already exist in our record.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                strcon.Close()
            Else
                ' Dim datetoday As Date = Date.Today
                strcon.Close()
                GetDateDiff()
                strcon.Close()
                create("INSERT INTO tbl_stockpcunit (unit_id,serial_number,brand_name,model,manufacturer,cpu,memory,version,storage,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_addunit.Text & "', '" & cmb_brand.Text & "','" & txtbx_model.Text & "','" & cmb_manufacturer.Text & "','" & cmb_cpu.Text & "','" & cmb_memory.Text & "','" & cmb_version.Text & "','" & txtb_storage.Text & "','" & txtb_purchasedvalue.Text & "','" & dtp_purchased.Text & "')")
                strcon.Close()
                create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_addunit.Text & "', '" & cmb_brand.Text & "','" & txtbx_model.Text & "','" & txtb_purchasedvalue.Text & "','" & txtb_depreciatedvalue.Text & "','" & dtp_purchased.Text & "')")
                strcon.Close()
                create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_addunit.Text & "', '" & cmb_brand.Text & "','" & txtbx_model.Text & "','System unit','Working','Available','" & lbl_datetoday.Text & "')")
                strcon.Close()
                create("INSERT INTO tbl_pcunitcondition (serial_number,brand,model,unit_condition) VALUES ('" & txtbx_addunit.Text & "','" & cmb_brand.Text & "','" & txtbx_model.Text & "', 'Working')")
                strcon.Close()
                'INSERT INTO STORAGE DB'
                create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_addunit.Text & "','" & cmb_brand.Text & "','" & txtbx_model.Text & "','System unit','Working')")
                strcon.Close()
                MessageBox.Show("System Unit added sucessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("SELECT * FROM tbl_stockpcunit", dgv_stockunit)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    'UPDATE FUNCTION
    'Private Sub UpdateUnit()
    '    Try
    '        strcon.Close()
    '        GetDateDiff()
    '        strcon.Close()
    '        updates("UPDATE tbl_stockpcunit SET brand_name = '" & cmb_brand.Text & "', model = '" & txtbx_model.Text & "', manufacturer = '" & cmb_manufacturer.Text & "', cpu = '" & cmb_cpu.Text & "', memory = '" & cmb_memory.Text & "', version = '" & cmb_version.Text & "', storage = '" & txtb_storage.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
    '        updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtbx_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
    '        updates("UPDATE tbl_pcunitcondition SET brand_name = '" & cmb_brand.Text & "', model = '" & txtbx_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
    '        updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtbx_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
    '        strcon.Close()
    '        MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        reload("SELECT * FROM tbl_stockpcunit", dgv_stockunit)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        strcon.Close()
    '    End Try
    'End Sub


    Private Sub btn_cancel2_Click(sender As Object, e As EventArgs)
        btn_stockadduinit.Show()
        ' btn_updatestockunit.Show()
        dgv_stockunit.Enabled = True
        txtbx_serialno.Text = ""
        ' Btn_Add2.Hide()
        ' Btn_Update2.Hide()
        btn_clear.Hide()
        btn_cancel.Hide()
        '   btn_cancel2.Hide()
        ClearText()
        lbl_unitid.Text = "-------"
        DisableText()
        txtbx_serialno.Show()
        txtbx_addunit.Hide()
        '  btn_clear2.Show()
        Button3.Visible = False
        txtbx_serialno.Enabled = True
        If txtbx_serialno.Enabled = False Then
            txtbx_serialno.Enabled = True
        End If
    End Sub

    'DISABLE TEXT INPUT IN COMBOBOX'
    Private Sub cmb_manufacturer_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_manufacturer.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_cpu_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_cpu.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_memory_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_memory.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_version_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_version.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_unitcondition_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_unitcondition.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtbx_search_TextChanged(sender As Object, e As EventArgs) Handles txtbx_search.TextChanged
        FilterData(txtbx_search.Text)
    End Sub

    'FOR SEARCH FUNCTION
    Public Sub FilterData(valueToSearch As String)
        strcon.Close()
        strcon.Open()
        If cmb_searchfilter.Text = "SERIAL NO." Then
            Dim searchquery As String = "SELECT * FROM tbl_stockpcunit WHERE CONCAT(serial_number) LIKE '%" & txtbx_search.Text & "%'"
            Dim command As New MySqlCommand(searchquery, strcon)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable

            adapter.Fill(table)

            dgv_stockunit.DataSource = table
            strcon.Close()

        ElseIf cmb_searchfilter.Text = "BRAND" Then
            Dim searchquery As String = "SELECT * FROM tbl_stockpcunit WHERE CONCAT(brand_name) LIKE '%" & txtbx_search.Text & "%'"
            Dim command As New MySqlCommand(searchquery, strcon)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable

            adapter.Fill(table)

            dgv_stockunit.DataSource = table
            strcon.Close()
        ElseIf cmb_searchfilter.Text = "MODEL" Then
            Dim searchquery As String = "SELECT * FROM tbl_stockpcunit WHERE CONCAT(model) LIKE '%" & txtbx_search.Text & "%'"
            Dim command As New MySqlCommand(searchquery, strcon)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable

            adapter.Fill(table)

            dgv_stockunit.DataSource = table
            strcon.Close()
        End If

    End Sub

    Private Sub cmb_manufacturer_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_manufacturer.SelectedValueChanged
        If cmb_manufacturer.Text <> "" Or cmb_manufacturer.Text <> "N/A" Then
            Try
                ' strcon.Open()
                Dim cmd3 As New MySqlCommand
                Dim daa3 As New MySqlDataAdapter
                Dim dtt3 As New DataTable


                cmd3.CommandText = "SELECT * FROM tbl_cpuversion where manufacturer = '" & cmb_manufacturer.Text & "'"
                cmd3.Connection = strcon

                daa3.SelectCommand = cmd3
                daa3.Fill(dtt3)

                cmb_cpu.DataSource = dtt3
                cmb_cpu.ValueMember = "cpuversion_id"
                cmb_cpu.DisplayMember = "version"
                cmb_cpu.Text = ""
                'daa3.Dispose()
                'strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

            End Try
        End If
    End Sub

    Private Sub txtb_purchasedvalue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_purchasedvalue.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'HOVER STOCKS'
    Private Sub btn_monitor_Click(sender As Object, e As EventArgs) Handles btn_monitor.Click
        stock_monitor.lbl_userid.Text = lbl_userid.Text
        stock_monitor.lbl_fname.Text = lbl_fname.Text
        stock_monitor.lbl_lname.Text = lbl_lname.Text
        stock_monitor.lbl_username.Text = lbl_username.Text
        stock_monitor.lbl_position.Text = lbl_position.Text
        stock_monitor.lbl_fullname.Text = lbl_fullname.Text
        stock_monitor.Show()
        Me.Close()
    End Sub

    Private Sub btn_unit_Click(sender As Object, e As EventArgs) Handles btn_unit.Click
        'stock_systemunit.lbl_userid.Text = lbl_userid.Text
        'stock_systemunit.lbl_fname.Text = lbl_fname.Text
        'stock_systemunit.lbl_lname.Text = lbl_lname.Text
        'stock_systemunit.lbl_username.Text = lbl_username.Text
        'stock_systemunit.lbl_position.Text = lbl_position.Text
        'stock_systemunit.lbl_fullname.Text = lbl_fullname.Text
        'stock_systemunit.Show()
        'Me.Close()
    End Sub

    Private Sub btn_laptop_Click(sender As Object, e As EventArgs) Handles btn_laptop.Click
        stock_laptop.lbl_userid.Text = lbl_userid.Text
        stock_laptop.lbl_fname.Text = lbl_fname.Text
        stock_laptop.lbl_lname.Text = lbl_lname.Text
        stock_laptop.lbl_username.Text = lbl_username.Text
        stock_laptop.lbl_position.Text = lbl_position.Text
        stock_laptop.lbl_fullname.Text = lbl_fullname.Text
        stock_laptop.Show()
        Me.Close()
    End Sub

    Private Sub btn_memory_Click(sender As Object, e As EventArgs) Handles btn_memory.Click
        stock_memory.lbl_userid.Text = lbl_userid.Text
        stock_memory.lbl_fname.Text = lbl_fname.Text
        stock_memory.lbl_lname.Text = lbl_lname.Text
        stock_memory.lbl_username.Text = lbl_username.Text
        stock_memory.lbl_position.Text = lbl_position.Text
        stock_memory.lbl_fullname.Text = lbl_fullname.Text
        stock_memory.Show()
        Me.Close()
    End Sub

    Private Sub btn_printer_Click(sender As Object, e As EventArgs) Handles btn_printer.Click
        stock_printer.lbl_userid.Text = lbl_userid.Text
        stock_printer.lbl_fname.Text = lbl_fname.Text
        stock_printer.lbl_lname.Text = lbl_lname.Text
        stock_printer.lbl_username.Text = lbl_username.Text
        stock_printer.lbl_position.Text = lbl_position.Text
        stock_printer.lbl_fullname.Text = lbl_fullname.Text
        stock_printer.Show()
        Me.Close()
    End Sub

    Private Sub btn_extras_Click(sender As Object, e As EventArgs) Handles btn_extras.Click
        stock_peripherals.lbl_userid.Text = lbl_userid.Text
        stock_peripherals.lbl_fname.Text = lbl_fname.Text
        stock_peripherals.lbl_lname.Text = lbl_lname.Text
        stock_peripherals.lbl_username.Text = lbl_username.Text
        stock_peripherals.lbl_position.Text = lbl_position.Text
        stock_peripherals.lbl_fullname.Text = lbl_fullname.Text
        stock_peripherals.Show()
        Me.Close()
    End Sub

    Private Sub btn_storage_Click(sender As Object, e As EventArgs) Handles btn_storage.Click
        stock_storage.lbl_userid.Text = lbl_userid.Text
        stock_storage.lbl_fname.Text = lbl_fname.Text
        stock_storage.lbl_lname.Text = lbl_lname.Text
        stock_storage.lbl_username.Text = lbl_username.Text
        stock_storage.lbl_position.Text = lbl_position.Text
        stock_storage.lbl_fullname.Text = lbl_fullname.Text
        stock_storage.Show()
        Me.Close()
    End Sub
    Private Sub btn_networkdevice_Click(sender As Object, e As EventArgs) Handles btn_networkdevice.Click
        stock_networkdevice.lbl_userid.Text = lbl_userid.Text
        stock_networkdevice.lbl_fname.Text = lbl_fname.Text
        stock_networkdevice.lbl_lname.Text = lbl_lname.Text
        stock_networkdevice.lbl_username.Text = lbl_username.Text
        stock_networkdevice.lbl_position.Text = lbl_position.Text
        stock_networkdevice.lbl_fullname.Text = lbl_fullname.Text
        stock_networkdevice.Show()
        Me.Close()
    End Sub


    'DROP DOWN MENU'   
    Private Sub Btn_StockSlide_Click(sender As Object, e As EventArgs) Handles Btn_StockSlide.Click
        Timer2.Start()
    End Sub

    'DROP DOWN MENU'
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If IsCollapsed2 Then

            NewPanelSlide.Height += 10
            If NewPanelSlide.Size = NewPanelSlide.MaximumSize Then
                Timer2.Stop()
                IsCollapsed2 = False
            End If
        Else
            NewPanelSlide.Height -= 10
            If NewPanelSlide.Size = NewPanelSlide.MinimumSize Then
                Timer2.Stop()
                IsCollapsed2 = True
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isCollapsed Then

            panelassign.Height += 10
            If panelassign.Size = panelassign.MaximumSize Then
                Timer1.Stop()
                isCollapsed = False
            End If
        Else
            panelassign.Height -= 10
            If panelassign.Size = panelassign.MinimumSize Then
                Timer1.Stop()
                isCollapsed = True
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
        If isCollapsed4 Then

            panelstorage.Height += 10
            If panelstorage.Size = panelstorage.MaximumSize Then
                Timer4.Stop()
                isCollapsed4 = False
            End If
        Else
            panelstorage.Height -= 10
            If panelstorage.Size = panelstorage.MinimumSize Then
                Timer4.Stop()
                isCollapsed4 = True
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
        isCollapsed3 = False
        isCollapsed4 = False
        IsCollapsed5 = False
        IsCollapsed6 = False

        Timer1.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()
    End Sub
    'Iscollapse3'
    Private Sub btn_dashstock_Click(sender As Object, e As EventArgs) Handles btn_dashstock.Click
        IsCollapsed4 = False
        IsCollapsed = False
        IsCollapsed5 = False
        IsCollapsed6 = False

        Timer3.Start()
        Timer1.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()
    End Sub
    'Iscollapse4'
    Private Sub btn_dashstorage_Click(sender As Object, e As EventArgs) Handles btn_dashstorage.Click
        isCollapsed3 = False
        isCollapsed = False
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
        'stock_systemunit.lbl_userid.Text = lbl_userid.Text
        'stock_systemunit.lbl_fname.Text = lbl_fname.Text
        'stock_systemunit.lbl_lname.Text = lbl_lname.Text
        'stock_systemunit.lbl_username.Text = lbl_username.Text
        'stock_systemunit.lbl_position.Text = lbl_position.Text
        'stock_systemunit.lbl_fullname.Text = lbl_fullname.Text
        'stock_systemunit.Show()
        'Me.Close()
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

End Class