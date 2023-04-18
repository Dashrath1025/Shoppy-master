<%@ Page Title="" Language="C#" MasterPageFile="~/User/UsersiteMasterPage.master" AutoEventWireup="true" CodeFile="AddtoCart.aspx.cs" Inherits="User_AddtoCart" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="author" content="CodeHim">
    <title>Update Quantity Shopping Cart Example</title>

    <!-- Style CSS -->
    <link rel="stylesheet" href="../css/style.css">
    <!-- Demo CSS (No need to include it into your project) -->
    <link rel="stylesheet" href="../css/demo.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- <%-- <br />
    <br />
    <script type="text/javascript">
        function sum() {
            var txtFirstNumberValue = document.getElementById('txtprices').value;
            var txtSecondNumberValue = document.getElementById('txtQty').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtsubtotals').value = result;
            }
        }
    </script>
    <contenttemplate>
        <div class="container">
            <br />
            <br />

            <button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button">
                Cart <span id="CartBadge" runat="server" class="badge">0</span>
            </button>
            <div style="padding-top: 50px">
                <div class="col-md-9">
                    <h4 class="proNameViewCart" runat="server" id="h4NoItems"></h4>
                    <asp:Repeater ID="RptrCartProducts" OnItemCommand="RptrCartProducts_ItemCommand" runat="server">
                        <ItemTemplate>

                            <div class="media" runat="server" style="border: 1px solid black;">
                                <div class="media-left">
                                    <a href="ProductView.aspx?PID=<%# Eval("ProductId") %>" target="_blank">
                                        <img class="media-object" width="100" src='<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />
                                    </a>
                                </div>
                                <div class="media-body" runat="server">
                                    <h4 class="media-heading proNameViewCart"><%# Eval("productName") %></h4>
                                    <span id="txtprics" class="ProPriceViewCart">&#8377;&nbsp<%# Eval("ProductPriceBeforeDiscount","{0:0.00}") %></span><span class="proOgPriceView">&#8377;&nbsp<%# Eval("ProductPrice","{0:0.00}") %></span><input type="number" id="txtprices" value="<%# Eval("ProductPrice","{0:0.00}") %>" /><span class="proPriceDiscountView">Off &#8377; <%# string.Format("{0}",Convert.ToInt64(Eval("ProductPrice"))-Convert.ToInt64(Eval("ProductPriceBeforeDiscount"))) %></span>
                                    <div class="pull-right form-inline">
                                        <asp:Label ID="lblQty" runat="server" Text="Qty:" Font-Size="Large"></asp:Label>

                                        <input type="number" id="txtQty"  min="1" max="<%# Eval("ProductAvailability") %>" onkeyup="sum()" width="40" font-size="Large" style="text-align: center">
                                    </div>
                                    <br />
                                    <p>

        
                                        <asp:Button OnClick="btnRemoveCart_Click" ID="btnRemoveCart" CssClass="RemoveButton1" runat="server" Text="Remove" />
                                        <br />
                                        <span class="proNameViewCart pull-right">SubTotal: &#8377;&nbsp
                                            <input type="number" id="txtsubtotals" /></span>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--Show cart details Ending--%>
    <%--      </div>

                <div class="col-md-3" runat="server" id="divAmountSect">
                    <div>
                        <h5 class="proNameViewCart">Price Details</h5>
                        <div>
                            <label class=" ">Total</label>
                            <span class="pull-right priceGray" runat="server" id="spanCartTotal"></span>
                        </div>
                        <div>
                            <label class=" ">Cart Discount</label>
                            <span class="pull-right priceGreen" runat="server" id="spanDiscount"></span>
                        </div>
                    </div>
                    <div>
                        <div class="cartTotal">
                            <label>Cart Total</label>
                            <span class="pull-right " runat="server" id="spanTotal"></span>
                            <div>
                                <asp:Button ID="btnBuyNow" CssClass="buyNowbtn" runat="server" OnClick="btnBuyNow_Click" Text="BUY NOW" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </contenttemplate>--%>--%>--%>
 
              <main>

                  <!-- Start DEMO HTML (Use the following code into your project)-->
                  <header id="site-header">
                      <div class="container">
                          <h1>Shopping cart<span class="last-span is-open"></span></h1>
                      </div>
                  </header>
                  <asp:Repeater ID="RptrCartProducts" OnItemCommand="RptrCartProducts_ItemCommand" runat="server">
                      <ItemTemplate>
                          <div class="container">
                              <section id="cart">
                                  <article class="product">
                                      <header>
                                          <a class="removes">

                                                <asp:Image ID="item2" runat="server" class="zoom1" alt="Berry Lace Dress" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' />

                                              <%--<img src="<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>" alt="Gamming Mouse">--%>
                                               <h3 id="spnn" style="display:none;"><%# Eval("ProductId") %></h3>
                                              <h3><%# Eval("productName") %></h3>
                                          </a>
                                          &nbsp;
                                      </header>

                                      <div class="content">

                                          <h3><%# Eval("productName") %></h3>
                                       <%# Eval("ProductDescription") %>
                                          

                                          <br />
                                          <div title="You have selected this product to be shipped in the color yellow." style="top: 0; width: 120px !important;" class="color yellow">No. Product Left</div>
                                          <div style="top: 45px" class="type small" id="pv"><%# Eval("ProductAvailability") %></div>

                                      </div>
                                      <footer class="content">
                                          <span class="qt-minus">-</span>
                                          <%--<span class="qt">1</span>--%>
                                          <%--     <asp:TextBox ID="TextBox1" class="qt" runat="server" Text="1" TextMode="Number" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>--%>
                                          <%--<asp:Label ID="TextBox1" class="qt" runat="server" ClientIDMode="Static" Text="1"></asp:Label>--%>
                                          <input type="number" ID="TextBox1"  ClientIDMode="Static" class="qt" value="1" min="1" Max="<%# Eval("ProductAvailability") %>" />
                                          <span class="qt-plus">+</span>

                                          <asp:Label ID="qty1" class="qty" hidden="hidden" runat="server"><%# Eval("ProductAvailability") %></asp:Label>
                                          <h2 class="full-price" style="background: #53b5aa;"><%# Eval("ProductPriceBeforeDiscount") %> &#8377;
                                          </h2>
                                          </script>
                                         <h2 class="price"><%# Eval("ProductPriceBeforeDiscount") %>  &#8377;
                                          </h2>
                                          <a href="ProductView.aspx?PID=<%# Eval("ProductId") %>" target="_blank"></a>
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;            
                                     <asp:Button CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CartID") %>' ID="btnRemoveCart" CssClass="RemoveButton1" Style="height: 30px !important;" runat="server" Text="Remove" />
                                      </footer>
                                  </article>
                              </section>
                          </div>
                           
                      </ItemTemplate>
                  </asp:Repeater>
                  <footer id="site-footer">
                      <div class="container clearfix">

                       <%--   <div class="left">
                              <h2 class="subtotal">Subtotal: <span></span>&#8377;</h2>

                          </div>--%>

                          <div class="right">
                              <h1 class="total">Total: &#8377; <span id="spn"></span></h1>
                              
                            <%--  <asp:Label ID="Label1" runat="server"></asp:Label>--%>
                             <%-- <asp:HiddenField ID="Label1" runat="server" />--%>
                              <asp:Button ID="Button1" runat="server" class="btn" Text="BUY NOW" OnClick="Button1_Click1" />
                              <asp:TextBox ID="name" runat="server" ClientIDMode="Static" style="display:none;"></asp:TextBox>
                              <asp:TextBox ID="pids" runat="server" ClientIDMode="Static" style="display:none;"></asp:TextBox>
                          </div>

                      </div>
                  </footer>
                  <!-- END EDMO HTML (Happy Coding!)-->

              </main>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="../js/script.js"></script>
    <script>

        var payableAmout = document.getElementById('spn').innerText;
      //  alert(payableAmout);

      <%--  <% Session["totalPayment"] = "HELLLLO"; %> ;--%>
     <%--   document.getElementById("<%=Label1.ClientID%>").innerText = payableAmout;--%>

        sessionStorage.setItem("TotalPayableAmount", payableAmout);
       
      //  alert(ab);
     
    </script>
<%--    <script>
        //var hii = jQuery("#spnn").text();
        //$("#pids").val(hii);
        
        //var hi = jQuery("#spn").text();
        //$("#name").val(hi);
        function mufun() {
      var productAvailble = document.getElementById("pv").innerText;
       // alert(productAvailble);
        var selectedQty = document.getElementById("TextBox1").innerText;
           // alert(selectedQty);

            if (selectedQty == productAvailble) {
               
                return true;
            } else {
               
                return false;
            }
            return false;
        }
    </script>--%>
<%--   <script>
       var span1 = document.getElementById("qty1").innerHTML;
       alert(span1);
       var el_down = document.getElementById("TextBox1").innerHTML;
       alert(el_down);
       function gfg_Run() {
           if (el_down >= span1) {
               alert("not");
           } else {
               alert("match");
           }
       }
   </script>--%>
</asp:Content>

