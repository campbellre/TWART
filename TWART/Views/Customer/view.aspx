<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="TWART.Views.Admin.viewinfo" %>

<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="TWART.DataObjects" %>
<!DOCTYPE html>
<html>
<head runat="server">
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
                    <li><a href="customer" id="about-link"><span class="icon fa-home">Client Information</span></a></li>
                </ul>
            </nav>
        </div>
        <div class="bottom">
            <!-- Social Icons -->
            <ul class="icons">
                <li><a href="https://github.com/campbellre/TWART" class="icon fa-github"><span class="label">Github</span></a></li>
                <li><a href="index.html#contact" class="icon fa-envelope"><span class="label">Email</span></a></li>
            </ul>
        </div>
    </div>
    <!-- Grid Display -->
    <div id="main">
        <!-- Admin Control Panel -->
        <section id="admin" class="top">
            <div class="container">
                <header>
                    <h2>Client's Accounts</h2>
                </header>
            </div>
        </section>
        <!-- Full Address -->
        <section id="controls" class="two">
            <div class="container">
                
                <table>
                    <% List<Account> viewCustomer = (List<Account>)Model;

                           foreach (var account in Model)
                           { %>

                            <!-- name -->
                            <tr>
                                <td><%= Html.Encode(account.Customer.Name)%></td>
                            </tr>
                            <% }
                    
                    %>
                    
                </table>
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
    <!--[if lte IE 8]><script src="../../assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="/assets/js/main.js"></script>
</body>
</html>
