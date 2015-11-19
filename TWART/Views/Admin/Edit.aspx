<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="TWART.Views.Admin.Edit" %>
<%@ Import Namespace="TWART.DataObjects" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <% Customer editCustomer = (Customer) Model; %>
        
        <form action="/admin/EditCustomer" method="POST">
            <input type="text" name="id" value="<%= editCustomer.ID %>"/>
            <input type="text" name="name" value="<%= editCustomer.Name %>"/>
            <input type="text" name="addressid" value="<%= editCustomer.Address_ID %>"/>
            <input type="submit" value="Go!"/>
        </form>

    </div>
</body>
</html>
