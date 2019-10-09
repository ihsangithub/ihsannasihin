Public Class update_barang

    Dim cr As New crud
    Private _aksi As String
    Public Property aksi As String
        Get
            Return _aksi
        End Get
        Set(value As String)
            _aksi = value
        End Set
    End Property
    'Sub New(ByVal aksi As String)
    '    InitializeComponent()
    '    _aksi = aksi
    'End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (_aksi = "nama") Then
            Try
                cr.updatenama(TextBox1.Text, ComboBox1.Text)
            Catch ex As Exception
                MsgBox("Update nama gagal")
            End Try
        ElseIf (_aksi = "type") Then
            Try
                cr.updatetype(TextBox1.Text, ComboBox1.Text)
            Catch ex As Exception
                MsgBox("Update type gagal")
            End Try
        ElseIf (_aksi = "harga") Then
            Try
                cr.updateharga(TextBox1.Text, ComboBox1.Text)
            Catch ex As Exception
                MsgBox("Update harga gagal")
            End Try
        ElseIf (_aksi = "tambah") Then
            Try
                Dim data As New DataTable
                data = cr.searchdatabarang(ComboBox1.Text)
                Dim sl As Integer = data.Rows(0).Item(4)
                cr.updatestok(TextBox1.Text + sl, ComboBox1.Text)
            Catch ex As Exception
                MsgBox("Update harga gagal")
            End Try
        ElseIf (_aksi = "kurang") Then
            Try
                Dim data As New DataTable
                data = cr.searchdatabarang(ComboBox1.Text)
                Dim sl As Integer = data.Rows(0).Item(4)
                cr.updatestok(sl - TextBox1.Text, ComboBox1.Text)
            Catch ex As Exception
                MsgBox("Update harga gagal")
            End Try
        End If
        Me.Hide()
        Data_Barang.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Update Batal")
        Me.Hide()
        Data_Barang.Show()
    End Sub

    Private Sub update_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cr.tampilcombo3()
    End Sub
End Class