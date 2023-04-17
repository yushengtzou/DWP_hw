<%@ Page Title="Books" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Books.aspx.vb" Inherits="ProtectedContent_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <p title="Book Information">
      Author:
   <asp:DropDownList ID="authorsDropDownList" runat="server" 
         DataSourceID="authorsLinqDataSource" AutoPostBack="True" 
         DataTextField="Name" DataValueField="AuthorID">
   </asp:DropDownList>
      <asp:LinqDataSource ID="authorsLinqDataSource" runat="server">
      </asp:LinqDataSource>
</p>
<p>
   <asp:GridView ID="titlesGridView" runat="server" AllowPaging="True" 
      AllowSorting="True" AutoGenerateColumns="False" 
      DataSourceID="titlesLinqDataSource" PageSize="4" Width="580px">
      <Columns>
         <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
         <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
         <asp:BoundField DataField="EditionNumber" HeaderText="Edition Number" 
            SortExpression="EditionNumber" />
         <asp:BoundField DataField="Copyright" HeaderText="Copyright" 
            SortExpression="Copyright" />
      </Columns>
   </asp:GridView>
   <asp:LinqDataSource ID="titlesLinqDataSource" runat="server">
   </asp:LinqDataSource>
</p>
</asp:Content>

