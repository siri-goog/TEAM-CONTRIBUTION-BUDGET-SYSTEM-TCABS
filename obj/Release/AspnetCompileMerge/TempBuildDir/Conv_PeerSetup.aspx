<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_PeerSetup.aspx.vb" Inherits="Test.Conv_PeerSetup" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    General Aspect Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>
        <tr>
            <td align="center" colspan="5">
                <table>
                    <tr>
                        <td>
                            Year
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="3%">&nbsp;</td>
                        <td>
                            Semester
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="3%">&nbsp;</td>
                        <td>
                            Unit
                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                    CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                    <asp:ListItem Value="1">Scoring</asp:ListItem>
                    <asp:ListItem Value="2">Budgeting</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="Peer Assessment No."></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="txtPeerNo" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Peer Assessment Name"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="TextBox1" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text="Start Date"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="TextBox2" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="End Date"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="TextBox3" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="tmRolId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>

                        <asp:TemplateField HeaderText="Select">
		                    <ItemTemplate>
			                    <asp:CheckBox id="chkSelect" onclick="fnEnableDisblePrice(this.id);" runat="server"></asp:CheckBox>
		                    </ItemTemplate>
	                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="General Aspect" SortExpression="projName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtGA" runat="server" Text='<%# Bind("projName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGA" runat="server" Text='<%# Bind("projName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Specific Aspect" SortExpression="tmRolName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtRole" runat="server" Text='<%# Bind("tmRolName") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server" Text='<%# Bind("tmRolName") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>

