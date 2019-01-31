<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm3.aspx.vb" Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
        .auto-style2 {
            width: 100%;
            height: 344px;
        }
        .auto-style3 {
            width: 230px;
        }
        .auto-style4 {
            width: 209px;
        }
        .auto-style5 {
            width: 201px;
        }
        .auto-style6 {
            width: 110px;
        }
        .auto-style7 {
            width: 230px;
            height: 387px;
        }
        .auto-style8 {
            height: 387px;
        }
        .auto-style9 {
            width: 230px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    <table class="auto-style2">
        <tr>
            <td class="auto-style9">
        <asp:Label ID="Label1" runat="server" Text="Task"></asp:Label>
            </td>
            <td class="auto-style5">
        <asp:TextBox ID="txtTaskID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">
        <asp:Button ID="btnSelect" runat="server" Text="Select" />
            </td>
            <td class="auto-style4">
        <asp:TextBox ID="txtTaskName" runat="server" CssClass="auto-style1"></asp:TextBox>
            </td>
            <td>
        <asp:Button ID="btnSearch" runat="server" Text="Search" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
        <asp:Calendar ID="calResult" runat="server"></asp:Calendar>
            </td>
            <td class="auto-style8" colspan="4">
        <asp:Repeater ID="rptSchedule" runat="server">
        <HeaderTemplate>
            <table width="100%" bgcolor="#ccffff" border="0">
                <tr>
                    <td align="left">
                        <span style="font-weight:bold;">
                            &nbsp;&nbsp;作業日:<%# calResult.SelectedDate.ToString("yyyy年mm月dd日") %></span></td>
                </tr>
            </table>
            <br />
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr bgcolor="#99ff99" style="font-weight:bold;">
                    <td width="42%">作業時間</td>
                    <td width="28%">タスク</td>                
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table width="100%" border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="42%" align="left">
                                    <%# DataBinder.Eval(Container.DataItem, "STime") %>～
                                    <%# DataBinder.Eval(Container.DataItem, "ETime") %>
                                </td>
                                <td width="28%" align="left">
                                    <%# DataBinder.Eval(Container.DataItem, "TaskName") %>      
                                </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
        </asp:Repeater>
            </td>
        </tr>
    </table>
    </form>
    </body>
</html>
