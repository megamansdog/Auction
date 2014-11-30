<%@ Page Title="Register" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Auction.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form method="post" action="register.aspx">
        <label for="username">Username: </label><input type="text" name="username" />
        <label for="password">Password: </label><input type="password" name="password" />
        <label for="email">Email: </label><input type="email" name="email" />
        <input type="submit" value="Register" />
    </form>
    <a href="index.aspx">Home</a>
</asp:Content>
