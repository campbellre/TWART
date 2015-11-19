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
                    <li><a href="#client" id="client-link" class="skel-layers-ignoreHref"><span class="icon fa-home">Client Information</span></a></li>
                    <li><a href="#order" id="order-link" class="skel-layers-ignoreHref"><span class="icon fa-home">Order Page</span></a></li>
                    <li><a href="logout" id="logout"><span class="icon fa-hand-o-left">Log Out</span></a></li>
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
    <form id="customerForm" runat="server">
        <div id="main">
            <!-- Client View -->
            <section id="client" class="top">
                <div class="container">
                    <header>
                        <h2 style="color: #ff0000">Administrator's Control Panel</h2>
                    </header>
                </div>
            </section>
            <!-- Client -->
            <section id="controls" class="controls">
                <div class="container">
                    <a href="Customer">Client Controls</a>
                    <p>Use this control to view or modify our client's addresses or account information.</p>
                </div>
            </section>
            <!-- Order -->
            <section id="order" class="order">
                <div class="container">
                    <a href="Orders">Order Page</a>
                    <p>Use this control to view, create or delete orders which exist on our system.</p>
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
