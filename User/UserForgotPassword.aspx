<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserForgotPassword.aspx.cs" Inherits="User_UserForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Min/Values/Bootstrap/bootstrap.min.js"></script>
    <script src="../Min/Values/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style type="text/css">
        a:hover {
            text-decoration: underline !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <body marginheight="0" topmargin="0" marginwidth="0" style="margin: 0px; background-color: #f2f3f8;" leftmargin="0">
            <!--100% body table-->
            <table cellspacing="0" border="0" cellpadding="0" width="100%" bgcolor="#f2f3f8"
                style="@import url(https: //fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;">
                <tr>
                    <td>
                        <table style="background-color: #f2f3f8; max-width: 670px; margin: 0 auto;" width="100%" border="0"
                            align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 80px;">&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="height: 20px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0"
                                        style="max-width: 670px; background: #fff; border-radius: 3px; text-align: center; -webkit-box-shadow: 0 6px 18px 0 rgba(0,0,0,.06); -moz-box-shadow: 0 6px 18px 0 rgba(0,0,0,.06); box-shadow: 0 6px 18px 0 rgba(0,0,0,.06);">
                                        <tr>
                                            <td style="height: 40px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 0 35px;">
                                                <h1 style="color: #1e1e2d; font-weight: 500; margin: 0; font-size: 32px; font-family: 'Rubik',sans-serif;">You have
                                            requested to reset your password</h1>
                                                <span
                                                    style="display: inline-block; vertical-align: middle; margin: 29px 0 26px; border-bottom: 1px solid #cecece; width: 100px;"></span>
                                                <p style="color: #455056; font-size: 15px; line-height: 24px; margin: 0;">
                                                    We cannot simply send you your old password. A unique link to reset your
                                            password has been generated for you. To reset your password, click the
                                            following link and follow the instructions.
                                                </p>
                                                <br />
                                           
                                                Enter Email :
                                                <asp:TextBox ID="TxtUsername" runat="server" class="form-control input-small"  ></asp:TextBox><br />
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtUsername" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtUsername" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Font-Names="Rockwell" ControlToValidate="TxtUsername" ForeColor="Red"
                                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ValidationGroup="Val_cc"
                                        ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                                           
                                              
                                                <asp:Button ID="BtnForgotPassword" runat="server" Text="Reset Password" OnClick="BtnForgotPassword_Click" CssClass="btn btn-primary"  ValidationGroup="Val_cc"  style="background: #20e277; text-decoration: none !important; font-weight: 500; margin-top: 35px; color: #fff; text-transform: uppercase; font-size: 14px; padding: 10px 24px; display: inline-block; border-radius: 20px;" />
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px;">&nbsp; <a href="UserLogin.aspx" style="font-family:Rockwell;" >Back ?</a></td>
                                        </tr>
                                    </table>
                                </td>
                               
                        </table>
                    </td>
                </tr>
            </table>
            <!--/100% body table-->
        </body>

    </form>
</body>
</html>
