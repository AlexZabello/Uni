<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Uni.Pages.Students" MasterPageFile="~/Pages/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Subject</th>
            <th>Group</th>
            <th>Prof</th>
            
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="fName" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="lName" runat="server"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="DDLSubject" AutoPostBack="false" runat="server"
                    DataTextField="Name" DataValueField="SubjectId">
                </asp:DropDownList></td>
            <td>
                <asp:DropDownList ID="DDLGroup" AutoPostBack="false" runat="server"
                    DataTextField="Name" DataValueField="GroupId">
                </asp:DropDownList></td>
            <td></td>
            <td>
                <asp:Button ID="bSearch" runat="server" Text="Search" OnClick="OnButtonSearch_Click" /></td>
        </tr>
            <asp:Repeater ID="Repeater1" ItemType="Uni.Models.StudentViewModel" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Item.FirstName %></td>
                        <td><%# Item.LastName %></td>
                        <td><%# Item.SubjectName %></td>
                        <td><%# Item.GroupName %></td>
                        <td><%# Item.ProfName %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
          </table>     
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="bSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        
    
</asp:Content>