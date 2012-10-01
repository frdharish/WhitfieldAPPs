<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSOV.aspx.cs" Inherits="AddSOV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
	        function formatCurrencyNoSign(num) {
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
	            return (((sign) ? '' : '-') + num + '.' + cents);
	        }

	        function formatNumber() {
	            if (!(event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) { event.returnValue = false; }
	        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <table  align="left"  width="100%" cellspacing="0" cellpadding="0" border="0">
        <th colspan="2" align="left">Schedule of Values</th>
        <tr>
            <td>
                        <table border="1">
                        
                            <tr> 
                                <th>Number</th>
                                <td>
					            <asp:dropdownlist id="ddlNo" ValidationGroup="insertnew" runat="server"></asp:dropdownlist><br />
					            <asp:RequiredFieldValidator ID="rrNo" ControlToValidate="ddlNo" ValidationGroup="insertnew" 
					            ErrorMessage="Number is Required" 
                                runat="server"></asp:RequiredFieldValidator>
                                </td> 
                            </tr> 
                            <tr>
                                <th>Description</th>
                                <td><asp:textbox  ValidationGroup="insertnew" id="txtDescription" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox></td>
                            </tr>                  


                            <tr>
                                    <th>Amount</th>
                                    <td><asp:textbox id="txtAmt"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                             </tr>
                            
                            <tr>
                                <td><asp:button  ValidationGroup="insertnew" id="btnnew" runat="server" Text="Save" CssClass="button" onclick="btnnew_Click" />
                                <br /><asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label></td>
                            </tr>
                        </table>
            </td>
         </tr>   
        </table>
    </div>
    </form>
</body>
</html>
