Public Class Choix
    Private Sub Choix_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recup = listedefilm(index_choisi)
        separe2 = recup.Split("%")

        Nom_film.Text = separe2(0)
        RichTextBox1.Text = separe2(1)
        PictureBox1.ImageLocation = separe2(2)
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class