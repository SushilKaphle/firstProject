<%@ Page Title="" Language="C#" MasterPageFile="~/SM_Master.Master" AutoEventWireup="true" CodeBehind="SalesPage.aspx.cs" Inherits="SockManagement.SalesPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td> Select ProductID</td>
            <td>
                <asp:DropDownList ID="ddlProductId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProductId_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>ProductId</td>
            <td>
                <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>ProductName</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>ProductType</td>
            <td>
                <asp:TextBox ID="txtProductType" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>PDiscription</td>
            <td>
                <asp:TextBox ID="txtPDiscription" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>Qty</td>
            <td>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        
    </table>


</asp:Content>
