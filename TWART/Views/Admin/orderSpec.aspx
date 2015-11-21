<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderSpec.aspx.cs" Inherits="TWART.Views.Admin.newOrderSpec" %>

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
                    <h2>Package Specifications</h2>
                </header>
            </div>
        </section>
        <!-- New Package -->
        <section id="newpackage" class="two">
                <div class="container">
                    <a href="newSpec">Create a new Package Specification</a>
                    <p>Use this control to create a new kind of package.</p>
                </div>
        </section>
         <!-- Packages -->
        <section id="existingpackages" class="two">
             <div class="container">
                    <table>
                        <% foreach (var specs in Model)
                           { %>
                        <tr>
                            <td><%= Html.Encode(specs.Weight + "Grams") %></td>
                            <td><%= Html.Encode(specs.Dimension_Height + "H") %></td>
                            <td><%= Html.Encode(specs.Dimension_Width + "W") %></td>
                            <td><%= Html.Encode(specs.Dimension_Length + "L") %></td>
                            <td><%= Html.ActionLink("Edit", "edit", new { id = specs.Specification_ID })%></td>
                            <td><%= Html.ActionLink("Delete", "delete", new { id = customer.Specification_ID })%></td>
                        </tr>
                        <% } %>
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
    <script src="../../assets/js/jquery.min.js"></script>
    <script src="../../assets/js/jquery.scrolly.min.js"></script>
    <script src="../../assets/js/jquery.scrollzer.min.js"></script>
    <script src="../../assets/js/skel.min.js"></script>
    <script src="../../assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="../../assets/js/main.js"></script>
</body>
</html>
