﻿Imports Oracle.DataAccess.Client
Public Class F_Secundario
    Public Facultad As New Facultad()
    Public Carrera As New Carrera()
    Public Materia As New Materia()
    Public Examen As New Examen()
    Private oConeccion As New Coneccion()
    Public Alumno As New Alumnos()
    Public Profesor As New Profesores()
    Public Persona As New Persona()
    Public oAula As New Aula()
    Public Curso As New Cursos()
    Public Otro As New Otros()
    Private oConfiguracion As New Configuracion()
    'FORM
    Private Sub F_Secundario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RDB_A_FinalExamenFinal.Checked = True
    End Sub
    'CLICK PARA SIGUIENTE PANEL
    Private Sub BTN_E_CursoSiguiente_Click(sender As Object, e As EventArgs) Handles BTN_E_CursoSiguiente.Click
        PNL_E_Curso.Visible = False
        oConfiguracion.EstablecerConfiguracion(Me, PNL_E_Curso2, TabControl1)
    End Sub
    Private Sub BTN_A_EditarCorrelativasMateria_Click(sender As Object, e As EventArgs) Handles BTN_A_EditarCorrelativasMateria.Click
        PNL_A_Materia.Visible = False
        oConfiguracion.EstablecerConfiguracion(Me, PNL_A_Correlativa, TabControl1)
    End Sub
    Private Sub BTN_A_AlumnoSiguiente_Click_1(sender As Object, e As EventArgs) Handles BTN_A_AlumnoSiguiente.Click
        PNL_A_Alumno.Visible = False
        oConfiguracion.EstablecerConfiguracion(Me, PNL_A_Alumno2, TabControl1)
    End Sub
    'CLICK PARA ACEPTAR
    Private Sub BTN_A_FacultadAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_FacultadAceptar.Click
        Facultad.Codigo = TXT_A_CodigoFacultad.Text
        Facultad.Descripcion = TXT_A_DescripcionFacultad.Text
        Facultad.InsertarFacultad()
        Me.Close()
    End Sub
    Private Sub BTN_A_CorrelativaAceptar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub BTN_A_CarreraAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_CarreraAceptar.Click
        Carrera.Codigo = TXT_A_CodigoCarrera.Text
        Carrera.Descripcion = TXT_A_DescripcionCarrera.Text
        Carrera.Duracion = TXT_A_DuracionCarrera.Text
        Carrera.InsertarCarrera()
        Me.Close()
    End Sub
    Private Sub BTN_A_MateriaSiguiente_Click(sender As Object, e As EventArgs) Handles BTN_A_MateriaSiguiente.Click
        Materia.Codigo = TXT_A_CodigoMateria.Text
        Materia.Descripcion = TXT_A_DescripcionMateria.Text
        Materia.InsertarMateria()
        Me.Close()
    End Sub
    Private Sub BTN_A_MateriaAgregar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_MateriaAgregar.Click
        Materia.RelacionarCorrelativa()
    End Sub
    Private Sub BTN_A_ProfesorSiguiente_Click_1(sender As Object, e As EventArgs) Handles BTN_A_ProfesorSiguiente.Click
        Persona.Nombre = TXT_A_NombreProfesor.Text
        Persona.Apellido = TXT_A_ApellidoProfesor.Text
        Persona.CUIL = TXT_A_CUILProfesor.Text
        Persona.DNI = TXT_A_DNIProfesor.Text
        Persona.Telefono = TXT_A_TelefonoProfesor.Text
        Persona.Correo = TXT_A_CorreoProfesor.Text
        Profesor.FechaDeIngreso = DTP_A_FechaIngresoProfesor.Value
        Profesor.Matricula = TXT_A_MatriculaProfesor.Text
        Profesor.InsertarProfesor()
        Me.Close()
    End Sub
    Private Sub BTN_A_AulaAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_AulaAceptar.Click
        oAula.Codigo = TXT_A_CodigoAula.Text
        oAula.Descripcion = TXT_A_DescripcionAula.Text
        oAula.InsertarAula()
        Me.Close()
    End Sub
    Private Sub BTN_A_AlumnoAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_AlumnoAceptar.Click
        Persona.Nombre = TXT_A_NombreAlumno.Text
        Persona.Apellido = TXT_A_ApellidoAlumno.Text
        Persona.CUIL = TXT_A_CUILAlumno.Text
        Persona.DNI = TXT_A_DNIAlumno.Text
        Persona.Telefono = TXT_A_TelefonoAlumno.Text
        Persona.Correo = TXT_A_CorreoAlumno.Text
        Alumno.FechaDeIngreso = DTP_A_FechaIngresoAlumno.Value
        Alumno.NumeroDeLegajo = TXT_A_NumeroLegajoAlumno.Text
        Alumno.InsertarAlumno()
        Me.Close()
    End Sub
    Private Sub BTN_A_OtroAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_OtroAceptar.Click
        Persona.Nombre = TXT_A_NombreOtro.Text
        Persona.Apellido = TXT_A_ApellidoOtro.Text
        Persona.CUIL = TXT_A_CUILOtro.Text
        Persona.DNI = TXT_A_DNIOtro.Text
        Persona.Correo = TXT_A_CorreoOtro.Text
        Persona.Telefono = TXT_A_TelefonoOtro.Text
        Otro.FechaDeIngreso = DTP_A_FechaIngresoOtro.Value
        Otro.InsertarOtro()
        Me.Close()
    End Sub
    Private Sub BTN_A_ExamenFinalAceptar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_ExamenFinalAceptar.Click
        Examen.Fecha = DTP_A_FechaExamenFinal.Value.Date
        Examen.Tipo = RDB_A_FinalExamenFinal.Checked
        Examen.Hora = CMB_A_HoraExamen.SelectedValue
        Examen.Minuto = CMB_A_MinutoExamen.SelectedValue
        Examen.InsertarExamen()
    End Sub
    Private Sub BTN_A_ExamenAgregar_Click(sender As Object, e As EventArgs) Handles BTN_A_ExamenAgregar.Click
        Examen.InsertarProfesorExamen()
    End Sub
    Private Sub BTN_A_CursoAgregar_Click(sender As Object, e As EventArgs) Handles BTN_A_CursoAgregar.Click
        Curso.Comision = TXT_A_ComisionCurso.Text
        Curso.InsertarCurso()
    End Sub
    Private Sub BTN_A_AgregarProfesorCurso_Click(sender As Object, e As EventArgs) Handles BTN_A_AgregarProfesorCurso.Click
        Curso.InsertarProfesorCurso()
    End Sub
    Private Sub BTN_A_ExamenBuscar_Click(sender As Object, e As EventArgs) Handles BTN_A_ExamenBuscar.Click
        Dim DNI As String = TXT_BuscarExamen.Text
        Dim ID As String = CMB_A_AlumnoExamen.SelectedValue
        oConfiguracion.CargarComboEspecifico(CMB_A_AlumnoExamen, PNL_A_Inscripcion, "PERSONA, ALUMNO", "PERSONA_APELLIDO", "ID_ALUMNO", "PERSONA_DNI = " & DNI & " AND ID_PERSONA = ALUMNO_RELA_PERSONA")
    End Sub
    Private Sub BTN_A_ExamenAceptar_Click(sender As Object, e As EventArgs) Handles BTN_A_ExamenAceptar.Click
        Examen.InscripcionExamen()
        Me.Close()
    End Sub
    Private Sub BTN_E_FacultadAceptar_Click(sender As Object, e As EventArgs) Handles BTN_E_FacultadAceptar.Click
        Facultad.Codigo = TXT_E_CodigoFacultad.Text
        Facultad.Descripcion = TXT_E_DescripcionFacultad.Text
        Facultad.EditarFacultad()
    End Sub
    Private Sub BTN_A_BuscarIC_Click(sender As Object, e As EventArgs) Handles BTN_A_BuscarIC.Click
        Dim DNI As String = TXT_A_BuscarIC.Text
        Dim ID As String = CMB_A_AlumnoIC.SelectedValue
        oConfiguracion.CargarComboEspecifico(CMB_A_AlumnoIC, PNL_A_InscripcionCursadas, "PERSONA, ALUMNO", "PERSONA_APELLIDO", "ID_ALUMNO", "PERSONA_DNI = " & DNI & " AND ID_PERSONA = ALUMNO_RELA_PERSONA")
    End Sub
    Private Sub BTN_A_InscribirIC_Click(sender As Object, e As EventArgs) Handles BTN_A_InscribirIC.Click
        Curso.InsertarAlumnoCurso()
        Me.Close()
    End Sub
    Private Sub BTN_E_CarreraAceptar_Click(sender As Object, e As EventArgs) Handles BTN_E_CarreraAceptar.Click
        Carrera.Descripcion = TXT_E_DescripcionCarrera.Text
        Carrera.Duracion = TXT_E_DuracionCarrera.Text
        Carrera.Codigo = TXT_E_CodigoCarrera.Text
        Carrera.EditarCarrera()
    End Sub

    Private Sub BTN_E_AulaAceptar_Click(sender As Object, e As EventArgs) Handles BTN_E_AulaAceptar.Click
        oAula.Descripcion = TXT_E_DescripcionAula.Text
        oAula.EditarAula()
    End Sub
    Private Sub BTN_S_FacultadBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_FacultadBorrar.Click
        Facultad.EliminarFacultad()
        Me.Close()
    End Sub
    Private Sub BTN_S_CarreraBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_CarreraBorrar.Click
        Carrera.EliminarCarrera()
    End Sub
    Private Sub BTN_S_AlumnoBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_AlumnoBorrar.Click
        Alumno.EliminarAlumno()
    End Sub

    Private Sub BTN_S_OtroEliminar_Click(sender As Object, e As EventArgs) Handles BTN_S_OtroEliminar.Click
        Otro.EliminarOtro()
    End Sub
    Private Sub BTN_S_MateriaBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_MateriaBorrar.Click
        Materia.EliminarMateria()
    End Sub
    Private Sub BTN_S_ExamenFinalBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_ExamenFinalBorrar.Click
        Examen.EliminarExamen()
    End Sub
    Private Sub BTN_S_AulaBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_AulaBorrar.Click
        oAula.EliminarAula()
    End Sub
    Private Sub BTN_S_CursoBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_CursoBorrar.Click
        Curso.EliminarCurso()
    End Sub
    Private Sub BTN_S_ProfesorBorrar_Click(sender As Object, e As EventArgs) Handles BTN_S_ProfesorBorrar.Click
        Profesor.EliminarProfesor()
    End Sub

    'PANELES
    Private Sub PNL_S_Materia_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Materia.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_SeleccionarCarreraMateria, PNL_S_Materia, "CARRERA", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_ExamenFinal_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_ExamenFinal.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_FacultadExamenFinal, PNL_S_ExamenFinal, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_Aula_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Aula.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_SeleccionarAulaAula, PNL_S_Aula, "AULA", "DESCRIPCION")
    End Sub
    Private Sub PNL_E_Facultad_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_E_Facultad.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_E_SeleccionarFacultad, PNL_E_Facultad, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_E_Carrera_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_E_Carrera.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_E_SeleccionarCarreraCarrera, PNL_E_Carrera, "CARRERA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_E_SeleccionarFacultadCarrera, PNL_E_Carrera, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_E_Aula_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_E_Aula.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_E_SeleccionarAulaAula, PNL_E_Aula, "AULA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_E_SeleccionarFacultadAula, PNL_E_Aula, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Carrera_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Carrera.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccionarFacultadCarrera, PNL_A_Carrera, "FACULTAD", "DESCRIPCION")

    End Sub
    Private Sub CMB_A_FacultadExamenFinal_VisibleChanged(sender As Object, e As EventArgs) Handles CMB_A_FacultadExamenFinal.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccionarCarreraMateria, PNL_A_Materia, "CARRERA", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Aula_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Aula.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccionarAulaFacultad, PNL_A_Aula, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Alumno2_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Alumno2.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccionarFacultadAlumno, PNL_A_Alumno2, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_ExamenFinal_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_ExamenFinal.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_FacultadExamenFinal, PNL_A_ExamenFinal, "FACULTAD", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_CarreraExamenFinal, PNL_A_ExamenFinal, "CARRERA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_MateriaExamenFinal, PNL_A_ExamenFinal, "MATERIA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_AulaExamenFinal, PNL_A_ExamenFinal, "AULA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_HoraExamen, PNL_A_ExamenFinal, "HORA", "NUMERO")
        oConfiguracion.CargarComboBox(CMB_A_MinutoExamen, PNL_A_ExamenFinal, "MINUTO", "NUMERO")
        oConfiguracion.CargarComboEspecifico(CMB_A_ProfesoresExamen, PNL_A_ExamenFinal, "PERSONA, PROFESOR", "PERSONA_APELLIDO", "ID_PROFESOR", "ID_PERSONA = PROFESOR_RELA_PERSONA")
    End Sub
    Private Sub PNL_A_Curso_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Curso.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_FacultadCurso, PNL_A_Curso, "FACULTAD", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_CarreraCurso, PNL_A_Curso, "CARRERA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_MateriaCurso, PNL_A_Curso, "MATERIA", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Curso2_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Curso2.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_DesdeHoraCurso, PNL_A_Curso2, "HORA", "NUMERO")
        oConfiguracion.CargarComboBox(CMB_A_DesdeMinutosCurso, PNL_A_Curso2, "MINUTO", "NUMERO")
        oConfiguracion.CargarComboBox(CMB_A_HastaHoraCurso, PNL_A_Curso2, "HORA", "NUMERO")
        oConfiguracion.CargarComboBox(CMB_A_HastaMinutosCurso, PNL_A_Curso2, "MINUTO", "NUMERO")
        oConfiguracion.CargarComboBox(CMB_A_DiaCurso, PNL_A_Curso2, "DIA", "DESCRIPCION")
        oConfiguracion.CargarCombo(CMB_A_AulaCurso, PNL_A_Curso2, "AULA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadCurso)
        oConfiguracion.CargarComboEspecifico(CMB_A_ProfesoresCurso, PNL_A_Curso2, "PERSONA, PROFESOR", "PERSONA_APELLIDO", "ID_PROFESOR", "ID_PERSONA = PROFESOR_RELA_PERSONA")
    End Sub
    Private Sub PNL_A_Inscripcion_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Inscripcion.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_FacultadExamen, PNL_A_Inscripcion, "FACULTAD", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_CarreraExamen, PNL_A_Inscripcion, "CARRERA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_CondiciónExamen, PNL_A_Inscripcion, "CONDICION", "DESCRIPCION")
    End Sub
    Private Sub Panel1_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_InscripcionCursadas.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_FacultadIC, PNL_A_InscripcionCursadas, "FACULTAD", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_CarreraIC, PNL_A_InscripcionCursadas, "CARRERA", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_Facultad_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Facultad.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_FacultadSeleccionar, PNL_S_Facultad, "FACULTAD", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_Carrera_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Carrera.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_SeleccionarCarreraCarrera, PNL_S_Carrera, "CARRERA", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_Alumno_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Alumno.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_SeleccionarAlumno, PNL_S_Alumno, "ALUMNO", "DESCRIPCION")
    End Sub
    Private Sub PNL_S_Otro_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Otro.VisibleChanged
        oConfiguracion.CargarComboEspecifico(CMB_S_SeleccionePersonaOtro, PNL_S_Otro, "PERSONA", "PERSONA_APELLIDO", "ID_ADMINISTRACION", "ID_PERSONA=ADMIN_RELA_PERSONA")
    End Sub
    Private Sub PNL_S_Profesor_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Profesor.VisibleChanged
        oConfiguracion.CargarComboEspecifico(CMB_S_SeleccionarProfesorProfesor, PNL_S_Profesor, "PERSONA", "PERSONA_APELLIDO", "ID_PROFESOR", "ID_PERSONA=PROFESOR_RELA_PERSONA")
    End Sub
    Private Sub PNL_S_Curso_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_S_Curso.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_S_SeleccionarFacultadCurso, PNL_S_Curso, "FACULTAD", "DESCRIPCION")
    End Sub

    'COMBOBOX
    Private Sub CMB_S_FacultadExamenFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_FacultadExamenFinal.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_S_CarreraExamenFinal, PNL_S_ExamenFinal, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_S_FacultadExamenFinal)
    End Sub

    Private Sub CMB_S_CarreraExamenFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_CarreraExamenFinal.SelectedIndexChanged
        Dim CARRERA As Integer = CMB_S_CarreraExamenFinal.SelectedValue
        oConfiguracion.CargarComboEspecifico(CMB_S_SeleccionarFinalExamenFinal, PNL_S_ExamenFinal, "MATERIA, EXAMEN", "MATERIA_DESCRIPCION", "ID_EXAMEN", "MATERIA_RELA_CARRERA=" & CARRERA & "ID_MATERIA=EXAMEN_RELA_MATERIA")
    End Sub

    Private Sub CMB_S_SeleccionarMateriaCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_SeleccionarMateriaCurso.SelectedIndexChanged
        oConfiguracion.CargarComboSinRepetir(CMB_S_ComisionCurso, PNL_S_Curso, "CURSO", "CURSO_N_COMISION", "CURSO_N_COMISION")
    End Sub
    Private Sub CMB_S_SeleccionarCarreraCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_SeleccionarCarreraCurso.SelectedIndexChanged
        oConfiguracion.CargarComboEspecifico(CMB_S_SeleccionarMateriaCurso, PNL_S_Curso, "MATERIA, CURSO", "MATERIA_DESCRIPCION", "ID_CURSO", "ID_MATERIA=CURSO_RELA_MATERIA")
    End Sub
    Private Sub CMB_S_SeleccionarFacultadCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_SeleccionarFacultadCurso.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_S_SeleccionarCarreraCurso, PNL_S_Curso, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_S_SeleccionarFacultadCurso)
    End Sub
    Private Sub CMB_S_SeleccionarCarreraMateria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_S_SeleccionarCarreraMateria.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_S_SeleccionarMateriaMateria, PNL_S_Materia, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_S_SeleccionarCarreraMateria)
    End Sub
    Private Sub CMB_E_SeleccionarFacultad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_E_SeleccionarFacultad.SelectedIndexChanged
        TXT_E_CodigoFacultad.Text = Facultad.Codigo
        TXT_E_DescripcionFacultad.Text = Facultad.Descripcion
    End Sub
    Private Sub CMB_A_SeleccionarFacultadAlumno_SelectedIndexChanged(sender As Object, e As EventArgs)
        oConfiguracion.CargarCombo(CMB_A_SeleccioneCarrreraAlumno, PNL_A_Alumno2, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_SeleccionarFacultadAlumno)
    End Sub
    Private Sub CMB_A_FacultadExamenFinal_SelectedIndexChanged(sender As Object, e As EventArgs)
        oConfiguracion.CargarCombo(CMB_A_CarreraExamenFinal, PNL_A_ExamenFinal, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadExamenFinal)
        oConfiguracion.CargarCombo(CMB_A_AulaExamenFinal, PNL_A_ExamenFinal, "AULA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadExamenFinal)
    End Sub
    Private Sub CMB_A_CarreraExamenFinal_SelectedIndexChanged(sender As Object, e As EventArgs)
        oConfiguracion.CargarCombo(CMB_A_MateriaExamenFinal, PNL_A_ExamenFinal, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_A_CarreraExamenFinal)
    End Sub
    Private Sub CMB_A_SeleccionarFacultadAlumno_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CMB_A_SeleccionarFacultadAlumno.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_SeleccioneCarrreraAlumno, PNL_A_Alumno2, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_SeleccionarFacultadAlumno)
    End Sub
    Private Sub CMB_A_SeleccioneCarreraCorrelativa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_SeleccioneCarreraCorrelativa.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_SeleccioneMateriasCorrelativa, PNL_A_Correlativa, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_A_SeleccioneCarreraCorrelativa)
        oConfiguracion.CargarCombo(CMB_A_SeleccioneCorrelativasCorrelativa, PNL_A_Correlativa, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_A_SeleccioneCarreraCorrelativa)
    End Sub
    Private Sub CMB_A_FacultadExamenFinal_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CMB_A_FacultadExamenFinal.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_CarreraExamenFinal, PNL_A_ExamenFinal, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadExamenFinal)
        oConfiguracion.CargarCombo(CMB_A_AulaExamenFinal, PNL_A_ExamenFinal, "AULA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadExamenFinal)
    End Sub
    Private Sub CMB_A_CarreraExamenFinal_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CMB_A_CarreraExamenFinal.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_MateriaExamenFinal, PNL_A_ExamenFinal, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_A_CarreraExamenFinal)
    End Sub
    Private Sub CMB_A_FacultadCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_FacultadCurso.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_CarreraCurso, PNL_A_Curso, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadCurso)
    End Sub
    Private Sub CMB_A_CarreraCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_CarreraCurso.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_MateriaCurso, PNL_A_Curso, "MATERIA", "DESCRIPCION", "RELA_CARRERA", CMB_A_CarreraCurso)
    End Sub
    Private Sub CMB_A_CarreraExamen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_CarreraExamen.SelectedIndexChanged
        Dim ID As Integer = CMB_A_CarreraExamen.SelectedValue
        oConfiguracion.CargarComboEspecifico(CMB_A_ExamenExamen, PNL_A_Inscripcion, "MATERIA, EXAMEN", "MATERIA_DESCRIPCION", "ID_MATERIA", "MATERIA_RELA_CARRERA = " & ID & " AND EXAMEN_RELA_MATERIA = ID_MATERIA")
    End Sub
    Private Sub CMB_A_ExamenExamen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_ExamenExamen.SelectedIndexChanged
        Dim ID As Integer = CMB_A_ExamenExamen.SelectedValue
        oConfiguracion.CargarComboEspecifico(CMB_A_LlamadoExamen, PNL_A_Inscripcion, "EXAMEN", "EXAMEN_LLAMADO", "ID_EXAMEN", "EXAMEN_RELA_MATERIA = " & ID & " AND EXAMEN_RELA_TIPO_EXAMEN <> 1")
    End Sub
    Private Sub CMB_A_FacultadExamen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_FacultadExamen.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_CarreraExamen, PNL_A_Inscripcion, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadExamen)
    End Sub
    Private Sub CMB_A_FacultadIC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_FacultadIC.SelectedIndexChanged
        oConfiguracion.CargarCombo(CMB_A_CarreraIC, PNL_A_InscripcionCursadas, "CARRERA", "DESCRIPCION", "RELA_FACULTAD", CMB_A_FacultadIC)
    End Sub
    Private Sub CMB_A_ComisionIC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_ComisionIC.SelectedIndexChanged
        Dim ID As Integer = CMB_A_CarreraIC.SelectedValue
        Dim Comision As String = CMB_A_ComisionIC.Text
        oConfiguracion.CargarComboEspecifico(CMB_A_CursoIC, PNL_A_InscripcionCursadas, "MATERIA, CURSO", "MATERIA_DESCRIPCION", "ID_CURSO", "MATERIA_RELA_CARRERA = " & ID & " AND ID_MATERIA = CURSO_RELA_MATERIA AND CURSO_N_COMISION = " & Comision)
    End Sub
    Private Sub CMB_A_CarreraIC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_A_CarreraIC.SelectedIndexChanged
        oConfiguracion.CargarComboSinRepetir(CMB_A_ComisionIC, PNL_A_InscripcionCursadas, "CURSO", "CURSO_N_COMISION", "CURSO_N_COMISION")
    End Sub
    'CANCELAR
    Private Sub BTN_S_CarreraCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_CarreraCancelar.Click
        Me.Close()
    End Sub

    Private Sub BTN_S_AlumnoCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_AlumnoCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_Cancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_MateriaCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_MateriaCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_ProfesorCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_ProfesorCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_CursoCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_CursoCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_AulaCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_AulaCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_ExamenFinalCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_ExamenFinalCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_ExamenFinalCancelar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_ExamenFinalCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_CancelarOtro_Click(sender As Object, e As EventArgs) Handles BTN_A_CancelarOtro.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_AlumnoCancelar2_Click_1(sender As Object, e As EventArgs) Handles BTN_A_AlumnoCancelar2.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_AlumnoCancelar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_AlumnoCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_AulaCancelar_Click(sender As Object, e As EventArgs) Handles BTN_A_AulaCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_ProfesorCancelar2_Click(sender As Object, e As EventArgs) Handles BTN_A_ProfesorCancelar2.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_MateriaCancelar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_MateriaCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_FacultadCancelar_Click_1(sender As Object, e As EventArgs) Handles BTN_A_FacultadCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_CarreraCancelar_Click(sender As Object, e As EventArgs) Handles BTN_A_CarreraCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_CursoCancelar_Click(sender As Object, e As EventArgs) Handles BTN_A_CursoCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_CursoCancelar2_Click(sender As Object, e As EventArgs) Handles BTN_A_CursoCancelar2.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_ExamenCancelar_Click(sender As Object, e As EventArgs) Handles BTN_A_ExamenCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_E_FacultadCancelar_Click(sender As Object, e As EventArgs) Handles BTN_E_FacultadCancelar.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_TerminarIC_Click(sender As Object, e As EventArgs) Handles BTN_A_TerminarIC.Click
        Me.Close()
    End Sub
    Private Sub BTN_S_FacultadCancelar_Click(sender As Object, e As EventArgs) Handles BTN_S_FacultadCancelar.Click
        Me.Close()
    End Sub
    'CREO QUE ESTO NO SIRVE
    Private Sub BTN_A_CorrelativaSalir_Click_1(sender As Object, e As EventArgs) Handles BTN_A_CorrelativaSalir.Click
        Me.Close()
    End Sub
    Private Sub BTN_A_ProfesorCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub
    Private Sub BTN_A_CursoSiguiente_Click_1(sender As Object, e As EventArgs) Handles BTN_A_CursoSiguiente.Click
        PNL_A_Curso.Visible = False
        oConfiguracion.EstablecerConfiguracion(Me, PNL_A_Curso2, TabControl1)
    End Sub
    Private Sub PNL_A_Materia_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Materia.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccionarCarreraMateria, PNL_A_Carrera, "CARRERA", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Otro_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Otro.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_FacultadOtro, PNL_A_Otro, "FACULTAD", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_OcupacionOtro, PNL_A_Otro, "PUESTO_ADMIN", "DESCRIPCION")
    End Sub
    Private Sub PNL_A_Correlativa_VisibleChanged(sender As Object, e As EventArgs) Handles PNL_A_Correlativa.VisibleChanged
        oConfiguracion.CargarComboBox(CMB_A_SeleccioneMateriasCorrelativa, PNL_A_Correlativa, "MATERIA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_SeleccioneCorrelativasCorrelativa, PNL_A_Correlativa, "MATERIA", "DESCRIPCION")
        oConfiguracion.CargarComboBox(CMB_A_SeleccioneCarreraCorrelativa, PNL_A_Correlativa, "CARRERA", "DESCRIPCION")
    End Sub


End Class