<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="GetUserDetails.aspx.cs" Inherits="User_GetUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .borderbox {
            box-shadow: 0px 0px 8px 5px rgba(0, 0, 0, .4);
            width: 100%;
            background-color: whitesmoke;
            border-radius: 5px;
        }

        .col-md-4.mb-4 {
            margin-left: 2%;
            margin-top: 2%;
        }

        .col-md-4.mb-4 {
            margin-top: 2%;
        }

        .card-body {
            margin-top: 10.5%;
        }
    </style>
    <div class="borderbox">
        <div class="row" style="margin-top: 5%;">
            <div class="col-md-4 mb-4">
                <div class="card mb-4">
                    <div class="card-header py-3">
                        <h5 class="mb-0">Biling Address</h5>
                    </div>
                    <div class="card-body">

                        <!-- 2 column grid layout with text inputs for the first and last names -->

                        <div class="col">
                            <div class="form-outline">

                                <label class="form-label" for="form7Example1">First name</label>
                                <asp:TextBox ID="BillingFirstname" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="BillingFirstname" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Firstname" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingFirstname" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed."></asp:RegularExpressionValidator>

                            </div>

                        </div>
                        <div class="col">
                            <div class="form-outline">
                                <label class="form-label" for="form7Example2">Middle name</label>
                                <asp:TextBox ID="BillingMiddlename" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="BillingMiddlename" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Middlename" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingMiddlename" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed."></asp:RegularExpressionValidator>


                            </div>
                        </div>


                        <!-- Text input -->
                        <div class="form-outline mb-4">
                            <label class="form-label" for="form7Example3">Last name</label>
                            <asp:TextBox ID="BillingLastname" runat="server" class="form-control"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="BillingLastname" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Lastname" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingLastname" Font-Names="Rockwell" ID="RegularExpressionValidator3" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed."></asp:RegularExpressionValidator>


                        </div>

                        <!-- Text input -->
                        <div class="form-outline mb-4">
                            <label class="form-label" for="form7Example4">Email</label>
                            <asp:TextBox ID="BillingEmail" runat="server" class="form-control"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="BillingEmail" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingEmail" Font-Names="Rockwell" ID="RegularExpressionValidator4" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Font-Names="Rockwell" ControlToValidate="BillingEmail" ForeColor="Red"
                                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ValidationGroup="Val_cc"
                                ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                        </div>

                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <label class="form-label" for="form7Example5">Mobile No </label>

                            <asp:TextBox ID="BillingMobileno" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="BillingMobileno" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Mobileno" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingMobileno" Font-Names="Rockwell" ID="RegularExpressionValidator6" ValidationGroup="Val_cc" ValidationExpression="^[0-9]{0,10}$" runat="server" ErrorMessage="Maximum 10 characters allowed."></asp:RegularExpressionValidator>

                        </div>
                        <br /><br /><br />



                    </div>

                </div>
            </div>




            <!-- 2 column grid layout with text inputs for the first and last names -->

            <div class="col-md-4 mb-4">
                <div class="card mb-4">

                    <!-- Message input -->
                    <div class="form-outline mb-4">
                        <label class="form-label" for="form7Example7">Address</label>
                        <textarea class="form-control" id="BillingAddress" runat="server" rows="4"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="BillingAddress" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Address" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingAddress" Font-Names="Rockwell" ID="RegularExpressionValidator7" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,500}$" runat="server" ErrorMessage="Maximum 500 characters allowed."></asp:RegularExpressionValidator>

                    </div>
                    <!-- Number input -->

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-outline mb-4">
                                <label class="form-label" for="form7Example6">Country</label>
                                <asp:DropDownList ID="BillingCountry" runat="server" class="form-control" OnSelectedIndexChanged="BillingCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="BillingCountry" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select Country" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>

                            </div>
                            <div class="form-outline mb-4">
                                <label class="form-label" for="form7Example6">State</label>

                                <asp:DropDownList ID="BillingState" runat="server" class="form-control" OnSelectedIndexChanged="BillingState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="BillingState" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select State" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>

                            </div>
                            <div class="form-outline mb-4">
                                <label class="form-label" for="form7Example6">City</label>

                                <asp:DropDownList ID="BillingCity" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="BillingCity" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select City" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>

                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"
                                runat="server">
                                <ProgressTemplate>
                                    <div id="ajaxloader">
                                        Loading..
                               
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BillingCountry" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="BillingState" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="form-outline mb-4">
                        <label class="form-label" for="form7Example6">Pincode</label>

                        <asp:TextBox ID="BillingPincode" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="BillingPincode" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Pincode" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="BillingPincode" Font-Names="Rockwell" ID="RegularExpressionValidator8" ValidationGroup="Val_cc" ValidationExpression="^[0-9]{0,6}$" runat="server" ErrorMessage="Maximum 6 characters allowed."></asp:RegularExpressionValidator>

                    </div>
                </div>

            </div>

            <div class="col-md-3 mb-3">
                <div class="card mb-4">
                    <div class="card-header py-3">

                        <%--  <h5 class="mb-0">Summary</h5>--%>
                    </div>
                    <br />
                    <div class="card-body">
                        <ul class="list-group list-group-flush">

                            <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                                <div>
                                    <strong>Check to Proceed</strong>
                                </div>
                                <%--                                <strong>
                                    <p class="mb-0">
                                        <asp:RadioButton ID="RadioButton1" runat="server" Width="20" Checked="true" Text="Cash on delivery" />
                                    </p>

                                </strong>
                            </div>
                            <span><strong>
                                <p5 style="font-family: Rockwell; color: red;">Further Payment Option Arrived Comming Soon :)</p5>
                                <asp:Label ID="Label1" runat="server"></asp:Label></strong></span>--%>
                                <asp:Button ID="rzpbutton1" runat="server" Text="Check to Proceed" class="btn btn-primary btn-lg btn-block" CommandName="plaorder" CommandArgument='<%# Eval("ProductId") %>' ValidationGroup="Val_cc" OnClick="rzpbutton1_Click" />
                            </li>


                        </ul>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <script>
        var TotalAmount = sessionStorage.getItem("TotalPayableAmount");
        document.getElementById("<%=Label1.ClientID%>").innerText = TotalAmount;
    </script>--%>
</asp:Content>

