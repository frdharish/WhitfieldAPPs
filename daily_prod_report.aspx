<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="daily_prod_report.aspx.cs" Inherits="daily_prod_report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div>
<asp:UpdatePanel runat="server" id="UpdatePanel1">
<ContentTemplate>
<ajaxToolkit:TabContainer ID="tabgeneral" runat="server" Width="100%" CssClass="fancy" ActiveTabIndex="0">
<ajaxToolkit:TabPanel ID="tabGenInfo" runat="server" HeaderText="Daily Production Report">
     <ContentTemplate>

<table  width="100%" bgcolor="WhiteSmoke">
    <table bgcolor="WhiteSmoke" border="0" width="100%">
        <tr>
            <td>
                <table bgcolor="WhiteSmoke" border="0" width="100%">
                    <tr>
                        <td class="form1" style="width: 50%" vAlign="top">
                            Report Date:
                            <asp:TextBox ID="txtReportDate" runat="server" align="center" MaxLength="30" 
                                ValidationGroup="Tabreport" Width="150px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                AlternateText="Click here to display calendar" 
                                ImageUrl="assets/img/calendar.gif" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" Format="MM/dd/yyyy" PopupButtonID="ImageButton1" 
                                TargetControlID="txtReportDate">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MskSecConTestDate"  
                                                TargetControlID="txtReportDate" 
                                                Mask="99/99/9999"
                                                MaskType="Date"
                                                InputDirection="RightToLeft" 
                                                AcceptNegative="Left" 
                                                 runat="server" CultureAMPMPlaceholder="" 
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"/>
                            <asp:Button ID="btnRptSearch" runat="server" CssClass="button" 
                                OnClick="btnSearch_Click" ValidationGroup="Tabreport1" Text="Create New"  Width="100px" />
                            <asp:RequiredFieldValidator ID="rrReportDate" runat="server" 
                                ControlToValidate="txtReportDate" ErrorMessage="Report Date is Required." 
                                ValidationGroup="Tabreport"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="form1" style="width: 100%" vAlign="top">
                            Significant Issues/Impediments Notes/Comments:<br />
                            <asp:TextBox ID="txtRptIssues" runat="server" cols="80" Font-Names="Arial" 
                                Font-Size="Small" Height="65px" Rows="6" TextMode="MultiLine" 
                                ValidationGroup="Tabreport" Width="550px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="reqRptIssues" runat="server" 
                               ValidationGroup="Tabreport" ControlToValidate="txtRptIssues" ErrorMessage="Issues is Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" border="0" width="100%">
                            <table bgcolor="yellow">
                                <tr>
                                    <td align="center" colspan="6">
                                        <bold>Cumulative Daily Hour Totals</bold>
                                        <tr>
                                            <th align="right" colspan="2" style="font-size: smaller">
                                                Engineering&nbsp;&nbsp;&nbsp;</th>
                                            <th align="center" style="font-size: smaller">
                                                Fabrication</th>
                                            <th align="center" style="font-size: smaller">
                                                Finishing</th>
                                            <th align="center" style="font-size: smaller">
                                                Miscellaneous</th>
                                            <th align="center" style="font-size: smaller">
                                                Total</th>
                                        </tr>
                                        <tr>
                                            <td align="right" width="75px">
                                                Budget Hours</td>
                                            <td align="center" width="100px">
                                                <asp:Label ID="lblcumEngHours" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center" width="100px">
                                                <asp:Label ID="lblcumFabHours" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center" width="100px">
                                                <asp:Label ID="lblcumfinHours" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center" width="100px">
                                                <asp:Label ID="lblcummiscHours" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center" width="50px">
                                                <asp:Label ID="lblcumtotHours" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Hours to Date</td>
                                            <td align="center">
                                                <asp:Label ID="lblcumEngTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumfabTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumfinTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcummiscTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumtotTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Daily Hours</td>
                                            <td align="center">
                                                <asp:Label ID="lblcumDailyEng" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumDailyfab" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumDailyfin" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumDailymisc" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumDailytot" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Difference</td>
                                            <td align="center">
                                                <asp:Label ID="lblcumdiffEng" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumdifffab" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumdifffin" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumdiffmisc" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblcumdifftot" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table align="center" border="0" style="background-color: Aqua" width="100%">
                    <tr>
                        <td>
                            <table border="0" width="auto%">
                                <tr>
                                    <td align="center" colspan="3">
                                        Provide comprehensive hourly data on work orders executed today based upon each 
                                        employees contribution.</td>
                                </tr>
                                <tr height="30px">
                                    <td align="right" valign="center" width="65px">
                                        Employee:</td>
                                     <td>
                                        <asp:DropDownList ID="ddlEmpl" runat="server" ValidationGroup="Tabreport" 
                                          Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center" rowspan="3" valign="top" width="70px">
                                        Comments:<br />
                                        <asp:TextBox ID="txtActComments" runat="server" Height="70px" MaxLength="500" 
                                            ValidationGroup="Tabreport" TextMode="MultiLine" Width="260px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr height="30px">
                                    <td align="right" valign="center" width="65px">
                                        Project:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" 
                                            ValidationGroup="Tabreport" Width="260px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="30px">
                                    <td align="right" valign="center" width="65px">
                                        Work Order:</td>
                                    <td align="left" valign="middle">
                                        <asp:DropDownList ID="ddlworkorders" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlworkorders_SelectedIndexChanged" 
                                            Width="260px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rrWorkOrder" runat="server" 
                                            ControlToValidate="ddlworkorders" ErrorMessage="Select Workorder" 
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" border="0">
                                <tr>
                                    <td>
                                        <tr>
                                            <th align="right" colspan="2" style="font-size: smaller">
                                                Engineering&nbsp;&nbsp;&nbsp;</th>
                                            <th align="center" style="font-size: smaller">
                                                Fabrication</th>
                                            <th align="center" style="font-size: smaller">
                                                Finishing</th>
                                            <th align="center" style="font-size: smaller">
                                                Miscellaneous</th>
                                            <th align="center" style="font-size: smaller">
                                                Total</th>
                                        </tr>
                                        <tr>
                                            <td align="right" width="75px">
                                                Budget Hours</td>
                                            <td align="center">
                                                <asp:Label ID="lblbudeng" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblbudfab" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblbudfin" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblbudmisc" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblbudtot" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Hours to Date</td>
                                            <td align="center">
                                                <asp:Label ID="lblEngTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblfabTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblfinTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblmiscTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbltotTD" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Daily Hours</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtenghours" runat="server" MaxLength="5" 
                                                    ValidationGroup="Tabreport" Width="50px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revenghours1" runat="server" 
                                                            ControlToValidate="txtenghours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtfabhours" runat="server" MaxLength="5" 
                                                    ValidationGroup="Tabreport" Width="50px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revfabhours" runat="server" 
                                                            ControlToValidate="txtfabhours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtfinhours" runat="server" MaxLength="5" 
                                                    ValidationGroup="Tabreport" Width="50px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revfinhorus" runat="server" 
                                                            ControlToValidate="txtfinhours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtmischours" runat="server" MaxLength="5" 
                                                    ValidationGroup="Tabreport" Width="50px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revmischours" runat="server" 
                                                            ControlToValidate="txtmischours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="btnWO" runat="server" CssClass="button" OnClick="btnWO_Click" 
                                                    Text="Save" ValidationGroup="Tabreport" Width="50px" />
                                            </td>
                                             <td align="center"><asp:Button ID="btnMail" runat="server" CssClass="button" 
                                                    OnClick="btnMail_Click" Text="Email Report"  Width="75px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Difference</td>
                                            <td align="center">
                                                <asp:Label ID="lbldiffEng" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbldifffab" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbldifffin" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbldiffmisc" runat="server" Width="20px"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbldifftot" runat="server" Width="20px"></asp:Label>
                                            </td>
                                        </tr>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table align="left" border="0" width="auto%">
                    <tr valign="top">
                        <td height="200" valign="top">
                            <asp:DataGrid ID="grdEmployeeHours" runat="server" AllowPaging="True" 
                                ItemStyle-Font-Bold="true" AutoGenerateColumns="False" CellPadding="3" CssClass="data" 
                                OnItemDataBound="grdEmployeeHours_ItemDataBound" ShowFooter="True" Width="100%">
                                <Columns>
                                    <asp:BoundColumn DataField="UName" HeaderText="Employee" SortExpression="UName">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="eng_hours" HeaderText="Eng." 
                                        SortExpression="eng_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fab_hours" HeaderText="Fab." 
                                        SortExpression="fab_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="fin_hours" HeaderText="Fin." 
                                        SortExpression="fin_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="misc_hours" HeaderText="Misc." 
                                        SortExpression="misc_hours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotHours" HeaderText="Total." 
                                        SortExpression="TotHours">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                </Columns>
                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                    Font-Size="10pt" ForeColor="Black" />
                                <PagerStyle Mode="NumericPages" />
                                <SelectedItemStyle BackColor="LemonChiffon" />
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="form1" style="width: 50%" valign="top">
                            Management Reviewed/Accepted:
                            <asp:CheckBoxList ID="chkActive" runat="server" CssClass="form1" 
                                RepeatDirection="Horizontal" ValidationGroup="Tabreport">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <tr>
        <table width="100%" border="0" bgcolor="WhiteSmoke">
            <tr>
                <td align="left" class="form1" style="width: 33%" valign="top">
                    <tr>
                        <td class="form1" vAlign="top">
                            Work Orders Executed Today
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:DataGrid ID="grdActivity" runat="server" AutoGenerateColumns="False" 
                                            BackColor="#999999" CellPadding="3" CssClass="data" DataKeyField="activity_id" 
                                            OnCancelCommand="grdActivity_CancelCommand" 
                                            OnDeleteCommand="grdActivity_DeleteCommand" 
                                            OnEditCommand="grdActivity_EditCommand" 
                                            OnItemDataBound="grdActivity_ItemDataBound" 
                                            OnUpdateCommand="grdActivity_UpdateCommand" ShowFooter="True" Width="100%">
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Project Name" SortExpression="ProjName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrjName" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.ProjName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Description" SortExpression="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLongDesc1" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Employee" SortExpression="LoginId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpl" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.UName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Engineering Hours" SortExpression="eng_hours">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtenghours" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.eng_hours") %>' Width="30"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvenghours" runat="server" 
                                                            ControlToValidate="txtenghours" Display="Dynamic" 
                                                            ErrorMessage="Please enter a number"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revenghours" runat="server" 
                                                            ControlToValidate="txtenghours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblenghours" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.eng_hours")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Fabrication Hours" SortExpression="fab_hours">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtfabhours" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.fab_hours") %>' Width="30"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvfabhours" runat="server" 
                                                            ControlToValidate="txtfabhours" Display="Dynamic" 
                                                            ErrorMessage="Please enter a number"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revfabhours" runat="server" 
                                                            ControlToValidate="txtfabhours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfabhours" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.fab_hours")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Finishing Hours" SortExpression="fin_hours">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtfinhours" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.fin_hours") %>' Width="30"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvfinhours" runat="server" 
                                                            ControlToValidate="txtfinhours" Display="Dynamic" 
                                                            ErrorMessage="Please enter a number"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revfinhours" runat="server" 
                                                            ControlToValidate="txtfinhours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfinhours" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.fin_hours")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Misc. Hours" SortExpression="misc_hours">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtmischours" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.misc_hours") %>' Width="30"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvmischours" runat="server" 
                                                            ControlToValidate="txtmischours" Display="Dynamic" 
                                                            ErrorMessage="Please enter a number"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revmischours" runat="server" 
                                                            ControlToValidate="txtmischours" Display="Dynamic" 
                                                            ErrorMessage="Please use only numbers" ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmischours" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container, "DataItem.misc_hours")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Comments" SortExpression="empl_comments">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtNotes" runat="server" Height="75px" MaxLength="500" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.empl_comments") %>' 
                                                            TextMode="MultiLine" Width="250px" Wrap="True">
								          </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtNotesRO" runat="server" BackColor="#EAEFF3" Height="25px" 
                                                            MaxLength="1000" ReadOnly="true" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.empl_comments") %>' 
                                                            TextMode="MultiLine" Width="250px" Wrap="True"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Left" Width="150px" 
                                                        Wrap="True" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="EDIT">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbutUpdate" runat="server" CommandName="Update" 
                                                            Text="&lt;img  border=0 src=assets/img/im_update.gif alt=save/update&gt;"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:LinkButton ID="lnkbutCancel" runat="server" CausesValidation="false" 
                                                            CommandName="Cancel" 
                                                            Text="&lt;img border=0 src=assets/img/im_cancel.gif alt=cancel&gt;"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbutEdit" runat="server" CausesValidation="false" 
                                                            CommandName="EDIT" Text="&lt;img border=0 src=assets/img/EDIT.gif alt=EDIT&gt;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="DEL">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbutDelete" runat="server" CausesValidation="false" 
                                                            CommandName="DELETE" 
                                                            Text="&lt;img border=0 src=assets/img/DELETE.gif alt=DELETE&gt;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#FFFF66" />
                                            <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                                Font-Size="10pt" ForeColor="#FFFF99" />
                                            <ItemStyle Wrap="False" />
                                            <PagerStyle Mode="NumericPages" />
                                            <SelectedItemStyle BackColor="LemonChiffon" />
                                        </asp:DataGrid>
                                        <!-- Report DataGrid Ends Here -->
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </td>
            </tr>
        
        </table>
    </tr>
 </table> 

        </ContentTemplate>
