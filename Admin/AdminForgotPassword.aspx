<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AdminForgotPassword.aspx.cs" Inherits="Admin_AdminForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Reset Password</h4>
        <hr />
        <table>
            <tr>
                <td>Enter Email :</td>
                <td>
                    <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtUsername" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtUsername" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtUsername" ForeColor="Red"
                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnForgotPassword" runat="server" Text="Send" OnClick="BtnForgotPassword_Click" CssClass="btn btn-primary" ValidationGroup="Val_cc"  />
                    <asp:Button ID="ResetData" runat="server" Text="Cancel" OnClick="ResetData_Click" CssClass="btn btn-danger"  />

                </td>
                <td>
                    <asp:HiddenField ID="HidPassword" runat="server" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>

