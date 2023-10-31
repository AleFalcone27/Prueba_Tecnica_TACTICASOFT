Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Imports System.Windows.Forms



Public Class Conexion
    Public Function RealizarConsulta(query As String) As DataTable
        Dim dataTable As New DataTable()

        Using conexion As New SqlConnection("Data Source=ALE;Initial Catalog=pruebademo;Integrated Security=True")
            Try
                conexion.Open()
                Dim adaptador As New SqlDataAdapter(query, conexion)
                adaptador.Fill(dataTable)
            Catch ex As Exception
                MsgBox("Error, no se pudo realizar la consulta")
            End Try
        End Using

        Return dataTable
    End Function

End Class



