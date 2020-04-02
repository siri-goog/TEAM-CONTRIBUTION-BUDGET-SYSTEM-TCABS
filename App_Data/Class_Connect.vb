Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text
Imports System.TimeZone
Imports MySql.Data.MySqlClient

Public Class Class_Connect
    Public Function GetDatatable(ByVal strsql As String) As DataTable
        Try
            Dim DT As New DataTable()
            If Myconn Is Nothing Then
                Me.OpenConnection()
            End If
            'Dim DA As New OleDbDataAdapter(strsql, Myconn)
            Dim DA As New MySqlDataAdapter(strsql, Myconn)
            DA.Fill(DT)
            Return DT
        Catch ex As Exception
            m_ErrorString = ex.Message
            Return Nothing
        End Try
        Myconn.Close()
    End Function
    '==============================================================================
    Public Sub ConectDB()
        If Myconn Is Nothing Then
            Me.OpenConnection()
        End If
    End Sub
    '==============================================================================
    Public Function OpenConnection() As Boolean
        Me.CreateConnection()
        Try
            If Myconn.State = ConnectionState.Closed Then
                Myconn.Open()
            End If
            Return True
        Catch ex As Exception
            m_ErrorString = ex.Message
            Return False
        End Try
    End Function

    '==============================================================================
    Public Sub CreateConnection()
        If Myconn Is Nothing Then
            Myconn = New MySqlConnection(StrDb)
            Myconn.Open()
        End If
    End Sub
    '==============================================================================
    Public Function Execute(ByVal strsql As String) As Integer
        'Dim cmd As New OleDbCommand(strsql)
        Dim cmd As New MySqlCommand(strsql)
        Return Me.Execute(cmd)
    End Function
    Public Function Execute(ByVal cmd As MySqlCommand) As Integer
        Dim Y As Boolean = Me.OpenConnection()
        If Y = True Then
            Dim X As Integer
            Try
                cmd.Connection = Myconn
                If m_Tran = True Then
                    cmd.Transaction = T1
                End If
                X = cmd.ExecuteNonQuery

            Catch ex As Exception
                m_ErrorString = ex.Message
                Return -1
            End Try
            Return X
        Else
            Return -1
        End If
        Myconn.Close()
    End Function
    '==============================================================================
    Public Sub MessageBox(ByVal msg As String, ByVal obj As Object)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & "window.alert('" + msg + "')</scr" & "ipt>"
        obj.controls.add(lbl)
    End Sub
End Class
Public Module Module1
    'Public StrDb As String = "Password=chom8540;Persist Security Info=True;User ID=chompunut;Initial Catalog=ETHANOL;Data Source=10.28.99.109\dom"
    Public StrDb As String = "Password=qweiop93;Persist Security Info=True;User ID=root; Initial Catalog=tcabs; Pooling=False; Data Source=localhost"

    Public Myconn As MySqlConnection
    Public M1 As New Class_Connect
    Public SQL(20) As String
    Public DT As DataTable
    Public m_ErrorString As String
    Public T1 As MySqlTransaction
    Public m_Tran As Boolean = False
    Public MessError As String = ""
    Public X4 As String = ""
    Public DT1 As DataTable
    Public DT2 As DataTable
    Public DT3 As DataTable
    Public DT4 As DataTable
End Module
