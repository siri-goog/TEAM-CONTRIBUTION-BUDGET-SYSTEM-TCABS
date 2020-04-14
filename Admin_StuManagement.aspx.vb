Public Class Admin_StuManagement
    Inherits System.Web.UI.Page

#Region "check"

    '-- alert
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1

        If txtStuID.Text = "" Then
            Me.txtStuID.Focus()
            alert("Please add student ID")
            chk = 0
        ElseIf txtStuName.Text = "" Then
            Me.txtStuName.Focus()
            alert("Please add student name")
            chk = 0
        ElseIf ddlStudentLevel.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlStudentLevel.Focus()
            alert("Please select student level")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Manage Student"

    '--load gridview
    Sub loaddata()
        SQL(0) = " GET_STUDENT;"
        DT = M1.GetDatatable(SQL(0))
        gvStudent.DataSource = DT
        gvStudent.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub

    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtStuID.Text = ""
        txtStuName.Text = ""
        ddlStudentLevel.SelectedIndex() = 0
    End Sub

    '--click save
    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim stuID As Integer = Trim(Me.txtStuID.Text)
        Dim stuName As String = Trim(Me.txtStuName.Text)
        Dim stuLevel As String = ddlStudentLevel.SelectedValue.ToString()
        Dim regDate As Date = Date.Today()

        cmd.CommandText = "ADD_STUDENT;"
        cmd.Parameters.AddWithValue("@stuId", stuID)
        cmd.Parameters.AddWithValue("@stuName", stuName)
        cmd.Parameters.AddWithValue("@stulevel", stuLevel)
        M1.Execute(SQL(0))
        Try
            alert("Data entered successfully.")
            txtStuID.Text = ""
            txtStuName.Text = ""
            ddlStudentLevel.SelectedIndex() = 0
            loaddata()
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
        End Try
    End Sub

#End Region

#Region "gridview data"

    '--managing gridview
    Protected Sub gvStudent_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvStudent.RowCancelingEdit
        gvStudent.EditIndex = -1
        Me.loaddata()
    End Sub

    '--show ddl and radiobutton GridView
    Protected Sub gvStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudent.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem
            Dim no As Integer = e.Row.RowIndex
            Dim itemNo As Integer = (ViewState("Page") * 10) + no

            Dim ddlID As DropDownList = e.Row.FindControl("ddlStuLevel")
            If Not IsNothing(ddlID) Then
                ddlID.SelectedValue = DT.Rows.Item(itemNo)("stulevel").ToString
            End If
        End If
    End Sub

    '--click edit
    Protected Sub gvStudent_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvStudent.RowEditing
        gvStudent.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    '--click update
    Protected Sub gvStudent_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvStudent.RowUpdating
        Dim index As Integer = e.RowIndex
        Dim stuid As String = Me.gvStudent.DataKeys(index).Values(0).ToString()
        Dim stuname As TextBox = CType(gvStudent.Rows(e.RowIndex).FindControl("txtStuName"), TextBox)
        Dim stulevel As DropDownList = CType(gvStudent.Rows(e.RowIndex).FindControl("ddlStuLevel"), DropDownList)

        Dim stunameStr As String = stuname.Text
        Dim stulevelStr As String = stulevel.SelectedValue.ToString()

        cmd.CommandText = "UPDATE_STUDENT;"
        cmd.Parameters.AddWithValue("@pstuId", stuid)
        cmd.Parameters.AddWithValue("@pstuName", stunameStr)
        cmd.Parameters.AddWithValue("@pstulevel", stulevelStr)
        M1.Execute(SQL(0))
        alert("Data edited successfully")
        gvStudent.EditIndex = -1
        loaddata()
    End Sub

    '--click delete
    Protected Sub gvStudent_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvStudent.RowDeleting
        Dim index As Integer = e.RowIndex
        Dim stuid As String = Me.gvStudent.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_STUDENT;"
        cmd.Parameters.AddWithValue("@pstuId", stuid)
        M1.Execute(SQL(0))
        alert("Data edited successfully")
        gvStudent.EditIndex = -1
        loaddata()
    End Sub

    '--gridview page
    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvStudent.SelectedIndexChanging
        Dim k1 As DataKey = gvStudent.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvStudent.PageIndexChanging
        Me.gvStudent.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvStudent.PageIndex
        loaddata()
    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "SEARCH_STUDENT('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvStudent.DataSource = DT
        gvStudent.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

End Class