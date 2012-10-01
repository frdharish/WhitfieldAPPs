<%@ Page Language="C#" AutoEventWireup="true" CodeFile="project_client.aspx.cs" Inherits="project_client" %>

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
	        hs.align='center';
	        hs.graphicsDir = 'assets/highslide/graphics/';
	        hs.outlineType = 'rounded-white';
	        hs.outlineWhileAnimating = true;
	        hs.showCredits = false;
	        hs.moveText = '';
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <DIV style="OVERFLOW-Y:scroll; WIDTH:424px; HEIGHT:192px;" >
        <asp:CheckBoxList ID="ChkPrjClient" runat="server" RepeatDirection=vertical>
        </asp:CheckBoxList>
        <asp:HiddenField ID="hidEstNum" runat="server" />
    </DIV>
    <table>
        <tr>
	        <td  align="center" class="form1" colSpan="5">
			        <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
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
                parent.agreewin.hide();
                parent.location.replace('whitfield_estimation.aspx?EstNum=' + myTextField.value);
            }
    </script> 
    </form>
  
</body>
</html>
