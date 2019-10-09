Public Class Data_Penyewa
    Dim cr As New crud
    Dim query As String
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = cr.tampil_data("select *from data_penyewa")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim queri As String = "select AVG(tagihan_akhir) from data_penyewa"
        DataGridView1.DataSource = cr.tampil_data(queri)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim queri As String = "select max(tagihan_akhir) as terbesar from data_penyewa"
        DataGridView1.DataSource = cr.tampil_data(queri)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim queri As String = "select min(tagihan_akhir) as terkecil from data_penyewa"
        'Dim queri As String = "select from data_penyewa where tagihan_akhir=min(tagihan_akhir)"
        DataGridView1.DataSource = cr.tampil_data(queri)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim queri As String = "select sum(tagihan_akhir) as total from data_penyewa"
        DataGridView1.DataSource = cr.tampil_data(queri)
    End Sub
End Class