Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class Admin_EmpDesignation
    Inherits System.Web.UI.Page
    Sub loadEmp()

        SQL(0) = "SELECT CONCAT(empId, ': ', empName) as empNameStr,empId from employee order by empId asc;"
        DT = M1.GetDatatable(SQL(0))
        ddlEmpolyee.DataSource = DT
        ddlEmpolyee.DataTextField = "empNameStr"
        ddlEmpolyee.DataValueField = "empId"
        ddlEmpolyee.DataBind()
    End Sub

    Sub loadRole()

        SQL(0) = "select roleName,roleId from role order by roleName asc;"
        DT = M1.GetDatatable(SQL(0))
        ddlRole.DataSource = DT
        ddlRole.DataTextField = "roleName"
        ddlRole.DataValueField = "roleId"
        ddlRole.DataBind()
    End Sub
    Sub loaddata()

        SQL(0) = "select empEnrolId,a.empId as empId, empName, roleName from employeeenrolment a 
                  inner join employee b on a.empId = b.empId inner join role c on a.roleId = c.roleId;"
        DT = M1.GetDatatable(SQL(0))
        gvEmpDes.DataSource = DT
        gvEmpDes.DataBind()

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
            loadEmp()
            loadRole()
        End If
    End Sub
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub


    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    '    Dim con As New MySqlConnection(constr)
    '    Dim cmd As New MySqlCommand

    '    cmd.Connection = con
    '    cmd.CommandText = "SP_ADD_ROLE"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@pempId", Convert.ToInt64(txtemployeeId.Text))
    '    cmd.Parameters.AddWithValue("@proleName", txtemployeeRole.Text)
    '    cmd.Parameters.AddWithValue("@proleDesc", txtRoleDesc.Text)
    '    cmd.Parameters.AddWithValue("@proleType", DropDownList1.Text)
    '    Try
    '        con.Open()
    '        If cmd.ExecuteScalar() IsNot " " Then
    '            Dim message As String = cmd.ExecuteScalar.ToString()
    '            alert(message)
    '        Else
    '            alert("Data inserted successfully")
    '        End If

    '    Catch er As MySqlException
    '        MsgBox(er.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim pempId As Integer = ddlEmpolyee.SelectedValue
        Dim proleId As String = ddlRole.SelectedValue

        cmd.CommandText = "SP_ADD_EMPENROLLMENT;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        cmd.Parameters.AddWithValue("@proleId", proleId)


        Try
            M1.Execute(SQL(0))
            alert("Data entered successfully.")
            ClearValue()

        Catch ex As Exception
            alert("Data entered fail, please Try again.")
        End Try
    End Sub
    Sub ClearValue()
        DT.Clear()
        ddlEmpolyee.Items.Clear()
        ddlEmpolyee.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlRole.Items.Clear()
        ddlRole.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        loaddata()
        loadEmp()
        loadRole()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "SP_SEARCH_EMPENROLMENT('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvEmpDes.DataSource = DT
        gvEmpDes.DataBind()
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ddlEmpolyee.SelectedIndex() = 0
        ddlRole.SelectedIndex() = 0
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

    'Protected Sub gvEmpDes_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmpDes.RowDeleting
    '    Dim index As Integer = e.RowIndex
    '    Dim empEnrolId As String = Me.gvEmpDes.DataKeys(index).Values(0).ToString()

    '    cmd.CommandText = "SP_DELETE_EMLPLOYEE;"
    '    cmd.Parameters.AddWithValue("@pempId", pempId)
    '    M1.Execute(SQL(0))
    '    alert("Data deleted successfully")
    '    gvEmployee.EditIndex = -1
    '    loaddata()

    'End Sub
End Class