<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_MeetingMinutes.aspx.vb" Inherits="Test.Student_MeetingMinutes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Meeting
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Minutes Meeting
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">

        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
            <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Unit Code"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Team"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label16" runat="server" CssClass="LabelMenu" Text="Meeting"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label18" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlMeeting" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Catagory"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlCatagory" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            <asp:ListItem Value="1">Last Meeting</asp:ListItem>
                            <asp:ListItem Value="2">Present</asp:ListItem>
                            <asp:ListItem Value="3">Next Meeting</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">Minutes Title</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            <asp:ListItem Value="99">Other</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <asp:TextBox ID="txtOther" runat="server" Width="171px" visible="false"
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">Minutes Details</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtDetails" runat="server" Width="171px" visible="false"
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text="Action Point"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            <asp:ListItem Value="1">Discussion</asp:ListItem>
                            <asp:ListItem Value="2">Decision</asp:ListItem>
                            <asp:ListItem Value="3">Agreement</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">Action Details</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label14" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtActionDetails" runat="server" Width="171px" visible="false"
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr><td align="center" colspan="3">&nbsp;</td></tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                    </td>
                </tr>
                <tr><td align="center" colspan="3">&nbsp;</td></tr>
                <tr id="trSearchNo" runat="server">
                    <td align="right">
                        <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu" 
                            Text="Searching by Meeting"></asp:Label>&nbsp;
                    </td>
                    <td align="center"> : </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnQuerySearch" runat="server" Visible="false">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr><td height="20px">&nbsp;</td></tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                                                        DataKeyNames="meetingId" 
                                                        AllowPaging="True" CssClass="GridViewBodyStyle" 
                                                        EmptyDataText="---No Record---">
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
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" Wrap="False" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Meeting Details" SortExpression="meetingDate">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtMeetingDate" runat="server" Text='<%# Bind("meetingDate") %>' ></asp:Textbox>
                                                               </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMeetingDate" runat="server" Text='<%# Bind("meetingDate") %>' Width="200px"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Start Time" SortExpression="startTime">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtStartTime" runat="server" Text='<%# Bind("startTime") %>' ></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("startTime") %>' Width="250px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="200px" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="End Time" SortExpression="stulevel">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtEndTime" runat="server" Text='<%# Bind("endTime") %>' ></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("endTime") %>' Width="250px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="200px" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Location" SortExpression="stulevel">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtEndTime" runat="server" Text='<%# Bind("location") %>' ></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("location") %>' Width="250px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="200px" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:BoundField HeaderText="Status" DataField="meetingStatus" ReadOnly="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:BoundField>

                                                            <asp:CommandField ShowEditButton="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:CommandField>

                                                            <asp:CommandField ShowDeleteButton="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr><td align="center" colspan="3" height="20px"></td></tr>
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
