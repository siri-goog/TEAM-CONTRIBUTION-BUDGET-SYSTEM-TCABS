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

        If ddlcompany.selecteditem.tostring = " [-- please select --] " Then
            Me.ddlcompany.focus()
            alert("กรุณาเลือกบริษัท\nplease select company")
            chk = 0
        Else
            If ddlholding.selecteditem.tostring = " [-- please select --] " Then
                Me.ddlholding.focus()
                alert("กรุณาเลือกกลุ่มบริษัท\nplease select holding")
                chk = 0
            ElseIf txtname.text = "" Then
                Me.txtname.focus()
                alert("กรุณาระบุชื่อบริษัท\nplease add company name")
                chk = 0
            ElseIf rblstatus.selectedvalue = "" Then
                Me.rblstatus.focus()
                alert("กรุณาระบุสถานะการใช้งาน\nplease select status")
                chk = 0
            End If
        End If


        Sql(0) = "select comcode from master_company where comcode = '" & Me.lblcomcode.text & "' "
        dt = m1.getdatatable(Sql(0))
        If dt.rows.count > 0 Then
            alert("รหัสบริษัทนี้ได้รับการเพิ่มแล้วค่ะ\nthis company code is already exist")
            chk = 0
        End If


        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    '--check ว่าเวลาต้องเลือกค้นหาตาม holding หรือ comcode
    Function chksearch() As Boolean
        Dim chk As String = 1

        If chkholding.checked = False And chkcomcode.checked = False Then
            alert("กรุณาเลือกประเภทการค้นหาค่ะ\nplease select search type")
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
        Sql(0) = " select * , case when a.status = 'y' then 'use' else 'not use' end as status1 ," _
               & " case when a.holding_group = 'aa' then 'aa : paper holding' when a.holding_group = 'po' then 'po : power holding'  else 'qs : other holding' end as holding , " _
               & " company_code + ' , ' + b.company_namet as companyname from [true].[dbo].[master_company] a" _
               & " join [hrms].[dbo].[com_company] b on a.id_company = b.id_company " _
               & " order by holding_group asc, comcode asc "
        dt = m1.getdatatable(Sql(0))
        gvStudent.DataSource = dt
        gvStudent.DataBind()
    End Sub

    --แสดง ddlcompany
    Sub loadcompanycode()
        Sql(0) = " select id_company, company_code as companycode ,company_code + ' , ' + company_namet as companyname " _
                & " from hrms.dbo.com_company order by companyname asc"
        dt = m1.getdatatable(Sql(0))
        Try
            ddlcompany.datatextfield = "companyname"
            ddlcompany.datavaluefield = "id_company"
        Catch ex As Exception
            ddlcompany.datatextfield = ""
            ddlcompany.datavaluefield = ""
        End Try
        Me.ddlcompany.datasource = dt
        Me.ddlcompany.databind()
        Me.ddlcompany.items.insert(0, " [-- please select --] ")
    End Sub

    --แสดงข้อมูลทุกครั้งที่ load page ขึ้นมา
    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("userid") = "26018"
        If Not Page.IsPostBack Then
            loaddata()
            loadcompanycode()
        End If
    End Sub

    --click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lblcomcode.text = ""
        txtname.text = ""
        ddlcompany.selectedindex() = 0
        ddlholding.selectedindex() = 0
        rblstatus.selectedvalue = False
        rblstatus.clearselection()
    End Sub

    Protected Sub ddlholding_selectedindexchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlholding.selectedindexchanged
        Sql(0) = " select max( substring( comcode,3,3)) as [maxcomcode] from master_company " _
                & " where comcode not like '%999' "
        dt = m1.getdatatable(Sql(0))
        Dim nocomcode As Integer = dt.rows(0)("maxcomcode") + 1
        If ddlholding.selecteditem.tostring = "[--please select--]" Then
            lblcomcode.text = ""
        ElseIf ddlholding.selectedvalue.tostring() = "aa" Then
            lblcomcode.text = "aa" + nocomcode.ToString()
        ElseIf ddlholding.selectedvalue.tostring() = "po" Then
            lblcomcode.text = "po" + nocomcode.ToString()
        ElseIf ddlholding.selectedvalue.tostring() = "qs" Then
            lblcomcode.text = "qs" + nocomcode.ToString()
        End If
    End Sub

    --click save
    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim compcode As String = Trim(Me.lblcomcode.text)
        Dim compname As String = Trim(Me.txtname.text)

        Dim id_comp As String = ddlcompany.selectedvalue.tostring()
        Dim holding As String = ddlholding.selectedvalue.tostring()
        Dim lost_status As String = ""
        If rblstatus.selectedindex = 0 Then
            lost_status = "y"
        ElseIf rblstatus.selectedindex = 1 Then
            lost_status = "n"
        End If

        Sql(0) = "insert into master_company (comcode,comname,id_company,holding_group,status) values('" & compcode & "','" & compname & "','" & id_comp & "','" & holding & "','" & lost_status & "')"
        m1.execute(Sql(0))
        alert("ดำเนินการเรียบร้อยแล้วค่ะ\ndata is complete.")
        gridviewcompany.editindex = -1
        loaddata()

        txtname.text = ""
        lblcomcode.text = ""
        ddlcompany.selectedindex() = 0
        ddlholding.selectedindex() = 0
        rblstatus.clearselection()
    End Sub

    --แสดง ddlid กับ rb_status ใน gridview
    Protected Sub gridviewcompany_rowdatabound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridviewcompany.rowdatabound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem
            Dim no As Integer = e.Row.RowIndex
            Dim itemno As Integer = (ViewState("page") * 10) + no

            Dim ddlid As DropDownList = e.Row.FindControl("ddlid")
            If Not IsNothing(ddlid) Then
                Sql(0) = "select id_company,company_code ,company_code + ' , ' + company_namet as companyname from hrms.dbo.com_company"
                dt1 = m1.getdatatable(Sql(0))
                ddlid.DataSource = dt1
                ddlid.DataTextField = "companyname"
                ddlid.DataValueField = "id_company"
                ddlid.DataBind()
                ddlid.SelectedValue = dt.rows.item(itemno)("id_company").tostring
            End If

            Dim ddlholdingid As DropDownList = e.Row.FindControl("ddlholdingid")
            If Not IsNothing(ddlholdingid) Then
                ddlholdingid.SelectedValue = dt.rows.item(itemno)("holding_group").tostring
            End If

            Dim rb_status As RadioButtonList = e.Row.FindControl("rb_status")
            If Not IsNothing(rb_status) Then
                rb_status.SelectedValue = dt.rows.item(itemno)("status").tostring
            End If
        End If
    End Sub

