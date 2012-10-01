<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Whitfield_financialmgmt_child.ascx.cs" Inherits="Whitfield_financialmgmt_child" %>
<%@ Import Namespace="System.Data" %>
<table width="100%"  align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
	<td align="left"><asp:textbox class="title" id="txtSelectionResultsEmpl" runat="server" Width="100%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>

		    <!-- DataGrid is going to be here -->   
			                 <asp:DataGrid  
			                 BorderStyle=Solid 
			                 BorderColor=Gray 
			                 BackColor=LightYellow 
			                 OnItemDataBound="grdinv_ItemDataBound"
			                 ID="grdinv" 
			                 runat="server" 
			                 AllowPaging="True" 
                              AutoGenerateColumns="False" 
                              CellPadding="3" 
                              CssClass="data" 
                              PageSize=100  showFooter="True" Width="100%">
                                <Columns>
				
                                    <asp:BoundColumn DataField="invoice_number" ItemStyle-Width="50px" HeaderText="Invoice Number" SortExpression="invoice_number">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Date_Submited"   ItemStyle-Width="50px" HeaderText="Date Submitted" 
                                        SortExpression="Date_Submited">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Date_Received"   ItemStyle-Width="50px" HeaderText="Date Received" 
                                        SortExpression="Date_Received">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Date_Approved"   ItemStyle-Width="50px" HeaderText="Date Approved" 
                                        SortExpression="Date_Approved">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Total_inv_Amount"  ItemStyle-Width="50px"  HeaderText="Total Inv Amount" 
                                        SortExpression="Total_inv_Amount">
                                        <HeaderStyle BackColor="#60829F" CssClass="subnav" Font-Bold="True" 
                                            HorizontalAlign="Center" />
                                        <ItemStyle BackColor="#EAEFF3" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Invoice_comments"  ItemStyle-Wrap=true ItemStyle-Width="250px"  HeaderText="Invoice comments." 
                                        SortExpression="Invoice_comments">
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