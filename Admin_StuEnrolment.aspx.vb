Public Class Admin_StuEnrolment
    Inherits System.Web.UI.Page
    '--load Year for dropdown
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

#Region "Unit"

    Protected Sub ddlUnitCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnitCode.SelectedIndexChanged
        Dim selectedUnit = ddlUnitCode.SelectedItem.Text
        SQL(0) = "select unitname,unitDesc,unitCredit from unit where unitId = '" & selectedUnit & "'"
        DT = M1.GetDatatable(SQL(0))
        lblUnitName.Text = DT.Rows(0).Item(0)
        lblUnitDesc.Text = DT.Rows(0).Item(1)
        lblCredit.Text = DT.Rows(0).Item(2)

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
            Dim offUnitId As Integer = ddlUnitCode.SelectedValue

            cmd.CommandText = "ADD_STUDENT_ENROL"
            cmd.Parameters.AddWithValue("@pstuId", stuId)
            cmd.Parameters.AddWithValue("@poffUnitId", offUnitId)

            Try
                M1.Execute(SQL(0))
                alert("Data entered successfully.")

            Catch ex As Exception
                alert("Data entered fail, please Try again.")
            End Try
        Next

        ClearValue()
        loadYear()



    End Sub
    Sub ClearValue()
        lblCredit.Text = ""
        lblUnitDesc.Text = ""
        lblUnitName.Text = ""
        DT_Student.Clear()
        DT.Clear()
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlUnitCode.Items.Clear()
        ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", ""))
    End Sub



#End Region

#Region "GV Search"

#End Region

#Region "Student"

#End Region

#Region "GV Student"

#End Region






End Class