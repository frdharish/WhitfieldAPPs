<%@ Control Language="C#" AutoEventWireup="true" CodeFile="workorder_materials.ascx.cs" Inherits="workorder_materials" %>
<%@ Import Namespace="System.Data" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 
<style type="text/css">
    .style1
    {
        width: 441px;
    }
    .style2
    {
        width: 472px;
    }
    .data
    {
        margin-left: 0px;
    }
</style>
<asp:UpdatePanel ID="UpdatePanelquad" runat="server">    
<contenttemplate> 
 <asp:HiddenField ID="hdnEstNum" runat="server" />
<asp:HiddenField ID="hdnworkorderNumber" runat="server" />
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<th align="left">
                Add New Sub Material
</th>
<tr>
        <td class="style1">
            <table  align="left" cellspacing="0" cellpadding="0" border="0" style="width: 176%">       
                    <tr>            
                            <td>
                                <table border="1">
                                    <tr>
                                        <td class="style2">
                                            <div style="OVERFLOW-Y:scroll; WIDTH:400px; HEIGHT:300px;">
                                                <asp:CheckBoxList ID="RdoprjMaterials" runat="server" 
                                                    RepeatDirection="vertical">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Button ID="btnnew" runat="server" CssClass="button" onclick="btnnew_Click" 
                                                Text="Save Sub Materials" ValidationGroup="insertnew1" />
                                            <br />
                                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="medium" 
                                                ForeColor="Maroon"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                </table>
        </td>
	    <td valign="top"  align="right"><asp:textbox class="title" id="txtSelectionResultsMSG" Text="" runat="server" Width="100%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox><br />
		<!-- DataGrid is going to be here -->
			<asp:datagrid id="grdpl1" runat="server"  BorderStyle="Solid" Width="91%" 
                CssClass="data" BackColor="WhiteSmoke" ItemStyle-Wrap="False"
			OnDeleteCommand="grdpl1_DeleteCommand" DataKeyField="sub_mat_id" OnCancelCommand="grdpl1_CancelCommand"
			OnUpdateCommand="grdpl1_UpdateCommand" OnEditCommand="grdpl1_EditCommand" FooterStyle-Font-Name="Verdana"
			FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
			FooterStyle-BackColor="#D9D9D9"  AutoGenerateColumns="False"
			Font-Size="Smaller"  SelectedItemStyle-BackColor="#999999" CellPadding="3" 
                EditItemStyle-BackColor="#ffff66">
			    <FooterStyle BackColor="#D9D9D9" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="10pt" ForeColor="#FFFF99" />
                <EditItemStyle BackColor="#FFFF66" />
			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
			    <ItemStyle Wrap="False" />
			<Columns>
			
			    <asp:BoundColumn DataField="EstNum" SortExpression="EstNum" HeaderStyle-Font-Bold="True"
					HeaderText="EstNum" HeaderStyle-Wrap="false" Visible=false>
					<HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					<ItemStyle></ItemStyle>
				</asp:BoundColumn>
				
				<asp:BoundColumn DataField="work_order_id" SortExpression="work_order_id" HeaderStyle-Font-Bold="True"
					HeaderText="Work Order" HeaderStyle-Wrap="false" Visible=false>
					<HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					<ItemStyle></ItemStyle>
				</asp:BoundColumn>
				
				<asp:BoundColumn DataField="sub_mat_id" SortExpression="sub_mat_id" HeaderStyle-Font-Bold="True"
					HeaderText="Sub Material" HeaderStyle-Wrap="false" Visible=false>
					<HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					<ItemStyle></ItemStyle>
				</asp:BoundColumn>
				
				<asp:TemplateColumn SortExpression="OrigMatName" HeaderText="Material Description" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblMat_type_Desc" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.OrigMatName")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   <asp:Label id="lblMat_type_Desc1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.OrigMatName")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
		
				<asp:TemplateColumn SortExpression="PriceInProject" HeaderText="PriceInProject" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.PriceInProject")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   <asp:Label id="lblPrice1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.PriceInProject")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				
				<asp:TemplateColumn SortExpression="Qty" HeaderText="Qty" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					               <asp:TextBox Width="50" id="txtqty1"  runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.Qty") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvqty1" runat="server" Display="Dynamic" ErrorMessage="Please enter Quantity"
						                ControlToValidate="txtqty1"></asp:RequiredFieldValidator>
						                 <cc1:FilteredTextBoxExtender ID="Featuredcontrol_qty1" 
                                        runat="server" Enabled="True" TargetControlID="txtqty1" 
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
				        </ItemTemplate>
				         <EditItemTemplate>
				                    <asp:TextBox Width="50" id="txtqty" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.Qty") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvqty" runat="server" Display="Dynamic" ErrorMessage="Please enter Quantity"
						                ControlToValidate="txtqty"></asp:RequiredFieldValidator>
						                 <cc1:FilteredTextBoxExtender ID="Featuredcontrol_qty" 
                                        runat="server" Enabled="True" TargetControlID="txtqty" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
                <asp:TemplateColumn SortExpression="pWO" HeaderText="Total Cost" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblTotalMat_Cost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.pWO")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   <asp:Label id="lblTotalMat_Cost1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.pWO")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
                <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
				<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				<ItemTemplate>
					<asp:LinkButton id="lnkbutEdit"  runat="server" Text="<img border=0 src=assets/img/EDIT.gif alt=EDIT>"
						CommandName="EDIT" CausesValidation="false"></asp:LinkButton></ItemTemplate>
				    <EditItemTemplate>
					<asp:LinkButton id="lnkbutUpdate" ValidationGroup="editmode1" runat="server" Text="<img  border=0 src=assets/img/im_update.gif alt=save/update>"
						CommandName="Update"></asp:LinkButton>&nbsp;
					<asp:LinkButton id="lnkbutCancel" runat="server" Text="<img border=0 src=assets/img/im_cancel.gif alt=cancel>"
						CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
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
			<PagerStyle Mode="NumericPages"></PagerStyle>
		</asp:datagrid>
		 <div>
            <table align="center"  style="background-color: Silver">
                    <tr>
                        <td valign="top">
                        <asp:HiddenField ID="hidControlDesignID" runat="server" Value="" />
                         <asp:button id="btnInsert" runat="server" ValidationGroup="TabFeatureInsert" 
                                Text="Save Quantities" CssClass="button" 
                                onclick="btnInsert_Click" Height="32px" Width="90px"></asp:button>&nbsp;&nbsp;
                        </td>
                    </tr>
            </table>
            <asp:label ID="lblSuccessMsg" runat="server" Font-Bold="true" ForeColor="Maroon" CssClass="form1"></asp:label>
        </div>
	</td>
</tr>
</table>
 </contenttemplate>
 </asp:UpdatePanel>


 