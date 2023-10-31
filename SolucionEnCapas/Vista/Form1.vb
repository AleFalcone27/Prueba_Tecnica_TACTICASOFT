Imports System.Data.SqlClient
Imports System.Globalization
Imports Datos

Public Class Form1

    Dim flag As Boolean = False
    Private estadoAnt As EEstado
    Private estado As EEstado
    Private consulta As String = ""

    Enum EEstado
        Ventas
        Cliente
        Productos
        Ventasitems
    End Enum


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        actualizarDb()

    End Sub


    ''' <summary>
    ''' Actualiza la vista según la opción que elijamos del comboBox
    ''' </summary>
    Private Sub actualizarDb()

        If flag Then
            LimpiarVista(estadoAnt)
        End If

        If ComboBox1.Text = "Ventas" Then
            Me.estado = EEstado.Ventas
            Me.consulta = Ventas.QueryAll
        ElseIf ComboBox1.Text = "Clientes" Then
            Me.estado = EEstado.Cliente
            Me.consulta = Cliente.QueryAll
        ElseIf ComboBox1.Text = "Productos" Then
            Me.estado = EEstado.Productos
            Me.consulta = Producto.QueryAll
        Else
            Me.estado = EEstado.Ventasitems
            Me.consulta = VentasItem.QueryAll
        End If



        Dim query As New Conexion
        DataGridView.DataSource = query.RealizarConsulta(Me.consulta)


        ActualizarVista(Me.estado)
        estadoAnt = estado
        flag = True
    End Sub

    ''' <summary>
    ''' Limpia los campos de texto y botones especificos de cada clase pero deja aquellos que son comunes a todas
    ''' </summary>
    ''' <param name="estadoAnt"></param>
    Private Sub LimpiarVista(estadoAnt)

        Select Case estadoAnt
            Case EEstado.Cliente
                Cliente.LimpiarVista()
            Case EEstado.Ventas
                Ventas.LimpiarVista()
            Case EEstado.Productos
                Producto.LimpiarVista()
            Case EEstado.Ventasitems
                VentasItem.LimpiarVista()
        End Select

    End Sub
    ''' <summary>
    ''' Imprime en pantalla los campos de texot, y botones especificos a cada clase
    ''' </summary>
    ''' <param name="estado"></param>
    Private Sub ActualizarVista(estado As EEstado)

        Select Case estado
            Case EEstado.Cliente
                Cliente.Vista()
            Case EEstado.Ventas
                Ventas.Vista()
            Case EEstado.Productos
                Producto.Vista()
            Case EEstado.Ventasitems
                VentasItem.Vista()

        End Select

    End Sub

    ''' <summary>
    ''' Por defecto ingresamos en la pestaña de ventas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "Ventas"
    End Sub

    ''' <summary>
    ''' Esta función contiene toda la logica referida las busquedas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click

        Dim table As String = ComboBox1.Text
        Dim num As Double
        Try
            Select Case table

                Case "Clientes"
                    If TxtSearch.Text.StartsWith("Tel-") Then
                        Me.consulta = $"SELECT Cliente,Telefono,Correo FROM clientes Where Telefono = '{TxtSearch.Text.Substring(4)}'"
                    ElseIf TxtSearch.Text.StartsWith("Correo-") Then
                        Me.consulta = $"SELECT Cliente,Telefono,Correo FROM clientes WHERE Correo = '{TxtSearch.Text.Substring(7)}'"
                    Else
                        Me.consulta = $"SELECT Cliente,Telefono,Correo FROM clientes WHERE Cliente = '{TxtSearch.Text}'"
                    End If

                Case "Productos"
                    If TxtSearch.Text.StartsWith("Cat-") Then
                        Me.consulta = $"SELECT ID,Nombre,Precio,Categoria FROM productos Where Categoria = '{TxtSearch.Text.Substring(4)}'"
                    ElseIf Double.TryParse(TxtSearch.Text.Substring(1), num) Then
                        If TxtSearch.Text.StartsWith("<") Then
                            Me.consulta = $"SELECT ID,Nombre,Precio,Categoria FROM productos Where Precio < {num}"
                        ElseIf TxtSearch.Text.StartsWith(">") Then
                            Me.consulta = $"SELECT ID,Nombre,Precio,Categoria FROM productos Where Precio > {num}"
                        Else
                            MsgBox("El precio debe ser representado en números")
                        End If
                    Else
                        Me.consulta = $"SELECT ID,Nombre,Precio,Categoria FROM productos Where ID = {TxtSearch.Text}"
                    End If

                Case "Ventas"
                    If Double.TryParse(TxtSearch.Text.Substring(1), num) Then
                        If TxtSearch.Text.StartsWith("<") Then
                            Me.consulta = $"SELECT IDCliente, Fecha, Total FROM ventas Where Total < {num}"
                        ElseIf TxtSearch.Text.StartsWith(">") Then
                            Me.consulta = $"SELECT IDCliente, Fecha, Total FROM ventas Where Total > {num}"
                        Else
                            MsgBox("Número no válido")
                        End If
                    ElseIf Double.TryParse(TxtSearch.Text, num) Then
                        Me.consulta = $"SELECT IDCliente, Fecha, Total FROM ventas Where IDCLiente = {num}"
                    End If


            End Select
        Catch ex As Exception
            MsgBox("Surgio un problema, intente otra vez")
        End Try

        Dim query As New Conexion
        DataGridView.DataSource = query.RealizarConsulta(Me.consulta)

    End Sub

    ''' <summary>
    ''' Esta funcicón tiene toda la logica referida a realizar modificaciones en los registros
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub bntModificar_Click(sender As Object, e As EventArgs) Handles bntModificar.Click

        Dim table As String = ComboBox1.Text

        Dim confirmacion As DialogResult = MessageBox.Show("¿Seguro que quieres modificar un registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacion = DialogResult.No Then

            Exit Sub

        End If

        Try
            Select Case table


                Case "Clientes"
                    If Cliente.rbtnNombre.Checked Then
                        Me.consulta = $"UPDATE clientes SET Cliente = '{Cliente.inputNombre.Text}' WHERE Cliente = '{TxtSearch.Text}'"
                    End If
                    If Cliente.rbtnTelefono.Checked Then
                        Me.consulta = $"UPDATE clientes SET Correo = '{Cliente.inputCorreo.Text}' WHERE Correo = '{TxtSearch.Text}'"
                    End If
                    If Cliente.rbtnTelefono.Checked Then
                        Me.consulta = $"UPDATE clientes SET Telefono = '{Cliente.inputTelefono.Text}' WHERE Telefono = '{TxtSearch.Text}'"
                    End If

                Case "Productos"
                    If Producto.rbtnNombre.Checked Then
                        Me.consulta = $"UPDATE productos SET Nombre = '{Producto.inputNombre.Text}' WHERE Nombre = {TxtSearch.Text}"
                    End If
                    If Producto.rbtnPrecio.Checked Then
                        Me.consulta = $"UPDATE productos SET Precio = '{Producto.inputPrecio.Text}' WHERE Precio = {TxtSearch.Text}"
                    End If
                    If Producto.rbtnCategoria.Checked Then
                        Me.consulta = $"UPDATE productos SET Categoria = '{Producto.inputCategoria.Text}' WHERE Categoria = {TxtSearch.Text}"
                    End If

                Case "VentasItems"
                    If VentasItem.rbtnIDProducto.Checked Then
                        Me.consulta = $"UPDATE ventasitems set IDProducto = {Integer.Parse(VentasItem.InputIDProducto.Text)} WHERE IDProducto = {Integer.Parse(TxtSearch.Text)}"
                    ElseIf VentasItem.rbtnCantidad.Checked Then
                        Me.consulta = $"UPDATE ventasitems set Cantidad = {Integer.Parse(VentasItem.inputCantidad.Text)} WHERE Cantidad = {Integer.Parse(TxtSearch.Text)}"
                    ElseIf VentasItem.rbtnIDVenta.Checked Then
                        Me.consulta = $"UPDATE ventasitems set IDVenta = {Integer.Parse(VentasItem.InputIDVenta.Text)} WHERE IDVenta = {Integer.Parse(TxtSearch.Text)}"
                    ElseIf VentasItem.rbtnPrecioTotal.Checked Then
                        Me.consulta = $"UPDATE ventasitems set PrecioTotal = {Integer.Parse(VentasItem.inputPrecioTotal.Text)} WHERE PrecioTotal = {Integer.Parse(TxtSearch.Text)}"
                    ElseIf VentasItem.rbtnPrecioUnitario.Checked Then
                        Me.consulta = $"UPDATE ventasitems set PrecioUnitario = {Integer.Parse(VentasItem.inputPrecioUnitario.Text)} WHERE PrecioUnitario = {Integer.Parse(TxtSearch.Text)}"
                    End If

            End Select
        Catch ex As Exception
            MsgBox("Surgio un problema, intente otra vez")
        End Try

        Dim query As New Conexion
        DataGridView.DataSource = query.RealizarConsulta(Me.consulta)
        actualizarDb()
    End Sub


    ''' <summary>
    ''' Esta funcicion encapsula toda la logica referida a la eliminacion de registros
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

        Dim table As String = ComboBox1.Text
        Dim precio As Integer

        Dim confirmacion As DialogResult = MessageBox.Show("¿Seguro que quieres eliminar un registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacion = DialogResult.No Then

            Exit Sub

        End If

        Try

            Select Case table

                Case "Clientes"
                    If Cliente.rbtnNombre.Checked Then
                        Me.consulta = $"DELETE clientes WHERE Cliente = '{Cliente.inputNombre.Text}'"
                    End If
                    If Cliente.rbtnTelefono.Checked Then
                        Me.consulta = $"DELETE clientes WHERE Corre = '{Cliente.inputCorreo.Text}'"
                    End If
                    If Cliente.rbtnTelefono.Checked Then
                        Me.consulta = $"DELETE clientes WHERE Telefono = '{Cliente.inputTelefono.Text}' "
                    End If


                Case "Productos"
                    If Producto.rbtnNombre.Checked Then
                        Me.consulta = $"DELETE productos WHERE Nombre = '{Producto.inputNombre.Text}'"
                    End If
                    If Producto.rbtnPrecio.Checked Then
                        If Integer.TryParse(Producto.inputPrecio.Text, precio) Then
                            Me.consulta = $"DELETE FROM productos WHERE Precio = {precio}"
                        Else
                            MsgBox("Error! El dato ingresado debe ser un número")
                        End If
                    End If
                    If Producto.rbtnCategoria.Checked Then
                        Me.consulta = $"DELETE productos WHERE Categoria = '{Producto.inputCategoria.Text}'"
                    End If

                Case "VentasItems"
                    If VentasItem.rbtnIDProducto.Checked Then
                        Me.consulta = $"DELETE FROM ventasitems WHERE IDProducto = {Integer.Parse(VentasItem.InputIDProducto.Text)}"
                    ElseIf VentasItem.rbtnCantidad.Checked Then
                        Me.consulta = $"DELETE FROM ventasitems WHERE Cantidad = {Integer.Parse(VentasItem.inputCantidad.Text)}"
                    ElseIf VentasItem.rbtnIDVenta.Checked Then
                        Me.consulta = $"DELETE FROM ventasitems WHERE IDVenta = {Integer.Parse(VentasItem.InputIDVenta.Text)}"
                    ElseIf VentasItem.rbtnPrecioTotal.Checked Then
                        Me.consulta = $"DELETE FROM ventasitems WHERE PrecioTotal = {Integer.Parse(VentasItem.inputPrecioTotal.Text)}"
                    ElseIf VentasItem.rbtnPrecioUnitario.Checked Then
                        Me.consulta = $"DELETE FROM ventasitems WHERE PrecioUnitario = {Integer.Parse(VentasItem.inputPrecioUnitario.Text)}"
                    End If
            End Select

        Catch ex As Exception
            MsgBox("Surgio un problema, intente otra vez")
        End Try

        Dim query As New Conexion
            DataGridView.DataSource = query.RealizarConsulta(Me.consulta)
        actualizarDb()
    End Sub

    ''' <summary>
    ''' Esta función encapsula toda aquella logica relacionada con agrega registros
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        Dim table As String = ComboBox1.Text
        'Dim total As Integer
        'Dim fechaConvertida As DateTime

        Try

            Select Case table
            'Case "Ventas"
            '    If Integer.TryParse(Ventas.inputTotal.Text, total) AndAlso DateTime.TryParseExact(Ventas.inputFecha.Text, "dd/MM/yyyy", Nothing, DateTimeStyles.None, fechaConvertida) Then
            '        Me.consulta = $"INSERT INTO Ventas (Fecha, Total) VALUES({fechaConvertida}, {total});"
            '    Else
            '        MsgBox("Los datos ingresados no coinciden con el formato")
            '    End If

                Case "Clientes"
                    Me.consulta = $"INSERT INTO clientes (Cliente, Telefono, Correo) VALUES('{Cliente.inputNombre.Text}', '{Cliente.inputTelefono.Text}', '{Cliente.inputCorreo.Text}');"

                Case "Productos"
                    Me.consulta = $"INSERT INTO productos (Nombre, Precio, Categoria) VALUES('{Producto.inputNombre.Text}', {Producto.inputPrecio.Text}, '{Producto.inputCategoria.Text}');"

                Case "VentasItems"
                    Me.consulta = $"INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES ({VentasItem.InputIDVenta.Text}, {VentasItem.InputIDProducto.Text},
                    {VentasItem.inputPrecioUnitario.Text}, {VentasItem.inputCantidad.Text}, {VentasItem.inputPrecioTotal.Text});"

            End Select

        Catch ex As Exception
            MsgBox("Surgio un problema, intente otra vez")
        End Try

        Dim query As New Conexion
        Me.DataGridView.DataSource = query.RealizarConsulta(Me.consulta)
        actualizarDb()

    End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim resultado As DialogResult = MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.No Then

            e.Cancel = True
        End If
    End Sub



End Class

