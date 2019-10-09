Public Class hapus_barang

    Dim cr As New crud
    Private Sub hapus_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cr.tampilcombo2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Data_Barang.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cr.hapus_data_barang()
        Me.Hide()
        Data_Barang.Show()
    End Sub
End Class