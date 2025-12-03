<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Contact.aspx.cs" 
    Inherits="Electronic_Shop.Admin_Contact" MasterPageFile="~/AdminMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Contact</title>
    <style>
        .contact-section {
            padding: 40px 20px;
        }
        .contact-section h2 {
            font-weight: bold;
            margin-bottom: 30px;
        }
        .table {
            width: 100%;
            margin-top: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container contact-section">
        <h2>Contact Submissions</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                      CssClass="table table-bordered table-striped"
                      AllowPaging="true" PageSize="10"
                      AllowSorting="true">
        </asp:GridView>
    </div>
</asp:Content>
