Public Class login_admin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (String.IsNullOrEmpty(TextBox1.Text.Trim())) Then
            MsgBox("Masukkan Username !!!")
        ElseIf (String.IsNullOrEmpty(TextBox2.Text.Trim())) Then
            MsgBox("Masukkan Passwordnya !!!")
        Else
            If (TextBox1.Text = "ihsan" And TextBox2.Text = "1") Then
                Me.Hide()
                menu_utama.Show()
                menu_utama.Button3.Enabled = True
                menu_utama.Button4.Enabled = True
            ElseIf (TextBox1.Text <> "ihsan" And TextBox2.Text <> "1") Then
                MsgBox("Username dan Password Salah !!!")
            ElseIf TextBox1.Text <> "ihsan" Then
                MsgBox("Username Salah !!!")
            ElseIf (TextBox2.Text <> "1") Then
                MsgBox("Password Salah !!!")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        form_awal.Show()
    End Sub
End Class