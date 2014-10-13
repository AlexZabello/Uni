<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Uni.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RequiredFieldValidator ID="LoginValidator" runat="server" ErrorMessage="Login required" 
            ControlToValidate="txtLogin" ToolTip="Login required">*</asp:RequiredFieldValidator>
        <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="PassValidator" runat="server" ErrorMessage="Password required" 
            ControlToValidate="txtPassword" ToolTip="Password required">*</asp:RequiredFieldValidator>
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
        <asp:Button ID="cmdRegister" runat="server" Text="Register" />
    
    </div>
    </form>
</body>
</html>
