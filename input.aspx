<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="input.aspx.vb" Inherits="WebApplication2.input" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 219px;
            height: 121px;
        }
        .auto-style4 {
            width: 233px;
        }
        .auto-style5 {
            height: 36px;
            width: 233px;
        }
        .auto-style6 {
            width: 98px;
            text-align: center;
        }
        .auto-style7 {
            height: 36px;
            width: 98px;
        }
        .auto-style8 {
            width: 219px;
        }
        .auto-style9 {
            height: 36px;
            width: 219px;
        }
        .auto-style10 {
            width: 211px;
        }
        .auto-style11 {
            height: 36px;
            width: 211px;
        }
        .auto-style12 {
            width: 57px;
        }
        .auto-style13 {
            height: 36px;
            width: 57px;
        }
        .auto-style14 {
            height: 36px;
        }
        .auto-style15 {
            width: 57px;
            height: 28px;
        }
        .auto-style16 {
            width: 233px;
            height: 28px;
        }
        .auto-style17 {
            width: 98px;
            height: 28px;
        }
        .auto-style18 {
            width: 219px;
            height: 28px;
        }
        .auto-style19 {
            width: 211px;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style15">
            <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                </td>
                <td class="auto-style16">
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style12">
            <asp:Label ID="Label4" runat="server" Text="Time"></asp:Label>
                </td>
                <td class="auto-style4">
            <asp:TextBox ID="txtTimeS" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">～</td>
                <td class="auto-style8"><asp:TextBox ID="txtTimeE" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">
            <asp:Label ID="Label2" runat="server" Text="TaskID"></asp:Label>
                </td>
                <td class="auto-style5">
            <asp:TextBox ID="txtTaskID" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
            <asp:Button ID="btnTaskSearch" runat="server" Text="Select" />
                </td>
                <td class="auto-style9">
            <asp:Label ID="TaskName" runat="server" Text="TaskName"></asp:Label>
                </td>
                <td class="auto-style11">
            <asp:TextBox ID="txtTaskName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" colspan="5">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
            <asp:Button ID="btnAddTask" runat="server" Text="AddTask" />
                </td>
                <td class="auto-style5"></td>
                <td class="auto-style7"></td>
                <td class="auto-style9"></td>
                <td class="auto-style11"></td>
            </tr>
        </table>
    </form>
</body>
</html>
