<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new.aspx.cs" Inherits="TWART.Views.Customer.new" %>

<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="TWART.DataObjects" %>
<!DOCTYPE html>
<html>
<head>
    <title>TWART Shipping Co.</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" href="/assets/css/main.css" />
    <!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
    <!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
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
                <p id="session">Welcome <%=Session["username"].ToString() %></p>
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="adminIndex" id="foobar-link"><span class="icon fa-hand-o-left">Control Panel</span></a></li>
                    <li><a href="#newClient" id="newClientSection" class="skel-layers-ignoreHref"><span class="icon fa-plus">New Client</span></a></li>
                    <li><a href="#clientList" id="clientListSection" class="skel-layers-ignoreHref"><span class="icon fa-list">Client List</span></a></li>
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
                    <h2>Create A New Client</h2>
                </header>
            </div>
        </section>
        <!-- Controls -->
        <section id="clientList" class="two">
            <div class="container">
                <form action="/Customer/create" method="POST" runat="server">
                    <table>
                        <tr>
                            <asp:TextBox runat="server" ID="newClientName">Client Name</asp:TextBox>
                        </tr>
                        <tr>
                            <% foreach (var addresses in Model)
                               {
                                   //creates list items
                                   ListItem item = new ListItem(addresses.LineOne.ToString() + ", " + addresses.LineTwo.ToString() + ", " + addresses.PostalCode.ToString());
                                   item.Value = addresses.ID.ToString();
                                   newAddress.Items.Add(item);
                               } %>
                            <asp:DropDownList runat="server" ID="newAddress"></asp:DropDownList>
                        </tr>
                        <tr>
                            <% foreach (var bank in Model)
                               {
                                   //creates list items
                                   ListItem item = new ListItem(bank);
                                   item.Value = bank.ID.ToString();
                                   bankList.Items.Add(item);
                               } %>
                            <asp:DropDownList runat="server" ID="bankList"></asp:DropDownList>
                        </tr>
                        <tr>
                            <asp:DropDownList runat="server" ID="accountType">
                                <asp:ListItem>Standard</asp:ListItem>
                                <asp:ListItem>Premium</asp:ListItem>
                            </asp:DropDownList>
                        </tr>
                    </table>
                    <div class="row">
                        <div class="12u$">
                            <input type="submit" value="Add" />
                        </div>
                    </div>
                </form>
            </div>
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
