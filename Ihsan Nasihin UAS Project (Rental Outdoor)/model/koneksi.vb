Imports MySql.Data.MySqlClient
Public Class koneksi
    Public konek As String = "server=localhost;user id=root;database=b_three_adventure"
    Private kon As New MySqlConnection(konek)
    Protected rd As MySqlDataReader
    Protected cmd_a As MySqlDataAdapter
    Protected cmd_c As MySqlCommand

    Protected Function bukakoneksi() As MySqlConnection
        Try
            If kon.State = ConnectionState.Closed Then
                kon.Open()
                'MsgBox("Koneksi Open")
            End If
        Catch ex As Exception
            MsgBox("Koneksi error" + ex.Message)
        End Try
        Return kon
    End Function
End Class
