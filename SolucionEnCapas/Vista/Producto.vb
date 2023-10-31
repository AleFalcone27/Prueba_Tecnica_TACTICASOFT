Imports System.IO
Public Class Producto

    Private Shared ListaControls As New List(Of Control)

    Public Shared inputNombre As New TextBox
    Public Shared inputPrecio As New TextBox
    Public Shared inputCategoria As New TextBox

    Public Shared rbtnNombre As New RadioButton
    Public Shared rbtnPrecio As New RadioButton
    Public Shared rbtnCategoria As New RadioButton
    Public Shared ListadoDeProductos As New Button


    Private Shared ruta As String = "C:\Users\aleef\OneDrive\Escritorio\Prueba Tecnica TACTICASOFT"

    Private Shared query1 As String = "SELECT ID,Nombre,Precio,Categoria FROM productos"

    Public Sub New()
        Vista()
    End Sub

    Public Shared Sub LimpiarVista()
        For Each control In ListaControls
            Form1.Controls.Remove(control)
        Next
    End Sub


    Public Shared ReadOnly Property QueryAll As String
        Get
            Return query1
        End Get
    End Property


    Public Shared Sub Vista()

        Dim x As Integer = 120
        Dim y As Integer = 100

        Dim labelNombre As New Label
        labelNombre.Text = "Nombre"
        labelNombre.Location = New Point(20, y)
        inputNombre.Location = New Point(x, y)
        rbtnNombre.Location = New Point(x + 130, y)
        ListaControls.Add(inputNombre)
        ListaControls.Add(labelNombre)
        ListaControls.Add(rbtnNombre)


        Dim labelPrecio As New Label
        labelPrecio.Text = "Precio"
        labelPrecio.Location = New Point(20, y + 40)
        inputPrecio.Location = New Point(x, y + 40)
        rbtnPrecio.Location = New Point(x + 130, y + 40)
        ListaControls.Add(inputPrecio)
        ListaControls.Add(labelPrecio)
        ListaControls.Add(rbtnPrecio)


        Dim labelCategoria As New Label
        labelCategoria.Text = "Categoria"
        labelCategoria.Location = New Point(20, y + 80)
        inputCategoria.Location = New Point(x, y + 80)
        rbtnCategoria.Location = New Point(x + 130, y + 80)
        ListaControls.Add(inputCategoria)
        ListaControls.Add(labelCategoria)
        ListaControls.Add(rbtnCategoria)


        ListadoDeProductos.Location = New Point(350, 260)
        ListadoDeProductos.Width = 90
        ListadoDeProductos.Height = 37
        ListadoDeProductos.Text = "Lista de Productos"
        ListaControls.Add(ListadoDeProductos)
        AddHandler ListadoDeProductos.Click, AddressOf GetListadoDeProductos

        For Each control In ListaControls
            Form1.Controls.Add(control)
        Next

    End Sub

    Public Shared Sub GetListadoDeProductos(sender As Object, e As EventArgs)

        Dim fs As FileStream
        Dim archivo As String = "ListadoDeProductos.txt"

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
            MsgBox("Hubo un problema al momento de crear el archivo, revise la ruta en Producto.vb")
        End Try


        Dim tabla As New DataTable

        Dim query As New Datos.Conexion
        tabla = query.RealizarConsulta("SELECT * FROM productos")

        Using escribir As New StreamWriter(Path.Combine(ruta, archivo))
            For Each fila As DataRow In tabla.Rows
                Dim id As Integer = Convert.ToInt32(fila("ID"))
                Dim nombreProducto As String = fila("Nombre").ToString()
                Dim precio As Double = Convert.ToDouble(fila("Precio"))
                Dim categoria As String = fila("Categoria").ToString()

                Dim linea As String = $"ID: {id} - Nombre del producto: {nombreProducto} - Precio: {precio} - Categoría: {categoria}"
                escribir.WriteLine(linea)
            Next
        End Using

    End Sub


End Class
