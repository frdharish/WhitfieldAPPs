<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TallPDFTest.aspx.cs" Inherits="TallPDFTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Invoice Form</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/tc.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body class="main">
		<form id="Form1" method="post" runat="server">
			<asp:table id="companyTable" runat="server" Width="100%">
				<asp:TableRow>
					<asp:TableCell HorizontalAlign="Left" Text="
						&lt;b&gt;INVOICE&lt;/b&gt;"></asp:TableCell>
					<asp:TableCell HorizontalAlign="Right">
						(company)
<asp:TextBox runat="server" ID="companyName"></asp:TextBox>
</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
						(address)
<asp:TextBox runat="server" ID="companyAddress"></asp:TextBox>
</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
						(postalcode)
<asp:TextBox runat="server" ID="companyPostalCode"></asp:TextBox>
</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
						(country)
<asp:TextBox runat="server" ID="companyCountry"></asp:TextBox>
</asp:TableCell>
				</asp:TableRow>
			</asp:table>
			<hr>
			<P><asp:table id="invoiceTable" runat="server" Width="100%">
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right">
							Number
<asp:TextBox Runat="server" ID="invoiceNumber" />
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right">
							Date
<asp:TextBox Runat="server" ID="invoiceDate" />
						</asp:TableCell>
					</asp:TableRow>
				</asp:table><asp:table id="infoTable" runat="server" Width="100%">
					<asp:TableRow>
						<asp:TableCell Width="45%" VerticalAlign="Top">
							<asp:Table Width="100%" Runat="server" id="billToTable">
								<asp:TableRow>
									<asp:TableCell HorizontalAlign="Left" ColumnSpan="2">
										<b>Bill to:</b></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Name</asp:TableCell>
									<asp:TableCell Width="100%">
										<asp:TextBox id="billToName" Runat="server" Width="100%" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Address</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox id="billToAddress" Runat="server" Width="100%" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Contact person</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox id="billToContact" Runat="server" Width="100%" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Fax</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox id="billToFax" Runat="server" Width="100%" />
									</asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</asp:TableCell>
						<asp:TableCell Width="10%"></asp:TableCell>
						<asp:TableCell Width="45%" VerticalAlign="Top">
							<asp:Table Width="100%" Runat="server" ID="Table4">
								<asp:TableRow>
									<asp:TableCell HorizontalAlign="Left" ColumnSpan="2">
										<b>Ship to:</b></asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Method</asp:TableCell>
									<asp:TableCell Width="100%">
										<asp:TextBox Runat="server" Width="100%" ID="shipMethod" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Name</asp:TableCell>
									<asp:TableCell Width="100%">
										<asp:TextBox Runat="server" Width="100%" ID="shipName" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Address</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox Runat="server" Width="100%" ID="shipAddress" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>Contact person</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox Runat="server" Width="100%" ID="shipContact" />
									</asp:TableCell>
								</asp:TableRow>
								<asp:TableRow>
									<asp:TableCell nowrap>e-mail</asp:TableCell>
									<asp:TableCell>
										<asp:TextBox Runat="server" Width="100%" ID="shipEmail" />
									</asp:TableCell>
								</asp:TableRow>
							</asp:Table>
						</asp:TableCell>
					</asp:TableRow>
				</asp:table></P>
			<P><asp:table id="orderTable" runat="server" Width="100%">
					<asp:TableRow BackColor="#FFFF80">
						<asp:TableCell Width="60%" Text="Item"></asp:TableCell>
						<asp:TableCell Width="15%" Text="Quantity"></asp:TableCell>
						<asp:TableCell Width="15%" Text="Unit price"></asp:TableCell>
						<asp:TableCell Width="10%" Text="Line total"></asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="Textbox1" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="quantity1" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="unit1" />
						</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="Textbox2" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="Textbox4" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="Textbox5" />
						</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="item2" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="quantity2" />
						</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="unit2" />
						</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell>
							<asp:Button id="btnAddLine" runat="server" Text="Add line"></asp:Button>
						</asp:TableCell>
						<asp:TableCell HorizontalAlign="Right" ColumnSpan="2">Subtotal</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right" ColumnSpan="3">Shipping & Handling</asp:TableCell>
						<asp:TableCell>
							<asp:TextBox Width="100%" Runat="server" ID="shippingAndHandling" />
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="shippingAndHandling"></asp:RequiredFieldValidator>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right" ColumnSpan="3">
							<input type="checkbox" Runat="server" ID="chkVAT" class="checkbox" NAME="chkVAT">19% VAT
						</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell HorizontalAlign="Right" ColumnSpan="3">Payment due</asp:TableCell>
						<asp:TableCell>&lt;calculated&gt;</asp:TableCell>
					</asp:TableRow>
				</asp:table></P>
			<hr>
			<B>Payment<BR>
			</B><input type="radio" name="paymentSelection" runat="server" ID="PaymentFull" VALUE="paidInFull"
				class="checkbox" onclick="__doPostBack('PaymentFull','')">Paid in full<BR>
			<input type="radio" name="paymentSelection" runat="server" ID="PaymentCheck" VALUE="sendCheck"
				CHECKED class="checkbox" onclick="__doPostBack('PaymentCheck','')">Send 
			check payable to (company)<BR>
			<input type="radio" name="paymentSelection" runat="server" ID="PaymentOnline" VALUE="purchaseOnline"
				class="checkbox" onclick="__doPostBack('PaymentOnline','')">Purchase online 
			using our shopping basket {URL}<BR>
			<!--<asp:radiobuttonlist id="paymentSelection" runat="server" AutoPostBack="True">
				<asp:ListItem Value="paidInFull" Selected="True">Paid in full</asp:ListItem>
				<asp:ListItem Value="sendCheck">Send check payable to (company)</asp:ListItem>
				<asp:ListItem Value="purchaseOnline">Purchase online using our shopping basket {URL}</asp:ListItem>
			</ASP:RADIOBUTTONLIST>-->
			&nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" id="chkDiscountCoupon" Runat="server" class="checkbox" disabled
				NAME="chkDiscountCoupon">Your discount coupon:
			<asp:textbox id="discountCoupon" runat="server" Enabled="False"></asp:textbox>
			<hr>
			<B>Remarks</B>
			<asp:textbox id="remarks" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox>
			<br>
			<asp:button id="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></asp:button>
		</form>
	</body>
</HTML>
