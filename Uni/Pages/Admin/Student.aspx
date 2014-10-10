<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Uni.Pages.Admin.Student" MasterPageFile="~/Pages/Admin/Admin.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:ListView ID="ListView1" ItemType="DataLayer.Entity.Student" SelectMethod="GetStudents"
            DataKeyNames="StudentId" UpdateMethod="UpdateStudent" DeleteMethod="DeleteStudent" InsertMethod="InsertStudent" InsertItemPosition="LastItem"
            EnableViewState="false" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Subject</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Item.FirstName %></td>
                    <td><%# Item.LastName %></td>
                    <td><%# Item.Subject.Name %></td>
                    <td>
                        <asp:Button ID="button1" CommandName="Edit" Text="Edit" runat="server" />
                        <asp:Button ID="button2" CommandName="Delete" Text="Delete" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <input type="hidden" name="StudentId" value="<%# Item.StudentId %>" />
                    <td><asp:TextBox ID="FName" runat="server" Text="<%# BindItem.FirstName %>"/>
                        
                    </td>
                    <td><asp:TextBox ID="LName" runat="server" Text="<%# BindItem.LastName %>"/></td>
                    <td><asp:DropDownList ID="DDLSubject" AutoPostBack="false" SelectMethod="GetSubjects"
                        DataTextField="Name" DataValueField="SubjectId" runat="server" SelectedValue='<%# BindItem.SubjectId %>'></asp:DropDownList></td>
                    <td>
                        <asp:Button ID="button3" CommandName="Update" Text="Update" runat="server" />
                        <asp:Button ID="button4" CommandName="Cancel" Text="Cancel" runat="server" />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
            <tr>
                <td><asp:TextBox ID="FName" runat="server" Text="<%# BindItem.FirstName %>"></asp:TextBox>
                    <input type="hidden" name="StudentID" value="0" />
                </td>
                <td><asp:TextBox ID="LName" runat="server" Text="<%# BindItem.LastName %>"></asp:TextBox></td>
                <td><asp:DropDownList ID="DDLSubject" AutoPostBack="false" SelectMethod="GetSubjects"
                    DataTextField="Name" DataValueField="SubjectId" runat="server" SelectedValue='<%# BindItem.SubjectId %>'></asp:DropDownList> </td>
                <td>
                    <asp:Button ID="Button5" CommandName="Insert" Text="Add" runat="server"/>
                </td>
            </tr>
        </InsertItemTemplate>
        </asp:ListView>

    
</asp:Content>
