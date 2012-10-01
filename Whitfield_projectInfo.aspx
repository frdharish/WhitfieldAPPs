<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="Whitfield_projectInfo.aspx.cs" Inherits="Whitfield_projectInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div>  <!-- Outer Div -->
<table cellpadding="2" cellspacing="2" width="100%" bgcolor="white">
  <tr>
    <td align="left"> <!-- Project Information Tabs Begin-->
    <SPAN class="header2"><asp:Label ID="lblPrjHeader" runat="server"></asp:Label></SPAN><br />
    <ajaxToolkit:TabContainer ID="tabgeneral" runat="server" Width="100%" 
            CssClass="fancy" ActiveTabIndex="6">
        <!-- Project General Information -->
        <ajaxToolkit:TabPanel ID="tabGenInfo" runat="server" HeaderText="General Information">
           <ContentTemplate>
                                   <table align="center" cellspacing="2" cellpadding="2"  width="100%" height="400" bgcolor="WhiteSmoke">
                                        <tr align="left" valign="top">
                                              <td>
                                                   <SPAN class="header1">GENERAL</SPAN><SPAN class="header2">INFORMATION</SPAN><BR>
        									          <TABLE  align="left"  width="75%" cellSpacing="0" cellPadding="0" border="0">
									                        <tr>
									                            <TD class="form1">Whitfield Project#:<br />
									                                        <asp:textbox id="txtrealPrjNumber" ValidationGroup="TabGroup1"  runat="server" MaxLength="50" Width="300px"></asp:textbox>

															                <asp:textbox id="txttwcPrjNumber" ValidationGroup="TabGroup1" 
                                                                    visible="False" ReadOnly=True runat="server" MaxLength="50" Width="300px"></asp:textbox>

															                <asp:HiddenField ID="hdntwcProjNumber" runat="server" />

															                <br />
														        </TD>
									                            <TD vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
									                            <TD class="form1" style="width: 151px">Client Project#:<br />
									                                        <asp:textbox id="txtClientPrjNumber" ValidationGroup="TabGroup1"  runat="server" MaxLength="50" Width="300px"></asp:textbox>

															                <br />
															                <asp:RequiredFieldValidator ValidationGroup="TabGroup1" ID="rrClientProjectNum" 
                                                                            ControlToValidate="txtClientPrjNumber" ErrorMessage="Client Project Number   Required"
                                                                            runat="server"></asp:RequiredFieldValidator>

									                            </TD>
									                            <TD vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
									                            <TD class="form1" style="width: 151px">Contract#:<br />
									                                        <asp:textbox id="txtContractNumber" ValidationGroup="TabGroup1"  runat="server" MaxLength="50" Width="300px"></asp:textbox>

															                <br />
									                            </TD>
	   							                             </tr>
									                         <TR>
														                <TD class="form1">Project Name:<br />
															                <asp:textbox id="txtprjname" ValidationGroup="TabGroup1" runat="server" MaxLength="50" Width="300px"></asp:textbox>

															                <asp:HiddenField ID="hdnEstNum" runat="server" />

															                <br />
															                <asp:RequiredFieldValidator ValidationGroup="TabGroup1" ID="rrprjname" 
                                                                            ControlToValidate="txtprjname" ErrorMessage="Project Name is Required"
                                                                            runat="server"></asp:RequiredFieldValidator>

														                </TD>
														                <TD vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
														                <TD class="form1" style="width: 151px">Project Type:<br />
															                <asp:dropdownlist id="ddlprjtype" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>


															                <br /><asp:RequiredFieldValidator ID="rrprjtype" 
                                                                                    ControlToValidate="ddlprjtype" ValidationGroup="TabGroup1" InitialValue="0" ErrorMessage="Project Type is Required" 
                                                                                    runat="server"></asp:RequiredFieldValidator>

														                </TD>
														                <TD vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
														                <TD vAlign="top" class="form1" style="width: 151px">Architect:<br />
															                <asp:dropdownlist id="ddlarchitect" Width="250px"  ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>

														                </TD>
												              </tr>
												     
												             <tr>
																	        <TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
													         </tr>
        															
															
												             <tr>
												                    <TD class="form1">Project Description:<br />
																		<asp:textbox id="txtdesc" width="380px"   ValidationGroup="TabGroup1" runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                                                        cols="80"></asp:textbox>


                                                                    </TD>
															        <TD vAlign="top"  ><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															        <TD class="form1">Notes/Comments:<br />
																		<asp:textbox id="txtNotes" width="380px"   ValidationGroup="TabGroup1" runat="server"  Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                                                        cols="80"></asp:textbox>

                                                                    </TD>
                                                                    <TD vAlign="top" ><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
														            <td class="form1">Final Price:<br />
																	        <asp:textbox id="txtfinalbid" style="text-align:right" MaxLength="14" ValidationGroup="TabGroup1" runat="server" Width="224px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>

                                                                    </td>
												           </tr>   
															
															<tr>
																	<TD colSpan="5"><IMG height="10" alt="" Src="assets/img/spacer.gif" width="1"></TD>
															</tr>
															
															<tr>															        
					    											<td vAlign="top" class="form1">Contractors:<br />
					          
																	            <br /><asp:datagrid id="grdclients" runat="server" CssClass="data" 
                                                                            Width="98%" OnItemCreated="ResultGridItemCreated"
													                                    OnPageIndexChanged="PageResultGrid1" AllowPaging="True" AutoGenerateColumns="False"
													                                    CellPadding="3" DataKeyField="ClientID">
