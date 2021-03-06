﻿
Imports System.Data.SqlClient

Public Class Puntos

    Inherits LCD.CAD

#Region "ATRIBUTOS"
    Private _id_Punto As Integer
    Private _descripcion As String
    Private _estado As Boolean
#End Region

#Region "PROPIEDADES"

    Public Property ID_Punto() As String
        Get
            Return _id_Punto
        End Get
        Set(ByVal value As String)
            _id_Punto = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

#End Region

#Region "METODOS"

    Sub New()

    End Sub

    Sub New(ByVal ID_Punto As Integer, ByVal Descripcion As String, ByVal Estado As Boolean)
        Me.ID_Punto = ID_Punto
        Me.Descripcion = Descripcion
        Me.Estado = Estado
    End Sub

    ''' <summary>
    ''' Guarda un Punto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Guardar() As Boolean
        Try
            IniciarSP("Pun_Insert")
            AddParametro("@ID_Punto", Me.ID_Punto)
            AddParametro("@Descripcion", Me.Descripcion)
            AddParametro("@Activo", Me.Estado)

            If EjecutarTransaccion() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error en : " & ex.Message & vbNewLine & "Desde : " & ex.Source & ex.ToString, MsgBoxStyle.Critical, "DANIEL ROMERO BACOTICH")
            Return False
        End Try
     
    End Function

    ''' <summary>
    ''' Actualiza los datos de un punto incluso su ID
    ''' </summary>
    ''' <param name="ID_Anterior"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Actualizar(ByVal ID_Anterior As Integer) As Boolean
        Try
            IniciarSP("Pun_Update")
            AddParametro("ID_Anterior", ID_Anterior)
            AddParametro("@ID_Punto", Me.ID_Punto)
            AddParametro("@Descripcion", Me.Descripcion)
            AddParametro("@Activo", Me.Estado)

            If EjecutarTransaccion() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error en : " & ex.Message & vbNewLine & "Desde : " & ex.Source & ex.ToString, MsgBoxStyle.Critical, "DANIEL ROMERO BACOTICH")
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Actualiza el estado de un punto a inactivo
    ''' </summary>
    ''' <param name="ID_Punto">ID del punto</param>
    ''' <param name="EstadoNuevo">Estado a cambiar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CambiarEstado(ByVal ID_Punto As Integer, ByVal EstadoNuevo As Boolean) As Boolean
        Try
            IniciarSP("Pun_Delete")
            AddParametro("@ID_Punto", ID_Punto)
            AddParametro("@Estado", EstadoNuevo)

            If EjecutarTransaccion() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error en : " & ex.Message & vbNewLine & "Desde : " & ex.Source & ex.ToString, MsgBoxStyle.Critical, "DANIEL ROMERO BACOTICH")
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Obtiene un punto por su ID
    ''' </summary>
    ''' <param name="ID_Punto">ID del punto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Obtener(ByVal ID_Punto As Integer) As DataTable

        Dim Tabla As New DataTable

        IniciarSP("Pun_GetByID")
        AddParametro("@ID_Punto", ID_Punto)

        If EjecutarTransaccion() = True Then
            If getTabla(Tabla) = True Then
                Return Tabla
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function
    ''' <summary>
    ''' Obtiene todos los puntos segun su estado y su descripcion
    ''' </summary>
    ''' <param name="Activo">Estado</param>
    ''' <param name="Descripcion">Descripcion</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Obtener(ByVal Activo As Boolean, ByVal Descripcion As String) As DataTable

        Dim Tabla As New DataTable

        IniciarSP("Pun_GetAll")
        AddParametro("@Activo", Activo)
        AddParametro("@Descripcion", Descripcion)

        If EjecutarTransaccion() = True Then
            If getTabla(Tabla) = True Then
                Return Tabla
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

#End Region


End Class
