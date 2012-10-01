<%@ Control Language="C#" AutoEventWireup="true" CodeFile="submaterial.ascx.cs" Inherits="submaterial" %>
<%@ Import Namespace="System.Data" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
	<td align="left"><asp:textbox class="title" id="txtSelectionResultsMSG" Text="Sub Material Adminstration" runat="server" Width="100%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>
		<!-- DataGrid is going to be here -->
			<asp:datagrid id="grdpl1" runat="server"  BorderStyle="Solid" Width="100%" CssClass="data" BackColor="WhiteSmoke" ItemStyle-Wrap="False"
			OnDeleteCommand="grdpl1_DeleteCommand" DataKeyField="sub_mat_id" OnCancelCommand="grdpl1_CancelCommand"
			OnUpdateCommand="grdpl1_UpdateCommand" OnEditCommand="grdpl1_EditCommand" FooterStyle-Font-Name="Verdana"
			FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
			FooterStyle-BackColor="#D9D9D9"  AutoGenerateColumns="False"
			Font-Size="Smaller"  SelectedItemStyle-BackColor="#999999" CellPadding="3" EditItemStyle-BackColor="#ffff66">
			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
			<Columns>
			
				<asp:BoundColumn DataField="material_id" SortExpression="material_id" HeaderStyle-Font-Bold="True"
					HeaderText="material id" HeaderStyle-Wrap="false" Visible="false">
					<HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					<ItemStyle></ItemStyle>
				</asp:BoundColumn>
				
			
				<asp:TemplateColumn SortExpression="thickness" HeaderText="thickness" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblthickness" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.thickness")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				         <EditItemTemplate>
				                    <asp:TextBox Width="50" id="txtthickness" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.thickness") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvthickness" runat="server" Display="Dynamic" ErrorMessage="Please enter thickness"
						                ControlToValidate="txtthickness"></asp:RequiredFieldValidator>
						                <cc1:FilteredTextBoxExtender ID="Featuredcontrol_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtthickness" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
			
			    <asp:TemplateColumn SortExpression="width" HeaderText="Width" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblwidth" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.width")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				         <EditItemTemplate>
				                    <asp:TextBox Width="50" id="txtwidth" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.width") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvwidth" runat="server" Display="Dynamic" ErrorMessage="Please enter width"
						                ControlToValidate="txtwidth"></asp:RequiredFieldValidator>
						                <cc1:FilteredTextBoxExtender ID="Featuredcontrol_FilteredTextBoxExtender2" 
                                        runat="server" Enabled="True" TargetControlID="txtwidth" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="length" HeaderText="Length" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lbllength" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.length")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				         <EditItemTemplate>
				                    <asp:TextBox Width="50" id="txtlength" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.length") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvlength" runat="server" Display="Dynamic" ErrorMessage="Please enter length"
						                ControlToValidate="txtlength"></asp:RequiredFieldValidator>
						                 <cc1:FilteredTextBoxExtender ID="Featuredcontrol_FilteredTextBoxExtender1" 
                                        runat="server" Enabled="True" TargetControlID="txtlength" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="weight" HeaderText="Weight" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblweight" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Weight")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				         <EditItemTemplate>
				                    <asp:TextBox Width="50" id="txtweight" ValidationGroup="editmode1" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.weight") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvweight" runat="server" Display="Dynamic" ErrorMessage="Please enter weight"
						                ControlToValidate="txtweight"></asp:RequiredFieldValidator>
						                 <cc1:FilteredTextBoxExtender ID="Featuredcontrol_Weight" 
                                        runat="server" Enabled="True" TargetControlID="txtweight" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="Manufacturer" HeaderText="Manufacturer" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblManufacturer" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Manufacturer")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtManufacturer" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Manufacturer") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvManufacturer" runat="server" Display="Dynamic" ErrorMessage="Please enter a Manufacturer"
						                ControlToValidate="txtManufacturer"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
                 <asp:TemplateColumn SortExpression="LEED" HeaderText="LEED?" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblLEED" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.LEED")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                  <asp:RadioButtonList ID="chkLEED" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" ValidationGroup="editmode">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                   </asp:RadioButtonList>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				 <asp:TemplateColumn SortExpression="FSC" HeaderText="FSC" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblFSC" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.FSC")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   <asp:RadioButtonList ID="chkFSC" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" ValidationGroup="editmode">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                   </asp:RadioButtonList>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Description")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtDescription" runat="server" ValidationGroup="editmode1" TextMode="MultiLine" Rows="3"  Columns="40" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvDescription" runat="server" Display="Dynamic" ErrorMessage="Please enter a Description"
						                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="cost" HeaderText="cost" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblCost" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Cost")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="100" id="txtCost" ValidationGroup="editmode1" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Cost") %>' onBlur="this.value=formatCurrency(this.value);">
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvCost" runat="server" Display="Dynamic" ErrorMessage="Please enter a Cost"
						                ControlToValidate="txtCost"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
                <asp:TemplateColumn SortExpression="UOM" HeaderText="UOM" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblUOM" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.uom_type_desc")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   				                  
				                   <asp:DropDownList ID="ddlUOM" runat="server" CssClass="form1"  DataValueField="uom_type_id"  
				                                    DataTextField="uom_type_desc"
	                                                DataSource='<%# UOMSet() %>' ValidationGroup="editmode1">				                        
                                   </asp:DropDownList>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="Material_Code" HeaderText="Material Code" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblMaterial_Code" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Material_Code")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtMaterial_Code" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Material_Code") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvMaterial_Code" runat="server" Display="Dynamic" ErrorMessage="Please enter a Material_Code"
						                ControlToValidate="txtMaterial_Code"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="Default_Field" HeaderText="Is Default?" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblDefault_Field" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Default_Field")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   	<asp:RadioButtonList ID="chkDefault_Field" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" ValidationGroup="editmode">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                   </asp:RadioButtonList>			                  
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
				<asp:TemplateColumn SortExpression="Notes" HeaderText="Notes" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblNotes" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Notes")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtNotes" runat="server" ValidationGroup="editmode1" TextMode="MultiLine" Rows="3"  Columns="40" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Notes") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvNotes" runat="server" Display="Dynamic" ErrorMessage="Please enter a Notes"
						                ControlToValidate="txtNotes"></asp:RequiredFieldValidator>
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
	</td>
