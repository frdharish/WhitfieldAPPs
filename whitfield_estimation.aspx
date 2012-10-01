<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfield_estimation.aspx.cs" Inherits="whitfield_estimation"  ValidateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="workordermaterial" Src="workorder_materials.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <script type="text/javascript" language="javascript">
               
                </script>
            <table cellpadding="2" cellspacing="2" width="100%" bgcolor="white">
                <tr>
                    <td align="left">
                    <SPAN class="header2"> <asp:Label ID="lblPrjHeader" ForeColor="OrangeRed" runat="server"></asp:Label></SPAN><br />
                        <ajaxToolkit:TabContainer ID="tabgeneral" runat="server" Width="100%" CssClass="fancy" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel ID="tabGenInfo" runat="server" HeaderText="General Information">
            <ContentTemplate>
                <table align="center" cellspacing="2" cellpadding="2"  width="100%" height="400" bgcolor="WhiteSmoke">
                    <tr align="left" valign="top"> 
                    <td>

                             <SPAN class="header1">GENERAL</SPAN>&nbsp;<SPAN class="header2">INFORMATION</SPAN><BR>
							         
        	 <TABLE>
        	 <tr>
			    <TD class="form1" >Project Name:<br />
					<asp:textbox id="txtprjname" ValidationGroup="TabGroup1" runat="server" MaxLength="50" Width="200px"></asp:textbox>
					<asp:HiddenField ID="hdnEstNum" runat="server" /><br />
					<asp:RequiredFieldValidator ValidationGroup="TabGroup1" ID="rrprjname" 
                    ControlToValidate="txtprjname" ErrorMessage="Project Name is Required"
                    runat="server"></asp:RequiredFieldValidator>
				</TD> <!--Project Name-->    	 
        		
        		<TD class="form1">Project Type:<br />
					<asp:dropdownlist id="ddlprjtype" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist><br />
					<asp:RequiredFieldValidator ID="rrprjtype"
					ControlToValidate="ddlprjtype" ValidationGroup="TabGroup1" InitialValue="0" ErrorMessage="Project Type is Required" 
                    runat="server"></asp:RequiredFieldValidator>
                </TD> <!--Project Type-->
                
                <td class="form1">Project Status:<br />
					<asp:dropdownlist id="ddlPrjStatus" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>
				</td> <!--Project Status-->
                
   				<td class="form1">Estimator:<br />
					<asp:dropdownlist id="ddlEstimator" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist><br />
					<asp:RequiredFieldValidator ID="rrestimator" ControlToValidate="ddlEstimator" ValidationGroup="TabGroup1" 
					ErrorMessage="Estimator is Required" 
                    runat="server"></asp:RequiredFieldValidator>
                </td> <!--Estimator-->													                             
 				
 				<td class="form1" >Base Bid:<br />
					<asp:textbox id="txtbasebid"  style="text-align:right"  ValidationGroup="TabGroup1" runat="server" Text="$0.00" MaxLength="14" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
                </td> <!--Base Bid-->
 				
 				<TD vAlign="top" class="form1" style="width: 151px" colspan="2" >Architect:<br />
					<asp:dropdownlist id="ddlarchitect" Width="250px"  ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>
				</TD> <!--Architect-->
        	 </tr> <!--Project Name, Project Type, Project Status, Estimator, Base Bid, Architect-->
        	 <tr >
				<td class="form1">Bid Date:<br />
					<asp:TextBox ID="txtBidDate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="ImgBidDate"
					ImageUrl="assets/img/calendar.gif"  ValidationGroup="TabGroup1"
                    AlternateText="Click here to display calendar" />
                    <ajaxToolkit:CalendarExtender ID="CalBidDate" runat="server" 
                    Format="MM/dd/yyyy" TargetControlID="txtBidDate"  
                    PopupButtonID="ImgBidDate" Enabled="True"/>
                </td> <!--Bid Date--> 
				<td class="form1">Bid Time:<br />															        															           
					<asp:TextBox ID="txtEditStartTime" ValidationGroup="TabGroup1" runat="server" MaxLength="8"></asp:TextBox>
                         <ajaxToolkit:MaskedEditExtender ID="m1" runat="server" Mask="99:99:99" 
                         MaskType="Time" AcceptAMPM="True" TargetControlID="txtEditStartTime" 
                         CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                         CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                         CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"></ajaxToolkit:MaskedEditExtender>
                         <ajaxToolkit:MaskedEditValidator ID="mv1" runat="server" 
                         ControlExtender="m1" ControlToValidate="txtEditStartTime"
                         Display="None" EmptyValueMessage="Time is required" 
                         InvalidValueMessage="Valid Bid Time in HH:MM" TooltipMessage="Input a time" 
                         ErrorMessage="mv1"></ajaxToolkit:MaskedEditValidator>
                </td> <!--Bid Time-->        	 
        	 	<td class="form1">Anticipated Review Duration:<br />
					<asp:TextBox ID="txtARD" MaxLength="5" Width="30px" ValidationGroup="TabGroup1" runat="server"></asp:TextBox> 
			    </td> <!--Anticipated Review Duration-->        	 
        	 	<td class="form1">Projected Award Date:<br />
					<asp:TextBox ID="txtawardDate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="imgaward"  
                    ImageUrl="assets/img/calendar.gif" 
                    AlternateText="Click here to display calendar" />
						<ajaxToolkit:CalendarExtender ID="CalAwardDt"  Format="MM/dd/yyyy"  
                         runat="server" TargetControlID="txtawardDate" PopupButtonID="imgaward" 
                         Enabled="True"/>
                </td> <!--Projected Award Date-->                
                <td class="form1" >Final Price:<br />
				    <asp:textbox id="txtfinalbid" style="text-align:right" MaxLength="14" ValidationGroup="TabGroup1" runat="server" Width="75px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox>
                </td> <!--Final Price-->                               
                
                <td class="form1" >Awarded Contractor:
                    <asp:dropdownlist id="ddlwonclient" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>
                </td > <!--Awarded Contractor-->
                
                <td class="form1">Awarded Competitor:<br />
                    <asp:dropdownlist id="ddlwoncompe" ValidationGroup="TabGroup1" runat="server"></asp:dropdownlist>
                </td> <!--Awarded Competitor-->
               </tr> <!--Bid Date, Bid Time, Anticipated Review Duration, Projected Award Date, Final Price, Awarded Contractor, Awarded Competitor-->
                    
            <tr>
				<TD class="form1" colspan="5" >Project Description:<br />
					<asp:textbox id="txtdesc" width="850px"   ValidationGroup="TabGroup1" runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                     cols="80"></asp:textbox>
                </TD> <!--Project Description-->                
                <td vAlign="top" class="form1" colspan="8" rowspan="2">Bidding Contractors:<br />
					<asp:PlaceHolder ID="pHprojClient" Visible="false" runat=server>
					<button class="button" style="width:75px" id="Button1" onclick="popupfunction('project_client.aspx');" type="button">Add Client</button>
					
					</asp:PlaceHolder><br />
					
					<asp:datagrid id="grdclients" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
					OnPageIndexChanged="PageResultGrid1" AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
					CellPadding="3" DataKeyField="ClientID">
					<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
						<Columns>
							<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Client Name" HeaderStyle-Font-Bold="true">
								<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
								<ItemStyle BackColor="#EAEFF3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="ContactName" SortExpression="ContactName" HeaderText="Primary Contact">
								<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
								<ItemStyle BackColor="#EAEFF3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="Email">
								<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
								<ItemStyle BackColor="#EAEFF3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="Tel" SortExpression="Tel" HeaderText="Contact Number">
								<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
								<ItemStyle BackColor="#EAEFF3"></ItemStyle>
							</asp:BoundColumn>
							<asp:TemplateColumn HeaderText="EDIT">
								<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
								<ItemTemplate>
								<%# ShowContactEditImage("AddContacts.aspx", ((DataRowView)Container.DataItem)["ClientID"])%>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
					</asp:datagrid>				        
				</td> <!--Bidding Contractors-->
        	</tr> <!--Project Description, Bidding Contractors-->
            <tr>
				<td class="form1">Construction Start Date:<br />
					<asp:TextBox ID="txtConstStdate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="imgConst"  
                    ImageUrl="assets/img/calendar.gif" 
                    AlternateText="Click here to display calendar" />
						<ajaxToolkit:CalendarExtender ID="CalConst" Format="MM/dd/yyyy"  runat="server" 
                        TargetControlID="txtConstStdate" PopupButtonID="imgConst" Enabled="True"/>
				</td> <!--Construction Start-->
				
				<td class="form1">Construction End Date:<br />
					<asp:TextBox ID="txtConstEndDate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="imgconstEnd"  
                    ImageUrl="assets/img/calendar.gif" 
                    AlternateText="Click here to display calendar" />
						<ajaxToolkit:CalendarExtender ID="CalConstEnd" Format="MM/dd/yyyy"  
                        runat="server" TargetControlID="txtConstEnddate" PopupButtonID="imgconstEnd" 
                        Enabled="True"/>
				</td> <!--Construction End Date-->
				
				<td class="form1">Construction Duration:<br />
					<asp:TextBox ID="txtConstDuration" MaxLength="5" Width="30px"  ValidationGroup="TabGroup1" runat="server"></asp:TextBox> Day(s)
				</td> <!--Construction Duration-->
				<td rowspan="3" colspan="2" width="250px"><table width="100%" height="100%">
			<tr><td colspan="2"><b>Project Address:</b></td> 
			<tr>
			    <td width="20%" align="right">Street:</td>
			    <td width="80%"><asp:textbox id="txtStreet" width="175px" ValidationGroup="TabGroup1" runat="server"></asp:textbox></td>
			</tr>
			<tr>
			    <td width="20%" align="right">City:</td>
			    <td width="80%"><asp:textbox id="txtCity" width="100px" ValidationGroup="TabGroup1" runat="server"></asp:textbox></td>
			</tr>
			<tr>
			    <td width="20%" align="right">State:</td>
			    <td width="80%"><asp:textbox id="txtState" width="75px" ValidationGroup="TabGroup1" runat="server"></asp:textbox></td>
			</tr>
			<tr>
			    <td width="20%" align="right">Zip:</td>
			    <td width="80%"><asp:textbox id="txtzip" width="75px" ValidationGroup="TabGroup1" runat="server"></asp:textbox></td>
			</tr>
			<tr>
			    <td class="form1" width="100%" colspan="2" align="right">Awarded Project Number: <asp:textbox id="txtrealprjNumber" width="50px" ReadOnly="true" ValidationGroup="TabGroup1" runat="server"></asp:textbox></td>
			</tr>
				</table>
				</td>

            </tr> <!--Construction Start, Construction End Date, Construction Duration-->   
            
            <!--Fabrication Start, Fabrication End Date, Fabrication Duration-->  	
            <tr>
				<td class="form1">Fabrication Start Date:<br />
					<asp:TextBox ID="txtfabStartdate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="ImageButton1FabStartDate"   
                    ImageUrl="assets/img/calendar.gif" 
                    AlternateText="Click here to display calendar" />
						<ajaxToolkit:CalendarExtender ID="CalendarExtender1FabStartDate" Format="MM/dd/yyyy"  runat="server" 
                        TargetControlID="txtfabStartdate" PopupButtonID="ImageButton1FabStartDate" Enabled="True"/>
				</td> <!--Construction Start-->
				
				<td class="form1">Fabrication End Date:<br />
					<asp:TextBox ID="txtfabEndDate" ValidationGroup="TabGroup1" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					<asp:ImageButton runat="server"  ID="ImageButton2FabEndDate"  
                    ImageUrl="assets/img/calendar.gif" 
                    AlternateText="Click here to display calendar" />
						<ajaxToolkit:CalendarExtender ID="CalendarExtender2fabEndDate" Format="MM/dd/yyyy"  
                        runat="server" TargetControlID="txtfabEndDate" PopupButtonID="ImageButton2FabEndDate" 
                        Enabled="True"/>
				</td> <!--Construction End Date-->
				
				<td class="form1">Fabrication Duration:<br />
					<asp:TextBox ID="txtfabduration" MaxLength="5" Width="30px"  ValidationGroup="TabGroup1" runat="server"></asp:TextBox> Day(s)
				</td> <!--Construction Duration-->

            </tr>  
        	 
        	<tr>
        	<td class="form1" colspan="3"  >Customer Message to be included in email body:<br />
					                <asp:textbox id="txtNotes" width="600px"   ValidationGroup="TabGroup1" runat="server"  Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="6" 
                                    cols="80" text="Thank you."></asp:textbox>
            </td>
        	    <!--td >
        	        <td>
        	            <table>
        	 	                
                        </table>
                    </td>
                    <td>
                        <tr>
                            <th colspan="2">Project Address</th>
                            <td>Street:</td>
                            <td>xx</td>
                        </tr>
                        <tr>
                            <td>Suite:</td>
                            <td>xx</td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td>xx</td>
                        </tr>
                        <tr>
                            <td>State:</td>
                            <td>xx</td>
                            <td>Zip</td>
                            <td>xx</td>
                        </tr>
                    </td-->
                </td><!--Notes/Comments--><td vAlign="top" class="form1" colspan="8" rowspan="4" >Competition Set:<br />
				<asp:PlaceHolder ID="pHprojcompe" Visible="false" runat=server> 
				<button class="button" style="width:150px" id="Button2" onclick="popupfunction('project_contacts.aspx');" type="button">Add Competition</button></asp:PlaceHolder>
				
				<asp:datagrid id="grdcompe" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
				OnPageIndexChanged="PageResultGrid2" AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				CellPadding="3" DataKeyField="Compeid">
				<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					  <Columns>
						<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Competition Name" HeaderStyle-Font-Bold="true">
						    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Bid" SortExpression="Bid" HeaderText="Bid Amount">
							<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>														                                    
						<asp:TemplateColumn HeaderText="EDIT">
							<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
							<ItemTemplate>
							<%# ShowContactEditImage("AddBid.aspx", ((DataRowView)Container.DataItem)["Compeid"])%></ItemTemplate></asp:TemplateColumn>
						</Columns>
						<PagerStyle Mode="NumericPages"></PagerStyle>
				 </asp:datagrid>
				 
				</td> <!--Competition Set-->
        	</tr> <!--Notes/Comments, Competition Set-->


			<tr>
        	 	<td  align="center" class="form1" colSpan="5">
					<asp:button id="btnnew" runat="server" ValidationGroup="TabGroup1" Text="Save Changes" CssClass="button" 
                    onclick="btnnew_Click"></asp:button>&nbsp;&nbsp;

                    <asp:button id="btnDelete" runat="server" ValidationGroup="TabGroup1" Text="Delete this Estimate" CssClass="button" 
                    Visible="false" onclick="btnDel_Click"></asp:button>&nbsp;&nbsp;


				</td> <!--Save Changes, Delete this Estimate-->

        	</tr> <!--Save Changes, Delete this Estimate-->

        	 </TABLE> <!--General Information Data Set-->
        	            </td>
        	        </tr>
        	    </table>
        	 </ContentTemplate>
        	 
        	 </ajaxToolkit:TabPanel><!--General Information-->
        	 
    <ajaxToolkit:TabPanel ID="tabconsideration" runat="server" HeaderText="Parameters">
       <ContentTemplate>
           <table cellspacing="2" cellpadding="2" width="100%"  bgcolor="WhiteSmoke" border="0">
              <SPAN class="header1">PRICING</SPAN>&nbsp;<SPAN class="header2">PARAMETERS</SPAN><BR>
               <tr align="left" valign="top">
                <td style="width:500px">
                    <table width="500px"  bgcolor="WhiteSmoke" border="0">								
                        <tr>
                            <td style="text-align:right;">Total Material Cost:</td>
                            <td style="text-align: right">$<asp:TextBox ID="txtTotMatCost" ToolTip="Total Material Costs from Estimate Items"  BackColor="Transparent" BorderStyle="None"  readonly="true" MaxLength="15" Width="70px"  runat="server" align="right"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">Total Contigency Cost:</td>
                            <td style="text-align: right">$<asp:TextBox ID="txtTotCotCost"  ToolTip="Total Contingency Costs from Contingencies" BackColor="Transparent" BorderStyle="None" readonly="true" MaxLength="15" Width="70px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;  font-weight:bold;">Material & Contigency Total:</td>
                            <td style="text-align: right;  font-weight:bold">$<asp:TextBox ID="txtMatContTotal" ToolTip="Total Material & Contingency Costs" BackColor="Transparent" BorderStyle="None" readonly="true" MaxLength="15" Width="70px" runat="server"></asp:TextBox></td>
                        </tr>
                    </table><!--Material & Contingency Total--> 
                    <br />
                	    							
                    <table width="275px"  bgcolor="WhiteSmoke" border="0">
                        <tr>
                    <td style="text-align: right;  width:75px; font-weight:bold;">Labor Cost</td>
                    <td style="text-align: center;  width:65px; font-weight:bold;">Rate</td>
                    <td style="text-align: center;  width:50px; font-weight:bold;">Hours</td>
                    <td style="text-align: center;  width:55px; font-weight:bold;">Total</td>
                </tr>
                        <tr>
                    <td align="right" >Engineering</td>
                    <td style="text-align: center;">
                        $<asp:TextBox ID="txtEngRate" ValidationGroup="Tabparams"  MaxLength="15" Width="30px" text="45.00"  
                            runat="server" onBlur="ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtEngTotal.value=this.value*ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtEngQty.value;calcLaborTotal();calcMarkUpPercent();MarkUpTotal();MarkupPctTotal();this.value=formatCurrencyNoSign(this.value);">
                        </asp:TextBox>/hr
                    </td>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtEngQty" readonly="true" BackColor="Transparent" BorderStyle="None" MaxLength="5" Width="30px"  runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">$
                        <asp:TextBox ID="txtEngTotal" ToolTip="Shop Drawing Preparation, CNC Programming/Setup, Submittal Preparation, Work Order Generation, Field Measuring, Jobsite Visits" BackColor="Transparent" BorderStyle="None" readonly="true" MaxLength="15" Width="45px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td align="right" >Fabrication</td>
                    <td style="text-align: center;">
                        $<asp:TextBox ID="txtFabRate" align="right" ValidationGroup="Tabparams" MaxLength="15" Width="30px" text="37.00" runat="server" onBlur="ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtFabTotal.value=this.value*ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtFabQty.value;calcLaborTotal();calcMarkUpPercent();MarkUpTotal();MarkupPctTotal();this.value=formatCurrencyNoSign(this.value);"></asp:TextBox>
                    /hr</td>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtFabQty" readonly="true" BackColor="Transparent" BorderStyle="None" MaxLength="5" Width="30px" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">$
                        <asp:TextBox ID="txtFabTotal" ToolTip="Fabrication & Finishing Costs" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="45px"  readonly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td align="right" >Installation</td>
                    <td style="text-align: center;">
                        $<asp:TextBox ID="txtInstRate" ValidationGroup="Tabparams" MaxLength="15" Width="30px" text="45.00" runat="server" onBlur="ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtInsTotal.value=this.value*ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtInsQty.value;calcLaborTotal();calcMarkUpPercent();MarkUpTotal();MarkupPctTotal();this.value=formatCurrencyNoSign(this.value);"></asp:TextBox>
                    /hr</td>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtInsQty" readonly="true" BackColor="Transparent" BorderStyle="None" MaxLength="5" Width="30px" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">$
                        <asp:TextBox ID="txtInsTotal" ToolTip="Direct Installation Costs Only" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="45px"  readonly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td align="right" >Miscellaneous</td>
                    <td style="text-align: center;">
                        $<asp:TextBox ID="txtMiscRate" ValidationGroup="Tabparams"  MaxLength="15" Width="30px" text="25.00" runat="server" onBlur="ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMiscTotal.value=this.value*ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMiscQty.value;calcLaborTotal();calcMarkUpPercent();MarkUpTotal();MarkupPctTotal();this.value=formatCurrencyNoSign(this.value);"></asp:TextBox>
                    /hr</td>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtMiscQty"  readonly="true" BackColor="Transparent" BorderStyle="None" MaxLength="5" Width="30px" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">$
                        <asp:TextBox ID="txtMiscTotal" ToolTip="Receiving, Handling, Shipping, Maintenance, Organization" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="45px"  readonly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td style="text-align: right;  font-weight:bold" colspan="3">Total Labor Cost:</td>
                    <td style="text-align: right;  font-weight:bold">$
                        <asp:TextBox ID="txtTotRate" ToolTip="Total Project Labor Direct Costs" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="45px" readonly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    </table><!--Total Labor Cost--> 
                    <br />
            
                    <table width="400px"  bgcolor="WhiteSmoke" border="0">
                <tr>
                    <td style="text-align: right;  width:100px; font-weight:bold;">Burden Item</td>
                    <td style="text-align: center;  width:50px; font-weight:bold;">Rate</td>
                    <td style="text-align: center;  width:50px; font-weight:bold;">Markup</td>
                    <td style="text-align: center;  width:50px; font-weight:bold;">Total</td>
                </tr>
                <tr>
                    <td align="right" >Overhead</td>
                    <td style="text-align: center;">
                        $<asp:TextBox ID="txtOverHeadRate"  ValidationGroup="Tabparams" text="24.11" MaxLength="15" Width="30px" runat="server" onBlur="calcMarkUpPercent();"></asp:TextBox>/hr
                    </td>
                    <td style="text-align: center;">
                        <asp:label ID="lblOHPercent" ToolTip="Markup=(Material Total & Contigency + Labor Total Total)/Overhead Total)" MaxLength="15" Width="30px" runat="server"></asp:label>%
                    </td>
                    <td style="text-align: right;">$
                        <asp:label ID="lblOverHeadTotal" ToolTip="Overhead Total=(Fabrication Hours + Finishing Hours + Miscellaneous Hours + Engineering Hours)*Overhead Rate)" BorderStyle="None" MaxLength="15" Width="45px" runat="server"></asp:label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" >Profit</td>
                    <td align="center">n/a</td>
                    <td style="text-align: center;">
                        <asp:TextBox ID="txtMarkUpPercent" ToolTip="Profit Markup={manual entry, default at 15%" ValidationGroup="Tabparams"  text="15.00" MaxLength="15" Width="30px" runat="server" onBlur="MarkupPctTotal();"></asp:TextBox>%
                    </td>
                    <td style="text-align: right;">$
                        <asp:label ID="lblProfitTotal" ToolTip="Profit Total={(Total Material & Contigency + Total Labor + Total Overhead)*Profit Markup" BorderStyle="None" MaxLength="15" Width="45px" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;  font-weight:bold" colspan="2">Total Overhead/Profit Cost:</td>
                    <td style="text-align: center;  font-weight:bold;">
                        <asp:label ID="lblTotalOverHeadProfitPercent" ToolTip="Overhead/Profit Markup Total=(Overhead Markup + Profit Markup)" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="30px" runat="server"></asp:label>%
                    </td>
                    <td style="text-align: right;  font-weight:bold;">$
                        <asp:label ID="lblTotalOverHeadProfit" ToolTip="Overhead/Profit Total=(Overhead Total + Profit Total)" BackColor="Transparent" BorderStyle="None" MaxLength="15" Width="45px" runat="server"></asp:label>
                    </td>
                </tr>
            </table><!--Total Overhead/Profit Cost--> 
                    <br />
             
                    <table width="350px"  bgcolor="WhiteSmoke" border="0">								
                        <tr>
                            <td style="text-align: right;  font-weight:bold">Total Project Sell Price:</td>
                            <td style="text-align: right;  font-weight:bold;" >$
                                <asp:label ID="lblTotSellPrice"  MaxLength="15" Width="55px" runat="server"></asp:label>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">

                                &nbsp;&nbsp;
                               &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table><!--Total Project Sell Price--> 
                    <br />
                </td>
                <td valign="top" align="left" style="width:600px">                
                    <table width="600px" border="1">
                        <tr>
                            <td colspan="2" style="text-align: center;  font-weight:bold;">Type of Work:
                                <asp:DropDownList ID="ddlTypeofWork"  runat="server" CssClass="form1" Width="250px">
                                </asp:DropDownList>
                            </td> 
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:button id="Button6" style="width:80px" runat="server"  
                                Text="Save/Refresh" CssClass="button" onclick="btnsaverefresh_Click">
                                </asp:button> 

                                <button class="button" style="width:85px" id="Button13" 
                                onclick="printProposal('Y');" type="button">Print Proposal
                                </button>

                                <button class="button" style="width:80px" id="Button14" 
                                onclick="printProposal('N');" type="button">Print Scope</button>
                            </td>
                        </tr>
                        <tr>
                              <td colspan="2" align="center">
                                    <asp:button ID="btnpl" runat="server" Text="Email Proposal" CssClass="button" 
                                     onclick="btnpl_Click" style="width:122px"></asp:button>
                                    <asp:button ID="Email1" runat="server" Text="Email Quote" CssClass="button" 
                                    onclick="btnQuote_Click" style="width:122px"></asp:button>
                            </td>
                        </tr> 
                        <tr>
                            <td style="width:300"  valign="top" align="center">
                                 <SPAN class="header1" >Alternates</SPAN><BR>
                                 <asp:UpdatePanel runat="server" id="upnlAlter">
								<ContentTemplate>
                                <asp:datagrid id="grdalternatives" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
				                                                     OnDeleteCommand="grdalternatives_DeleteCommand" 
				                                                     OnPageIndexChanged="PageResultGrid2" 
				                                                     AllowPaging="false" 
				                                                     OnCancelCommand="grdalternatives_CancelCommand" 
				                                                     OnUpdateCommand="grdalternatives_UpdateCommand" 
				                                                     OnEditCommand="grdalternatives_EditCommand"
				                                                     AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="idnumber" >
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
					                                                              <asp:TemplateColumn SortExpression="Alternate_Number" HeaderText="Number" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
					                                                                        <itemtemplate>
																						        <asp:Label id="lblAlternate_number" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.Alternate_Number")%>'>
																						            </asp:Label>
																					        </ItemTemplate>
																					        <edititemtemplate>
																						        <asp:TextBox id="txtAlternate_number"   runat="server" Width="60px" 
																						             Text='<%# DataBinder.Eval(Container, "DataItem.Alternate_Number") %>'>
																						                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						        </asp:TextBox>
																				            </edititemtemplate>
																	               </asp:TemplateColumn>
																				    
																				    
																			        <asp:TemplateColumn SortExpression="Type" HeaderText="Type" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																				            <itemtemplate>
																						        <asp:Label id="lblType" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.Type")%>'>
																						            </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						        <asp:dropdownList ID="ddlType" runat="server" Width="100"
				                                                                                    DataSource="<%#BindDDLDefaults()%>" 
                                                                                                    DataTextField="value"
                                                                                                    DataValueField="key">
                                                                                                </asp:dropdownList>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	 
																			 
																			        <asp:TemplateColumn SortExpression="Description" HeaderText="Desc." HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lbldesc" runat="server" width="150" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtdesc"   runat="server" Width="150px" Height="75px"  TextMode="MultiLine" MaxLength="1000"
																						                Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>		    
																				 
																		    
																		            <asp:TemplateColumn SortExpression="Amount" HeaderText="Amount" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
					                                                                        <itemtemplate>
																						        <asp:Label id="lblAmount" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.Amount")%>'>
																						            </asp:Label>
																					        </ItemTemplate>
																					        <edititemtemplate>
																						        <asp:TextBox id="txtAmount"   runat="server" Width="60px" 
																						             Text='<%# DataBinder.Eval(Container, "DataItem.Amount") %>'>
																						                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						        </asp:TextBox>
																				            </edititemtemplate>
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
																							CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate>
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                         </asp:datagrid> 
				                </ContentTemplate>
				              </asp:UpdatePanel>
				              <br />
				              <button class="button" style="width:100px" id="Button11" 
                                   onclick="popupfunction('newalternatives.aspx');" type="button">Alternate Item</button>
                            </td>
                            <td style="width:300" valign="top" align="center">
                            <SPAN class="header1">Itemization</SPAN><BR>
                             <asp:UpdatePanel runat="server" id="upnlIB">
								<ContentTemplate>
                                <asp:datagrid id="grdItemBreakDown" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
				                                                     OnDeleteCommand="grdItemBreakDown_DeleteCommand" 
				                                                     OnCancelCommand="grdItemBreakDown_CancelCommand" 
				                                                     OnUpdateCommand="grdItemBreakDown_UpdateCommand" 
				                                                     OnEditCommand="grdItemBreakDown_EditCommand"
				                                                     OnPageIndexChanged="PageResultGrid2" AllowPaging="false" 
				                                                     AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="idnumber" >
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
					                                                            
						                                                            <asp:TemplateColumn SortExpression="item_number" HeaderText="No" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
					                                                                        <itemtemplate>
																						        <asp:Label id="lblINo" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.item_number")%>'>
																						            </asp:Label>
																					        </ItemTemplate>
																					        <edititemtemplate>
																						        <asp:TextBox id="txtIno"   runat="server" Width="60px" 
																						             Text='<%# DataBinder.Eval(Container, "DataItem.item_number") %>'>
																						                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						        </asp:TextBox>
																				            </edititemtemplate>
																	               </asp:TemplateColumn>
																	               
						                                                            
						                                                             <asp:TemplateColumn SortExpression="Description" HeaderText="Desc." HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblIdesc" runat="server" width="150" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtIdesc"   runat="server" Width="150px" Height="75px"  TextMode="MultiLine" MaxLength="1000"
																						                Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	
																			         
					                                                            
						                                                             <asp:TemplateColumn SortExpression="Amount" HeaderText="Amount" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="Right" BackColor="#EAEFF3"></ItemStyle>
					                                                                        <itemtemplate>
																						        <asp:Label id="lblIAmount" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.Amount")%>'>
																						            </asp:Label>
																					        </ItemTemplate>
																					        <edititemtemplate>
																						        <asp:TextBox id="txtIAmount"   runat="server" Width="100px" 
																						             Text='<%# DataBinder.Eval(Container, "DataItem.Amount") %>'>
																						        </asp:TextBox>
																				            </edititemtemplate>
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
																							CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate>
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                </asp:datagrid> 
				                                  </ContentTemplate>
				                            </asp:UpdatePanel>
				              <br />
				              <button class="button" style="width:100px" id="Button12" 
                                   onclick="popupfunction('newitembreakdown.aspx');" type="button">Item</button>
                            </td>
                        </tr>   
                   
                    </table>
                </td>                 
               </tr>
           </table>
       </ContentTemplate>
     </ajaxToolkit:TabPanel><!--Parameters-->
              
    <ajaxToolkit:TabPanel ID="proj_materials" runat="server" HeaderText="Materials">
                  <ContentTemplate>
                       <table cellspacing="2" cellpadding="2" width="100%"  height="400" bgcolor="WhiteSmoke">
                            <tr align="left" valign="top">
                                <td>
                                    <SPAN class="header1">Materials</SPAN><br />
                                     <asp:Button ID="btnexport" runat="server" CausesValidation="False" 
                                         CssClass="button" onclick="btnexport_Click" Text="Excel Export" />&nbsp;&nbsp;&nbsp;
                                    <button class="button" style="width:127px" id="Button7" 
                                            onclick="popupMaterial('Newestimate_material.aspx');" type="button">Add New Material</button>
                                            &nbsp;&nbsp;&nbsp;	
                                    <asp:Button ID="btnStandard" runat="server" CausesValidation="False" 
                                         CssClass="button" onclick="btnstandard_Click" Text="Standard Casework Materials" />
                                          &nbsp;&nbsp;&nbsp;	
                                    <asp:Button ID="btnLEED" runat="server" CausesValidation="False" 
                                         CssClass="button" onclick="btnLEED_Click" Text="LEED Materials" />
                                    <br />
                                    <!-- Here goes the Material Listing for the Estimate -->
                                    <TABLE cellSpacing="0" cellPadding="0"  border="0">
										<TR>
											<TD width="22"><IMG height="1" alt="" src="assets/img/spacer.gif" width="22"></TD>
											<TD width="100%">
											  <asp:UpdatePanel runat="server" id="updMaterialProject">
												<ContentTemplate>
												<asp:datagrid id="grdEstimateMaterials" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                        OnItemDataBound="grdEstimateMaterials_ItemDataBound" OnCancelCommand="grdEstimateMaterials_CancelCommand" OnUpdateCommand="grdEstimateMaterials_UpdateCommand" OnEditCommand="grdEstimateMaterials_EditCommand"  
				                                        OnPageIndexChanged="PageResultGrid1"  AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                        FooterStyle-Font-Name="Verdana" PageSize="100" ShowFooter="True"	FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" 
				                                        FooterStyle-ForeColor="#ffff99"
														FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="sub_mat_id">
				                                        <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				                                        <Columns>
			                                                    <asp:TemplateColumn HeaderText="Seq. No" HeaderStyle-Font-Bold="True">
			                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
			                                                    <ItemTemplate>
			                                                            <%#(grdEstimateMaterials.PageSize * grdEstimateMaterials.CurrentPageIndex) + Container.ItemIndex + 1%>
			                                                    </ItemTemplate>
			                                                    </asp:TemplateColumn>
			                                                    
			                                                     <asp:TemplateColumn SortExpression="Material Type" HeaderText="Material Type" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblreference_number" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.reference_number")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																						</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label id="lblreference_number1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.reference_number")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																				    </EditItemTemplate>
																</asp:TemplateColumn>
																
																 <asp:TemplateColumn SortExpression="LEED" HeaderText="LEED" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblLEED" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.LEED")%>'>
																						</asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label id="lblLEED1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.LEED")%>'>
																						         </asp:Label>
																				    </EditItemTemplate>
													            </asp:TemplateColumn>
																
																<asp:TemplateColumn SortExpression="PriceInProject" HeaderText="Project Price" HeaderStyle-Font-Bold="True">
				                                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                                        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                                        <ItemTemplate>
					                                                                <asp:Label id="lblPriceInProject" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.PriceInProject")%>'>
					                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                                        </ItemTemplate>
				                                                         <EditItemTemplate>
				                                                                    <asp:TextBox Width="50" id="txtPriceInProject" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.PriceInProject") %>' >
					                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                                                                <asp:RequiredFieldValidator id="rfvqty" runat="server" Display="Dynamic" ErrorMessage="Please enter PriceInProject"
						                                                                ControlToValidate="txtPriceInProject"></asp:RequiredFieldValidator>
						                                                                <ajaxToolkit:FilteredTextBoxExtender ID="Featuredcontrol_qty" 
                                                                                        runat="server" Enabled="True" TargetControlID="txtPriceInProject" 
                                                                                        ValidChars="0123456789.">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
				                                                        </EditItemTemplate> 
				                                                </asp:TemplateColumn>
				                                                
																 <asp:TemplateColumn SortExpression="Material Code" HeaderText="Material Code" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblMaterial_Code" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Material_Code")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label id="lblMaterial_Code1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Material_Code")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																				    </EditItemTemplate>
																</asp:TemplateColumn>
																
                                                                <asp:TemplateColumn SortExpression="OrigMatName" HeaderText="Material Description" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle Width="350px" HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblOrigMatName" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.OrigMatName")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label id="lblOrigMatName1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.OrigMatName")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																				    </EditItemTemplate>
																</asp:TemplateColumn>	                                        
				                                                
					                                       
					                                    
														
														 <asp:TemplateColumn HeaderText="Total Qty" HeaderStyle-Font-Bold="True">
			                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
			                                                    <ItemTemplate>
			                                                           <itemtemplate>
			                                                           <asp:Label id="lblTotalQty" runat="server" Text='<%#GetTotalMaterialQtyForEstimation(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["sub_mat_id"])%>'>
					                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>		                                                             
		                                                              </itemtemplate>
			                                                    </ItemTemplate>
			                                            </asp:TemplateColumn>
			                                            
			                                            <asp:TemplateColumn SortExpression="UOM" HeaderText="UOM" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblUOM" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.uom_type_desc")%>'>
																						    </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label id="lblUOM1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.uom_type_desc")%>'>
																						         </asp:Label>
																				    </EditItemTemplate>
													   </asp:TemplateColumn>
			                                            
			                                         
			                                            <asp:TemplateColumn HeaderText="Total Price" HeaderStyle-Font-Bold="True">
			                                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
			                                                    <ItemTemplate>
			                                                           <itemtemplate>
			                                                           <asp:Label id="lblTotalPrice" runat="server" Text='<%#GetTotalPrice(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["sub_mat_id"] , ((DataRowView)Container.DataItem)["PriceInProject"])%>'>
					                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>		                                                             
		                                                              </itemtemplate>
			                                                    </ItemTemplate>
			                                            </asp:TemplateColumn>
			                                            
			                                            <asp:TemplateColumn SortExpression="Verified" HeaderText="Verified?" HeaderStyle-Font-Bold="True">
				                                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                            <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                            <ItemTemplate>
					                                                    <asp:Label id="lblVerified" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Verified")%>'>
					                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                            </ItemTemplate>
				                                            <EditItemTemplate>
				                   	                                    <asp:RadioButtonList ID="chkVerified" runat="server" CssClass="form1" 
                                                                            RepeatDirection="Horizontal" ValidationGroup="editmode">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                                                       </asp:RadioButtonList>			                  
				                                            </EditItemTemplate> 
				                                    </asp:TemplateColumn>
				
				                                <asp:TemplateColumn SortExpression="Purchased" HeaderText="Purchased?" HeaderStyle-Font-Bold="True">
				                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                        <ItemTemplate>
					                                                <asp:Label id="lblPurchased" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Purchased")%>'>
					                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                        </ItemTemplate>
				                                        <EditItemTemplate>
				                   	                                <asp:RadioButtonList ID="chkPurchased" runat="server" CssClass="form1" 
                                                                        RepeatDirection="Horizontal" ValidationGroup="editmode">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                                                   </asp:RadioButtonList>			                  
				                                        </EditItemTemplate> 
				                                </asp:TemplateColumn>
				
				                                    <asp:TemplateColumn SortExpression="Received" HeaderText="Received?" HeaderStyle-Font-Bold="True">
				                                            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                                            <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                                            <ItemTemplate>
					                                                    <asp:Label id="lblReceived" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Received")%>'>
					                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                                            </ItemTemplate>
				                                            <EditItemTemplate>
				                   	                                    <asp:RadioButtonList ID="chkReceived" runat="server" CssClass="form1" 
                                                                            RepeatDirection="Horizontal" ValidationGroup="editmode">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                                                       </asp:RadioButtonList>			                  
				                                            </EditItemTemplate> 
				                                    </asp:TemplateColumn>
				
				
				
			                                             <asp:TemplateColumn SortExpression="matnotes" HeaderText="Notes" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblmatnotes" runat="server" width="250" Text='<%#DataBinder.Eval(Container, "DataItem.matnotes")%>'>
																						    </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id="txtmatnotes"   runat="server" Width="250px" Height="75px"  TextMode="MultiLine" MaxLength="1000"
																						        Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.matnotes") %>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						</asp:TextBox>
																				    </EditItemTemplate>
													   </asp:TemplateColumn>
													           		    
				                                        <asp:TemplateColumn HeaderText="Delete">
	                                                                <HeaderStyle Font-Bold="true" width="15%" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
	                                                                <ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
	                                                                <ItemTemplate>
		                                                             <%# DeleteMaterial(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["sub_mat_id"])%>
		                                                             </ItemTemplate>
		                                                    </asp:TemplateColumn>
		                                                    <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
															<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
															<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
															<ItemTemplate>
																<asp:LinkButton id="lnkbutEdit" runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
																	CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate>
																	<EditItemTemplate>
																            <asp:LinkButton id="lnkbutUpdate" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
																	            CommandName="Update"></asp:LinkButton>&nbsp;
																            <asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
																	            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
																	</EditItemTemplate>
															</asp:TemplateColumn>

				                                        </Columns>
				                                        <PagerStyle Mode="NumericPages"></PagerStyle>
			                                        </asp:datagrid>
			                                        </ContentTemplate>
			                                         <Triggers>
                                                        <asp:PostBackTrigger  ControlID="btnexport" />
                                                     </Triggers>
			                                        </asp:UpdatePanel>
											</TD>
										</TR>
									</TABLE>
                                    
                                    <!-- Material Listing for Estimation ends -->		        
								</td>

                            </tr>
                       </table>
                  </ContentTemplate>
              </ajaxToolkit:TabPanel>
