<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Auction.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h2>Credit Cards</h2>
    <h3>Add Credit Card</h3>
    <form method="post" action="profile.aspx">
        <label for="owner">Owner</label><input type="text" id="owner" name="owner" />
        <label for="number">Number</label><input type="number" id="number" name="number" />
        <label for="expiration">Expiration</label><input type="date" id="expiration" name="expiration" />
        <input type="hidden" name="action" value="createCC"/>
        <input type="submit" name="submit" id="submit" />
    </form>
    <h3>List of Current Cards</h3>
    <ul>
        <% 
            foreach (Auction.CCInfo CC in CCList)
            {
        %>
        <li>Owner: <%: CC.owner %> - Number: <%: CC.number %> - Expires: <%: CC.expiration.ToString("d") %></li>
        <%
            }
        %>
    </ul>

    <h2>Contact Information</h2>
    <h3>Add Contact Information</h3>
    <form method="post" action="profile.aspx">
        <label for="owner">Owner</label><input type="text" id="owner" name="owner" />
        <label for="number">Number</label><input type="number" id="number" name="number" />
        <label for="expiration">Expiration</label><input type="date" id="expiration" name="expiration" />
        <input type="hidden" name="action" value="createCC"/>
        <input type="submit" name="submit" id="submit" />
    </form>
    <h3>List of Current Contact Information</h3>
        <% 
        foreach (Auction.CCInfo CC in CCList)
        {
        %>
        <li>Owner: <%: CC.owner %> - Number: <%: CC.number %> - Expires: <%: CC.expiration.ToString("d") %></li>
        <%
            }
        %>
</asp:Content>
