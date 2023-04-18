<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPayment.aspx.cs" Inherits="User_UserPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay .Net Sample App</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        body {
            background-color: #dce3f0;
        }

        .height {
            height: 100vh;
        }

        .card {
            width: 50%;
            height: 55%;
        }

        .image {
            position: absolute;
            right: 12px;
            top: 10px;
        }

        .main-heading {
            font-size: 40px;
            color: red !important;
        }

        .ratings i {
            color: orange;
        }

        .user-ratings h6 {
            margin-top: 2px;
        }

        .colors {
            display: flex;
            margin-top: 2px;
        }

            .colors span {
                width: 15px;
                height: 15px;
                border-radius: 50%;
                cursor: pointer;
                display: flex;
                margin-right: 6px;
            }

                .colors span:nth-child(1) {
                    background-color: red;
                }

                .colors span:nth-child(2) {
                    background-color: blue;
                }

                .colors span:nth-child(3) {
                    background-color: yellow;
                }

                .colors span:nth-child(4) {
                    background-color: purple;
                }

        .btn-danger {
            height: 48px;
            font-size: 18px;
        }
    </style>
</head>

<body>

    <form id="fr1" runat="server">


        <center>

            <div class="height d-flex justify-content-center align-items-center">

                <div class="card p-3">

                    <asp:Repeater ID="PaymentDetails" runat="server">
                        <ItemTemplate>
                            <div class="d-flex justify-content-between align-items-center ">
                                <div class="mt-2">
                                    Product Name :
                                    <h4 class="text-uppercase"><%# Eval ("productName") %></h4>
                                    <div class="mt-2">
                                        Company Name :
                                        <h5 class="text-uppercase mb-0"><%# Eval ("ProductCompany") %></h5>
                                        Description :
                                        <h6 style="width:500px;"><%# Eval ("ProductDescription") %></h6>

                                    </div>
                                    <br />
                                </div>
                                <div class="image">
                                    <asp:Image ID="item2" runat="server" Width="200" Height="200" alt="Berry Lace Dress" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />

                                </div>
                            </div>
                            <div class="mt-7">
                                <div class="d-flex justify-content-between align-items-center mt-5 mb-2">
                                    <span style="color: #d9534f">Payable Amount : &#8377; <%# Eval ("ProductPriceBeforeDiscount") %></span>
                                </div>

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <p></p>
                    <br />
                    <%--   <button class="btn btn-danger">Add to cart</button>--%>
                    <button id="rzp-button1" class="btn btn-danger">Pay Now</button>
                </div>

            </div>

        </center>
    </form>
    <form action="Charge.aspx" method="post" name="razorpayForm">

        <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
        <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
        <input id="razorpay_signature" type="hidden" name="razorpay_signature" />

    </form>


    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        var orderId = "<%=orderId%>"
        var options = {
            "name": "Milan Limbani",
            "description": "Milan Limbani",
            "order_id": orderId,
            "image": "https://s29.postimg.org/r6dj1g85z/daft_punk.jpg",
            "prefill": {
                "name": "Milan Limbani",
                "email": "milanlimbani555@gmail.com",
                "contact": "+916359784404",
            },
            "notes": {
                "address": "Hello World",
                "merchant_order_id": "12312321",
            },
            "theme": {
                "color": "#F37254"
            }
        }
        // Boolean whether to show image inside a white frame. (default: true)
        options.theme.image_padding = false;
        options.handler = function (response) {
            document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
            document.getElementById('razorpay_order_id').value = orderId;
            document.getElementById('razorpay_signature').value = response.razorpay_signature;
            document.razorpayForm.submit();
        };
        options.modal = {
            ondismiss: function () {
                console.log("This code runs when the popup is closed");
            },
            // Boolean indicating whether pressing escape key 
            // should close the checkout form. (default: true)
            escape: true,
            // Boolean indicating whether clicking translucent blank
            // space outside checkout form should close the form. (default: false)
            backdropclose: false
        };
        var rzp = new Razorpay(options);
        document.getElementById('rzp-button1').onclick = function (e) {
            rzp.open();
            e.preventDefault();
        }
    </script>
</body>

</html>