<!--Materials-->
              
    <ajaxToolkit:TabPanel ID="tabestimate" runat="server" HeaderText="Estimate items">
                                                <ContentTemplate>
                                                    <table cellspacing="2" cellpadding="2" width="100%" height="400" bgcolor="WhiteSmoke">
                                                            <tr align="left" valign="top">
                                                                    <td>
                                                                            <SPAN class="header1">ESTIMATE</SPAN>&nbsp;
									                                        <SPAN class="header2">ITEMS</SPAN><br />
									                                        <button class="button" style="width:150px" id="btnWorkOrder" onclick="popupfunction('project_workorder.aspx');" type="button">Add Estimate Items</button>
									                                        <asp:UpdatePanel runat="server" id="UpdatePanel">
														                <ContentTemplate>
																		<asp:datagrid id="grdpl1" runat="server" Width="50%" CssClass="data" BackColor="#999999" ItemStyle-Wrap="False"
																			OnDeleteCommand="grdpl1_DeleteCommand" DataKeyField="work_order_id" OnCancelCommand="grdpl1_CancelCommand"
																			OnItemCommand="grdpl1_Itemcommand" OnItemDataBound="grd1_ItemDataBound" OnUpdateCommand="grdpl1_UpdateCommand" OnEditCommand="grdpl1_EditCommand" FooterStyle-Font-Name="Verdana"
																			FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
																			ItemStyle-BorderColor=ActiveBorder ItemStyle-BorderStyle=Solid  BorderColor=Black FooterStyle-BackColor="#D9D9D9"  ShowFooter="True" AutoGenerateColumns="False"
																			Font-Size="Smaller"  SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
																			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
																			<Columns>
																			
																			<asp:TemplateColumn HeaderImageUrl="assets/img/Search.gif">
					                                                            <HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
					                                                            <ItemTemplate>
						                                                            <asp:ImageButton ImageUrl="assets/img/Plus.gif" CommandName="Expand" ID="btnExpand" Runat="server"></asp:ImageButton>
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
																							CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate>
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
																			   <asp:TemplateColumn SortExpression="seq_id" HeaderText="Number" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblseq" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.work_order_id")%>'>
																						 
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																						        
																						<asp:HiddenField ID="hdntot_rate" runat="server"  Value='<%#DataBinder.Eval(Container, "DataItem.overheadrate")%>'></asp:HiddenField>
																					</ItemTemplate>
											    								</asp:TemplateColumn>
											    								
											    								 <asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True"
																					HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																					<asp:label id="lblLongDesc11" style="white-space: normal" Font-Size="Smaller" Font-Names="Verdana" runat="server"  BorderStyle=None BorderWidth=0 BackColor="#EAEFF3" Width="125px" Height="50px"   TextMode="MultiLine" MaxLength="1000"
																						        Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						</asp:label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id="txtLongDesc1" Font-Names="Verdana" runat="server" Width="125px" Height="50px"  MaxLength=50  Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																					</EditItemTemplate>
																				</asp:TemplateColumn>
																				
																				 <asp:TemplateColumn SortExpression="Notes" HeaderText="Notes" HeaderStyle-Font-Bold="True"
																					HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle  BackColor="#EAEFF3"  Wrap="true" Width="200" HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>																					    																					 
																					    <asp:label id="lblNotes" style="white-space: normal" Font-Size="Smaller" Font-Names="Verdana" runat="server"  
																					            BorderStyle=None BorderWidth=0  TextMode="MultiLine"
																					            BackColor="#EAEFF3" Width="300px" Height="50px" MaxLength="1000"
																						        Wrap=true Text='<%#DataBinder.Eval(Container, "DataItem.notes1")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						</asp:label>
																					</ItemTemplate>
																					<EditItemTemplate>
																					 
																						<asp:TextBox id="txtNotes"   runat="server" Width="275px" Height="50px"  TextMode="MultiLine" MaxLength="1000"
																						        Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.notes1") %>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						</asp:TextBox>
																					</EditItemTemplate>
																				    </asp:TemplateColumn>
																				    
																				    <asp:TemplateColumn SortExpression="reftext"  HeaderText="Reference" HeaderStyle-Font-Bold="True"
																					HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle BackColor="#EAEFF3" Wrap="true"  Width="150" HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:label id="lblref" style="white-space: normal" Font-Size="Smaller" Wrap=true Font-Names="Verdana" BackColor="#EAEFF3"   
																						                     BorderStyle=None BorderWidth=0 TextMode="Multiline"   runat="server" 
																						                    Width="150px" Height="50px" Text='<%#DataBinder.Eval(Container, "DataItem.reftext")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																						</asp:label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox id="txtref" runat="server" Width="150px" Height="50px" TextMode="MultiLine" MaxLength=1000 Wrap=True Text='<%# DataBinder.Eval(Container, "DataItem.reftext") %>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																					</EditItemTemplate>
																				    </asp:TemplateColumn>		
	
																				  <asp:TemplateColumn SortExpression="Engineering Hours" HeaderText="Engineering Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblEnghours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.eng_hours")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtEngHours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.eng_hours") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfrEngHours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtEngHours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalEngHours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtEngHours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
																							</EditItemTemplate> 
																					</asp:TemplateColumn>
																					
																					<asp:TemplateColumn SortExpression="Fabrication Hours" HeaderText="Fabrication Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblfabhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.fab_hours")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtfabhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fab_hours") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvfabhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtfabhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalfabhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtfabhours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></EditItemTemplate>
																					</asp:TemplateColumn>
																					
																					<asp:TemplateColumn SortExpression="Finishing Hours" HeaderText="Finishing Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblfinhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.fin_hours")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtfinhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fin_hours") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvfinhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtfinhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalfinhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtfinhours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
																					</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn SortExpression="Install hours" HeaderText="Install Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblinstallhours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.install_hours")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtinstallhours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.install_hours") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtinstallhours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalinstallhours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtinstallhours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn SortExpression="misc_hours" HeaderText="Misc Hours" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblMiscHours" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.misc_hours")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtMiscHours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.misc_hours") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvMiscHours" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtMiscHours"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalMiscHours" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtMiscHours" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></EditItemTemplate>
																				   </asp:TemplateColumn>
																				   
																				    <asp:TemplateColumn SortExpression="total_labor" HeaderText="Total Labor" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblTotlabor" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.total_labor")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
											    								   </asp:TemplateColumn>
											    								   
																					<asp:TemplateColumn SortExpression="Material Cost" HeaderText="Material Cost" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblMatCost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.tot_mat_cost")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtMatCost" runat="server" ReadOnly=true Text='<%# DataBinder.Eval(Container, "DataItem.tot_mat_cost") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						<asp:RequiredFieldValidator id="rfvMatCost" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							ControlToValidate="txtMatCost"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="revalMatCost" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							ControlToValidate="txtMatCost" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
																							</EditItemTemplate>
																				    </asp:TemplateColumn>
																				    
																				    
																				    <asp:TemplateColumn SortExpression="TotContengency" HeaderText="Contigency" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblContigency" runat="server"> </asp:Label>
																					    </ItemTemplate>
											    								    </asp:TemplateColumn>
											    								   
											    								    
											    								    <asp:TemplateColumn SortExpression="cont_disp"  HeaderText="Contigency Dispersement" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblContDisp" runat="server"> </asp:Label>
																					    </ItemTemplate>
											    								    </asp:TemplateColumn>
											    								    
											    								     <asp:TemplateColumn SortExpression="ContPlusMaterial" HeaderText="Total Material + Contigency" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblMatPlusCont" runat="server"> </asp:Label>
																					    </ItemTemplate>
											    								    </asp:TemplateColumn>
											    								    
											    								     <asp:TemplateColumn SortExpression="Overhead" HeaderText="Overhead" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lbloverhead" runat="server"> </asp:Label>
																					    </ItemTemplate>
											    								    </asp:TemplateColumn>
											    								    
											    								    
											    								     <asp:TemplateColumn SortExpression="Profit" HeaderText="Profit" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblProfit" runat="server"> </asp:Label>
																					    </ItemTemplate>
											    								    </asp:TemplateColumn>
											    								    
											    								     <asp:TemplateColumn SortExpression="SellPrice" HeaderText="Sell Price" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblSellPrice" runat="server"> </asp:Label>
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
									                                                                <asp:textbox class="title" id="txtSelectionResultsMSG" Text="Sub Material for WorkOrder" runat="server" Width="100%" BorderStyle="None"	BorderWidth="0px"></asp:textbox><br />									                                                            
										                                                           <uc1:workordermaterial id="DynamicTable1" runat="server"></uc1:workordermaterial>
									                                                            </td>
									                                                            
								                                                            </tr>
							                                                            </table>
						                                                            </asp:PlaceHolder>
					                                                            </ItemTemplate>
				                                                            </asp:TemplateColumn>
				
																			  </Columns><PagerStyle Mode="NumericPages"></PagerStyle>
																		</asp:datagrid>
																		</ContentTemplate>
																		</asp:UpdatePanel>
																	</TD>
																</TR>
                                                           
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel><!--Estimate Items-->
                          
    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Contingencies">
                  <ContentTemplate>
                       <table cellspacing="2" cellpadding="2" width="100%"  height="400" bgcolor="WhiteSmoke" border="1">
                            <tr>
                                <td valign="top">
                                    <table>
                                        <tr>
                                            <td>
                                                <SPAN class="header1">Contingencies</SPAN><br />
                                            </td>
                                        </tr>
                                                    <tr>
														     <td align="left" valign="top" colspan="5" >
                                                               <!-- Data Grid for Quals go here -->
                                                                <asp:UpdatePanel runat="server" id="updcont">
														        <ContentTemplate>
                                                               <asp:datagrid id="grdContingency" runat="server" CssClass="data" Width="100%" 
                                                                    OnItemCreated="ResultGridItemCreated"
				                                                    OnCancelCommand="grdContingency_CancelCommand" 
				                                                    OnItemDataBound="grdContingency_ItemDataBound" 
				                                                    OnUpdateCommand="grdContingency_UpdateCommand" 
				                                                    OnEditCommand="grdContingency_EditCommand" 
				                                                    OnDeleteCommand="grdContingency_DeleteCommand" 
				                                                    OnPageIndexChanged="PageResultGrid2" 
				                                                    AllowPaging="false" 
				                                                    AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                     ShowFooter="True" CellPadding="3" DataKeyField="sub_contingency_id">
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
					                                                    
						                                                    <asp:TemplateColumn SortExpression="group_name" HeaderText="Type" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblgroup_name" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.group_name")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label Width="30" id="txtgroup_name" runat="server" ReadOnly=true Text='<%# DataBinder.Eval(Container, "DataItem.group_name") %>' >
																						</asp:Label>
																					</EditItemTemplate>
																			</asp:TemplateColumn>	
																			
						                                                    	
						                                                    <asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.description")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label Width="150" id="txtDescription" runat="server" ReadOnly=true Text='<%# DataBinder.Eval(Container, "DataItem.description") %>' >
																						</asp:Label>
																					</EditItemTemplate>
																			</asp:TemplateColumn>	
						                                                    
						                                                     <asp:TemplateColumn SortExpression="UOM" HeaderText="UOM" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lbluom" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UOM")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:Label Width="30" id="txtuom" runat="server" ReadOnly=true Text='<%# DataBinder.Eval(Container, "DataItem.UOM") %>' >
																						</asp:Label>
																					</EditItemTemplate>
																			</asp:TemplateColumn>	
						                                                    	
						                                                   <asp:TemplateColumn SortExpression="Cost" HeaderText="Cost" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblCost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.cost")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtcost" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.cost") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						    <asp:RequiredFieldValidator id="rfvtxtcost" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							    ControlToValidate="txtcost"></asp:RequiredFieldValidator>
																							<asp:RegularExpressionValidator id="revalMatCost" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							    ControlToValidate="txtcost" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
																					</EditItemTemplate>
																			</asp:TemplateColumn>	
																			
																			<asp:TemplateColumn SortExpression="Qty" HeaderText="Qty" HeaderStyle-Font-Bold="True">
																					<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label id="lblqty" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.qty")%>'>
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
																					</ItemTemplate>
																					<EditItemTemplate>
																						<asp:TextBox Width="30" id="txtqty" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.qty") %>' >
																						        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
																						    <asp:RequiredFieldValidator id="rfvqty" runat="server" Display="Dynamic" ErrorMessage="Please enter a number"
																							    ControlToValidate="txtqty"></asp:RequiredFieldValidator>
																							<asp:RegularExpressionValidator id="revalqty" runat="server" Display="Dynamic" ErrorMessage="Please use only numbers"
																							    ControlToValidate="txtqty" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
																					</EditItemTemplate>
																			</asp:TemplateColumn>	
																			
																			 <asp:TemplateColumn SortExpression="Total Cost" HeaderText="Total Cost" HeaderStyle-Font-Bold="True">
																					    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:Label id="lblTotCost" runat="server"> </asp:Label>
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
																							CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate>
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                                   </asp:datagrid> 
				                                                   </ContentTemplate>
				                                                   </asp:UpdatePanel>
									                        </td>
														</tr>
                                           <tr>
                                            <td style="text-align: right;"  colspan="3">Total Contigency Cost:</td><td style="text-align: right;  background-color: Yellow">
                                            <asp:TextBox ID="txtTotCont" ValidationGroup="Tabcont" MaxLength="15" Width="70px" runat="server"></asp:TextBox>
                                            
                                            <br>
        									<button class="button" style="width:175px" id="Button8" 
                                            onclick="popupfunction('newcontingencytoProject.aspx');" type="button">Add New Contingency to Project</button>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                            <asp:button id="btnContengency" runat="server" ValidationGroup="Tabcont" Text="Save Changes" CssClass="button" 
                                                                            onclick="btncon_Click"></asp:button>
                                            </td>
                                         </tr> 
                                    </table>
                                </td>
                            </tr>
                       </table>
                  </ContentTemplate>
              </ajaxToolkit:TabPanel><!--Contingencies-->
                          
    <ajaxToolkit:TabPanel ID="tabworkorder" runat="server" HeaderText="Terms">
                                                <ContentTemplate>
                                                    <table align='center' cellspacing="2" cellpadding="2" width="100%" height="400" bgcolor="WhiteSmoke">
                                                        <tr align="left" valign="top">
                                                            <td>
                                                                    <SPAN class="header1">Terms & Conditions</SPAN><BR>
									                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
									                    </tr>
									                    <tr>
														     <td align="left" valign="top">
                                                               <!-- Data Grid for Quals go here -->
                                                               <asp:UpdatePanel runat="server" id="updTermsConditions">
														        <ContentTemplate>
                                                               <asp:datagrid id="grdTerms" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
				                                                    OnDeleteCommand="grdTerms_DeleteCommand" OnPageIndexChanged="PageResultGrid2" AllowPaging="False" 
				                                                    AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="sub_terms_id">
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
						                                                    <asp:BoundColumn DataField="group_name" SortExpression="group_name" HeaderText="Type" HeaderStyle-Font-Bold="true">
						                                                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                    <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                    </asp:BoundColumn>
						                                                    <asp:BoundColumn DataField="description" SortExpression="description" HeaderText="Description">
							                                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                    <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                    </asp:BoundColumn>														                                    
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                                   </asp:datagrid> 
				                                                  </ContentTemplate>
				                                                  </asp:UpdatePanel> 
									                        </td>
														</tr>
														
														<tr>
															    <td>
															            <button class="button" style="width:175px" id="btnAddNewTerm" 
                                                                                onclick="popupfunction('newconditionstoProject.aspx');" type="button">Add New Terms to Project</button>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
																	    <asp:button id="Button3" runat="server" Visible=false ValidationGroup="TabGroup4" Text="Save Changes" CssClass="button" 
                                                                            onclick="btnconsider_Click"></asp:button>&nbsp;&nbsp;
															    </td>
														</tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel><!--Terms-->
                                            
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Qualifications">
                                                <ContentTemplate>
                                                    <table align='center' cellspacing="2" cellpadding="2" width="100%" height="400" bgcolor="WhiteSmoke">
                                                        <tr align="left" valign="top">
                                                                <td>
                                                                    <SPAN class="header1">Qualifications</SPAN><BR>
									                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>									                            
									                    </tr>
									                    <tr>
														      <td align="left" valign="top">
                                                               <!-- Data Grid for Quals go here -->
                                                                 <asp:UpdatePanel runat="server" id="upanelQUal">
								                                    <ContentTemplate>
                                                               <asp:datagrid id="grdQuals" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
				                                                     OnDeleteCommand="grdQuals_DeleteCommand" OnPageIndexChanged="PageResultGrid2" AllowPaging="False" 
				                                                     AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="sub_qual_id" >
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
						                                                            <asp:BoundColumn DataField="gName1" SortExpression="gName1" HeaderText="Type" HeaderStyle-Font-Bold="true">
						                                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>
						                                                            <asp:BoundColumn DataField="description" SortExpression="description" HeaderText="Description">
							                                                            <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>														                                    
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                                   </asp:datagrid> 
				                                                    </ContentTemplate> 
				                                                    </asp:UpdatePanel>                                                               
									                        </td>
														</tr>
														
														<tr>
															    <td>
															        <button class="button" style="width:175px" id="btnNewAddQual" 
                                                                                onclick="popupfunction('newqualstoProject.aspx');" type="button">Add New Qualification to Project</button>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
																	    <asp:button id="Button4" runat="server" Visible=false ValidationGroup="TabGroup5" Text="Save Changes" CssClass="button" 
                                                                            onclick="btnqual_Click"></asp:button>&nbsp;&nbsp;
															    </td>
														</tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel><!--Qualifications-->
                                            
    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Log">
                                                <ContentTemplate>
                                                    <table align='center' cellspacing="2" cellpadding="2" width="100%" height="400" bgcolor="WhiteSmoke">
                                                        <tr align="left" valign="top">
                                                            <td>
                                                                    <SPAN class="header1">Log</SPAN><BR>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
									                    </tr>
									     									                    <tr>
									                               
									                                <td class="form1" >Comments Date:<br />
															            <asp:TextBox ID="txtcmtsDate" ValidationGroup="TabGroup6" runat="server" MaxLength="17" Width="150px"></asp:TextBox><asp:ImageButton runat="server"  ID="ImgcmtsDate1"  
                                                                            ImageUrl="assets/img/calendar.gif"  ValidationGroup="TabGroup6"
                                                                            AlternateText="Click here to display calendar" />
    														            <ajaxToolkit:CalendarExtender ID="CalendarExtender1Date" runat="server" 
                                                                            Format="MM/dd/yyyy" TargetControlID="txtcmtsDate"  
                                                                            PopupButtonID="ImgcmtsDate1" Enabled="True"/>
															                <br /><br />Comments Time:<br />															        															           
															                <asp:TextBox ID="txtcmtsTime" ValidationGroup="TabGroup6" runat="server" MaxLength="8"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="mExtCmtsTime" runat="server" Mask="99:99:99" 
                                                                            MaskType="Time" AcceptAMPM="True" TargetControlID="txtcmtsTime" 
                                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"></ajaxToolkit:MaskedEditExtender>


                                                                            <ajaxToolkit:MaskedEditValidator ID="mValcmtsTime" runat="server" 
                                                                            ControlExtender="mExtCmtsTime" ControlToValidate="txtcmtsTime"
                                                                                Display="None" EmptyValueMessage="Time is required" 
                                                                            InvalidValueMessage="Valid Bid Time in HH:MM" TooltipMessage="Input a time" 
                                                                            ErrorMessage="mValcmtsTime"></ajaxToolkit:MaskedEditValidator></td><td rowspan="8" valign="top" >														     
                                                                    Conversation Log History:<br />
                                                                    <asp:datagrid id="grdConvHist" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
								                                    PageSize="100" OnPageIndexChanged="PageResultGrid3" AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
								                                    CellPadding="3">
								                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
								                                    <Columns>
									                                    <asp:BoundColumn DataField="LastModifiedBy" SortExpression="LastModifiedBy" HeaderText="User Name" HeaderStyle-Font-Bold="true">
										                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="50px" ></ItemStyle>
									                                    </asp:BoundColumn>
									                                    <asp:BoundColumn DataField="LastModifiedDate" SortExpression="LastModifiedDate" HeaderText="Conversation Date">
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="65px" HorizontalAlign="Center" ></ItemStyle>
									                                    </asp:BoundColumn>		
									                                    <asp:BoundColumn DataField="LastModifiedTime" SortExpression="LastModifiedTime" HeaderText="Conversation Time">
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="65px" HorizontalAlign="Center" ></ItemStyle>
									                                    </asp:BoundColumn>												                                    
									                                    <asp:BoundColumn DataField="comments" SortExpression="comments" HeaderText="Conversation" >
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Wrap="true" Width="350px" ></ItemStyle>
									                                    </asp:BoundColumn>
								                                    </Columns>
								                                    <PagerStyle Mode="NumericPages"></PagerStyle>
												                   </asp:datagrid>
                                                                   <br />
                                                                   <asp:datagrid id="grdEmailLog" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
								                                    PageSize="100" OnPageIndexChanged="PageResultGrid3" AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
								                                    CellPadding="3">
								                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
								                                    <Columns>

                                                                       <asp:BoundColumn DataField="LastModifiedBy" SortExpression="LastModifiedBy" HeaderText="Contact Name" HeaderStyle-Font-Bold="true">
										                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="50px" ></ItemStyle>
									                                    </asp:BoundColumn>
									                                    <asp:BoundColumn DataField="emailid" SortExpression="emailid" HeaderText="Sent EMail Address" HeaderStyle-Font-Bold="true">
										                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="50px" ></ItemStyle>
									                                    </asp:BoundColumn>
                                                                         <asp:BoundColumn DataField="comments" SortExpression="comments" HeaderText="comments">
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="65px" HorizontalAlign="Center" ></ItemStyle>
									                                    </asp:BoundColumn>	
									                                    <asp:BoundColumn DataField="LastModifiedDate" SortExpression="LastModifiedDate" HeaderText="Email Date">
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="65px" HorizontalAlign="Center" ></ItemStyle>
									                                    </asp:BoundColumn>		
									                                    <asp:BoundColumn DataField="LastModifiedTime" SortExpression="LastModifiedTime" HeaderText="Email Time">
										                                    <HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
										                                    <ItemStyle BackColor="#EAEFF3" Width="65px" HorizontalAlign="Center" ></ItemStyle>
									                                    </asp:BoundColumn>	                                                                  
                                                                        
                                                                        											                                    
								                                    </Columns>
								                                    <PagerStyle Mode="NumericPages"></PagerStyle>
												                   </asp:datagrid>
									                        </td><!--test column-->                                                                             
                                                                            
                                                                            </tr><tr>
														     <td>
                                                                    Enter your comment:<br />
                                                                    <asp:textbox id="txtconversation" ValidationGroup="TabGroup6" runat="server" TextMode="MultiLine" Rows="10" cols="100"  Wrap="true" Width="400px"></asp:textbox></td><td vAlign="top" width="10"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="10"></TD><td vAlign="top" width="100"><IMG height="1" alt="" Src="assets/img/spacer.gif" width="100"></TD></tr><tr>
															    <td>
																	    <asp:button id="btnConvLog" runat="server" ValidationGroup="TabGroup6" Text="Save your comment" CssClass="button" 
                                                                            onclick="btnconv_Click"></asp:button>&nbsp;&nbsp;
															    </td>
														</tr>
														<tr>
														     <td>

														</tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel><!--Conversation Log-->
                                            
    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Project Documents">
             <ContentTemplate>
                   <table align=center width="100%" height="400" bgcolor="WhiteSmoke" border="1" >
                        <tr>
             <td width="33%" align="center" valign="top"> 
                <table width="100%" valign="top">
                        <tr align="center" valign="top">
                            <td >
                                <SPAN class="header1">Project Documents</SPAN><BR>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

	                    </tr>
			            
			            <tr>
	                        <td class="form1" style="color: Maroon" align="left" valign="top">Document Type:<br/>	                                                           
		                        <asp:dropdownlist id="ddlDocType" ValidationGroup="TabGroup7" runat="server"></asp:dropdownlist>
		                        <asp:RequiredFieldValidator ID="resubject" ControlToValidate="ddlDocType" InitialValue="" ForeColor="White" 
		                        Font-Bold="true" Display="Static" runat="server">*Document type is required</asp:RequiredFieldValidator></td><td class="form1" style="color: Maroon" align="left" valign="top">Download document:<br/>
                                <asp:FileUpload ID="FileUpload1" runat="server"/>
                                <asp:RequiredFieldValidator ID="reqmessage" ValidationGroup="TabGroup7"   ControlToValidate="FileUpload1" ForeColor="Maroon" 
                                Font-Bold="true" Display="Static" runat="server">*document is required.</asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                id="regfileupload" runat="server"  ValidationGroup="TabGroup7" ForeColor="Maroon" Font-Bold="true" Display="Static"
                                ErrorMessage="Only doc, docx or pdf,excel, gif or jpg files are allowed!" 
                                ValidationExpression="[a-zA-Z\\].*(.doc|.DOC|.docx|.DOCX|.pdf|.PDF|.jpg|.gif|.xls|.xlsx|.XLSX)$" 
                                ControlToValidate="FileUpload1"></asp:RegularExpressionValidator></td></tr><tr>
				            <td align="left">
					            <asp:button id="Button5" runat="server" ValidationGroup="TabGroup7" Text="Upload Document" CssClass="button" 
                                onclick="btnupload_Click"></asp:button>&nbsp;&nbsp;
				            </td>
			            </tr>
						
						<tr>
							<td align="left" colspan="2">
                               Project Documents:<br />
                                 <asp:datagrid id="grddocs" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
								         OnPageIndexChanged="PageResultGriddocs" AllowPaging="false" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
								         CellPadding="3">
								         <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
								         <Columns>
									    <asp:BoundColumn DataField="doc_Type_Desc" SortExpression="doc_Type_Desc" HeaderText="Type" HeaderStyle-Font-Bold="true">
									    <HeaderStyle width="15%" HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
									    <ItemStyle width="15%" BackColor="#EAEFF3"></ItemStyle>
									    </asp:BoundColumn>
    									                                     
                                        <asp:TemplateColumn HeaderText="Document">
	                                    <HeaderStyle Font-Bold="true" width="15%" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
	                                    <ItemStyle width="70%" HorizontalAlign="Left" BackColor="#EAEFF3"></ItemStyle>
	                                    <ItemTemplate>
		                                <%# Showdocument(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["seq_num"],((DataRowView)Container.DataItem)
		                                ["doc_name"])%></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="Delete">
	                                    <HeaderStyle Font-Bold="true" width="15%" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
	                                    <ItemStyle width="15%" HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
	                                    <ItemTemplate>
		                                 <%# DeleteDocument(((DataRowView)Container.DataItem)["EstNum"], ((DataRowView)Container.DataItem)["seq_num"])
		                                 %></ItemTemplate></asp:TemplateColumn></Columns><PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
							</td>
						</tr>
                            </table>
             </td>
             <td width="33%" align="center" valign="top">          
                <table width="100%" valign="top">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                                         <td align="left" valign="top" width="100%">
                                                             <SPAN class="header1">Contract Documents List</SPAN><BR>
                                                                <button class="button" style="width:100px" id="Button9" 
                                                                                onclick="popupfunction('add_drawing_list.aspx');" type="button">Add Document</button>
                                                               <br />
                                                               <!-- Data Grid for Quals go here -->
                                                               <asp:datagrid id="grdDrawingList" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                                     OnDeleteCommand="grdDrawingList_DeleteCommand" OnPageIndexChanged="PageResultGrid2" AllowPaging="false" 
				                                                     AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="idnumber" >
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
						                                                            <asp:BoundColumn DataField="type" SortExpression="type" HeaderText="Type" HeaderStyle-Font-Bold="true">
						                                                                <HeaderStyle width="10%" HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>
						                                                            <asp:BoundColumn DataField="doc_name" SortExpression="doc_name" HeaderText="Name">
							                                                            <HeaderStyle width="60%" HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>	
						                                                            
						                                                            <asp:BoundColumn DataField="doc_number" SortExpression="doc_number" HeaderText="Page">
							                                                            <HeaderStyle width="10%" HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>
						                                                            
						                                                            <asp:BoundColumn DataField="revision" SortExpression="revision" HeaderText="Rev">
							                                                            <HeaderStyle width="5%" HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center"></ItemStyle>
						                                                            </asp:BoundColumn>	
						                                                            
						                                                             <asp:BoundColumn DataField="doc_date" SortExpression="doc_date" HeaderText="Date">
							                                                            <HeaderStyle width="10%" HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							                                                            <ItemStyle BackColor="#EAEFF3"></ItemStyle>
						                                                            </asp:BoundColumn>	
						                                                            
						                                                            												                                    
						                                                            <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
																					    <HeaderStyle width="5%" HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
																					    <ItemTemplate>
																						    <asp:LinkButton id="lnkbutDelete" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
																							    CommandName="DELETE" CausesValidation="false">
																					        </asp:LinkButton>
																					     </ItemTemplate>
																			        </asp:TemplateColumn>
						                                                    </Columns>
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                                   </asp:datagrid>
				                                                   <br />
				                                                    Architect Drawing Date:(Click Save and Refresh after Entering)<br /> <!--Architecture Drawing Date -->
					                                                    <asp:TextBox ID="txtDrawingDt" runat="server" MaxLength="10" Width="125px"></asp:TextBox>
					                                                    <asp:ImageButton runat="server"  ID="imgDrawingDt"
					                                                    ImageUrl="assets/img/calendar.gif"  ValidationGroup="TabGroup1"
                                                                        AlternateText="Click here to display calendar" />
                                                                        <ajaxToolkit:CalendarExtender ID="CalDrawingDt" runat="server" 
                                                                        Format="MM/dd/yyyy" TargetControlID="txtDrawingDt"  
                                                                        PopupButtonID="imgDrawingDt" Enabled="True"/> 
                                                                        &nbsp;&nbsp;<asp:button id="btnDrawingDate" style="width:100px" runat="server"  Text="Save/Refresh" CssClass="button" 
                                                                        onclick="btnDrawingDate_Click"></asp:button>
									                        </td> 
                               </tr>
                            </table>
                        </td>
                   </tr>
               </table>
               </td>
               <td width="33%" align="center" valign="top"> 
                <table width="100%" valign="top">
                    <tr>
                         <td>
                            <table width="100%">
                                <tr>
                                    <SPAN class="header1">Change Document Listing</SPAN><BR>
                                     <td align="left" valign="top">
                                                               <!-- Data Grid for Quals go here -->
                                                                <button class="button" style="width:175px" id="Button10" 
                                                                                onclick="popupfunction('add_amendments.aspx');" type="button">Add Change Document</button>
                                                               <br />
                                                               <asp:UpdatePanel runat="server" id="updAmendment">
								                                <ContentTemplate>
                                                               <asp:datagrid id="grdAmendments" runat="server" CssClass="data" Width="100%" OnItemCreated="ResultGridItemCreated"
				                                                     OnDeleteCommand="grdAmendments_DeleteCommand" OnPageIndexChanged="PageResultGrid2" AllowPaging="false" 
				                                                     AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				                                                    CellPadding="3" DataKeyField="idNum" 
                                                                    OnCancelCommand="grdAmendments_CancelCommand" 
	  		                                                        OnUpdateCommand="grdAmendments_UpdateCommand" 
				                                                    OnEditCommand="grdAmendments_EditCommand" 
                                                                    >
				                                                    <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					                                                      <Columns>
                                                                                    <asp:TemplateColumn SortExpression="type" HeaderText="Type" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblamendment_type" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.type")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:dropdownList ID="ddlamendment_type" runat="server" Width="100"
				                                                                                    DataSource="<%#Bindamendment_types()%>" 
                                                                                                    DataTextField="value"
                                                                                                    DataValueField="key">
                                                                                                </asp:dropdownList>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	                                                                                   


                                                                                     <asp:TemplateColumn SortExpression="amendment_number" HeaderText="Amendment number" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblamendment_number" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.amendment_number")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtamendment_number"   runat="server" Width="60px" Height="75px"
                                                                                                      Text='<%# DataBinder.Eval(Container, "DataItem.amendment_number") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	 
                                                                                     						                                                            
                                                                                     <asp:TemplateColumn SortExpression="amendment_date" HeaderText="Date" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblamendment_date" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.amendment_date")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtamendment_date"   runat="server" Width="60px" Height="75px"
                                                                                                      Text='<%# DataBinder.Eval(Container, "DataItem.amendment_date") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	 

				                                                            
								                                                     
                                                                                      <asp:TemplateColumn SortExpression="amendment_impact" HeaderText="Impact" HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblamendment_impact" runat="server" width="60" Text='<%#DataBinder.Eval(Container, "DataItem.amendment_impact")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtIamendment_impact"   runat="server" Width="60px" Height="75px"
                                                                                                      Text='<%# DataBinder.Eval(Container, "DataItem.amendment_impact") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
																			         </asp:TemplateColumn>	 

                                                                                      <asp:TemplateColumn SortExpression="Notes" HeaderText="Desc." HeaderStyle-Font-Bold="True">
																					        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
																					        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>    
																				             <itemtemplate>
																						        <asp:Label id="lblInotes" runat="server" width="100" Text='<%#DataBinder.Eval(Container, "DataItem.notes")%>'>
																						        </asp:Label>
																					        </itemtemplate>
																					        <edititemtemplate>
																						         <asp:textbox id="txtInotes"   runat="server" Width="100px" Height="75px"  TextMode="MultiLine" MaxLength="1000"
																						                Wrap="true" Text='<%# DataBinder.Eval(Container, "DataItem.notes") %>'>
																	         			        </asp:textbox>
																				            </edititemtemplate>
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
																							CommandName="Cancel" CausesValidation="false"></asp:LinkButton></EditItemTemplate>
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
						                                                    <PagerStyle Mode="NumericPages"></PagerStyle>
				                                                   </asp:datagrid>  
                                                                   </ContentTemplate>
                                                                   </asp:UpdatePanel>                                                                
									                        </td> 
									  </tr>
						        </table>
						     </td> 
						  </tr>
				    </table>
				</td>                                   
             </ContentTemplate>
        </ajaxToolkit:TabPanel><!--Project Documents-->
       
  
  </ajaxToolkit:TabContainer>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label></td></tr></table>
                    <script type="text/javascript" language="javascript">
                var theForm = document.forms[0];
                window.name = 'IEAdvanceQueue';
                var agreewin = "";

                function popupproposal(url) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var parameters = "?EstNum=" + myTextField.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Estimation", "width=900px,height=600px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                
                function popupfunction(url) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var parameters = "?EstNum=" + myTextField.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Estimation", "width=650px,height=600px,center=0,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }

                function popupMaterial(url) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var parameters = "?EstNum=" + myTextField.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Materials", "width=800px,height=650px,center=0,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                function popupprocess(url,id) {
                    var pageName = url;
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    var parameters = "?id=" + id + "&EstNum=" + myTextField.value;
                    url = pageName + parameters
                    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Maintenance", "width=550px,height=400px,center=1,resize=1,scrolling=0", "recal")
                    agreewin.onclose = function() { //Define custom code to run when window is closed
                        return true //Allow closing of window in both cases
                    }
                }
                function calcLaborTotal() {
                    var val1 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtEngTotal').value;
                    var val2 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtFabTotal').value;
                    var val3 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtInsTotal').value;
                    var val4 = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMiscTotal').value;
                    var val5 = Number(val1) + Number(val2) + Number(val3) + Number(val4);
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate');
                    myTextField.value = val5.toString();
                    document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotSellPrice').innerHTML = (Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotalOverHeadProfit').innerHTML)).toString();

                }
                function calcMarkUpPercent() {

                    //Overhead = (Total Labor + total Material + Contingency)* Overhead percent
                    var val1 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtEngQty').value);
                    var val2 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtFabQty').value);
                    //var val3 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtInstQty').value);
                    var val4 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMiscQty').value);
                    //var val1 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value);
                    //var val2 = N/mber(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value);
                    var valOHRate = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtOverHeadRate').value);

                    //var valOHRate = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOHPercent').value);

                    var valOHTotal = (val1 + val2 + val4) * valOHRate;
                   // alert(val1);
                   // alert(val2);
                   // alert(valOHRate);                    
                   // var valOHTotal = (val1 + val2) * (valOHRate/100);
                    
                    valOHTotal = valOHTotal.toFixed(2);
                    document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOverHeadTotal').innerHTML = valOHTotal.toString();
                    MarkUpTotal();
                    document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotSellPrice').innerHTML = (Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotalOverHeadProfit').innerHTML)).toString();

               }
               function MarkUpTotal() {
                   //lblOHPercent.Text = ((Convert.ToDecimal(lblOverHeadTotal.Text) / (Convert.ToDecimal(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text))) * 100).ToString("#.##");
                   var Markup1;
                   var markup2;
                   var val1 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value);
                   var val2 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value);
                   var val3 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOverHeadTotal').innerHTML);
                   Markup1 = val1 + val2;
                   markup2 = val3;
                   var Markup = (markup2 / Markup1) * 100;
                   Markup = Markup.toFixed(2);
                   document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOHPercent').innerHTML = Markup.toString();

               }
               function MarkupPctTotal() {
                   var totrate;
                   var matconttotal;
                   var overheadtotal;
                   var val1 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value);
                   var val2 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value);
                   var val3 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOverHeadTotal').innerHTML);
                   var markupPct;
                   var markupPct = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMarkUpPercent').value);
                   var markuptotal = (markupPct/100) * (val1 + val2 + val3);
                   markuptotal = markuptotal.toFixed(2);
                   document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblProfitTotal').innerHTML = markuptotal.toString();
      
                   var overheadProfitTotal;
                   var overheadMarkupTotal;
                   overheadMarkupTotal = markupPct + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOHPercent').innerHTML);
                   overheadMarkupTotal = overheadMarkupTotal.toFixed(2);
                   var val4 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblOverHeadTotal').innerHTML);
                   var val5 = Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblProfitTotal').innerHTML);
                   
                   document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotalOverHeadProfitPercent').innerHTML = overheadMarkupTotal.toString();
                   overheadProfitTotal = val4 + val5;
                   overheadProfitTotal = overheadProfitTotal.toFixed(2);

                   document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotalOverHeadProfit').innerHTML = overheadProfitTotal.toString();

                   document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotSellPrice').innerHTML = (Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtTotRate').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_txtMatContTotal').value) + Number(document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabconsideration_lblTotalOverHeadProfit').innerHTML)).toString();
                   //lblTotSellPrice.Text = (Convert.ToInt32(txtTotRate.Text) + Convert.ToInt32(txtMatContTotal.Text) + Convert.ToDecimal(lblTotalOverHeadProfit.Text)).ToString();
               }
                function showdocument(EstNum, seqNumber) {
                    window.open('view_document.aspx?EstNum=' + EstNum + '&seqno=' + seqNumber, 'form', 'width=470,height=452,left=10,top=163,location=no, menubar=no,status=no,toolbar=no,scrollbars=no,resizable=yes');
                }
                function Deletedocument(EstNum, seqNumber) {
                    var pageName = "whitfield_estimation.aspx";
                    var parameters = "?EstNum=" + EstNum + "&seqno=" + seqNumber  + "&hFlag=D";
                    var result = null;
                    if (confirm("Are you sure want to delete this document?")) {
                        url = pageName + parameters
                        location.href = url;
                        return;
                    }
                    //window.open('whitfield_estimation.aspx?EstNum=' + EstNum + '&seqno=' + seqNumber, 'form', 'width=470,height=452,left=10,top=163,location=no, menubar=no,status=no,toolbar=no,scrollbars=no,resizable=yes');
                }
                function DeleteMaterial(EstNum, submatid) {
                    var pageName = "whitfield_estimation.aspx";
                    var parameters = "?EstNum=" + EstNum + "&submatid=" + submatid + "&hFlag=DMaterial";
                    var result = null;
                    if (confirm("Are you sure want to delete this Submaterial from this Estimate?")) {
                        url = pageName + parameters
                        location.href = url;
                        return;
                    }
                }
                function popupfunctionthis(url) {
                    var pageName = url;
                    //var myTextField = document.getElementById('hdnEstNum');
                    alert(url);
                    
                    //var myTextField1 = document.getElementById('hdnworkorderNumber');
                   // var parameters = "?EstNum=" + myTextField.value;
                   // url = pageName + parameters
                   // agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Project Estimation", "width=900px,height=600px,center=1,resize=1,scrolling=0", "recal")
                   // agreewin.onclose = function() { //Define custom code to run when window is closed
                   //     return true //Allow closing of window in both cases
                   // }
                }
                function printProposal(IsFinancial) {
                    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_tabgeneral_tabGenInfo_hdnEstNum');
                    window.open('Whitfield_proposalGeneration.aspx?EstNum=' + myTextField.value + '&IsFinancial=' + IsFinancial, 'form', 'width=500,height=500,left=10,top=163,location=no, menubar=no,status=no,toolbar=no,scrollbars=no,resizable=yes');
                }
                
                //DeleteMaterials
            </script></div></asp:Content>