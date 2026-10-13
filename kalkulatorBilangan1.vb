Public Class kalkulatorBilangan1





    ' Menyimpan angka pertama
    Dim angkaPertama As Decimal = 0

        ' Menyimpan operator yang dipilih
        Dim operatorHitung As String = ""

        ' Menentukan apakah input angka baru dimulai
        Dim inputBaru As Boolean = True

        ' =========================
        ' TOMBOL ANGKA 0 - 9
        ' =========================

        Private Sub TombolAngka_Click(
        sender As Object,
        e As EventArgs
    ) Handles btn0.Click, btn1.Click, btn2.Click,
              btn3.Click, btn4.Click, btn5.Click,
              btn6.Click, btn7.Click, btn8.Click,
              btn9.Click

            Dim tombol As Button = CType(sender, Button)
            Dim angka As String = tombol.Text

            If inputBaru Then
                txtangka.Text = angka
                inputBaru = False
            ElseIf txtangka.Text = "0" Then
                txtangka.Text = angka
            Else
                txtangka.Text &= angka
            End If

        End Sub

        ' =========================
        ' TOMBOL TITIK DESIMAL
        ' =========================

        Private Sub btntitik_Click(
        sender As Object,
        e As EventArgs
    ) Handles btntitik.Click

            If inputBaru Then
                txtangka.Text = "0."
                inputBaru = False
            ElseIf Not txtangka.Text.Contains(".") Then
                txtangka.Text &= "."
            End If

        End Sub

        ' =========================
        ' OPERATOR + - * /
        ' =========================

        Private Sub Operator_Click(
        sender As Object,
        e As EventArgs
    ) Handles btntambah.Click, btnkurang.Click,
              btnkali.Click, btnbagi.Click

            Dim tombol As Button = CType(sender, Button)

            ' Jika layar kosong setelah memilih operator,
            ' izinkan pengguna mengganti operator.
            If txtangka.Text = "" Then
                operatorHitung = tombol.Text
                Return
            End If

            ' Simpan angka pertama
            If Not Decimal.TryParse(
            txtangka.Text,
            Globalization.NumberStyles.Number,
            Globalization.CultureInfo.InvariantCulture,
            angkaPertama
        ) Then
                Return
            End If

            ' Simpan operator
            operatorHitung = tombol.Text

            ' Kosongkan layar untuk angka kedua
            txtangka.Clear()
            inputBaru = True

        End Sub

        ' =========================
        ' TOMBOL SAMA DENGAN
        ' =========================

        Private Sub btnSamaDengan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSamaDengan.Click

            Dim angkaKedua As Decimal
            Dim hasil As Decimal

            ' Pastikan angka kedua tersedia
            If operatorHitung = "" OrElse
           txtangka.Text = "" Then
                Return
            End If

            If Not Decimal.TryParse(
            txtangka.Text,
            Globalization.NumberStyles.Number,
            Globalization.CultureInfo.InvariantCulture,
            angkaKedua
        ) Then
                Return
            End If

            ' Melakukan perhitungan
            Select Case operatorHitung

                Case "+"
                    hasil = angkaPertama + angkaKedua

                Case "-"
                    hasil = angkaPertama - angkaKedua

                Case "*"
                    hasil = angkaPertama * angkaKedua

                Case "/"
                    If angkaKedua = 0 Then
                        txtangka.Text = "Tidak bisa dibagi 0"
                        operatorHitung = ""
                        inputBaru = True
                        Return
                    End If

                    hasil = angkaPertama / angkaKedua

                Case Else
                    Return

            End Select

            ' Tampilkan hasil di layar yang sama
            txtangka.Text = hasil.ToString(
            Globalization.CultureInfo.InvariantCulture
        )

            ' Bersihkan operator untuk perhitungan selanjutnya
            operatorHitung = ""
            inputBaru = True

        End Sub


End Class