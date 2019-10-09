Public Class sewa
    Inherits barang

    Public Overloads Function hitung(ByVal tagihan As Integer, ByVal disk As Double) As Double
        Return tagihan - tagihan * disk
    End Function
End Class
