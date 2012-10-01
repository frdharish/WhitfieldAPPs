<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newalternatives.aspx.cs" Inherits="newalternatives" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <table align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff" border="1" width="50%">
		      <tr>
		                            <asp:HiddenField ID="hidEstNum" runat="server" />
			                            <td valign="top"><!--Type; Name; Number; Date; Revision-->
			                            <span class="header1">Alternatives List</span><span class="header2"> Data Entry</span>   
			                    			<table align="center"  style=" height:300px; width: 69%;" cellspacing="0" 
                                                cellpadding="0" border="0">		                    			    
                                                      
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Alternatives Type:<br/>
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form1" Width="266px">
                                                                </asp:DropDownList><br />
                                                               <asp:RequiredFieldValidator ID="rrType" ControlToValidate="ddlType" InitialValue=""  ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                         </td>
                                                </tr>
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Number:<br/>
                                                                  <asp:textbox id="txtNumber" width="75px" runat="server"></asp:textbox> <br />
                                                                    <asp:RequiredFieldValidator ID="rrName" ControlToValidate="txtNumber"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Description:<br/>
                                                            <asp:textbox id="txtNotes" width="450px"  runat="server"  
                                                            Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                                                     cols="80"></asp:textbox>
                                                                    <asp:RequiredFieldValidator ID="rrNumber" ControlToValidate="txtNotes"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
				                                
				                                 <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Amount:<br/>
                                                                  <asp:textbox id="txtbasebid"  style="text-align:right"   runat="server" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
                                                    </td>  
                                                </tr>                                                                                               
                                    </table>
                                    </td>
               </tr>
</table>
<table align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff"  width="20%">
        <tr>
	               <td align="center">
	                    <asp:button id="btnSave" runat="server" text="Save" 
                           CssClass="button" onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;
					</td>
	    </tr>
</table>
    </div>
    </form>
</body>
</html>

