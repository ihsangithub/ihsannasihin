Imports MySql.Data.MySqlClient
Public Class crud
    Inherits koneksi
    Public Function tampil_data(ByVal query As String) As DataTable
        Dim tampil As New DataTable
        Try
            cmd_a = New MySqlDataAdapter(query, bukakoneksi())
            cmd_a.Fill(tampil)
        Catch ex As Exception
            MsgBox("Data tidak tampil")
        End Try
        Return tampil
    End Function
    Sub tampilcombo()
        Try
            cmd_c = New MySqlCommand("select id_barang from tb_barang", bukakoneksi)
            rd = cmd_c.ExecuteReader
            form_penyewaan.ComboBox1.Items.Clear()
            While rd.Read
                form_penyewaan.ComboBox1.Items.Add(rd(0).ToString)
            End While
            rd.Close()
        Catch ex As Exception
            MsgBox("Tampil textbox gagal")
        End Try
    End Sub
    Sub tampilcombo2()
        Try
            cmd_c = New MySqlCommand("select id_barang from tb_barang", bukakoneksi)
            rd = cmd_c.ExecuteReader
            hapus_barang.ComboBox1.Items.Clear()
            While rd.Read
                hapus_barang.ComboBox1.Items.Add(rd(0).ToString)
            End While

            rd.Close()
        Catch ex As Exception
            MsgBox("Tampil textbox gagal")
        End Try
    End Sub
    Sub tampilcombo3()
        Try
            cmd_c = New MySqlCommand("select id_barang from tb_barang", bukakoneksi)
            rd = cmd_c.ExecuteReader
            update_barang.ComboBox1.Items.Clear()
            While rd.Read
                update_barang.ComboBox1.Items.Add(rd(0).ToString)
            End While
            rd.Close()
        Catch ex As Exception
            MsgBox("Tampil textbox gagal")
        End Try
    End Sub
    Public Sub insertbarang(ByVal id As String, ByVal nama As String, ByVal type As String, ByVal hari As Integer, ByVal stok As Integer)
        Try
            Dim str As String
            str = "insert into tb_barang values('" & id & "','" & nama & "','" & type & "','" & hari & "','" & stok & "')"
            cmd_c = New MySqlCommand(str, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MessageBox.Show("Insert barang Berhasil")
            tambah_barang.Hide()
            Data_Barang.Show()
        Catch ex As Exception
            MessageBox.Show("Insert Barang Gagal" + ex.ToString)
        End Try
    End Sub
    Public Sub insertpenyewa(ByVal no As String, ByVal nama As String, ByVal tot As Integer)
        Try
            Dim str As String
            str = "insert into tb_penyewa values('" & no & "','" & nama & "','" & tot & "')"
            cmd_c = New MySqlCommand(str, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MessageBox.Show("Nama Berhasil di Input")
            With form_penyewaan
                .Button4.Enabled = False
                .TextBox1.ReadOnly = True
                .TextBox2.ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show("Input Nama Gagal" + ex.ToString)
        End Try
    End Sub
    Public Sub insertbarangdisewa(ByVal no As String, ByVal id As String, ByVal jum As Integer, ByVal lama As Integer, ByVal harga As Integer)
        Try
            Dim str As String
            str = "insert into data_barang_disewa values('" & no & "','" & id & "','" & jum & "','" & lama & "','" & harga & "')"
            cmd_c = New MySqlCommand(str, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MessageBox.Show("Barang Berhasil disewa")
        Catch ex As Exception
            MessageBox.Show("Sewa Barang Gagal" + ex.ToString)
        End Try
    End Sub
    Public Sub insertdatapenyewa(ByVal no As String, ByVal nama As String, ByVal awal As Integer, ByVal dis As String, ByVal akhir As Integer)
        Try
            Dim str As String
            str = "insert into data_penyewa values('" & no & "','" & nama & "','" & awal & "','" & dis & "','" & akhir & "')"
            cmd_c = New MySqlCommand(str, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MessageBox.Show("Barang Berhasil disewa")
            With form_pengembalian
                .TextBox1.Text = ""
                .TextBox2.Text = ""
                .TextBox3.Text = ""
                .TextBox4.Text = ""
                .TextBox5.Text = ""
                .TextBox6.Text = ""
                .Label8.Text = "..."
                .Button5.Enabled = False
                .Button4.Enabled = False
            End With
        Catch ex As Exception
            MessageBox.Show("Sewa Barang Gagal" + ex.ToString)
        End Try
    End Sub
    Public Sub hapus_data_barang()
        Try
            Dim query As String = "delete from tb_barang where id_barang='" + hapus_barang.ComboBox1.Text + "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("Data Dihapus")
        Catch ex As Exception
            MsgBox("Masih ada barang yang di luar")
            'MsgBox("Data Gagal Dihapus" + ex.ToString)
        End Try
    End Sub
    Public Sub hapus_penyewa(ByVal kode As String)
        Try
            Dim query As String = "delete from tb_penyewa where no_identitas='" + kode + "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            'MsgBox("Data penyewa Dihapus")
            form_pengembalian.Hide()
            menu_utama.Show()
        Catch ex As Exception
            MsgBox("Data Gagal Dihapus" + ex.ToString)
        End Try
    End Sub
    Public Sub hapus_barangpenyewa(ByVal kode As String)
        Try
            Dim query As String = "delete from data_barang_disewa where no_identitas='" + kode + "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            'MsgBox("Data barang Dihapus")
            hapus_penyewa(kode)
        Catch ex As Exception
            MsgBox("Data Gagal Dihapus" + ex.ToString)
        End Try
    End Sub
    Sub updatenama(ByVal nama As String, ByVal id As String)
        Try
            Dim query As String = "update tb_barang set nama_barang='" & nama & "' where id_barang='" & id & "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("Nama barang berhasil di ubah")
        Catch ex As Exception
            MsgBox("Data Gagal Diubah" + ex.ToString)
        End Try
    End Sub
    Sub updatetype(ByVal type As String, ByVal id As String)
        Try
            Dim query As String = "update tb_barang set type='" & type & "' where id_barang='" & id & "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("type barang berhasil di ubah")
        Catch ex As Exception
            MsgBox("Data Gagal Diubah" + ex.ToString)
        End Try
    End Sub
    Sub updatestok(ByVal st As String, ByVal id As String)
        Try
            Dim query As String = "update tb_barang set stok='" & st & "' where id_barang='" & id & "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("type barang berhasil di ubah")
        Catch ex As Exception
            MsgBox("Data Gagal Diubah" + ex.ToString)
        End Try
    End Sub
    Sub updateharga(ByVal harga As String, ByVal id As String)
        Try
            Dim query As String = "update tb_barang set type='" & harga & "' where id_barang='" & id & "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("type barang berhasil di ubah")
        Catch ex As Exception
            MsgBox("Data Gagal Diubah" + ex.ToString)
        End Try
    End Sub
    Sub updatetotharga(ByVal tot As String, ByVal no As String)
        Try
            Dim query As String = "update tb_penyewa set total_harga='" & tot & "' where no_identitas='" & no & "'"
            cmd_c = New MySqlCommand(query, bukakoneksi())
            cmd_c.ExecuteNonQuery()
            MsgBox("total harga = " + tot)
            form_penyewaan.Hide()
            menu_utama.Show()
        Catch ex As Exception
            MsgBox("total harga gagal" + ex.ToString)
        End Try
    End Sub
    Public Function searchdata(ByVal cari As String) As DataTable
        Dim dt = New DataTable
        Dim query As String = "select * from tb_penyewa where no_identitas like '%" + cari + "%' or nama_lengkap like '%" + cari + "%'"
        Try
            cmd_a = New MySqlDataAdapter(query, bukakoneksi())
            cmd_a.Fill(dt)
        Catch ex As Exception
            MsgBox("Salah tampil" + ex.ToString)
        End Try
        Return dt
    End Function
    Public Function searchdatabarang(ByVal cari As String) As DataTable
        Dim dt = New DataTable
        Dim query As String = "select * from tb_barang where id_barang like '%" + cari + "%' or nama_barang like '%" + cari + "%'"
        Try
            cmd_a = New MySqlDataAdapter(query, bukakoneksi())
            cmd_a.Fill(dt)
        Catch ex As Exception
            MsgBox("Salah tampil" + ex.ToString)
        End Try
        Return dt
    End Function
    Public Function searchpenyewabarang(ByVal cari As String) As DataTable
        Dim dt = New DataTable
        Dim query As String = "select d.no_identitas, p.nama_lengkap, d.id_barang, d.jumlah_unit, d.lama_sewa, d.harga, p.total_harga from data_barang_disewa d inner join tb_penyewa p on d.no_identitas=p.no_identitas where d.no_identitas like '%" + cari + "%' or p.nama_lengkap like '%" + cari + "%'"
        Try
            cmd_a = New MySqlDataAdapter(query, bukakoneksi())
            cmd_a.Fill(dt)
        Catch ex As Exception
            MsgBox("Salah tampil" + ex.ToString)
        End Try
        Return dt
    End Function
End Class
