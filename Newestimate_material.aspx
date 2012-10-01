<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newestimate_material.aspx.cs" Inherits="Newestimate_material" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to Whitfield-co Project management systetms</title>
	<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
	<meta name="CODE_LANGUAGE" Content="C#" />
	<meta name="vs_defaultClientScript" content="JavaScript" />
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <script src="assets/highslide/highslide-full.js" type="text/javascript"></script>
     <script type="text/javascript">
	        hs.align='center';
	        hs.graphicsDir = 'assets/highslide/graphics/';
	        hs.outlineType = 'rounded-white';
	        hs.outlineWhileAnimating = true;
	        hs.showCredits = false;
	        hs.moveText = '';
	</script>
</head>
<body>
<form id="Form1" name="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div>
    <table align='center'>
        <tr>

	        <td><b>Search by Material Type:</b><br>
                    <asp:DropDownList id="ddlMatType"  CssClass="form1"  runat="server" 
                            AutoPostBack=true  onselectedindexchanged="ddlMatType_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <div style="OVERFLOW-Y:scroll; WIDTH:700px; HEIGHT:592px;" >
<asp:UpdatePanel ID="UpdatePanelquad" runat="server">    
<contenttemplate>
     <asp:datagrid  id="grdRpResults" runat="server" CssClass="data" BorderWidth="1px" ItemStyle-Wrap="false"
			CellPadding="3" Width="85%" HeaderStyle-Wrap="False" 
            HeaderStyle-ForeColor="#ffffff" AlternatingItemStyle-BackColor="#EAEFF3"
			HeaderStyle-Font-Bold="True" HeaderStyle-BorderStyle="Dashed" ItemStyle-BackColor="LightGrey" 
			OnPageIndexChanged="PageResultGrid1"  HeaderStyle-BackColor="#60829F"	DataKeyField="sub_mat_id"  BackColor="LightGrey"  FooterStyle-BackColor="Silver"
			AllowPaging="True" PageSize="100" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
			AllowSorting="True">
			<FooterStyle BackColor="Silver" />
			<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#EAEFF3" />
            <ItemStyle BackColor="LightGray" Wrap="False" />
				<Columns>
					<asp:TemplateColumn HeaderText="contract">
                       <HeaderTemplate>
                            <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll"/>
                       </HeaderTemplate>
                       <ItemTemplate>
                            <input type="checkbox" runat="server" id="EmpId" onclick="CheckChanged();" checked="false" name="EmpId" />
                       </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Id" Visible="false">
                        <ItemTemplate>
                             <asp:Label id="Id" Text='<%# 
                                DataBinder.Eval(Container.DataItem, "sub_mat_id") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Mat_type_Desc" HeaderText="Mat_type_Desc"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Reference_Number" HeaderText="Ref Num"></asp:BoundColumn>
                    <asp:BoundColumn  DataField="description" HeaderText="description"></asp:BoundColumn>
                    <asp:BoundColumn DataField="uom_type_desc" HeaderText="UOM Type Desc"></asp:BoundColumn>
                    <asp:BoundColumn DataField="thickness" HeaderText="thickness"></asp:BoundColumn>
                    <asp:BoundColumn DataField="length" HeaderText="length"></asp:BoundColumn>
                    <asp:BoundColumn DataField="width" HeaderText="width"></asp:BoundColumn>
                    <asp:BoundColumn DataField="LEED" HeaderText="LEED"></asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			<HeaderStyle BackColor="#60829F" BorderStyle="Dashed" Font-Bold="True" 
                ForeColor="White" Wrap="False" />
			</asp:datagrid>
       </contenttemplate>
</asp:UpdatePanel> 
    </DIV>
    <asp:HiddenField ID="hidEstNum" runat="server" />
    <table>
        <tr>
	        <td  align="center" class="form1">
			        <asp:button id="btnnew" runat="server" Text="Submit Changes" CssClass="button" 
                        onclick="btnnew_Click"></asp:button>
                     &nbsp;&nbsp;<button id="eulabox"  class="button" name="eulabox" onclick="CloseandRefresh();" >Close</button>
                    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=Larger></asp:Label>
		    </td>
	    </tr>
    </table>
    </div>

        <script type="text/javascript">
            function CloseandRefresh() {
                var myTextField = document.getElementById('hidEstNum');
                parent.agreewin.hide();
                parent.location.replace('whitfield_estimation.aspx?EstNum=' + myTextField.value);
            }
        </script> 
    </form>
  
</body>
</html>
