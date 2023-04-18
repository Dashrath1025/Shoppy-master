<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="UserOrder.aspx.cs" Inherits="User_UserOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        body {
            background: #eee;
        }

        .card {
            box-shadow: 0 20px 27px 0 rgb(0 0 0 / 5%);
        }

        .card {
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border: 0 solid rgba(0,0,0,.125);
            border-radius: 1rem;
        }

        .text-reset {
            --bs-text-opacity: 1;
            color: inherit !important;
        }

        a {
            color: #5465ff;
            text-decoration: none;
        }

        .contentcenter {
            margin-left: 20%;
        }
    </style>
    <div class="contentcenter">

        <div class="container-fluid" style="margin-top: 5%;">
            <center>
                <asp:Label ID="EmptyOrderDetails" runat="server" class="text-primary" Style="margin-top: 5%;"></asp:Label>
            </center>
        </div>
        <asp:Repeater ID="UserOrderDetails" runat="server">
            <ItemTemplate>
                <div class="container-fluid" style="margin-top: 5%;">

                    <div class="container">
                        <!-- Title -->
                        <div class="d-flex justify-content-between align-items-center py-3">
                            <h2 class="h5 mb-0"><a href="#" class="text-muted"></a>Order ID <%# Eval ("OID") %></h2>
                        </div>

                        <!-- Main content -->
                        <div class="row">
                            <div class="col-lg-8">
                                <!-- Details -->
                                <div class="card mb-4">
                                    <div class="card-body">
                                        <div class="mb-3 d-flex justify-content-between">
                                            <div>
                                                <span class="me-3"><%# Eval ("DateTime") %></span>
                                                <span class="badge rounded-pill bg-info"><%# Eval ("OrderStatus") %></span>
                                            </div>
                                            <div class="d-flex">
                                                <button class="btn btn-link p-0 me-3 d-none d-lg-block btn-icon-text"><i class="bi bi-download"></i><span class="text">Invoice</span></button>
                                                <div class="dropdown">

                                                    <%--   <i class="bi bi-three-dots-vertical">Delivered Date : <%# Eval ("DeliveredDate") %></i><br />
                                                      <i class="bi bi-three-dots-vertical">Order Status : <%# Eval ("ProductStatus") %></i>
                                                    --%>
                                                    <ul class="dropdown-menu dropdown-menu-end">
                                                        <li><a class="dropdown-item" href="#"><i class="bi bi-pencil"></i>Edit</a></li>
                                                        <li><a class="dropdown-item" href="#"><i class="bi bi-printer"></i>Print</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <table class="table table-borderless">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div class="d-flex mb-2">
                                                            <div class="flex-shrink-0">
                                                                <asp:Image ID="Image1" runat="server" width="35" class="img-fluid"  ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />

                                                               <%-- <img src="../UploadedImages/<%# Eval("ProductImage1") %>" alt="" width="35" class="img-fluid">--%>
                                                            </div>
                                                            <div class="flex-lg-grow-1 ms-3">
                                                                <h6 class="small mb-0"><a href="#" class="text-reset"><%# Eval ("productName") %></a></h6>
                                                                <span class="small">Product Company : <%# Eval ("ProductCompany") %></span>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td></td>
                                                    <td class="text-end">&#8377; <%# Eval ("ProductPriceBeforeDiscount") %></td>
                                                </tr>

                                            </tbody>
                                            <tfoot>
                                                <%--<tr>
                                                <td colspan="2">Subtotal</td>
                                                <td class="text-end">&#8377; <%# Eval ("ProductPriceBeforeDiscount") %></td>
                                            </tr>--%>
                                                <%--   <tr>
                                            <td colspan="2">Shipping</td>
                                            <td class="text-end">$0.00</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Discount (Code: NEWYEAR)</td>
                                            <td class="text-danger text-end">-$10.00</td>
                                        </tr>--%>
                                                <tr class="fw-bold">
                                                    <td colspan="2">TOTAL</td>
                                                    <td class="text-end">&#8377; <%# Eval ("ProductPriceBeforeDiscount") %></td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <!-- Payment -->
                                <div class="card mb-4">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <h3 class="h6">Payment ID</h3>
                                                <p>
                                                    <%# Eval ("PaymentID") %>
                                                    <br>
                                                    <%--Total:&#8377; <%# Eval ("ProductPriceBeforeDiscount") %> <span class="badge bg-success rounded-pill"></span>--%>
                                                </p>
                                            </div>
                                            <%--<div class="col-lg-6">
                                            <h3 class="h6">Billing address</h3>
                                            <address>
                                                <strong><%# Eval ("bFirstname") %></strong><br>
                                                <%# Eval ("bAddress") %><br>
                                                Country : <%# Eval ("bCountry") %> , State : <%# Eval ("bState") %><br />
                                                City : <%# Eval ("bCity") %> ,Pincode :  <%# Eval ("bPincode") %><br />
                                                <abbr title="Phone">Ph:</abbr>
                                                <%# Eval ("bMobileno") %>
                                            </address>
                                        </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

