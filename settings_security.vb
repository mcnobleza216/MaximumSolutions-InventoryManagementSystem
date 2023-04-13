Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text

Public Class settings_security


    Private Sub settings_security_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ptc_check.Visible = False
        txtbx_securitykey.Focus()
    End Sub

    Private Sub txtbx_securitykey_TextChanged(sender As Object, e As EventArgs) Handles txtbx_securitykey.TextChanged
        Try
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

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
        If txtbx_securitykey.Text = "" Then
            MessageBox.Show("Please enter the security key", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            REMOVEEMPLOYEE()
        End If
    End Sub

    Public Sub REMOVEEMPLOYEE()
        '  Dim action1 As String = "Remove Employee No. " + lbl_employeeno.Text
        If ptc_check.Visible = True Then
            If lbl_employeetype.Text = "INTERNAL EMPLOYEE" Then
                Try
                    strcon.Close()
                    deletes("DELETE FROM tbl_employee WHERE employee_no = '" & lbl_employeeno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Employee successfully remove from the list", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '  create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action1 & "','" & lbl_datetoday.Text & "')")
                    reload("SELECT * FROM tbl_employee", settings_employee.dgv_internal)
                    settings_employee.disabletext()
                    settings_employee.cleartext()
                    strcon.Close()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            ElseIf lbl_employeetype.Text = "EXTERNAL EMPLOYEE" Then
                Try
                    strcon.Close()
                    deletes("DELETE FROM tbl_employeeexternal WHERE employee_no = '" & lbl_employeeno.Text & "'")
                    strcon.Close()
                    MessageBox.Show("Employee successfully remove from the list", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'create("INSERT INTO tbl_activitylog(user_id,first_name,last_name,username,action,date_time) VALUES ('" & lbl_userid.Text & "','" & lbl_fname.Text & "','" & lbl_lname.Text & "','" & lbl_username.Text & "','" & action1 & "','" & lbl_datetoday.Text & "')")
                    reload("SELECT * FROM tbl_employeeexternal", settings_employee.dgv_external)
                    settings_employee.disabletext()
                    settings_employee.cleartext()
                    strcon.Close()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    strcon.Close()
                End Try
            End If
        Else
            MessageBox.Show("You entered a wrong security key!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
     

    End Sub
End Class