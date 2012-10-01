<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newcontingencytoProject.aspx.cs" Inherits="newcontingencytoProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
     <asp:HiddenField ID="hidEstNum" runat="server" />
    <div>
     <asp:CheckBoxList ID="ChkCongingency" runat="server" RepeatDirection="vertical">
     </asp:CheckBoxList>
     <table>
        <tr>
			    <td>
					    <asp:button id="Button3" runat="server"  Text="Save Changes" CssClass="button" 
                            onclick="Button3_Click"></asp:button> 
			    </td>
		</tr>
	 </table>
    </div>
    </form>
</body>
</html>
