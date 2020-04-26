Public Class Conv_ProjTask
    Inherits System.Web.UI.Page

    Sub Clear()
        txtTaskNo.Text = ""
        txtTaskTitle.Text = ""
        txtTaskDesc.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlUnitCode.Items.Clear()
        ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", ""))
    End Sub

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "check"

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
        ElseIf ddlProject.SelectedItem.ToString = " [-- please select --] " Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf txtTaskNo.Text = "" Then
            Me.txtTaskNo.Focus()
            alert("Please add task No")
            chk = 0
        ElseIf txtTaskTitle.Text = "" Then
            Me.txtTaskTitle.Focus()
            alert("Please add task title")
            chk = 0
        ElseIf txtTaskDesc.Text = "" Then
            Me.txtTaskDesc.Focus()
            alert("Please add task description")
            chk = 0
        ElseIf txtStartDate.Text = "" Then
            Me.txtStartDate.Focus()
            alert("Please add start date")
            chk = 0
        ElseIf txtEndDate.Text = "" Then
            Me.txtEndDate.Focus()
            alert("Please add end date")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Carlendar"

    Dim vClsFunc As New ClassFunction()

    Protected Sub IMbStartDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbStartDate.Click
        Calendar1.Visible = True
        Calendar2.Visible = False
    End Sub
    Protected Sub IMbEndDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbEndDate.Click
        Calendar2.Visible = True
        Calendar1.Visible = False
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.txtStartDate.Text = vClsFunc.DateString_Show(Calendar1.SelectedDate)
        Calendar1.Visible = False
    End Sub
    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        Me.txtEndDate.Text = vClsFunc.DateString_Show(Calendar2.SelectedDate)
        Calendar2.Visible = False
    End Sub


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
        Dim selectedYear = ddlYear.SelectedItem.Value
        Dim selectedSem = ddlSemester.SelectedItem.Value
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        SQL(0) = " Select z.projId, z.projName " _
                & " From project z " _
                & " join offeredUnit a on z.offUnitId = a.offUnitId " _
                & " where a.offUnitYear = " & selectedYear & " And a.offUnitSem = " & selectedSem
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
    End Sub

    Sub loaddata()
        SQL(0) = "Select c.offUnitYear, c.offUnitSem, CONCAT(d.unitID, '-', d.unitName) as unitStr, " _
                   & " b.projName, a.* " _
                   & "  From task a " _
                   & "  Join project b on a.projId = b.projId " _
                   & "  Join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  Join unit d on c.UnitId = d.UnitId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            Calendar1.Visible = False
            Calendar2.Visible = False
            loaddata()
        End If
    End Sub

#End Region

#Region "Save"

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim projId As String = ddlProject.SelectedValue.ToString()
        Dim taskNo As String = Me.txtTaskNo.Text
        Dim taskTitle As String = Me.txtTaskTitle.Text
        Dim taskDesc As String = Me.txtTaskDesc.Text
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)

        cmd.CommandText = "ADD_TASK;"
        cmd.Parameters.AddWithValue("@pprojId", projId)
        cmd.Parameters.AddWithValue("@ptaskNo", taskNo)
        cmd.Parameters.AddWithValue("@ptaskTitle", taskTitle)
        cmd.Parameters.AddWithValue("@ptaskDesc", taskDesc)
        cmd.Parameters.AddWithValue("@pstartDate", startDate)
        cmd.Parameters.AddWithValue("@pendDate", endDate)
        M1.Execute(SQL(0))
        Try
            alert("Data entered successfully.")
            clear()
            loaddata()
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SQL(0) = "Select c.offUnitYear, c.offUnitSem, CONCAT(d.unitID, '-', d.unitName) as unitStr, " _
                   & " b.projName, a.* " _
                   & "  From task a " _
                   & "  Join project b on a.projId = b.projId " _
                   & "  Join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  Join unit d on c.UnitId = d.UnitId " _
                   & "  Where taskTitle like '%" & txtSearch.Text & "%'  "
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