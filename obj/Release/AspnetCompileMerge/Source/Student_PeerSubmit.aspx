<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_PeerSubmit.aspx.vb" Inherits="Test.Student_PeerSubmit" %>
<%-- <asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Student
</asp:Content> --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Accept Task Submission
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <table width="100%">
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                    CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Team Member"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="true" 
                    CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gv_Show" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="---No Record---" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="General Aspect">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sttApp" HeaderText="Specific Aspect">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Score" SortExpression="startTime">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtStartTime" runat="server" Text='<%# Bind("startTime") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("startTime") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="DeepSkyBlue" ForeColor="White" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" Font-Bold="False" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </center>
</asp:Content>