<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
<Columns>
<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Client Name">
<HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
        Font-Bold="True"></HeaderStyle>

<ItemStyle BackColor="#EAEFF3"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ContactName" SortExpression="ContactName" HeaderText="Primary Contact">
<HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="#60829F" 
        CssClass="subnav"></HeaderStyle>

<ItemStyle BackColor="#EAEFF3"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="Email">
<HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="#60829F" 
        CssClass="subnav"></HeaderStyle>

<ItemStyle BackColor="#EAEFF3"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Tel" SortExpression="Tel" HeaderText="Contact Number">
<HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="#60829F" 
        CssClass="subnav"></HeaderStyle>

<ItemStyle BackColor="#EAEFF3"></ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="EDIT">
    <ItemTemplate>
																                                    <%# ShowContactEditImage("twc_AddContacts.aspx", ((DataRowView)Container.DataItem)["ClientID"])%>
															                                    
</ItemTemplate>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#60829F" 
        CssClass="subnav"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
</asp:TemplateColumn>
</Columns>

<PagerStyle Mode="NumericPages"></PagerStyle>
</asp:datagrid>

															        </td>
															         <TD vAlign="top" ><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
														            <td class="form1">Winning Contractor:<br />
															                    <asp:dropdownlist id="ddlwonclient" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>

															            </td>
        														         <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															            <td class="form1">Construction Duration:<br />
															            <asp:TextBox ID="txtConstDuration" MaxLength="5" Width="30px"  ValidationGroup="TabGroup1" runat="server"></asp:TextBox>
 Day(s)
															            </td>
															 </tr>
															 
															 
															 <tr> 
															 		    <td class="form1">Construction End Date:<br />
															                 <asp:TextBox ID="txtConstEndDate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>

															                <asp:ImageButton runat="server"  ID="imgconstEnd"  
                                                                             ImageUrl="assets/img/calendar.gif" 
                                                                             AlternateText="Click here to display calendar" />

															                 <ajaxToolkit:CalendarExtender ID="CalConstEnd" Format="MM/dd/yyyy"  
                                                                             runat="server" TargetControlID="txtConstEnddate" PopupButtonID="imgconstEnd" 
                                                                             Enabled="True"/>

															             </td>
															            <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															            <td class="form1">Construction Start Date:<br />
														                    <asp:TextBox ID="txtConstStdate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>

															                <asp:ImageButton runat="server"  ID="imgConst"  
                                                                            ImageUrl="assets/img/calendar.gif" 
                                                                            AlternateText="Click here to display calendar" />
 
															                <ajaxToolkit:CalendarExtender ID="CalConst" Format="MM/dd/yyyy"  runat="server" 
                                                                            TargetControlID="txtConstStdate" PopupButtonID="imgConst" Enabled="True"/>

															            </td>
															            <td vAlign="top" width="50"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															            <td class="form1">Assigned Installers:<br />
															                    <DIV style="OVERFLOW-Y:scroll; WIDTH:350px; HEIGHT:125px;" >
                                                                                   <asp:CheckBoxList ID="chkInstallers" runat="server"></asp:CheckBoxList>

                                                                                </DIV>
															            </td>
															 </tr>
															 <tr>
															             <td>
															                    Project Status:<br />
					                                                            <asp:dropdownlist id="ddlPrjStatus" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>
															             </td>
															             <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															             <td class="form1">Material and Contingency Cost:<br />
															             <asp:TextBox ID="txtMatContCost" MaxLength="10" Width="30px"  ValidationGroup="TabGroup1" runat="server"></asp:TextBox>
															            </td>
															             <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															             <td class="form1">Overhead and Profit Cost:<br />
															             <asp:TextBox ID="txtOverheadCost" MaxLength="10" Width="30px"  ValidationGroup="TabGroup1" runat="server"></asp:TextBox>
															            </td>
															 </tr>
															<tr>
															    <td  align="center" class="form1" colSpan="5">
																	    <asp:button id="btnnew" runat="server" ValidationGroup="TabGroup1" Text="Save Changes" CssClass="button" 
                                                                            onclick="btnnew_Click"></asp:button>
                                                                        &nbsp;&nbsp
                                                                        <button class="button" style="width:150px" id="btnDistribution" onclick="popupfunction('maintain_dlist.aspx','Distribution List');" type="button">Distribution List</button>
															    </td>
															</tr>
                                                         </TABLE>  
									     </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
									     
									      <!-- Parameters -->
									      <ajaxToolkit:TabPanel ID="TabParameters" runat="server" HeaderText="Parameters">
                                            <ContentTemplate>
                                                 <table align='center'  width="100%" height="400" bgcolor="WhiteSmoke">
                                                      <tr align="left" valign="top">
                                                           <td>
                                                                <table><SPAN class="header1">Parameters</SPAN>
                                                                <br />
                                                                <br />
                                                                   <table>
                                                                       <tr>
                                                                            <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															                 <td class="form1">Original Contract:<br />
															                 
															                 <asp:TextBox ID="txtOrigContract" MaxLength="10" Width="100px"  ValidationGroup="TabParam" runat="server"></asp:TextBox>
															                </td>
															           </tr>
															           <tr>
															                 <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															                 <td class="form1">Change Orders:<br />
															                 <asp:TextBox ID="txtChangeOrder" MaxLength="10" Width="100px"  ValidationGroup="TabParam" runat="server"></asp:TextBox>
															                </td>
                                                                      </tr>
                                                                      
                                                                      <tr>
															                 <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20"></TD>
															                 <td class="form1">Current Contract:<br />
															                  <asp:Label CssClass="form1" Font-Bold=true ID="lblCurrentContract" MaxLength="10" Width="100px"  ValidationGroup="TabParam" runat="server"></asp:Label>
															  			</td>
                                                                      </tr>
                                                                      <tr>
															                    <td  align="center" class="form1" colSpan="5">
																	                    <asp:button id="btnParameters" runat="server" ValidationGroup="TabParam" Text="Save Values" CssClass="button" 
                                                                                            onclick="btnsaveparameters_Click"></asp:button>
                       
															                    </td>
													                   </tr>
                                                                   </table>
                                                                </table>
						                                   </td>						   
						                                </tr>
						                                
                                                </table>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>  
                                        <!-- Parameters -->
 
									     <!-- Work Orders -->
									     <ajaxToolkit:TabPanel ID="tabestimate" runat="server" HeaderText="Work Orders">
                                        <ContentTemplate>
                                                    <table cellspacing="2" cellpadding="2" width="100%" height="400" bgcolor="WhiteSmoke">
                                                            <tr align="left" valign="top">
                                                                    <td>
                                                                            <SPAN class="header1">WORK</SPAN>
									                                        <SPAN class="header2">ORDERS</SPAN><br />
									                                        <button class="button" style="width:150px" id="btnWorkOrder" onclick="popupfunction('twc_project_workorder.aspx','Work Order');" type="button">Add Change Orders</button><asp:UpdatePanel runat="server" id="UpdatePanel">
														                <ContentTemplate>
																		<asp:datagrid id="grdpl1" runat="server" Width="50%" CssClass="#60829F" BackColor="#999999" ItemStyle-Wrap="False"
																			OnDeleteCommand="grdpl1_DeleteCommand" DataKeyField="work_order_id" OnCancelCommand="grdpl1_CancelCommand"
																			OnItemDataBound="grd1_ItemDataBound" OnUpdateCommand="grdpl1_UpdateCommand" OnEditCommand="grdpl1_EditCommand" FooterStyle-Font-Name="Verdana"
																			FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
																			FooterStyle-BackColor="#D9D9D9"  ShowFooter="True" AutoGenerateColumns="False"
																			SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
																			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
																			<Columns>
																				<asp:TemplateColumn SortExpression="seq_id" HeaderText="Number" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblseq" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.work_order_id")%>'>
																								        </asp:Label>
																					</ItemTemplate>
											    								</asp:TemplateColumn>
											    								
											    								 <asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True"
																					HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblLongDesc1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id="txtLongDesc1" runat="server" Width="250px" Height="75px"  MaxLength=50  Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																				        </asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn SortExpression="Material Cost" HeaderText="Material Cost" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblMatCost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.tot_mat_cost")%>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtMatCost" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tot_mat_cost") %>' >
																						 </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvMatCost" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtMatCost"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator id="revalMatCost" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtMatCost" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Fabrication Hours" HeaderText="Fabrication Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblfabhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.fab_hours")%>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtfabhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fab_hours") %>' >
                                                                                        
																						        </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvfabhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtfabhours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator id="revalfabhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtfabhours"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Finishing Horus" HeaderText="Finishing Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblfinhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.fin_hours")%>'>
																						
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtfinhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fin_hours") %>' >

																						        </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvfinhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtfinhours"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator id="revalfinhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtfinhours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Install hours" HeaderText="Install Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblinstallhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.install_hours")%>'>
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtinstallhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.install_hours") %>' >
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtinstallhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtinstallhours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Engineering Hours" HeaderText="Engineering Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblEnghours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.eng_hours")%>'>
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtEngHours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.eng_hours") %>' >
																						</asp:TextBox>
																						<asp:RequiredFieldValidator id="rfrEngHours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtEngHours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalEngHours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtEngHours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="misc_hours" HeaderText="Misc Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblMiscHours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.misc_hours")%>'>
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtMiscHours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.misc_hours") %>' >
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvMiscHours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtMiscHours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalMiscHours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtMiscHours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Notes" HeaderText="Notes" HeaderStyle-Font-Bold="True"
																					HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle BackColor="#EAEFF3" Wrap="true" Width="150" HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblnotes" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.notes")%>'>
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id="txtNotes" runat="server" Width="250px" Height="75px" TextMode="MultiLine" MaxLength=1000 Wrap=True Text='<%# DataBinder.Eval(Container, "DataItem.notes") %>'>
																						
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        
																						        </asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				
																				<asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
																							CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate><EditItemTemplate>
																						<asp:LinkButton id="lnkbutUpdate" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
																							CommandName="Update"></asp:LinkButton>
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
																	</TD>
																</TR>
                                                           
                                                    </table>
                                                </ContentTemplate>
        </ajaxToolkit:TabPanel>
         
        <!-- Change Order Log -->
        <ajaxToolkit:TabPanel ID="changes" runat="server" HeaderText="Change Order Log">
            <ContentTemplate>
                 <table align='center'  width="100%" height="400" bgcolor="WhiteSmoke">
                      <tr align="left" valign="top">
                           <td>
                              <SPAN class="header1">Change Order Log</SPAN><BR>
						       
						 </td>
						</tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>      
       
        <!-- Materials -->
        <ajaxToolkit:TabPanel ID="materials" runat="server" HeaderText="Materials">
            <ContentTemplate>
                 <table align='center'  width="100%" height="400" bgcolor="WhiteSmoke">
                      <tr align="left" valign="top">
                           <td>
                              <SPAN class="header1">Material Procurement Log</SPAN><BR>
						 
						 </td>
						</tr>
                </table>
            </ContentTemplate>
         </ajaxToolkit:TabPanel>
         
        <!-- Daily Field Report --> 
        <ajaxToolkit:TabPanel ID="TabPnlFieldReport" runat="server" HeaderText="Daily Field Report">
            <ContentTemplate>
                <table width="80%" bgcolor="WhiteSmoke" border="0" ><!--Daily Field Report Table Start-->
                    <tr>
                    <td >
                        <table bgcolor="WhiteSmoke" border="0" valign="top">
                            <tr>
                            <td>
                                <table width="100%" valign="top" bgcolor="WhiteSmoke" border="0" >
                                    <tr>
                                        <td vAlign="middle" align="right" class="form1">Project#:</td><td colspan="2">
                                        <asp:Label id="txtwhitPrjNumber" ValidationGroup="Tabreport" Width="75px"  runat="server"></asp:Label></td></tr><tr>
			                            <td vAlign="middle" align="right" class="form1">Report Date:</td><td colspan="2">
				                            <asp:TextBox ID="txtReportDate"  ValidationGroup="Tabreport"  runat="server" MaxLength="15" Width="125px"></asp:TextBox><asp:ImageButton runat="server"  ID="ImageButton1"  ImageUrl="assets/img/calendar.gif" AlternateText="Click here to display calendar" /> 
                                            <asp:button id="btnRptSearch" runat="server" onclick="btnSearch_Click" Visible="false" Text="Search" Width="50px" CssClass="button"></asp:button>
				                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy"  runat="server" TargetControlID="txtReportDate" PopupButtonID="ImageButton1" Enabled="True"/>                                                                                        
				                            <asp:RequiredFieldValidator ValidationGroup="Tabreport" ID="rrReportDate" ControlToValidate="txtReportDate" ErrorMessage="Report Date is Required."
                                            runat="server"></asp:RequiredFieldValidator></td></tr><tr>
						                <td class="form1" align="right" valign="middle">Management <br />Reviewed/Accepted:</td><td>
						               
	                                         <asp:RadioButtonList ID="chkActive" CssClass="form1"  ValidationGroup="Tabreport"  RepeatDirection="Horizontal" runat="server">
	                                         <asp:ListItem Text="Yes" Value="Y" ></asp:ListItem><asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem></asp:RadioButtonList></td><td valign="middle" align="center"><br>
						                    <asp:button id="btnWO" ValidationGroup="Tabreport" onclick="btnactivity_Click" runat="server" Text="Save Report" Width="100px" CssClass="button"></asp:button>
						                    &nbsp;&nbsp;<asp:Button ID="btnMail" runat="server" CssClass="button" OnClick="btnMail_Click" Text="Email Report"  Width="75px" />
					                    </td>	
                                    </tr>
                                 </table><!--Project # & Report Date-->
                            </td>
                            <td>
                                <table width="100%" bgcolor="WhiteSmoke" border="0" >
                                    <td valign="top">
                                        <table bgcolor="yellow">
 						                    <th colspan="2" valign="top" align="center" style="font-size: smaller">Installation Daily Hour Analysis</th><tr>
                                               <td align="right">Budget Hours</td><td align="center"><asp:Label ID="lblCummBudgetHours" runat="server" Width="20px"></asp:Label></td></tr><tr>
                                               <td align="right">Hours to Date</td><td align="center"><asp:Label ID="lblCummHoursTD" runat="server" Width="20px"></asp:Label></td></tr><tr>
                                               <td align="right">Difference</td><td align="center"><asp:Label ID="lblCummDiffTD" runat="server" Width="20px"></asp:Label></td></tr></table></td></table><!--Installation Daily Hour Analysis--></td></tr><tr>
					                    <td vAlign="top" class="form1" colspan="2">Daily Work Performed Notes/Comments:<br />
				                            <asp:textbox id="txtRptNotes" width="600px"  ValidationGroup="Tabreport" runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                            cols="80"></asp:textbox></td></tr><tr>
                                       <td vAlign="top" class="form1" colspan="2">Significant Issues/Impediments Notes/Comments:<br />
				                            <asp:textbox id="txtRptIssues" width="600px"  ValidationGroup="Tabreport"  runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" cols="80">

