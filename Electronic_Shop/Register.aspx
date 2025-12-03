<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Electronic_Shop.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script>
        function validatePasswords() {
            var pwd = document.getElementById('<%= txtPassword.ClientID %>').value;
            var confirmPwd = document.getElementById('<%= txtConfirmPassword.ClientID %>').value;
            if (pwd !== confirmPwd) {
                alert("Passwords do not match!");
                return false;
            }
            return true;
        }
    </script>
</head>
<body class="d-flex justify-content-center align-items-center vh-100 bg-light">
    <form id="form1" runat="server">
        <div class="card p-4 shadow" style="width: 400px;">
            <h3 class="text-center">Register</h3>
            <div class="mb-3">
                <label for="txtName" class="form-label">Full Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtMobile" class="form-label">Mobile No:</label>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtConfirmPassword" class="form-label">Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3 form-check">
                <asp:CheckBox ID="chkShowPassword" runat="server" CssClass="form-check-input" AutoPostBack="true" />
                <label class="form-check-label">Show Password</label>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success w-100"
                OnClick="btnRegister_Click" OnClientClick="return validatePasswords();" />
            <div class="mt-3 text-center">
                <a href="Login.aspx">Already have an account? Login here</a>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="d-block text-center mt-2"></asp:Label>
        </div>
    </form>
</body>
</html>
