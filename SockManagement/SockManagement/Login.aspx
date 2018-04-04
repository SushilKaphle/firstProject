<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SockManagement.Login" %>

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
                    <td>User Name</td>
                    
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>UserPasswor</td>
                    <td>
                            <asp:TextBox ID="txtPassword1" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnSignUp" runat="server" Text="SignUp" OnClick="btnSignUp_Click" />
                    </td>
                </tr>
            </table>

            <asp:Label ID="txtMessage" runat="server" BackColor="Red" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
