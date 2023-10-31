Imports System.IO
Public Class Ventas

    Private Shared ListaControls As New List(Of Control)
    Private Shared query1 As String = "SELECT IDCliente, Fecha, Total FROM ventas"

    Shared ruta As String = "C:\Users\aleef\OneDrive\Escritorio\Prueba Tecnica TACTICASOFT"

    Public Shared inputFecha As New TextBox
    Public Shared inputTotal As New TextBox
    Public Shared btnReporteVentas As New Button

    Public Sub New()
        Vista()
    End Sub


    Public Shared ReadOnly Property QueryAll As String
        Get
            Return query1
        End Get
    End Property


    Public Shared Sub LimpiarVista()
        For Each control In ListaControls
            Form1.Controls.Remove(control)
        Next
    End Sub


    Public Shared Sub Vista()

        Dim x As Integer = 100
        Dim y As Integer = 100

        Dim labelFecha As New Label
        labelFecha.Text = "Fecha"
        inputFecha.Location = New Point(x + 20, y)
        labelFecha.Location = New Point(20, y)
        ListaControls.Add(labelFecha)
        ListaControls.Add(inputFecha)


        Dim labelTotal As New Label
        labelTotal.Text = "Total"
        inputTotal.Location = New Point(x + 20, y + 40)
        labelTotal.Location = New Point(20, y + 40)
        ListaControls.Add(inputTotal)
        ListaControls.Add(labelTotal)


        btnReporteVentas.Location = New Point(350, 260)
        btnReporteVentas.Width = 90
        btnReporteVentas.Height = 37
        btnReporteVentas.Text = "Reporte de Ventas"
        ListaControls.Add(btnReporteVentas)
        AddHandler btnReporteVentas.Click, AddressOf GetReporteVEntas

        For Each control In ListaControls
            Form1.Controls.Add(control)
        Next

    End Sub

    Public Shared Sub GetReporteVEntas(sender As Object, e As EventArgs)
        Dim fs As FileStream
        Dim archivo As String = "ReporteDeVentas.txt"

        Try
            If File.Exists(ruta) Then
                fs = File.Create(ruta & archivo)
                fs.Close()
                MsgBox("El archivo creo correctamente")
            Else
                Directory.CreateDirectory(ruta)
                fs = File.Create(ruta & archivo)
                fs.Close()
                MsgBox("El archivo y ruta creados correctamente")
            End If
        Catch ex As Exception
            MsgBox("Hubo un problema al momento de crear el archivo, revise la ruta en Ventas.Vb")
        End Try


        Dim tabla As New DataTable

        Dim query As New Datos.Conexion
        tabla = query.RealizarConsulta("SELECT * FROM ventas")

        Using escribir As New StreamWriter(Path.Combine(ruta, archivo))
            For Each fila As DataRow In tabla.Rows
                Dim idCliente As Integer = Convert.ToInt32(fila("IDCliente"))
                Dim Fecha As String = fila("Fecha").ToString()
                Dim Total As Double = Convert.ToDouble(fila("Total"))

                Dim linea As String = $"IDCliente: {idCliente} - Fecha: {Fecha} - Total: {Total}"
                escribir.WriteLine(linea)
            Next
        End Using

    End Sub
End Class
