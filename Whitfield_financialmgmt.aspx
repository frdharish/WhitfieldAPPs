<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="Whitfield_financialmgmt.aspx.cs" Inherits="Whitfield_financialmgmt" %>
<%@ Register TagPrefix="uc1" TagName="submaterial" Src="Whitfield_financialmgmt_child.ascx" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div>
            <asp:datagrid id="grdProjects" 
            runat="server" 
            CssClass="data" 
            Width="98%"  PageSize="100"
            OnItemCreated="ResultGridItemCreated"
		    OnPageIndexChanged="PageResultGrid" 
		    OnItemDataBound="grdProjects_ItemDataBound"
		    OnItemCommand="grdProjects_Itemcommand"
		    AllowPaging="True" 
		     ShowFooter = "True"
		    AutoGenerateColumns="False" 
		    SelectedItemStyle-BackColor="LemonChiffon"
		    CellPadding="3" 
		    DataKeyField="TWC_proj_number">
			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				<Columns>
				    <asp:TemplateColumn HeaderImageUrl="assets/img/Search.gif">
					    <HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					    <ItemStyle HorizontalAlign="Center"></ItemStyle>
					    <ItemTemplate>
						    <asp:ImageButton ImageUrl="assets/img/Plus.gif" CommandName="Expand" ID="btnExpand" Runat="server"></asp:ImageButton>
					    </ItemTemplate>
				    </asp:TemplateColumn>
				
				    <asp:TemplateColumn HeaderText="EDIT">
                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
                        <ItemTemplate>
                             <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["TWC_proj_number"])%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    
					<asp:BoundColumn DataField="TWC_proj_number" SortExpression="TWC_proj_number" HeaderText="Number" HeaderStyle-Font-Bold="true">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="C_Contract_Value" SortExpression="C_Contract_Value" HeaderText="Current Contract">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="O_Contract_Value" SortExpression="O_Contract_Value" HeaderText="Original Contract">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="CO_Contract_Value" SortExpression="CO_Contract_Value" HeaderText="Change Order">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="Earned_amt" SortExpression="Earned_amt" HeaderText="Earned Amt">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="Open_invoices" SortExpression="Open_invoices" HeaderText="Open Invoices">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					
				
					<asp:TemplateColumn HeaderText="Balance Remaining" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblBalremaining" runat="server">
					                </asp:Label>
				        </ItemTemplate>
				   </asp:TemplateColumn>
				
				   <asp:TemplateColumn>
					        <ItemStyle HorizontalAlign="Center" ForeColor="#33cc00" CssClass="subnav"></ItemStyle>
					        <ItemTemplate>
						        <asp:PlaceHolder ID="ExpandedContent" Visible="False" Runat="server">
							        <%# ShowClosingTags() %>
							        <table id='Dynacontent' width="100%" style="background-color:White;">
								        <colgroup>
									        <col width="10%">
									        <col width="50%">
								        </colgroup>
								        <tr>
									        <td>
										        <uc1:submaterial id="DynamicTable1" runat="server"></uc1:submaterial>
									        </td>
								        </tr>
							        </table>
						        </asp:PlaceHolder>
					        </ItemTemplate>
				    </asp:TemplateColumn>
				</Columns>
						<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>	
</div>
<!-- END MAIN CONTENT AREA -->
<script type="text/javascript" language="javascript">

var theForm = document.forms[0];
window.name ='IEAdvanceQueue';
function ShowEdit(EstNum,twc_project_number)
{
    var pageName = "Whitfield_projectInvoice.aspx";
    var parameters = "?EstNum=" + EstNum + "&twc_project_number=" + twc_project_number;
    url =  pageName + 	parameters	
    location.href=url;
}
		  
</script>
</asp:Content>

