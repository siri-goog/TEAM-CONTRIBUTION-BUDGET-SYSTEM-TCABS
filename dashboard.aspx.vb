Public Class dashboard
    Inherits System.Web.UI.Page

    Sub checkMenu()
        Me.divAdmin.Style.Value = "Display:none"
        Me.divConvenor.Style.Value = "Display:none"
        Me.divSupervisor.Style.Value = "Display:none"
        Me.divStudent.Style.Value = "Display:none"

        Dim userRole() As String = Session("userRole").ToString().Trim().Split(",")
        Dim i As Integer = 0
        For i = 0 To userRole.Length - 1
            If userRole(i) = "Admin" Then 'Admin
                Me.divAdmin.Style.Value = ""
            ElseIf userRole(i) = "Convenor" Then 'Convenor
                Me.divConvenor.Style.Value = ""
            ElseIf userRole(i) = "Supervisor" Then 'Supervisor
                Me.divSupervisor.Style.Value = ""
            End If
        Next

        If Session("userRole") = "Student" Then
            Me.divStudent.Style.Value = ""
        End If
    End Sub

    Sub checkDashboard()
        If Session("userRole") = "Admin" Then

        ElseIf Session("userRole") = "Student" Then
            SQL(0) = " Select a. offUnitId, concat(c.unitId , ' - ', c.unitName) as unitStr, " _
                & " b.offUnitYear, concat( 'Semester ', b.offUnitSem) as semStr " _
                & " From enrolment a " _
                & " join offeredunit b " _
                & " on a.offUnitId = b.offUnitId " _
                & " join unit c " _
                & " on b.unitId = c.unitId " _
                & " where a.stuId = " & Session("userID") & " " _
                & " And curdate() between offUnitStart and offUnitEnd "
            DT = M1.GetDatatable(SQL(0))
            gvDashboard.DataSource = DT
            gvDashboard.DataBind()
        Else '-- Convenor or Supervisor
            SQL(0) = " Select a. offUnitId, concat(c.unitId , ' - ', c.unitName) as unitStr, " _
                & " b.offUnitYear, concat( 'Semester ', b.offUnitSem) as semStr " _
                & " From enrolment a " _
                & " join offeredunit b " _
                & " on a.offUnitId = b.offUnitId " _
                & " join unit c " _
                & " on b.unitId = c.unitId " _
                & " where a.stuId = " & Session("userID") & " " _
                & " And curdate() between offUnitStart and offUnitEnd "
            DT = M1.GetDatatable(SQL(0))
            gvDashboard.DataSource = DT
            gvDashboard.DataBind()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkMenu()
        checkDashboard()
    End Sub

End Class