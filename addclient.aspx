<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="addclient.aspx.cs" Inherits="addclient" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<table  align="center" cellSpacing="0" cellPadding="0" border="0">

 <tr>
    <tr>
        <TD valign=top class="form1" colspan="3" >Client Name:<br />
	        <asp:textbox id="txtclientname" runat="server" MaxLength="100" Width="240px"></asp:textbox>
	        <br /><asp:RequiredFieldValidator ID="rrcname" ControlToValidate="txtclientname" ErrorMessage="Client Name is Required"
                    runat="server"></asp:RequiredFieldValidator><asp:HiddenField ID="hidclient" runat="server" />
        </TD>

        <TD valign=top class="form1" style="width: 151px" colspan="2" >Client Type:<br />
	        <asp:dropdownlist id="ddlClientType"  runat="server"></asp:dropdownlist>
	        <br /><asp:RequiredFieldValidator ID="rrcType" ControlToValidate="ddlClientType"  InitialValue="0" ErrorMessage="Client Type is Required" 
                    runat="server"></asp:RequiredFieldValidator>
        </TD>
    </tr>
    <tr>
        <td valign=top class="form1" colspan="3" >Street:<br />
			<asp:textbox id="txtstreet" runat="server" MaxLength="50" Width="240px"></asp:textbox></br>
        </td>
        <td valign=top class="form1" colspan="2" >Web:<br />
			<asp:textbox id="txtWeb" runat="server" Width="300px"></asp:textbox>
        </td>    
    </tr>
    <tr>
        <TD vAlign="top" class="form1" style="width: 105px"></br>City:<br />
	        <asp:dropdownlist id="ddlCity" runat="server" Width="95px" ></asp:dropdownlist>
        </TD>       
        <td valign=top class="form1" style="width: 75px"></br>State:<br />
            <asp:dropdownlist id="ddlState" runat="server" Width="50px" ></asp:dropdownlist><br />
	        <asp:RequiredFieldValidator ID="rrState" ControlToValidate="ddlState" ErrorMessage="State is Required" runat="server"></asp:RequiredFieldValidator>
        </td>
        <td valign="top" class="form1" style="width: 70px" ></br>Zip Code:<br />
			<asp:textbox id="Textbox1" runat="server" MaxLength="12" Width="50px"></asp:textbox>
		</td>
        <td valign="top"  class="form1" colspan="2" ></br>FTP:<br />
			<asp:textbox id="txtFTP" runat="server" Width="300px"></asp:textbox>
        </td>
    </tr>
    <tr>
        <td valign="top" class="form1" colspan="1.5" >Phone:<br />
				        <asp:textbox id="txtPhNumber" runat="server" MaxLength="17" ValidationGroup="MKE" Width="75px"></asp:textbox>
				         <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                            TargetControlID="txtPhNumber"
                            Mask="999-999-9999"
                            ClearMaskOnLostFocus="false"
                            MessageValidatorTip="true"
                            MaskType="None"
                            InputDirection="LeftToRight"
                            AcceptNegative="Left"
                            DisplayMoney="Left" Filtered="-"
                            />
                        <ajaxToolkit:MaskedEditValidator id="MaskedEditValidator2" runat="server"
                            ControlExtender="MaskedEditExtender2"
                            ControlToValidate="txtPhNumber"
                            IsValidEmpty="False" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                            EmptyValueMessage="input is required"
                            InvalidValueMessage="input is invalid"
                            Display="Dynamic"
                            TooltipMessage="XXX-XXX-XXXX"
                            EmptyValueBlurredText="Phone number should not be empty!"
                            InvalidValueBlurredMessage="Please input the right phone number!"
                            ValidationGroup="MKE" />

                </td>   

        <td valign="top" class="form1" >Fax:<br />
				        <asp:textbox id="txtFaxNumber" runat="server" MaxLength="17" ValidationGroup="MKE1" Width="75px"></asp:textbox>
				        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                            TargetControlID="txtFaxNumber"
                            Mask="999-999-9999"
                            ClearMaskOnLostFocus="false"
                            MessageValidatorTip="true"
                            MaskType="None"
                            InputDirection="LeftToRight"
                            AcceptNegative="Left"
                            DisplayMoney="Left" Filtered="-"
                            />
                        <ajaxToolkit:MaskedEditValidator id="MaskedEditValidator1" runat="server"
                            ControlExtender="MaskedEditExtender1"
                            ControlToValidate="txtFaxNumber"
                            IsValidEmpty="True" ValidationExpression ="[0-9]{3}\-[0-9]{3}\-[0-9]{4}"
                            InvalidValueMessage="input is invalid"
                            Display="Dynamic"
                            TooltipMessage="XXX-XXX-XXXX"
                            InvalidValueBlurredMessage="Please input the right Fax number!"
                            ValidationGroup="MKE1" />
                </td>
                  <td valign="top" width="30"><IMG alt="" Src="assets/img/spacer.gif" width="30"></td>
        <td valign="top" class="form1">Login:<br />
			<asp:textbox id="txtLogin" runat="server" MaxLength="17" Width="150px"></asp:textbox>
        </td> 
        <td valign="top" class="form1">Password:<br />
			<asp:textbox id="txtPass" runat="server" MaxLength="12" Width="85px"></asp:textbox>
        </td>
    </tr>

