Public Class Admin_StuManagement
    Inherits System.Web.UI.Page

    '#Region "Check"

    '    '-- Alert
    '    Protected Sub alert(ByVal scriptAlert As String)
    '        Dim script As String = ""
    '        script = "alert('" + scriptAlert + "');"
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jsCall", script, True)
    '    End Sub

    '    '--Function Check()
    '    Function Check() As Boolean
    '        Dim chk As String = 1

    '        If ddlCompany.SelectedItem.ToString = " [-- Please Select --] " Then
    '            Me.ddlCompany.Focus()
    '            alert("กรุณาเลือกบริษัท\nPlease Select Company")
    '            chk = 0
    '        Else
    '            If ddlHolding.SelectedItem.ToString = " [-- Please Select --] " Then
    '                Me.ddlHolding.Focus()
    '                alert("กรุณาเลือกกลุ่มบริษัท\nPlease Select Holding")
    '                chk = 0
    '            ElseIf txtName.Text = "" Then
    '                Me.txtName.Focus()
    '                alert("กรุณาระบุชื่อบริษัท\nPlease Add Company Name")
    '                chk = 0
    '            ElseIf rblStatus.SelectedValue = "" Then
    '                Me.rblStatus.Focus()
    '                alert("กรุณาระบุสถานะการใช้งาน\nPlease select status")
    '                chk = 0
    '            End If
    '        End If


    '        Sql(0) = "Select ComCode From Master_Company where ComCode = '" & Me.lblComCode.Text & "' "
    '        DT = M1.GetDatatable(Sql(0))
    '        If DT.Rows.Count > 0 Then
    '            alert("รหัสบริษัทนี้ได้รับการเพิ่มแล้วค่ะ\nThis Company Code is already exist")
    '            chk = 0
    '        End If


    '        If chk = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Function

    '    '--Check ว่าเวลาต้องเลือกค้นหาตาม Holding หรือ ComCode
    '    Function chkSearch() As Boolean
    '        Dim chk As String = 1

    '        If chkHolding.Checked = False And chkComCode.Checked = False Then
    '            alert("กรุณาเลือกประเภทการค้นหาค่ะ\nPlease select search type")
    '            chk = 0
    '        End If

    '        If chk = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Function

    '#End Region

