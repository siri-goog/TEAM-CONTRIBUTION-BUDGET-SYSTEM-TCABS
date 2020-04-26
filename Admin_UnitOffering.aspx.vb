Public Class Admin_UnitOffering
    Inherits System.Web.UI.Page

#Region "Carlendar"
    Dim vClsFunc As New ClassFunction()

    Protected Sub IMbStartDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbStartDate.Click
        Calendar1.Visible = True
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.txtStartDate.Text = vClsFunc.DateString_Show(Calendar1.SelectedDate)
        Calendar1.Visible = False
    End Sub

#End Region

#Region "check"

    Sub clear()
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        ddlUnit.SelectedIndex() = 0
        ddlConvenor.SelectedIndex() = 0
        txtRoomNo.Text = ""
        txtStartDate.Text = ""
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
        ElseIf ddlUnit.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlUnit.Focus()
            alert("Please select unit")
            chk = 0
        ElseIf ddlConvenor.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlConvenor.Focus()
            alert("Please select convenor")
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

    Sub loadUnit()
        SQL(0) = " Select unitId, CONCAT(unitId, ' - ', unitName) as unitStr From unit "
        DT = M1.GetDatatable(SQL(0))
        ddlUnit.DataSource = DT
        ddlUnit.DataTextField = "unitStr"
        ddlUnit.DataValueField = "unitId"
        ddlUnit.DataBind()
    End Sub

    Sub loadYear()
        Dim year As Integer = DateTime.Now.Year
        For i = year To year + 3
            ddlYear.Items.Add(i)
        Next
    End Sub

    Sub loadConv()
        SQL(0) = "  Select a.empEnrolId, CONCAT(a.empId, ' - ', b.empName) as empStr " _
                 & " From employeeEnrolment a " _
                 & " Join employee b " _
                 & " On a.empId = b.empId  " _
                 & " Where roleId = 1 "
        DT = M1.GetDatatable(SQL(0))
        ddlConvenor.DataSource = DT
        ddlConvenor.DataTextField = "empStr"
        ddlConvenor.DataValueField = "empEnrolId"
        ddlConvenor.DataBind()
    End Sub

    '--load gridview
    Sub loaddata()
        SQL(0) = "  Select a.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, d.EmpName " _
                 & " From offeredUnit a " _
                 & " join unit b on a.unitID = b.unitID " _
                 & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                 & " join employee d on c.empId = d.EmpId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadUnit()
            loadYear()
            loadConv()
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

        Dim year As String = ddlYear.SelectedValue.ToString()
        Dim sem As String = ddlSemester.SelectedValue.ToString()
        Dim unit As String = ddlUnit.SelectedValue.ToString()
        Dim convenor As String = ddlConvenor.SelectedValue.ToString()
        Dim roomNo As Integer = Trim(Me.txtRoomNo.Text)
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)

        cmd.CommandText = "addOfferedUnit;"
        cmd.Parameters.AddWithValue("@pyear", year)
        cmd.Parameters.AddWithValue("@psem", sem)
        cmd.Parameters.AddWithValue("@punit_id", unit)
        cmd.Parameters.AddWithValue("@pempEnrolId", convenor)
        cmd.Parameters.AddWithValue("@proom", roomNo)
        cmd.Parameters.AddWithValue("@poffUnitStart", startDate)
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
        'SQL(0) = "SEARCH_STUDENT('" & searchTerm & "');"
        SQL(0) = " Select a.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, d.EmpName " _
                 & " From offeredUnit a " _
                 & " join unit b on a.unitID = b.unitID " _
                 & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                 & " join employee d on c.empId = d.EmpId " _
                 & "  Where b.unitId like '" & searchTerm & "' or b.unitName like '" & searchTerm & "' "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

End Class