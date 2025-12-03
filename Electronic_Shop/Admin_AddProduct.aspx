<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_AddProduct.aspx.cs" Inherits="Electronic_Shop.Admin_AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Product</h2>
    <label>Product Name:</label>
    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
    
    <label>Price:</label>
    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>

    <label>Quantity:</label>
    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>

    <label>Image URL:</label>
    <asp:TextBox ID="txtImageUrl" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="btn btn-primary mt-3" OnClick="btnAddProduct_Click" />


</asp:Content>