</asp:textbox>
		                               </td>
                                    </tr>
                                    <tr>
   			                            <td vAlign="top" class="form1" colspan="2">Change Order Work Notes/Comments:<br />
				                            <asp:textbox id="txtRptChangeOrderNotes" width="600px"  ValidationGroup="Tabreport"  runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                            cols="80"></asp:textbox></td></tr></table></td><td valign="top">
                         <table bgcolor="WhiteSmoke" border="0" >
                        <tr>
                            <td>
                            <table width="100%" border="0">
	                            <td vAlign="top" class="form1" colspan="4">
	                          <table>
						            <tr>
							            <td  valign="top"  width="100px">Select Worker<br />
								            <asp:DropDownList ID="ddlEmplType"  ValidationGroup="Tabreport" runat="server" Width="150px"></asp:DropDownList>
							            </td>
							            <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20">
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							</td>
							            <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20">
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							</td>
							            <td  valign="top" width="50px">Hours:<br />
								            <asp:textbox id="txtManHours"  ValidationGroup="Tabreport" runat="server" MaxLength="6" Width="50px"></asp:textbox></td><td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20">
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							
							</td>
							            <td valign="top" width="150px"><br>
								            <asp:button id="Button2" ValidationGroup="Tabreport" Visible=false onclick="btnmpdetails_Click" runat="server" Text="Save ManPower Detail" Width="150px" CssClass="button"></asp:button>
							            </td>
					        
						            </tr>
					            </table>
				            </td>	
				            </table>
				            </td>
				        </tr>
				        <tr>
				            <td>
				            <table>
				            
                                <td vAlign="top" class="form1"><button class="button" style="width:150px" id="btnWorkerMaintenance" onclick="popupwithwidthheight('worker_maintenance.aspx','Worker Maintenance');" type="button">Add Worker</button><br />Manpower Detail:<br />								                                               																	
			                    <asp:UpdatePanel runat="server" id="UpdatePanel1">
				                    <ContentTemplate>
					                    <asp:datagrid id="grdManPower" runat="server" Width="100%" CssClass="data" BackColor="#999999" 
					                    ItemStyle-Wrap="False" HorizontalAlign="Center"
					                    OnDeleteCommand="grdManPower_DeleteCommand" DataKeyField="manhour_id" 
					                    OnCancelCommand="grdManPower_CancelCommand"
					                    OnItemDataBound="grdManPower_ItemDataBound" OnUpdateCommand="grdManPower_UpdateCommand" 
					                    OnEditCommand="grdManPower_EditCommand" FooterStyle-Font-Name="Verdana"
					                    FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
					                    FooterStyle-BackColor="#D9D9D9"  ShowFooter="True" AutoGenerateColumns="False"
					                    SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
					                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
						                    <Columns> 
							                    <asp:TemplateColumn SortExpression="Level" HeaderText="Worker Name" HeaderStyle-Font-Bold="True"
							                    HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblEmplType" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.WorkerName")%>'>
							
							</asp:Label>
							                    </ItemTemplate>
							                    </asp:TemplateColumn> 
                            																				                            
        					                    <asp:TemplateColumn SortExpression="Install_hours" HeaderText="Hours" HeaderStyle-Font-Bold="True">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblinstallhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.install_hours")%>'>
							
							</asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" MaxLength="6" id="txtinstallhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.install_hours") %>' >
							
							</asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please enter total hours"
							                    ControlToValidate="txtinstallhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
							                    ControlToValidate="txtinstallhours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn  Visible=false SortExpression="TotHours" HeaderText="Total Hours" HeaderStyle-Font-Bold="True"
							                    HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblTotHours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TotHours")%>'>
							
							</asp:Label>
							                    </ItemTemplate>
							                    </asp:TemplateColumn>
                    																					                                  
							                    <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
							                    CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate><EditItemTemplate>
							                    <asp:LinkButton id="lnkbutUpdate" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
							                    CommandName="Update"></asp:LinkButton>
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
                            </td><!-- ManPower DataGrid Ends Here -->
				            </table>
				            </td>
				        </tr>
				        <tr>
				            <td>
				            <asp:UpdatePanel runat="server" id="UpdatePanelWO">
							<ContentTemplate>
				            <table bgcolor="aqua">
				                <td colspan="4">
	                                <table border="0">Daily Workorder Details
					                    <tr>
					                        <tr>
						                        <td  colspan="2" valign="top">
							                        <asp:DropDownList ID="ddlworkorders"  ValidationGroup="Tabreport" runat="server" AutoPostBack="True" 
                                                            OnSelectedIndexChanged="ddlworkorders_SelectedIndexChanged" Width="250px"></asp:DropDownList>
						                        </td>

					                        </tr>
					                        <tr>
					                            <td align="right">Budget Hours</td><td align="center"> <asp:Label ID="lblinstbud" runat="server" Width="20px"></asp:Label></td></tr><tr>
					                            <td align="right">Hours to Date</td><td align="center"><asp:Label ID="lblInstbudTD" runat="server" Width="20px"></asp:Label></td></tr><tr>
					                        <td align="right">Hours Today</td><td align="center">
						                        <asp:textbox id="txtHours" HorizonatalAlign="center" ValidationGroup="Tabreport" runat="server" MaxLength="6" Width="50px"></asp:textbox></td></tr><tr>
					                            <td align="right">Difference</td><td align="center"><asp:Label ID="lblInstdiffbud" runat="server" Width="20px"></asp:Label></td></tr></tr></table></td><td>
			                        <table>Comments Specific to this Work Order:
					                            <tr>
						                            <td  valign="top" width="100px">
							                            <asp:TextBox id="txtActComments" ValidationGroup="Tabreport" runat="server" Width="250px" Height="100px" TextMode="MultiLine" MaxLength=500 Wrap=True>
							
							</asp:TextBox>
						                            </td>
					                            </tr>  
				                    </table>
			                    </td>	
				            </table>
				            </ContentTemplate>
				            </asp:UpdatePanel>
				            </td>
				        </tr>
				        <tr> 
				            <td>
				            <table>
				            <td rowspan="2", valign="top" >								                                               																	
				<asp:UpdatePanel runat="server" id="UpdatePanel2">
			<ContentTemplate>
				<asp:datagrid id="grdActivity" runat="server" Width="100%" CssClass="data" BackColor="#999999" 
				ItemStyle-Wrap="False"
				OnDeleteCommand="grdActivity_DeleteCommand" DataKeyField="activity_id" 
				OnCancelCommand="grdActivity_CancelCommand"
				 PageSize = "100" OnItemDataBound="grdActivity_ItemDataBound" OnUpdateCommand="grdActivity_UpdateCommand" 
				OnEditCommand="grdActivity_EditCommand" FooterStyle-Font-Name="Verdana"
				FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
				FooterStyle-BackColor="#D9D9D9"  ShowFooter="True" AutoGenerateColumns="False"
				SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
				<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					<Columns>       																			                                  
					 	<asp:TemplateColumn SortExpression="Description" HeaderText="Work Orders Executed" HeaderStyle-Font-Bold="True"
						HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
						<asp:Label id="lblLongDesc1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.WODesc")%>'>
						</asp:Label></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="Install_hours" HeaderText="Install Hours" HeaderStyle-Font-Bold="True">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
						<ItemTemplate>
						<asp:Label id="lblinstallhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.install_hours")%>'>
						</asp:Label></ItemTemplate><EditItemTemplate>
						<asp:TextBox Width="30" id="txtinstallhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.install_hours") %>' >
						</asp:TextBox><asp:RequiredFieldValidator id="rfvinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
						ControlToValidate="txtinstallhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
						ControlToValidate="txtinstallhours" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="empl_comments" HeaderText="Comments" HeaderStyle-Font-Bold="True"
						HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3" Wrap="true" Width="150" HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
						<asp:Label id="lblnotes" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.empl_comments")%>'>
						</asp:Label></ItemTemplate><EditItemTemplate>
						<asp:TextBox id="txtNotes" runat="server" Width="250px" Height="75px" TextMode="MultiLine" MaxLength='500' Wrap=True Text='<%# DataBinder.Eval(Container, "DataItem.empl_comments") %>'>
						</asp:TextBox></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
						<ItemTemplate>
						<asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
						CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate><EditItemTemplate>
						<asp:LinkButton id="lnkbutUpdate" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
						CommandName="Update"></asp:LinkButton>
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
			</td><!-- Report DataGrid Ends Here -->   
				            </table>
				            </td>
				        </tr>
				        </tr>		                   
                        </table>
                    </td>
                    </tr>
                </table>     
			<table align='center'>
				<tr>

				</tr>
			</table>									                     
		</ContentTemplate>
	    </ajaxToolkit:TabPanel>
		
		<!-- Daily Report Log -->
									                    
        <ajaxToolkit:TabPanel ID="dr_log" runat="server" HeaderText="Daily Report Log">
            <ContentTemplate>
                      Daily Field Report Log<br />
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
		                    <ContentTemplate>
                                <asp:datagrid id="grdHistoryRpt" runat="server" CssClass="data" Width="50%"
                                    AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                                    OnPageIndexChanged="PageResultGridHistory"  OnItemDataBound="grdHistoryRpt_ItemDataBound" FooterStyle-Font-Name="Verdana"
                                     PageSize="25" FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
                                    FooterStyle-BackColor="#D9D9D9"  ShowFooter="True"  
                                CellPadding="3">
                                <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                                <Columns>
                                    
                                            <asp:TemplateColumn HeaderText="Report Date">
                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
                                            <ItemTemplate>
                                                <%#showHistoryReport(((DataRowView)Container.DataItem)["rpt_date"])%></ItemTemplate></asp:TemplateColumn><asp:BoundColumn DataField="install_hours" SortExpression="install_hours" HeaderText="Install. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                            </Columns><PagerStyle Mode="NumericPages"></PagerStyle>
                               </asp:datagrid>
                               </ContentTemplate>
                                </asp:UpdatePanel>
               </ContentTemplate>
         </ajaxToolkit:TabPanel>
         
        <!-- Production Scheduling -->
        <ajaxToolkit:TabPanel ID="wo_schedule" runat="server" HeaderText="Production Scheduling">
            <ContentTemplate>
               <table align="center"  width="100%" bgcolor="WhiteSmoke">
                    <tr align="left" valign="top">
                        <td>
                            <asp:Panel ID="pnlButtonSchedule" runat="server">
                                <asp:button id="btnProdSchedule" runat="server" ValidationGroup="TabGroup1" 
                                Text="Setup Schedule" CssClass="button" onclick="btnProdSchedule_Click">
                                </asp:button>
                            </asp:Panel>
                            <SPAN class="header1">Total Project Shop Hours:<asp:Label ID="lblTotAnnFabHours" runat="server"></asp:Label></SPAN>
                            <SPAN class="header2">Total Scheduled Hours:<asp:Label ID="lblTotScheduledHours" runat="server"></asp:Label></SPAN>
						</td>
					</tr>
                </table>
                      <br />
                      <asp:Panel ID="pnlActSchedule"  Visible=False runat="server">
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
		              <ContentTemplate>
		               <table align="left"  width="100%" bgcolor="WhiteSmoke">
                            <tr align="left" valign="top">
                                    <!--fycd,yearmonth,week_number,sequence,Hours,weeklyNotes-->
                                     <td class="form1" width="5%">Year:<br />
								        <asp:dropdownlist id="ddlYear" 
                                            ValidationGroup="tabProdSch" runat="server"  AutoPostBack="true"
                                            onselectedindexchanged="ddlYear_SelectedIndexChanged"></asp:dropdownlist>
                                         <br />
                                         <asp:RequiredFieldValidator ID="rryear" 
                                               ControlToValidate="ddlYear" ValidationGroup="tabProdSch" InitialValue="0" ErrorMessage="Year is Required" 
                                               runat="server">
                                        </asp:RequiredFieldValidator>
							        </td>
							        
							        <td class="form1" width="5%">Month:<br />
								        <asp:dropdownlist id="ddlMonth" AutoPostBack="true"
                                            ValidationGroup="tabProdSch" runat="server" 
                                            onselectedindexchanged="ddlMonth_SelectedIndexChanged"></asp:dropdownlist>
                                            <br />
                                         <asp:RequiredFieldValidator ID="rrMonth" 
                                               ControlToValidate="ddlMonth" ValidationGroup="tabProdSch" InitialValue="0" ErrorMessage="Month is Required" 
                                               runat="server">
 
                                            </asp:RequiredFieldValidator>
							        </td>
							        
							        <td class="form1" width="5%">Week:<br />
								        <asp:dropdownlist id="ddlWeek" AutoPostBack="true"
                                            ValidationGroup="tabProdSch" runat="server" 
                                            onselectedindexchanged="ddlWeek_SelectedIndexChanged"></asp:dropdownlist>
                                            <br />
                                         <asp:RequiredFieldValidator ID="rrWeek" 
                                               ControlToValidate="ddlWeek" ValidationGroup="tabProdSch" InitialValue="0" ErrorMessage="Week is Required" 
                                               runat="server"> </asp:RequiredFieldValidator>
							        </td>
							        
							        <td class="form1" width="5%">Hours:<br />
							        <asp:TextBox Width="70" id="txtSchhours" runat="server" Text="0" ></asp:TextBox></td>
							        
								        
							         <td rowspan="2" width="80%">
                                    <DIV style="text-align:left; OVERFLOW-Y:scroll; WIDTH:625px; HEIGHT:125px;" >
                                            <asp:datagrid ID="grdWeeklyNotes" runat="server" CssClass="data" Width="600px"
                                            AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                                            OnItemCreated="ResultGridItemCreated" OnPageIndexChanged="PageResultGridHistory" FooterStyle-Font-Name="Verdana"
                                            PageSize="100" FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" 
                                            FooterStyle-ForeColor="#ffff99"
                                            FooterStyle-BackColor="#D9D9D9"  ShowFooter="True"  
                                            CellPadding="3">
                                            <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                                                <Columns>                                    
                                                   <asp:BoundColumn DataField="week_number"  ItemStyle-HorizontalAlign="Center" SortExpression="week_number" HeaderText="Week">
                                                    <HeaderStyle HorizontalAlign="center" Width="50px" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                    <ItemStyle BackColor="#EAEFF3" Width="50px" HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                            
                                                 <asp:BoundColumn DataField="yearmonth"  ItemStyle-HorizontalAlign="center" SortExpression="yearmonth" HeaderText="Month(Year)">
                                                    <HeaderStyle HorizontalAlign="center" Width="100px" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                    <ItemStyle BackColor="#EAEFF3" Width="100px" HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                            
                                                 <asp:BoundColumn DataField="weeklyNotes" ItemStyle-Wrap="true"  ItemStyle-HorizontalAlign="Left" SortExpression="weeklyNotes" HeaderText="Weekly Plan Summary">
                                                    <HeaderStyle HorizontalAlign="Left" Width="500px" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                    <ItemStyle BackColor="#EAEFF3" Width="500px" Wrap="true" HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundColumn>                                            
                                            </Columns>                                            
                                            <PagerStyle Mode="NumericPages"></PagerStyle>
                                        </asp:datagrid>
                                       </DIV>
                                    </td>
							        
							        </tr>
							        
							        <tr>
							        <td  colspan=4 valign="top" width="100px">Weekly Production Plan Summary:<br />
							             <asp:TextBox id="txtWeeklyComments" 
                                              ValidationGroup="tabProdSch" runat="server" Width="300px" Height="25px" 
                                              TextMode="MultiLine" MaxLength=500 Wrap=True></asp:TextBox>
                                    </td>
                                    
                                    <td>
                                        <asp:button id="btnSaveHours" width="80px" 
                                        runat="server" 
                                        ValidationGroup="tabProdSch" 
                                        Text="Save Hours" 
                                        CssClass="button" 
                                        onclick="btnSaveHours_Click"></asp:button><br />
                                        <asp:Label ID="lblSchError" runat="server" CssClass="error1"></asp:Label>
                                    </td>
                                   
                                    
                                    </tr>
                                    <tr>
                                        <td colspan="6">Production Plan Hourly Summary Table:</td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="6">
                                        <DIV style="OVERFLOW-Y:scroll; WIDTH:100%; HEIGHT:200px;" >
                                             <asp:datagrid id="grdSchedule"                                               
                                                         runat="server" 
                                                         CssClass="data" 
                                                         OnPageIndexChanged="PageResultGridNotes" 
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
                                                         ShowFooter="True"  
                                                         CellPadding="3">
                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                                                   <PagerStyle Mode="NumericPages"></PagerStyle>
                                                   </asp:datagrid>
                                        </DIV>
                                        </td>
                                    </tr>
                                    
                                    </table>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
            </ContentTemplate>
         </ajaxToolkit:TabPanel>
         
                <!-- Financials -->
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Financials">
            <ContentTemplate>
                 <table align='center'  width="100%" height="400" bgcolor="WhiteSmoke">
                      <tr align="left" valign="top">
                           <td>
                                <table><SPAN class="header1">Schedule of Values</SPAN><BR>























