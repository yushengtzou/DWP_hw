<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Our Password-Protected Book Information Site</h2>
    <p>
        To learn more about our books, <a href="ProtectedContent/Books.aspx">click here</a> or click the Books tab in the 
        navigation bar above. You must be logged in to view the Books page.</p>
    </asp:Content>