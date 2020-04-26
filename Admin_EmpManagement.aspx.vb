Public Class Admin_EmpManagement
    Inherits System.Web.UI.Page


    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "load data"
    Sub loaddata()
        SQL(0) = " GET_EMPLOYEE;"
        DT = M1.GetDatatable(SQL(0))
        gvEmployee.DataSource = DT
        gvEmployee.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub

#End Region

#Region "save"

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim pempId As Integer = Trim(Me.txtemployeeId.Text)
        Dim pempName As String = Me.txtempName.Text
        Dim pemail As String = txtemailId.Text

        cmd.CommandText = "SP_ADD_EMPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        cmd.Parameters.AddWithValue("@pempName", pempName)
        cmd.Parameters.AddWithValue("@pempEmail", pemail)
        M1.Execute(SQL(0))
        Try
            alert("Data entered successfully.")
            txtemployeeId.Text = ""
            txtempName.Text = ""
            txtemailId.Text = ""
            loaddata()
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtemployeeId.Text = ""
        txtempName.Text = ""
        txtemailId.Text = ""

    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "SP_SEARCH_EMPLOYEE('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvEmployee.DataSource = DT
        gvEmployee.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

#Region "GV"
    Protected Sub gvEmployee_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmployee.RowDeleting
        Dim index As Integer = e.RowIndex
        Dim pempId As String = Me.gvEmployee.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "SP_DELETE_EMLPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        M1.Execute(SQL(0))
        alert("Data deleted successfully")
        gvEmployee.EditIndex = -1
        loaddata()
    End Sub

    Protected Sub gvEmployee_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEmployee.RowUpdating
        Dim index As Integer = e.RowIndex
        Dim empId As String = Me.gvEmployee.DataKeys(index).Values(0).ToString()
        Dim empName As TextBox = CType(gvEmployee.Rows(e.RowIndex).FindControl("txtEmpName"), TextBox)
        Dim empEmail As TextBox = CType(gvEmployee.Rows(e.RowIndex).FindControl("txtEmpEmail"), TextBox)

        cmd.CommandText = "SP_UPDATE_EMPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", empId)
        cmd.Parameters.AddWithValue("@pempName", empName.Text)
        cmd.Parameters.AddWithValue("@pempEmail", empEmail.Text)
        M1.Execute(SQL(0))
        alert("Data edited successfully")
        gvEmployee.EditIndex = -1
        loaddata()
    End Sub
    Protected Sub gvEmployee_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEmployee.RowEditing
        gvEmployee.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvEmployee.SelectedIndexChanging
        Dim k1 As DataKey = gvEmployee.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvEmployee.PageIndexChanging
        Me.gvEmployee.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvEmployee.PageIndex
        loaddata()
    End Sub

#End Region

End Class