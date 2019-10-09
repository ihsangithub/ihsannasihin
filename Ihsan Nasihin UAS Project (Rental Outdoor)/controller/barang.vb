Public Class barang
    Private _harga As Integer
    Private _total As Integer
    Private _bayar As Integer
    Private _tagihan As Integer
    Private diskon As Double
    Private _tot_tag As Double
    Private _uang As Integer

    Public Property uang As Integer
        Get
            Return _uang
        End Get
        Set(value As Integer)
            _uang = value
        End Set
    End Property
    Public Property tot_tag As Double
        Get
            Return _tot_tag
        End Get
        Set(value As Double)
            _tot_tag = value
        End Set
    End Property
    Public Property tagihan As Integer
        Get
            Return _tagihan
        End Get
        Set(value As Integer)
            _tagihan = value
        End Set
    End Property
    Public Property bayar As Integer
        Get
            Return _bayar
        End Get
        Set(value As Integer)
            _bayar = value
        End Set
    End Property
    Public Property total As Integer
        Get
            Return _total
        End Get
        Set(value As Integer)
            _total = value
        End Set
    End Property
    Public Property harga As Integer
        Get
            Return _harga
        End Get
        Set(value As Integer)
            _harga = value
        End Set
    End Property

    Public Property dis As Double
        Get
            Return diskon
        End Get
        Set(value As Double)
            diskon = value
        End Set
    End Property
    Public Function hitung(ByVal tagihan As Integer) As Double
        Return tagihan
    End Function
End Class
