﻿Imports Oracle.DataAccess.Client
Public NotInheritable Class Alumnos
    Inherits Persona
    Private pNumeroDeLegajo As String
    Private pFechaDeIngreso As Date
    Private pCarrera As String
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
    Friend Property NumeroDeLegajo() As String
        Get
            Return pNumeroDeLegajo
        End Get
        Set(ByVal value As String)
            pNumeroDeLegajo = value
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
    Friend Property Carrera() As String
        Get
            Return pCarrera
        End Get
        Set(value As String)
            pCarrera = value
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
    Protected Overrides Sub EditarCorreo(ID As String)
        MyBase.EditarCorreo(ID)
    End Sub
    Protected Overrides Sub EditarTelefono(ID As String)
        MyBase.EditarTelefono(ID)
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
    'INSERTAR ALUMNO
    Friend Sub InsertarAlumno()
        Dim Tabla As String = "ALUMNO"
        Dim ID As String = InsertarPersona()
        Try
            InsertarSQL(Tabla)
            Fila("ALUMNO_NUMERO_LEGAJO") = pNumeroDeLegajo
            Fila("ALUMNO_FECHA_INGRESO") = pFechaDeIngreso
            Fila("ALUMNO_RELA_PERSONA") = ID
            Insert(Tabla)
            Comando.Parameters.Clear()
            Comando.CommandText = "Insert Into Alumno VALUES(:idalumno,:numerolegajo,:fechaingreso,:relapersona) RETURNING id_Alumno INTO :Last_id"
            Comando.Parameters.Add(New OracleParameter(":idalumno", OracleDbType.Int64, 10, "ID_ALUMNO"))
            Comando.Parameters.Add(New OracleParameter(":numerolegajo", OracleDbType.Int64, 10, "ALUMNO_NUMERO_LEGAJO"))
            Comando.Parameters.Add(New OracleParameter(":fechaingreso", OracleDbType.Date, 0, "ALUMNO_FECHA_INGRESO"))
            Comando.Parameters.Add(New OracleParameter(":relapersona", OracleDbType.Int64, 10, "ALUMNO_RELA_PERSONA"))
            Comando.Parameters.Add(New OracleParameter(":Last_id", OracleDbType.Int32, ParameterDirection.ReturnValue))
            ActualizarSQL(Tabla)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ID = (Comando.Parameters(":Last_id").Value).ToString
            Tabla = "ALUMNO_CARRERA"
            InsertarSQL(Tabla)
            Fila("ALU_CARRE_RELA_ALUMNO") = ID
            Fila("ALU_CARRE_RELA_CARRERA") = pCarrera
            Insert(Tabla)
            Comando.Parameters.Clear()
            Comando.CommandText = "Insert Into Alumno_Carrera VALUES(:idalucarre,:relaalumno,:relacarrera)"
            Comando.Parameters.Add(New OracleParameter(":idalucarre", OracleDbType.Int64, 10, "ID_ALUMNO_CARRERA"))
            Comando.Parameters.Add(New OracleParameter(":relaalumno", OracleDbType.Int64, 10, "ALU_CARRE_RELA_ALUMNO"))
            Comando.Parameters.Add(New OracleParameter(":relacarrera", OracleDbType.Int64, 10, "ALU_CARRE_RELA_CARRERA"))
            ActualizarSQL(Tabla)
            MessageBox.Show("Los datos se guardaron correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'EDITAR ALUMNO
    Friend Sub EditarAlumno(ID As String)
        Try
            EditarPersona(ID)
            EditarTelefono(ID)
            EditarCorreo(ID)
            Comando.CommandText = "UPDATE ALUMNO SET ALUMNO_FECHA_INGRESO = '" & pFechaDeIngreso.Date & "', ALUMNO_NUMERO_LEGAJO = '" & pNumeroDeLegajo & "' WHERE ALUMNO_RELA_PERSONA = '" & ID & "'"
            Conexion.Open()
            Comando.ExecuteNonQuery()
            Conexion.Close()
            MessageBox.Show("Los datos han sido editados correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'ELIMINAR ALUMNO Y SU INSCRIPCIÓN
    Friend Sub EliminarInscripcion(ID As String)
        Try
            Comando.Connection = Conexion
            Comando.CommandText = "DELETE FROM ALUMNO_CARRERA WHERE ALU_CARRE_RELA_ALUMNO = " & ID
            Conexion.Open()
            Comando.ExecuteNonQuery()
            Conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Friend Sub EliminarAlumno(ID As String)
        Try
            Comando.Connection = Conexion
            Comando.CommandText = "DELETE FROM ALUMNO WHERE ALUMNO_RELA_PERSONA = " & ID
            Conexion.Open()
            Comando.ExecuteNonQuery()
            Conexion.Close()
            EliminarTelefono(ID)
            EliminarCorreo(ID)
            EliminarPersona(ID)
            MessageBox.Show("Los datos han sido eliminados correctamente")
        Catch ex As Exception
            MessageBox.Show("No se puede realizar la acción, primero elimine las dependencias de esta entidad.", "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