#Region "AddNewStudent"

    '--Load GridView
    Sub LoadData()
        Sql(0) = " select * , case when a.status = 'Y' then 'Use' else 'Not use' end as status1 ," _
               & " case when a.Holding_Group = 'AA' then 'AA : Paper Holding' when a.Holding_Group = 'PO' then 'PO : Power Holding'  else 'QS : Other Holding' end as Holding , " _
               & " Company_Code + ' , ' + b.Company_NameT as companyName from [TRUE].[dbo].[Master_Company] A" _
               & " join [HRMS].[dbo].[COM_Company] B on a.id_company = b.id_company " _
               & " order by Holding_Group ASC, ComCode ASC "
        DT = M1.GetDatatable(Sql(0))
        gvStudent.DataSource = DT
        gvStudent.DataBind()
    End Sub

    '--แสดง ddlCompany
    Sub LoadCompanyCode()
        Sql(0) = " select ID_Company, Company_Code As companyCode ,Company_Code + ' , ' + Company_NameT As companyName " _
                & " from HRMS.dbo.COM_Company Order By companyName ASC"
        DT = M1.GetDatatable(Sql(0))
        Try
            ddlCompany.DataTextField = "companyName"
            ddlCompany.DataValueField = "ID_Company"
        Catch ex As Exception
            ddlCompany.DataTextField = ""
            ddlCompany.DataValueField = ""
        End Try
        Me.ddlCompany.DataSource = DT
        Me.ddlCompany.DataBind()
        Me.ddlCompany.Items.Insert(0, " [-- Please Select --] ")
    End Sub

    '--แสดงข้อมูลทุกครั้งที่ Load Page ขึ้นมา
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("USERID") = "26018"
        If Not Page.IsPostBack Then
            LoadData()
            LoadCompanyCode()
        End If
    End Sub

    '--Click Cancel
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lblComCode.Text = ""
        txtName.Text = ""
        ddlCompany.SelectedIndex() = 0
        ddlHolding.SelectedIndex() = 0
        rblStatus.SelectedValue = False
        rblStatus.ClearSelection()
    End Sub

    Protected Sub ddlHolding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHolding.SelectedIndexChanged
        Sql(0) = " Select MAX( SUBSTRING( ComCode,3,3)) As [MaxComCode] From Master_Company " _
                & " Where ComCode not like '%999' "
        DT = M1.GetDatatable(Sql(0))
        Dim NoComCode As Integer = DT.Rows(0)("MaxComCode") + 1
        If ddlHolding.SelectedItem.ToString = "[--Please Select--]" Then
            lblComCode.Text = ""
        ElseIf ddlHolding.SelectedValue.ToString() = "AA" Then
            lblComCode.Text = "AA" + NoComCode.ToString()
        ElseIf ddlHolding.SelectedValue.ToString() = "PO" Then
            lblComCode.Text = "PO" + NoComCode.ToString()
        ElseIf ddlHolding.SelectedValue.ToString() = "QS" Then
            lblComCode.Text = "QS" + NoComCode.ToString()
        End If
    End Sub

    '--Click Save
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Check() = False Then
            Exit Sub
        End If

        Dim compCode As String = Trim(Me.lblComCode.Text)
        Dim compName As String = Trim(Me.txtName.Text)

        Dim id_comp As String = ddlCompany.SelectedValue.ToString()
        Dim holding As String = ddlHolding.SelectedValue.ToString()
        Dim lost_status As String = ""
        If rblStatus.SelectedIndex = 0 Then
            lost_status = "Y"
        ElseIf rblStatus.SelectedIndex = 1 Then
            lost_status = "N"
        End If

        Sql(0) = "insert into Master_Company (ComCode,ComName,ID_Company,Holding_Group,Status) values('" & compCode & "','" & compName & "','" & id_comp & "','" & holding & "','" & lost_status & "')"
        M1.Execute(Sql(0))
        alert("ดำเนินการเรียบร้อยแล้วค่ะ\nData is complete.")
        GridViewCompany.EditIndex = -1
        LoadData()

        txtName.Text = ""
        lblComCode.Text = ""
        ddlCompany.SelectedIndex() = 0
        ddlHolding.SelectedIndex() = 0
        rblStatus.ClearSelection()
    End Sub

    '--แสดง ddlID กับ rb_status ใน GridView
    Protected Sub GridViewCompany_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewCompany.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem
            Dim no As Integer = e.Row.RowIndex
            Dim itemNo As Integer = (ViewState("Page") * 10) + no

            Dim ddlID As DropDownList = e.Row.FindControl("ddlID")
            If Not IsNothing(ddlID) Then
                Sql(0) = "select ID_Company,Company_Code ,Company_Code + ' , ' + Company_NameT As companyName from HRMS.dbo.COM_Company"
                DT1 = M1.GetDatatable(Sql(0))
                ddlID.DataSource = DT1
                ddlID.DataTextField = "companyName"
                ddlID.DataValueField = "ID_Company"
                ddlID.DataBind()
                ddlID.SelectedValue = DT.Rows.Item(itemNo)("ID_Company").ToString
            End If

            Dim ddlHoldingID As DropDownList = e.Row.FindControl("ddlHoldingID")
            If Not IsNothing(ddlHoldingID) Then
                ddlHoldingID.SelectedValue = DT.Rows.Item(itemNo)("Holding_Group").ToString
            End If

            Dim rb_status As RadioButtonList = e.Row.FindControl("rb_status")
            If Not IsNothing(rb_status) Then
                rb_status.SelectedValue = DT.Rows.Item(itemNo)("Status").ToString
            End If
        End If
    End Sub

#End Region

