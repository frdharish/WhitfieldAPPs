<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInvoice.aspx.cs" Inherits="AddInvoice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Invoice</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <table  align="left"  width="100%" cellspacing="0" cellpadding="0" border="0">
        <th colspan="2" align="left">Add Invoice</th>
        <tr>
            <td>
                        <table border="1">
                        
                            <tr> 
                                <td class="form1">
                                Number<br />
					            <asp:dropdownlist id="ddlNo" ValidationGroup="insertnew" runat="server"></asp:dropdownlist><br />
					            <asp:RequiredFieldValidator ID="rrNo" ControlToValidate="ddlNo" ValidationGroup="insertnew" 
					            ErrorMessage="Number is Required" 
                                runat="server"></asp:RequiredFieldValidator>
                                </td> 

                                <td class="form1">Date Submitted<br />
					                 <asp:TextBox ID="txtSubmitDate" ValidationGroup="insertnew" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                <asp:ImageButton runat="server"  ID="ImgBidDate"
					                ImageUrl="assets/img/calendar.gif"  ValidationGroup="insertnew"
                                    AlternateText="Click here to display calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalBidDate" runat="server" 
                                    Format="MM/dd/yyyy" TargetControlID="txtSubmitDate"  
                                    PopupButtonID="ImgBidDate" Enabled="True"/>
                                </td> 
                                
                                <td class="form1">Date Approved <br />
					                 <asp:TextBox ID="txtApprDate" ValidationGroup="insertnew" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                <asp:ImageButton runat="server"  ID="ImageButton1"
					                ImageUrl="assets/img/calendar.gif"  ValidationGroup="insertnew"
                                    AlternateText="Click here to display calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    Format="MM/dd/yyyy" TargetControlID="txtApprDate"  
                                    PopupButtonID="ImageButton1" Enabled="True"/>
                                </td> 
                                
                            </tr>                  
                            <tr> 
                            <td class="form1">Date Received <br />
					                 <asp:TextBox ID="txtReceivedDate" ValidationGroup="insertnew" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                <asp:ImageButton runat="server"  ID="ImageButton2"
					                ImageUrl="assets/img/calendar.gif"  ValidationGroup="insertnew"
                                    AlternateText="Click here to display calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                                    Format="MM/dd/yyyy" TargetControlID="txtReceivedDate"  
                                    PopupButtonID="ImageButton2" Enabled="True"/>
                             </td> 
                             <td class="form1">Fabrication Labor Cost<br />
                                      <asp:textbox id="txtfabCost"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                             <td class="form1">Installation Labor  Cost<br />
                                      <asp:textbox id="txtInstCost"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                             
                             </tr>
                             <tr>
                             <td class="form1">Material Cost<br />
                                      <asp:textbox id="txtMatCost"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                              <td class="form1">Base Contract Billing Amount<br />
                                      <asp:textbox id="txtBseContract"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                             <td class="form1">Change Orders Billing Amount<br />
                                      <asp:textbox id="txtChangeOrder"  style="text-align:right"  ValidationGroup="insertnew" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>
                             </tr>
                             <tr>
                                    <td lass="form1" colspan="3">Notes/Comments<br /> 
                                <asp:textbox  ValidationGroup="insertnew" id="txtDescription" runat="server" 
                                            TextMode="MultiLine" Rows="3"  Columns="40" Width="523px"></asp:textbox></td>
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
