<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="twc_weekly_project_scheduling.aspx.cs" Inherits="twc_weekly_project_scheduling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
     <asp:UpdatePanel runat="server" id="upnlAlter">
	<ContentTemplate>
	<table align="left"  width="300px" bgcolor="WhiteSmoke">
    <tr align="left" valign="top">
            <!--fycd,yearmonth,week_number,sequence,Hours,weeklyNotes-->
             <td class="form1" width="150">Year:<br />
		        <asp:dropdownlist id="ddlYear" 
                    runat="server"  
                  ></asp:dropdownlist>
                 <br />
                 <asp:RequiredFieldValidator ID="rryear" 
                       ControlToValidate="ddlYear" ValidationGroup="tabProdSch" InitialValue="0" ErrorMessage="Year is Required" 
                       runat="server">
                </asp:RequiredFieldValidator>
	        </td>
	        
	        <td class="form1" width="150px">Month:<br />
		        <asp:dropdownlist id="ddlMonth" 
                    runat="server"></asp:dropdownlist>
                    <br />
                 <asp:RequiredFieldValidator ID="rrMonth" 
                       ControlToValidate="ddlMonth" ValidationGroup="tabProdSch" InitialValue="0" ErrorMessage="Month is Required" 
                       runat="server">
                    </asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp
                    <asp:button id="btnSearch" style="width:100px" runat="server"  
                    Text="Search" CssClass="button" onclick="btnSearch_Click"></asp:button>
	        </td>
	 </tr>
	</table>
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
    <tr>
		<td colspan="3"><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
				Width="100%"></asp:textbox></td>
	</tr>
	<TR>
	<td>
	  <asp:datagrid id="grdSchedule"                                               
                         runat="server" 
                         CssClass="data"
                         BorderStyle="Solid"
                         OnPageIndexChanged="PageResultGridNotes" 
                         OnItemDataBound="grdSchedule_ItemDataBound"
                         Width="800px"
                         AllowPaging="True" 
                         AutoGenerateColumns="True" 
                         SelectedItemStyle-BackColor="LemonChiffon"
                         FooterStyle-Font-Name="Verdana"
                         PageSize="25" 
                         FooterStyle-Font-Size="10pt" 
                         FooterStyle-Font-Bold="True" 
                         FooterStyle-ForeColor="#ffff99"
                         FooterStyle-BackColor="#D9D9D9"
                         EditItemStyle-BackColor="#ffff66"
                         BackColor="#EAEFF3"
                         AlternatingItemStyle-BackColor="#D9D9D9"
					     ItemStyle-Wrap="False"  
                         ShowFooter="True"  
                         CellPadding="3">
                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                   <PagerStyle Mode="NumericPages"></PagerStyle>
                   </asp:datagrid>
         </td>
       </TR>
    </TABLE>
	</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>

