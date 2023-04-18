<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="User_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="margin-top:120px;">
   <%--    <center>

        <div>
            <br />
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3>Your Products
         
                                <asp:Label ID="CountRow" runat="server" Style="float: right;"></asp:Label></h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="table table-responsive">
                                <asp:GridView ID="YourProducts" runat="server" Width="50%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnDataBound="YourProducts_DataBound" OnRowCommand="YourProducts_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product Id" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="productName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Photo">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' ControlStyle-Width="70" ControlStyle-Height="70" HeaderText="Preview Image" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductPriceBeforeDiscount" HeaderText="Price">
                                            <ItemStyle />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <EmptyDataTemplate>
                                        <div style="color: red; text-align: center;">No Product found.</div>
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle Height="40px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </center>--%>

     <form action="Charge.aspx"  method="post" name="razorpayForm">
         
            <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
            <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
            <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
        </form>
      
        <button id="rzp-button1">Pay with Razorpay</button>

       </div>
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

</asp:Content>

