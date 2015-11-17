<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TWART.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 425px;
            font-size: xx-large;
            text-align: center;
        }
        .auto-style2 {
            font-size: xx-large;
            text-align: center;
        }
        .auto-style4 {
            width: 126px;
        }
        .auto-style5 {
            width: 103px;
        }
        .auto-style6 {
            width: 293px;
        }
        .auto-style7 {
            width: 423px;
        }
        .auto-style8 {
            width: 423px;
            height: 45px;
        }
        .auto-style9 {
            height: 45px;
        }
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 421px;
        }
        .auto-style12 {
            height: 23px;
            width: 421px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 546px">
    
        <table style="width: 100%; height: 70px;">
            <tr>
                <td class="auto-style1">Banking</td>
                
                <td class="auto-style2">Report</td>
            </tr>
            </table>
    
        <table style="width: 100%; height: 88px;">
            <tr>
                <td class="auto-style6">Client ID</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">Client</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="58px" Width="275px"></asp:TextBox>

                </td>

            </tr>
            </table>
    
        <table style="width:100%; height: 217px;">
            <tr>
                <td class="auto-style8">Name<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                
                <td class="auto-style9">Forename
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Date Of Birth
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                
                <td>Surname<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Address<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                
                <td>Address<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    
        <table style="width:100%; height: 112px;">
            <tr>
                <td class="auto-style11">Contact<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                
                <td>Postcode<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Banking<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
                
                <td class="auto-style10">Contact Number<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Button ID="Button1" runat="server" Text="Search" />
                </td>
                
                <td class="auto-style10">
                    <asp:Button ID="Button2" runat="server" Text="Edit" />
                    <asp:Button ID="Button3" runat="server" Text="Update" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
