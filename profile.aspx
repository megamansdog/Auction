<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Auction.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h2>Credit Cards</h2>
    <form method="post" action="profile.aspx" class="form-horizontal">
        <fieldset>
        <legend>Add Credit Card</legend>
            <div class="form-group col-md-4">
                <label for="owner">Owner</label><input type="text" id="owner" name="owner" class="form-control input-md" />
                <label for="number">Number</label><input type="number" id="number" name="number" class="form-control input-md" />
                <label for="expiration">Expiration</label><input type="date" id="expiration" name="expiration" class="form-control input-md" />
                <input type="hidden" name="action" value="createCC"/>
                <input type="submit" name="submit" id="submitCC" class="btn btn-primary" />
            </div>
        </fieldset>
    </form>
    <h3>List of Current Cards</h3>
    <ul class="list-group">
        <% 
            foreach (Auction.CCInfo CC in CCList)
            {
        %>
        <li class="list-group-item">Owner: <%: CC.owner %><br />Number: <%: CC.number %><br />Expires: <%: CC.expiration.ToString("d") %></li>
        <%
            }
        %>
    </ul>

    <h2>Contact Information</h2>
    <form method="post" action="profile.aspx" class="form-horizontal">
        <fieldset>
        <legend>Add Contact Information</legend>
            <div class="form-group col-md-4">
                <label for="phone_number">Phone Number</label><input type="text" id="phone_number" name="phone_number" />
                <input type="hidden" name="action" value="createContactInfo"/>
                <input type="submit" name="submit" id="submitContactInfo" />
            </div>
        </fieldset>
    </form>
    <h3>List of Current Contact Information</h3>
    <ul class="list-group">
        <% 
        foreach (Auction.ContactInfo ContactInfo in ContactList)
        {
        %>
        <li class="list-group-item">Phone Number: <%: ContactInfo.phone_number %></li>
        <%
            }
        %>
    </ul>


    <h2>Addresses</h2>
    <form method="post" action="profile.aspx" class="form-horizontal">
        <fieldset>
        <legend>Add Address</legend>
            <div class="form-group col-md-4">
                <label for="street_number">Street Number</label><input type="text" id="street_number" name="street_number" />
                <label for="street_name">Street Name</label><input type="text" id="street_name" name="street_name" />
                <label for="city">City</label><input type="text" id="city" name="city" />
                <label for="state">State</label><input type="text" id="state" name="state" />
                <label for="zip">Zip</label><input type="text" id="zip" name="zip" />
                <input type="hidden" name="action" value="createAddress"/>
                <input type="submit" name="submit" id="submitAddress" />
            </div>
        </fieldset>
    </form>
    <h3>List of Current Addresses</h3>
    <ul class="list-group">
        <% 
        foreach (Auction.Address Address in AddressList)
        {
        %>
        <li class="list-group-item">Address: <%: Address.street_number + " " + Address.street_name + " " + Address.city + " " + Address.state + " " + Address.zip %></li>
        <%
            }
        %>
    </ul>
</asp:Content>
