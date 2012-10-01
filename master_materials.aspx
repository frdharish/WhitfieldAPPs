<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="master_materials.aspx.cs" Inherits="master_materials" %>
<%@ Register TagPrefix="uc1" TagName="submaterial" Src="submaterial.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:UpdatePanel ID="UpdatePanelquad" runat="server">    
<contenttemplate>  
<table align='center'>
<tr>

	<td class="form1"><b>Search by Material Type:</b><BR>
            <asp:DropDownList id="ddlMatType"  CssClass="form1"  runat="server" 
            AutoPostBack=true  onselectedindexchanged="ddlMatType_SelectedIndexChanged"></asp:DropDownList>
    </td>
</tr>
</table>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
	<td align="left"><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" Width="100%" BorderStyle="None"
			BorderWidth="0px"></asp:textbox>
			<b>Material Maintenance Module</b><br />
		<!-- DataGrid is going to be here -->
            <asp:Button ID="btnexport" runat="server" CausesValidation="False" 
                                         CssClass="button" onclick="btnexport_Click" Text="Excel Export" />			
             <asp:datagrid id="grdpl1" runat="server"  BorderStyle="Solid" Width="100%" CssClass="data" BackColor="WhiteSmoke" ItemStyle-Wrap="False"
			OnDeleteCommand="grdpl1_DeleteCommand" DataKeyField="material_id" OnCancelCommand="grdpl1_CancelCommand"
			OnItemCommand="grdpl1_Itemcommand" OnUpdateCommand="grdpl1_UpdateCommand" OnEditCommand="grdpl1_EditCommand" FooterStyle-Font-Name="Verdana"
			FooterStyle-Font-Size="10pt" FooterStyle-Font-Bold="True" FooterStyle-ForeColor="#ffff99"
			FooterStyle-BackColor="#D9D9D9"  AutoGenerateColumns="False"
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
				
				<asp:BoundColumn DataField="material_id" SortExpression="material_id" HeaderStyle-Font-Bold="True"
					HeaderText="material id" HeaderStyle-Wrap="false" Visible="false">
					<HeaderStyle HorizontalAlign="center" CssClass="subnav"></HeaderStyle>
					<ItemStyle></ItemStyle>
				</asp:BoundColumn>
				
			
				<asp:TemplateColumn SortExpression="Mat_type_Desc" HeaderText="Primary Material Type" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblMat_type_Desc" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Mat_type_Desc")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                   <asp:Label id="lblMat_type_Desc1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Mat_type_Desc")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
			
				<asp:TemplateColumn SortExpression="Reference_Number" HeaderText="Material Type" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblReference_Number" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Reference_Number")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtReference_Number" ValidationGroup="editmode" runat="server" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Reference_Number") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvRefNumber" runat="server" Display="Dynamic" ErrorMessage="Please enter a Reference Number"
						                ControlToValidate="txtReference_Number"></asp:RequiredFieldValidator>
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
				                    <asp:TextBox Width="200" id="txtDescription" runat="server" ValidationGroup="editmode" TextMode="MultiLine" Rows="3"  Columns="40" MaxLength="150" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvDescription" runat="server" Display="Dynamic" ErrorMessage="Please enter a Description"
						                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				

				
				<asp:TemplateColumn SortExpression="Comments" HeaderText="Comments" HeaderStyle-Font-Bold="True">
				        <HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				        <ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
				        <ItemTemplate>
					                <asp:Label id="lblComments" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Comments")%>'>
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
				        </ItemTemplate>
				        <EditItemTemplate>
				                    <asp:TextBox Width="200" id="txtComments" runat="server" ValidationGroup="editmode" TextMode="MultiLine" Rows="3"  Columns="40" Text='<%# DataBinder.Eval(Container, "DataItem.Comments") %>' >
					                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
					                <asp:RequiredFieldValidator id="rfvComments" runat="server" Display="Dynamic" ErrorMessage="Please enter a Comments"
						                ControlToValidate="txtComments"></asp:RequiredFieldValidator>
				        </EditItemTemplate> 
				</asp:TemplateColumn>
				
                <asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Left" HeaderText="EDIT">
				<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
				<ItemStyle HorizontalAlign="center" BackColor="#EAEFF3"></ItemStyle>
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
				    <ItemStyle BackColor="#EAEFF3" HorizontalAlign="center"></ItemStyle>
				    <ItemTemplate>
					    <asp:LinkButton id="lnkbutDelete" runat="server" Text="<img border=0 src=assets/img/DELETE.gif alt=DELETE>"
						    CommandName="DELETE" CausesValidation="false">
				        </asp:LinkButton>
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
										<uc1:submaterial id="DynamicTable1" runat="server"></uc1:submaterial>
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
            onclick="popupfunction('add_new_material.aspx');" type="button">Add New Material</button>
	</td>
</tr>
</table>	
</contenttemplate>
        <Triggers>
            <asp:PostBackTrigger  ControlID="btnexport" />
         </Triggers>
</asp:UpdatePanel>
<script type="text/javascript" language="javascript">
var theForm = document.forms[0];
window.name = 'IEAdvanceQueue';
var agreewin = "";
function popupfunction(url) {
    var pageName = url;
    //var parameters = "?EstNum=" + myTextField.value;
    url = pageName;
    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Material Maintenance", "width=600px,height=500px,center=1,resize=1,scrolling=0", "recal")
    agreewin.onclose = function() { //Define custom code to run when window is closed
        return true //Allow closing of window in both cases
    }
}
 </script>
</asp:Content>

