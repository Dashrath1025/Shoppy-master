<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="User_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb">
        <div class="container">
            <div class="breadcrumb-inner">
                <ul class="list-inline list-unstyled">
                    <li><a href="#">Home</a></li>
                    <li class='active'>Contact</li>
                </ul>
            </div>
            <!-- /.breadcrumb-inner -->
        </div>
        <!-- /.container -->
    </div>
    <!-- /.breadcrumb -->

    <div class="body-content">
        <div class="container">
            <div class="contact-page">
                <div class="row" style="width: 100% !important;">

                    <div class="col-md-12 contact-map outer-bottom-vs">
                        <%--    <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d14878.37844556218!2d72.86421262641397!3d21.208257224420862!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s46%20Prabhudarshan%20Society%20shyamdham%20chowk%2C%20Punagam%2C%20Varachha%2C%20Surat%2C%20Gujarat!5e0!3m2!1sen!2sin!4v1672411035078!5m2!1sen!2sin" frameborder="0" allowfullscreen="" aria-hidden="false" tabindex="0" style="border: 0;width:100%;height:400px;"></iframe>--%>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m23!1m12!1m3!1d3718.9580485045217!2d72.86141771473518!3d21.23351208588786!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m8!3e6!4m0!4m5!1s0x3be04f2652963ac9%3A0x7d9787a5b5c4275d!2sSilver%20Business%20Point%2C%20near%2C%204015%20silver%20business%20point%2C%20VIP%20Cir%2C%20Uttran%2C%20Surat%2C%20Gujarat%20394105!3m2!1d21.2335121!2d72.8636064!5e0!3m2!1sen!2sin!4v1672412254008!5m2!1sen!2sin" style="border: 0; width: 100%; height: 400px;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>

                    </div>
                    <div class="col-md-8 contact-form">
                        <div class="col-md-12 contact-title">
                            <h4>Contact Form</h4>
                        </div>
                        <div class="col-md-4 ">

                            <div class="form-group">
                                <label class="info-title" for="exampleInputName">Your Name <span>*</span></label>
                                <asp:TextBox ID="exampleInputName" runat="server" class="form-control unicase-form-control text-input"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="exampleInputName" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="exampleInputName" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label class="info-title" for="exampleInputEmail1">Email Address <span>*</span></label>
                                <asp:TextBox ID="exampleInputEmail1" runat="server" class="form-control unicase-form-control text-input"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="exampleInputEmail1" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="exampleInputEmail1" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Font-Names="Rockwell" runat="server" ControlToValidate="exampleInputEmail1" ForeColor="Red"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    Display="Dynamic" ValidationGroup="Val_cc"
                                    ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label class="info-title" for="exampleInputTitle">Title <span>*</span></label>
                                <asp:TextBox ID="exampleInputTitle" runat="server" class="form-control unicase-form-control text-input"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="exampleInputTitle" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Title" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="exampleInputTitle" Font-Names="Rockwell" ID="RegularExpressionValidator3" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>

                            </div>

                        </div>
                        <div class="col-md-12">

                            <div class="form-group">
                                <label class="info-title" for="exampleInputComments">Your Comments <span>*</span></label>
                                <textarea class="form-control unicase-form-control" ID="exampleInputComments" runat="server"></textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="exampleInputComments" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Description" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="exampleInputComments" Font-Names="Rockwell" ID="RegularExpressionValidator4" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,2000}$" runat="server" ErrorMessage="Maximum 2000 characters allowed."></asp:RegularExpressionValidator>

                            </div>
                        </div>
                        <div class="col-md-12 outer-bottom-small m-t-20">
                            <asp:Button ID="SendMessage" runat="server" Text="Send Message" class="btn-upper btn btn-primary checkout-page-button" ValidationGroup="Val_cc" OnClick="SendMessage_Click"  />
                        </div>
                    </div>
                    <div class="col-md-4 contact-info">
                        <div class="contact-title">
                            <h4>Information</h4>
                        </div>
                        <div class="clearfix address">
                            <span class="contact-i"><i class="fa fa-map-marker"></i></span>
                            <span class="contact-span">Silver Bussiness, 435 VIP Road,Utran, Gujarat INDIA</span>
                        </div>
                        <div class="clearfix phone-no">
                            <span class="contact-i"><i class="fa fa-mobile"></i></span>
                            <span class="contact-span">+(91) 63597 00000<br>
                                +(91) 72808 60006</span>
                        </div>
                        <div class="clearfix email">
                            <span class="contact-i"><i class="fa fa-envelope"></i></span>
                            <span class="contact-span"><a href="#">shoppingcart@gmail.com</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.contact-page -->
    </div>
    <!-- /.row -->
</asp:Content>

