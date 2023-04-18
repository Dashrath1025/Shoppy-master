<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSignup.aspx.cs" Inherits="User_UserSignup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Signup Page</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <style>
        .card {
            margin-top: 10px;
            width: 500px;
        }

        input#ContentPlaceHolder1_Email {
            display: block;
            width: 120%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        }

        .btn-primary {
            margin-left: 5%;
        }

        body {
            background-color: whitesmoke
        }

        .height-100 {
            height: 100vh
        }

        .card {
            width: 500px;
            border: none;
            height: 430px;
            box-shadow: 0px 5px 20px 0px #d2dae3;
            z-index: 1;
            display: flex;
            justify-content: center;
            align-items: center
        }

            .card h6 {
                color: red;
                font-size: 20px
            }

        .inputs input {
            width: 40px;
            height: 40px
        }

        input[type=number]::-webkit-inner-spin-button, input[type=number]::-webkit-outer-spin-button {
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            margin: 0
        }

        .card-2 {
            background-color: #fff;
            padding: 10px;
            width: 350px;
            height: 100px;
            bottom: -50px;
            left: 20px;
            position: absolute;
            border-radius: 5px
        }

            .card-2 .content {
                margin-top: 50px
            }

                .card-2 .content a {
                    color: red
                }

        .form-control:focus {
            box-shadow: none;
            border: 2px solid red
        }

        .validate {
            border-radius: 20px;
            height: 40px;
            background-color: red;
            border: 1px solid red;
            width: 140px
        }

        #BtnUserLogin:hover {
            background-color: #ff6a00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container height-100 d-flex justify-content-center align-items-center">
            <div class="position-relative">
                <div class="card p-2 text-center">
                    <h3 style="color:red;">Signup</h3>
                   <hr />
                    <h6>Please enter the one time password
                    <br />
                        to verify your account</h6>
                    <br />
                    <div>
                        <span>Enter Email </span>
                        <asp:TextBox ID="Email" runat="server" Width="220px" BorderStyle="Groove" Style="border-radius: 4px;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnUserSignup" runat="server" ValidationGroup="Val_cc" Text="Get Otp" class="btn btn-danger" Style="border-radius: 4px; background-color: #dc3545; color: white;" Height="40px" OnClick="BtnUserSignup_Click"/><br />


                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Email" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="Email" Font-Names="Rockwell" ID="RegularExpressionValidator4" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Font-Names="Rockwell" ControlToValidate="Email" ForeColor="Red"
                            ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            Display="Dynamic" ValidationGroup="Val_cc"
                            ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div id="otp" class="inputs d-flex flex-row justify-content-center mt-2">
                        <asp:TextBox ID="first" runat="server" class="m-2 text-center form-control rounded" MaxLength="1"></asp:TextBox>
                        <asp:TextBox ID="second" runat="server" class="m-2 text-center form-control rounded" MaxLength="1"></asp:TextBox>
                        <asp:TextBox ID="third" runat="server" class="m-2 text-center form-control rounded" MaxLength="1"></asp:TextBox>
                        <asp:TextBox ID="fourth" runat="server" class="m-2 text-center form-control rounded" MaxLength="1"></asp:TextBox>
                    </div>
                    <div class="mt-4">
                        <asp:Button ID="Verifyotp" runat="server" class="btn btn-danger px-4 validate" Text="Validate" OnClick="Verifyotp_Click" />

                    </div>
                </div>
                  <div class="card-2">
                    <div class="content d-flex justify-content-center align-items-center"><span>Already Account ?</span> <a href="UserLogin.aspx" class="text-decoration-none ms-3">Login </a> </div>
                </div>
            </div>
        </div>



    </form>
</body>
</html>
