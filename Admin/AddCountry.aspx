<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="Admin_AddCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminameDisplay" Runat="Server">
     <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="form-group">
        <h4 class="text-primary">Add Country</h4>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="CountryID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Country Name </td>
                <td>
                    <asp:TextBox ID="CountryName" runat="server" placeholder="Enter Country Name" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CountryName" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter Country" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="CountryName" Font-Names="Rockwell" ID="RegularExpressionValidator2" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed."></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--<tr>
                <td>Description </td>
                <td>
                    <textarea id="Description" runat="server" name="description" rows="3" placeholder="Enter Description" class="form-control"></textarea>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Description" ForeColor="Red" Font-Names="Rockwell" runat="server" Display="Dynamic" ErrorMessage="Enter Description" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="Description" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,500}$" runat="server" ErrorMessage="Maximum 500 characters allowed."></asp:RegularExpressionValidator>
                </td>
            </tr>--%>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnCreateCountry" ValidationGroup="Val_cc" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="BtnCreateCountry_Click" />
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
                        <asp:GridView ID="ShowAddCountryDatas" runat="server" CssClass="table" OnSelectedIndexChanged="ShowAddCountryDatas_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("CountryId") %>' OnClick="lnkView_Click">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CountryId" HeaderText="Country Id" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                               <%-- <asp:BoundField DataField="CountryDescription" HeaderText="Country Description" />--%>
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

