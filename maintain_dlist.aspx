<%@ Page Language="C#" AutoEventWireup="true" CodeFile="maintain_dlist.aspx.cs" Inherits="maintain_dlist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <table>
    <tr>
            <td>
                <asp:ListBox ID="leftlist" runat="server" Height="182px" Width="241px"></asp:ListBox>
            </td>
       
            <td>
                 <asp:Button ID="btnLefttoRight" runat="server" Text=">>" onclick="Button1_Click" /> 
                <br /><br />
                 <asp:Button ID="btnRighttoLeft" runat="server" Text="<<" onclick="Button2_Click" /> 
            </td>
            <td>
                <asp:ListBox ID="rightlist" runat="server" Height="189px" Width="278px"></asp:ListBox>
            </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
