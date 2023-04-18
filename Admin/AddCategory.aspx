<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Admin_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Add Category</h4>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="CatID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>CategoryName </td>
                <td>
                    <asp:TextBox ID="CategoryName" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CategoryName" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter CategoryName" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="CategoryName" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed."></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Description </td>
                <td>
                    <textarea id="Description" runat="server" name="description" rows="3" placeholder="Enter Description" class="form-control"></textarea>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Description" ForeColor="Red" Font-Names="Rockwell" runat="server" Display="Dynamic" ErrorMessage="Enter Description" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="Description" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,500}$" runat="server" ErrorMessage="Maximum 500 characters allowed."></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnCreateCategory" ValidationGroup="Val_cc" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="BtnCreateCategory_Click" />
                    <asp:Button ID="BtnReset" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="BtnReset_Click"/>

                </td>

            </tr>

        </table>
    </div>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Category Report
          <asp:Label ID="CountRow" runat="server" Style="float: right;"></asp:Label></h3>
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="table table-responsive">
                        <asp:GridView ID="ShowAddCategoryDatas" runat="server" CssClass="table" OnSelectedIndexChanged="ShowAddCategoryDatas_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Categoyid") %>' OnClick="lnkView_Click1">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Categoyid" HeaderText="Categoy Id" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                                <asp:BoundField DataField="CategoryDescription" HeaderText="Category Description" />
                                <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label Text="No Record Found" ForeColor="Red" runat="server"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>

