<%@ Page Title="" Language="C#" MasterPageFile="~/userside.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="Electronic_Shop.order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="container mt-5 mb-5">
        <h2 class="mb-4 text-center">Place Your Order</h2>

        <div class="row justify-content-center">
            <div class="col-md-6">

                <div class="form-group mb-3">
                    <label for="fname">First Name</label>
                    <asp:TextBox ID="fname" CssClass="form-control" runat="server" placeholder="Enter your first name" required="true"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="address">Address</label>
                    <asp:TextBox ID="address" CssClass="form-control" runat="server" placeholder="Enter your address" required="true"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" CssClass="form-control" runat="server" TextMode="Email" required="true" placeholder="Enter your email"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="mobileNumber">Mobile Number</label>
                    <asp:TextBox ID="mobileNumber" CssClass="form-control" runat="server" TextMode="Phone" required="true" placeholder="Enter your mobile number"></asp:TextBox>
                </div>

                <div class="form-group mb-4">
                    <label for="quantity">Quantity</label>
                    <asp:TextBox ID="quantity" CssClass="form-control" runat="server" TextMode="Number" required="true" placeholder="Enter quantity"></asp:TextBox>
                </div>

                <!-- Hidden fields for product ID and price -->
                <asp:HiddenField ID="hfProductID" runat="server" />
                <asp:HiddenField ID="hfPrice" runat="server" />

                <asp:Button ID="Button1" CssClass="btn btn-primary w-100" runat="server" Text="Place Order" OnClick="Button1_Click" />

            </div>
        </div>
    </div>
</asp:Content>
