<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Auction.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <% if (Session["id"] == null) { %>
    <form action="login.ashx" method="post" class="form-horizontal">
        <!-- Form Name -->
        <fieldset>
            <legend>Login</legend>
            <label class="control-label" for="username">Username</label><input type="text" id="username" name="username" placeholder="Login Username" class="form-control input-md"/>
            <label class="control-label" for="password">Password</label><input type="password" id="password" name="password" placeholder="Login Password" class="form-control input-md"/>
            <% //<asp:Button runat="server" text="Submit" OnClick="SubmitForm" /> %>
            <input class="btn btn-primary" type="submit" value="Log In" />
        </fieldset>
    </form>
    <a href="register.aspx">Register</a>
    <% } else { %>
        We are logged in...
    <%} %>
</asp:Content>