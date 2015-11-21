<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TWART.Views.Role.Index" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="System.Web.Routing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="index" runat="server">
        <div>
            <table>
                <tr>
                    <thead>
                        Role Title
                    </thead>
                    <% foreach (var role in Model)
                       { %>
                    <tr>
                        <td>
                            <%= Html.Encode(role.Title)  %>
                        </td>
                        <td>
                            <%= Html.ActionLink("Edit", "Edit", new { id = role.Id }) %>
                        </td>
                        <td>
                            <%= Html.ActionLink("Delete", "Delete", new { id = role.Id }) %>
                        </td>
                    </tr>
                    <% } %>
            </table>
        </div>
    </form>
</body>
</html>
