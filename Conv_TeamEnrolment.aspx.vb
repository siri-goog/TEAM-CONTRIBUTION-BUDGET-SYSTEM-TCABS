Public Class Conv_TeamEnrolment
    Inherits System.Web.UI.Page

    Sub clear()
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        ddlUnitCode.SelectedIndex() = 0
        ddlProject.SelectedIndex() = 0
    End Sub

#Region "check"
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
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
        ElseIf ddlProject.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlUnitCode.Focus()
            alert("Please select unit")
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
    Protected Sub ddlUnitCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnitCode.SelectedIndexChanged
        Dim selectedUnit = ddlUnitCode.SelectedItem.Value
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        SQL(0) = " Select projId, projName from project where offUnitId = " & selectedUnit
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
    End Sub
    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        Dim selectedProj As String = ddlProject.SelectedItem.Value.ToString()
        SQL(0) = "  Select * " _
                 & " From team " _
                 & " Where projId = '" & selectedProj & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlTeam.DataSource = DT
        ddlTeam.DataTextField = "teamTitle"
        ddlTeam.DataValueField = "teamId"
        ddlTeam.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
        End If
    End Sub

    Sub loaddata()
        SQL(0) = " GET_STUDENT;"
        DT = M1.GetDatatable(SQL(0))
    End Sub

#End Region

#Region "GV Search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearchStu.Text) & "%"
        SQL(0) = "SEARCH_STUDENT('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvSearch.DataSource = DT
        gvSearch.DataBind()
        pnQuerySearch.Visible = True
        DT.Clear()

    End Sub

    Protected Sub gvSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSearch.SelectedIndexChanged
        Dim stuId As String
        Dim stuName As String
        Dim stuLevel As String

        stuId = gvSearch.Rows(gvSearch.SelectedIndex).Cells(0).Text
        stuName = gvSearch.Rows(gvSearch.SelectedIndex).Cells(1).Text
        stuLevel = gvSearch.Rows(gvSearch.SelectedIndex).Cells(2).Text
        gvSearch.DataSource = Nothing
        gvSearch.DataBind()
        If DT_Student.Columns.Count = 0 Then
            DT_Student.Columns.Add("stuId", GetType(String))
            DT_Student.Columns.Add("stuName", GetType(String))
            DT_Student.Columns.Add("stulevel", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow
        R("stuId") = stuId
        R("stuName") = stuName
        R("stuLevel") = stuLevel
        'DT_Student.Rows.Add(stuId, stuName, stuLevel)
        DT_Student.Rows.Add(R)
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
    End Sub

#End Region

#Region "GV Student"

    Protected Sub gvStudent_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvStudent.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Student.Rows.RemoveAt(index)
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        For Each GVRow As GridViewRow In Me.gvStudent.Rows
            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            Dim stuId As String = K1(0)
            Dim teamId As Integer = ddlTeam.SelectedValue

            cmd.CommandText = "ADD_TEAM_ENROL"
            cmd.Parameters.AddWithValue("@pteamId", teamId)
            cmd.Parameters.AddWithValue("@penrolId", teamId)
            cmd.Parameters.AddWithValue("@pPM_Role", teamId)

            Try
                M1.Execute(SQL(0))
                alert("Data entered successfully.")

            Catch ex As Exception
                alert("Data entered fail, please Try again.")
            End Try
        Next

        clear()
        loadYear()
    End Sub

    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

#End Region

End Class