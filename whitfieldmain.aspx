<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfieldmain.aspx.cs" Inherits="whitfieldmain" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN MAIN CONTENT AREA -->
<asp:Panel ID="pnlprojects" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" bgColor="#ffffff" border="0">
				<TR>
					<TD>
						<TABLE cellSpacing="5" cellPadding="5" width="100%" border="0">
							<TR>
								<TD colSpan="2"><IMG height="1" alt="" src="assets/img/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD width="7"><IMG height="1" alt="" src="assets/img/spacer.gif" width="7"></TD>
								<TD style="vertical-align:top"><SPAN class="header1">SUBMITTED</SPAN>&nbsp;
									<SPAN class="header2">PROJECTS</SPAN><BR>
									<BR>
									<BR>
									<TABLE cellSpacing="0" cellPadding="0" width="499" border="0">
										<TR>
											<!--<TD vAlign="top" align="center"><IMG height="23" alt="" src="assets/img/prop_ico.gif" width="22" border="0"></TD>-->
											<TD width="22"><IMG height="1" alt="" src="assets/img/spacer.gif" width="22"></TD>
											<TD width="100%">
												<asp:datagrid id="grdsubmitted" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                        OnPageIndexChanged="PageResultGrid1" OnItemDataBound="grdsubmitted_ItemDataBound" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                        FooterStyle-Font-Name="Verdana" PageSize="100" ShowFooter="True"	FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
														FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="EstNum">
				                                        <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				                                        <Columns>
					                                        <asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
						                                        <HeaderStyle HorizontalAlign="center"  VerticalAlign="Bottom" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>
					                                        <asp:BoundColumn DataField="BidDate" SortExpression="BidDate" HeaderText="Bid Date">
						                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="Bottom" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn> 
					                                        <asp:BoundColumn DataField="BaseBid"   SortExpression="BaseBid" ItemStyle-HorizontalAlign="Right" HeaderText="Bid Amount">
						                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="Bottom" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn> 		                                        					                                        
					                                        <asp:BoundColumn DataField="fmtBaseBid"  Visible="false" ItemStyle-HorizontalAlign="Right" SortExpression="fmtBaseBid" HeaderText="Bid Amount">
						                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="Bottom" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>                                                           
		 		                                           <asp:BoundColumn DataField="install_hours"   SortExpression="install_hours"  HeaderText="Install Hours">
						                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="Bottom" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Right"></ItemStyle>
					                                        </asp:BoundColumn>	
					                                         <asp:BoundColumn DataField="fab_hours"   SortExpression="fab_hours"  HeaderText="Shop Hours">
						                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="Bottom" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Right"></ItemStyle>
					                                        </asp:BoundColumn>	
					                                        <asp:TemplateColumn HeaderText="EDIT">
						                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Bottom" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
						                                        <ItemTemplate>
							                                        <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"])%>
						                                        </ItemTemplate>
					                                        </asp:TemplateColumn>
				                                        </Columns>
				                                        <PagerStyle Mode="NumericPages"></PagerStyle>
			                                        </asp:datagrid>
											</TD>
										</TR>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<TR>
											<TD colSpan="3" height="23"><IMG height="203" alt="" src="assets/img/spacer.gif" width="22">
											</TD>
										</TR>
										<TR>
											<TD colSpan="3" height="15"><IMG height="15" alt="" src="assets/img/spacer.gif" width="1"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="7"><IMG height="1" alt="" src="assets/img/spacer.gif" width="7"></TD>
								<TD style="vertical-align:top"><SPAN class="header1">UPCOMING</SPAN>&nbsp;
									<SPAN class="header2">PROJECTS</SPAN>
									<br />
									<br />
									<br />
									<table height="100" cellSpacing="0" cellPadding="1" width="400" border="0">
										<tr>
											<td style="vertical-align:top">
											    <asp:datagrid id="grdPending" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                        OnPageIndexChanged="PageResultGrid2" OnItemDataBound="grdPending_ItemDataBound" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                        FooterStyle-Font-Name="Verdana"	PageSize="100"  ShowFooter="True" FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
														FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="EstNum">
				                                        <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				                                        <Columns>
					                                        <asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
						                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>
					                                        <asp:BoundColumn DataField="BidDate" SortExpression="BidDate" HeaderText="Bid Date">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>	
                                                            <asp:BoundColumn DataField="BaseBid"  Visible="false" SortExpression="BaseBid" ItemStyle-HorizontalAlign="Right"  HeaderText="Bid Amount">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>				                                        					                                        
					                                        <asp:BoundColumn DataField="fmtBaseBid" Visible="false" ItemStyle-HorizontalAlign="Right" SortExpression="fmtBaseBid" HeaderText="Bid Amount">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>
					                                         <asp:BoundColumn DataField="BidTime" SortExpression="BidTime" HeaderText="Bid Time">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>	
					                                        <asp:TemplateColumn HeaderText="EDIT">
						                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
						                                        <ItemTemplate>
							                                        <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"])%>
						                                        </ItemTemplate>
					                                        </asp:TemplateColumn>
				                                        </Columns>
				                                        <PagerStyle Mode="NumericPages"></PagerStyle>
			                                        </asp:datagrid>
											</td>
										</tr>
									</TABLE>
								</TD>
								<TD width="7"><IMG height="1" alt="" src="assets/img/spacer.gif" width="7"></TD>
								<TD style="vertical-align:top"><SPAN class="header1">AWARDED</SPAN>&nbsp;
									<SPAN class="header2">PROJECTS</SPAN>
									<br />
									<br />
									<br />
									<table height="100" cellSpacing="0" cellPadding="1" width="400" border="0">
										<tr>
											<td style="vertical-align:top">
											    <asp:datagrid id="grdAwarded" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                        OnPageIndexChanged="PageResultGrid3" OnItemDataBound="grdAwarded_ItemDataBound" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                        FooterStyle-Font-Name="Verdana"	PageSize="100"  ShowFooter="True" FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
														FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="EstNum">
				                                        <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				                                        <Columns>
					                                        <asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
						                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>
					                                        <asp:BoundColumn DataField="BidDate" Visible="false" SortExpression="BidDate" HeaderText="Bid Date">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>	
                                                            <asp:BoundColumn DataField="FinalPrice"   SortExpression="FinalPrice" ItemStyle-HorizontalAlign="Right"  HeaderText="Final Amount">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>				                                        					                                        
					                                        <asp:BoundColumn DataField="fmtFinalPrice" Visible="false" ItemStyle-HorizontalAlign="Right" SortExpression="fmtFinalPrice" HeaderText="Final Amount">
						                                        <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle BackColor="#EAEFF3"></ItemStyle>
					                                        </asp:BoundColumn>
					                                        <asp:TemplateColumn HeaderText="EDIT">
						                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						                                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
						                                        <ItemTemplate>
							                                        <%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"])%>
						                                        </ItemTemplate>
					                                        </asp:TemplateColumn>
				                                        </Columns>
				                                        <PagerStyle Mode="NumericPages"></PagerStyle>
			                                        </asp:datagrid>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
</asp:Panel>
<!-- END MAIN CONTENT AREA -->
<script type="text/javascript" language="javascript">

var theForm = document.forms[0];
window.name ='IEAdvanceQueue';
function ShowEdit(EstNum)
{
    var pageName = "whitfield_estimation.aspx";
    var parameters = "?EstNum=" + EstNum;
    url =  pageName + 	parameters	
    location.href=url;
}
		  
</script>
</asp:Content>

