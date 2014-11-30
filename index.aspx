<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Auction.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <% //Session["Name"] = "test"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <% if (Session["id"] != null) { %>
    Welcome, <%: Session["username"] %> (<a href="logout.aspx">Logout</a>)
    <p id="test">Click <a href="test.aspx">TEST</a></p>
    <% } else { %>
    <form action="login.ashx" method="post">
        <label for="username">Username</label><input type="text" id="username" name="username"/>
        <label for="password">Password</label><input type="password" id="password" name="password"/>
        <% //<asp:Button runat="server" text="Submit" OnClick="SubmitForm" /> %>
        <input type="submit" value="Log In" />
    </form>
        <a href="register.aspx">Register</a>
     <% } %>
    
</asp:Content>