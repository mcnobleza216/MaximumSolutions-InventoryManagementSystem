Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class storage_updateitemvalue


    Private Sub txtbx_securitykey_TextChanged(sender As Object, e As EventArgs) Handles txtbx_securitykey.TextChanged
        Try
            strcon.Close()
            strcon.Open()

            cmd.CommandText = "SELECT * FROM tbl_securitykey WHERE security_key = '" & txtbx_securitykey.Text & "'"
            cmd.Connection = strcon

            Dim dr As MySqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                ptc_check.Visible = True
                strcon.Close()
            Else
                ptc_check.Visible = False
                strcon.Close()
            End If
            dr.Dispose()
            strcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_update2_Click(sender As Object, e As EventArgs) Handles btn_update2.Click
        If ptc_check.Visible = True Then
            Try
                updates("UPDATE tbl_allstocksvalue SET depreciation_value = '" & lbl_depreciatedvalue.Text & "', purchased_value = '" & lbl_purchasedvalue.Text & "', date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
                updateseperate()
                MessageBox.Show("Item value updated successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reload("select tbl_allstocksvalue.* , tbl_allstocks.date_added FROM tbl_allstocksvalue left join tbl_allstocks on tbl_allstocksvalue.serial_number=tbl_allstocks.serial_number", storage_itemvalue.dgv_stockunit)
                storage_itemvalue.dtp_purchased.Enabled = False
                storage_itemvalue.txtbx_purchasedval.ReadOnly = True
                storage_itemvalue.cleartext()
                Me.Close()
                strcon.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                strcon.Close()
            End Try
        ElseIf ptc_check.Visible = False Then
            MessageBox.Show("You entered a wrong security key!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub

    Private Sub storage_updateitemvalue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ptc_check.Visible = False
        txtbx_securitykey.Focus()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Public Sub updateseperate()
        If lbl_unittype.Text = "System unit" Then
            updates("UPDATE tbl_stockpcunit SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Laptop" Then
            updates("UPDATE tbl_stocklaptop SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Monitor" Then
            updates("UPDATE tbl_stockmonitor SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Memory" Then
            updates("UPDATE tbl_stockmemory SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Storage drive" Then
            updates("UPDATE tbl_stockstorage SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Printer" Then
            updates("UPDATE tbl_stockprinter SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Peripherals" Then
            updates("UPDATE tbl_stockperipherals SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        ElseIf lbl_unittype.Text = "Networking" Then
            updates("UPDATE tbl_stocknetworkdevice SET purchased_value='" & lbl_purchasedvalue.Text & "',date_purchased = '" & lbl_datepurchased.Text & "' WHERE serial_number = '" & lbl_serialno.Text & "'")
        End If
    End Sub
End Class