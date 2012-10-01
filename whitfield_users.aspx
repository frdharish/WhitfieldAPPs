<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfield_users.aspx.cs" Inherits="whitfield_users" %>
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
								<TD vAlign="top"><SPAN class="header1">ADMINISTRATION:</SPAN> <SPAN class="header2">USERS</SPAN><BR>
									<BR>
									<IMG height="3" alt="" Src="assets/img/dot.gif" width="499"><BR>
									<BR>
									<TABLE cellSpacing="0" cellPadding="0" border="0">
										<TBODY>
											<TR>
												<TD vAlign="middle"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle"><IMG height="16" alt="" Src="assets/img/add.gif" width="16"></TD>
												<TD vAlign="middle"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle"><asp:button id="btnnew" runat="server" Text="Create New User" 
                                                        CssClass="button" onclick="btnnew_Click"></asp:button></TD>
											</TR>
										</TBODY>
									</TABLE>
									<IMG height="3" alt="" Src="assets/img/dot.gif" width="499">
									<BR>
									<BR>
									<TABLE cellSpacing="0" cellPadding="0" border="0">
										<TBODY>
											<TR>
												<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle" width="16"><IMG height="16" alt="" Src="assets/img/search.gif" width="16"></TD>
												<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD class="title" vAlign="middle" width="100%">Existing User Search</TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="10"></TD>
											</TR>
											<TR>
												<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
												<TD vAlign="middle" colSpan="3">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="form1">UserID:<BR>
																<asp:textbox id="txtuserid" runat="server" MaxLength="17"></asp:textbox></TD>
															<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
															<TD class="form1">Phone Number:<BR>
																<asp:textbox id="txtphno" runat="server" MaxLength="17"></asp:textbox></TD>
															<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
															<TD class="form1">role:<BR>
																<asp:dropdownlist id="ddlrole" runat="server"></asp:dropdownlist></TD>
														<TR>
															<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
														</TR>
														<TR>
															<TD class="form1">First Name:<BR>
																<asp:textbox id="txtfn" runat="server" MaxLength="17"></asp:textbox></TD>
															<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
															<TD class="form1">Last Name:<BR>
																<asp:textbox id="txtln" runat="server" MaxLength="17"></asp:textbox></TD>
															<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
														</TR>
														<TR>
															<TD colSpan="5"><IMG height="10" alt="" src="assets/img/spacer.gif" width="1"></TD>
														</TR>
														 <tr>
															<td class="form1" colSpan="5">
															        <button id="btnContacts" onclick="popupcontact()"></button>
															        <asp:button id="btnSelect" runat="server" 
                                                                    Text="Search Existing Users" CssClass="button" onclick="btnSelect_Click"></asp:button></td>
														</tr>
													</TABLE>
												</TD>
											</TR>
										</TBODY>
									</TABLE>
									<BR>
									<TABLE cellSpacing="1" cellPadding="1" border="0" width="100%">
										<tr>
											<td><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
													Width="100%"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:datagrid id="grdRpResults" runat="server" CssClass="#60829F" Width="98%" OnItemCreated="ResultGridItemCreated"
													OnPageIndexChanged="PageResultGrid" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
													CellPadding="3" DataKeyField="Loginid">
													<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
													<Columns>
														<asp:BoundColumn DataField="Loginid" SortExpression="Loginid" HeaderText="USER ID" HeaderStyle-Font-Bold="true">
															<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="First Name">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LastName" SortExpression="LastName" HeaderText="Last Name">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EmployeeNo" SortExpression="EmployeeNo" HeaderText="Employee #">
															<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle BackColor="#EAEFF3"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="EDIT">
															<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
															<ItemTemplate>
																<%# ShowEditImage(((DataRowView)Container.DataItem)["LoginId"])%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DELETE">
															<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
															<ItemTemplate>
																<%# ShowDelsImage(((DataRowView)Container.DataItem)["LoginId"])%>
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
	        function ShowDelete(UserId)
	        {
	            var pageName = "whitfield_users.aspx";
		        var parameters	=	"?hUserid=" + UserId + "&hFlag=D";
		        var result		=	null;
		        if (confirm("Are you sure want to delete this user?"))
		        {
			        url =  pageName + 	parameters	
			        location.href=url;				
			        return;
		        }
	        }

	        function ShowEdit(UserId)
	        {
	            var pageName = "whitfield_users_edit.aspx";
		        var parameters	=	"?hUserid=" + UserId + "&hFlag=E";
		        url =  pageName + 	parameters	
		        location.href=url;
		    }
		    function popupcontact() {
		    }
		</script>
</asp:Content>

