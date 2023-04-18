<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AddNewAdmin.aspx.cs" Inherits="Admin_AddNewAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Add New Admin</h4>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="CatID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Username</td>
                <td>
                    <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtUsername" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Username" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtUsername" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Font-Names="Rockwell" runat="server" ControlToValidate="TxtUsername" ForeColor="Red"
                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtPassword" ForeColor="Red" Font-Names="Rockwell" runat="server" Display="Dynamic" ErrorMessage="Enter Password" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtPassword" Font-Names="Rockwell" ForeColor="Red"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="At least one letter, one number and one special character"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnNewAdmin" runat="server" Text="Create" OnClick="BtnNewAdmin_Click" ValidationGroup="Val_cc" CssClass="btn btn-primary" />
                    <%-- <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>--%>
                    <asp:Button ID="ResetData" runat="server" Text="Cancel" OnClick="ResetData_Click" CssClass="btn btn-danger" />

                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Admin Report
          <asp:Label ID="CountRow" runat="server" Style="float: right;"></asp:Label></h3>
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="table table-responsive">
                        <asp:GridView ID="ShowAdminDatas" runat="server" CssClass="table" OnSelectedIndexChanged="ShowAdminDatas_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Aid") %>' OnClick="lnkView_Click">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Aid" HeaderText="Admin Id" />
                                <asp:BoundField DataField="Username" HeaderText="UserName" />
                                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                                <asp:BoundField DataField="UpdationDate" HeaderText="Updation Date" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label Text="No Record Found" ForeColor="Red" runat="server"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

