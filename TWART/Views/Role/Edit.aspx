<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="TWART.Views.Role.Edit" %>
<%@ Import Namespace="TWART.DataObjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form action="/Role/EditRole" method="POST">
        <% Role showRole = (Role) Model; %>
        <input type="hidden" name="id" value="<%= showRole.Id %>"/>
        <input type="text" name="title" value="<%= showRole.Title %>"/>
        
        <input type="submit" value="Edit"/>
    </form>
</body>
</html>