</tr>
 <tr>
    <td valign="top" class="form1" colspan="5"></br>Notes:<br />
		<asp:textbox id="txtNotes" runat="server" TextMode=MultiLine Rows="6" cols="80" Width="565px"></asp:textbox>
    </td>
 </tr> 
    <tr>
                <td valign="top" class="form1" colspan="5"><br />Contacts:<br />
                <asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
													Width="100%"></asp:textbox><br />
				  <asp:datagrid id="grdRpResults" runat="server" CssClass="data" Width="98%" OnItemCreated="ResultGridItemCreated"
					OnPageIndexChanged="PageResultGrid" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
					CellPadding="3" DataKeyField="ContactID">
					<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
					<Columns>
						<asp:BoundColumn DataField="First" SortExpression="First" HeaderText="First Name" HeaderStyle-Font-Bold="true">
							<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Last" SortExpression="Last" HeaderText="Last Name">
							<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Tel" SortExpression="Tel" HeaderText="Phone number">
							<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="Email Address">
							<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle BackColor="#EAEFF3"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="EDIT">
							<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
							<ItemTemplate>
								<%# ShowEditImage(((DataRowView)Container.DataItem)["ClientID"], ((DataRowView)Container.DataItem)["ContactID"])%>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid>      

                </td>
    </tr>
	<tr>
	    <td  align="center" class="form1" colSpan="5">
			    <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
                    onclick="btnnew_Click"></asp:button>
                &nbsp;&nbsp;<input TYPE=button class="button" OnClick="popupcontact();" VALUE="Add Contacts"><br />
                <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=Larger></asp:Label>
		</td>
	</tr>
</table>			
<script type="text/javascript" language="javascript">
var theForm = document.forms[0];
window.name = 'IEAdvanceQueue';
var agreewin = "";
function popupcontact(url) {
    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_hidclient');
    var url = 'maintaincontact.aspx?clientid=' + myTextField.value;
    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Contacts Maintenance", "width=800px,height=400px,center=1,resize=1,scrolling=0", "recal")
    agreewin.onclose = function() { //Define custom code to run when window is closed
        return true //Allow closing of window in both cases
    }
}
function ShowEdit(ClientID,ContactID) {
    var myTextField = document.getElementById('ctl00_ContentPlaceHolder1_hidclient');
    var url = 'maintaincontact.aspx?contactid=' + ContactID.toString() + '&clientid=' + ClientID.toString();
    agreewin = dhtmlmodal.open("agreebox", "iframe", url, "Contacts Maintenance", "width=800px,height=400px,center=1,resize=1,scrolling=0", "recal")
    agreewin.onclose = function() { //Define custom code to run when window is closed
        return true //Allow closing of window in both cases
    }
}
</script>
</asp:Content>

