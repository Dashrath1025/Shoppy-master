<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="UserViewProduct.aspx.cs" Inherits="User_UserViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="../css/User/product.css" />
    
            <div class="w3-sidebar w3-light-grey w3-bar-block" style="width: 15%">
                <h3 class="w3-bar-item">Filter</h3>
                <h3 class="w3-bar-item">Filter</h3>
                <a href="#" class="w3-bar-item w3-button">Price</a>
                <asp:TextBox ID="filterprices" TextMode="Range" min="0" max="10000" runat="server" AutoPostBack="true" OnTextChanged="filterprices_TextChanged1"></asp:TextBox>
                <asp:Label ID="lblOutput" runat="server" Text="0"></asp:Label>

            </div>
          

    <div style="margin-left: 15%">
        <div class="w3-container-fluid">
        </div>
        <div class="w3-container-fluid">
            <div class="panel-body">
                <div class="row" style="padding-top: 50px">
                    <asp:Repeater ID="productcategorywises" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-lg-3">
                                <%--<a href="UserProductDetails.aspx?PID=<%# Eval("ProductId") %>" style="text-decoration: none;">--%>
                                <%-- <div class="thumbnail">
                                        <img src="../UploadedImages/<%# Eval("ProductImage1") %>" alt="<%# Eval("ProductImage1") %>" style="height: 180px;" />
                                        <div class="caption" style="text-align: center;">
                                            <div class="probrand">
                                                <%# Eval ("ProductCompany") %>
                                            </div>
                                            <div class="proName">
                                                <%# Eval ("productName") %>
                                            </div>
                                            <div class="proPrice">
                                                <span class="proOgPrice">&#8377;<%# Eval ("ProductPrice","{0:0,00}") %>
                                                </span>
                                                &#8377;<%# Eval ("ProductPriceBeforeDiscount") %>
                                                <span class="proPriceDiscount" style="font-family: Rockwell; color: red;">(<%# Eval("Discount","{0:0,00}") %>
                                                    off) </span>
                                            </div>
                                        </div>
                                    </div>--%>

                                <div class="product-grid">
                                    <div class="product-image">
                                        <a href="#" class="image">
                                        <asp:Image ID="Image1" runat="server" class="pic-1" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' Height="200px" />


                                            <%--<img class="pic-1" src="../UploadedImages/<%# Eval("ProductImage1") %>">--%>
                                        </a>
                                        <span class="product-sale-label">Sale!</span>
                                        <ul class="product-links">
                                            <%--  <li><a href="#"><i class="fa fa-shopping-bag"></i>Add to cart</a></li>--%>
                                            <li><a href="UserProductDetails.aspx?PID=<%# Eval("ProductId") %>"><i class="fa fa-search"></i>Quick View</a></li>
                                        </ul>
                                    </div>
                                    <div class="product-content">
                                        <h3 class="title"><a href="#"><%# Eval ("productName") %></a></h3>
                                        <div class="price"><span>&#8377;<%# Eval ("ProductPrice") %></span>    &#8377;<%# Eval ("ProductPriceBeforeDiscount") %></div>
                                    </div>
                                </div>

                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

