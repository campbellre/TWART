<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="TWART.Views.User.CreateEmployee" %>
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
                    <li><a href="Users" id="foobar-link"><span class="icon fa-hand-o-left">Back</span></a></li>
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
        <section id="client" class="top">
            <div class="container">
                <header>
                    <h2>Add a new Admin User</h2>
                </header>
            </div>
        </section>
        <!-- Edit Here -->
        <section id="edit" class="two">
            <div class="container">
        <form method="POST" action="/User/CreateEmployeeUser">
            <input type="text" name="Username" value="Username"/>
            <input type="password" name="Password" value="Password"/>
            <input type="password" name="ConfirmPassword" value="Confirm Password"/>
            <input type="email" name="email" value="Email Address"/>
            <input type="text" name="Firstname" value="Firstname"/>
            <input type="text" name="Lastname" value="Surname"/>
            <input type="date" name="DOB" value="DOB"/>
            <input type="text" name="ContactNumber" value="Contact Number"/>
            <input type="date" name="Password" value="Password"/>

            <!-- drop down for the role -->
            <% foreach (Role role in Model)
               {
                   ListItem item = new ListItem(role.Title.ToString());
                   item.Value = role.Id.ToString();
                   RoleTitle.Items.Add(item);
               } %>
            <asp:DropDownList runat="server"  ID="RoleTitle"/>
            <br />
            <input type="text" name="LineOne" value="Address Line 1" />
            <input type="text" name="LineTwo" value="Address Line 1" />
            <input type="text" name="LineThree" value="Address Line 1" />
            <input type="text" name="LineFour" value="Address Line 1" />
            <input type="text" name="LineFive" value="Address Line 1" />
            <input type="text" name="State" value="State" />
            <input type="text" name="County" value="County" />
            <input type="text" name="Country" value="Country" />
            <input type="text" name="postalCode" value="Postal Code" />
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
    <!--[if lte IE 8]><script src="/assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="/assets/js/main.js"></script>
</body>
</html>