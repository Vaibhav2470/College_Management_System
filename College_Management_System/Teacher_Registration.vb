Imports Microsoft.Data.SqlClient

Public Class Teacher_Registration
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Admin_Dashboard.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Con As SqlConnection = New SqlConnection
        Dim Command As New SqlCommand
        Con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=login;Integrated Security=True"
        Try
            Command.Connection = Con
            Dim stmt As String = "SELECT * FROM Teacher_Table WHERE TeacherID=@TeacherID,  AND AdminPassword=@AdminPassword"
            Command.CommandText = stmt
            Command.Parameters.AddWithValue("@AdminID", TextBox1.Text)
            Command.Parameters.AddWithValue("@AdminPassword", TextBox2.Text)
            Con.Open()
            Dim reader As SqlDataReader = Command.ExecuteReader
            If reader.Read Then
                MessageBox.Show("Login Successful")
                Me.Hide()
                Admin_Dashboard.Show()
                TextBox1.Clear()
                TextBox2.Clear()
            Else
                MessageBox.Show("Invalid Username OR Password!")
                Me.Show()
                TextBox1.Clear()
                TextBox2.Clear()
            End If
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
End Class