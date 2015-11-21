<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newCustomer.aspx.cs" Inherits="TWART.Views.Admin.newCustomerView" %>

<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="TWART.DataObjects" %>
<!DOCTYPE html>
<html>
<head>
    <title>TWART Shipping Co.</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" href="../../assets/css/main.css" />
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
                    <img src="../../images/avatar.jpg" alt="" /></span>
                <h1 id="title">TWART Shipping Corporation</h1>
                <p id="session">Welcome <%=Session["username"].ToString() %></p>
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="adminIndex" id="foobar-link"><span class="icon fa-hand-o-left">Control Panel</span></a></li>
                </ul>
            </nav>
        </div>
        <div class="bottom">
            <!-- Social Icons -->
            <ul class="icons">
                <li><a href="https://github.com/campbellre/TWART" class="icon fa-github"><span class="label">Github</span></a></li>
                <li><a href="../../index.html#contact" class="icon fa-envelope"><span class="label">Email</span></a></li>
            </ul>
        </div>
    </div>
    <!-- Main -->
    <div id="main">
        <!-- Client View -->
        <section id="client" class="top">
            <div class="container">
                <header>
                    <h2>Create a new Customer</h2>
                </header>
            </div>
        </section>
        <!-- Controls -->
        <section id="controls" class="two">
            <div class="container">
                <form action="createCustomer" method="POST" runat="server">
                    <table>
                        <tr>
                            <% foreach (var addresses in Model)
                               {
                                   //creates list items
                                   ListItem item = new ListItem(addresses.ID + ", " + addresses.LineOne.ToString() + ", " + addresses.LineTwo.ToString() + ", " + addresses.PostalCode.ToString());
                                   item.Value = addresses.ID.ToString();
                                   newAddress.Items.Add(item);
                               } %>
                            <asp:TextBox runat="server" ID="newClientName">Client Name</asp:TextBox>
                    <br />
                            <asp:DropDownList runat="server" ID="newAddress"></asp:DropDownList>
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
    <script src="../../assets/js/jquery.min.js"></script>
    <script src="../../assets/js/jquery.scrolly.min.js"></script>
    <script src="../../assets/js/jquery.scrollzer.min.js"></script>
    <script src="../../assets/js/skel.min.js"></script>
    <script src="../../assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="../../assets/js/main.js"></script>
</body>
</html>
