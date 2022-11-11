<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 32px;
            width: 85px;
        }
        .style3
        {
            width: 351px;
        }
        .style4
        {
            height: 21px;
            width: 351px;
        }
        .style5
        {
            height: 32px;
            width: 351px;
        }
        .style6
        {
            height: 19px;
        }
        .style7
        {
            height: 19px;
            width: 351px;
        }
        .style8
        {
            width: 85px;
        }
        .style9
        {
            height: 21px;
            width: 85px;
        }
        .style10
        {
            height: 19px;
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    

    <Table ID="Table1">
    <tr><td class="style8">
        <asp:Literal ID="ltFirstName" runat="server" Text="First Name"></asp:Literal>
        </td><td class="style3">
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtFirstName" ErrorMessage="First Name Required" 
                ValidationGroup="1">*</asp:RequiredFieldValidator>
        </td></tr
    <tr></tr>
        <tr>
            <td class="style9">
        <asp:Literal ID="ltLastName" runat="server" Text="Last Name"></asp:Literal>
        </td><td class="style4">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Last Name Required" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </td>
            <tr>
                <td class="style9">
                    <asp:Literal ID="ltEmail" runat="server" Text="Email"></asp:Literal>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Email Required" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Invalid email address" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1">!</asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style10">
                    Gender</td>
                <td class="style7">
                    <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    Country</td>
                <td class="style7">
                    <asp:DropDownList ID="ddlCountry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style5">
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" ValidationGroup="1" />
                </td>
            </tr>
            <tr>
                <td class="style8">
                </td>
                <td class="style3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="country.CountryName" HeaderText="Country" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" onclick="btnEdit_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <table>
            </table>
        </tr>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

