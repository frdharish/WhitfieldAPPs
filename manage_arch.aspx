<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="manage_arch.aspx.cs" Inherits="manage_arch" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- BEGIN MAIN CONTENT AREA -->
			<TABLE cellSpacing="0" cellPadding="0" bgColor="#ffffff" border="0" width="100%">
				<TR>
					<TD>
						<TABLE cellSpacing="5" cellPadding="5" width="100%" border="0">
							<TR>
								<TD colSpan="2"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD width="7"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="7"></TD>
								<TD vAlign="top"><SPAN class="header1">ADMINISTRATION:</SPAN> <SPAN class="header2">Architects</SPAN><BR>
									<BR>
									<IMG height="3" alt="" Src="assets/img/dot.gif" width="499"><BR>
									<BR>
									<TABLE cellSpacing="0" cellPadding="0" border="0">
										<TBODY>
											<TR>
												<TD vAlign="middle"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle"><IMG height="16" alt="" Src="assets/img/add.gif" width="16"></TD>
												<TD vAlign="middle"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle"><asp:button id="btnnew" runat="server" Text="Create New Architect" 
                                                        CssClass="button" onclick="btnnew_Click"></asp:button></TD>
											</TR>
										</TBODY>
									</TABLE>
									<IMG height="3" alt="" Src="assets/img/dot.gif" width="499">
									<BR>
									<BR>
									<TABLE cellSpacing="1" cellPadding="1" border="0" width="100%">
										<tr>
											<td><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
													Width="100%"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:datagrid id="grdRpResults" runat="server" CssClass="#60829F" Width="98%" OnItemCreated="ResultGridItemCreated"
												 PageSize="100"	 OnPageIndexChanged="PageResultGrid" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
													CellPadding="3" DataKeyField="ArchID">
													<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
													<Columns>
														<asp:BoundColumn DataField="Architect" SortExpression="Architect" HeaderText="Architect Name" HeaderStyle-Font-Bold="true">
															<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Address" SortExpression="Address" HeaderText="Address">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Citynm" SortExpression="Citynm" HeaderText="City">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Statenm" SortExpression="Statenm" HeaderText="State">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>														
														<asp:BoundColumn DataField="Phone" SortExpression="Phone" HeaderText="Phone Number">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Fax" SortExpression="Fax" HeaderText="Fax Number">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="EDIT">
															<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
															<ItemTemplate>
																<%# ShowEditImage(((DataRowView)Container.DataItem)["ArchID"])%>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			
<script type="text/javascript" language="javascript">

var theForm = document.forms[0];
window.name ='IEAdvanceQueue';
function ShowEdit(ArchID)
{
    var pageName = "archmain.aspx";
    var parameters = "?IsNew=N&hClientID=" + ArchID;
    url =  pageName + 	parameters	
    location.href=url;
}
</script>
</asp:Content>

