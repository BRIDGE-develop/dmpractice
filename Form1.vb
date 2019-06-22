Imports WindowsApp1

Public Class Form1
    Public Property idMaemoji As Object       'おおお、これはどんな仕方だ？
    Public Property idUsiromoji As Object
    ' Dim WithEvents txtStuId As String

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        txtStuId.MaxLength = 7          '入力桁数制限
        'Dim txtStuId_Pattern As String = "(\A{2}\d{5})"    'この正規表現の仕方は結局間違ったのだ。勉強しとこう。
        'Dim txtStuId_Pattern As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(txtStuId.Text, "\A\A\d\d\d\d\d")

        '学生番号チェック
        If txtStuId.Text <> "" Then
            If Not System.Text.RegularExpressions.Regex.IsMatch(txtStuId.Text, "^[A-Z]{2}[0-9]{5}$") Then        'Match(Me.txtStuId.Text)
                MsgBox("IDの形式が違う")
            End If
            ' MsgBox("OK")
        Else

            MsgBox("学生番号を入力してください。")
        End If

        'パスワードチェック
        txtStuPw.PasswordChar = "*"c        'cは何で付くのか。

        If txtStuPw.Text <> "" Then
            If txtStuPw.TextLength < 6 Or txtStuPw.TextLength > 10 Then
                MsgBox("パスワードは６～１０文字です。")

                txtStuPw.Focus()    '桁数の条件に満たされていないならパスワードのテキストボックスにフォーカス
            ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(txtStuPw.Text, "^(?=.*[0-9])(?=.*[A-Za-z])[a-zA-Z0-9]{6,10}$") Then        'パスワードが必ず「英文字＋数字」の仕組みであること    '^[a-zA-Z0-9]{6,10}$  ^(?=.*[0-9])(?=.*[A-Za-z])[0-9A-Za-z]{6,10}$
                MsgBox("pw形式が違う")
                txtStuPw.Focus()
            Else
                MsgBox("PWOK")
            End If


        Else
            MsgBox("パスワードを入力してください。")
        End If

    End Sub

End Class
