<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfield_users_edit.aspx.cs" Inherits="whitfield_users_edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" />
<!-- BEGIN MAIN CONTENT AREA -->
			<TABLE cellSpacing="0" cellPadding="0" bgColor="#ffffff" border="0">
				<TBODY>
					<TR>
						<TD>
							<TABLE cellSpacing="5" cellPadding="5" width="100%" border="0">
								<TBODY>
									<TR>
										<TD colSpan="2"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="1"></TD>
									</TR>
									<TR>
										<TD width="7"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="7"></TD>
										<TD vAlign="top"><SPAN class="header1">ADMINISTRATION:</SPAN>
											<SPAN class="header2">USERS</SPAN><BR>
											<BR>
											<IMG height="3" alt="" Src="assets/img/dot.gif" width="499">
											<BR>
											<BR>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TBODY>
													<TR>
														<TD colSpan="4"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="10"></TD>
													</TR>
													<TR>
														<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
														<TD vAlign="middle" colSpan="3">
															<TABLE cellSpacing="0" cellPadding="0" border="0">
															    <TR>
																	<TD class="form1">First Name:<br />
																		<asp:textbox id="txtfn" runat="server" MaxLength="17"></asp:textbox>
																		<br /><asp:RequiredFieldValidator ID="rrfn" ControlToValidate="txtfn" InitialValue="" Display=Static ErrorMessage="First Name is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1" style="width: 151px">Last Name:<br />
																		<asp:textbox id="txtln" runat="server" MaxLength="17"></asp:textbox>
																		<br /><asp:RequiredFieldValidator ID="rrln" ControlToValidate="txtln" InitialValue="" Display=Static ErrorMessage="Last Name is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">E-Mail:<br /><asp:textbox id="txtem" runat="server" MaxLength="50" Width="281px" Runat="server"></asp:textbox>
																		<br />
																		<asp:RequiredFieldValidator ID="rrem" ControlToValidate="txtem" InitialValue="" Display=Static ErrorMessage="Email is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																    <TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">Employee Number:<br /><asp:textbox id="txtEmpNo" runat="server" MaxLength="50" Width="281px" runat="server"></asp:textbox>
																		<br />
																		<asp:RequiredFieldValidator ID="rrempno" ControlToValidate="txtEmpNo" InitialValue="" Display=Static ErrorMessage="Employee Number is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																</TR>
																
																<TR>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
																</TR>
																
																<TR>
																	<TD class="form1">Address:<br />
																		<asp:textbox id="txtaddress" runat="server" MaxLength="50" Width="281px"></asp:textbox>
																		<br /><asp:RequiredFieldValidator ID="rraddress" ControlToValidate="txtaddress" InitialValue="" Display=Static ErrorMessage="Address is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1" style="width: 151px">State:<br />
																		<asp:dropdownlist id="ddlstate" runat="server"  AutoPostBack=true
                                                                            onselectedindexchanged="ddlstate_SelectedIndexChanged"></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrstate" ControlToValidate="ddlstate" InitialValue="" Display=Static ErrorMessage="State is Required" runat="server"></asp:RequiredFieldValidator>
																		</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">City:<br />
																		<asp:dropdownlist id="ddlcity" runat="server"></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrcity" ControlToValidate="ddlcity" InitialValue="" Display=Static ErrorMessage="City is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">Zip Code:<br />
																		<asp:textbox id="txtzip" runat="server" MaxLength="50" Width="281px" Runat="server"></asp:textbox></TD>
																</TR>
																
																<TR>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
																</TR>
																
																<TR>
																	<TD class="form1">UserID:<br />
																		<asp:textbox id="txtuserid" runat="server" MaxLength="17" ReadOnly="true"></asp:textbox></TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1" style="width: 151px">Password:<br />
																		<asp:textbox id="txtpasswd" runat="server" MaxLength="17"></asp:textbox></TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">Phone Number:<br />
																		<asp:textbox id="txtphno" runat="server" MaxLength="17" Width="224px" ValidationGroup="MKE" ></asp:textbox>
																		<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                                                TargetControlID="txtphno"
                                                                                Mask="999-999-9999"
                                                                                ClearMaskOnLostFocus="false"
                                                                                MessageValidatorTip="true"
                                                                                MaskType="None"
                                                                                InputDirection="LeftToRight"
                                                                                AcceptNegative="Left"
                                                                                DisplayMoney="Left" Filtered="-"
                                                                                />
                                                                            <ajaxToolkit:MaskedEditValidator id="MaskedEditValidator2" runat="server"
                                                                                ControlExtender="MaskedEditExtender2"
                                                                                ControlToValidate="txtphno"
                                                                                IsValidEmpty="true" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                                                                                InvalidValueMessage="input is invalid"
                                                                                Display="Dynamic"
                                                                                TooltipMessage="XXX-XXX-XXXX"
                                                                                InvalidValueBlurredMessage="Please input the right phone number!"
                                                                                ValidationGroup="MKE" /></TD>
																		<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">Role:<br />
																		<asp:dropdownlist id="ddlrole" runat="server"></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrrole" ControlToValidate="ddlrole" InitialValue="" Display=Static ErrorMessage="Role is Required" runat="server"></asp:RequiredFieldValidator>
																	</TD>

																</TR>
																
																
																<TR>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
																</TR>
																
																<TR>
																	<TD class="form1">Hourly Rate:<br />
																		<asp:textbox id="txtrate" runat="server" MaxLength="17" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></TD>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
																</TR>
																<TD class="form1">Emplyee Type:<br />
																		<asp:dropdownlist id="ddlEmplyType" runat="server"></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrEmplType" ControlToValidate="ddlEmplyType" InitialValue="" Display=Static ErrorMessage="Emplyee Type is Required" runat="server"></asp:RequiredFieldValidator>
															    </TD>

															</TABLE>
															<TABLE>
																<TR>
																	<TD  align="center" class="form1" colSpan="5">
																	    <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
                                                                            onclick="btnnew_Click"></asp:button>&nbsp;&nbsp;
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
														<TD vAlign="middle" colSpan="3"></TD>
													</TR>
												</TBODY></TABLE>
										</TD>
									</TR>
									<TR>
										<TD colSpan="2"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="1"></TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
				</TBODY></TABLE>
</asp:Content>

