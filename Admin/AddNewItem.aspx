<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AddNewItem.aspx.cs" Inherits="Admin_AddNewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Add New Item</h4>
        <hr />
        <div class="module">
            <div class="module-head">
                <h3>ADD Product</h3>
            </div>
            <table>
                <tr>
                    <td>Category</td>
                    <td>
                        <asp:DropDownList ID="DropCategory" CssClass="form-control" runat="server" Style="height: 35px;" OnSelectedIndexChanged="DropCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DropCategory" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select Category" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Sub Category</td>
                    <td>
                        <asp:DropDownList ID="DropSubCategory" runat="server" CssClass="form-control" Style="height: 35px;"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DropSubCategory" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select SubCategory" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Name</td>
                    <td>
                        <asp:TextBox ID="Productname" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Productname" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter CategoryName" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="Productname" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Company</td>
                    <td>
                        <asp:TextBox ID="ProductCompany" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ProductCompany" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter CategoryName" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductCompany" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,45}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Price Before Discount</td>
                    <td>
                        <asp:TextBox ID="ProductPriceBeofreDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ProductPriceBeofreDiscount" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Product Price Before Discount" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductPriceBeofreDiscount" Font-Names="Rockwell" ID="RegularExpressionValidator3" ValidationGroup="Val_cc" ValidationExpression="^\d+$" runat="server" ErrorMessage="Only Numeric Value allowed."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Price After Discount(Selling Price)</td>
                    <td>
                        <asp:TextBox ID="ProductPriceAfterDiscount" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="ProductPriceAfterDiscount_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ProductPriceAfterDiscount" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Product Price After Discount" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductPriceAfterDiscount" Font-Names="Rockwell" ID="RegularExpressionValidator4" ValidationGroup="Val_cc" ValidationExpression="^\d+$" runat="server" ErrorMessage="Only Numeric Value allowed"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                  <tr>
                    <td>Product Total Discount</td>
                    <td>
                        <asp:TextBox ID="Discount" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="Discount" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Product Discount" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="Discount" Font-Names="Rockwell" ID="RegularExpressionValidator7" ValidationGroup="Val_cc" ValidationExpression="^\d+$" runat="server" ErrorMessage="Only Numeric Value allowed"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Description</td>
                    <td>
                        <textarea name="productDescription" id="ProductDescription" cssclass="form-control" runat="server" placeholder="Enter Product Description" rows="6" class="span8 tip" style="width: 300px;"></textarea>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ProductDescription" ForeColor="Red" Font-Names="Rockwell" runat="server" Display="Dynamic" ErrorMessage="Enter Description" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductDescription" Font-Names="Rockwell" ID="RegularExpressionValidator6" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,1000}$" runat="server" ErrorMessage="Maximum 1000 characters allowed."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Shipping Charge</td>
                    <td>
                        <asp:TextBox ID="ProductShippingCharge" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ProductShippingCharge" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Product Shipping Charge" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductShippingCharge" Font-Names="Rockwell" ID="RegularExpressionValidator5" ValidationGroup="Val_cc" ValidationExpression="^\d+$" runat="server" ErrorMessage="Only Numeric Value allowed"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Availability</td>
                    <td>
                        <asp:TextBox ID="ProductAvailability" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ProductAvailability" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter No. Product Availability" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="ProductAvailability" Font-Names="Rockwell" ID="RegularExpressionValidator10" ValidationGroup="Val_cc" ValidationExpression="^\d+$" runat="server" ErrorMessage="Only Numeric Value allowed"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Image1</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="FileUpload1" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Choose a Image" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Image2</td>
                    <td>
                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="FileUpload2" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Choose a Image" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Product Image3</td>
                    <td>
                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="FileUpload3" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Choose a Image" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" CssClass="btn btn-primary" ValidationGroup="Val_cc" />
                        <asp:Button ID="Reset" runat="server" Text="Cancel" OnClick="Reset_Click" CssClass="btn btn-danger" />
                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Product Report
          <asp:Label ID="CountRow" runat="server" Text="Label" Style="float: right;"></asp:Label></h3>
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="table table-responsive">
                        <asp:GridView ID="ShowItemDetails" runat="server" CssClass="table" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ProductId") %>' OnClick="lnkView_Click">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ProductId" HeaderText="S.No." />
                                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                                <asp:BoundField DataField="SubCategoryName" HeaderText="SubCategory Name" />
                                <asp:BoundField DataField="productName" HeaderText="product Name" />
                                <asp:BoundField DataField="ProductCompany" HeaderText="Brand" />
                                <asp:BoundField DataField="ProductPrice" HeaderText="Price" />
                                <asp:BoundField DataField="ProductPriceBeforeDiscount" HeaderText="Product Before Discount" />
                                 <asp:BoundField DataField="Discount" HeaderText="Product Discount" />
                                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" />
                                <asp:BoundField DataField="ShippingCharge" HeaderText="Shipping Charge" />
                                <asp:BoundField DataField="ProductAvailability" HeaderText="Product Availability" />
                                <asp:BoundField DataField="PostingDate" HeaderText="PostingDate" />
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' ControlStyle-Width="50" ControlStyle-Height="50" HeaderText="Preview Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage2").ToString())%>' ControlStyle-Width="50" ControlStyle-Height="50" HeaderText="Preview Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage3").ToString())%>' ControlStyle-Width="50" ControlStyle-Height="50" HeaderText="Preview Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label Text="No Record Found" ForeColor="Red" runat="server"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>

                </div>

            </div>


        </div>
        <%-- <div class="panel-footer">View Product</div>--%>
    </div>
</asp:Content>

