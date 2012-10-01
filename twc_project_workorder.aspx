<%@ Page Language="C#" AutoEventWireup="true" CodeFile="twc_project_workorder.aspx.cs" Inherits="twc_project_workorder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to Whitfield-co Project management systetms</title>
	<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
	<meta name="CODE_LANGUAGE" Content="C#" />
	<meta name="vs_defaultClientScript" content="JavaScript" />
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <script src="assets/highslide/highslide-full.js" type="text/javascript"></script>
     <script type="text/javascript">
         hs.align = 'center';
         hs.graphicsDir = 'assets/highslide/graphics/';
         hs.outlineType = 'rounded-white';
         hs.outlineWhileAnimating = true;
         hs.showCredits = false;
         hs.moveText = '';


         function formatNumber() {
             if (!(event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) { event.returnValue = false; }
         }
	</script>
    <style type="text/css">
        .style1
        {
            width: 183px;
        }
        .style2
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            color: #000000;
            text-decoration: none;
            width: 183px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
     <TABLE  align="center" cellSpacing="0" cellPadding="0" border="0">
        <tr>
	        <td  colspan="3" class="form1">Description:<br />
	            <asp:textbox id="txtdesc" width="380px" 
	            runat="server" Font-Names="Arial" Font-Size=Small MaxLength="50"></asp:textbox><br />
	        </td>
	    </tr>
        <tr>
				<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
		</tr>
	     <tr>
	        <td class="form1"><br />Fabrication Hours:<br />
	            <asp:TextBox ID="txtFabHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtFabHours')"></asp:TextBox> 
	        </td>
	        <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="50"></TD>
	         <td class="style2"><br />Finishing Hours:<br />
	            <asp:TextBox ID="txtFinishHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtFinishHours')"></asp:TextBox> 
	        </td>
	    </tr>
        <tr>
				<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
		</tr>
	     <tr>
	        <td class="form1"><br />Installation Hours:<br />
	            <asp:TextBox ID="txtInstallHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtInstallHours')"></asp:TextBox> 
	        </td>
	        <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="50"></TD>
	         <td class="style2"><br />Engineering Hours:<br />
	            <asp:TextBox ID="txtEngHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtEngHours')"></asp:TextBox> 
	        </td>
	    </tr>
        <tr>
				<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
		</tr>
	     <tr>
	        <td class="form1"><br />Miscellaneous Hours:<br />
	            <asp:TextBox ID="txtMiscHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtMiscHours')"></asp:TextBox> 
	        </td>
	        <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="50"></TD>
	       <td class="style2"><br />Total Material Cost:<br />
	            <asp:TextBox ID="txtMaterialCost" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtMaterialCost')"></asp:TextBox> 
	        </td>
	    </tr>
	    <tr>
				<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
		</tr>
	     <tr>
             <td colspan="3" class="form1">Notes:<br />
	            <asp:textbox id="txtNotes" width="380px" 
	            runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" cols="80"></asp:textbox><br />
	        </td>
	        <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="50"></TD>
	        <td vAlign="top" class="style1"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="50"></TD>
	    </tr>
	    <tr>
				<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
		</tr>
	     <tr>
	        <td class="form1" colspan="3"><br />Is Active?:<br />
	            <asp:CheckBoxList ID="chkActive" CssClass="form1"  RepeatDirection="Horizontal" runat="server">
	                    <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
	                    <asp:ListItem Text="No" Value="0" Selected=true></asp:ListItem>
	            </asp:CheckBoxList>  
	            <asp:HiddenField ID="hidEstNum" runat="server" />
	            <asp:HiddenField ID="hidtwcProjNumber" runat="server" />
	        </td>
	    </tr>
	   </TABLE>
	     <TABLE  align="center" cellSpacing="0" cellPadding="0" border="0">
        <tr>
	        <td  align="center" class="form1" colSpan="5">
			        <asp:button id="btnnew" runat="server" Text="Save Workorder" CssClass="button" 
                        onclick="btnnew_Click"></asp:button>
                     &nbsp;&nbsp;<button id="eulabox"  class="button" name="eulabox" onclick="CloseandRefresh();" >Close</button>
                    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=Larger></asp:Label>
		    </td>
	    </tr>
    </table>
    </div>
      <script type="text/javascript">
          function CloseandRefresh() {
              var myTextField = document.getElementById('hidEstNum');
              var myTextField1 = document.getElementById('hidtwcProjNumber');
              parent.agreewin.hide();
              parent.location.replace('whitfield_projectInfo.aspx?EstNum=' + myTextField.value + '&twcProjectNumber=' + myTextField1.value);
          }
    </script> 
    </form>
</body>
</html>
