Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Home

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Nom.Text <> "" Then
            Name2 = Nom.Text
            Picture = "C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm\" & ComboBox1.SelectedItem
            Details = DESCRIPTION.Text
            Ajout_film = Name2 & "%" & Details & "%" & Picture
            listedefilm.Add(Ajout_film)
            Dim Fichier_write As StreamWriter = New StreamWriter("BaseDeDonnée.txt")
            For nombre_de_film = 0 To listedefilm.Count - 1
                Fichier_write.WriteLine(listedefilm(nombre_de_film))
            Next
            Fichier_write.Close()
            Nom.Clear()
            DESCRIPTION.Clear()
            MsgBox("AJOUTER !")
        Else
            MsgBox("Champs incomplet !")
        End If


    End Sub

    Private Sub Nom_TextChanged(sender As Object, e As EventArgs) Handles Nom.TextChanged

    End Sub

    Private Sub DESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles DESCRIPTION.TextChanged

    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.CreateDirectory("C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm")
        MsgBox("Placez vos images dans le dossier image de votre ordinateur dans le dossier CouvertureFilm", MsgBoxStyle.Information, "Information")
        ComboBox1.Items.Add("[aucune]")
        ComboBox1.SelectedIndex = 0
        Dim i As Integer
        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm").Count - 1
            Separe = My.Computer.FileSystem.GetFiles("C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm").Item(i).Split("\")
            If Separe(5).EndsWith(".jpg") Then ComboBox1.Items.Add(Separe(5))
        Next i
        Dim fichier_read As StreamReader = New StreamReader("BaseDeDonnée.txt")
        Dim lignes() As String = File.ReadAllLines("BaseDeDonnée.txt")
        For a = 0 To lignes.Length - 1
            listedefilm.Add(lignes(a))
        Next
        fichier_read.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Liste_film_windows.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Editer.Show()
    End Sub
End Class