#Region "Gridview"

    '--การจัดการภายใน GridView
    Protected Sub GridViewCostcenter_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridViewCompany.RowCancelingEdit
        GridViewCompany.EditIndex = -1
        Me.LoadData()
    End Sub

    Protected Sub GridViewCompany_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridViewCompany.RowEditing
        GridViewCompany.EditIndex = e.NewEditIndex
        'Bind data to the GridView control.
        Me.LoadData()
    End Sub

    Protected Sub GridViewCompany_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridViewCompany.RowUpdating
        Dim index As Integer = e.RowIndex
        Dim compCode As String = Me.GridViewCompany.DataKeys(index).Values(0).ToString()
        Dim compName As TextBox = CType(GridViewCompany.Rows(e.RowIndex).FindControl("txtComName"), TextBox)
        Dim comp As DropDownList = CType(GridViewCompany.Rows(e.RowIndex).FindControl("ddlID"), DropDownList)
        Dim rb_status As RadioButtonList = CType(GridViewCompany.Rows(e.RowIndex).FindControl("rb_status"), RadioButtonList)

        Sql(0) = "update Master_Company set ComName = '" & compName.Text & "', ID_Company = '" & comp.SelectedValue.ToString() & "' , Status = '" & rb_status.SelectedValue.ToString() & "' where ComCode = '" & compCode & "'"
        M1.Execute(Sql(0))
        alert("ดำเนินการเรียบร้อยแล้วค่ะ\nData is complete.")
        GridViewCompany.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub GridViewCompany_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridViewCompany.SelectedIndexChanging
        Dim K1 As DataKey = GridViewCompany.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub GridViewCompany_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewCompany.PageIndexChanging
        Me.GridViewCompany.PageIndex = e.NewPageIndex
        ViewState("Page") = Me.GridViewCompany.PageIndex
        LoadData()
    End Sub

#End Region

#Region "Search"

    Protected Sub chkHolding_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHolding.CheckedChanged
        ddlSearchHolding.Enabled = True
        chkComCode.Checked = False
        txtSearchComCode.Enabled = False
    End Sub

    Protected Sub chkComCode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkComCode.CheckedChanged
        txtSearchComCode.Enabled = True
        chkHolding.Checked = False
        ddlSearchHolding.Enabled = False
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkSearch() = False Then
            Exit Sub
        End If

        If chkHolding.Checked = True Then
            Dim holding As String = ddlSearchHolding.SelectedValue.ToString()
            Sql(0) = " select * , case when a.status = 'Y' then 'Use' else 'Not use' end as status1 ," _
               & " case when a.Holding_Group = 'AA' then 'AA : Paper Holding' when a.Holding_Group = 'PO' then 'PO : Power Holding'  else 'QS : Other Holding' end as Holding , " _
               & " Company_Code + ' , ' + b.Company_NameT as companyName from [TRUE].[dbo].[Master_Company] A" _
               & " join [HRMS].[dbo].[COM_Company] B on a.id_company = b.id_company " _
               & " Where a.Holding_Group = '" & holding & "' order by Holding_Group ASC, ComCode ASC "
            DT = M1.GetDatatable(Sql(0))
            GridViewCompany.DataSource = DT
            GridViewCompany.DataBind()
        Else
            Dim ComCode As String = txtSearchComCode.Text
            Sql(0) = " select * , case when a.status = 'Y' then 'Use' else 'Not use' end as status1 ," _
               & " case when a.Holding_Group = 'AA' then 'AA : Paper Holding' when a.Holding_Group = 'PO' then 'PO : Power Holding'  else 'QS : Other Holding' end as Holding , " _
               & " Company_Code + ' , ' + b.Company_NameT as companyName from [TRUE].[dbo].[Master_Company] A" _
               & " join [HRMS].[dbo].[COM_Company] B on a.id_company = b.id_company " _
               & " Where a.ComCode = '" & ComCode & "' order by Holding_Group ASC, ComCode ASC "
            DT = M1.GetDatatable(Sql(0))
            GridViewCompany.DataSource = DT
            GridViewCompany.DataBind()
        End If
    End Sub

    Protected Sub btnSearchCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCancel.Click
        LoadData()
        chkHolding.Checked = False
        chkComCode.Checked = False
        ddlSearchHolding.Enabled = False
        txtSearchComCode.Enabled = False
    End Sub

#End Region

End Class