#end region

#region "gridview"

    --การจัดการภายใน gridview
    Protected Sub gridviewcostcenter_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridviewcompany.rowcancelingedit
        gridviewcompany.editindex = -1
        Me.loaddata()
    End Sub

    Protected Sub gridviewcompany_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridviewcompany.rowediting
        gridviewcompany.editindex = e.NewEditIndex
        bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gridviewcompany_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridviewcompany.rowupdating
        Dim index As Integer = e.RowIndex
        Dim compcode As String = Me.gridviewcompany.datakeys(index).values(0).tostring()
        Dim compname As TextBox = CType(gridviewcompany.rows(e.RowIndex).findcontrol("txtcomname"), TextBox)
        Dim comp As DropDownList = CType(gridviewcompany.rows(e.RowIndex).findcontrol("ddlid"), DropDownList)
        Dim rb_status As RadioButtonList = CType(gridviewcompany.rows(e.RowIndex).findcontrol("rb_status"), RadioButtonList)

        Sql(0) = "update master_company set comname = '" & compname.Text & "', id_company = '" & comp.SelectedValue.ToString() & "' , status = '" & rb_status.SelectedValue.ToString() & "' where comcode = '" & compcode & "'"
        m1.execute(Sql(0))
        alert("ดำเนินการเรียบร้อยแล้วค่ะ\ndata is complete.")
        gridviewcompany.editindex = -1
        loaddata()

    End Sub

    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridviewcompany.selectedindexchanging
        Dim k1 As DataKey = gridviewcompany.datakeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridviewcompany.pageindexchanging
        Me.gridviewcompany.pageindex = e.NewPageIndex
        ViewState("page") = Me.gridviewcompany.pageindex
        loaddata()
    End Sub

#End Region

#Region "search"

    Protected Sub chkholding_checkedchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkholding.checkedchanged
        ddlsearchholding.enabled = True
        chkcomcode.checked = False
        txtsearchcomcode.enabled = False
    End Sub

    Protected Sub chkcomcode_checkedchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcomcode.checkedchanged
        txtsearchcomcode.enabled = True
        chkholding.checked = False
        ddlsearchholding.enabled = False
    End Sub

    Protected Sub btnsearch_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chksearch() = False Then
            Exit Sub
        End If

        If chkholding.checked = True Then
            Dim holding As String = ddlsearchholding.selectedvalue.tostring()
            Sql(0) = " select * , case when a.status = 'y' then 'use' else 'not use' end as status1 ," _
               & " case when a.holding_group = 'aa' then 'aa : paper holding' when a.holding_group = 'po' then 'po : power holding'  else 'qs : other holding' end as holding , " _
               & " company_code + ' , ' + b.company_namet as companyname from [true].[dbo].[master_company] a" _
               & " join [hrms].[dbo].[com_company] b on a.id_company = b.id_company " _
               & " where a.holding_group = '" & holding & "' order by holding_group asc, comcode asc "
            dt = m1.getdatatable(Sql(0))
            gridviewcompany.datasource = dt
            gridviewcompany.databind()
        Else
            Dim comcode As String = txtsearchcomcode.text
            Sql(0) = " select * , case when a.status = 'y' then 'use' else 'not use' end as status1 ," _
               & " case when a.holding_group = 'aa' then 'aa : paper holding' when a.holding_group = 'po' then 'po : power holding'  else 'qs : other holding' end as holding , " _
               & " company_code + ' , ' + b.company_namet as companyname from [true].[dbo].[master_company] a" _
               & " join [hrms].[dbo].[com_company] b on a.id_company = b.id_company " _
               & " where a.comcode = '" & comcode & "' order by holding_group asc, comcode asc "
            dt = m1.getdatatable(Sql(0))
            gridviewcompany.datasource = dt
            gridviewcompany.databind()
        End If
    End Sub

    Protected Sub btnsearchcancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCancel.Click
        loaddata()
        chkholding.checked = False
        chkcomcode.checked = False
        ddlsearchholding.enabled = False
        txtsearchcomcode.enabled = False
    End Sub

#End Region

End Class