</ajaxToolkit:TabPanel>
                          
                          <ajaxToolkit:TabPanel ID="tabHistory" runat="server" HeaderText="Production Report Log">
                            <ContentTemplate>
                            Daily Production Report Log<br />
                                <asp:datagrid id="grdHistoryRpt" runat="server" CssClass="data" Width="50%"
                                   PageSize="100"  AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
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
                                                <%#showHistoryReport(((DataRowView)Container.DataItem)["rpt_date"])%>
                                            </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="fab_hours" SortExpression="fab_hours" HeaderText="Fab. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="fin_hours" SortExpression="fin_hours" HeaderText="Fin. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="eng_hours" SortExpression="eng_hours" HeaderText="Eng. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="misc_hours" SortExpression="misc_hours" HeaderText="Misc. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                             <asp:BoundColumn DataField="TotHours" SortExpression="TotHours" HeaderText="Tot. Hours" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
                                                <ItemStyle BackColor="#EAEFF3"></ItemStyle>
                                            </asp:BoundColumn>
                                            </Columns><PagerStyle Mode="NumericPages"></PagerStyle>
                               </asp:datagrid>
                            </ContentTemplate>
                          </ajaxToolkit:TabPanel>


                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" Height="900px" HeaderText="Production Schedule">
                                <ContentTemplate>
                                    	 <table align="left"  width="50%" bgcolor="WhiteSmoke">
                                             <tr align="left" valign="top">
                                             <td>
                                                <!--<td class="form1" width="5%">Year:<br /> -->
								                     <asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
							                    <!--</td> -->
							        
							                    <!--<td class="form1" width="5%">Month:<br />-->
								                    <asp:dropdownlist id="ddlMonth" runat="server"></asp:dropdownlist>
							                    <!--</td>  
                                                <td class="form1" width="5%"><br />-->
                                                 <asp:Button ID="btnProd" runat="server" CssClass="button"  Text="Search"
                                                 OnClick="btnProd_Click" Width="150px" />
                                               <!--  </td>
                                                </tr>
                                                    </table> -->
                                             
                                             <!--<table align="left"  width="50%" bgcolor="WhiteSmoke">
                                                <tr align="left" valign="top">
                                                <td>  -->
                                            <br />
                                            <asp:PlaceHolder ID="plSchedule"  runat="server"></asp:PlaceHolder>
                                            </td>
                                        </tr>
                                        </table> 
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

</ajaxToolkit:TabContainer>
 </ContentTemplate>
 </asp:UpdatePanel>
 <script type="text/javascript" language="javascript">
var theForm = document.forms[0];
window.name = 'IEAdvanceQueue';
var agreewin = "";
function showHistoryReport(ReportDate) {
    location.href = 'daily_prod_report.aspx?ReportDate=' + ReportDate;
}
</script>
</div>
</asp:Content>

