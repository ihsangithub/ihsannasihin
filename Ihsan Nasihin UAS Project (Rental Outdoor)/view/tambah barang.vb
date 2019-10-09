Public Class tambah_barang

    Dim crd As New crud
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            crd.insertbarang(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Catch ex As Exception
            MsgBox("Tambah Gagal")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Tambah Barang Dibatalkan")
        Me.Hide()
        Data_Barang.Show()
    End Sub
End Class