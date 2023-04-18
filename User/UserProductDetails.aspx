<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="UserProductDetails.aspx.cs" Inherits="User_UserProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Theme styles START -->
    <link href="../assets/pages/css/components.css" rel="stylesheet">
    <link href="../assets/corporate/css/style.css" rel="stylesheet">
    <link href="../assets/pages/css/style-shop.css" rel="stylesheet" type="text/css">
    <link href="../assets/corporate/css/style-responsive.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        img.zoom {
            width: 290px;
            height: 150px;
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
        }

        img.zoom1 {
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
        }

        img.zoom2 {
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
        }

        img.zoom3 {
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
        }

        .transition {
            -webkit-transform: scale(1.3);
            -moz-transform: scale(1.3);
            -o-transform: scale(1.3);
            transform: scale(1.3);
        }

        .transition1 {
            -webkit-transform: scale(1.5);
            -moz-transform: scale(1.5);
            -o-transform: scale(1.5);
            transform: scale(1.5);
        }

        .productDis {
            margin-left: 15%;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <%-- <script type="text/javascript">
          function zoomin() {
              var GFG = document.getElementById("item2");
              var currWidth = GFG.clientWidth;
              GFG.style.width = (currWidth + 100) + "px";
          }

          function zoomout() {
              var GFG = document.getElementById("img");
              var currWidth = GFG.clientWidth;
              GFG.style.width = (currWidth - 100) + "px";
          }
      </script>--%>
    <script>
        $(document).ready(function () {
            $('.zoom').hover(function () {
                $(this).addClass('transition');
            }, function () {
                $(this).removeClass('transition');
            });
        });
        $(document).ready(function () {
            $('.zoom1').hover(function () {
                $(this).addClass('transition1');
            }, function () {
                $(this).removeClass('transition1');
            });
        });
        $(document).ready(function () {
            $('.zoom2').hover(function () {
                $(this).addClass('transition1');
            }, function () {
                $(this).removeClass('transition1');
            });
        });
        $(document).ready(function () {
            $('.zoom3').hover(function () {
                $(this).addClass('transition1');
            }, function () {
                $(this).removeClass('transition1');
            });
        });
    </script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <br />
    <br />
    <br />
    <%--<button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button">
        Cart <span id="CartBadge" runat="server" class="badge">0</span>
    </button>--%>
    <br />
    <div class="main">
        <div class="container">
            <!-- BEGIN CONTENT -->
            <div class="productDis">
                <div class="col-md-9 col-sm-7">
                    <div class="product-page">
                        <asp:Repeater ID="ProductDescriptionData" runat="server">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <div class="product-main-image">
                                            <asp:Image ID="item1" runat="server" onclick="zoomin()" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' alt="img" class="zoom" />

                                        </div>
                                        <div class="product-other-images">
                                            <a href="#" class="fancybox-button" rel="photos-lib">
                                                <asp:Image ID="item2" runat="server" class="zoom1" alt="Berry Lace Dress" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />

                                                <%--<img id="item2" class="zoom1" alt="Berry Lace Dress" src="../UploadedImages/<%# Eval("ProductImage1") %>"></a>--%>
                                                <a href="#" class="fancybox-button" rel="photos-lib">
                                                  <%--  <asp:Image ID="Image1" runat="server" class="zoom1" alt="Berry Lace Dress" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />

                                                    <img id="item3" class="zoom2" alt="Berry Lace Dress" src="../UploadedImages/<%# Eval("ProductImage2") %>"></a>--%>
                                                <asp:Image ID="item3" runat="server" class="zoom2" alt="Berry Lace Dress" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage2").ToString())%>' />
                                                
                                                <a href="#" class="fancybox-button" rel="photos-lib">
                                                    <asp:Image ID="item4" runat="server" class="zoom3" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage3").ToString())%>'/>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <h1 style="font-family: Rockwell; color: black;"><%# Eval ("productName") %></h1>
                                        <div class="product-page-options">
                                            <div class="pull-left">
                                                <label class="control-label">Company Name:</label>
                                                <p4 style="font-family: Rockwell; color: black;"><%# Eval ("ProductCompany") %></p4>
                                            </div>
                                            <div class="product-quantitys">
                                                Item Available :
                                           
                                                <p3 style="font-family: Rockwell; color: black;"><%# Eval ("ProductAvailability") %> </p3>
                                            </div>
                                            <div class="product-quantitys" style="font-family: Rockwell; color: forestgreen;">
                                                Including Shipping Charge 
                                       
                                            </div>
                                        </div>
                                        <div class="price-availability-block clearfix">
                                            <h3 style="color: #e84d1c;">
                                                <div class="proPrice">
                                                    Price :   &#8377;<%# Eval ("ProductPriceBeforeDiscount") %>
                                                    <span class="proOgPrice" style="font-family: Rockwell; color: black;">&#8377;<%# Eval ("ProductPrice") %>
                                                </span>
                                                    <span class="proPriceDiscount" style="font-family: Rockwell; color: red;">(<%# Eval("Discount","{0:0,00}") %>
                                                    off) </span>
                                                </div>
                                            </h3>
                                        </div>
                                        <%-- <div class="price-availability-block clearfix">
                                        <h3 style="color: #e84d1c;">
                                            <div class="proPrice">
                                                No of Product Select :                                                   
                                                <input type="number" id="Productselect"  style="width:40px;height:30px;"  value="1" name="fname" min="1" max="<%# Eval ("ProductAvailability") %>">
                                            </div>
                                        </h3>
                                    </div>--%>
                                        <div class="description">
                                            <p style="font-family: Rockwell; color: black;">
                                                <%# Eval ("ProductDescription") %>
                                            </p>
                                        </div>
                                        <div class="product-page-cart">
                                            <asp:Button ID="BtnAddtoCart" class="btn btn-primary" runat="server" Text="Add to cart" OnClick="BtnAddtoCart_Click" ValidationGroup="val" />
                                        </div>
                                        <%--  <div class="review">
                                        <input type="range" value="4" step="0.25" id="backing4">
                                        <div class="rateit" data-rateit-backingfld="#backing4" data-rateit-resetable="false" data-rateit-ispreset="true" data-rateit-min="0" data-rateit-max="5">
                                        </div>
                                        <a>7 reviews</a>
                                    </div>--%>
                                    </div>

                                    <div class="product-page-content">
                                        <ul id="myTab" class="nav nav-tabs">
                                            <li><a href="#Description" data-toggle="tab">Description</a></li>
                                            <li><a href="#Information" data-toggle="tab">Information</a></li>
                                            <li class="active"><a href="#Reviews" data-toggle="tab">Reviews</a></li>
                                        </ul>
                                        <div id="myTabContent" class="tab-content">
                                            <div class="tab-pane fade" id="Description" style="font-family: Rockwell; color: black;">
                                                <p><%# Eval ("ProductDescription") %></p>
                                            </div>
                                            <div class="tab-pane fade" id="Information">
                                                <table class="datasheet">
                                                    <tr>
                                                        <th colspan="2">Additional features</th>
                                                    </tr>
                                                    <tr>
                                                        <td class="datasheet-features-type">Product Name</td>
                                                        <td><%# Eval ("productName") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="datasheet-features-type">Company Name</td>
                                                        <td><%# Eval ("ProductCompany") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="datasheet-features-type">Price</td>
                                                        <td><%# Eval ("ProductPriceBeforeDiscount","{0:0,00}") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="datasheet-features-type">Shipping Charge</td>
                                                        <td><%# Eval ("ShippingCharge") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="datasheet-features-type">Product Available No. Item</td>
                                                        <td><%# Eval ("ProductAvailability") %></td>
                                                    </tr>
                                                </table>
                                            </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>


                                <div class="tab-pane fade in active" id="Reviews">
                                    <!--<p>There are no reviews for this product.</p>-->
                                    <div class="review-item clearfix">
                                        <div class="review-item-submitted">
                                            <strong><%# Eval ("Uname") %></strong>
                                            <em><%# Eval ("RatingDate") %></em>
                                            <div class="rateits" data-rateit-readonly="true">Rating : <%# Eval ("Rating") %>/100</div>
                                        </div>
                                        <div class="review-item-content">
                                            <p><%# Eval ("Description") %></p>
                                        </div>
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
                <!-- BEGIN FORM-->

                <h2>Write a review</h2>
                <div class="form-group">
                    <label for="name">Name <span class="require">*</span></label>
                    <%-- <input type="text" class="form-control" id="name">--%>
                    <asp:TextBox ID="TxtName" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtName" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Username" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Font-Names="Rockwell" ControlToValidate="TxtName" ForeColor="Red"
                        ValidationExpression="^[a-zA-Z]*$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="Check Name Format!"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    <%--<input type="text" class="form-control" id="email">--%>
                    <asp:TextBox ID="TxtEmail" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtEmail" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Username" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Font-Names="Rockwell" ControlToValidate="TxtEmail" ForeColor="Red"
                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        Display="Dynamic" ValidationGroup="Val_cc"
                        ErrorMessage="Check EmailId Format!"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="review">Review <span class="require">*</span></label>
                    <textarea class="form-control" rows="8" runat="server" id="TxtReview"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TxtReview" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter " ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="email">Rating</label>
                    <asp:TextBox ID="Rating" TextMode="Range" step="0.25" runat="server" oninput="this.nextElementSibling.value = this.value"></asp:TextBox>
                    <output>24</output>
                    <%--   <input id="input-21b" type="number" class="rating" min="0" max="5" step="0.5" data-glyphicon="false" data-star-captions="{}" data-default-caption="{rating} Stars" data-size="lg">--%>
                </div>
                <div class="padding-top-20">
                    <%--<button type="submit" class="btn btn-primary">Send</button>--%>
                    <asp:Button ID="SaveRating" runat="server" Text="Save" class="btn btn-primary" OnClick="SaveRating_Click" ValidationGroup="Val_cc" />
                </div>

                <!-- END FORM-->

                <div class="sticker sticker-sale"></div>
            </div>
        </div>
    </div>
    <!-- END CONTENT -->



</asp:Content>

