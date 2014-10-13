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
                <label for="name">Name:</label>
                <input name="name" />
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" name="password" />
            </div>
            <button name="action" value="login" type="submit">Log In</button>
        </div>
    </form>
</body>
</html>
