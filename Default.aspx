<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
    <title>Untitled Page</title>
    <style type="text/css">
    /*
Tab Control 02/11/2010
*/
.fancy .ajax__tab_header 
{
	font-size:13px;
	font-weight:bold;
	color:#000000;
    font-family:sans-serif;
     background:url(assets/img/blue_bg.jpg) repeat-x;
}
.fancy .ajax__tab_active .ajax__tab_outer,
.fancy .ajax__tab_header .ajax__tab_outer,
.fancy .ajax__tab_hover .ajax__tab_outer
{
    height:46px;
    background:url(assets/img/blue_left.jpg) no-repeat left top;
}
.fancy .ajax__tab_active .ajax__tab_inner,
.fancy .ajax__tab_header .ajax__tab_inner,
.fancy .ajax__tab_hover .ajax__tab_inner
{
    height:46px;
    margin-left:16px; /* offset the width of the left image */
    background:url(assets/img/blue_right.jpg) no-repeat right top;
}
.fancy .ajax__tab_active .ajax__tab_tab,
.fancy .ajax__tab_hover .ajax__tab_tab,
.fancy .ajax__tab_header .ajax__tab_tab
{
	margin:16px 16px 0px 0px;
}
.fancy .ajax__tab_hover .ajax__tab_tab,
.fancy .ajax__tab_active .ajax__tab_tab 
{
	color:#cccccc;
}
.fancy .ajax__tab_body 
{
    font-family:verdana,tahoma,helvetica;
    font-size:10pt;
    border:1px solid #999999;
    border-top:0;
    padding:2px;
    background-color:#666666;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <table cellpadding="2" cellspacing="2" width="50%" bgcolor="#ffccff">
                <tr>
                    <td align="left">
                        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" CssClass="fancy"
                            ActiveTabIndex="0">
                            <ajaxToolkit:TabPanel ID="TabAboutUs" runat="server" HeaderText="About Me">
                                <ContentTemplate>
                                    <table cellspacing="2" cellpadding="2" background="img/Bg2.gif" width="100%" height="300">
                                        <tr align="left" valign="top">
                                            <td>
                                                <h3>
                                                    Purushottam Rathore
                                                 </h3>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabAddress" runat="server" HeaderText="Address">
                                <ContentTemplate>
                                    <table cellspacing="2" cellpadding="2" width="100%" background="img/Bg2.gif" height="300">
                                        <tr align="left" valign="top">
                                            <td>
                                                <h3>
                                                    Noida</h3>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabCountry" runat="server" HeaderText="Country">
                                <ContentTemplate>
                                    <table cellspacing="2" cellpadding="2" width="100%" height="300" background="img/Bg2.gif">
                                        <tr align="left" valign="top">
                                            <td>
                                                <h3>
                                                    India</h3>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPhoto" runat="server" HeaderText="My Photo">
                                <ContentTemplate>
                                    <table cellspacing="2" cellpadding="2" width="100%" height="300" bgcolor="WhiteSmoke">
                                        <tr align="left" valign="top">
                                            <td>
                                                <img src="puru.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
