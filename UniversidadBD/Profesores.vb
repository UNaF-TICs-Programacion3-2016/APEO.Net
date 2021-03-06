﻿Imports Oracle.DataAccess.Client
Public NotInheritable Class Profesores
    Inherits Persona
    Private pMatricula As String
    Private pFechaDeIngreso As Date
    'PROPIEDADES HEREDADAS
    Friend Overrides Property Nombre As String
        Get
            Return MyBase.Nombre
        End Get
        Set(value As String)
            MyBase.Nombre = value
        End Set
    End Property
    Friend Overrides Property Apellido As String
        Get
            Return MyBase.Apellido
        End Get
        Set(value As String)
            MyBase.Apellido = value
        End Set
    End Property
    Friend Overrides Property CUIL As String
        Get
            Return MyBase.CUIL
        End Get
        Set(value As String)
            MyBase.CUIL = value
        End Set
    End Property
    Friend Overrides Property DNI As String
        Get
            Return MyBase.DNI
        End Get
        Set(value As String)
            MyBase.DNI = value
        End Set
    End Property
    Friend Overrides Property Telefono As String
        Get
            Return MyBase.Telefono
        End Get
        Set(value As String)
            MyBase.Telefono = value
        End Set
    End Property
    Friend Overrides Property Correo As String
        Get
            Return MyBase.Correo
        End Get
        Set(value As String)
            MyBase.Correo = value
        End Set
    End Property
    'PROPIEDADES ESPECIALES
    Friend Property Matricula() As String
        Get
            Return pMatricula
        End Get
        Set(ByVal value As String)
            pMatricula = value
        End Set
    End Property
    Friend Property FechaDeIngreso() As Date
        Get
            Return pFechaDeIngreso
        End Get
        Set(ByVal value As Date)
            pFechaDeIngreso = value
        End Set
    End Property
    'METODOS HEREDADOS
    'Insertar Persona
    Protected Overrides Function InsertarPersona() As String
        Return MyBase.InsertarPersona()
    End Function
    Protected Overrides Sub InsertarTelefono(ID As String)
        MyBase.InsertarTelefono(ID)
    End Sub
    Protected Overrides Sub InsertarCorreo(ID As String)
        MyBase.InsertarCorreo(ID)
    End Sub
    'Editar Persona
    Protected Overrides Sub EditarPersona(ID As String)
        MyBase.EditarPersona(ID)
    End Sub
    Protected Overrides Sub EditarTelefono(ID As String)
        MyBase.EditarTelefono(ID)
    End Sub
    Protected Overrides Sub EditarCorreo(ID As String)
        MyBase.EditarCorreo(ID)
    End Sub
    'Eliminar Persona
    Protected Overrides Sub EliminarPersona(ID As String)
        MyBase.EliminarPersona(ID)
    End Sub
    Protected Overrides Sub EliminarTelefono(ID As String)
        MyBase.EliminarTelefono(ID)
    End Sub
    Protected Overrides Sub EliminarCorreo(ID As String)
        MyBase.EliminarCorreo(ID)
    End Sub
    'INSERTAR PROFESOR
    Friend Sub InsertarProfesor()
        Dim Tabla As String = "PROFESOR"
        Dim ID As String = InsertarPersona()
        Try
            InsertarSQL(Tabla)
            Fila("PROFESOR_FECHA_INGRESO") = pFechaDeIngreso
            Fila("PROFESOR_RELA_PERSONA") = ID
            Fila("PROFESOR_MATRICULA") = pMatricula
            Insert(Tabla)
            Comando.Parameters.Clear()
            Comando.CommandText = "Insert Into Profesor VALUES(:idprofesor,:fechaingreso,:relapersona,:matricula)"
            Comando.Parameters.Add(New OracleParameter(":idprofesor", OracleDbType.Int64, 10, "ID_PROFESOR"))
            Comando.Parameters.Add(New OracleParameter(":fechaingreso", OracleDbType.Date, 0, "PROFESOR_FECHA_INGRESO"))
            Comando.Parameters.Add(New OracleParameter(":relapersona", OracleDbType.Int64, 10, "PROFESOR_RELA_PERSONA"))
            Comando.Parameters.Add(New OracleParameter(":matricula", OracleDbType.Int64, 10, "PROFESOR_MATRICULA"))
            ActualizarSQL(Tabla)
            MessageBox.Show("Los datos se guardaron correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'EDITAR PROFESOR
    Friend Sub EditarProfesor(ID As String)
        Try
            EditarPersona(ID)
            EditarTelefono(ID)
            EditarCorreo(ID)
            Comando.CommandText = "UPDATE PROFESOR SET PROFESOR_FECHA_INGRESO = '" & pFechaDeIngreso.Date & "', PROFESOR_MATRICULA = '" & pMatricula & "' WHERE PROFESOR_RELA_PERSONA = '" & ID & "'"
            Conexion.Open()
            Comando.ExecuteNonQuery()
            Conexion.Close()
            MessageBox.Show("Los datos han sido editados correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'ELIMINAR PROFESOR
    Friend Sub EliminarProfesor(ID As String)
        Try
            Comando.Connection = Conexion
            Comando.CommandText = "DELETE FROM PROFESOR WHERE PROFESOR_RELA_PERSONA = " & ID
            Conexion.Open()
            Comando.ExecuteNonQuery()
            Conexion.Close()
            EliminarTelefono(ID)
            EliminarCorreo(ID)
            EliminarPersona(ID)
            MsgBox("Los datos han sido eliminados correctamente.")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
