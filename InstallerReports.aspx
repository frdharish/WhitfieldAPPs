<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="InstallerReports.aspx.cs" Inherits="InstallerReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div>  <!-- Outer Div -->
<table cellpadding="2" cellspacing="2" width="100%" bgcolor="white">
  <tr>
    <td align="left"> <!-- Project Information Tabs Begin-->
    <SPAN class="header2"><asp:Label ID="lblPrjHeader" runat="server"></asp:Label></SPAN><br />
    <ajaxToolkit:TabContainer ID="tabgeneral" runat="server" Width="100%" CssClass="fancy" ActiveTabIndex="0">
        
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
                                        <td vAlign="middle" align="right" class="form1">Project#:</td>
                                        <td colspan="2">
                                        <asp:Label id="txtwhitPrjNumber" ValidationGroup="Tabreport" Width="75px"  runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnEstNum" runat="server" />
                                        <asp:HiddenField ID="hdntwcProjNumber" runat="server" />
			                            </td>
                                    </tr>
                                    <tr>
			                            <td vAlign="middle" align="right" class="form1">Report Date:</td>
			                            <td colspan="2">
				                            <asp:TextBox ID="txtReportDate"  ValidationGroup="Tabreport"  runat="server" MaxLength="15" Width="125px"></asp:TextBox>
				                            <asp:ImageButton runat="server"  ID="ImageButton1"  ImageUrl="assets/img/calendar.gif" AlternateText="Click here to display calendar" /> 
                                            <asp:button id="btnRptSearch" runat="server" Visible="false" Text="Search" Width="50px" CssClass="button"></asp:button>
				                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy"  runat="server" TargetControlID="txtReportDate" PopupButtonID="ImageButton1" Enabled="True"/>                                                                                        
				                            <asp:RequiredFieldValidator ValidationGroup="Tabreport" ID="rrReportDate" ControlToValidate="txtReportDate" ErrorMessage="Report Date is Required."
                                            runat="server"></asp:RequiredFieldValidator>                                                                                
                                        </td>
                                    </tr>
                                    <tr>
						                <td class="form1" align="right" valign="middle">Management <br />Reviewed/Accepted:</td>
						                <td>
						               
	                                         <asp:RadioButtonList ID="chkActive" CssClass="form1"  ValidationGroup="Tabreport"  RepeatDirection="Horizontal" runat="server">
	                                         <asp:ListItem Text="Yes" Value="Y" ></asp:ListItem>
	                                         <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
	                                         </asp:RadioButtonList>  
	                                    </td>
					                    <td valign="middle" align="center"><br>
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
 						                    <th colspan="2" valign="top" align="center" style="font-size: smaller">Installation Daily Hour Analysis</th>
                                            <tr>
                                               <td align="right">Budget Hours</td>
                                               <td align="center"><asp:Label ID="lblCummBudgetHours" runat="server" Width="20px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                               <td align="right">Hours to Date</td>
                                               <td align="center"><asp:Label ID="lblCummHoursTD" runat="server" Width="20px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                               <td align="right">Difference</td>
                                               <td align="center"><asp:Label ID="lblCummDiffTD" runat="server" Width="20px"></asp:Label></td>
                                            </tr>                       
                                        </table>
                                    </td>                        
                                </table><!--Installation Daily Hour Analysis-->
                            </td>
                            </tr> 
                                    <tr>
					                    <td vAlign="top" class="form1" colspan="2">Daily Work Performed Notes/Comments:<br />
				                            <asp:textbox id="txtRptNotes" width="600px"  ValidationGroup="Tabreport" runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                            cols="80"></asp:textbox>
			                            </td>
                                    </tr>
		                            <tr>
                                       <td vAlign="top" class="form1" colspan="2">Significant Issues/Impediments Notes/Comments:<br />
				                            <asp:textbox id="txtRptIssues" width="600px"  ValidationGroup="Tabreport"  runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" cols="80">
                                            </asp:textbox>
		                               </td>
                                    </tr>
                                    <tr>
   			                            <td vAlign="top" class="form1" colspan="2">Change Order Work Notes/Comments:<br />
				                            <asp:textbox id="txtRptChangeOrderNotes" width="600px"  ValidationGroup="Tabreport"  runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                            cols="80"></asp:textbox>
			                            </td>  
                                    </tr>
                       
                        </table>
                    </td>
                    <td valign="top">
                         <table bgcolor="WhiteSmoke" border="0" >
                        <tr>
                            <td>
                            <table width="100%" border="0">
	                            <td vAlign="top" class="form1" colspan="4">
	                          <table>
						            <tr>
							            <td  valign="top"  width="100px">Worker Type<br />
								            <asp:DropDownList ID="ddlEmplType"  ValidationGroup="Tabreport" runat="server" Width="150px"></asp:DropDownList>
							            </td>
							            <td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20">
							            </td>
							            <td  valign="top" width="50px">Hours:<br />
								            <asp:textbox id="txtManHours"  ValidationGroup="Tabreport" runat="server" MaxLength="3" Width="50px"></asp:textbox>
								            <asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
							                    ControlToValidate="txtManHours" ValidationExpression="[0-9.]"></asp:RegularExpressionValidator></td><td vAlign="top"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="20">
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
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
                            <td vAlign="top" class="form1">
                                <button class="button" style="width:150px" id="btnWorkerMaintenance" onclick="popupwithwidthheight('worker_maintenance.aspx','Worker Maintenance');" type="button">Add Worker</button>  
                                <br />Manpower Detail:<br />								                                               																	
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
							                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    <EditItemTemplate>
							                    <asp:TextBox Width="50" id="txtinstallhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.install_hours") %>' >
							                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
							                    <asp:RequiredFieldValidator id="rfvinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please enter total hours"
							                    ControlToValidate="txtinstallhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
							                    ControlToValidate="txtinstallhours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn>
							                    
						                    
							                    <asp:TemplateColumn Visible="false" SortExpression="TotHours" HeaderText="Total Hours" HeaderStyle-Font-Bold="True"
							                    HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:Label id="lblTotHours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TotHours")%>'>
							                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
							                    </ItemTemplate>
							                    </asp:TemplateColumn>
                    																					                                  
							                    <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
							                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                    <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
							                    <ItemTemplate>
							                    <asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
							                    CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate><EditItemTemplate>
							                    <asp:LinkButton id="lnkbutUpdate" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
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
						                        <asp:textbox id="txtHours" HorizonatalAlign="center" ValidationGroup="Tabreport" runat="server" MaxLength="3" Width="50px"></asp:textbox></td></tr><tr>
					                            <td align="right">Difference</td><td align="center"><asp:Label ID="lblInstdiffbud" runat="server" Width="20px"></asp:Label></td></tr></tr></table></td><td>
			                        <table>Comments Specific to this Work Order:
					                            <tr>
						                            <td  valign="top" width="100px">
							                            <asp:TextBox id="txtActComments" ValidationGroup="Tabreport" runat="server" Width="250px" Height="100px" TextMode="MultiLine" MaxLength=500 Wrap=True>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
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
				OnItemDataBound="grdActivity_ItemDataBound" OnUpdateCommand="grdActivity_UpdateCommand" 
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
						ControlToValidate="txtinstallhours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></EditItemTemplate></asp:TemplateColumn><asp:TemplateColumn SortExpression="empl_comments" HeaderText="Comments" HeaderStyle-Font-Bold="True"
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
                                <asp:datagrid id="grdHistoryRpt" runat="server" CssClass="data" Width="50%"
                                    AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                                    OnItemDataBound="grdHistoryRpt_ItemDataBound" FooterStyle-Font-Name="Verdana"
                                    FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
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
                
                function showHistoryReport(ReportDate) {
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_TabPnlFieldReport_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_TabPnlFieldReport_hdntwcProjNumber');
                    location.href = 'InstallerReports.aspx?ReportDate=' + ReportDate + "&twcProjNumber=" + myTextField1.value + "&EstNum=" + myTextField.value;
                }
                function popupwithwidthheight(url, heading) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_TabPnlFieldReport_hdnEstNum');
                    var myTextField1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_TabPnlFieldReport_hdntwcProjNumber');
                    var parameters = "?EstNum=" + myTextField.value + "&twcProjNumber=" + myTextField1.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, heading, "width=700px,height=500px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
            </script></div></asp:Content>