</tr>
</table>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<table  align="left"  width="50%" cellspacing="0" cellpadding="0" border="0">
<th align="left">Add New Sub Material</th>
<tr>
    <td>
                <table border="1">                
                    <tr>
                        <td class="form1">UOM<br /><asp:dropdownlist ValidationGroup="insertnew1" id="ddlUOM" runat="server"></asp:dropdownlist></td>                
                        <td class="form1">Brand/Manufacturer<br /><asp:textbox  ValidationGroup="insertnew1" id="txtManu" runat="server" MaxLength="50" Width="224px"></asp:textbox></td>                
                        <td class="form1">Material Code<br /><asp:textbox  ValidationGroup="insertnew1" id="txtMatCode" runat="server" MaxLength="50" Width="224px"></asp:textbox></td>                
                        <td class="form1">Thickness<br /><asp:textbox  ValidationGroup="insertnew1" id="txtthickness" runat="server" MaxLength="10" Width="50px"></asp:textbox>
                         <cc1:FilteredTextBoxExtender ID="filter1" 
                                        runat="server" Enabled="True" TargetControlID="txtthickness" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                         </td>
                        <td class="form1">Width<br /><asp:textbox  ValidationGroup="insertnew1" id="txtWidth" runat="server" MaxLength="10" Width="50px"></asp:textbox>
                        <cc1:FilteredTextBoxExtender ID="filter3" 
                                        runat="server" Enabled="True" TargetControlID="txtWidth" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                        </td>                
                        <td class="form1">Length<br /><asp:textbox  ValidationGroup="insertnew1" id="txtlength" runat="server" MaxLength="10" Width="50px"></asp:textbox>
                        <cc1:FilteredTextBoxExtender ID="filter2" 
                                        runat="server" Enabled="True" TargetControlID="txtlength" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                        </td> 
                        <td class="form1">Weight<br /><asp:textbox  ValidationGroup="insertnew1" id="txtweight" runat="server" MaxLength="10" Width="50px"></asp:textbox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                        runat="server" Enabled="True" TargetControlID="txtweight" 
                                        ValidChars="0123456789.">
                                        </cc1:FilteredTextBoxExtender>
                        </td>            
                    </tr>                
                    
                    <tr>
                       <td class="form1">LEED<br /><asp:RadioButtonList  ValidationGroup="insertnew1" ID="chkActive" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                        </td>  
                        <td class="form1">FSC<br /><asp:RadioButtonList  ValidationGroup="insertnew1" ID="chkiFSC" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                        </td>                
                        <td class="form1">Description<br /><asp:textbox  ValidationGroup="insertnew1" id="txtDescription" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox></td>
                        <td class="form1">Notes/Comments:<br /><asp:textbox  ValidationGroup="insertnew1" id="txtMemo" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox></td>               
                        <td class="form1">Cost<br /><asp:textbox  ValidationGroup="insertnew1" id="txtCost" runat="server" MaxLength="15" Width="100px" onBlur="this.value=formatCurrency(this.value);"></asp:textbox></td>   
                        <td class="form1" colspan="2">Is Default?<br /><asp:RadioButtonList  ValidationGroup="insertnew1" ID="rdoDefault_Field" runat="server" CssClass="form1" 
                                        RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                        </td>  
                    </tr>                    
                    <tr>
                        <td class="form1"><asp:button  ValidationGroup="insertnew1" id="btnnew" runat="server" Text="Save Sub Materials" CssClass="button" onclick="btnnew_Click" />
                        <br /><asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label></td>
                    </tr>
                    
                </table>
    </td>
 </tr>   
</table>
 