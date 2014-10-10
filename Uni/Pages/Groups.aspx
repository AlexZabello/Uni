<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="Uni.Pages.Groups" MasterPageFile="~/Pages/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="Repeater1" ItemType="Uni.Models.GroupModel" SelectMethod="GetGroups" runat="server">
        <HeaderTemplate>
            <table>
                    <tr>
                        <th>Group Name</th>
                        <th>Subject Name</th>
                        <th>Prof</th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Name %></td>
                <td><%# Item.SubjectName %></td>
                <td><%# Item.ProfName %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="3" align="right"><%= GroupCount() %></td>
                
            </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
