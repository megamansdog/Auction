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
    <div class="row">
        <% 
            foreach (Auction.Item Item in ItemList)
            {
        %>
          <div class="col-sm-6 col-md-2">
            <div class="thumbnail">
              <img src="http://localhost:57608/showpicture.ashx?imageid=<%: db.GetFirstItemPicture(Item.id) %>" alt="...">
              <div class="caption">
                <h3><%: Item.name %></h3>
                <p><%: Item.description %></p>
                  <p>Ends: <%: Item.end_time %></p>
                <p><a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
              </div>
            </div>
           </div>
        <%
            }
        %>
     </div>
    <%} %>
</asp:Content>