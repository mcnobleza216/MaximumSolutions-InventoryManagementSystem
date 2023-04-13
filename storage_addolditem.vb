Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class storage_addolditem

    Dim IsCollapsed As Boolean = True
    Dim IsCollapsed2 As Boolean = True
    Dim IsCollapsed3 As Boolean = True
    Dim IsCollapsed4 As Boolean = True
    Dim IsCollapsed5 As Boolean = True
    Dim IsCollapsed6 As Boolean = True

    Private Sub storage_addolditem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        depreciateitems()
        reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
        FilterData("")

        Dim datetoday As String = Date.Today.ToString("yyyy-MM-dd")
        lbl_datetoday.Text = datetoday

        panelstorage.Size = panelstorage.MaximumSize
        txtb_model.TabIndex = 0
        'btn_add2.Hide()
        'btn_clear.Hide()
        'btn_cancel.Hide()

        '  txtbx_serialno.Focus()
        txtbx_serialno.Show()
        '  txtbx_addunit.Hide()
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

    End Sub

    Private Sub btn_generateserial_Click(sender As Object, e As EventArgs) Handles btn_generateserial.Click
        txtb_model.Focus()
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
        txtbx_serialno.Text = xStr

    End Sub
    'CLEAR AND ENABLE AND DISABLE TOOLS SHORCUT
    Public Sub ClearText()
        '  lbl_unitid.Text = "-------"
        ' txtbx_serialno.Text = ""
        txtb_model.Text = ""
        cmb_manufacturer.Text = ""
        cmb_cpu.Text = ""
        cmb_memory.Text = ""
        cmb_version.Text = ""
        cmb_availability.Text = ""
        cmb_storage.Text = ""
        cmb_peripheraltype.Text = ""
        ' txtb_storagesize.Text = ""
        'dtp_purchased.Text = ""
        ' txtb_depreciatedvalue.Text = ""
        cmb_brand.Text = ""
        cmb_unitcondition.Text = "Please Select"
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
        cmb_peripheraltype.Enabled = True

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



    Public Sub CMBPlaceHolder()
        cmb_peripheraltype.Text = "Select"
        cmb_manufacturer.Text = "Select"
        cmb_cpu.Text = "Select"
        cmb_memory.Text = "Select"
        cmb_version.Text = "Select"
        cmb_storage.Text = "Select"
    End Sub

    'GET THE DEPRECIATED VALUE'
    Public Sub GetDateDiff()
        Try
            Dim depreciationspan As Integer

            Dim unittype As String = cmb_itemtype.Text

            strcon.Open()
            cmd.CommandText = "SELECT lifespan from tbl_stockdepreciationspan WHERE unit_type = '" & cmb_itemtype.Text & "'"
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
            '  updates("UPDATE tbl_stockpcunitvalue SET depreciation_value = '" & lbl_totaldepreciation.Text & "' WHERE serial_number = '" & txtbx_serialno.Text & "'")

            strcon.Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

   

    'DISABLE CMB'
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


    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        '   btn_stockadduinit.Show()
        ' btn_updatestockunit.Show()
        dgv_stockunit.Enabled = True
        txtbx_serialno.Text = ""
        '  btn_add2.Hide()
        ' Btn_Update2.Hide()
        ' btn_clear.Hide()
        '  btn_cancel.Hide()

        ClearText()
        lbl_unitid.Text = "-------"
        CMBPlaceHolder()
        txtb_storagesize.Text = ""
        DisableText()
        txtbx_serialno.Show()
        cmb_peripheraltype.Enabled = False
        txtbx_serialno.Enabled = False
        '  txtbx_addunit.Hide()
        btn_generateserial.Show()
        cmb_itemtype.Text = "SELECT FIRST"
        btn_generateserial.Enabled = False
        'btn_clear2.Show()
        '  Button3.Visible = False
        dtp_dateadded.Value = Convert.ToDateTime(Date.Today)
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        ClearText()
        CMBPlaceHolder()
        ' lbl_unitid.Text = "-------"
        txtbx_serialno.Text = ""
        cmb_brand.Text = "Select"
    End Sub

    Private Sub txtb_storagesize_TextChanged(sender As Object, e As EventArgs) Handles txtb_storagesize.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtb_storagesize.Text = digitsOnly.Replace(txtb_storagesize.Text, "")
    End Sub

    Private Sub txtb_storagesize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_storagesize.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click
        If txtb_model.Text = "" Or cmb_brand.Text = "" Or cmb_manufacturer.Text = "Select" Or cmb_cpu.Text = "Select" Or cmb_memory.Text = "Select" Or cmb_version.Text = "Select" Or cmb_unitcondition.Text = "Please Select" Then
            MessageBox.Show("All information must be provided!", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            AddItem()
            ClearText()
            DisableText()
            cmb_peripheraltype.Hide()
            cmb_storage.Hide()
            lbl_peripheraltype.Hide()
            lbl_storagetype.Hide()
            lbl_unitid.Text = "-------"
            txtbx_serialno.Text = ""
            btn_add2.Enabled = False
            btn_clear.Enabled = False
            btn_cancel.Enabled = False

        End If
    End Sub


    Private Sub cmb_itemtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_itemtype.SelectedIndexChanged
        txtb_model.Focus()
        'txtb_model.Enabled = True
        txtb_model.Text = ""
        ' cmb_unitcondition.SelectedIndex = 0
        If lbl_peripheraltype.Visible = True Then
            lbl_peripheraltype.Hide()
            cmb_peripheraltype.Hide()
        ElseIf lbl_storagetype.Visible = True Then
            cmb_storage.Hide()
        End If

        txtbx_serialno.Enabled = True
        txtbx_serialno.Text = ""
        txtbx_serialno.ReadOnly = True
        lbl_unitid.Text = "-------"
        ClearText()

        txtbx_serialno.ReadOnly = True
        btn_generateserial.Enabled = True
        If cmb_itemtype.Text = "Monitor" Or cmb_itemtype.Text = "Printer" Then
            DisableSpecs()
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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa3.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "System unit" Then
            DisableSpecs()
            CMBPlaceHolder()
            '  EnableText()
            cmb_peripheraltype.Hide()
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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa3.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "Laptop" Then
            DisableSpecs()
            CMBPlaceHolder()
            '  EnableText()
            cmb_peripheraltype.Hide()
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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa3.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "Memory" Then
            DisableSpecs()
            cmb_memory.Text = "Select"
            cmb_version.Text = "Select"
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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa3.Dispose()

                txtb_model.Enabled = False
                txtb_model.Text = "RAM"

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "Storage" Then
            DisableSpecs()
            cmb_storage.Text = "Select"
            lbl_storagetype.Show()
            cmb_storage.Text = ""
            txtb_storagesize.Text = ""
            cmb_storage.Show()

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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa3.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "Networking" Then
            DisableSpecs()
            lbl_peripheraltype.Show()
            cmb_peripheraltype.Show()

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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa4.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf cmb_itemtype.Text = "Peripherals" Then
            DisableSpecs()
            lbl_peripheraltype.Show()
            cmb_peripheraltype.Show()
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
                cmb_brand.Text = "Select"

                strcon.Close()
                daa4.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        End If
    End Sub

    Private Sub txtbx_serialno_TextChanged(sender As Object, e As EventArgs) Handles txtbx_serialno.TextChanged

        If txtbx_serialno.Text = "" Then
            btn_clear.Enabled = False
            btn_cancel.Enabled = False
            btn_add2.Enabled = False
            cmb_peripheraltype.Enabled = False

        Else
            btn_clear.Enabled = True
            btn_cancel.Enabled = True
            btn_add2.Enabled = True
            cmb_peripheraltype.Enabled = True
        End If
        Try

            strcon.Open()

            cmd.CommandText = "SELECT * FROM tbl_inventorystorage WHERE serial_number = '" & txtbx_serialno.Text & "'"
            cmd.Connection = strcon

            Dim dr As MySqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                MessageBox.Show("The inputted serial number already exist, seems like this unit already exist in the storage.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbl_unitid.Text = "-------"
                dr.Dispose()
                strcon.Close()
                DisableText()
            ElseIf txtbx_serialno.Text = "" Then
                lbl_unitid.Text = "-------"
                DisableText()
                cmb_brand.Enabled = False
                cmb_unitcondition.Enabled = False
            Else
                dr.Dispose()
                txtb_model.Enabled = True
                If cmb_itemtype.Text = "System unit" Then
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
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Laptop" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stocklaptop ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 351201
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
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Monitor" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockmonitor ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 451201
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
                    DisableSpecs()
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Storage" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockstorage ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 551201
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        End If
                        strcon.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        strcon.Close()
                    End Try

                    DisableSpecs()
                    cmb_storage.Enabled = True
                    txtb_storagesize.Enabled = True
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Memory" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockmemory ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 651201
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
                    DisableSpecs()
                    cmb_memory.Enabled = True
                    cmb_version.Enabled = True
                    cmb_memory.Text = "Select"
                    cmb_version.Text = "Select"
                    txtb_model.Enabled = False
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Printer" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockprinter ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 751201
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
                    DisableSpecs()
                    cmb_peripheraltype.Hide()
                    lbl_datetoday.Hide()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Peripherals" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stockperipherals ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 851201
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
                    DisableSpecs()
                    cmb_peripheraltype.Enabled = True
                    cmb_peripheraltype.Show()
                    lbl_datetoday.Show()
                    strcon.Close()
                ElseIf cmb_itemtype.Text = "Networking" Then
                    Try
                        Dim unitID As String

                        cmd.CommandText = "SELECT unit_id FROM tbl_stocknetworkdevice ORDER BY unit_id DESC LIMIT 1"
                        cmd.Connection = strcon

                        unitID = Convert.ToInt32(cmd.ExecuteScalar())

                        Dim finalunitid As Integer
                        Dim unitidtext As String
                        If unitID >= 1 Then
                            finalunitid = unitID + 1
                            unitidtext = Convert.ToString(finalunitid)
                            lbl_unitid.Text = unitidtext
                        Else
                            finalunitid = 951201
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
                    DisableSpecs()
                    cmb_peripheraltype.Show()
                    lbl_peripheraltype.Show()
                    lbl_datetoday.Hide()
                    strcon.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()

        End Try

    End Sub

    Private Sub txtbx_serialno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbx_serialno.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_itemtype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_itemtype.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_unitcondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_unitcondition.SelectedIndexChanged
        If cmb_unitcondition.Text = "New" Or cmb_unitcondition.Text = "Working" Then
            cmb_availability.Text = "Available"
        ElseIf cmb_unitcondition.Text = "Defective" Then
            cmb_availability.Text = "Not Available"
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


    'FUNCTIONALITY CODE'

    Public Sub AddItem()
        Dim itemtype As String = cmb_itemtype.Text

        Select Case itemtype
            Case "System unit"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','System unit','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','System unit','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockpcunit (unit_id,serial_number,brand_name,model,manufacturer,cpu,memory,version,storage,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','" & cmb_manufacturer.Text & "','" & cmb_cpu.Text & "','" & cmb_memory.Text & "','" & cmb_version.Text & "','" & txtb_storagesize.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','System unit','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_pcunitcondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Sysetm unit added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Laptop"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Laptop','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Laptop','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stocklaptop (unit_id,serial_number,brand_name,model,manufacturer,cpu,memory,version,storage,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','" & cmb_manufacturer.Text & "','" & cmb_cpu.Text & "','" & cmb_memory.Text & "','" & cmb_version.Text & "','" & txtb_storagesize.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Laptop','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_laptopcondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Laptop added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Monitor"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Monitor','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Monitor','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockmonitor (unit_id,serial_number,brand_name,model,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Monitor','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_monitorcondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Monitor added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Storage"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Storage drive','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Storage drive','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockstorage (unit_id,serial_number,brand_name,model,type,size,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','" & cmb_version.Text & "','" & cmb_memory.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Storage drive','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_storagecondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Storage drive added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Memory"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Memory','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Memory','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockmemory (unit_id,serial_number,brand_name,model,type,size,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','" & cmb_version.Text & "','" & cmb_memory.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Memory','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_memorycondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("RAM added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Printer"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Printer','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Printer','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockprinter (unit_id,serial_number,brand_name,model,type,size,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','" & cmb_version.Text & "','" & cmb_memory.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Printer','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_printercondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Printer added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Peripherals"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Peripherals','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Peripherals','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stockperipherals (unit_id,serial_number,brand_name,model,type,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & cmb_peripheraltype.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Peripherals','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_peripheralcondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show(cmb_peripheraltype.Text + " added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            Case "Networking"
                Try
                    strcon.Close()
                    create("INSERT INTO tbl_inventorystorage (unit_id,serial_number,brand_name,model,unit_type,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "','Networking','" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocks (unit_id,serial_number,brand_name,model,unit_type,unit_condition,availability,date_added) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Networking','" & cmb_unitcondition.Text & "','" & cmb_availability.Text & "','" & lbl_datetoday.Text & "')")
                    strcon.Close()
                    create("INSERT INTO tbl_stocknetworkdevice (unit_id,serial_number,brand_name,model,type,purchased_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & cmb_peripheraltype.Text & "','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_allstocksvalue (unit_id,serial_number,brand_name,model,unit_type,purchased_value,depreciation_value,date_purchased) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "', '" & cmb_brand.Text & "','" & txtb_model.Text & "','Networking','0','0','')")
                    strcon.Close()
                    create("INSERT INTO tbl_networkdevicecondition (unit_id,serial_number,brand,model,unit_condition) VALUES ('" & lbl_unitid.Text & "','" & txtbx_serialno.Text & "','" & cmb_brand.Text & "','" & txtb_model.Text & "', '" & cmb_unitcondition.Text & "')")
                    strcon.Close()
                    MessageBox.Show("Network Device added in the storage!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number", dgv_stockunit)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
        End Select
       
    End Sub

   
    Private Sub cmb_sortby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_sortby.SelectedIndexChanged
        reload("select tbl_inventorystorage.* , tbl_allstocks.availability, tbl_allstocks.date_added FROM tbl_inventorystorage left join tbl_allstocks on tbl_inventorystorage.serial_number=tbl_allstocks.serial_number WHERE tbl_inventorystorage.unit_type = '" & cmb_sortby.Text & "'", dgv_stockunit)
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
        'storage_addolditem.lbl_userid.Text = lbl_userid.Text
        'storage_addolditem.lbl_fname.Text = lbl_fname.Text
        'storage_addolditem.lbl_lname.Text = lbl_lname.Text
        'storage_addolditem.lbl_username.Text = lbl_username.Text
        'storage_addolditem.lbl_position.Text = lbl_position.Text
        'storage_addolditem.lbl_fullname.Text = lbl_fullname.Text
        'storage_addolditem.Show()
        'Me.Close()
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