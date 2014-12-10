<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="item_add.aspx.cs" Inherits="Auction.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form class="form-horizontal" method="post" action="item_add.aspx" enctype="multipart/form-data">
    <fieldset>

    <!-- Form Name -->
    <legend>New Item</legend>

    <!-- Name input-->
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_name">Item Name</label>  
      <div class="col-md-4">
      <input id="item_name" name="item_name" type="text" placeholder="Item Name" class="form-control input-md" />
      <span class="help-block">Name of the item you are selling</span>  
      </div>
    </div>

    <!-- Condition Select -->
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_condition">Condition</label>
      <div class="col-md-4">
        <select id="item_condition" name="item_condition" class="form-control">
          <option value="new">New</option>
          <option value="refurbished">Refurbished</option>
          <option value="explained">Explained</option>
        </select>
      </div>
    </div>

    <!-- Initial Price input-->
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_initial_price">Initial Price</label>  
      <div class="col-md-4">
      <input id="item_initial_price" name="item_initial_price" type="text" placeholder="Initial Price" class="form-control input-md" />
      <span class="help-block">Starting price for your item</span>  
      </div>
    </div>

    <!-- Description input-->
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_description">Item Description</label>  
      <div class="col-md-4">
      <textarea id="item_description" name="item_description" type="text" placeholder="Item Description" class="form-control input-md"></textarea>
      <span class="help-block">A brief description of your item</span>  
      </div>
    </div>

    <!-- Quantity input-->
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_quantity">Quantity</label>  
      <div class="col-md-4">
      <input id="item_quantity" name="item_quantity" type="text" placeholder="Quantity" class="form-control input-md" />
      <span class="help-block">The amount of individual items. Highest bidder wins all.</span>  
      </div>
    </div>

    <!-- Image Files Button --> 
    <div class="form-group">
      <label class="col-md-4 control-label" for="item_pictures">Pictures</label>
      <div class="col-md-4">
        <input id="item_pictures" name="item_pictures" class="input-file" type="file" multiple />
      </div>
    </div>

    <!-- Duration input-->
    <div class="form-group">
        <label class="col-md-4 control-label" for="item_duration">Duration</label>  
        <div class="col-md-1">
            <input id="item_duration" name="item_duration" type="number" placeholder="Duration" class="form-control input-md" min="1" max="60" />
            <span class="help-block">Length of time you wish for your auction to live</span>  
        </div>
        <div class="col-md-1">
        <select id="item_duration_type" name="item_duration_type" class="form-control">
            <option value="minutes">Minutes</option>
            <option value="hours">Hours</option>
            <option value="days">Days</option>
        </select>
        </div>
    </div>

    <!-- Submit Button -->
    <div class="form-group">
      <div class="col-md-4 col-md-offset-4">
        <button type="submit" id="item_submit" name="item_submit" class="btn btn-primary">Submit</button>
      </div>
    </div>

    <!-- Form Action -->
    <input type="hidden" name="action" value="item_add" />

    </fieldset>
    </form>

</asp:Content>
