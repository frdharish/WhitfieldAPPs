<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="twc_project_scheduling.aspx.cs" Inherits="twc_project_scheduling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
 <tr>
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
 </tr>                                    
</table>
</asp:Content>

