<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Auction.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <% //Session["Name"] = "test"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <% if (Session["username"] != null) { %>
    Welcome, <%: Session["username"] %> (<a href="logout.aspx">Logout</a>)
    <p id="test">Click <a href="test.aspx">TEST</a></p>
    <% } else { %>
    <form action="login.aspx" method="post">
        <label for="username">Username</label><input type="text" runat="server" id="username" />
        <% //<asp:Button runat="server" text="Submit" OnClick="SubmitForm" /> test %> 
        <input type="submit" value="Log In" />
    </form>
        <a href="register.aspx">Register</a>
     <% } %>
    
</asp:Content>
