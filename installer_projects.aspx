<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="installer_projects.aspx.cs" Inherits="installer_projects" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<BR>
<TABLE cellSpacing="0" cellPadding="0" width="50%" border="0">
	<TR>
		<TD width="22"><IMG height="1" alt="" src="assets/img/spacer.gif" width="22"></TD>
		<TD width="100%">
			<asp:datagrid id="grdsubmitted" runat="server" CssClass="data" Width="700" OnItemCreated="ResultGridItemCreated"
                    OnPageIndexChanged="PageResultGrid1" OnItemDataBound="grdsubmitted_ItemDataBound" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                    FooterStyle-Font-Name="Verdana" PageSize="15" ShowFooter="false"	FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
					FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="EstNum">
                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                    <Columns>
                        <asp:BoundColumn DataField="TWC_proj_number" SortExpression="TWC_proj_number" HeaderText="Project Number" HeaderStyle-Font-Bold="true">
                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="20" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="250"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ConstrStart" SortExpression="ConstrStart" HeaderText="Construction Start Date">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn> 
                         <asp:BoundColumn DataField="ConstrCompl" SortExpression="ConstrCompl" HeaderText="Construction End Date">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn> 
                        <asp:BoundColumn  Visible=false DataField="FinalPrice"   SortExpression="FinalPrice" ItemStyle-HorizontalAlign="Right" HeaderText="Final Amount">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>				                                        					                                        
                        <asp:BoundColumn DataField="fmtFinalPrice" Visible="false" ItemStyle-HorizontalAlign="Right" SortExpression="fmtFinalPrice" HeaderText="Final Amount">
                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle BackColor="#EAEFF3" Width="100" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="EDIT">
                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
                            <ItemTemplate>
                                <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["TWC_proj_number"])%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
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
function ShowEdit(EstNum, TWC_proj_number)
{
    var pageName = "InstallerReports.aspx";
    var parameters = "?EstNum=" + EstNum + "&twcprojnumber=" + TWC_proj_number;
    url =  pageName + 	parameters	
    location.href=url;
}
		  
</script>
</asp:Content>



