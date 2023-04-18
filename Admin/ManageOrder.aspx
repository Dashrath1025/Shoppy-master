<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="ManageOrder.aspx.cs" Inherits="Admin_ManageOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .panel-body {
            padding: 1px !important;
        }

        .select#ContentPlaceHolder1_DisplayUserOrder_Orderstatus_1 {
            background-color: white;
            color: black;
        }
    </style>
    <div class="container-fluid">
        <br />
           <h4 class="text-primary">Manage Order</h4>
        <hr />
        <div class="row form-group">

            <div class="col-sm-4">
                From :
      
                <asp:TextBox ID="FromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FromDate" runat="server" ErrorMessage="Required" ForeColor="Red" Font-Names="Rockwell" ValidationGroup="valcc" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="col-sm-4">
                To :               
               
                <asp:TextBox ID="ToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ToDate" ErrorMessage="Required" ForeColor="Red" Font-Names="Rockwell" ValidationGroup="valcc" Display="Dynamic"></asp:RequiredFieldValidator>

                <br />
                <asp:Button ID="FetchDate" runat="server" Text="FetchData" OnClick="FetchDate_Click" CssClass="btn btn-primary" ValidationGroup="valcc" />
            </div>
            <div class="col-sm-4">
                Search :
               
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            
            <table>
                <tr>
                    <td>Order ID</td>
                    <td>
                        <asp:TextBox ID="txtoid" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Select Order Status</td>
                    <td>
                        <asp:DropDownList ID="ddlOptions" runat="server" class="btn btn-primary" Style="background-color: white; color: black;width:200px;">
                            <asp:ListItem Value="Select" Text=" -- Select --"></asp:ListItem>
                            <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                            <asp:ListItem Value="Cancel" Text="Cancel"></asp:ListItem>
                            <asp:ListItem Value="Delivered" Text="Delivered"></asp:ListItem>
                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                            <asp:ListItem Value="InTransit" Text="In Transit"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Button1_Click" />

                    </td>
                </tr>
            </table>


        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 style="text-align: center; font-family: Rockwell;">Order Report</h3>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="table table-responsive">
                            <asp:GridView ID="DisplayUserOrder" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="DisplayUserOrder_SelectedIndexChanged" CellPadding="10" CellSpacing="0">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="OID" HeaderText="O.No." />
                                    <asp:BoundField DataField="PaymentID" HeaderText="Payment ID" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#"../UploadedImages/" +(DataBinder.Eval(Container.DataItem, "ProductImage1").ToString())%>' ControlStyle-Width="50" ControlStyle-Height="50" HeaderText="Preview Image" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="ProductCompany" HeaderText="Company Name" />
                                    <asp:BoundField DataField="ProductPriceBeforeDiscount" HeaderText="Product Price" />
                                    <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
                                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                                    <asp:BoundField DataField="StateName" HeaderText="State" />
                                    <asp:BoundField DataField="CityName" HeaderText="City" />
                                    <asp:BoundField DataField="BillingPincode" HeaderText="Pincode" />
                                    <asp:BoundField DataField="DateTime" HeaderText="DateTime" />

                                    <%--<asp:BoundField DataField="DeliveredDate" HeaderText="Delivered Date" />
                                    <asp:BoundField DataField="ProductStatus" HeaderText="Product Status" />--%>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Label Text="No Record Found" ForeColor="Red" runat="server"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Order Status">
                                        <ItemTemplate>
                                           <asp:Label ID="lbl" runat="server" Text='<%# Eval("OrderStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <%--  <Columns>
                                    <asp:TemplateField HeaderText="Operation">
                                        <ItemTemplate>
                                          <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" CssClass="btn btn-primary" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>--%>
                            </asp:GridView>
                        </div>

                    </div>

                </div>

            </div>


        </div>

    </div>

    </div>


</asp:Content>

