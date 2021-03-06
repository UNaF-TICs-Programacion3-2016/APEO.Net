﻿Imports Oracle.DataAccess.Client
Public Class Configuracion
    Inherits Coneccion
    'CONFIGURACIÓN DE INTERFAZ
    Public Shared Sub EstablecerConfiguracion(Formulario As Form, Panel As Panel, Pestañas As TabControl)
        With Formulario
            .Width = 587
            .Height = 485
            .BackColor = Color.DeepSkyBlue
        End With
        With Panel
            .Width = 532
            .Height = 390
            .Top = 6
            .Left = 6
            .BackColor = Color.WhiteSmoke
        End With
        With Pestañas
            .Width = 552
            .Height = 428
        End With
        Formulario.Show()
        Panel.Visible = True
    End Sub
    Public Shared Sub EstablecerPanel(Panel As Panel)
        With Panel
            .Left = 0
            .Top = 64
            .Width = 1100
            .Height = 505
            .Visible = True
            .BackColor = Color.PaleTurquoise
            .BorderStyle = BorderStyle.FixedSingle
        End With
    End Sub
    'CARGAR DATOS AL COMBO
    Sub CargarComboBox(Combo As ComboBox, Panel As Panel, Tabla As String, Columna As String)
        If Panel.Visible = True Then
            Try
                CargarFila(Tabla, Tabla & "_" & Columna, Combo)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Sub CargarComboBox(Combo As ComboBox, Panel As Panel, Tabla As String, Columna As String, Condicion As String, Referencia As ComboBox)
        If Panel.Visible = True Then
            Try
                CargarFila(Tabla, Tabla & "_" & Columna, Tabla & "_" & Condicion, Combo, Referencia)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Sub CargarComboBox(Combo As ComboBox, Panel As Panel, Tabla As String, Columna As String, Valor As String, Condicion As String)
        If Panel.Visible = True Then
            Try
                CargarFila(Combo, Tabla, Columna, Valor, Condicion)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'CARGAR DATOS AL COMBO, SIN QUE SE REPITAN
    Sub EliminarRepetidos(Combo As ComboBox, Panel As Panel, Tabla As String, Columna As String, Valor As String)
        If Panel.Visible = True Then
            Try
                CargarFilaSinRepetir(Combo, Tabla, Columna, Valor)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Sub EliminarRepetidos(Combo As ComboBox, Panel As Panel, Tabla As String, Columna As String, Valor As String, Condicion As String)
        If Panel.Visible = True Then
            Try
                CargarFilaSinRepetir(Combo, Tabla, Columna, Valor, Condicion)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'CARGAR DATOS A UNA LISTA
    Sub CargarListBox(Lista As ListBox, Panel As Panel, Tabla As String, Columna As String, Condicion As String)
        If Panel.Visible = True Then
            Try
                CargarLista(Tabla, Columna, Condicion, Lista)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'CARGAR DATOS A UNA LISTA, SIN QUE SE REPITAN
    Sub EliminarRepetidos(Lista As ListBox, Panel As Panel, Tabla As String, Columna As String, Condicion As String)
        If Panel.Visible = True Then
            Try
                CargarListaSinRepetir(Tabla, Columna, Condicion, Lista)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'CARGAR DATOS AL DATAGRID
    Sub CargarDGV(Datos As DataGridView, Panel As Panel, Tabla As String, Columna As String, Condicion As String)
        If Panel.Visible = True Then
            Try
                CargarColumnas(Tabla, Columna, Condicion, Datos)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
