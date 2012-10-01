<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Whitfield_Payroll_ByEmployee.ascx.cs" Inherits="Whitfield_Payroll_ByEmployee" %>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
	<td align="left"><asp:textbox class="title" id="txtSelectionResultsEmpl" runat="server" Width="100%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>

		    <!-- DataGrid is going to be here -->   
			 <asp:DataGrid ID="grdEmpl" BorderStyle=Solid BorderColor=Gray BackColor=LightYellow runat="server" AllowPaging="True" Visible=false 
                                OnItemDataBound="grdEmpl_OnItemDataBound" AutoGenerateColumns="False" CellPadding="3" CssClass="data" 
                                PageSize=100  DataKeyField=loginid  ShowFooter="True" Width="100%">
                                <Columns>
				
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
                                </Columns>
                                <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                                    Font-Size="10pt" ForeColor="#FFFF99" />
                                <PagerStyle Mode="NumericPages" />
                                <SelectedItemStyle BackColor="LemonChiffon" />
                            </asp:DataGrid>
	</td>
</tr>
</table>