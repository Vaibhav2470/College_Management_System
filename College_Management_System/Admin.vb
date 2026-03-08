Imports Microsoft.Data.SqlClient
Public Class Admin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Home_Page.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Con As SqlConnection = New SqlConnection
        Dim Command As New SqlCommand
        Con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=login;Integrated Security=True"
        Try
            Command.Connection = Con
            'Dim stmt As String = "select * from Admin_Table where AdminId ='" & TextBox1.Text & "' AND AdminPassword ='" & TextBox2.Text & "'"
            'Command.CommandText = stmt
            Dim stmt As String = "SELECT * FROM Admin_Table WHERE AdminID=@AdminID AND AdminPassword=@AdminPassword"
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class