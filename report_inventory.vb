Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Text
Imports Microsoft.Reporting.WinForms

Public Class report_inventory

    Private Sub report_inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Sub LoadReport()

        Dim rptDS As ReportDataSource
        Me.ReportViewer1.RefreshReport()

        Try

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter

            strcon.Open()

            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage", strcon)
            da.Fill(ds.Tables("dt_inventory"))
            strcon.Close()

            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.FullPage


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    'Private Sub cmb_unittype_TextChanged(sender As Object, e As EventArgs) Handles cmb_unittype.TextChanged
    '    cmb_condition.Text = "SELECT"
    '    If cmb_condition.Text = "NONE" And cmb_unittype.Text = "SELECT ALL" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage


    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text = "SELECT ALL" And cmb_condition.Text <> "SELECT" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_condition = '" & cmb_condition.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text <> "SELECT ALL" And cmb_condition.Text <> "SELECT" Then

    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_condition = '" & cmb_condition.Text & "' AND unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_condition.Text = "NONE" And cmb_unittype.Text <> "SELECT ALL" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text <> "SELECT ALL" And cmb_condition.Text = "SELECT" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_condition.Text = "SELECT" And cmb_unittype.Text = "SELECT ALL" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try


    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub

 
    'Private Sub cmb_condition_TextChanged(sender As Object, e As EventArgs) Handles cmb_condition.TextChanged
    '    If cmb_condition.Text = "NONE" And cmb_unittype.Text = "SELECT ALL" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try
             
    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage


    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text = "SELECT ALL" And cmb_condition.Text <> "SELECT" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try
            

    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_condition = '" & cmb_condition.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text <> "SELECT ALL" And cmb_condition.Text <> "SELECT" Then

    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try
            
    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_condition = '" & cmb_condition.Text & "' AND unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text <> "SELECT ALL" And cmb_condition.Text = "NONE" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try

    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    ElseIf cmb_unittype.Text <> "SELECT ALL" And cmb_condition.Text = "SELECT" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try
              

    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage WHERE unit_type ='" & cmb_unittype.Text & "'", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    ElseIf cmb_condition.Text = "SELECT" And cmb_unittype.Text = "SELECT ALL" Then
    '        Dim rptDS As ReportDataSource
    '        Me.ReportViewer1.RefreshReport()

    '        Try
                

    '            Dim ds As New DataSet1
    '            Dim da As New MySqlDataAdapter

    '            strcon.Open()

    '            da.SelectCommand = New MySqlCommand("SELECT * FROM tbl_inventorystorage", strcon)
    '            da.Fill(ds.Tables("dt_inventory"))
    '            strcon.Close()

    '            rptDS = New ReportDataSource("DataSet1", ds.Tables("dt_inventory"))
    '            ReportViewer1.LocalReport.DataSources.Add(rptDS)
    '            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    '            ReportViewer1.ZoomMode = ZoomMode.FullPage
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub
End Class