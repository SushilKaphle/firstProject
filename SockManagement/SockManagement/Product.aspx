<%@ Page Title="" Language="C#" MasterPageFile="~/SM_Master.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="SockManagement.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Product Registration</h1>
    <table>
        <tr>
            <td>Select PoroductId</td>
            <td>
                <asp:DropDownList ID="ddlProductId" AutoPostBack = "true" runat ="server" OnSelectedIndexChanged="ddlProductId_SelectedIndexChanged"></asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td> ProductId   </td>
            <td>
                <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Product Name</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Product Type</td>
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
            <td>
                <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
            
                <asp:Button ID="btnUpdate" runat="server" Text="Update Product" OnClick="btnUpdate_Click" />
            
                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" OnClick="btnDelete_Click" />
               
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdProduct" runat="server"></asp:GridView>

</asp:Content>
