<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="UserMainPage.aspx.cs" Inherits="User_UserMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:TextBox ID="txtsearch" autofocus="autofocus" runat="server" style="margin-top:12px;" Height="33px" placeholder="Search..." Width="250px"></asp:TextBox>
    <asp:Button class="btn btn-outline-success my-2 my-sm-0" ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="filecategory" runat="server" style="width:200px;height:30px;border-radius:5px;" AutoPostBack="true" OnSelectedIndexChanged="filecategory_SelectedIndexChanged"></asp:DropDownList>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" href="../css/User/product.css" />

    <%--<div style="margin-left:15%">--%>
    <div class="w3-container-fluid">
    </div>
    <div class="w3-container-fluid">

        <div class="panel-body">

            <asp:Label ID="Lbl2" runat="server"></asp:Label>
            <div class="row" style="padding-top: 50px">
                <asp:Repeater ID="rptrProducts" runat="server">

                    <ItemTemplate>

                        <div class="col-lg-3 col-lg-3">
                            <div class="product-grid">
                                <div class="product-image">
                                    <a href="#" class="image">
                                        <asp:Image ID="Image1" runat="server" class="pic-1" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' Height="200px" />

                                    </a>
                                    <span class="product-sale-label">Sale!</span>
                                    <ul class="product-links">
                                        <%--  <li><a href="#"><i class="fa fa-shopping-bag"></i>Add to cart</a></li>--%>
                                        <li><a href="UserViewProduct.aspx?PID=<%# Eval("ProductId") %>&SubCategory=<%# Eval("SubCatID") %>"><i class="fa fa-search"></i>Quick View</a></li>
                                    </ul>
                                </div>
                                <div class="product-content">
                                    <h3 class="title"><a href="#"><%# Eval ("productName") %></a></h3>
                                    <div class="price"><span>&#8377;<%# Eval ("ProductPrice") %></span>    &#8377;<%# Eval ("ProductPriceBeforeDiscount") %></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <%--</div>--%>
</asp:Content>

