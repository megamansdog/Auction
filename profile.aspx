<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Auction.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h2>Credit Cards</h2>
    <h3>Add Credit Card</h3>
    <form method="post" action="profile.aspx" class="form-horizontal">
        <label for="owner">Owner</label><input type="text" id="owner" name="owner" />
        <label for="number">Number</label><input type="number" id="number" name="number" />
        <label for="expiration">Expiration</label><input type="date" id="expiration" name="expiration" />
        <input type="hidden" name="action" value="createCC"/>
        <input type="submit" name="submit" id="submitCC" />
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
    <form method="post" action="profile.aspx" class="form-horizontal">
        <label for="phone_number">Phone Number</label><input type="text" id="phone_number" name="phone_number" />
        <input type="hidden" name="action" value="createContactInfo"/>
        <input type="submit" name="submit" id="submitContactInfo" />
    </form>
    <h3>List of Current Contact Information</h3>
    <ul>
        <% 
        foreach (Auction.ContactInfo ContactInfo in ContactList)
        {
        %>
        <li>Phone Number: <%: ContactInfo.phone_number %></li>
        <%
            }
        %>
    </ul>


    <h2>Addresses</h2>
    <h3>Add Address</h3>
    <form method="post" action="profile.aspx" class="form-horizontal">
        <label for="street_number">Street Number</label><input type="text" id="street_number" name="street_number" />
        <label for="street_name">Street Name</label><input type="text" id="street_name" name="street_name" />
        <label for="city">City</label><input type="text" id="city" name="city" />
        <label for="state">State</label><input type="text" id="state" name="state" />
        <label for="zip">Zip</label><input type="text" id="zip" name="zip" />
        <input type="hidden" name="action" value="createAddress"/>
        <input type="submit" name="submit" id="submitAddress" />
    </form>
    <h3>List of Current Addresses</h3>
    <ul>
        <% 
        foreach (Auction.Address Address in AddressList)
        {
        %>
        <li>Address: <%: Address.street_number + Address.street_name + Address.city + Address.state + Address.zip %></li>
        <%
            }
        %>
    </ul>
</asp:Content>
