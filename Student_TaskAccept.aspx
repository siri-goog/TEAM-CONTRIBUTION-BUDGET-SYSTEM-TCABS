<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_TaskAccept.aspx.vb" Inherits="Test.Student_TaskAccept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Accept Task Submission
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:GridView ID="gv_Show" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        EmptyDataText="---No Record---" PageSize="5">
        <Columns>
            <asp:TemplateField HeaderText="Project Details">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text="Unit :"></asp:Label>
                                <asp:Label ID="LB_EmpID" runat="server" Text='<%# Bind("unitStr") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label17" runat="server" CssClass="LabelMenu" Text="Project :"></asp:Label>
                                <asp:Label ID="LB_EmpName" runat="server" Text='<%# Bind("projName") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Task Description">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="Task :"></asp:Label>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("taskTitle") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label19" runat="server" CssClass="LabelMenu" Text="Task Desc :"></asp:Label>
                                <asp:Label ID="LB_TrueNo" runat="server" Text='<%# Bind("taskDesc") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label14" runat="server" CssClass="LabelMenu" Text="Role :"></asp:Label>
                                <asp:Label ID="LB_TrueComp" runat="server" Text='<%# Bind("tmRolName") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label16" runat="server" CssClass="LabelMenu" Text="Minutes Taken :"></asp:Label>
                                <asp:Label ID="LB_IR" runat="server" Text='<%# Bind("minutesTaken") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 10px">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:BoundField DataField="submitDate" HeaderText="Submit Date">
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="stuName" HeaderText="Submit By" Visible="False">
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px" Wrap="False" />
            </asp:BoundField>              
            <asp:TemplateField HeaderText="Your Approve">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 1px">
                        <tr>
                            <td align="left" style="height: 16px">
                            <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Approve Status :"></asp:Label><br />
                    <asp:RadioButtonList ID="RAD_YourApprove" runat="server" RepeatDirection="Horizontal" Width="170px" Font-Names="Verdana" Font-Size="8pt">
                        <asp:ListItem Value="Approved">Approve</asp:ListItem>
                        <asp:ListItem Value="Disapproved">Not approve</asp:ListItem>
                    </asp:RadioButtonList>
                                </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                                <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text="Comment :"></asp:Label><br />
                                <asp:TextBox ID="TB_Comment" runat="server"  ForeColor="Blue" Font-Names="vernada" Font-Size="8" Width="164px" Height="52px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 16px">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" VerticalAlign="Top" />
            </asp:TemplateField>  
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="sttApp" HeaderText="sttApp" Visible="False">
                <HeaderStyle Font-Bold="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:BoundField>
        </Columns>
        <PagerStyle BackColor="DeepSkyBlue" ForeColor="White" />
        <HeaderStyle CssClass="GridViewHeaderStyle" Font-Bold="False" />
    </asp:GridView>
    </center>
</asp:Content>
