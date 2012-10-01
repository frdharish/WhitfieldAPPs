<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_drawing_list.aspx.cs" Inherits="add_drawing_list" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <table align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff" border="1" width="50%">
		      <tr>
		                            <asp:HiddenField ID="hidEstNum" runat="server" />
			                            <td valign="top"><!--Type; Name; Number; Date; Revision-->
			                            <span class="header1">Drawing List</span><span class="header2">Data Entry</span>   
			                    			<table align="center"  style=" height:300px; width: 69%;" cellspacing="0" 
                                                cellpadding="0" border="0">		                    			    
                                                      
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Drawing Type:<br/>
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form1" Width="266px">
                                                                </asp:DropDownList><br />
                                                               <asp:RequiredFieldValidator ID="rrType" ControlToValidate="ddlType" InitialValue=""  ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Name:<br/>
                                                                  <asp:textbox id="txtName" width="75px" runat="server"></asp:textbox> <br />
                                                                    <asp:RequiredFieldValidator ID="rrName" ControlToValidate="txtName"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
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
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Revision:<br/>
                                                                  <asp:textbox id="txtRevision" width="75px" runat="server"></asp:textbox>
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
