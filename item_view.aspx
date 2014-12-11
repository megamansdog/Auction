<%@ Page Title="item.name" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="item_view.aspx.cs" Inherits="Auction.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="countdown.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitlePlaceHolder" runat="server">
    <% if (DateTime.Now < item.end_time) {  %>
    <h1 class="col-md-12"><%: Page.Title %><span class="label label-success pull-right">Active</span></h1>
    <div class="row col-md-12">
       <span id="countdown-holder" class="label label-primary pull-right"></span>
    </div>
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
        <form class="form-inline col-md-3" action="bid_add.ashx" method="post" role="form">
            <fieldset>

        <!-- Bid Form -->
                <legend>Bid</legend>

        <!-- Bid Amount input-->
                <div class="form-group">
                    <div class="input-group">
                      <label class="control-label sr-only" for="bid_amount">Amount (USD):</label>  
                      <input id="bid_amount" name="bid_amount" type="number" step="any" placeholder="1.50" class="form-control" required />
                  </div>
                </div>
                <div class="form-group">
                    <button id="bid_submit" class="btn btn-primary form-control"><% if ((int)Session["id"] == item.userid){ %>Set Initial Price<% } else { %>Bid<% } %></button>
                </div>
                <input type="hidden" name="action" value="bid_add" />
                <input type="hidden" name="itemid" value="<%: item.id %>" />
            </fieldset>
        </form>
        <!-- Current High Amount & Bidder -->
        <div class="col-md-2"><legend>Highest Bid:</legend>$<%: highestBid.bid_amount %></div>
    </div>
    <hr />
    <!-- Item Description -->
    <div class="row col-md-12 row-centered">
        <div class="col-md-1">
            <h4>Description:</h4>
        </div>
        <div class="col-md-11 col-centered">
            <pre><%: item.description %></pre>
        </div>
    </div>

    <script>
        var clock = document.getElementById("countdown-holder"), targetDate = new Date(<%: item.end_time.Year %> , <%: item.end_time.Month %>, <%: item.end_time.Day %> -1, <%: item.end_time.Hour %>,  <%: item.end_time.Minute %>,  <%: item.end_time.Second %>,  <%: item.end_time.Millisecond %> ); // Jan 1, 2050;

        clock.innerHTML = countdown(targetDate).toString();
        setInterval(function () {
            clock.innerHTML = countdown(targetDate).toString();
        }, 1000);
    </script>

</asp:Content>
