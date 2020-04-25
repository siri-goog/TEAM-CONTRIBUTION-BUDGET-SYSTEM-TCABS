Public Class Conv_setProjectRole
    Inherits System.Web.UI.Page
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
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
        End If
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
        SQL(0) = "select unitId,offUnitId from offeredunit where offUnitYear = " & selectedYear & " and offUnitSem = " & selectedSem
        DT = M1.GetDatatable(SQL(0))
        ddlUnitCode.DataSource = DT
        ddlUnitCode.DataTextField = "unitId"
        ddlUnitCode.DataValueField = "offUnitId"
        ddlUnitCode.DataBind()
    End Sub

    Protected Sub ddlUnitCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnitCode.SelectedIndexChanged
        Dim selectedUnit = ddlUnitCode.SelectedItem.Text
        SQL(0) = "select unitname,unitDesc,unitCredit from unit where unitId = '" & selectedUnit & "'"
        DT = M1.GetDatatable(SQL(0))
        lblUnitName.Text = DT.Rows(0).Item(0)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtProjectName.Text) & "%"
        Dim poffUnitId = ddlUnitCode.SelectedValue
        SQL(0) = "SEARCH_PROJECT('" & searchTerm & "'" & "," & poffUnitId & ");"
        DT = M1.GetDatatable(SQL(0))
        gvSearch.DataSource = DT
        gvSearch.DataBind()
        pnQuerySearch.Visible = True
        DT.Clear()

    End Sub
End Class