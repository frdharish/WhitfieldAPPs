<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="SearchProjects.aspx.cs" Inherits="SearchProjects" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<TABLE  width="50%" border="0" align='center'>
<TR>
<td class="form1">Project Name(User * from Wild Character):<BR>
        <asp:textbox id="txtEstName" runat="server" MaxLength="17"></asp:textbox>
<br />
Project Status:<br />
    <asp:dropdownlist id="ddlPrjStatus" runat="server"></asp:dropdownlist>
<br /> 
Estimator:<br />
    <asp:dropdownlist id="ddlEstimator" runat="server"></asp:dropdownlist>
</td>
</TR>
<tr>
<td class="form1">
	        <asp:button id="btnSelect" runat="server" 
            Text="Search" CssClass="button" onclick="btnSelect_Click"></asp:button>
</td>
</tr>
</TABLE>
<BR>
<TABLE align='center' cellSpacing="1" cellPadding="1" border="0" width="75%">
	<tr>
		<td><asp:textbox class="title" id="txtSelectionResultsMSG" runat="server" BorderWidth="0px" BorderStyle="None"
				Width="100%"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:datagrid id="grdRpResults" runat="server" CssClass="data" Width="75%" OnItemCreated="ResultGridItemCreated"
				OnPageIndexChanged="PageResultGrid"  PageSize="25" AllowPaging="True" AutoGenerateColumns="False" SelectedItemStyle-BackColor="LemonChiffon"
				CellPadding="3" DataKeyField="EstNum">
				<SelectedItemStyle BackColor="LemonChiffon"></SelectedItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ProjName" SortExpression="ProjName" HeaderText="Project Name" HeaderStyle-Font-Bold="true">
						<HeaderStyle HorizontalAlign="center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BidDate" SortExpression="BidDate" HeaderText="Bid Date">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Estimator" SortExpression="Estimator" HeaderText="Estimator Name">
						<HeaderStyle HorizontalAlign="center" Font-Bold="true" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle BackColor="#EAEFF3"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="EDIT">
						<HeaderStyle Font-Bold="true" HorizontalAlign="Center" BackColor="#60829F" CssClass="subnav"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" BackColor="#EAEFF3"></ItemStyle>
						<ItemTemplate>
							<%# ShowEditImage(((DataRowView)Container.DataItem)["EstNum"])%>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>
</TABLE>
<script type="text/javascript" language="javascript">

			var theForm = document.forms[0];
			window.name ='IEAdvanceQueue';
	        function ShowEdit(EstNum)
	        {
	            var pageName = "whitfield_estimation.aspx";
	            var parameters = "?EstNum=" + EstNum;
		        url =  pageName + 	parameters	
		        location.href=url;
		    }
		  
</script>
</asp:Content>

