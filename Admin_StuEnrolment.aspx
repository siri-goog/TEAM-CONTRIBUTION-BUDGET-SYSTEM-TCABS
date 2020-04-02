<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_StuEnrolment.aspx.vb" Inherits="Test.Admin_StuEnrolment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Student Enrolment
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">

        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
            <table width="100%">
                <tr id="trSearchNo" runat="server">
                    <td align="right">
                        <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu" 
                            Text="Searching by Student ID or Name"></asp:Label>&nbsp;
                    </td>
                    <td align="center"> : </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtSearchStu" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="Btn" />
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
                                                    <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="GridViewBodyStyle">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Student ID" DataField="StuID" ReadOnly="True" />
                                                            <asp:BoundField HeaderText="Name" DataField="StuName" ReadOnly="True"/>
                                                            <asp:BoundField HeaderText="Level" DataField="StuName" ReadOnly="True"/>
                                                            <asp:CommandField ShowSelectButton="True" />
                                                        </Columns>
                                                        <%--<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />--%>
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
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnQueryData" runat="server" Visible="False">
                            <table width="100%">
                                <tr><td height="20px"></td></tr>
                                <tr>
                                    <td align="center" >
                                        <table width="100%">
                                            <tr>
                                                <td align="right" width="48%" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Student ID"></asp:Label>
                                                </td>
                                                <td align="center" valign="top" class="style11" >
                                                    <asp:Label ID="Label17" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                                </td>
                                                <td align="left" width="50%" valign="top" ><asp:Label ID="lblID" 
                                                        runat="server" CssClass="LabelData"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text="Student Name"></asp:Label>
                                                </td>
                                                <td align="center" valign="top" class="style11">
                                                    <asp:Label ID="Label18" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                                </td>
                                                <td align="left" valign="top"><asp:Label ID="lblName" runat="server" 
                                                        CssClass="LabelData"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text="Student Level"></asp:Label>
                                                </td>
                                                <td align="center" valign="top" class="style11">
                                                    <asp:Label ID="Label19" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                                </td>
                                                <td align="left" valign="top"><asp:Label ID="lblLevel" runat="server" 
                                                        CssClass="LabelData"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td height="20px"></td></tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Year"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Semester"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="False">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            <asp:ListItem Value="2">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Unit Code"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="False">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            <asp:ListItem Value="Certificate">Certificate</asp:ListItem>
                            <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                            <asp:ListItem Value="Bachelor">Bachelor</asp:ListItem>
                            <asp:ListItem Value="Master">Master</asp:ListItem>
                            <asp:ListItem Value="PhD">PhD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Unit Name"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:Label ID="lblUnitCode" runat="server" 
                                                        CssClass="LabelData"></asp:Label>
                        
                    </td>
                </tr>
                    <tr>
                    <td align="right" width="47%">
                        Description</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:Label ID="lblUnitDesc" runat="server" 
                                                        CssClass="LabelData"></asp:Label>
                        </td>
                </tr>
                    <tr>
                    <td align="right" width="47%">
                        Credit</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:Label ID="lblCredit" runat="server" 
                                                        CssClass="LabelData"></asp:Label></td>
                </tr>
                    
                    <tr><td align="center" colspan="3"></td></tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="Btn" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" height="20px"></td></tr>
                </table>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvUnit" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ComCode" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Unit Code" DataField="UnitCode" ReadOnly="True" >

                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Unit Name" SortExpression="ComName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtUnitName" runat="server" Text='<%# Bind("UnitName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUnitName" runat="server" Text='<%# Bind("UnitName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="UnitDesc">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtUnitDesc" runat="server" Text='<%# Bind("UnitDesc") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUnitDesc" runat="server" Text='<%# Bind("UnitDesc") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Credit">
                            <%--<EditItemTemplate>
                                <asp:DropDownList ID="ddlHoldingID" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="AA">AA : Paper Holding</asp:ListItem>
                                    <asp:ListItem Value="PP">PP : Power Holding</asp:ListItem>
                                    <asp:ListItem Value="QS">QS : Other Holding</asp:ListItem>
                                </asp:DropDownList>
                           </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblCredit" runat="server" Text='<%# Bind("UnitCredit") %>' Width="100px"></asp:Label>
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
