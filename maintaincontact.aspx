<%@ Page Language="C#" AutoEventWireup="true" CodeFile="maintaincontact.aspx.cs" Inherits="maintaincontact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table  align="center" cellSpacing="0" cellPadding="0" border="0">
                <tr>
                            <td class="form1">Contact First Name:<br />
	                            <asp:textbox id="txtcontactfname" runat="server" MaxLength="17" Width="224px"></asp:textbox>
	                            <br /><asp:HiddenField ID="hidclient" runat="server" />
	                            <asp:RequiredFieldValidator ID="rrcname" 
                                ControlToValidate="txtcontactfname" ErrorMessage="First Name is Required"
                                runat="server"></asp:RequiredFieldValidator>
                            </td>
                            <TD vAlign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
                            <td class="form1">Contact Last Name:<br />
	                            <asp:textbox id="txtcontactlname" runat="server" MaxLength="17" Width="224px"></asp:textbox>
	                            <br />
	                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                ControlToValidate="txtcontactlname" ErrorMessage="Last Name is Required"
                                runat="server"></asp:RequiredFieldValidator>
                            </td>
                            <TD vAlign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
                            <td class="form1">Title:<br />
	                            <asp:dropdownlist id="ddltitle" runat="server"></asp:dropdownlist>
	                            <br />
	                            <asp:RequiredFieldValidator ID="rrtitle" 
                                ControlToValidate="ddltitle" ErrorMessage="Title is Required"  InitialValue=""
                                runat="server"></asp:RequiredFieldValidator> 
                            </td>
                   </tr>
                   <tr>
                            <td class="form1">Contact Telephone:<br />
	                            <asp:textbox id="txttele" runat="server" MaxLength="17"  ValidationGroup="MKE" Width="175px"></asp:textbox>
	                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                    TargetControlID="txttele"
                                    Mask="999-999-9999"
                                    ClearMaskOnLostFocus="false"
                                    MessageValidatorTip="true"
                                    MaskType="None"
                                    InputDirection="LeftToRight"
                                    AcceptNegative="Left"
                                    DisplayMoney="Left" Filtered="-"
                                    />
                                <ajaxToolkit:MaskedEditValidator id="MaskedEditValidator2" runat="server"
                                    ControlExtender="MaskedEditExtender2"
                                    ControlToValidate="txttele"
                                    IsValidEmpty="true" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                                    InvalidValueMessage="input is invalid"
                                    Display="Dynamic"
                                    TooltipMessage="XXX-XXX-XXXX"
                                    InvalidValueBlurredMessage="Please input the right phone number!"
                                    ValidationGroup="MKE" />
	                            <br />Extension:<br /><asp:textbox id="txtextn" runat="server" MaxLength="5" Width="50px"></asp:textbox>
	                            <br />
	                            <asp:RequiredFieldValidator ID="rrtele" 
                                ControlToValidate="txttele" ErrorMessage="Telephone is Required"
                                runat="server"></asp:RequiredFieldValidator>
                            </td>
                            <TD vAlign="top" width="10"><IMG height="1" alt="" src="assets/img/spacer.gif" width="10"></TD>
                            <td class="form1">Fax Number:<br />
	                            <asp:textbox id="txtFax" runat="server" MaxLength="17" Width="175px"></asp:textbox>
                                <br />Contact Email:<br />
	                            <asp:textbox id="txtEmail" runat="server" MaxLength="100" Width="224px"></asp:textbox>
	                            <br />
	                            <asp:RequiredFieldValidator ID="rremail" 
                                ControlToValidate="txtemail"  ErrorMessage="Email is Required"
                                runat="server"></asp:RequiredFieldValidator>
                            </td>
                            <TD vAlign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
                            <td class="form1">Address:<br />
	                            <asp:textbox id="txtAddress" runat="server" TextMode=MultiLine Rows="3" cols="80"></asp:textbox>
	                            <br />
                            </td>
                   </tr>
                   <tr>
                            <TD vAlign="top" class="form1" style="width: 151px">City:<br />
	                            <asp:dropdownlist id="ddlCity" runat="server"></asp:dropdownlist>
                            </TD>
                            
                            <td valign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></td>
                            
                            <td class="form1">State:<br />
                                <asp:dropdownlist id="ddlState" runat="server"></asp:dropdownlist>
	                            <br />
	                            <asp:RequiredFieldValidator ID="rrState" 
                                ControlToValidate="ddlState" ErrorMessage="State is Required" 
                                runat="server"></asp:RequiredFieldValidator>
                            </td>
            		        
                            <td valign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></td>
            		        
                            <td class="form1">Zipcode<br />
				                    <asp:textbox id="txtzip" runat="server" MaxLength="17" Width="224px"></asp:textbox>
                            </td>
                 </tr>
                 <tr>
                            <td class="form1" colspan="5">Notes:<br />
				                    <asp:textbox id="txtNotes" runat="server" TextMode="MultiLine" Rows="6" 
                                                                    cols="80" Width="726px"></asp:textbox>

                            </td>
                </tr>
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
    </form>
 <script type="text/javascript">
     function CloseandRefresh() {
            var myTextField = document.getElementById('hidclient');
            parent.agreewin.hide();
            parent.location.replace('addclient.aspx?IsNew=N&hClientID=' + myTextField.value);   
        }
    </script>
</body>
</html>
