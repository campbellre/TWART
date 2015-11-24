<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="TWART.Views.Order.newOrderView" %>

<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="TWART.DataObjects" %>
<!DOCTYPE html>
<html>
<head>
    <title>TWART Shipping Co.</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="/assets/js/ie/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" href="/assets/css/main.css" />
    <!--[if lte IE 8]><link rel="stylesheet" href="/assets/css/ie8.css" /><![endif]-->
    <!--[if lte IE 9]><link rel="stylesheet" href="/assets/css/ie9.css" /><![endif]-->
</head>
<body>
    <!-- Header -->
    <div id="header">
        <div class="top">
            <!-- Logo -->
            <div id="logo">
                <span class="image avatar48">
                    <img src="/images/avatar.jpg" alt="" /></span>
                <h1 id="title">TWART Shipping Corporation</h1>
                <p id="session">Welcome <%= Session["username"] == null ? Session["username"].ToString() : "" %></p>
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="adminIndex" id="foobar-link"><span class="icon fa-hand-o-left">Control Panel</span></a></li>
                    <li><a href="#newOrder" id="newOrderSection" class="skel-layers-ignoreHref"><span class="icon fa-plus">New Order</span></a></li>
                </ul>
            </nav>
        </div>
        <div class="bottom">
            <!-- Social Icons -->
            <ul class="icons">
                <li><a href="https://github.com/campbellre/TWART" class="icon fa-github"><span class="label">Github</span></a></li>
                <li><a href="/index.html#contact" class="icon fa-envelope"><span class="label">Email</span></a></li>
            </ul>
        </div>
    </div>
    <!-- Main -->
    <div id="main">
        <!-- Client View -->
        <section id="newClient" class="top">
            <div class="container">
                <header>
                    <h2>Create A New Order</h2>
                </header>
            </div>
        </section>
        <!-- Controls -->
        <section id="newOrder" class="two">
            <form action="/order/createOrder" method="POST" runat="server">
                <div class="container">
                    <table>
                        <% foreach (var addresses in Model)
                            {
                                //creates list items
                                ListItem item = new ListItem(addresses.LineOne.ToString() + ", " + addresses.LineTwo.ToString() + ", " + addresses.PostalCode.ToString());
                                item.Value = addresses.ID.ToString();
                                address1.Items.Add(item);
                                ListItem item2 = new ListItem(addresses.LineOne.ToString() + ", " + addresses.LineTwo.ToString() + ", " + addresses.PostalCode.ToString());
                                item2.Value = addresses.ID.ToString();
                                address2.Items.Add(item);
                            } %>
                        <tr title="Source Address:">
                            <asp:DropDownList runat="server" ID="address1"></asp:DropDownList>
                        </tr>
                        <tr title="Destination Address:">
                            <asp:DropDownList runat="server" ID="address2"></asp:DropDownList>
                        </tr>
                        <tr>
                            <asp:TextBox runat="server" ID="weight">Weight (Grams)</asp:TextBox>
                            <asp:RegularExpressionValidator ID="weightConfirm" ControlToValidate="weight" BackColor="Red" runat="server" ErrorMessage="Invalid Weight" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            <asp:TextBox runat="server" ID="height">Height (CM)</asp:TextBox>
                            <asp:RegularExpressionValidator ID="heightConfirm" ControlToValidate="height" runat="server" ErrorMessage="Invalid Height" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            <asp:TextBox runat="server" ID="width">Width (CM)</asp:TextBox>
                            <asp:RegularExpressionValidator ID="widthConfirm" ControlToValidate="width" runat="server" ErrorMessage="Invalid Width" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            <asp:TextBox runat="server" ID="length">Length (CM)</asp:TextBox>
                            <asp:RegularExpressionValidator ID="lengthConfirm" ControlToValidate="length" runat="server" ErrorMessage="Invalid Length" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </tr>
                        <tr>
                            <asp:TextBox runat="server" ID="goodsDescriptor">Package Description</asp:TextBox>
                            <asp:DropDownList runat="server" ID="options">
                                <asp:ListItem>Handle With Care</asp:ListItem>
                                <asp:ListItem>Very Fragile - Glass</asp:ListItem>
                                <asp:ListItem>Very Fragile - Electronics</asp:ListItem>
                                <asp:ListItem>Heavy (10-20kg)</asp:ListItem>
                                <asp:ListItem>Very Heavy (20kg+)</asp:ListItem>
                            </asp:DropDownList>
                        </tr>
                        <tr>
                            <asp:DropDownList runat="server" ID="deliveryBands">
                                <asp:ListItem>Next Day Delivery</asp:ListItem>
                                <asp:ListItem>Express 1-2 Days</asp:ListItem>
                                <asp:ListItem>Standard 3-5 Days</asp:ListItem>
                                <asp:ListItem>Basic 5-10 Days</asp:ListItem>
                            </asp:DropDownList>
                        </tr>
                    </table>
                    <div class="row">
                        <div class="12u$">
                            <input type="submit" value="Place Order" />
                        </div>
                    </div>
                </div>
            </form>
        </section>
    </div>
    <!-- Footer -->
    <div id="footer">
        <!-- Copyright -->
        <ul class="copyright">
            <li>&copy; TWART Shipping Co. All rights reserved.</li>
        </ul>
    </div>
    <!-- Scripts -->
    <script src="/assets/js/jquery.min.js"></script>
    <script src="/assets/js/jquery.scrolly.min.js"></script>
    <script src="/assets/js/jquery.scrollzer.min.js"></script>
    <script src="/assets/js/skel.min.js"></script>
    <script src="/assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="/assets/js/main.js"></script>
</body>
</html>
