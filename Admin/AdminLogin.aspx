<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .card {
            margin-top: 180px;
            width: 500px;
        }
    </style>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="css/my-login.css" />
</head>
<%--<body>
    <form id="form1" runat="server">
        <center>
            <div>
                <h1>Admin Login</h1>
                <table>
                    <tr>
                        <td>Username</td>
                        <td>
                            <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="BtnAdminLogin" runat="server" Text="Button" OnClick="BtnAdminLogin_Click" />
                          <%--  <asp:Label ID="lblMessage" runat="server"></asp:Label>--%>
<%--         </td>
                    </tr>
                </table>
            </div>
        </center>
    </form>



</body>--%>
<body class="my-login-page">
    <section class="h-100">
        <div class="container h-100">
            <div class="row justify-content-md-center h-100">
                <div class="card-wrapper">
                    <div class="card fat">
                        <div class="card-body">
                                <a href="../User/UserMainPage.aspx" class="float-right">Ecommerce Portal</a>
                            <h4 class="card-title">Admin Login</h4>
                            <form class="my-login-validation" novalidate="" runat="server">
                                <div class="form-group">
                                    <label for="email">Username</label>
                                    <asp:TextBox ID="TxtUsername" class="form-control" runat="server"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtUsername" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Username" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TxtUsername" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Font-Names="Rockwell" ControlToValidate="TxtUsername" ForeColor="Red"
                                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ValidationGroup="Val_cc"
                                        ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="password">
                                        Password									                                        										
                                    </label>
                                    <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" class="form-control" name="password"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtPassword" ForeColor="Red" Font-Names="Rockwell" runat="server" Display="Dynamic" ErrorMessage="Enter Password" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtPassword" Font-Names="Rockwell" ForeColor="Red"
                                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
                                        Display="Dynamic" ValidationGroup="Val_cc"
                                        ErrorMessage="At least one letter, one number and one special character"></asp:RegularExpressionValidator>                                   
                                </div>
                                <div class="form-group">
									<div class="custom-checkbox custom-control">
                                         <asp:CheckBox ID="remember" runat="server" CssClass="form-check-input" />
										Remember Me
									</div>
								</div>
                                <div class="form-group m-0">
                                    <asp:Button ID="BtnAdminLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="BtnAdminLogin_Click" ValidationGroup="Val_cc" />
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </section>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
