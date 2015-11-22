<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="TWART.Views.Customer.newCustomerView" %>

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
                <p id="session">Welcome <%=Session["username"].ToString() %></p>
            </div>
            <!-- Nav -->
            <nav id="nav">
                <ul>
                    <li><a href="Customer" id="newClientSection" class="skel-layers-ignoreHref"><span class="icon fa-backward">Client System</span></a></li>
                    <li><a href="#clientList" id="clientInfo" class="skel-layers-ignoreHref"><span class="icon fa-plus">Client Information</span></a></li>
                    <li><a href="#contactInfo" id="contactnav" class="skel-layers-ignoreHref"><span class="icon fa-plus">Contact Details</span></a></li>
                    <li><a href="#customerAddress" id="addressnav" class="skel-layers-ignoreHref"><span class="icon fa-plus">Address Information</span></a></li>
                    <li><a href="#accountType" id="accountypenav" class="skel-layers-ignoreHref"><span class="icon fa-plus">Account Type</span></a></li>
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
        <!-- Controls -->
        <form action="/User/CreateClient" method="POST" runat="server">
            <section id="clientList" class="top">
                <div class="container">
                    <header>
                        <h2>Create A New Client Profile</h2>
                    </header>
                    <footer>
                        <asp:TextBox runat="server" ID="clientName">Client's Name</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="nameRegulator" ControlToValidate="clientName" Display="Dynamic" runat="server" ErrorMessage="Allows up to 40 uppercase and lowercase characters." ValidationExpression="(?!^[0-9]*$)^[a-zA-Z'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="username">Username</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="usernameConfirm" ControlToValidate="username" Display="Dynamic" runat="server" ErrorMessage="Allows up to 15 uppercase and lowercase characters." ValidationExpression="^[a-zA-Z'\s]{1,15}$"></asp:RegularExpressionValidator>
                        <p>Password:</p>
                        <asp:TextBox runat="server" ID="password1" TextMode="Password">Password</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="password1Confirm" ControlToValidate="password1" Display="Dynamic" runat="server" ErrorMessage="It must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$"></asp:RegularExpressionValidator>
                        <p>Re-Enter Password:</p>
                        <asp:TextBox runat="server" ID="password2" TextMode="Password">Confirm Password</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="password2Confirm" ControlToValidate="password2" Display="Dynamic" runat="server" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$"></asp:RegularExpressionValidator>
                        <asp:CompareValidator runat="server" ControlToValidate="password1" Display="Dynamic" ControlToCompare="password2" ErrorMessage="Passwords do not match." />
                    </footer>
                </div>
            </section>
            <section id="contactInfo" class="three">
                <div class="container">
                    <header>
                        <h2>Contact Information</h2>
                    </header>
                    <footer>
                        <asp:TextBox runat="server" ID="contactForename">Contact's Forename</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="contactNameValidator" ControlToValidate="contactForename" Display="Dynamic" runat="server" ErrorMessage="Allows up to 15 uppercase and lowercase characters." ValidationExpression="^[a-zA-Z''-'\s]{1,15}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="contactSurname">Contact's Surname</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="surnameValidator" ControlToValidate="contactSurname" Display="Dynamic" runat="server" ErrorMessage="Allows up to 15 uppercase and lowercase characters." ValidationExpression="^[a-zA-Z''-'\s]{1,15}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="contactPosition">Contact's Position within Client</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="contactPosValidator" ControlToValidate="contactPosition" Display="Dynamic" runat="server" ErrorMessage="Allows up to 40 uppercase and lowercase characters." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="contactPhone">Contact Number</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="contactNumberValidator" ControlToValidate="contactPhone" Display="Dynamic" runat="server" ErrorMessage="Invalid Phone Number" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </footer>
                </div>
            </section>
            <section id="customerAddress" class="four">
                <div class="container">
                    <header>
                        <h2>Address Information</h2>
                    </header>
                    <footer>
                        <asp:TextBox runat="server" ID="address1">Address Line 1</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="address1" Display="Dynamic" runat="server" ErrorMessage="Invalid Address Line, must contain a number." ValidationExpression="[A-Za-z0-9'\.\-\s\,]"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="address2">Address Line 2</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="address2" Display="Dynamic" runat="server" ErrorMessage="Invalid Address Line" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="address3">Address Line 3</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="address3" Display="Dynamic" runat="server" ErrorMessage="Invalid Address Line" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="address4">Address Line 4</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="address4" Display="Dynamic" runat="server" ErrorMessage="Invalid Address Line" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="address5">Address Line 5</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="address5" Display="Dynamic" runat="server" ErrorMessage="Invalid Address Line" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="state">State</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="state" Display="Dynamic" runat="server" ErrorMessage="Invalid State" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="county">County</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="county" Display="Dynamic" runat="server" ErrorMessage="Invalid County" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="country">Country</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="country" Display="Dynamic" runat="server" ErrorMessage="Invalid Country" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" ID="postcode">Postcode</asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="postcode" Display="Dynamic" runat="server" ErrorMessage="Invalid Postcode" ValidationExpression="[A-Za-z0-9'\.\-\s\,]"></asp:RegularExpressionValidator>
                    </footer>
                </div>
            </section>

            <section id="bankDetails" class="five">
                <header>
                    <h2>Bank Details</h2>
                </header>
                <footer>
                    <asp:TextBox runat="server" ID="accountNumber">Account Number</asp:TextBox><br />
                    <asp:TextBox runat="server" ID="sortCode">Sort Code</asp:TextBox>
                </footer>
            </section>

            <section id="accountType" class="two">
                <div class="container">
                    <header>
                        <h2>Account Type</h2>
                    </header>
                    <footer>
                        <asp:DropDownList runat="server" ID="accountTypes">
                        </asp:DropDownList>
                        <div class="12u$">
                            <br />
                            <input type="submit" value="Create Client" />
                        </div>
                    </footer>
                </div>
            </section>

        </form>
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