</table>
						   </td>
						   <td>
                                <table><SPAN class="header1">Payment Applications</SPAN><BR>























</table>
						   </td>
						   <td>
                                <table><SPAN class="header1">Miscellaneous</SPAN><BR>























</table>
						   </td>
						</tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>     

        <!-- Project Documents -->                      
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Project Documents">
            <ContentTemplate>
                                                    <table align='center'  width="100%" height="400" bgcolor="WhiteSmoke">
                                                        <tr align="left" valign="top">
                                                            <td>
                                                                    <SPAN class="header1">Project Documents</SPAN><BR>
									 
									
									  
									
									
									  
									
									  
									
									
									
									  
									
									  
									
									
									  
									
									  
									
									
									
									
									 </td>
									                    </tr>
									                    <tr>
	                                                            <td class="form1" style="color: Maroon">Document Type:<br/>	                                                           
		                                                            <asp:dropdownlist id="ddlDocType" ValidationGroup="TabGroup7" runat="server"></asp:dropdownlist>
		                                                            <asp:RequiredFieldValidator ID="resubject" ControlToValidate="ddlDocType" InitialValue="" ForeColor="White" Font-Bold="true" Display="Static" runat="server">*Document type is required</asp:RequiredFieldValidator></td></tr><tr>
	                                                                <td class="form1" style="color: Maroon">Download document:<br/>
                                                                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                                                                        <asp:RequiredFieldValidator ID="reqmessage" ValidationGroup="TabGroup7"   ControlToValidate="FileUpload1" ForeColor="Maroon" Font-Bold="true" Display="Static" runat="server">*document is required.</asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                                                             id="regfileupload" runat="server"  ValidationGroup="TabGroup7" ForeColor="Maroon" Font-Bold="true" Display="Static"
                                                                             ErrorMessage="Only doc, docx or pdf,excel, gif or jpg files are allowed!" 
                                                                             ValidationExpression="[a-zA-Z\\].*(.doc|.DOC|.docx|.DOCX|.pdf|.PDF|.jpg|.gif|.xls|.xlsx|.XLSX)$" 
                                                                             ControlToValidate="FileUpload1"></asp:RegularExpressionValidator></td></tr><tr>
															    <td>
																	    <asp:button id="Button5" runat="server" ValidationGroup="TabGroup7" Text="Upload Document" CssClass="button" 
                                                                            onclick="btnupload_Click"></asp:button>
															    </td>
														</tr>
														<tr>
														     <td>
                                                                    Project Documents:<br />
                                                                    <asp:datagrid id="grddocs" runat="server" CssClass="data" Width="50%" OnItemCreated="ResultGridItemCreated"
								                                    OnPageIndexChanged="PageResultGriddocs" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
								                                    CellPadding="3">
								                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
								                                    <Columns>
									                                    <asp:BoundColumn DataField="doc_Type_Desc" SortExpression="doc_Type_Desc" HeaderText="Document Type" HeaderStyle-Font-Bold="true">
										                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3"></ItemStyle>
									                                    </asp:BoundColumn>
									                                     
                                                                   
                                                                        <asp:TemplateColumn HeaderText="View Document">
	                                                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
	                                                                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
	                                                                        <ItemTemplate>
		                                                                        <%# Showdocument(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["seq_num"],((DataRowView)Container.DataItem)["doc_name"])%></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="Delete">
	                                                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
	                                                                        <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
	                                                                        <ItemTemplate>
		                                                                        <%# DeleteDocument(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["seq_num"])%></ItemTemplate></asp:TemplateColumn></Columns><PagerStyle Mode="NumericPages"></PagerStyle>
												                   </asp:datagrid>
									                        </td>
														</tr>
                                                    </table>
                                                </ContentTemplate>
        </ajaxToolkit:TabPanel>
         
    </ajaxToolkit:TabContainer>
    </td>
    
  </tr>
