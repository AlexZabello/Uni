<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Uni.Pages.Auth.ManageUsers" MasterPageFile="~/Pages/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ListView ID="ListView1" runat="server" ItemType="Uni.Models.UserModel" SelectMethod="GetUsers"
        UpdateMethod="UpdateUser" EnableViewState="false">
        <LayoutTemplate>
            <table>
                    <tr>
                        <th>Login</th>
                        <th>Role</th>
                    </tr>
                <tr runat="server" id="itemPlaceHolder"></tr>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                
                <td><%# Item.Login  %>
                    <input type="hidden" name="UserModel.UserId" value="<%# Item.UserId %>" />
                </td>
                <td><%# Item.UserRole %></td>
                <td><asp:Button ID="button1" CommandName="Edit" Text="Edit" runat="server" /></td>
                
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                    
                    <td><asp:Label ID="Login" runat="server" Text="<%# BindItem.Login%>"/>
                        <asp:HiddenField ID="UserId" runat="server" Value="<%# BindItem.UserId %>"/>
                        
                    </td>
                    <td><asp:DropDownList ID="DDLRole" AutoPostBack="false" SelectMethod="GetRoles" DataTextField="Name" DataValueField="UserRoleId" runat="server" SelectedValue='<%# BindItem.UserRoleId %>'></asp:DropDownList></td>
                    <td>
                        <asp:Button ID="button3" CommandName="Update" Text="Update" runat="server" />
                        <asp:Button ID="button4" CommandName="Cancel" Text="Cancel" runat="server" />
                    </td>
                </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>