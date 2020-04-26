Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class Conv_TeamFormation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As New MySqlConnection(constr)
        Dim cmd As New MySqlCommand

        cmd.Connection = con
        cmd.CommandText = "SP_ADD_TEAM"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@pteamNo", Convert.ToInt64(txtTeamNum.Text))
        cmd.Parameters.AddWithValue("@pteamTitle", txtTeamTitle.Text)
        cmd.Parameters.AddWithValue("@pprojId", Convert.ToInt64(txtprojId.Text))
        cmd.Parameters.AddWithValue("@pempEnrolId", Convert.ToInt64(txtEnrolId.Text))
        Try
            con.Open()
            If cmd.ExecuteScalar() IsNot " " Then
                Dim message As String = cmd.ExecuteScalar.ToString()
                alert(message)
            Else
                alert("Data inserted successfully")
            End If

        Catch er As MySqlException
            MsgBox(er.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class