<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="archmain.aspx.cs" Inherits="archmain" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<table  align="center" cellspacing="0" cellpadding="0" border="0">
    <tr>
                <td valign="top" class="form1" style="width: 183px">Architect Name:<br />
	                <asp:textbox id="txtclientname" runat="server" MaxLength="100" Width="224px"></asp:textbox>
	                <br />
	                <asp:RequiredFieldValidator ID="rrcname" 
                    ControlToValidate="txtclientname" ErrorMessage="Architect Name is Required"
                    runat="server"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hidclient" runat="server" />
                </td>
                
                <td vAlign="top" width="30"><img height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                
                 <td valign="top" class="form1">Web<br />
				        <asp:textbox id="txtWeb" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox>
                </td>
                
                 <td valign="top" width="30"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                 
                 <td valign="top" class="form1">Street<br />
				        <asp:textbox id="txtstreet" runat="server" MaxLength="50" Width="224px"></asp:textbox>
                </td>
               
                

      </tr>

      <tr>
			        <td colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></td>
      </tr>
			
	
      <tr>
                <td valign="top" class="form1">State:<br />
                    <asp:dropdownlist id="ddlState" runat="server"></asp:dropdownlist>
	                <br />
	                <asp:RequiredFieldValidator ID="rrState" 
                    ControlToValidate="ddlState" ErrorMessage="State is Required" 
                    runat="server"></asp:RequiredFieldValidator>
                </td>
                
                
                <td valign="top" width="30"><IMG height="1" alt="" src="assets/img/spacer.gif" width="30"></td>
                
                 <td valign="top" class="form1" style="width: 183px">City:<br />
	                <asp:dropdownlist id="ddlCity" runat="server"></asp:dropdownlist> or<br />
	                Enter City (if city is unavailable)<asp:textbox id="txtcity" runat="server" MaxLength="50" Width="224px"></asp:textbox>	                
                 </td>
		        
                <td valign="top" width="30"><img height="1" alt="" src="assets/img/spacer.gif" width="30"></td>
		        
                <td valign="top" class="form1">Zip Code<br />
				       <asp:textbox id="txtZipcode" runat="server" MaxLength="15" Width="224px"></asp:textbox>	                
                </td>
    </tr> 
    
     <tr>
                <td valign="top" class="form1" style="width: 183px">PhoneNumber:<br />
				        <asp:textbox id="txtPhNumber" runat="server" MaxLength="17" ValidationGroup="MKE" Width="224px"></asp:textbox>
				         <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                            TargetControlID="txtPhNumber"
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
                            ControlToValidate="txtPhNumber"
                            IsValidEmpty="False" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                            EmptyValueMessage="input is required"
                            InvalidValueMessage="input is invalid"
                            Display="Dynamic"
                            TooltipMessage="XXX-XXX-XXXX"
                            EmptyValueBlurredText="Phone number should not be empty!"
                            InvalidValueBlurredMessage="Please input the right phone number!"
                            ValidationGroup="MKE" />

                </td>
                <td valign="top" width="30"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                <td valign="top" class="form1">FaxNumber<br />
				        <asp:textbox id="txtFaxNumber" runat="server" MaxLength="17" ValidationGroup="MKE1" Width="224px"></asp:textbox>
				        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                            TargetControlID="txtFaxNumber"
                            Mask="999-999-9999"
                            ClearMaskOnLostFocus="false"
                            MessageValidatorTip="true"
                            MaskType="None"
                            InputDirection="LeftToRight"
                            AcceptNegative="Left"
                            DisplayMoney="Left" Filtered="-"
                            />
                        <ajaxToolkit:MaskedEditValidator id="MaskedEditValidator1" runat="server"
                            ControlExtender="MaskedEditExtender1"
                            ControlToValidate="txtFaxNumber"
                            IsValidEmpty="True" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                            InvalidValueMessage="input is invalid"
                            Display="Dynamic"
                            TooltipMessage="XXX-XXX-XXXX"
                            InvalidValueBlurredMessage="Please input the right Fax number!"
                            ValidationGroup="MKE1" />
                </td>
                <td valign="top" width="30"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                <td valign="top" width="30"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
    </tr> 
    
   
    <tr>
                <td valign="top" class="form1" colspan="5">Notes:<br />
				        <asp:textbox id="txtNotes" runat="server" TextMode=MultiLine Rows="6" 
                                                                    cols="80" Width="982px"></asp:textbox>

                </td>
    </tr> 
	<tr>
	    <td  align="center" class="form1" colSpan="5">
			    <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
                    onclick="btnnew_Click"></asp:button>
                &nbsp;&nbsp;<br />
                <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=Larger></asp:Label>
		</td>
	</tr>
</table>			
</asp:Content>

