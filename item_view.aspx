<%@ Page Title="item.name" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="item_view.aspx.cs" Inherits="Auction.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitlePlaceHolder" runat="server">
    <% if (DateTime.Now < item.end_time) {  %>
    <h1><%: Page.Title %><span class="label label-success">Active</span></h1>
    <% } else { %>
    <h1><%: Page.Title %><span class="label label-danger">Sold</span></h1>
    <% } %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <!-- Item Pictures -->
    <div class="row">
    <% 
        foreach( Auction.Picture pic in ItemPictureList ) {
    %>
        <div class="col-xs-6 col-md-2">
            <a href="showpicture.ashx?imageid=<%: pic.id %>" data-lightbox="item-images" class="thumbnail">
                <img src="showpicture.ashx?imageid=<%: pic.id %>" alt="<%: pic.image_name %>" />
            </a>
        </div>
    <%
        }
    %>
    </div>

    <!-- Item Price / Bids -->

    <!-- Item Description -->
</asp:Content>
