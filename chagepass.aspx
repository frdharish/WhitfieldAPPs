<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chagepass.aspx.cs" Inherits="chagepass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Whitfield-co Project management systetms</title>
	<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
	<meta name="CODE_LANGUAGE" Content="C#" />
	<meta name="vs_defaultClientScript" content="JavaScript" />
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
</head>
<body>
    <form id="form1" runat="server">
<div>
        <TABLE cellSpacing="0" cellPadding="0" border="0">
            <TR>
		        <TD class="form1">Login id:<br />
			        <asp:textbox id="txtloginid" runat="server" MaxLength="17"></asp:textbox>
			        <br /><asp:RequiredFieldValidator ID="rrloginid" ControlToValidate="txtloginid" InitialValue="" Display=Static ErrorMessage="login id is Required" runat="server"></asp:RequiredFieldValidator>
		        </TD>
            </TR>
            <TR>
		        <TD class="form1">Old Password:<br />
			        <asp:textbox id="txtoldpasswd" runat="server" MaxLength="17" TextMode="Password"></asp:textbox>
			        <br /><asp:RequiredFieldValidator ID="rroldpasswd" ControlToValidate="txtoldpasswd" InitialValue="" Display=Static ErrorMessage="old password is Required" runat="server"></asp:RequiredFieldValidator>
		        </TD>
            </TR>
            <TR>
		        <TD class="form1">New Password:<br />
			        <asp:textbox id="txtnewpasswd" runat="server" MaxLength="17" TextMode="Password"></asp:textbox>
			        <br /><asp:RequiredFieldValidator ID="rrnewpasswd" ControlToValidate="txtnewpasswd" InitialValue="" Display=Static ErrorMessage="New password is Required" runat="server"></asp:RequiredFieldValidator>
		        </TD>
            </TR>
         </TABLE>
         <TABLE>
			<TR>
				<TD  align="center" class="form1" colSpan="5">
				    <asp:button id="btnupdate" runat="server" Text="Change Password" 
                        CssClass="button" onclick="btnupdate_Click"></asp:button>&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="lblErrMsg" runat=server Font-Bold=true ForeColor=Maroon></asp:Label>
				</TD>
			</TR>
		</TABLE>
</div>
    </form>
</body>
</html>
