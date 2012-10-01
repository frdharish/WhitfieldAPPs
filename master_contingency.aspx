<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="master_contingency.aspx.cs" Inherits="master_contingency" %>
<%@ Register TagPrefix="uc1" TagName="DynamicTable" Src="master_contingency.ascx" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager" runat="server" />
  <span class="header1">Contingency </span><span class="header2">- Adminstration</span> 
  <asp:UpdatePanel ID="UpdatePanelouter" runat="server">    
        <contenttemplate>
		<asp:datagrid id="grdEstimateMaterials" runat="server" CssClass="data" Width="50%" 
		        OnUpdateCommand="grdEstimateMaterials_UpdateCommand" 
		        OnCancelCommand="grdEstimateMaterials_CancelCommand"
		        OnEditCommand="grdEstimateMaterials_EditCommand"
		        OnDeleteCommand="grdEstimateMaterials_DeleteCommand"
		        OnItemCreated="ResultGridItemCreated"
                OnItemCommand="grdEstimateMaterials_Itemcommand"
                OnPageIndexChanged="PageResultGrid1"  AllowPaging="True" 
                AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
                FooterStyle-Font-Name="Verdana" PageSize="100" ShowFooter="True"	
                FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" 
                FooterStyle-ForeColor="#ffff99"
				FooterStyle-BackColor="#D9D9D9" CellPadding="3" DataKeyField="contingency_id">
                <SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
                <Columns>
                        <asp:TemplateColumn HeaderImageUrl="assets/img/Search.gif">
					        <HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					        <ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
					        <ItemTemplate>
						        <asp:ImageButton ImageUrl="assets/img/Plus.gif" CommandName="Expand" ID="btnExpand" Runat="server"></asp:ImageButton>
					        </ItemTemplate>
				        </asp:TemplateColumn>
				
                        <asp:TemplateColumn HeaderText="Seq. No" HeaderStyle-Font-Bold="True">
                        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle VerticalAlign="Top" HorizontalAlign="center"  Width="10px" BackColor="#EAEFF3"></ItemStyle>
                        <ItemTemplate>
                                <%#(grdEstimateMaterials.PageSize * grdEstimateMaterials.CurrentPageIndex) + Container.ItemIndex + 1%><br />
                        </ItemTemplate>
                        </asp:TemplateColumn> 
                        
						<asp:TemplateColumn SortExpression="Group_name" HeaderText="Group name" HeaderStyle-Font-Bold="True"
						HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle  VerticalAlign="Top" BackColor="#EAEFF3"  Wrap="true" Width="150px" HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
						   <asp:Label id="lblgrp"  runat="server" BorderStyle="None" BorderWidth=0 BackColor="#EAEFF3" Width="150px"
							         Text='<%# DataBinder.Eval(Container, "DataItem.Group_name") %>'>
							        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:Label id="txtgrp"   runat="server" Width="150px" Height="50px"  
							        Text='<%# DataBinder.Eval(Container, "DataItem.Group_name") %>'>
							        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							</asp:Label>
						</EditItemTemplate>
					    </asp:TemplateColumn>
					    
					    <asp:TemplateColumn SortExpression="Description" HeaderText="Description" HeaderStyle-Font-Bold="True"
						HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle  BackColor="#EAEFF3" VerticalAlign="Top"   Wrap="true" Width="200px" HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
						    <asp:label id="lbldesc" style="white-space: normal" runat="server" BorderStyle=None BorderWidth=0 BackColor="#EAEFF3" Width="200px" Height="50px"  TextMode="MultiLine" MaxLength="2000"
							         Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
							        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							 </asp:label> 
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox id="txtdesc"   runat="server" Width="200px" Height="50px"  TextMode="MultiLine" MaxLength="2000"
							        Wrap="true" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
							        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							</asp:TextBox>
						</EditItemTemplate>
					    </asp:TemplateColumn>	
					    			    
                        <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle VerticalAlign="Top"   HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
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
				            <ItemStyle VerticalAlign="Top"  BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
				            <ItemTemplate>
					            <asp:LinkButton id="lnkbutDelete" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
						            CommandName="DELETE" CausesValidation="false">
				                </asp:LinkButton>
				             </ItemTemplate>
		                </asp:TemplateColumn>
		                
				      <asp:TemplateColumn ItemStyle-BackColor="#D9D9D9" HeaderStyle-BackColor="#D9D9D9" >
					            <ItemStyle VerticalAlign="Top"  HorizontalAlign="Center"   ForeColor="#EAEFF3" CssClass="subnav"></ItemStyle>
					            <ItemTemplate>
						            <asp:PlaceHolder ID="ExpandedContent" Visible="False" Runat="server">
							            <%# ShowClosingTags() %>
							            <table id='Dynacontent' border="1" style="background-color:Silver" align="center" width="50%">
								            <colgroup>
									            <col width="10%">
									            <col width="40%">
								            </colgroup>
								            <tr>
									             <td>
										            <uc1:DynamicTable id="DynamicTable1" runat="server"></uc1:DynamicTable>
									            </td>
								            </tr>
							            </table>
						            </asp:PlaceHolder>
					            </ItemTemplate>
				     </asp:TemplateColumn>                                    
                </Columns>
                <PagerStyle Mode="NumericPages"></PagerStyle>
            </asp:datagrid>  
            <br />
		    <button class="button" style="width:127px" id="Button1" 
            onclick="popupfunction('add_new_master_contingency.aspx');" type="button">Add New Contingency</button>        
        </contenttemplate>        
      </asp:UpdatePanel>
<script type="text/javascript" language="javascript">
var theForm = document.forms[0];
window.name = 'IEAdvanceQueue';
var agreewin = "";
function popupfunction(url) {
    var pageName = url;
    //var parameters = "?EstNum=" + myTextField.value;
    url = pageName;
    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Contingency Maintenance", "width=600px,height=500px,center=1,resize=1,scrolling=0", "recal")
    agreewin.onclose = function() { //Define custom code to run when window is closed
        return true //Allow closing of window in both cases
    }
}
 </script>
</asp:Content>

