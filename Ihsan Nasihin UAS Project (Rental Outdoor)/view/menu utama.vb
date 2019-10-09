Public Class menu_utama
    Dim cr As New crud
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Data_Barang.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        form_awal.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With form_penyewaan
            .TextBox1.Text = ""
            .TextBox2.Text = ""
            .ComboBox1.Text = ""
            .TextBox3.Text = ""
            .TextBox4.Text = ""
            .Button4.Enabled = True
            .ListBox1.Items.Clear()
            .ListBox2.Items.Clear()
            .ListBox3.Items.Clear()
            .ListBox4.Items.Clear()
            .TextBox1.ReadOnly = False
            .TextBox2.ReadOnly = False
            .DataGridBarang.DataSource = cr.tampil_data("select * from tb_barang")
        End With
        Me.Hide()
        form_penyewaan.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        form_pengembalian.DataGridpenyewa.DataSource = cr.tampil_data("select d.no_identitas, p.nama_lengkap, d.id_barang, d.jumlah_unit, d.lama_sewa, d.harga, p.total_harga from data_barang_disewa d inner join tb_penyewa p on d.no_identitas=p.no_identitas")
        Me.Hide()
        form_pengembalian.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Data_Penyewa.DataGridView1.DataSource = cr.tampil_data("select *from data_penyewa")
        Me.Hide()
        Data_Penyewa.Show()
    End Sub
End Class