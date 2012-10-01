<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="compmain.aspx.cs" Inherits="compmain" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<table  align="center" cellspacing="0" cellpadding="0" border="0">
    <tr>
                <td valign="top" class="form1" style="width: 183px">Competition Name:<br />
	                <asp:textbox id="txtclientname" runat="server" MaxLength="100" Width="224px"></asp:textbox>
	                <br />
	                <asp:RequiredFieldValidator ID="rrcname" 
                    ControlToValidate="txtclientname" ErrorMessage="Competitor Name is Required"
                    runat="server"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hidcompe" runat="server" />

                </td>
                <td vAlign="top" width="30"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                <td valign="top" class="form1">labor Rate<br />
				        <asp:textbox id="txtlaborRate" runat="server" MaxLength="17" Width="224px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
                </td>
                <td vAlign="top" width="30"><img height="1" alt="" Src="assets/img/spacer.gif" width="30"></td>
                
                <td valign="top" class="form1">Overhead Burden<br />
				        <asp:textbox id="txtOverHead" runat="server" MaxLength="17" Width="224px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
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
		        
                <td valign="top" class="form1">Web<br />
				        <asp:textbox id="txtWeb" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox>
                </td>
    </tr> 
    <tr>
                <td valign="top" class="form1" colspan="5">Notes:<br />
				        <asp:textbox id="txtNotes" runat="server" TextMode=MultiLine Rows="6" 
                                                                    cols="80" Width="726px"></asp:textbox>

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
