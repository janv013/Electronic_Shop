<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Electronic_Shop.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function togglePassword() {
            var passwordInput = document.getElementById('<%= txtPassword.ClientID %>');
            var checkBox = document.getElementById('chkShowPassword');
            if (checkBox.checked) {
                passwordInput.type = "text";
            } else {
                passwordInput.type = "password";
            }
        }
    </script>
</head>
<body class="d-flex justify-content-center align-items-center vh-100 bg-light">
    <form id="form1" runat="server">
        <div class="card p-4 shadow" style="width: 400px;">
            <h3 class="text-center">Login</h3>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            </div>
            <div class="mb-3 form-check">
                <input type="checkbox" id="chkShowPassword" class="form-check-input" onclick="togglePassword()" />
                <label for="chkShowPassword" class="form-check-label">Show Password</label>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
            <div class="mt-3 text-center">
                <a href="Register.aspx">Not registered? Sign up here</a>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="d-block text-center mt-2"></asp:Label>
        </div>
    </form>
</body>
</html>
