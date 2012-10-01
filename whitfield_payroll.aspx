<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="whitfield_payroll.aspx.cs" Inherits="whitfield_payroll" %>
<%@ Register TagPrefix="uc1" TagName="Whitfield_Payroll_ByEmployee" Src="Whitfield_Payroll_ByEmployee.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Whitfield_Payroll_ByProject" Src="Whitfield_Payroll_ByProject.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:UpdatePanel ID="UpdatePanelPayroll" runat="server">    
<contenttemplate> 
<table bgcolor="WhiteSmoke" border="0" width="100%">
    <tr>
        <td class="form1" style="width:100%" >
            Report From Date:
            <asp:TextBox ID="txtFromDate" runat="server" align="center" MaxLength="30" 
                ValidationGroup="Tabreport" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" 
                AlternateText="Click here to display calendar" 
                ImageUrl="assets/img/calendar.gif" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                Enabled="True" Format="MM/dd/yyyy" PopupButtonID="ImageButton1" 
                TargetControlID="txtFromDate">
            </ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="MskSecConTestDate"  
                                TargetControlID="txtFromDate" 
                                Mask="99/99/9999"
                                MaskType="Date"
                                InputDirection="RightToLeft" 
                                AcceptNegative="Left" 
                                 runat="server"/>
            
            Report To Date:
            <asp:TextBox ID="txtToDate" runat="server" align="center" MaxLength="30" 
                ValidationGroup="Tabreport" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2"  runat="server" 
                AlternateText="Click here to display calendar" 
                ImageUrl="assets/img/calendar.gif" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                Enabled="True" Format="MM/dd/yyyy" PopupButtonID="ImageButton2" 
                TargetControlID="txtToDate">
            </ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1"  
                                TargetControlID="txtToDate" 
                                Mask="99/99/9999"
                                MaskType="Date"
                                InputDirection="RightToLeft" 
                                AcceptNegative="Left" 
                                 runat="server"/>
                                 
             Report By:<asp:DropDownList ID="ddlEmpl" runat="server" ValidationGroup="Tabreport" Width="150px">
                        <asp:ListItem Text="By Employee" Value="1"></asp:ListItem>
                        <asp:ListItem Text="By Project" Value="2"></asp:ListItem>
                       </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnRptSearch" runat="server" CssClass="button" 
                OnClick="btnSearch_Click" ValidationGroup="Tabreport" Text="Search"  Width="100px" />
            <asp:RequiredFieldValidator ID="rrReportDate" runat="server" 
                ControlToValidate="txtToDate" ErrorMessage="Report Date is Required." 
                ValidationGroup="Tabreport"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

<!-- This is for Employee PayRoll Section -->
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
	<td align="left"><asp:textbox class="title" id="txtSelectionResultsEmpl" runat="server" Width="75%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>

		    <!-- DataGrid is going to be here -->   
			 <asp:DataGrid ID="grdEmpl" runat="server" AllowPaging="True" Visible=false 
                                OnItemDataBound="grdEmpl_OnItemDataBound" OnItemCommand="grdEmpl_Itemcommand"  AutoGenerateColumns="False" CellPadding="3" CssClass="data" 
                                PageSize=100  DataKeyField=loginid  ShowFooter="True" Width="100%">
                                <Columns>
                                    <asp:TemplateColumn HeaderImageUrl="assets/img/Search.gif">
					                    <HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					                    <ItemStyle  width="50px" HorizontalAlign="Center"></ItemStyle>
					                    <ItemTemplate>
						                    <asp:ImageButton ImageUrl="assets/img/Plus.gif" CommandName="Expand" ID="btnExpand" Runat="server"></asp:ImageButton>
					                    </ItemTemplate>
				                    </asp:TemplateColumn>
				
                                    <asp:BoundColumn DataField="UName" ItemStyle-Width="250px" HeaderText="Employee" SortExpression="UName">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="eng_hours"   ItemStyle-Width="50px" HeaderText="Eng." 
                                        SortExpression="eng_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fab_hours"   ItemStyle-Width="50px" HeaderText="Fab." 
                                        SortExpression="fab_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fin_hours"   ItemStyle-Width="50px" HeaderText="Fin." 
                                        SortExpression="fin_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="misc_hours"  ItemStyle-Width="50px"  HeaderText="Misc." 
                                        SortExpression="misc_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotHours"  ItemStyle-Width="50px"  HeaderText="Total." 
                                        SortExpression="TotHours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="pWO"  ItemStyle-Width="50px"  HeaderText="Total Amount." 
                                        SortExpression="pWO">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-Width="50px">
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
										                   <uc1:Whitfield_Payroll_ByProject id="DynamicTable1" runat="server"></uc1:Whitfield_Payroll_ByProject>
									                    </td>
								                    </tr>
							                    </table>
						                    </asp:PlaceHolder>
					                    </ItemTemplate>
				                    </asp:TemplateColumn>
                                </Columns>
                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                <PagerStyle Mode="NumericPages" />
                                <SelectedItemStyle BackColor="LemonChiffon" />
                            </asp:DataGrid>
	</td>
</tr>
<tr>
	<td align="left">
		    <!-- DataGrid is going to be here -->
			<asp:textbox class="title" id="txtSelectionResultsProj" runat="server" Width="75%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>
			 <asp:DataGrid ID="grdProj" runat="server" AllowPaging="True" Visible=false 
              OnItemDataBound="grdProj_OnItemDataBound" OnItemCommand="grdProj_Itemcommand" PageSize=100   DataKeyField="EstNum" AutoGenerateColumns="False" CellPadding="3" CssClass="data" 
              ShowFooter="True" Width="100%">
                                <Columns>
                                
                                    <asp:TemplateColumn HeaderImageUrl="assets/img/Search.gif">
					                    <HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					                    <ItemStyle HorizontalAlign="Center" width="50px"></ItemStyle>
					                    <ItemTemplate>
						                    <asp:ImageButton ImageUrl="assets/img/Plus.gif" CommandName="Expand" ID="btnExpand" Runat="server"></asp:ImageButton>
					                    </ItemTemplate>
				                    </asp:TemplateColumn>
				
                                    <asp:BoundColumn DataField="ProjName" ItemStyle-Width="250px" HeaderText="Project" SortExpression="ProjName">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="eng_hours" ItemStyle-Width="50px" HeaderText="Eng." 
                                        SortExpression="eng_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fab_hours" ItemStyle-Width="50px" HeaderText="Fab." 
                                        SortExpression="fab_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fin_hours"  ItemStyle-Width="50px" HeaderText="Fin." 
                                        SortExpression="fin_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="misc_hours"  ItemStyle-Width="50px" HeaderText="Misc." 
                                        SortExpression="misc_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotHours"   ItemStyle-Width="50px" HeaderText="Total." 
                                        SortExpression="TotHours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-Width="50px">
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
										                   <uc1:Whitfield_Payroll_ByEmployee id="DynamicTable2" runat="server"></uc1:Whitfield_Payroll_ByEmployee>
									                    </td>
								                    </tr>
							                    </table>
						                    </asp:PlaceHolder>
					                    </ItemTemplate>
				                    </asp:TemplateColumn>
				
                                </Columns>
                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                <PagerStyle Mode="NumericPages" />
                                <SelectedItemStyle BackColor="LemonChiffon" />
                            </asp:DataGrid>
	</td>
</tr>
</table>

<!-- This is for Project PayRoll Section Ends. -->

</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

