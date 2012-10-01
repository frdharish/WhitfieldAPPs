<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<table WIDTH="506" CELLPADDING="0" CELLSPACING="0" BORDER="0">
<tr>
<td HEIGHT="33" COLSPAN="2"><IMG Src="assets/img/spacer.gif" WIDTH="1" HEIGHT="33" ALT=""></td>
</tr>
<tr>
<td WIDTH="39"><IMG Src="assets/img/spacer.gif" WIDTH="39" HEIGHT="1" ALT=""></td>
<td>
<table BGCOLOR="#ffffff" WIDTH="467" CELLPADDING="0" CELLSPACING="0" BORDER="0">
									<tr>
										<td><IMG Src="assets/img/topbox_login.gif" WIDTH="467" HEIGHT="25" ALT=""></td>
									</tr>
									<tr>
										<td>
											<table WIDTH="467" CELLPADDING="0" CELLSPACING="0" BORDER="0">
												<tr>
													<td WIDTH="31" HEIGHT="30"><IMG Src="assets/img/spacer.gif" WIDTH="31" HEIGHT="1" ALT=""></td>
													<td WIDTH="359" HEIGHT="30" VALIGN="top"><SPAN CLASS="header1">SYSTEM</SPAN> <SPAN CLASS="header2">
															LOGIN</SPAN></td>
													<td WIDTH="64" HEIGHT="30"><IMG Src="assets/img/ico_login.gif" WIDTH="64" HEIGHT="30" ALT=""></td>
													<td WIDTH="13" HEIGHT="30"><IMG Src="assets/img/ico_shadow.gif" WIDTH="13" HEIGHT="30" ALT=""></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td BGCOLOR="#000000"><IMG Src="assets/img/blk_line_shadow.gif" WIDTH="467" HEIGHT="1" ALT=""></td>
									</tr>
									<tr>
										<td>
										<table width="467" cellpadding="0" cellspacing="0" border="0">
	                                        <tr>
		                                        <td width="454" BGCOLOR="#f9f9f9" valign="top">
			                                        <table cellpadding="0" cellspacing="0" border="0">
					                                        <TBODY>
						                                        <tr>
							                                        <td width="24"><img Src="assets/img/spacer.gif" width="10" height="1" alt=""></td>
							                                        <td class="form1" valign="top"><img Src="assets/img/spacer.gif" width="1" height="5" alt="">
								                                        <br>
								                                        username:<br>
								                                        <asp:textbox id="tbUserID" MaxLength="30" TabIndex="1" Cssclass="width: 210px;" runat="server"></asp:textbox><br />
								                                        <asp:RequiredFieldValidator ID="rruserid" ControlToValidate="tbUserID"  ForeColor="Red" ErrorMessage="Login is required"  runat="server"></asp:RequiredFieldValidator> </td>
						                                        <tr>
							                                        <td width="24"></td>
							                                        <td class="form1" valign="top"><img Src="assets/img/spacer.gif" width="1" height="5" alt="">
								                                        <br>
								                                        password:<br>
								                                        <asp:textbox id="tbpassword" textmode="Password" MaxLength="30" TabIndex="2" Cssclass="width: 210px;"
									                                        runat="server"></asp:textbox><br />
									                                    <asp:RequiredFieldValidator ID="rrpass" ControlToValidate="tbpassword"  ForeColor="Red" ErrorMessage="Password required"  runat="server"></asp:RequiredFieldValidator>
								                                        <asp:button id="btnSignIn" class="button" runat="server" text="Login Now" TabIndex="3" 
                                                                            onclick="btnSignIn_Click"></asp:button></td>
						                                        <tr>
							                                        <td width="24"></td>
							                                        <td class="error1" valign="top"><img Src="assets/img/spacer.gif" width="1" height="8" alt=""><br>
								                                        <asp:Label ID="lblMsg" runat="server"></asp:Label><br>
							                                        </td>
						                                        </tr>
			                                        </table>
		                                        </td>
		                                        <td width="13" valign="top"><img Src="assets/img/box_shadow.gif" width="13" height="125" alt=""></td>
	                                        </tr>
                                        </table>
</td>
</tr>
<tr>
<td>
	                                    <table WIDTH="467" CELLPADDING="0" CELLSPACING="0" BORDER="0">
		                                    <tr>
			                                    <td BGCOLOR="#60829f" WIDTH="28"><IMG Src="assets/img/left_bot.gif" WIDTH="28" HEIGHT="26" ALT=""></td>
			                                    <td BGCOLOR="#60829f" WIDTH="395">
				                                    <table CELLPADDING="0" CELLSPACING="0" BORDER="0">
					                                    <tr>
						                                   <td><a onclick="return hs.htmlExpand(this,{objectType:'iframe',minWidth:300,objectHeight:200,preserveContent:false,align:'center',contentId:'template'})" href="chagepass.aspx" WIDTH="152" HEIGHT="26" ALT="" BORDER="0"><IMG Src="assets/img/change.gif" WIDTH="151" HEIGHT="26" ALT="" BORDER="0"></A></td>
						                                    <td><a onclick="return hs.htmlExpand(this,{objectType:'iframe',minWidth:300,objectHeight:200,preserveContent:false,align:'center',contentId:'template'})" href="resetpass.aspx" WIDTH="151" HEIGHT="26" ALT="" BORDER="0"><IMG Src="assets/img/forgot.gif" WIDTH="152" HEIGHT="26" ALT="" BORDER="0"></A></td>  
						                                    
						                                    <!--<td><a onclick="return hs.htmlExpand(this,{objectType:'iframe',minWidth:300,objectHeight:200,preserveContent:false,align:'center',contentId:'template'})"
																								href="resetpass.aspx"><IMG Src="assets/img/forgot.gif" /></a></td>
															<td><a onclick="return hs.htmlExpand(this,{objectType:'iframe',minWidth:300,objectHeight:200,preserveContent:false,align:'center',contentId:'template'})"
																								href="chagepass.aspx"><IMG Src="assets/img/forgot.gif" /></a></td>--> 
					                                    </tr>
				                                    </table>
			                                    </td>
			                                    <td BGCOLOR="#60829f" WIDTH="44"><IMG Src="assets/img/right_bot.gif" WIDTH="44" HEIGHT="26" ALT=""></td>
		                                    </tr>
	                                    </table>
</td>
</tr>
<tr>
<td><IMG Src="assets/img/bot_box.jpg" WIDTH="467" HEIGHT="20" ALT=""></td>
</tr>
</table>
</asp:Content>

