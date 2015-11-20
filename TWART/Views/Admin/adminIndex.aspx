<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminIndex.aspx.cs" Inherits="TWART.Views.Admin.IndexView" %>

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
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="#client" id="client-link" class="skel-layers-ignoreHref"><span class="icon fa-user">Client System</span></a></li>
                    <li><a href="#order" id="order-link" class="skel-layers-ignoreHref"><span class="icon fa-sort">Order System</span></a></li>
                    <li><a href="#user" id="user-link" class="skel-layers-ignoreHref"><span class="icon fa-unlock-alt">User System</span></a></li>
                    <li><a href="#address" id="address-link" class="skel-layers-ignoreHref"><span class="icon fa-map-marker">Address System</span></a></li>
                    <li><a href="#banking" id="banking-link" class="skel-layers-ignoreHref"><span class="icon fa-credit-card">Banking System</span></a></li>
                    <li><a href="#accounts" id="accounts-link" class="skel-layers-ignoreHref"><span class="icon fa-clone">Accounts System</span></a></li>
                    <li><a href="#employees" id="employees-link" class="skel-layers-ignoreHref"><span class="icon fa-industry">Employees System</span></a></li>
                    <li><a href="Logout" id="logout"><span class="icon fa-hand-o-left">Log Out</span></a></li>
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
    <form id="customerForm" runat="server">
        <div id="main">
            <!-- Controls -->
            <section id="client" class="top">
                <div class="container">
                    <header>
                        <h2><strong style="color: #ff0000">Administrator's Control Panel</strong></h2>
                    </header>
                </div>
            </section>
            <!-- Client -->
            <section id="controls" class="two">
                <div class="container">
                    <a href="Customer">Client Controls</a>
                    <p>Use this control to create, retrieve, update or delete on our client system.</p>
                </div>
            </section>
            <!-- Order -->
            <section id="order" class="three">
                <div class="container">
                    <a href="Orders">Order Controls</a>
                    <p>Use this control to create, retrieve, update or delete on our order system.</p>
                </div>
            </section>
            <!-- User -->
            <section id="user" class="four">
                <div class="container">
                    <a href="Users">Create New Admin User</a>
                    <p>Use this control to create, retrieve, update or delete on our user system.</p>
                </div>
            </section>
            <!-- Address -->
            <section id="address" class="two">
                <div class="container">
                    <a href="Address">Address</a>
                    <p>Use this control to create, retrieve, update or delete on our address system.</p>
                </div>
            </section>
            <!-- Banking -->
            <section id="banking" class="three">
                <div class="container">
                    <a href="Banking">Banking</a>
                    <p>Use this control to create, retrieve, update or delete on our banking system.</p>
                </div>
            </section>
            <!-- Accounts -->
            <section id="accounts" class="four">
                <div class="container">
                    <a href="Accounts">Accounts</a>
                    <p>Use this control to create, retrieve, update or delete on our accounts system.</p>
                </div>
            </section>
            <!-- Employees -->
            <section id="employees" class="two">
                <div class="container">
                    <a href="Employees">Employees</a>
                    <p>Use this control to create, retrieve, update or delete on our employees system.</p>
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
    <script src="../../assets/js/jquery.min.js"></script>
    <script src="../../assets/js/jquery.scrolly.min.js"></script>
    <script src="../../assets/js/jquery.scrollzer.min.js"></script>
    <script src="../../assets/js/skel.min.js"></script>
    <script src="../../assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="../../assets/js/main.js"></script>
</body>
</html>
