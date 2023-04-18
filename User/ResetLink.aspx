<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetLink.aspx.cs" Inherits="User_ResetLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <style>
        tr, td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server">
            <div class="form-group">
                <h4 class="text-primary">Add New Password</h4>
                <hr />
                <table class="style1">
                    <tr>
                        <td class="style2">New Password
                        </td>
                        <td>
                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtPassword" ForeColor="Red" runat="server" Display="Dynamic" Font-Names="Rockwell" ErrorMessage="Enter Password" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtPassword" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtPassword" Font-Names="Rockwell" ForeColor="Red"
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
                            <asp:Button ID="BtnForgotpassword" runat="server" Text="Save" OnClick="BtnForgotpassword_Click" CssClass=" btn btn-primary" ValidationGroup="Val_cc" />
                            <asp:Button ID="ResetData" runat="server" Text="Cancel" OnClick="ResetData_Click" CssClass="btn btn-danger" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </center>
</body>
</html>
