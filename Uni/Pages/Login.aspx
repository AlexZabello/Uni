<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Uni.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph" />

        <div class="loginContainer">
            <div>
                <label for="name">Name:</label>
                <input name="name" />
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" name="password" />
            </div>
            <button type="submit">Log In</button>
        </div>
    </form>
</body>
</html>
