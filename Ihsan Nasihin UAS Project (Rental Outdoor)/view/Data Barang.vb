Public Class Data_Barang
    Dim cr As New crud
    'Dim frup As New update_barang

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        tambah_barang.Show()
    End Sub

    Private Sub Data_Barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = cr.tampil_data("select * from tb_barang")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus_barang.ComboBox1.Text = ""
        Me.Hide()
        hapus_barang.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With update_barang
            .Label3.Text = "Masukkan Nama Baru"
            .aksi = "nama"
            .ComboBox1.Text = ""
            .TextBox1.Text = ""
            Me.Hide()
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With update_barang
            .Label3.Text = "Masukkan Type Baru"
            .aksi = "type"
            .ComboBox1.Text = ""
            .TextBox1.Text = ""
            Me.Hide()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        With update_barang
            .Label3.Text = "Masukkan Harga Baru"
            .aksi = "harga"
            .ComboBox1.Text = ""
            .TextBox1.Text = ""
            Me.Hide()
            .Show()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With update_barang
            .Label3.Text = "Masukkan Tambah Baru"
            .aksi = "tambah"
            .ComboBox1.Text = ""
            .TextBox1.Text = ""
            Me.Hide()
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With update_barang
            .Label3.Text = "Masukkan Kurang Baru"
            .aksi = "kurang"
            .ComboBox1.Text = ""
            .TextBox1.Text = ""
            Me.Hide()
            .Show()
        End With
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim queri As String="select * from tb_barang"
        DataGridView1.DataSource = cr.tampil_data(queri)
    End Sub
End Class