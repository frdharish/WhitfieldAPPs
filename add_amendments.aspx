<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_amendments.aspx.cs" Inherits="add_amendments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
     <asp:HiddenField ID="hidEstNum" runat="server" />
    <div>
    <table align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff" border="1" width="50%">
		                            <tr>
			                            <td valign="top">
			                            <span class="header1">Amendments/Modifications </span><span class="header2">Data Entry</span>   
			                    			<table align="center"  style=" height:300px; width: 69%;" cellspacing="0" 
                                                cellpadding="0" border="0">		                    			    
                                                      
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Type:<br/>
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form1" Width="266px">
                                                                </asp:DropDownList><br />
                                                               <asp:RequiredFieldValidator ID="rrType" ControlToValidate="ddlType" InitialValue=""  ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                                
                                               
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Number:<br/>
                                                                 <asp:textbox id="txtNumber" width="75px" runat="server"></asp:textbox> <br />
                                                                    <asp:RequiredFieldValidator ID="rrNumber" ControlToValidate="txtNumber"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="form1">Date:<br />
					                                    <asp:TextBox ID="txtfabEndDate"  runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                                    <asp:ImageButton runat="server"  ID="ImageButton2FabEndDate"  
                                                        ImageUrl="assets/img/calendar.gif" 
                                                        AlternateText="Click here to display calendar" />
						                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2fabEndDate" Format="MM/dd/yyyy"  
                                                            runat="server" TargetControlID="txtfabEndDate" PopupButtonID="ImageButton2FabEndDate" 
                                                            Enabled="True"/>
				                                    </td>
				                                </tr>
				                               
				                                 <tr>                                                                    
                                                     <td class="form1">Impact?<br />
                                                        <asp:RadioButtonList  ValidationGroup="insertnew1" ID="chkActive" runat="server" CssClass="form1" 
                                                                RepeatDirection="Horizontal" >
                                                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                            <asp:ListItem Selected="True" Text="No" Value="No"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>   
                                                </tr>  
                                                <tr>
                                                  <td class="form1">Notes<br />
                                                         <asp:textbox id="txtInotes"   runat="server" Width="150px" TextMode="MultiLine" Rows="3" 
                                                            cols="25" MaxLength="1000" Wrap="true">
														 </asp:textbox>
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
