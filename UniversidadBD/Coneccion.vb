﻿Imports Oracle.DataAccess.Client
Public Class Coneccion
    Protected Conexion As New OracleConnection()
    Protected Comando As New OracleCommand()
    Protected Almacenamiento As New DataSet()
    Protected Fila As DataRow
    'CONSTRUCTOR
    Sub New()
        Conexion.ConnectionString = "Data Source=localhost;" + "User Id=TPBD;" + "Password=balditofc42;"
        Almacenamiento.Tables.Clear()
        Comando.Parameters.Clear()
    End Sub
    'COMPROBAR CONEXIÓN
    Public Sub Conectarse()
        Try
            Conexion.Open()
            F_Principal.ToolStripLabel1.Text = "CONECTADO"
            Conexion.Close()
        Catch ex As Exception
            F_Principal.ToolStripLabel1.Text = "DESCONECTADO"
        End Try
    End Sub
    'COMANDOS
    'Cargar la tabla en el DataSet y crear una nueva fila
    Protected Sub InsertarSQL(Tabla As String)
        Dim Adaptador = New OracleDataAdapter("Select * From " & Tabla, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Fila = Almacenamiento.Tables(Tabla).NewRow()
    End Sub
    'Cargar los datos a la fila creada
    Protected Sub Insert(Tabla As String)
        Almacenamiento.Tables(Tabla).Rows.Add(Fila)
        Comando.Connection = Conexion
    End Sub
    'Actualizar la base de datos con la nueva fila incluida
    Protected Sub ActualizarSQL(Tabla As String)
        Dim Adaptador = New OracleDataAdapter()
        Adaptador.InsertCommand = Comando
        Adaptador.Update(Almacenamiento, Tabla)
        Almacenamiento.Tables.Clear()
    End Sub
    'CARGAR EN LOS COMBO
    Protected Sub CargarFila(Tabla As String, Columna As String, Combo As ComboBox)
        Dim Adaptador = New OracleDataAdapter("Select * From " & Tabla, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Combo.ValueMember = "ID_" & Tabla
        Combo.DataSource = Almacenamiento.Tables(Tabla)
        Combo.DisplayMember = Columna
    End Sub
    Protected Sub CargarFila(Tabla As String, Columna As String, Condicion As String, Combo As ComboBox, Referencia As ComboBox)
        Dim ID As Integer = Referencia.SelectedValue
        Dim Adaptador = New OracleDataAdapter("Select * From " & Tabla & " Where " & Condicion & " = " & ID, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Combo.ValueMember = "ID_" & Tabla
        Combo.DataSource = Almacenamiento.Tables(Tabla)
        Combo.DisplayMember = Columna
    End Sub
    Protected Sub CargarFila(Combo As ComboBox, Tabla As String, Columna As String, Valor As String, Condicion As String)
        Dim Adaptador = New OracleDataAdapter("Select * From " & Tabla & " Where " & Condicion, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Combo.ValueMember = Valor
        Combo.DataSource = Almacenamiento.Tables(Tabla)
        Combo.DisplayMember = Columna
    End Sub
    'CARGAR EN LOS COMBO, DATOS NO REPETIDOS
    Protected Sub CargarFilaSinRepetir(Combo As ComboBox, Tabla As String, Columna As String, Valor As String)
        Dim Adaptador = New OracleDataAdapter("Select Distinct " & Columna & " From " & Tabla, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Combo.ValueMember = Valor
        Combo.DataSource = Almacenamiento.Tables(Tabla)
        Combo.DisplayMember = Columna
    End Sub
    Protected Sub CargarFilaSinRepetir(Combo As ComboBox, Tabla As String, Columna As String, Valor As String, Condicion As String)
        Dim Adaptador = New OracleDataAdapter("Select Distinct " & Columna & " From " & Tabla & " Where " & Condicion, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Combo.ValueMember = Valor
        Combo.DataSource = Almacenamiento.Tables(Tabla)
        Combo.DisplayMember = Columna
    End Sub
    'CARGAR A UNA LISTA
    Protected Sub CargarLista(Tabla As String, Columna As String, Condicion As String, Lista As ListBox)
        Dim Adaptador = New OracleDataAdapter("Select * From " & Tabla & " Where " & Condicion, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Lista.DisplayMember = Columna
        Lista.DataSource = Almacenamiento.Tables(Tabla)
    End Sub
    'CARGAR A UNA LISTA, DATOS NO REPETIDOS
    Protected Sub CargarListaSinRepetir(Tabla As String, Columna As String, Condicion As String, Lista As ListBox)
        Dim Adaptador = New OracleDataAdapter("Select Distinct " & Columna & " From " & Tabla & " Where " & Condicion, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Lista.DisplayMember = Columna
        Lista.DataSource = Almacenamiento.Tables(Tabla)
    End Sub
    'CARGAR A UN DATAGRID
    Protected Sub CargarColumnas(Tabla As String, Columna As String, Condicion As String, Datos As DataGridView)
        Dim Adaptador = New OracleDataAdapter("Select " & Columna & " From " & Tabla & " Where " & Condicion, Conexion)
        Almacenamiento.Tables.Clear()
        Adaptador.Fill(Almacenamiento, Tabla)
        Datos.DataSource = Almacenamiento.Tables(Tabla)
    End Sub
End Class