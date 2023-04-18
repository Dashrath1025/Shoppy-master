<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSiteMasterPage.master" AutoEventWireup="true" CodeFile="AddState.aspx.cs" Inherits="Admin_AddState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminameDisplay" runat="Server">
    <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-group">
        <h4 class="text-primary">Add State</h4>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="CatID" runat="server" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Country</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Style="height: 30px;"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DropDownList1" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" InitialValue="0" ErrorMessage="Select Country" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>State Name</td>
                <td>
                    <asp:TextBox ID="StateName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="StateName" Font-Names="Rockwell" ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Enter StateName" ValidationGroup="Val_cc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="StateName" Font-Names="Rockwell" ID="RegularExpressionValidator1" ValidationGroup="Val_cc" ValidationExpression="^[\s\S]{0,500}$" runat="server" ErrorMessage="Maximum 45 characters allowed."></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnSate" runat="server" Text="Create" CssClass="btn btn-primary" ValidationGroup="Val_cc" OnClick="BtnSate_Click" />
                    <asp:Button ID="ResetData" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="ResetData_Click" />

                </td>
            </tr>
        </table>
    </div>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>SubCategory Report
         
                <asp:Label ID="CountRow" runat="server" Style="float: right;"></asp:Label></h3>
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="table table-responsive">
                        <asp:GridView ID="ShowStateDatas" runat="server" CssClass="table" OnSelectedIndexChanged="ShowStateDatas_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("StateId") %>' OnClick="lnkView_Click1">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StateId" HeaderText="State Id" />
                              <%--  <asp:BoundField DataField="CountryId" HeaderText="Country Id" />--%>
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="StateName" HeaderText="State Name" />
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

