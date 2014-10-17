<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignStudent.aspx.cs" Inherits="Uni.Pages.Teacher.AssignStudent" MasterPageFile="~/Pages/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="students">
        <table>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Subject Name</th>
            </tr>
        <asp:Repeater ID="repeater1" ItemType="DataLayer.Entity.Student" SelectMethod="GetStudents" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Item.FirstName %></td>
                    <td><%# Item.LastName %></td>
                    <td><%# Item.Subject.Name %></td>
                    <td><button type="button">Select</button></td>
                </tr>
            </ItemTemplate>
            
        </asp:Repeater>
            </table>
    </div>
    <div id="buttons">
        <p><asp:Button ID="bLeft" runat="server" Text="Exclude" OnClick="OnButtonLeft_Click" /></p>
        <p><asp:Button ID="bRight" runat="server" Text="Include" OnClick="OnButtonRight_Click" /></p>
    </div>
    <div id="groupStudent">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="DDLGroup" runat="server" DataTextField="Name" DataValueField="GroupId" 
            AutoPostBack="true" OnSelectedIndexChanged="DDLGroup_SelectedIndexChanged" ></asp:DropDownList>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Subject Name</th>
                    </tr>

                    <asp:Repeater ID="repeaterGroup" runat="server" ItemType="DataLayer.Entity.Student">
                        <ItemTemplate>
                            <tr>
                            <td><%# Item.FirstName %></td>
                            <td><%# Item.LastName %></td>
                            <td><%# Item.Subject.Name %></td>
                                <td><button type="button">Select</button></td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DDLGroup" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>