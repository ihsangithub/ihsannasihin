Public Class form_penyewaan
    Dim cr As New crud
    Dim sew As New sewa

    Private kodedatabarang As String
    Private Sub form_penyewaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = True
        DataGridBarang.DataSource = cr.tampil_data("select * from tb_barang")
        cr.tampilcombo()
        sew.total = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cr.updatetotharga(sew.total, TextBox1.Text)
            sew.total = 0
            Button3.Enabled = False
            Button1.Enabled = False
        Catch ex As Exception
            MsgBox("no identitas sudah terdaftar")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        menu_utama.Show()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridBarang.CellContentClick

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (String.IsNullOrEmpty(ComboBox1.Text.Trim())) Then
            MsgBox("Pilih Id Barang")
        ElseIf (String.IsNullOrEmpty(TextBox3.Text.Trim())) Then
            MsgBox("Masukkan Jumlah Unit Barang")
        ElseIf (String.IsNullOrEmpty(TextBox4.Text.Trim())) Then
            MsgBox("Masukkan Lama Sewa Barang")
        Else
            kodedatabarang = ComboBox1.Text
            Dim data As New DataTable
            data = cr.searchdatabarang(kodedatabarang)
            sew.harga = TextBox3.Text * TextBox4.Text * data.Rows(0).Item(3)
            sew.total += sew.harga
            cr.insertbarangdisewa(TextBox1.Text, ComboBox1.Text, TextBox3.Text, TextBox4.Text, sew.harga)
            Dim lis(4) As String
            lis(0) = ComboBox1.Text
            lis(1) = TextBox3.Text
            lis(2) = TextBox4.Text
            lis(3) = sew.harga

            ListBox1.Items.Add(lis(0))
            ListBox2.Items.Add(lis(1))
            ListBox3.Items.Add(lis(2))
            ListBox4.Items.Add(lis(3))

            ComboBox1.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            DataGridBarang.DataSource = cr.tampil_data("select * from tb_barang")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (String.IsNullOrEmpty(TextBox1.Text.Trim())) Then
            MsgBox("Masukkan No Identitas")
        ElseIf (String.IsNullOrEmpty(TextBox2.Text.Trim())) Then
            MsgBox("Masukkan Nama Anda")
        Else
            Try
                cr.insertpenyewa(TextBox1.Text, TextBox2.Text, 0)
                Button3.Enabled = True
                Button1.Enabled = True
            Catch ex As Exception
                MsgBox("Registrasi Nama Gagal")
            End Try
        End If
    End Sub

End Class