Imports System.Data.SqlClient
Imports Conexion
Public Class VentasItem

    Private Shared ListaControls As New List(Of Control)
    Public Shared query1 As String = "SELECT IDVEnta, IDProducto, PrecioUnitario, PrecioTotal, Cantidad FROM ventasitems"

    Public Shared totalGeneral As New Button
    Public Shared inputPrecioUnitario As New TextBox
    Public Shared inputCantidad As New TextBox
    Public Shared inputPrecioTotal As New TextBox
    Public Shared InputIDVenta As New TextBox
    Public Shared InputIDProducto As New TextBox


    Public Shared rbtnPrecioUnitario As New RadioButton
    Public Shared rbtnCantidad As New RadioButton
    Public Shared rbtnPrecioTotal As New RadioButton
    Public Shared rbtnIDVenta As New RadioButton
    Public Shared rbtnIDProducto As New RadioButton


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


        Dim LabelIdProducto As New Label
        LabelIdProducto.Text = "ID Producto"
        LabelIdProducto.Location = New Point(20, y - 40)
        InputIDProducto.Location = New Point(x + 20, y - 40)
        rbtnIDProducto.Location = New Point(x + 130, y - 40)
        ListaControls.Add(InputIDProducto)
        ListaControls.Add(LabelIdProducto)
        ListaControls.Add(rbtnIDProducto)


        Dim labelPrecioUnitario As New Label
        labelPrecioUnitario.Text = "Precio Unitario"
        labelPrecioUnitario.Location = New Point(20, y)
        inputPrecioUnitario.Location = New Point(x + 20, y)
        rbtnPrecioUnitario.Location = New Point(x + 130, y)
        ListaControls.Add(inputPrecioUnitario)
        ListaControls.Add(labelPrecioUnitario)
        ListaControls.Add(rbtnPrecioUnitario)


        Dim labelCAntidad As New Label
        labelCAntidad.Text = "Cantidad"
        labelCAntidad.Location = New Point(20, y + 40)
        inputCantidad.Location = New Point(x + 20, y + 40)
        rbtnCantidad.Location = New Point(x + 130, y + 40)
        ListaControls.Add(inputCantidad)
        ListaControls.Add(labelCAntidad)
        ListaControls.Add(rbtnCantidad)


        Dim labelPrecioTotal As New Label
        labelPrecioTotal.Text = "Precio Total"
        labelPrecioTotal.Location = New Point(20, y + 80)
        inputPrecioTotal.Location = New Point(x + 20, y + 80)
        rbtnPrecioTotal.Location = New Point(x + 130, y + 80)
        ListaControls.Add(inputPrecioTotal)
        ListaControls.Add(labelPrecioTotal)
        ListaControls.Add(rbtnPrecioTotal)


        Dim LabelIdVenta As New Label
        LabelIdVenta.Text = "ID Ventas"
        LabelIdVenta.Location = New Point(20, y + 120)
        InputIDVenta.Location = New Point(x + 20, y + 120)
        rbtnIDVenta.Location = New Point(x + 130, y + 120)
        ListaControls.Add(InputIDVenta)
        ListaControls.Add(LabelIdVenta)
        ListaControls.Add(rbtnIDVenta)


        totalGeneral.Location = New Point(350, 260)
        totalGeneral.Width = 90
        totalGeneral.Height = 37
        totalGeneral.Text = "Total ventas"
        ListaControls.Add(totalGeneral)
        AddHandler totalGeneral.Click, AddressOf GetTotalVentas


        For Each control In ListaControls
            Form1.Controls.Add(control)
        Next

    End Sub

    Public Shared Sub GetTotalVentas(sender As Object, e As EventArgs)
        Dim query As New Datos.Conexion
        Form1.DataGridView.DataSource = query.RealizarConsulta("SELECT SUM(PrecioTotal) AS TotalVentas FROM ventasitems")
    End Sub


End Class
