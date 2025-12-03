<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_ShowProduct.aspx.cs" Inherits="Electronic_Shop.Admin_ShowProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Product List</h2>
    <asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False"
    OnRowCommand="GridView1_RowCommand"
    CssClass="table table-striped table-bordered table-hover"
    DataKeyNames="ProductID">

        <Columns>
            <asp:TemplateField HeaderText="Product Id">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductID") %>' CssClass="text-center"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProductName") %>' CssClass="text-center"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Price") %>' CssClass="text-center"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Quantity") %>' CssClass="text-center"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandName="Edit" CommandArgument='<%# Eval("ProductID") %>'
                        runat="server" Text="Edit" CssClass="btn btn-warning btn-sm"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDelete" CommandName="Delete" CommandArgument='<%# Eval("ProductID") %>'
                        runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                        OnClientClick="return confirm('Are you sure you want to delete this product?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
