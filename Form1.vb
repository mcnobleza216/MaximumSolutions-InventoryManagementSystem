Imports MySql.Data.MySqlClient
Public Class Form1
    Dim MySqlcon As MySqlConnection
    Dim command As MySqlCommand
    Dim query As String


    Private Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        MySqlcon = New MySqlConnection
        MySqlcon.ConnectionString = ("server=192.168.0.12; database=dbinventory;username=root;password=root")
        Dim reader As MySqlDataReader

            MySqlcon.Open()

        query = "select * from tbl_user where username = '" & txtuser.Text & "' and password= '" & txtpass.Text & "' and user_type= 'staff'"
            command = New MySqlCommand(query, MySqlcon)
            reader = command.ExecuteReader

        If (reader.HasRows) Then
            reader.Read()

            Dim userid As String = reader.GetValue(0).ToString()
            Dim fname As String = reader.GetValue(1).ToString()
            Dim lname As String = reader.GetValue(2).ToString()
            Dim username As String = reader.GetValue(3).ToString()
            Dim position As String = reader.GetValue(6).ToString()

            Home.lbl_userid.Text = userid
            Home.lbl_fname.Text = fname
            Home.lbl_lname.Text = lname
            Home.lbl_username.Text = username
            Home.lbl_fullname.Text = fname + " " + lname
            Home.lbl_position.Text = position

            MessageBox.Show("Login Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Home.Show()

            Me.Close()
            MySqlcon.Close()
            Exit Sub

        Else

            MySqlcon.Close()
            MySqlcon.Open()

            query = "select * from tbl_user where username = '" & txtuser.Text & "' and password= '" & txtpass.Text & "' and user_type= 'admin'"
            command = New MySqlCommand(query, MySqlcon)
            reader = command.ExecuteReader

            If (reader.HasRows) Then
                MessageBox.Show("Login Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dashboard.Show()
                Me.Close()
                MySqlcon.Close()
                Exit Sub

            ElseIf txtpass.Text = "" Or txtuser.Text = "" Then
                MessageBox.Show("please enter your username or password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("username or password is incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            MySqlcon.Close()
        End If
    End Sub

    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtuser.Focus()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the system?", "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class
