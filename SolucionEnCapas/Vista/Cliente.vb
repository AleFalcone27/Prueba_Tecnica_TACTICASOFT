
Partial Public Class Cliente

    Private Shared ListaControls As New List(Of Control)
    Private Shared query1 As String = "SELECT ID,Cliente,Telefono,Correo FROM clientes"

    Public Shared inputNombre As New TextBox
    Public Shared inputTelefono As New TextBox
    Public Shared inputCorreo As New TextBox
    Public Shared rbtnNombre As New RadioButton
    Public Shared rbtnTelefono As New RadioButton
    Public Shared rbtnCorreo As New RadioButton

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

        Dim x As Integer = 100
        Dim y As Integer = 100

        Dim labelNombre As New Label
        labelNombre.Text = "Nombre"
        labelNombre.Location = New Point(20, y)
        inputNombre.Location = New Point(x + 20, y)
        rbtnNombre.Location = New Point(x + 130, y)
        ListaControls.Add(inputNombre)
        ListaControls.Add(labelNombre)
        ListaControls.Add(rbtnNombre)


        Dim labelTelefono As New Label
        labelTelefono.Text = "Telefono"
        labelTelefono.Location = New Point(20, y + 40)
        inputTelefono.Location = New Point(x + 20, y + 40)
        rbtnTelefono.Location = New Point(x + 130, y + 40)
        ListaControls.Add(inputTelefono)
        ListaControls.Add(labelTelefono)
        ListaControls.Add(rbtnTelefono)


        Dim labelCorreo As New Label
        labelCorreo.Text = "Correo"
        labelCorreo.Location = New Point(20, y + 80)
        inputCorreo.Location = New Point(x + 20, y + 80)
        rbtnCorreo.Location = New Point(x + 130, y + 80)
        ListaControls.Add(inputCorreo)
        ListaControls.Add(labelCorreo)
        ListaControls.Add(rbtnCorreo)




        For Each control In ListaControls
            Form1.Controls.Add(control)
        Next

    End Sub


End Class

