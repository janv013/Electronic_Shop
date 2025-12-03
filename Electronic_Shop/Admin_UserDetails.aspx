<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_UserDetails.aspx.cs" Inherits="Electronic_Shop.Admin_UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User List</h2>

    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" 
        OnRowCommand="gvUsers_RowCommand" DataKeyNames="UserID">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <%--<asp:BoundField DataField="CreatedAt" HeaderText="Registered Date" DataFormatString="{0:dd/MM/yyyy}" />--%>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                        CommandName="DeleteUser" CommandArgument='<%# Eval("UserID") %>'
                        OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
