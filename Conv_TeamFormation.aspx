﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_TeamFormation.aspx.vb" Inherits="Test.Conv_TeamFormation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Team
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Team Formation
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
        <tr>
            <td align="center">
            <table width="100%">
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        Team Number</td>
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtTeamNum" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        Team Title</td>
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Team No"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtTeamTitle" runat="server" Width="171px" 
                        <asp:TextBox ID="txtNo" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td align="right" valign="top" width="47%">
                        Project Id</td>
                    <td align="center" valign="top" width="3%">
                <tr>
                    <td align="right" width="47%">
                        Team Name</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtprojId" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                    </tr>
                    <tr>
                    <td align="right" valign="top" width="47%">
                        Employee Enrol ID</td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtEnrolId" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                    </tr>
                    <tr>
                    <td align="right" width="47%">
                        &nbsp;</td>
                    <td align="center" width="3%">
                        &nbsp;</td>
                    <td align="left" width="50%">
                        &nbsp;</td>
                </tr>
                    <tr>
                    <td align="right" width="47%">
                        &nbsp;</td>
                    <td align="center" width="3%">
                        &nbsp;</td>
                    <td align="left" width="50%">
                        &nbsp;</td>
                        <asp:TextBox ID="txtName" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Supervisor"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlSupervisor" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                    </td>
                </tr>
                <tr><td align="center" colspan="3" height="20px"></td></tr>
            </table>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="teamId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="offUnitYear" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Semester" DataField="offUnitSem" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Unit" DataField="unitStr" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Project" SortExpression="projName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtProjName" runat="server" Text='<%# Bind("projName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblProjName" runat="server" Text='<%# Bind("projName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Team No" SortExpression="teamNo">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtTeamNo" runat="server" Text='<%# Bind("teamNo") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTeamNo" runat="server" Text='<%# Bind("teamNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Team Name" SortExpression="teamTitle">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtTeamName" runat="server" Text='<%# Bind("teamTitle") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTeamName" runat="server" Text='<%# Bind("teamTitle") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Supervisor" SortExpression="supStr">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtSup" runat="server" Text='<%# Bind("empName") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSup" runat="server" Text='<%# Bind("empName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
