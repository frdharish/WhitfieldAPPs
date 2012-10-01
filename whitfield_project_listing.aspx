<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfield_project_listing.aspx.cs" Inherits="whitfield_project_listing" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:PlaceHolder ID="phProjButton" runat="server">
    <button class="button" style="width:250px" id="btnProjects" onclick="popupfunction('awarded_projects.aspx');" type="button">Add Awarded Projects</button> 
</asp:PlaceHolder>
<BR>
<BR>
<TABLE cellSpacing="0" cellPadding="0" width="50%" border="0">
    <tr>
		<td colspan="3"><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
				Width="100%"></asp:textbox></td>
	</tr>
	<TR>
		<!--<TD vAlign="top" align="center"><IMG height="23" alt="" src="assets/img/prop_ico.gif" width="22" border="0"></TD>-->
		<TD width="22"><IMG height="1" alt="" src="assets/img/spacer.gif" width="22"></TD>
		<TD width="100%">
			<asp:datagrid id="grdsubmitted" runat="server" CssClass="data" Width="700" OnItemCreated="ResultGridItemCreated"
                    OnPageIndexChanged="PageResultGrid1" OnItemDataBound="grdsubmitted_ItemDataBound" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                    FooterStyle-Font-Name="Verdana" PageSize="100" ShowFooter="True"	FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
					FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="EstNum">
                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                    <Columns>
                    <asp:TemplateColumn HeaderText="EDIT">
                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
                            <ItemTemplate>
                                <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["TWC_proj_number"])%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="TWC_proj_number" SortExpression="TWC_proj_number" HeaderText="Project Number" HeaderStyle-Font-Bold="true">
                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="20" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="250"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="fab_start" SortExpression="fab_start" HeaderText="Fabrication Start Date">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn> 
                         <asp:BoundColumn DataField="fab_end" SortExpression="fab_end" HeaderText="Fabrication End Date">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                          <asp:BoundColumn DataField="fab_hours" SortExpression="fab_hours" HeaderText="Shop Hours">
                            <HeaderStyle HorizontalAlign="Right" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn> 
                          <asp:BoundColumn DataField="install_hours" SortExpression="install_hours" HeaderText="Installation Hours">
                            <HeaderStyle HorizontalAlign="Right" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>  
                        <asp:BoundColumn DataField="FinalPrice"   SortExpression="FinalPrice" ItemStyle-HorizontalAlign="Right" HeaderText="Final Amount">
                            <HeaderStyle HorizontalAlign="Right" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>				                                        					                                        
                        <asp:BoundColumn DataField="fmtFinalPrice" Visible="false" ItemStyle-HorizontalAlign="Right" SortExpression="fmtFinalPrice" HeaderText="Final Amount">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="MatContCost" ItemStyle-HorizontalAlign="Right" SortExpression="MatContCost" HeaderText="Material & Contingency Cost">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="OverheadCost"  ItemStyle-HorizontalAlign="Right" SortExpression="OverheadCost" HeaderText="Overhead Cost">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        
                    </Columns>
                    <PagerStyle Mode="NumericPages"></PagerStyle>
                </asp:datagrid>
		</TD>
	</TR>
</TABLE>
<script type="text/javascript" language="javascript">

var theForm = document.forms[0];
window.name = 'IEAdvanceQueue';


var agreewin = "";
function popupfunction(url) {
    var pageName = url;
    url = pageName;
    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Awarded Projects", "width=550px,height=500px,center=1,resize=1,scrolling=0", "recal")
    agreewin.onclose = function() { //Define custom code to run when window is closed
        return true //Allow closing of window in both cases
    }
}

function ShowEdit(EstNum, TWC_proj_number)
{
    var pageName = "whitfield_projectInfo.aspx";
    var parameters = "?EstNum=" + EstNum + "&twcprojnumber=" + TWC_proj_number;
    url =  pageName + 	parameters	
    location.href=url;
}
		  
</script>
</asp:Content>

