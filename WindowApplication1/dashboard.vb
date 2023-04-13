Public Class dashboard

    Dim isCollapsed As Boolean = True
    Dim isCollapsed2 As Boolean = False

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("Log out success, you will be prompt to Login Screen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DropDownPanel.Size = DropDownPanel.MinimumSize
        Panel_SlideStock.Size = Panel_SlideStock.MaximumSize

    End Sub

   

    Private Sub Btn_Designation_Click(sender As Object, e As EventArgs) Handles Btn_Designation.Click

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isCollapsed Then

            DropDownPanel.Height += 10
            If DropDownPanel.Size = DropDownPanel.MaximumSize Then
                Timer1.Stop()
                isCollapsed = False
            End If
        Else
            DropDownPanel.Height -= 10
            If DropDownPanel.Size = DropDownPanel.MinimumSize Then
                Timer1.Stop()
                isCollapsed = True
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If isCollapsed2 Then
            Picture_Slide.Image = My.Resources.ARROWUP
            Panel_SlideStock.Height += 10
            If Panel_SlideStock.Size = Panel_SlideStock.MaximumSize Then
                Timer2.Stop()
                isCollapsed2 = False
            End If
        Else
            Picture_Slide.Image = My.Resources.ARROWDOWN_removebg_preview
            Panel_SlideStock.Height -= 10
            If Panel_SlideStock.Size = Panel_SlideStock.MinimumSize Then
                Timer2.Stop()
                isCollapsed2 = True
            End If
        End If
    End Sub

    Private Sub Btn_StockSlide_Click(sender As Object, e As EventArgs) Handles Btn_StockSlide.Click
        Timer2.Start()
    End Sub
   
    Private Sub Btn_StockSlide_Click_1(sender As Object, e As EventArgs) Handles Btn_StockSlide.Click

    End Sub

    Private Sub btn_unit_Click(sender As Object, e As EventArgs) Handles btn_unit.Click
        stock_systemunit.Show()
        Me.Close()
    End Sub
End Class