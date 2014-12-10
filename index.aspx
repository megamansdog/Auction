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
    <div class="row equal">
        <% 
            foreach (Auction.Item Item in ItemList)
            {
        %>
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <a href="item_view.aspx?itemid=<%: Item.id %>"><img src="showpicture.ashx?imageid=<%: db.GetFirstItemPicture(Item.id) %>" alt="..."></a>
                    <div class="caption"><h3><a href="item_view.aspx?itemid=<%: Item.id %>"><%: Item.name %></a></h3></div>
                </div>
                <div class="">
                        <p class="item_description"><%: Item.description %></p>
                            <p>Ends: <%: Item.end_time %></p>
                        <p><a href="item_view.aspx?itemid=<%: Item.id %>" class="btn btn-primary" role="button">View</a></p>
                </div>
            </div>
        <%
            }
        %>
     </div>

    <div class="row">

    </div>
    <%} %>
</asp:Content>