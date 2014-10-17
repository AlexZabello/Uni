<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Uni.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        span.error {
            color: red;
            border-bottom: solid double red;
            visibility: collapse;
        }
    </style>
</head>
<body>
    <form runat="server">
        <span id="message" class="error" runat="server">Incorrect username or password</span>
        <div class="loginContainer">
            <div>
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" OnClick="OnButtonLogin_Click" Text="Log In" runat="server"/>
            
        </div>
    </form>
</body>
</html>
