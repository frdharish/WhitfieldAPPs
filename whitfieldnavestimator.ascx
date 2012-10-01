<%@ Control Language="C#" AutoEventWireup="true" CodeFile="whitfieldnavestimator.ascx.cs" Inherits="whitfieldnavestimator" %>
<!-- ACTUAL NAV CODE -->
<STYLE TYPE="text/css"> @import url(assets/css/horizNav.css); 
</STYLE>
<SCRIPT LANGUAGE="Javascript"     Src="assets/js/horizNav.js" TYPE="text/javascript"></SCRIPT>

			<!-- Header code Ends -->
<!-- ACTUAL NAV CODE -->
<TABLE WIDTH="100%" CELLPADDING="0" CELLSPACING="0" BORDER="0">
	<TR>
		<TD BACKGROUND="assets/img/bavbg.gif">
			<!-- Overall Wrapper / BG Image -->
			<DIV ID="topNav" CLASS="navBar" STYLE="BACKGROUND-IMAGE: url(assets/img/bavbg.gif); HEIGHT: 28px">
		
				<!-- Estimates -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" STYLE="BACKGROUND-IMAGE: none" onclick="goTo('#');">Estimates</DIV>
					<DIV CLASS="dropContainer">
						<DIV CLASS="dropMenu">
									<DIV CLASS="dropItem"><A HREF="whitfield_estimation.aspx?createNew=1" name="estimation">Add New Estimate</A></DIV>
									<DIV CLASS="dropItem"><A HREF="SearchProjects.aspx" name="EdtEstimate">Edit existing Estimate</A></DIV>
									<DIV CLASS="dropItem"><A HREF="manageclients.aspx" NAME="Clients">Manage Clients</A></DIV>
									<DIV CLASS="dropItem"><A HREF="manage_competition.aspx" NAME="Compe">Manage Competition</A></DIV>
									<DIV CLASS="dropItem"><A HREF="manage_arch.aspx" NAME="Architect">Manage Architects</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_contingency.aspx" NAME="Finishes">Master Contingencies</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_terms.aspx" NAME="Finishes">Master Terms</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_quals.aspx" NAME="Finishes">Master Qualifications</A></DIV>
						</DIV>
					</DIV>
				</DIV>
			</DIV>
	    </TD>
	</TR>
</TABLE>
<TABLE WIDTH="100%" CELLPADDING="0" CELLSPACING="0" BORDER="0">
	<TR>
		<TD WIDTH="100%" HEIGHT="12" BGCOLOR="#60829F" BACKGROUND="assets/img/sub_bg.jpg">
			<TABLE CELLPADDING="0" CELLSPACING="0" BORDER="0">
				<TR>
					<TD HEIGHT="12" WIDTH="19" VALIGN="middle"><IMG     Src="assets/img/spacer.gif" WIDTH="19" HEIGHT="12" ALT=""></TD>
					<TD HEIGHT="12" VALIGN="middle"></TD>
				</TR>
			</TABLE></TD>
	</TR>
		<TR>
		<TD BGCOLOR="#ffffff"><IMG     Src="assets/img/spacer.gif" WIDTH="1" HEIGHT="1" ALT=""></TD>
	</TR>
	<TR>
		<TD BGCOLOR="#CA0000" BACKGROUND="assets/img/top_color.jpg"><IMG     Src="assets/img/spacer.gif" WIDTH="1" HEIGHT="7" ALT=""></TD>
	</TR>
</TABLE>