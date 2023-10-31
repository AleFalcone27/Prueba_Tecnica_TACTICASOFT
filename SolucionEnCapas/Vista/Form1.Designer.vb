<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.bntModificar = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.PruebademoDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PruebademoDataSet = New Vista.pruebademoDataSet()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(473, 24)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(483, 266)
        Me.DataGridView.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ventas", "Clientes", "Productos", "VentasItems"})
        Me.ComboBox1.Location = New System.Drawing.Point(23, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(226, 24)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(117, 22)
        Me.TxtSearch.TabIndex = 3
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(171, 24)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(49, 22)
        Me.BtnSearch.TabIndex = 4
        Me.BtnSearch.Text = "Buscar"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(12, 261)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(90, 37)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Agregar"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'bntModificar
        '
        Me.bntModificar.Location = New System.Drawing.Point(118, 261)
        Me.bntModificar.Name = "bntModificar"
        Me.bntModificar.Size = New System.Drawing.Size(90, 37)
        Me.bntModificar.TabIndex = 6
        Me.bntModificar.Text = "Modificar"
        Me.bntModificar.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(234, 261)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(90, 37)
        Me.BtnDelete.TabIndex = 7
        Me.BtnDelete.Text = "Eliminar"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'PruebademoDataSetBindingSource
        '
        Me.PruebademoDataSetBindingSource.DataSource = Me.PruebademoDataSet
        Me.PruebademoDataSetBindingSource.Position = 0
        '
        'PruebademoDataSet
        '
        Me.PruebademoDataSet.DataSetName = "pruebademoDataSet"
        Me.PruebademoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 310)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.bntModificar)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DataGridView)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PruebademoDataSetBindingSource As BindingSource
    Friend WithEvents PruebademoDataSet As pruebademoDataSet
    Friend WithEvents DataGridView As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents bntModificar As Button
    Friend WithEvents BtnDelete As Button
End Class
