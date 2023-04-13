Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text


Public Class storage_manage

    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True

    Dim dttable As New DataTable
    Dim dr As MySqlDataReader


    Public Sub DisableSpecs()
        cmb_manufacturer.Enabled = False
        cmb_manufacturer.Text = "N/A"
        cmb_cpu.Enabled = False
        cmb_cpu.Text = "N/A"
        cmb_version.Enabled = False
        cmb_version.Text = "N/A"
        cmb_memory.Enabled = False
        cmb_memory.Text = "N/A"
        cmb_storage.Enabled = False
        cmb_storage.Text = "N/A"
        txtb_storagesize.Enabled = False
        txtb_storagesize.Text = "N/A"
    End Sub

    Private Sub storage_manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
        FilterData("")

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

        panelstorage.Size = panelstorage.MaximumSize

        'Btn_Add2.Hide()
        ' btn_clear.Hide()
        btn_cancel.Hide()

        txtbx_serialno.Focus()
        txtbx_serialno.Show()
        ' txtbx_addunit.Hide()
        dtp_dateadded.MaxDate = Date.Today
        dtp_dateadded.Value = Convert.ToDateTime(Date.Today)
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
            strcon.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try

        Try
            Dim cmdd As New MySqlCommand
            Dim daa As New MySqlDataAdapter
            Dim dtt As New DataTable
            strcon.Close()
            strcon.Open()

            cmdd.Connection = strcon
            cmdd.CommandText = "SELECT * FROM tbl_memoryversion"

            daa.SelectCommand = cmdd
            daa.Fill(dtt)

            cmb_version.DataSource = dtt
            cmb_version.ValueMember = "version_id"
            cmb_version.DisplayMember = "version"
            cmb_version.Text = ""
            strcon.Close()
            daa.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try

        Try
            Dim cmdd As New MySqlCommand
            Dim daa As New MySqlDataAdapter
            Dim dtt As New DataTable
            strcon.Close()
            strcon.Open()

            cmdd.Connection = strcon
            cmdd.CommandText = "SELECT * FROM tbl_storagedrivetype"

            daa.SelectCommand = cmdd
            daa.Fill(dtt)

            cmb_storage.DataSource = dtt
            cmb_storage.ValueMember = "storagetype_id"
            cmb_storage.DisplayMember = "storage_type"
            cmb_storage.Text = ""

            strcon.Close()
            daa.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try


        'Try
        '    Dim cmd3 As New MySqlCommand
        '    Dim daa3 As New MySqlDataAdapter
        '    Dim dtt3 As New DataTable

        '    strcon.Open()

        '    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'System unit'"
        '    cmd3.Connection = strcon

        '    daa3.SelectCommand = cmd3
        '    daa3.Fill(dtt3)

        '    cmb_brand.DataSource = dtt3
        '    cmb_brand.ValueMember = "brand_id"
        '    cmb_brand.DisplayMember = "brand_name"
        '    cmb_brand.Text = ""

        '    strcon.Close()
        '    daa3.Dispose()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    strcon.Close()
        'End Try
    End Sub

    Public Sub disablecombobox()
        cmb_manufacturer.Enabled = False
        cmb_cpu.Enabled = False
        cmb_memory.Enabled = False
        cmb_storage.Enabled = False
        txtb_storagesize.Enabled = False
        cmb_version.Enabled = False
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        'lbl_model.Text = txtb_model.Text
        'lblbrand.Text = cmb_brand.Text
        'lbl_peripheraltype.Text = cmb_peripheraltype.Text
        'lblmanufacturer.Text = cmb_manufacturer.Text
        'lblcpu.Text = cmb_cpu.Text
        'lblmemory.Text = cmb_memory.Text
        'lblversion.Text = cmb_version.Text
        'lblstoragesize.Text = txtb_storagesize.Text
        'lblstoragetype.Text = cmb_storage.Text
        'lblcondition.Text = cmb_unitcondition.Text

        lbl_unitbrand.Text = cmb_brand.Text
        If txtbx_serialno.Text = "" Then
            MessageBox.Show("Please select a record first", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            If lbl_unittype.Text = "Networking" Then
                EnableText()
                cmb_peripheraltype.Show()
                lbl_peripheraltype.Show()
                cmb_peripheraltype.Enabled = True
                disablecombobox()

                Dim daa3 As New MySqlDataAdapter
                Dim dtt3 As New DataTable
                strcon.Close()
                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_networkdevicetype"
                cmd.Connection = strcon

                daa3.SelectCommand = cmd
                daa3.Fill(dtt3)

                cmb_peripheraltype.DataSource = dtt3
                cmb_peripheraltype.ValueMember = "type_id"
                cmb_peripheraltype.DisplayMember = "type"
                strcon.Close()
                daa3.Dispose()

                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa4 As New MySqlDataAdapter
                    Dim dtt4 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Networking'"
                    cmd3.Connection = strcon

                    daa4.SelectCommand = cmd3
                    daa4.Fill(dtt4)

                    cmb_brand.DataSource = dtt4
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa4.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try

            ElseIf lbl_unittype.Text = "Peripherals" Then
                EnableText()
                cmb_peripheraltype.Show()
                lbl_peripheraltype.Show()
                cmb_peripheraltype.Enabled = True
                disablecombobox()

                Dim daa3 As New MySqlDataAdapter
                Dim dtt3 As New DataTable
                strcon.Close()
                strcon.Open()

                cmd.CommandText = "SELECT * FROM tbl_peripheraltype"
                cmd.Connection = strcon

                daa3.SelectCommand = cmd
                daa3.Fill(dtt3)

                cmb_peripheraltype.DataSource = dtt3
                cmb_peripheraltype.ValueMember = "peripheraltype_id"
                cmb_peripheraltype.DisplayMember = "type"
                strcon.Close()
                daa3.Dispose()

                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa4 As New MySqlDataAdapter
                    Dim dtt4 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Peripherals'"
                    cmd3.Connection = strcon

                    daa4.SelectCommand = cmd3
                    daa4.Fill(dtt4)

                    cmb_brand.DataSource = dtt4
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa4.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try

            ElseIf lbl_unittype.Text = "Monitor" Then
                EnableText()
                disablecombobox()
                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Monitor'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            ElseIf lbl_unittype.Text = "Memory" Then
                EnableText()
                cmb_manufacturer.Enabled = False
                cmb_cpu.Enabled = False
                cmb_storage.Enabled = False
                txtb_storagesize.Enabled = False

                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'RAM'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            ElseIf lbl_unittype.Text = "Storage drive" Then
                EnableText()
                cmb_manufacturer.Enabled = False
                cmb_cpu.Enabled = False
                cmb_memory.Enabled = False
                cmb_version.Enabled = False
                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Storage drive'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            ElseIf lbl_unittype.Text = "System unit" Then
                EnableText()
                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'System unit'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            ElseIf lbl_unittype.Text = "Laptop" Then
                EnableText()
                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Laptop'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_name"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try

            ElseIf lbl_unittype.Text = "Printer" Then
                EnableText()
                disablecombobox()
                Try
                    Dim cmd3 As New MySqlCommand
                    Dim daa3 As New MySqlDataAdapter
                    Dim dtt3 As New DataTable
                    strcon.Close()
                    strcon.Open()

                    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = 'Printer'"
                    cmd3.Connection = strcon

                    daa3.SelectCommand = cmd3
                    daa3.Fill(dtt3)

                    cmb_brand.DataSource = dtt3
                    cmb_brand.ValueMember = "brand_id"
                    cmb_brand.DisplayMember = "brand_name"
                    cmb_brand.Text = lbl_unitbrand.Text

                    strcon.Close()
                    daa3.Dispose()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            End If


            btn_update2.Show()
            'btn_clear.Show()
            btn_cancel.Show()
            ' btn_clear2.Hide()
            btn_update.Hide()
            ' btn_updatestockunit.Hide()
            txtbx_serialno.Enabled = False
            dgv_stockunit.Enabled = False

            'Try
            '    Dim cmd3 As New MySqlCommand
            '    Dim daa3 As New MySqlDataAdapter
            '    Dim dtt3 As New DataTable

            '    strcon.Close()
            '    strcon.Open()

            '    cmd3.CommandText = "SELECT * FROM tbl_unitbrands where unit_type = '" & lbl_unittype.Text & "'"
            '    cmd3.Connection = strcon

            '    daa3.SelectCommand = cmd3
            '    daa3.Fill(dtt3)

            '    cmb_brand.DataSource = dtt3
            '    cmb_brand.ValueMember = "brand_id"
            '    cmb_brand.DisplayMember = "brand_name"
            '    'cmb_brand.Text = ""

            '    strcon.Close()
            '    daa3.Dispose()
            '    '
            '    
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'Finally
            '    strcon.Close()
            'End Try

        End If
    End Sub

    Private Sub dgv_stockunit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_stockunit.CellContentClick
        lbl_unittype.Visible = True
        '   lbl_unitid.Text = dgv_stockunit.CurrentRow.Cells(0).Value
        txtbx_serialno.Text = dgv_stockunit.CurrentRow.Cells(1).Value
        ' cmb_brand.Text = dgv_stockunit.CurrentRow.Cells(2).Value
        ' txtb_model.Text = dgv_stockunit.CurrentRow.Cells(3).Value
        'lbl_unittype.Text = dgv_stockunit.CurrentRow.Cells(3).Value
        ''cmb_manufacturer.Text = dgv_stockunit.CurrentRow.Cells(4).Value
        ''cmb_cpu.Text = dgv_stockunit.CurrentRow.Cells(5).Value
        ''cmb_memory.Text = dgv_stockunit.CurrentRow.Cells(6).Value
        ''cmb_version.Text = dgv_stockunit.CurrentRow.Cells(7).Value
        ''txtb_storage.Text = dgv_stockunit.CurrentRow.Cells(8).Value
        lbl_unittype.Text = dgv_stockunit.CurrentRow.Cells(4).Value
        cmb_unitcondition.Text = dgv_stockunit.CurrentRow.Cells(5).Value
        cmb_availability.Text = dgv_stockunit.CurrentRow.Cells(6).Value
        dtp_dateadded.Text = dgv_stockunit.CurrentRow.Cells(7).Value


        ' GetDateDiff()

        '  txtb_depreciatedvalue.Text = dgv_stockunit.CurrentRow.Cells(9).Value
    End Sub

    Private Sub txtbx_serialno_TextChanged(sender As Object, e As EventArgs) Handles txtbx_serialno.TextChanged
        Try
            strcon.Open()
            cmd.CommandText = "SELECT unit_type FROM tbl_inventorystorage WHERE serial_number = '" & txtbx_serialno.Text & "'"
            cmd.Connection = strcon

            Dim unittype As String
            unittype = Convert.ToString(cmd.ExecuteScalar())

            If unittype = "System unit" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Hide()
                cmb_storage.Hide()

                cmd.CommandText = "SELECT * FROM tbl_stockpcunit WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_manufacturer.Text = dr.GetValue(4).ToString()
                    cmb_cpu.Text = dr.GetValue(5).ToString()
                    cmb_memory.Text = dr.GetValue(6).ToString()
                    cmb_version.Text = dr.GetValue(7).ToString()
                    txtb_storagesize.Text = dr.GetValue(8).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(9).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(10).ToString()
                    'lbl_unittype.Text = "System unit"
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()

                End If

            ElseIf unittype = "Laptop" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Hide()
                cmb_storage.Hide()

                ' Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stocklaptop WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_manufacturer.Text = dr.GetValue(4).ToString()
                    cmb_cpu.Text = dr.GetValue(5).ToString()
                    cmb_memory.Text = dr.GetValue(6).ToString()
                    cmb_version.Text = dr.GetValue(7).ToString()
                    txtb_storagesize.Text = dr.GetValue(8).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(9).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(10).ToString()
                    ' lbl_unittype.Text = "Laptop"
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()
                End If
            ElseIf unittype = "Monitor" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Hide()
                cmb_storage.Hide()
                '  Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stockmonitor WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()

                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(4).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(5).ToString()
                    '  lbl_unittype.Text = "Monitor"
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    DisableSpecs()
                    dr.Dispose()
                    strcon.Close()
                End If

            ElseIf unittype = "Memory" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Hide()
                cmb_storage.Hide()
                '   Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stockmemory WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_memory.Text = dr.GetValue(5).ToString()
                    cmb_version.Text = dr.GetValue(4).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(6).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(7).ToString()
                    '    lbl_unittype.Text = "Memory"

                    cmb_manufacturer.Text = "N/A"
                    cmb_cpu.Text = "N/A"
                    cmb_storage.Text = "N/A"
                    txtb_storagesize.Text = "N/A"
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()
                End If

            ElseIf unittype = "Storage drive" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Show()
                cmb_storage.Show()
                '  Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stockstorage WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_storage.Text = dr.GetValue(4).ToString()
                    txtb_storagesize.Text = dr.GetValue(5).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(6).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(7).ToString()
                    '   lbl_unittype.Text = "Storage drive"

                    cmb_manufacturer.Text = "N/A"
                    cmb_cpu.Text = "N/A"
                    cmb_memory.Text = "N/A"
                    cmb_version.Text = "N/A"

                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()
                End If

            ElseIf unittype = "Printer" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Hide()
                lbl_peripheraltype.Hide()
                lbl_storagetype.Hide()
                cmb_storage.Hide()
                '   Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stockprinter WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(4).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(5).ToString()
                    '   lbl_unittype.Text = "Printer"

                    DisableSpecs()
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()

                End If
            ElseIf unittype = "Peripherals" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Show()
                lbl_peripheraltype.Show()
                lbl_storagetype.Hide()
                cmb_storage.Hide()
                '  Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stockperipherals WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_peripheraltype.Text = dr.GetValue(4).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(5).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(6).ToString()
                    '   lbl_unittype.Text = "Peripherals"

                    DisableSpecs()
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()

                    'Try
                    '    strcon.Close()
                    '    Dim cmd3 As New MySqlCommand
                    '    Dim daa3 As New MySqlDataAdapter
                    '    Dim dtt3 As New DataTable

                    '    strcon.Open()

                    '    cmd3.CommandText = "SELECT * FROM tbl_peripheraltype"
                    '    cmd3.Connection = strcon

                    '    daa3.SelectCommand = cmd3
                    '    daa3.Fill(dtt3)

                    '    cmb_peripheraltype.DataSource = dtt3
                    '    cmb_peripheraltype.ValueMember = "peripheraltype_id"
                    '    cmb_peripheraltype.DisplayMember = "type"
                    '    cmb_peripheraltype.Text = ""

                    '    strcon.Close()
                    '    daa3.Dispose()

                    'Catch ex As Exception
                    '    MessageBox.Show(ex.Message)
                    'Finally
                    '    strcon.Close()
                    'End Try
                End If
            ElseIf unittype = "Networking" Then
                strcon.Close()
                strcon.Open()
                ClearText()
                cmb_peripheraltype.Show()
                lbl_peripheraltype.Show()
                lbl_storagetype.Hide()
                cmb_storage.Hide()
                'Dim cmd2 As MySqlCommand
                cmd.CommandText = "SELECT * FROM tbl_stocknetworkdevice WHERE serial_number = '" & txtbx_serialno.Text & "'"
                cmd.Connection = strcon

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    lbl_unitid.Text = dr.GetValue(0).ToString()
                    cmb_brand.Text = dr.GetValue(2).ToString()
                    txtb_model.Text = dr.GetValue(3).ToString()
                    cmb_peripheraltype.Text = dr.GetValue(4).ToString()
                    lbl_purchasedvalue.Text = dr.GetValue(5).ToString()
                    lbl_purchaseddate.Text = dr.GetValue(6).ToString()
                    'lbl_unittype.Text = "Networking"

                    DisableSpecs()
                    ' txtb.Text = dr.GetValue(9).ToString()
                    ' dtp_dateadded.Text = dr.GetValue(10).ToString()

                    dr.Dispose()
                    strcon.Close()

                End If
                strcon.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        btn_update.Show()
        ' btn_updatestockunit.Show()
        dgv_stockunit.Enabled = True
        txtbx_serialno.Text = ""
        btn_update2.Hide()
        ' Btn_Update2.Hide()
        '   btn_clear.Hide()
        btn_cancel.Hide()

        ClearText()
        lbl_unitid.Text = "-------"
        cmb_manufacturer.Text = ""
        cmb_cpu.Text = ""
        cmb_memory.Text = ""
        cmb_version.Text = ""
        cmb_brand.Text = ""
        txtb_storagesize.Text = ""
        DisableText()
        txtbx_serialno.Show()
        cmb_peripheraltype.Enabled = False
        txtbx_serialno.Enabled = False
        'txtbx_addunit.Hide()
        'btn_clear2.Show()
        '  Button3.Visible = False
        dtp_dateadded.Value = Convert.ToDateTime(Date.Today)
       
    End Sub
    'CLEAR AND ENABLE AND DISABLE TOOLS SHORCUT
    Public Sub ClearText()
        lbl_unitid.Text = "-------"
        ' txtbx_serialno.Text = ""
        txtb_model.Text = ""
        cmb_manufacturer.Text = ""
        cmb_cpu.Text = ""
        cmb_memory.Text = ""
        cmb_version.Text = ""
        cmb_availability.Text = ""
        cmb_storage.Text = ""
        cmb_peripheraltype.Text = ""
        txtb_storagesize.Text = ""
        'dtp_purchased.Text = ""
        ' txtb_depreciatedvalue.Text = ""
        cmb_brand.Text = ""
        cmb_unitcondition.Text = ""
    End Sub
    Public Sub EnableText()
        '  lbl_unitid.Enabled = True
        ' txtbx_serialno.Enabled = True
        txtb_model.Enabled = True
        cmb_manufacturer.Enabled = True
        cmb_cpu.Enabled = True
        cmb_memory.Enabled = True
        cmb_version.Enabled = True
        txtb_storagesize.Enabled = True
        ' txtb_purchasedvalue.Enabled = True
        'dtp_dateadded.Enabled = True
        cmb_brand.Enabled = True
        cmb_unitcondition.Enabled = True
        '  txtb_depreciatedvalue.Enabled = True
    End Sub
    Public Sub DisableText()
        ' lbl_unitid.Enabled = False
        ' txtbx_serialno.Enabled = False
        txtb_model.Enabled = False
        cmb_manufacturer.Enabled = False
        cmb_cpu.Enabled = False
        cmb_memory.Enabled = False
        txtb_storagesize.Enabled = False
        cmb_version.Enabled = False
        ' txtb_purchasedvalue.Enabled = False
        dtp_dateadded.Enabled = False
        cmb_brand.Enabled = False
        cmb_unitcondition.Enabled = False
        ' txtb_depreciatedvalue.Enabled = False
    End Sub

    'GET THE DEPRECIATED VALUE'
    Public Sub GetDateDiff()
        Try
            Dim depreciationspan As Integer

            Dim unittype As String = lbl_unittype.Text

            Select Case unittype
                Case "System unit"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'System unit'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '  updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Laptop"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Laptop'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '   updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Monitor"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Monitor'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '   updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Memory"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'RAM'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '     updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Storage drive"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Storage drive'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '     updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Printer"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Printer'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '     updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Peripherals"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Peripherals'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '    updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()

                Case "Networking"
                    strcon.Open()
                    cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = 'Networking'"
                    cmd.Connection = strcon

                    depreciationspan = Convert.ToInt32(cmd.ExecuteScalar())

                    Dim currdate As DateTime = Convert.ToDateTime(Date.Today)
                    Dim purchaseddate As DateTime = Convert.ToDateTime(lbl_purchaseddate.Text)

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

                    purchasedvalue = Convert.ToDouble(lbl_purchasedvalue.Text)

                    depreciation_year = purchasedvalue / depreciationspan
                    depreciation_month = depreciation_year / 12

                    Dim totaldepreciation As Double
                    Dim depreciatedvalue As Double

                    totaldepreciation = months * depreciation_month

                    depreciatedvalue = Convert.ToDouble(lbl_purchasedvalue.Text) - totaldepreciation

                    'txtb_depreciatedvalue.Text = Math.Round(depreciatedvalue, 2)
                    lbl_totaldepreciation.Text = Math.Round(depreciatedvalue, 2)

                    strcon.Close()
                    '    updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

                    strcon.Close()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

   
    Private Sub txtb_storagesize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_storagesize.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    'FOR UPDATE BUTTON

    Private Sub btn_update2_click(sender As Object, e As EventArgs)
        Try
            Dim storage As Double = Convert.ToDouble(txtb_storagesize.Text)
            If (lbl_unitid.Text = "" Or txtbx_serialno.Text = "" Or txtb_storagesize.Text = "" Or txtb_model.Text = "") Then
                MessageBox.Show("all information must be provided!", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf storage > 5000 Or storage < 60 Then
                MessageBox.Show("storage size seems incorrect", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                updateunit()
                txtbx_serialno.Text = ""

                txtbx_serialno.Enabled = True

                dgv_stockunit.Enabled = True
            End If
        Catch ex As exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'UPDATE FUNCTION
    Private Sub UpdateUnit()
        Dim unittype As String = lbl_unittype.Text

        Select Case unittype
            Case "System unit"
                Try
                    strcon.Close()
                    'GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockpcunit SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', manufacturer = '" & cmb_manufacturer.Text & "', cpu = '" & cmb_cpu.Text & "', memory = '" & cmb_memory.Text & "', version = '" & cmb_version.Text & "', storage = '" & txtb_storagesize.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' , availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_pcunitcondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Laptop"
                Try
                    strcon.Close()
                    ' GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stocklaptop SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', manufacturer = '" & cmb_manufacturer.Text & "', cpu = '" & cmb_cpu.Text & "', memory = '" & cmb_memory.Text & "', version = '" & cmb_version.Text & "', storage = '" & txtb_storagesize.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' , availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_laptopcondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Monitor"
                Try
                    strcon.Close()
                    '   GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockmonitor SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_monitorcondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Memory"
                Try
                    strcon.Close()
                    '   GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockmemory SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', type = '" & cmb_version.Text & "', size = '" & cmb_memory.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_memorycondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "'WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Storage drive"
                Try
                    strcon.Close()
                    '      GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockstorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', type = '" & cmb_storage.Text & "', size = '" & txtb_storagesize.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    ' updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_storagecondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "'WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Printer"
                Try
                    strcon.Close()
                    '     GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockprinter SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    '   updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_printercondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "'WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Peripherals"
                Try
                    strcon.Close()
                    '    GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stockperipherals SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "',type = '" & cmb_peripheraltype.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    ' updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_peripheralcondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "'WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Networking"
                Try
                    strcon.Close()
                    '     GetDateDiff()
                    strcon.Close()
                    updates("UPDATE tbl_stocknetworkdevice SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "',type = '" & cmb_peripheraltype.Text & "'  WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_networkdevicecondition SET brand = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_allstocks SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', availability = '" & cmb_availability.Text & "', unit_condition = '" & cmb_unitcondition.Text & "'WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    updates("UPDATE tbl_inventorystorage SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', unit_condition = '" & cmb_unitcondition.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    'updates("UPDATE tbl_stockpcunitvalue SET brand_name = '" & cmb_brand.Text & "', model = '" & txtb_model.Text & "', purchased_value = '" & txtb_purchasedvalue.Text & "' , depreciation_value = '" & txtb_depreciatedvalue.Text & "', date_purchased = '" & dtp_purchased.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
        End Select
    End Sub

    'DISABLE TEXT INPUT IN COMBOBOX'
    Private Sub cmb_manufacturer_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_manufacturer.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_cpu_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles cmb_cpu.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_memory_KeyPress(ByVal sender As Object, e As KeyPressEventArgs)
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
    Private Sub cmb_brand_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_brand.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_peripheraltype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_peripheraltype.KeyPress
        e.Handled = True
    End Sub

    'FOR SEARCH FUNCTION
    Public Sub FilterData(valueToSearch As String)
        strcon.Close()
        strcon.Open()

        Dim searchquery As String = "select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number WHERE CONCAT(tbl_inventorystorage.serial_number,tbl_inventorystorage.model,tbl_inventorystorage.brand_name) LIKE '%" & txtbx_search.Text & "%'"
        Dim command As New MySqlCommand(searchquery, strcon)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        dgv_stockunit.DataSource = table
        strcon.Close()
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

    Private Sub btn_update2_Click_1(sender As Object, e As EventArgs) Handles btn_update2.Click
        Try
            ' Dim storage As Double = Convert.ToDouble(txtb_storagesize.Text)
            If lbl_unitid.Text = "" Or txtbx_serialno.Text = "" Or cmb_manufacturer.Text = "" Or cmb_cpu.Text = "" Or cmb_memory.Text = "" Or cmb_version.Text = "" Or txtb_storagesize.Text = "" Or cmb_availability.Text = "" Or cmb_unitcondition.Text = "" Then
                MessageBox.Show("All information must be provided!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'ElseIf txtb_model.Text = lbl_model.Text And cmb_brand.Text = lbl_model.Text And cmb_peripheraltype.Text = lbl_peripheraltype.Text And cmb_manufacturer.Text = lblmanufacturer.Text And cmb_cpu.Text = lblcpu.Text And cmb_memory.Text = lblmemory.Text And cmb_version.Text = lblversion.Text And cmb_storage.Text = lblstoragetype.Text And txtb_storagesize.Text = lblstoragesize.Text And cmb_unitcondition.Text = lblcondition.Text Then
                '    MessageBox.Show("There is no changes made on the data", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                UpdateUnit()
                txtbx_serialno.Text = ""

                txtbx_serialno.Enabled = False
                disablecombobox()
                DisableText()
                btn_update2.Hide()
                btn_cancel.Hide()
                btn_update.Show()
                ClearText()
                txtbx_serialno.Text = ""
                lbl_unittype.Text = ""
                dgv_stockunit.Enabled = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "WOW", MessageBoxButtons.OKCancel)
        End Try
    End Sub

    Private Sub cmb_unitcondition_TextChanged(sender As Object, e As EventArgs) Handles cmb_unitcondition.TextChanged
        If cmb_unitcondition.Text = "Defective" Then
            cmb_availability.Text = "Not Available"
        ElseIf cmb_unitcondition.Text = "Working" Or cmb_unitcondition.Text = "New" Then
            cmb_availability.Text = "Available"
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
                cmb_cpu.Text = "Select"
                'daa3.Dispose()
                'strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally

            End Try
        End If

    End Sub

    Private Sub cmb_sortby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_sortby.SelectedIndexChanged
        reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number WHERE tbl_inventorystorage.unit_type = '" & cmb_sortby.Text & "'", dgv_stockunit)
        
    End Sub

    Private Sub cmb_sortby_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_sortby.KeyPress
        e.Handled = True
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
        'storage_manage.lbl_userid.Text = lbl_userid.Text
        'storage_manage.lbl_fname.Text = lbl_fname.Text
        'storage_manage.lbl_lname.Text = lbl_lname.Text
        'storage_manage.lbl_username.Text = lbl_username.Text
        'storage_manage.lbl_position.Text = lbl_position.Text
        'storage_manage.lbl_fullname.Text = lbl_fullname.Text
        'storage_manage.Show()
        'Me.Close()
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

    Private Sub cmb_memory_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles cmb_memory.KeyPress
        e.Handled = True
    End Sub
End Class