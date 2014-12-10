<%@ Page Title="item.name" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="item_view.aspx.cs" Inherits="Auction.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitlePlaceHolder" runat="server">
    <% if (DateTime.Now < item.end_time) {  %>
    <h1 class="col-md-12"><%: Page.Title %><span class="label label-success pull-right">Active</span></h1>
    <% } else { %>
    <h1 class="col-md-12"><%: Page.Title %><span class="label label-danger pull-right">Ended</span></h1>
    <% } %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <!-- Item Pictures -->
    <div class="row row-centered">
    <% 
        foreach( Auction.Picture pic in ItemPictureList ) {
    %>
        <div class="col-xs-6 col-md-1 col-centered">
            <a href="showpicture.ashx?imageid=<%: pic.id %>" data-lightbox="item-images" class="thumbnail">
                <img src="showpicture.ashx?imageid=<%: pic.id %>" alt="<%: pic.image_name %>" />
            </a>
        </div>
    <%
        }
    %>
    </div>
    <div class="row">
    <!-- Item Price / Bids -->
        <form class="form-inline col-md-4" action="bid_add.ashx" method="post">
            <fieldset>

        <!-- Bid Form -->
                <legend>Bid</legend>

        <!-- Bid Amount input-->
                <div class="form-group">
                   <label class="col-md-1 control-label" for="bid_amount">Amount (USD):</label>  
                  <div class="col-md-2 col-md-offset-1">
                        <input id="bid_amount" name="bid_amount" type="number" step="any" placeholder="1.50" class="form-control input-md" required />
                  </div>
                  <div class="col-md-2 col-md-offset-4">
                    <button id="singlebutton" name="singlebutton" class="btn btn-primary form-control">Bid</button>
                  </div>
                    <input type="hidden" name="action" value="bid_add" />
                    <input type="hidden" name="itemid" value="<%: item.id %>" />
                </div>
            </fieldset>
        </form>
    </div>
    <hr />
    <!-- Item Description -->
    <div class="row col-md-12 row-centered">
        <div class="col-md-1">
            <h4>Description:</h4>
        </div>
        <div class="col-md-11 col-centered">
            <p><%: item.description %></p>
        </div>
    </div>
</asp:Content>
