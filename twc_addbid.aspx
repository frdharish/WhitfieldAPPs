<%@ Page Language="C#" AutoEventWireup="true" CodeFile="twc_addbid.aspx.cs" Inherits="twc_addbid" %>

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

	        function isNumber(field) {
	            var re = /^[0-9-'.'-',']*$/;
	            if (!re.test(field.value)) {
	                //alert('Value must be all numberic charcters, including "." or "," non numerics will be removed from field!');
	                field.value = field.value.replace(/[^0-9-'.'-',']/g, "");
	            }
	        }
	        function formatCurrency(num) {
	            num = num.toString().replace(/\$|\,/g, '');
	            if (isNaN(num))
	                num = "0";
	            sign = (num == (num = Math.abs(num)));
	            num = Math.floor(num * 100 + 0.50000000001);
	            cents = num % 100;
	            num = Math.floor(num / 100).toString();
	            if (cents < 10)
	                cents = "0" + cents;
	            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
	                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
                num.substring(num.length - (4 * i + 3));
	            return (((sign) ? '' : '-') + '$' + num + '.' + cents);
	        }


	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table  width="50%" border="0" align='center'>
            <tr>
            <td class="form1">Project Name:<BR>
                    <asp:textbox id="txtEstName" runat="server"  ReadOnly=true MaxLength="17"></asp:textbox>
                    <asp:HiddenField ID="hidEstNum" runat="server" />
                    <asp:HiddenField ID="hidProjNumber" runat="server" />
            <br />
            Client Name:<br />
                <asp:textbox id="txtClientName" runat="server"  ReadOnly=true MaxLength="17"></asp:textbox>
            <br />
            Bid Amont:<br />
                <asp:textbox id="txtBidAmt" runat="server"  MaxLength="5" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>    
            </td>
            </TR>
            </table>
            <table  width="75%" border="0" align='center'>
                <tr>
	                <td  align="center" class="form1" colSpan="5">
			                <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
                                onclick="btnnew_Click"></asp:button>
                             &nbsp;&nbsp;<button id="eulabox"  class="button" name="eulabox" onclick="CloseandRefresh();" >Close</button>
                            <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label>
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

