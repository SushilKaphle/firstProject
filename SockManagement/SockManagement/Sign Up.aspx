<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign Up.aspx.cs" Inherits="SockManagement.Sign_Up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <table>
                <tr>
                    <td> Select Id</td>
                    <td>
                        <asp:DropDownList ID="ddlIds" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlIds_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLAstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>User Name</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>PassWord</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> User type</td>
                    <td>
                        <asp:RadioButtonList ID="rblUserType" runat="server">
                            <asp:ListItem Text="User" Value="0" />
                            <asp:ListItem Text="Admin" Value="1" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSignUp" runat="server" Text="Create" OnClick="btnSignUp_Click" Width="67px" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                     </td>
                </tr>

            </table>


        </div>
       <%--<p>&nbsp;</p>--%>
    </form>
</body>
</html>
