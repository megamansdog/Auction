<%@ Page Title="Test" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Auction.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    This is a test for <%: Session["username"] %>
    <a href="index.aspx">Home</a>
</asp:Content>
