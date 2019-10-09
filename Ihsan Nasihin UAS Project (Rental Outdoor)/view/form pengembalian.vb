Public Class form_pengembalian
    Dim cr As New crud
    Dim sew As New sewa
    Private kode As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Batal")
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub form_pengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridpenyewa.DataSource = cr.tampil_data("select d.no_identitas, p.nama_lengkap, d.id_barang, d.jumlah_unit, d.lama_sewa, d.harga, p.total_harga from data_barang_disewa d inner join tb_penyewa p on d.no_identitas=p.no_identitas")
    End Sub
    Sub isitext()
        Dim data As New DataTable
        data = cr.searchdata(kode)
        Try
            TextBox4.Text = data.Rows(0).Item(0)
            TextBox1.Text = data.Rows(0).Item(1)
            TextBox2.Text = data.Rows(0).Item(2)
        Catch ex As Exception
            MsgBox("Tidak ada objek")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            kode = DataGridpenyewa.CurrentRow.Cells(0).Value.ToString
        Catch ex As Exception
            MsgBox("Tidak ada objek")
        End Try
        isitext()
        Button5.Enabled = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim aa As String = TextBox5.Text
        Try
            DataGridpenyewa.DataSource = cr.searchpenyewabarang(aa)
        Catch ex As Exception
            MsgBox("Cari gagal")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            sew.tagihan = TextBox2.Text
        Catch ex As Exception
            MsgBox("Periksa Tagihan Bukan Angka")
        End Try
        If sew.tagihan >= 100000 And sew.tagihan <= 150000 Then
            sew.dis = 0.05
            Label8.Text = "5 %"
            sew.tot_tag = sew.hitung(sew.tagihan, sew.dis)
        ElseIf sew.tagihan > 150000 And sew.tagihan <= 250000 Then
            sew.dis = 0.1
            Label8.Text = "10 %"
            sew.tot_tag = sew.hitung(sew.tagihan, sew.dis)
        ElseIf sew.tagihan > 250000 And sew.tagihan <= 400000 Then
            sew.dis = 0.15
            Label8.Text = "15 %"
            sew.tot_tag = sew.hitung(sew.tagihan, sew.dis)
        ElseIf sew.tagihan > 400000 Then
            sew.dis = 0.2
            Label8.Text = "20 %"
            sew.tot_tag = sew.hitung(sew.tagihan, sew.dis)
        ElseIf sew.tagihan < 100000 Then
            Label8.Text = "0 %"
            sew.tot_tag = sew.hitung(sew.tagihan)
        End If

        TextBox6.Text = sew.tot_tag
        Button4.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
       
        If (String.IsNullOrEmpty(TextBox3.Text.Trim())) Then
        MsgBox("Masukkan Uang anda")
        Else
            Try
                sew.uang = TextBox3.Text
                If sew.tot_tag = sew.uang Then
                    MsgBox("Uang anda Pass")
                    cr.hapus_barangpenyewa(TextBox4.Text)
                ElseIf sew.tot_tag > sew.uang Then
                    MsgBox("Uang anda Kurang !!!" & (sew.tot_tag - sew.uang))
                    MsgBox("Ulangi Pembayaran")
                ElseIf sew.tot_tag < sew.uang Then
                    MsgBox("Kembalian anda Rp." & (sew.uang - sew.tot_tag))
                    cr.hapus_barangpenyewa(TextBox4.Text)
                    cr.insertdatapenyewa(TextBox4.Text, TextBox1.Text, TextBox2.Text, Label8.Text, TextBox6.Text)
                End If
            Catch ex As Exception
                MsgBox("Inputan Harus angka")
            End Try
            
        End If
    End Sub
End Class