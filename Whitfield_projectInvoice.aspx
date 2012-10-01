<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="Whitfield_projectInvoice.aspx.cs" Inherits="Whitfield_projectInvoice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />

            <table cellpadding="2" cellspacing="2" width="100%" bgcolor="white">
                <tr>
                  <td align="left">
                        <SPAN class="header2"> <asp:Label ID="lblPrjHeader" ForeColor="OrangeRed" runat="server"></asp:Label></SPAN><br />
                        <ajaxToolkit:TabContainer ID="tabgeneral" runat="server" Width="100%" 
                            CssClass="fancy" ActiveTabIndex="0">
                        
                            <ajaxToolkit:TabPanel ID="tabGenInfo" runat="server" HeaderText="Payment Applications">
                                <HeaderTemplate>
                                    Payment Applications
                                </HeaderTemplate>
                                <ContentTemplate>
                                 <table>
                                   <tr>
                                   		<td class="form1">Client:<br />
											 <asp:dropdownlist id="ddlwonclient" ValidationGroup="TabParam" runat="server"></asp:dropdownlist>
										</td>
										
										 <td class="form1">Current Contract:<br />
										    <asp:Label CssClass="form1" Font-Bold=True ID="lblCurrentContract" 
                                                 MaxLength="10" Width="100px"  ValidationGroup="TabParam" runat="server"></asp:Label>
											 
										</td>
										
                                        <td class="form1">Original Contract Value:<br />
											<asp:TextBox ID="txtOrigContract" MaxLength="10" Width="100px" Font-Bold=True  
                                                Enabled="False"  ValidationGroup="TabParam" runat="server"></asp:TextBox>
										</td>
										
										<td class="form1">Change Order Value:<br />
											 <asp:TextBox ID="txtChangeOrder" MaxLength="10" Width="100px" Font-Bold=True 
                                                Enabled="False"  ValidationGroup="TabParam" runat="server"></asp:TextBox>
											  <asp:HiddenField ID="hdnEstNum" runat="server" />
											  <asp:HiddenField ID="hdntwcProjNumber" runat="server" />
										</td>
                                   </tr>
                                   <tr>
                                   <td class="form1">Initial Payment date:<br />
					                    <asp:TextBox ID="txtInitialPaymentDate" ValidationGroup="TabParam" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                    <asp:ImageButton runat="server"  ID="ImgBidDate"
					                    ImageUrl="assets/img/calendar.gif"  ValidationGroup="TabParam"
                                        AlternateText="Click here to display calendar" />
                                        <ajaxToolkit:CalendarExtender ID="CalBidDate" runat="server" 
                                        Format="MM/dd/yyyy" TargetControlID="txtInitialPaymentDate"  
                                        PopupButtonID="ImgBidDate" Enabled="True"/>
                                   </td>
                                   <td class="form1">Final Payment date:<br />
					                    <asp:TextBox ID="txtFinalPaymentDate" ValidationGroup="TabParam" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                    <asp:ImageButton runat="server"  ID="ImageButton1"
					                    ImageUrl="assets/img/calendar.gif"  ValidationGroup="TabParam"
                                        AlternateText="Click here to display calendar" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Format="MM/dd/yyyy" TargetControlID="txtFinalPaymentDate"  
                                        PopupButtonID="ImageButton1" Enabled="True"/>
                                   </td>
                                   <td class="form1">Payment Point Of Contact:<br />
											 <asp:dropdownlist id="ddlContacts" ValidationGroup="TabParam" 
                                           runat="server" Height="18px" Width="211px"></asp:dropdownlist>
									</td>
                                   </tr> 
                                   <tr>
                                        <td><asp:button  ValidationGroup="TabParam" id="btnnew" runat="server" Text="Save" CssClass="button" onclick="btnnew_Click" />
                                       &nbsp;&nbsp;
                                        <asp:button id="btnProdSchedule" 
                                                    runat="server" 
                                                    ValidationGroup="TabGroup1" 
                                                    Text="Setup CashFlow Schedule" 
                                                    CssClass="button" 
                                                    onclick="btnProdSchedule_Click" 
                                                    ToolTip="This function will setup new or update existing cashflow table" />
                                                    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=True 
                                                    Font-Size=Medium></asp:Label>
                                             </td>
                                    </tr>                                  
        	                     </table>
        	                     <table>
        	                     <tr>
        	                     
        	                     <td vAlign="top" class="form1">Invoice:<br />
				                    <button class="button" style="width:150px" id="Button2" onclick="popupfunction('AddInvoice.aspx','ADD Invoice','550','500');" type="button">Add Invoice</button>
                    				<br />
                    				        <asp:UpdatePanel runat="server" id="updgrdpl1">
											<ContentTemplate>
                    						<asp:datagrid id="grdpl1" 
				                            runat="server"  
				                            BorderStyle="Solid" 
				                            Width="100%" 
				                             ShowFooter="true"
				                            CssClass="data" 
				                            BackColor="WhiteSmoke"
			                                DataKeyField="invoice_number" 
			                                OnItemCreated="ResultGridItemCreated"
			                                OnPageIndexChanged="PageResultGrid"
			                                OnCancelCommand="grdpl1_CancelCommand"
			                                OnDeleteCommand="grdpl1_DeleteCommand"
			                                OnUpdateCommand="grdpl1_UpdateCommand" 
			                                OnEditCommand="grdpl1_EditCommand"  
			                                OnItemDataBound="grdpl1_ItemDataBound"
			                                AutoGenerateColumns="False"
			                                Font-Size="Smaller" 
			                                CellPadding="3">
				                            <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                              <Columns>
					                                      <asp:TemplateColumn HeaderText="EDIT">
				                                            <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                  Font-Bold="True"></HeaderStyle>
				                                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutEdit"  runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
						                                            CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate>
				                                                <EditItemTemplate>
					                                            <asp:LinkButton id="lnkbutUpdate" ValidationGroup="editmode" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
						                                            CommandName="Update"></asp:LinkButton>&nbsp;
					                                            <asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
						                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
					                                            </EditItemTemplate>
			                                                </asp:TemplateColumn>
                        		                              
                        		                              <asp:TemplateColumn SortExpression="invoice_number" HeaderText="Number" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblinvoice_number0" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.invoice_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:Label id="lblinvoice_number1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.invoice_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </EditItemTemplate> 
				                                            </asp:TemplateColumn>
				              
						                                    
						                            
						                                    <asp:TemplateColumn SortExpression="Date_Submited" HeaderText="Date Submited" ItemStyle-Width="75px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDate_Submited" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Date_Submited")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="50" id="txtDate_Submited" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Date_Submited") %>' >
					                                                         </asp:TextBox>
					                                                        <asp:ImageButton runat="server"  ID="ImgDate_Submited"
					                                                        ImageUrl="assets/img/calendar.gif"  
                                                                            AlternateText="Click here to display calendar" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalDate_Submited" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtDate_Submited"  
                                                                            PopupButtonID="ImgDate_Submited" Enabled="True"/>
					                                                        <asp:RequiredFieldValidator id="rfvDate_Submited" runat="server" Display="Dynamic" ErrorMessage="Please Date_Submited"
						                                                        ControlToValidate="txtDate_Submited"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                             </asp:TemplateColumn>
				                                             
				                                              <asp:TemplateColumn SortExpression="Date_Received" 
                                                              HeaderText="Date Received" ItemStyle-Width="75px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                      Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDate_Received" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Date_Received")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="50" id="txtDate_Received" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Date_Received") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:ImageButton runat="server"  ID="ImgDate_Received"
					                                                        ImageUrl="assets/img/calendar.gif"  
                                                                            AlternateText="Click here to display calendar" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalDate_Received" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtDate_Received"  
                                                                            PopupButtonID="ImgDate_Received" Enabled="True"/>
					                                                        <asp:RequiredFieldValidator id="rfvDate_Received" 
					                                                        runat="server" 
					                                                        Display="Dynamic" 
					                                                        ErrorMessage="Please Date_Received"
						                                                    ControlToValidate="txtDate_Received">
						                                                    </asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                             </asp:TemplateColumn>
				                                             
				                                             
				                                              <asp:TemplateColumn SortExpression="Date_Approved" 
                                                              HeaderText="Date Approved" ItemStyle-Width="75px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                      Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDate_Approved" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Date_Approved")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="50" id="txtDate_Approved"  ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Date_Approved") %>' >
					                                                         </asp:TextBox>
					                                                        <asp:ImageButton runat="server"  ID="ImgDate_Approved"
					                                                        ImageUrl="assets/img/calendar.gif"  
                                                                            AlternateText="Click here to display calendar" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalDate_Approved" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtDate_Approved"  
                                                                            PopupButtonID="ImgDate_Approved" Enabled="True"/>
					                                                        <asp:RequiredFieldValidator id="rfvDate_Approved" runat="server" Display="Dynamic" ErrorMessage="Please Date_Approved"
						                                                        ControlToValidate="txtDate_Approved"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                             </asp:TemplateColumn>
				                                             
				                                             <asp:TemplateColumn SortExpression="fab_lab_Cost" HeaderText="Fab Lab Cost" ItemStyle-Width="55px">
				                                                    <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                        Font-Bold="True"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblfab_lab_Cost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.fab_lab_Cost")%>'>
					                                                            </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                                <asp:TextBox Width="55" id="txtfab_lab_Cost" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.fab_lab_Cost") %>' >
					                                                            </asp:TextBox>
					                                                            <asp:RequiredFieldValidator id="rfvfab_lab_Cost" runat="server" Display="Dynamic" ErrorMessage="Please enter a fab_lab_Cost"
						                                                            ControlToValidate="txtfab_lab_Cost"></asp:RequiredFieldValidator>
				                                                    </EditItemTemplate> 
				                                            </asp:TemplateColumn>
				
				                                        <asp:TemplateColumn SortExpression="Ins_lab_Cost" HeaderText="Inst Lab Cost" ItemStyle-Width="55px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblIns_lab_Cost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Ins_lab_Cost")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="55" id="txtIns_lab_Cost" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Ins_lab_Cost") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvIns_lab_Cost" runat="server" Display="Dynamic" ErrorMessage="Please enter a Ins_lab_Cost"
						                                                        ControlToValidate="txtIns_lab_Cost"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				
				                                        <asp:TemplateColumn SortExpression="Material_cost" HeaderText="Material Cost" ItemStyle-Width="55px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                     Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblMaterial_cost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Material_cost")%>'>
					                                                         </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="55" id="txtMaterial_cost" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Material_cost") %>' >
					                                                         </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvMaterial_cost" runat="server" Display="Dynamic" ErrorMessage="Please enter a Material_cost"
						                                                     ControlToValidate="txtMaterial_cost"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				
					                               
						                                <asp:TemplateColumn SortExpression="Overhead_Costs" HeaderText="Overhead Cost" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblOverhead_Cost0" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Overhead_Costs")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:Label id="lblOverhead_Cost1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Overhead_Costs")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </EditItemTemplate> 
				                                         </asp:TemplateColumn>
				                                            
				                                            
				                                        <asp:TemplateColumn SortExpression="Base_contract" HeaderText="Base Contract" ItemStyle-Width="55px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblBase_contract" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Base_contract")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="75" id="txtBase_contract" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Base_contract") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvBase_contract" runat="server" Display="Dynamic" ErrorMessage="Please enter a Base_contract"
						                                                        ControlToValidate="txtBase_contract"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				
				                                        <asp:TemplateColumn SortExpression="Change_order" HeaderText="Change Order" ItemStyle-Width="55px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblChange_order" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Change_order")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="75" id="txtChange_order" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Change_order") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvChange_order" runat="server" Display="Dynamic" ErrorMessage="Please enter a Change_order"
						                                                        ControlToValidate="txtChange_order"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				                                        
									                                
						                                <asp:TemplateColumn SortExpression="Total_inv_Amount" HeaderText="Total Invoice Amt" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="right" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblTotal_inv_Amount0" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Total_inv_Amount")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:Label id="lblTotal_inv_Amount1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Total_inv_Amount")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </EditItemTemplate> 
				                                         </asp:TemplateColumn>
				                                             
						                                    
				                                        <asp:TemplateColumn SortExpression="Invoice Comments" 
                                                              HeaderText="Invoice_comments" ItemStyle-Width="55px">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblInvoice_comments" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Invoice_comments")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="150" id="txtInvoice_comments" ValidationGroup="editmode" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Text='<%# DataBinder.Eval(Container, "DataItem.Invoice_comments") %>' >
					                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvInvoice_comments" runat="server" Display="Dynamic" ErrorMessage="Please enter a Comments"
						                                                        ControlToValidate="txtInvoice_comments"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				                                        
				                                        <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
				                                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                            <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutDelete" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
						                                            CommandName="DELETE" CausesValidation="false">
				                                                </asp:LinkButton>
				                                             </ItemTemplate>
		                                                </asp:TemplateColumn>
				
						                         </Columns>
						                         <EditItemStyle BackColor="#FFFF66" />
                                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                                <ItemStyle Wrap="False" />
						                         <PagerStyle Mode="NumericPages"></PagerStyle>
				                             </asp:datagrid>
				                             </ContentTemplate>
				                             </asp:UpdatePanel>
				                             				 
				                   </td>
        	                     </tr>
        	                     </table> 
        	                     <br /><br />                               
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        
                        
                         <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="1" HeaderText="Schedule of Values">
                         <ContentTemplate>
                         <table>
                            <tr>
                              <!-- Original SOV  -->
                              <td valign="top">
                                <button class="button" style="width:150px" id="btnSOV" onclick="popupfunction('AddSOV.aspx','ADD SOV','550','500');" type="button">Add SOV</button><br />
                                   			<asp:UpdatePanel ID="updSOV" runat="server" >
                                   			<ContentTemplate>
                                   			
                                   			<asp:datagrid id="grdSOV" 
				                            runat="server"  
				                            BorderStyle="Solid" 
				                            Width="100%" 
				                            CssClass="data" 
				                            BackColor="WhiteSmoke"
			                                DataKeyField="seq_number" 
			                                OnItemCreated="ResultGridItemCreated"
			                                OnPageIndexChanged="PageResultGridSOV"
			                                OnCancelCommand="grdSOV_CancelCommand"
			                                OnUpdateCommand="grdSOV_UpdateCommand" 
			                                OnEditCommand="grdSOV_EditCommand" 
			                                OnDeleteCommand="grdSOV_DeleteCommand"
			                                OnItemDataBound="grdSOV_ItemDataBound"
			                                AutoGenerateColumns="False"
			                                 ShowFooter="true"
			                                Font-Size="Smaller" 
			                                CellPadding="3">
				                            <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                              <Columns>
					                                      <asp:TemplateColumn HeaderText="EDIT">
				                                            <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                  Font-Bold="True"></HeaderStyle>
				                                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutEdit"  runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
						                                            CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate>
				                                                <EditItemTemplate>
					                                            <asp:LinkButton id="lnkbutUpdate" ValidationGroup="editmode" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
						                                            CommandName="Update"></asp:LinkButton>&nbsp;
					                                            <asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
						                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
					                                            </EditItemTemplate>
			                                                </asp:TemplateColumn>
                        		                             
                        		                             <asp:TemplateColumn SortExpression="seq_number" HeaderText="Number" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblseq_number0" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.seq_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:Label id="lblseq_number1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.seq_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </EditItemTemplate> 
				                                         </asp:TemplateColumn>
				                                                        

						                                    					                            
				                                            <asp:TemplateColumn SortExpression="Description" 
                                                              HeaderText="Description">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="200" id="txtDescription" ValidationGroup="editmode1" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvDescription" runat="server" Display="Dynamic" ErrorMessage="Please enter a Description"
						                                                        ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				
				                                        <asp:TemplateColumn SortExpression="sov_amount" HeaderText="S.O.V. Amount">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="right"  BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblsov_amount" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.sov_amount")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="200" id="txtsov_amount" ValidationGroup="editmode1" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.sov_amount") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvsov_amount" runat="server" Display="Dynamic" ErrorMessage="Please enter a sov_amount"
						                                                        ControlToValidate="txtsov_amount"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				                                        
				                                        <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
				                                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                            <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutDelete1" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
						                                            CommandName="DELETE" CausesValidation="false">
				                                                </asp:LinkButton>
				                                             </ItemTemplate>
		                                                </asp:TemplateColumn>
		        
						                         </Columns>
						                         <EditItemStyle BackColor="#FFFF66" />
                                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                                <ItemStyle Wrap="False" />
						                         <PagerStyle Mode="NumericPages"></PagerStyle>
				                             </asp:datagrid>
				                             </ContentTemplate>
                                   			</asp:UpdatePanel>
                              </td>
                              <td valign="top" width="20%">&nbsp;&nbsp;</td>
                              <!-- Change Order SOV -->                              
                              <td valign="top">
                                <button class="button" style="width:150px" id="Button1" onclick="popupfunction('AddCOSOV.aspx','ADD Co-SOV','550','500');" type="button" onclick="return Button1_onclick()">Add Change Order SOV</button><br />
                                   			<asp:UpdatePanel ID="UpdCOSOV" runat="server" >
                                   			<ContentTemplate>
                                   			
                                   			<asp:datagrid id="grdCOSOV" 
				                            runat="server"  
				                            BorderStyle="Solid" 
				                            Width="100%" 
				                            CssClass="data" 
				                             ShowFooter="true"
				                             PageSize="100"
				                            BackColor="WhiteSmoke"
			                                DataKeyField="seq_number" 
			                                OnItemCreated="ResultGridItemCreated"
			                                OnCancelCommand="grdCOSOV_CancelCommand"
			                                OnUpdateCommand="grdCOSOV_UpdateCommand" 
			                                OnEditCommand="grdCOSOV_EditCommand" 
			                                OnDeleteCommand="grdCOSOV_DeleteCommand"
			                                OnItemDataBound="grdCOSOV_ItemDataBound"
			                                AutoGenerateColumns="False"
			                                Font-Size="Smaller" 
			                                CellPadding="3">
				                            <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                              <Columns>
					                                      <asp:TemplateColumn HeaderText="EDIT">
				                                            <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                  Font-Bold="True"></HeaderStyle>
				                                            <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutEdit"  runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
						                                            CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate>
				                                                <EditItemTemplate>
					                                            <asp:LinkButton id="lnkbutUpdate" ValidationGroup="editmode" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
						                                            CommandName="Update"></asp:LinkButton>&nbsp;
					                                            <asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
						                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
					                                            </EditItemTemplate>
			                                                </asp:TemplateColumn>
                        		                             
                        		                             <asp:TemplateColumn SortExpression="seq_number" HeaderText="Number" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblseq_number0" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.seq_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:Label id="lblseq_number1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.seq_number")%>'>
					                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                    </EditItemTemplate> 
				                                             </asp:TemplateColumn>
              
                                                             <asp:TemplateColumn SortExpression="co_number" HeaderText="CO#" HeaderStyle-Font-Bold="True">
				                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                    <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                    <ItemTemplate>
					                                                            <asp:Label id="lblco_number" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.co_number")%>'>
					                                                            </asp:Label>
				                                                    </ItemTemplate>
				                                                    <EditItemTemplate>
				                                                               <asp:TextBox id="txtco_number" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.co_number")%>'>
					                                                          </asp:TextBox>
				                                                    </EditItemTemplate> 
				                                             </asp:TemplateColumn>      
						                                    					                            
				                                            <asp:TemplateColumn SortExpression="Description" 
                                                              HeaderText="Description">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="200" id="txtDescription" ValidationGroup="editmode1" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvDescription" runat="server" Display="Dynamic" ErrorMessage="Please enter a Description"
						                                                        ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                             </asp:TemplateColumn>
				
				                                        <asp:TemplateColumn SortExpression="sov_amount" ItemStyle-HorizontalAlign=Right HeaderText="S.O.V. Amount">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle  HorizontalAlign="right"   BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblsov_amount" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.sov_amount")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="200" id="txtsov_amount" ValidationGroup="editmode1" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.sov_amount") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvsov_amount" runat="server" Display="Dynamic" ErrorMessage="Please enter a sov_amount"
						                                                        ControlToValidate="txtsov_amount"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                        </asp:TemplateColumn>
				                                        
				                                        <asp:TemplateColumn SortExpression="Date_Submited" HeaderText="Date Submited" ItemStyle-Width="75px">
				                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDate_Submited" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Date_Submited")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="75" id="txtDate_Submited" ValidationGroup="editmode1" runat="server" MaxLength="180" Text='<%# DataBinder.Eval(Container, "DataItem.Date_Submited") %>' >
					                                                         </asp:TextBox>
					                                                        <asp:ImageButton runat="server"  ID="ImgDate_Submited"
					                                                        ImageUrl="assets/img/calendar.gif"  
                                                                            AlternateText="Click here to display calendar" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalDate_Submited" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtDate_Submited"  
                                                                            PopupButtonID="ImgDate_Submited" Enabled="True"/>
					                                                        <asp:RequiredFieldValidator id="rfvDate_Submited" runat="server" Display="Dynamic" ErrorMessage="Please Date_Submited"
						                                                        ControlToValidate="txtDate_Submited"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                         </asp:TemplateColumn>
				                                         
				                                          <asp:TemplateColumn SortExpression="Date_Approved" 
                                                              HeaderText="Date Approved" ItemStyle-Width="75px">
				                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav" 
                                                                      Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblDate_Approved" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Date_Approved")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="75" id="txtDate_Approved"  ValidationGroup="editmode1" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Date_Approved") %>' >
					                                                         </asp:TextBox>
					                                                        <asp:ImageButton runat="server"  ID="ImgDate_Approved"
					                                                        ImageUrl="assets/img/calendar.gif"  
                                                                            AlternateText="Click here to display calendar" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalDate_Approved" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtDate_Approved"  
                                                                            PopupButtonID="ImgDate_Approved" Enabled="True"/>
				                                                </EditItemTemplate> 
				                                          </asp:TemplateColumn>
				                                             
				                                          <asp:TemplateColumn SortExpression="Notes" 
                                                              HeaderText="Comments">
				                                                <HeaderStyle HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav" 
                                                                    Font-Bold="True"></HeaderStyle>
				                                                <ItemStyle HorizontalAlign="left" BackColor="#EAEFF3"></ItemStyle>
				                                                <ItemTemplate>
					                                                        <asp:Label id="lblNotes" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Notes")%>'>
					                                                        </asp:Label>
				                                                </ItemTemplate>
				                                                <EditItemTemplate>
				                                                            <asp:TextBox Width="200" id="txtNotes" ValidationGroup="editmode1" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Text='<%# DataBinder.Eval(Container, "DataItem.Notes") %>' >
					                                                        </asp:TextBox>
					                                                        <asp:RequiredFieldValidator id="rfvNotes" runat="server" Display="Dynamic" ErrorMessage="Please enter a Notes"
						                                                        ControlToValidate="txtNotes"></asp:RequiredFieldValidator>
				                                                </EditItemTemplate> 
				                                             </asp:TemplateColumn>
				                                                
				                                        <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
				                                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                            <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
				                                            <ItemTemplate>
					                                            <asp:LinkButton id="lnkbutDelete1" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
						                                            CommandName="DELETE" CausesValidation="false">
				                                                </asp:LinkButton>
				                                             </ItemTemplate>
		                                                </asp:TemplateColumn>
		        
						                         </Columns>
						                         <EditItemStyle BackColor="#FFFF66" />
                                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                                <ItemStyle Wrap="False" />
						                         <PagerStyle Mode="NumericPages"></PagerStyle>
				                             </asp:datagrid>
				                             </ContentTemplate>
                                   			</asp:UpdatePanel>
                              </td>
                              
                            </tr>
                         </table>
                         </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                            
                          <ajaxToolkit:TabPanel ID="TbPanelAmount" runat="server" HeaderText="Cash Flow Analysis"  ActiveTabIndex="2">
                            <ContentTemplate>
                                                <table align="center"  width="100%" bgcolor="WhiteSmoke">
                                                    <tr align="left" valign="top">
                                                        <td>
                                                            <SPAN class="header1">Current Contract Amount:<asp:Label ID="lblTotAnnFabHours" runat="server"></asp:Label>



                                                             </SPAN>
                                                            <SPAN class="header2">Current Projected Amount:<asp:Label ID="lblTotScheduledHours" runat="server"></asp:Label>



                                                            </SPAN>
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
							                                <asp:TextBox Width="50" id="txtSchAmount" runat="server" Text="0" onBlur="this.value=formatCurrencyNoSign(this.value);" ></asp:TextBox></td>
                        							        
                        								        
							                                 <td rowspan="2" width="80%">
                                                            <div style="text-align:left; OVERFLOW-Y:scroll; WIDTH:625px; HEIGHT:125px;" >
                                                                    <asp:datagrid ID="grdWeeklyNotes" runat="server" CssClass="data" Width="600px"
                                                                    AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                                                                    OnItemCreated="ResultGridItemCreated" FooterStyle-Font-Name="Verdana"
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
                                                               </div>
                                                            </td>
                        							        
							                                </tr>
                        							        
							                                <tr>
							                                <td  colspan=4 valign="top" width="100px">Weekly Cash Flow Plan Summary:<br />
							                                     <asp:TextBox id="txtWeeklyComments" 
                                                                      ValidationGroup="tabProdSch" runat="server" Width="300px" Height="25px" 
                                                                      TextMode="MultiLine" MaxLength=500 Wrap=True></asp:TextBox>
                                                            </td>
                                                            
                                                            <td>
                                                                <asp:button id="btnSaveHours" width="80px" 
                                                                runat="server" 
                                                                ValidationGroup="tabProdSch" 
                                                                Text="Save Input" 
                                                                CssClass="button" 
                                                                onclick="btnSaveHours_Click"></asp:button><br />
                                                                <asp:Label ID="lblSchError" runat="server" CssClass="error1"></asp:Label>
                                                            </td>
                                                           
                                                            
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">Weekly Cash Flow Summary Table:</td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td colspan="6">
                                                                <DIV style="OVERFLOW-Y:scroll; WIDTH:100%; HEIGHT:200px;" >
                                                                     <asp:datagrid id="grdSchedule"                                               
                                                                                 runat="server" 
                                                                                 CssClass="data" 
                                                                                 Width="800px"
                                                                                 AllowPaging="True" 
                                                                                 AutoGenerateColumns="True" 
                                                                                 SelectedItemStyle-BackColor="LemonChiffon"
                                                                                 FooterStyle-Font-Name="Verdana"
                                                                                 PageSize="100" 
                                                                                 FooterStyle-Font-Size="10pt" 
                                                                                 FooterStyle-Font-Bold="True" 
                                                                                 FooterStyle-ForeColor="#ffff99"
                                                                                 FooterStyle-BackColor="#D9D9D9"  
                                                                                   HorizontalAlign=Right
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
                        </ajaxToolkit:TabContainer>
                 </td>
                </tr>
            </table>
            
           <script type="text/javascript" language="javascript">
            var theForm = document.forms[0];
            window.name = 'IEAdvanceQueue';
            var agreewin = "";
            function popupfunction(url,msg,width,height) {
                var pageName = url;
                var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdntwcProjNumber');
                var parameters = "?EstNum=" + myTextField.value + "&twcProjNumber=" + myTextField1.value;
                url = pageName + parameters
                agreewin = dhtmlmodal.open("agreebox", "iframe", url, msg, "width=" + width + "px,height=" + height + "px,center=1,resize=1,scrolling=0", "recal")
                agreewin.onclose = function() { 
                        //Define custom code to run when window is closed
                        return true 
                        //Allow closing of window in both cases
                }
            }
           </script>
           
</asp:Content>

