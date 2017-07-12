Imports System.IO

Public Class Editer
    Private Sub Editer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Dim fichier_read As StreamReader = New StreamReader("BaseDeDonnée.txt")
        Dim lignes() As String = File.ReadAllLines("BaseDeDonnée.txt")
        For a = 1 To lignes.Length - 1
            Me.DataGridView1.Rows.Add(" ")
        Next
        For a = 0 To lignes.Length - 1
            recup = lignes(a)
            separe2 = recup.Split("%")
            recup2 = separe2(2).Split("\")
            Separe3 = recup2(5)
            Me.DataGridView1.Rows(a).Cells(0).Value = separe2(0)
            Me.DataGridView1.Rows(a).Cells(1).Value = separe2(1)
            Me.DataGridView1.Rows(a).Cells(2).Value = Separe3
        Next
        fichier_read.Close()

        For i = 0 To DataGridView1.Rows.Count - 1
            edit.Add(DataGridView1.Rows(i).Cells(0).Value & "%" & DataGridView1.Rows(i).Cells(1).Value & "%" & "C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm\" & DataGridView1.Rows(i).Cells(2).Value)
            recup = edit(i)
            separe2 = recup.Split("%")
            ComboBox1.Items.Add(separe2(0))
        Next

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        edit.Clear()
        For i = 0 To DataGridView1.Rows.Count - 1
            edit.Add(DataGridView1.Rows(i).Cells(0).Value & "%" & DataGridView1.Rows(i).Cells(1).Value & "%" & "C:\Users\" & Environment.UserName & "\Pictures\CouvertureFilm\" & DataGridView1.Rows(i).Cells(2).Value)
        Next
        error_tab = edit.IndexOf("%%C:\Users\admin\Pictures\CouvertureFilm\")
        edit.RemoveAt(error_tab)
        Dim Fichier_write As StreamWriter = New StreamWriter("BaseDeDonnée.txt")
        For nombre_de_film = 0 To edit.Count - 1
            Fichier_write.WriteLine(edit(nombre_de_film))

        Next
        Fichier_write.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        edit.RemoveAt(supp)
        ComboBox1.Items.Clear()
        Dim Fichier_write As StreamWriter = New StreamWriter("BaseDeDonnée.txt")
        For nombre_de_film = 0 To edit.Count - 1
            Fichier_write.WriteLine(edit(nombre_de_film))
            recup = edit(nombre_de_film)
            separe2 = recup.Split("%")
            ComboBox1.Items.Add(separe2(0))
        Next
        Fichier_write.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button2.Enabled = True
        supp = ComboBox1.SelectedIndex
    End Sub
End Class