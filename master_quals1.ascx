<%@ Control Language="C#" AutoEventWireup="true" CodeFile="master_quals1.ascx.cs" Inherits="master_quals1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0" style="margin-right: 0px">
<tr>
<td>
            <table valign="top" width="50%" align="left" cellpadding="0" cellspacing="0" border="0" style="margin-right: 0px">
                    <tr>
	                    <td valign="top" align="left"> 
	        	            <asp:datagrid id="grd1" runat="server" CssClass="data" Width="50%" 
		                    OnUpdateCommand="grd1_UpdateCommand" 
		                    OnCancelCommand="grd1_CancelCommand"
		                    OnEditCommand="grd1_EditCommand"
		                    OnDeleteCommand="grd1_DeleteCommand"
		                    OnItemCreated="ResultGridItemCreated"
                            OnPageIndexChanged="PageResultGrid1"  AllowPaging="True" 
                            AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                            FooterStyle-Font-Name="Verdana" PageSize="100" ShowFooter="True"	
                            FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" 
                            FooterStyle-ForeColor="#ffff99"
				            FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="sub_qual_id">
                            <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                            <Columns>
            			
                                    <asp:TemplateColumn HeaderText="Seq. No" HeaderStyle-Font-Bold="True">
                                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						            <ItemStyle VerticalAlign="Top" HorizontalAlign="center"  Width="10px" BackColor="#EAEFF3"></ItemStyle>
                                    <ItemTemplate>
                                            <%#(grd1.PageSize * grd1.CurrentPageIndex) + Container.ItemIndex + 1%><br />
                                    </ItemTemplate>
                                    </asp:TemplateColumn> 
            					    
					                <asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True"
						            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
						            <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						            <ItemStyle VerticalAlign="Top"  BackColor="#EAEFF3"  Wrap="true" Width="200px" HorizontalAlign="Left"></ItemStyle>
						            <ItemTemplate>
						                <asp:label id="lbldesc" style="white-space: normal" runat="server" BorderStyle=None BorderWidth=0 BackColor="#EAEFF3" Width="200px" Height="50px"  TextMode="MultiLine" MaxLength="2000"
							                     Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
							                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							             </asp:label> 
						            </ItemTemplate>
						            <EditItemTemplate>
							            <asp:TextBox id="txtdesc"   runat="server" Width="200px" Height="50px"  TextMode="MultiLine" MaxLength="2000"
							                    Wrap=true Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
							                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							            </asp:TextBox>
						            </EditItemTemplate>
					                </asp:TemplateColumn>
            					    
					                 <asp:TemplateColumn SortExpression="is_default" HeaderText="Is Default?" HeaderStyle-Font-Bold="True">
				                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                        <ItemStyle VerticalAlign="Top"  HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				                        <ItemTemplate>
					                            <asp:Label id="lblis_default" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.is_default")%>'>
					                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				                        </ItemTemplate>
				                         <EditItemTemplate>
				                                <asp:RadioButtonList ID="chkis_default" runat="server" CssClass="form1" 
                                                        RepeatDirection="Horizontal" ValidationGroup="editmode">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Selected="True" Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
				                        </EditItemTemplate> 
				                    </asp:TemplateColumn>
            				        
				                    <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
				                    <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                    <ItemStyle VerticalAlign="Top"  HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
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
            			    
            			    
			                        <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="DEL">
				                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				                        <ItemStyle VerticalAlign="Top" BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
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
</td>
<td valign="top">
                  <table valign="top" align='center' cellspacing="0" cellpadding="0" bgcolor="#ffffff" border="1" width="50%">
	                <tr>
                        <td> 
	                            <table cellspacing="5" cellpadding="5" width="100%" border="1">
		                            <tr>
			                            <td valign="top">
			                            <span class="header1">Qualification </span><span class="header2">Data Entry</span>   
			                    			<table align="center"  style=" height:250px; width: 50%;" cellspacing="0" 
                                                cellpadding="0" border="0">		                    			    
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Description:<br/>
                                                                 <asp:textbox  ID="txtdesc" CssClass="form1" ValidationGroup="vg2" TextMode="MultiLine" wrap="true" 
                                                                    Rows="4" Columns="20" MaxLength="20" runat="server" 
                                                                    Width="420px"></asp:textbox> <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vg2" ControlToValidate="txtdesc"   ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>                                              
                                                
                                                <tr>                                                                    
                                                    <td  valign="top" align="left" class="form1" style="color: Maroon">
                                                         Is Default:<br/>

                                                                <asp:RadioButtonList ID="ddldefault" ValidationGroup="vg2" runat="server" CssClass="form1" Width="266px">
                                                                </asp:RadioButtonList><br />
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vg2" ControlToValidate="ddldefault"  InitialValue=""  ForeColor="Red" Font-Bold="true" Display="Static" runat="server">*Required.</asp:RequiredFieldValidator>  
                                                    </td>
                                                </tr>
                                            </table>
			                            </td>
		                            </tr>
	                            </table>
	                      </td>
			        </tr>
			        <tr>
				               <td align="center">
				                    <asp:button id="btnSave" ValidationGroup="vg2" runat="server" text="Save" 
                                       CssClass="button" onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;
        						</td>
				    </tr>
			</table>
</td>
</tr>
</table>