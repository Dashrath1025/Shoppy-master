<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="ResetLink.aspx.cs" Inherits="Admin_ResetLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Add New Password</h4>
        <hr />
        <table class="style1">
            <tr>
                <td class="style2">New Password
                </td>
                <td>
                    <asp:TextBox ID="TxtPassword" runat="server"  TextMode="Password" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtPassword" ForeColor="Red" runat="server" Display="Dynamic" Font-Names="Rockwell" ErrorMessage="Enter Password" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtPassword" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtPassword" ForeColor="Red" Font-Names="Rockwell"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="At least one letter, one number and one special character"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="TxtCofrmPwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ControlToCompare="TxtPassword"
                        ControlToValidate="txtcofrmpwd" ErrorMessage="Password does not match" Font-Names="Rockwell" ValidationGroup="Val_cc"
                        ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">&nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnForgotpassword" runat="server" Text="Save" Width="156px" OnClick="BtnForgotpassword_Click" CssClass=" btn btn-primary" ValidationGroup="Val_cc" />
                    <asp:Button ID="ResetData" runat="server" Text="Cancel" Width="156px" OnClick="ResetData_Click" CssClass="btn btn-danger" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

