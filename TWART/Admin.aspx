﻿<

<!DOCTYPE html>
<html>
<head>
    <title>TWART Shipping Co.</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" href="assets/css/main.css" />
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
                    <img src="images/avatar.jpg" alt="" /></span>
                <h1 id="title">TWART Shipping Corporation</h1>
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="login.html" class="skel-layers-ignoreHref" id="foobar-link"><span class="icon fa-hand-o-right">Log Out</span></a></li>
                </ul>
            </nav>
        </div>
        <div class="bottom">
            <!-- Social Icons -->
            <ul class="icons">
                <li><a href="https://github.com/campbellre/TWART" class="icon fa-github"><span class="label">Github</span></a></li>
                <li><a href="#contact" class="icon fa-envelope"><span class="label">Email</span></a></li>
            </ul>
        </div>
    </div>
    <!-- Main -->
    <form id="admincontrols" runat="server">
        <div id="main">
            <!-- Admin Control Panel -->
            <section id="admin" class="top">
                <div class="container">
                    <header>
                        <h2 style="color: #ff0000">Administrator's Control Panel</h2>
                    </header>
                </div>
            </section>
            <!-- Controls -->
            <section id="controls" class="middle">
                <div class="container">
                    <asp:SqlDataSource ID="adminDataSource" runat="server" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM 15ac3d04.customer" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
                    <h2>Client List</h2>
                    <asp:GridView ID="clients" 
                        runat="server" DataSourceID="adminDataSource"
                         RowDataBound="Customer" DataKeyNames="Company_Name"></asp:GridView>
                    <asp:GridView ID="client" runat="server" ></asp:GridView>
                </div>
            </section>
        </div>
    </form>
    <!-- Footer -->
    <div id="footer">
        <!-- Copyright -->
        <ul class="copyright">
            <li>&copy; TWART Shipping Co. All rights reserved.</li>
        </ul>
    </div>
    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.scrolly.min.js"></script>
    <script src="assets/js/jquery.scrollzer.min.js"></script>
    <script src="assets/js/skel.min.js"></script>
    <script src="assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="assets/js/main.js"></script>
</body>
</html>
