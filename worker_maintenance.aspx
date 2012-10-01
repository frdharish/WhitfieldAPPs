<%@ Page Language="C#" AutoEventWireup="true" CodeFile="worker_maintenance.aspx.cs" Inherits="worker_maintenance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
	<script type="text/javascript">
	        function isNumber(field) {
	            var re = /^[0-9-'.'-',']*$/;
	            if (!re.test(field.value)) {
	                //alert('Value must be all numberic charcters, including "." or "," non numerics will be removed from field!');
	                field.value = field.value.replace(/[^0-9-'.'-',']/g, "");
	            }
	        }
	        function formatCurrency(num) {
	            num = num.toString().replace(/\$|\,/g, '');
	            if (isNaN(num))
	                num = "0";
	            sign = (num == (num = Math.abs(num)));
	            num = Math.floor(num * 100 + 0.50000000001);
	            cents = num % 100;
	            num = Math.floor(num / 100).toString();
	            if (cents < 10)
	                cents = "0" + cents;
	            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
	                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
                num.substring(num.length - (4 * i + 3));
	            return (((sign) ? '' : '-') + '$' + num + '.' + cents);
	        }
	        function formatCurrencyNoSign(num) {
	            num = num.toString().replace(/\$|\,/g, '');
	            if (isNaN(num))
	                num = "0";
	            sign = (num == (num = Math.abs(num)));
	            num = Math.floor(num * 100 + 0.50000000001);
	            cents = num % 100;
	            num = Math.floor(num / 100).toString();
	            if (cents < 10)
	                cents = "0" + cents;
	            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
	                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
                num.substring(num.length - (4 * i + 3));
	            return (((sign) ? '' : '-') + num + '.' + cents);
	        }

	        function formatNumber() {
	            if (!(event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) { event.returnValue = false; }
	        }

    </script>
    <title>Worker Maintenance</title>
</head>
<body>
    
    <form id="form1" runat="server">
            <asp:HiddenField ID="hidEstNum" runat="server" />
            <asp:HiddenField ID="hidtwcProjNumber" runat="server" />
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table>
    <tr>
          <td vAlign="top" class="form1">                                  
                                <br />								                                               																	
			                    <asp:UpdatePanel runat="server" id="UpdatePanel1">
				                    <ContentTemplate>
					                    <asp:datagrid id="grdManPower" runat="server" Width="100%" CssClass="data" BackColor="#999999" 
					                    ItemStyle-Wrap="False" HorizontalAlign="Center"
					                    OnDeleteCommand="grdManPower_DeleteCommand" 
					                    DataKeyField="worker_id" 
					                    OnCancelCommand="grdManPower_CancelCommand"
					                    OnUpdateCommand="grdManPower_UpdateCommand" 
					                    OnEditCommand="grdManPower_EditCommand" FooterStyle-Font-Name="Verdana"
					                    FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
					                    FooterStyle-BackColor="#D9D9D9"  ShowFooter="True" AutoGenerateColumns="False"
					                    SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
					                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
						                    <Columns> 
						                    
							                     <asp:TemplateColumn SortExpression="worker_firstName" HeaderText="First Name" HeaderStyle-Font-Bold="True"
							                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>							                    
							                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left"></ItemStyle>
							                            <ItemTemplate>
							                            <asp:Label id="lblfirstname" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.worker_firstName")%>'>
							                            </asp:Label>
							                            </ItemTemplate>
							                             <EditItemTemplate>
							                            <asp:TextBox Width="50" id="txtfirstname"  ValidationGroup="EditGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.worker_firstName") %>' >
							                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                            <asp:RequiredFieldValidator id="rfvfirstname" runat="server" Display="Dynamic" ErrorMessage="Please enter first Name"
							                            ControlToValidate="txtfirstname"></asp:RequiredFieldValidator>
							                            </EditItemTemplate>
							                    </asp:TemplateColumn> 
                            																				                            
        					                    <asp:TemplateColumn SortExpression="worker_lastName" HeaderText="Last Name" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lbllastname" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.worker_lastName")%>'>
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" id="txtlastname" runat="server"  ValidationGroup="EditGroup"  Text='<%# DataBinder.Eval(Container, "DataItem.worker_lastName") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvlastname" runat="server" Display="Dynamic" ErrorMessage="Please enter Last Name"
							                    ControlToValidate="txtlastname"></asp:RequiredFieldValidator>
							                    </EditItemTemplate>
							                    </asp:TemplateColumn>
							                    
						                    
							                    <asp:TemplateColumn SortExpression="Street" HeaderText="Street" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblStreet" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Street")%>'>
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" id="txtStreet" runat="server"  ValidationGroup="EditGroup"  Text='<%# DataBinder.Eval(Container, "DataItem.Street") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvStreet" runat="server" Display="Dynamic" ErrorMessage="Please enter Street"
							                    ControlToValidate="txtStreet"></asp:RequiredFieldValidator>
							                    </EditItemTemplate>
							                    </asp:TemplateColumn>
							                    
                    							<asp:TemplateColumn SortExpression="City" HeaderText="City" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblCity" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.City")%>'>
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" id="txtCity" runat="server" ValidationGroup="EditGroup"  Text='<%# DataBinder.Eval(Container, "DataItem.City") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvCity" runat="server" Display="Dynamic" ErrorMessage="Please enter City"
							                    ControlToValidate="txtCity"></asp:RequiredFieldValidator>
							                    </EditItemTemplate>
							                    </asp:TemplateColumn>
							                    
							                    
							                     <asp:TemplateColumn SortExpression="state_cd" HeaderText="state_cd" HeaderStyle-Font-Bold="True">
				                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                        <ItemTemplate>
					                                         <asp:Label id="lblstate" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.state_cd")%>'>
					                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                        </ItemTemplate>
				                                        <EditItemTemplate>                                				                   				                  
				                                                   <asp:DropDownList ID="ddlstate" runat="server"  ValidationGroup="EditGroup"  CssClass="form1"  DataValueField="statecd"  
				                                                                    DataTextField="State"
	                                                                                DataSource='<%#FetchStates()%>'>				                        
                                                                   </asp:DropDownList>
				                                        </EditItemTemplate> 
				                                </asp:TemplateColumn>
				                                
				                                
							                     <asp:TemplateColumn SortExpression="worker_type" HeaderText="worker_type" HeaderStyle-Font-Bold="True">
				                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                        <ItemTemplate>
					                                         <asp:Label id="lblworker_type" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.installer_type_name")%>'>
					                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                        </ItemTemplate>
				                                        <EditItemTemplate>                                				                   				                  
				                                                   <asp:DropDownList ID="ddlworker_type"  ValidationGroup="EditGroup" runat="server" CssClass="form1"  DataValueField="installer_type_id"  
				                                                                    DataTextField="installer_type_name"  
	                                                                                DataSource='<%#FetchEmplyeeTypes()%>'>				                        
                                                                   </asp:DropDownList>
				                                        </EditItemTemplate> 
				                                </asp:TemplateColumn>
							                    
							                    <asp:TemplateColumn SortExpression="ssn" HeaderText="SSN#" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblssn" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.ssn")%>'>
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" MaxLength="10" id="txtssn"  ValidationGroup="EditGroup"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ssn") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvssn" runat="server" Display="Dynamic" ErrorMessage="Please enter ssn"
							                    ControlToValidate="txtssn"></asp:RequiredFieldValidator>
							                    </EditItemTemplate>
							                    </asp:TemplateColumn>
							                    
							                    <asp:TemplateColumn SortExpression="rate_of_pay" HeaderText="Rate" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblRate" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.rate_of_pay")%>'>
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" MaxLength="10" id="txtRate" ValidationGroup="EditGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.rate_of_pay") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvrate_of_pay" runat="server" Display="Dynamic" ErrorMessage="Please enter rate of pay"
							                    ControlToValidate="txtRate"></asp:RequiredFieldValidator>
							                    </EditItemTemplate>
							                    </asp:TemplateColumn>
							                    
							                    														                                  
							                    <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
							                    CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate><EditItemTemplate>
							                    <asp:LinkButton id="lnkbutUpdate" ValidationGroup="EditGroup" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
							                    CommandName="Update"></asp:LinkButton>&nbsp;
							                    <asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
							                    CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:LinkButton id="lnkbutDelete" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
							                    CommandName="DELETE" CausesValidation="false"></asp:LinkButton></ItemTemplate></asp:TemplateColumn></Columns><PagerStyle Mode="NumericPages"></PagerStyle>
							                    </asp:datagrid>
							        </ContentTemplate>
							    </asp:UpdatePanel>
                            </td>
               </tr>
               <!-- ManPower DataGrid Ends Here -->
		</table>
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
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																    <TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
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
																		<asp:dropdownlist id="ddlstate" runat="server" ></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrstate" ControlToValidate="ddlstate" InitialValue="" Display=Static ErrorMessage="State is Required" runat="server"></asp:RequiredFieldValidator>
																		</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">City:<br />
																		<asp:textbox id="txtCity" runat="server" MaxLength="50" Width="132px" 
                                                                            Height="20px"></asp:textbox>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																</TR>
																
																<TR>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
																</TR>
																
																<TR>
																    <TD class="form1">SSN:<br />
																		<asp:textbox id="txtSSN" runat="server" MaxLength="15" Width="281px"></asp:textbox>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD>
																	<TD class="form1">Hourly Rate:<br />
																		<asp:textbox id="txtrate" runat="server" MaxLength="17" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
																	</TD>
																	<TD vAlign="middle" width="10"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="10"></TD>																
																    <TD class="form1">Emplyee Type:<br />
																		<asp:dropdownlist id="ddlEmplyType" runat="server"></asp:dropdownlist>
																		<br /><asp:RequiredFieldValidator ID="rrEmplType" ControlToValidate="ddlEmplyType" InitialValue="" Display=Static ErrorMessage="Emplyee Type is Required" runat="server"></asp:RequiredFieldValidator>
															        </TD>
															    </TR>

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
												</TBODY>
									</TABLE>
    </div>
    </form>
</body>
</html>