</table>    


<table align='center'>
  <tr>
    <td align="center">
    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label></td></tr></table><script type="text/javascript" language="javascript">
                var theForm = document.forms[0];
                window.name = 'IEAdvanceQueue';
                var agreewin = "";
                function popupfunction(url,Msg) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    var parameters = "?EstNum=" + myTextField.value + "&twcProjNumber=" + myTextField1.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, Msg, "width=650px,height=550px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                function popupwithwidthheight(url,heading) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    var parameters = "?EstNum=" + myTextField.value + "&twcProjNumber=" + myTextField1.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, heading, "width=700px,height=500px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                function popupprocess(url,id) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    var parameters = "?id=" + id + "&EstNum=" + myTextField.value + "&twcProjNumber=" + myTextField1.value; 
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Maintenance", "width=550px,height=400px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                function showdocument(EstNum, seqNumber) {
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    window.open('twc_view_document.aspx?EstNum=' + EstNum + "&twcProjNumber=" + myTextField1.value + "&seqno=" + seqNumber, 'form', 'width=470,height=452,left=10,top=163,location=no, menubar=no,status=no,toolbar=no,scrollbars=no,resizable=yes');
                }
                
                function Deletedocument(EstNum, seqNumber) {
                    var pageName = "whitfield_projectInfo.aspx";
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    var parameters = "?EstNum=" + EstNum + "&twcProjNumber=" + myTextField1.value + "&seqno=" + seqNumber + "&hFlag=D";
                    var result = null;
                    if (confirm("Are you sure want to delete this document?")) {
                        url = pageName + parameters
                        location.href = url;
                        return;
                    }
                }
                function showHistoryReport(ReportDate) {
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                    location.href = 'whitfield_projectInfo.aspx?ReportDate=' + ReportDate + "&twcProjNumber=" + myTextField1.value + "&EstNum=" + myTextField.value; 
                }
            </script></div></asp:Content>