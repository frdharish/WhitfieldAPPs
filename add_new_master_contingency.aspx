<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="add_new_master_contingency.aspx.cs" Inherits="add_new_master_contingency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff" border="1" width="50%">
		                            <tr>
			                            <td valign="top">
			                            <span class="header1">Master Contingency </span><span class="header2">Data Entry</span>   
			                    			<table align="center"  style=" height:300px; width: 69%;" cellspacing="0" 
                                                cellpadding="0" border="0">		                    			    
                                                      
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Group Name:<br/>
                                                                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form1" Width="266px">
                                                                </asp:DropDownList><br />
                                                               <asp:RequiredFieldValidator ID="rrGroup" ControlToValidate="ddlGroup" InitialValue=""  ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Description:<br/>
                                                                 <asp:textbox  ID="txtdesc" CssClass="form1" TextMode="MultiLine" wrap="true" 
                                                                    Rows="4" Columns="20" MaxLength="20" runat="server" 
                                                                    Width="420px"></asp:textbox> <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtdesc"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
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

</asp:Content>
