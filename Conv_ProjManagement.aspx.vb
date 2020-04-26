Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class Conv_ProjManagement
    Inherits System.Web.UI.Page
#Region "check"

    Sub clear()
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        ddlUnitCode.SelectedIndex() = 0
        txtProjName.Text = ""
        txtProjDesc.Text = ""
    End Sub

    '-- alert
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1

        If ddlYear.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlYear.Focus()
            alert("Please select year")
            chk = 0
        ElseIf ddlSemester.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlSemester.Focus()
            alert("Please select semester")
            chk = 0
        ElseIf ddlUnitCode.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlUnitCode.Focus()
            alert("Please select unit")
            chk = 0
        ElseIf txtProjName.Text = "" Then
            Me.txtProjName.Focus()
            alert("Please select project name")
            chk = 0
        ElseIf txtProjDesc.Text = "" Then
            Me.txtProjDesc.Focus()
            alert("Please select project description")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "load data"

    Sub loadYear()
        Dim nowYear As Integer = Date.Now.Year
        Dim nextYear = nowYear + 1
        Dim nextYearStr = nextYear.ToString
        Dim nowYearStr = nowYear.ToString
        SQL(0) = "select distinct(offUnitYear) from offeredunit where offUnitYear = " & nowYearStr & " or offUnitYear = " & nextYearStr
        DT = M1.GetDatatable(SQL(0))
        ddlYear.DataSource = DT
        ddlYear.DataTextField = "offUnitYear"
        ddlYear.DataValueField = "offUnitYear"
        ddlYear.DataBind()

    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        SQL(0) = "select distinct(offUnitSem) from offeredunit where offUnitYear = " & selectedYear
        DT = M1.GetDatatable(SQL(0))
        ddlSemester.DataSource = DT
        ddlSemester.DataTextField = "offUnitSem"
        ddlSemester.DataValueField = "offUnitSem"
        ddlSemester.DataBind()
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        Dim selectedSem = ddlSemester.SelectedItem.Value
        ddlUnitCode.Items.Clear()
        ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        SQL(0) = "select a.offUnitId, CONCAT(b.unitId, ' - ', b.unitName) as unitStr " _
                & " from offeredunit a " _
                & " join unit b on a.unitId = b.unitId " _
                & " where offUnitYear = " & selectedYear & " And offUnitSem = " & selectedSem
        DT = M1.GetDatatable(SQL(0))
        ddlUnitCode.DataSource = DT
        ddlUnitCode.DataTextField = "unitStr"
        ddlUnitCode.DataValueField = "offUnitId"
        ddlUnitCode.DataBind()
    End Sub


    '--load gridview
    Sub loaddata()
        SQL(0) = " Select z.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, " _
                 & " d.EmpName, a.offUnitYear, a.offUnitSem " _
                 & " From project z " _
                 & " join offeredUnit a on z.offUnitId = a.offUnitId " _
                 & " join unit b on a.unitID = b.unitID " _
                 & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                 & " join employee d on c.empId = d.EmpId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            loaddata()
        End If
    End Sub

#End Region

#Region "Save"

    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    '--click save
    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim unit As String = ddlUnitCode.SelectedValue.ToString()
        Dim projName As String = Me.txtProjName.Text
        Dim projDesc As String = Me.txtProjDesc.Text

        cmd.CommandText = "ADD_PROJECT;"
        cmd.Parameters.AddWithValue("@pprojName", projName)
        cmd.Parameters.AddWithValue("@pprojDesc", projDesc)
        cmd.Parameters.AddWithValue("@poffUnitId", unit)
        M1.Execute(SQL(0))
        Try
            alert("Data entered successfully.")
            clear()
            loaddata()
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
        End Try
    End Sub

#End Region

#Region "gridview data"

    ''--managing gridview
    'Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvStudent.RowCancelingEdit
    '    gvData.EditIndex = -1
    '    Me.loaddata()
    'End Sub

    ''--show ddl and radiobutton GridView
    'Protected Sub gvData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudent.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim drv As DataRowView = e.Row.DataItem
    '        Dim no As Integer = e.Row.RowIndex
    '        Dim itemNo As Integer = (ViewState("Page") * 10) + no

    '        Dim ddlID As DropDownList = e.Row.FindControl("ddlStuLevel")
    '        If Not IsNothing(ddlID) Then
    '            ddlID.SelectedValue = DT.Rows.Item(itemNo)("stulevel").ToString
    '        End If
    '    End If
    'End Sub

    ''--click edit
    'Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvStudent.RowEditing
    '    gvData.EditIndex = e.NewEditIndex
    '    'bind Data to the gridview control.
    '    Me.loaddata()
    'End Sub

    ''--click update
    'Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvStudent.RowUpdating
    '    Dim index As Integer = e.RowIndex
    '    Dim stuid As String = Me.gvStudent.DataKeys(index).Values(0).ToString()
    '    Dim stuname As TextBox = CType(gvStudent.Rows(e.RowIndex).FindControl("txtStuName"), TextBox)
    '    Dim stulevel As DropDownList = CType(gvStudent.Rows(e.RowIndex).FindControl("ddlStuLevel"), DropDownList)

    '    Dim stunameStr As String = stuname.Text
    '    Dim stulevelStr As String = stulevel.SelectedValue.ToString()

    '    cmd.CommandText = "UPDATE_STUDENT;"
    '    cmd.Parameters.AddWithValue("@pstuId", stuid)
    '    cmd.Parameters.AddWithValue("@pstuName", stunameStr)
    '    cmd.Parameters.AddWithValue("@pstulevel", stulevelStr)
    '    M1.Execute(SQL(0))
    '    alert("Data edited successfully")
    '    gvData.EditIndex = -1
    '    loaddata()
    'End Sub

    ''--click delete
    'Protected Sub gvStudent_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvStudent.RowDeleting
    '    Dim index As Integer = e.RowIndex
    '    Dim stuid As String = Me.gvData.DataKeys(index).Values(0).ToString()

    '    cmd.CommandText = "DELETE_STUDENT;"
    '    cmd.Parameters.AddWithValue("@pstuId", stuid)
    '    M1.Execute(SQL(0))
    '    alert("Data edited successfully")
    '    gvData.EditIndex = -1
    '    loaddata()
    'End Sub

    '--gridview page
    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = " Select z.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, " _
                 & " d.EmpName, a.offUnitYear, a.offUnitSem " _
                 & " From project z " _
                 & " join offeredUnit a on z.offUnitId = a.offUnitId " _
                 & " join unit b on a.unitID = b.unitID " _
                 & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                 & " join employee d on c.empId = d.EmpId " _
                 & " Where z.projName Like '" & searchTerm & "' "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As New MySqlConnection(constr)
        Dim cmd As New MySqlCommand

        Dim date1 As Date = Convert.ToDateTime(txtDate.Text)

        cmd.Connection = con
        cmd.CommandText = "SP_ADD_PROJECT"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@pprojName", txtProjectName.Text)
        cmd.Parameters.AddWithValue("@pprojDesc", txtProjDesc.Text)
        cmd.Parameters.AddWithValue("@poffUnitId", Convert.ToInt64(txtunitId.Text))
        cmd.Parameters.AddWithValue("@pprojRegDate", date1.Date)
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
    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

End Class