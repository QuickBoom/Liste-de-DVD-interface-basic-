Imports System.IO

Public Class Liste_film_windows

    Private Sub Liste_film_windows_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Dim fichier_read As StreamReader = New StreamReader("BaseDeDonnée.txt")
        Dim lignes() As String = File.ReadAllLines("BaseDeDonnée.txt")
        listedefilm.Clear()

        For a = 0 To lignes.Length - 1
            listedefilm.Add(lignes(a))
        Next
        fichier_read.Close()
        For i = 0 To listedefilm.Count - 1
            recup = listedefilm(i)
            separe2 = recup.Split("%")
            ImageList1.Images.Add(Image.FromFile(separe2(2)))
            ListView1.LargeImageList = ImageList1
            ListView1.Items.Add(separe2(0)).ImageIndex = i
        Next i
        ListView1.Sorting = SortOrder.Ascending

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fichier_read As StreamReader = New StreamReader("BaseDeDonnée.txt")
        Dim lignes() As String = File.ReadAllLines("BaseDeDonnée.txt")
        listedefilm.Clear()

        For a = 0 To lignes.Length - 1
            listedefilm.Add(lignes(a))
        Next
        fichier_read.Close()
        film_selectionner = ListView1.SelectedItems.Item(0).Text
        For i = 0 To listedefilm.Count - 1
            recup = listedefilm(i)
            separe2 = recup.Split("%")
            recherche.Add(separe2(0))
        Next
        index_choisi = recherche.IndexOf(film_selectionner)
        Choix.Show()
    End Sub
End Class