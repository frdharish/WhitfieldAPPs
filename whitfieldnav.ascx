<%@ Control Language="C#" AutoEventWireup="true" CodeFile="whitfieldnav.ascx.cs" Inherits="whitfieldnav" %>
<!-- ACTUAL NAV CODE -->
<STYLE TYPE="text/css"> @import url(assets/css/horizNav.css);</STYLE>
<SCRIPT LANGUAGE="Javascript" Src="assets/js/horizNav.js" TYPE="text/javascript"></SCRIPT>
<TABLE WIDTH="100%" CELLPADDING="0" CELLSPACING="0" BORDER="0">
	<TR>
		<TD BACKGROUND="assets/img/bavbg.gif">
			<!-- Overall Wrapper / BG Image -->
			<DIV ID="topNav" CLASS="navBar" STYLE="BACKGROUND-IMAGE: url(assets/img/bavbg.gif); HEIGHT: 28px">
		
				<!-- Company -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" STYLE="BACKGROUND-IMAGE: none" onclick="goTo('#');">Estimates</DIV>
					<DIV CLASS="dropContainer">
								<DIV CLASS="dropMenu">
									<DIV CLASS="dropItem"><A HREF="whitfield_estimation.aspx?createNew=1" name="estimation">Add New Estimate</A></DIV>
									<DIV CLASS="dropItem"><A HREF="SearchProjects.aspx" NAME="EdtEstimate">Search existing Estimate</A></DIV>									
								</DIV>
					</DIV>
				</DIV>
				<!-- Projects -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" onclick="goTo('#');">Lists</DIV>
					<DIV CLASS="dropContainer">
								<DIV CLASS="dropMenu">
									<DIV CLASS="dropItem"><A HREF="manageclients.aspx" NAME="Clients">Manage Clients</A></DIV>
									<DIV CLASS="dropItem"><A HREF="manage_competition.aspx" NAME="Compe">Manage Competition</A></DIV>
									<DIV CLASS="dropItem"><A HREF="manage_arch.aspx" NAME="Architect">Manage Architects</A></DIV>
									<DIV CLASS="dropItem"><A HREF="master_materials.aspx" NAME="materials">Master Materials Listing</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_contingency.aspx" NAME="Finishes">Master Contingencies</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_terms.aspx" NAME="Finishes">Master Terms</A></DIV>
							        <DIV CLASS="dropItem"><A HREF="master_quals.aspx" NAME="Finishes">Master Qualifications</A></DIV>
								</DIV>
				    </DIV>
		            
				</DIV>
				<!-- Projects -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" onclick="goTo('#');">Projects</DIV>
					<DIV CLASS="dropContainer">
								<DIV CLASS="dropMenu">
									<DIV CLASS="dropItem"><A HREF="whitfield_project_listing.aspx" NAME="projInfo">Project Listing</A></DIV>
									<DIV CLASS="dropItem"><A HREF="daily_prod_report.aspx" NAME="invoice">Daily Production Report</A></DIV>
									<DIV CLASS="dropItem"><A HREF="twc_project_scheduling.aspx" NAME="invoice">Project Schedule Report</A></DIV>
									<DIV CLASS="dropItem"><A HREF="twc_weekly_project_scheduling.aspx" NAME="invoice">Project Weekly Schedule Report</A></DIV>
								</DIV>
				    </DIV>
		            
				</DIV>
				<!-- Finance -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" onclick="goTo('#');">Finance</DIV>
							<DIV CLASS="dropContainer">
								<DIV CLASS="dropMenu">
									<DIV CLASS="dropItem"><A HREF="#" NAME="overhead">Overhead Expenses</A></DIV>
									<DIV CLASS="dropItem"><A HREF="Whitfield_financialmgmt.aspx" NAME="invoice">Project Invoicing</A></DIV>
									<DIV CLASS="dropItem"><A HREF="#" NAME="projcosting">Project Costing</A></DIV>
									<DIV CLASS="dropItem"><A HREF="whitfield_payroll.aspx" NAME="payroll">Payroll</A></DIV>
								</DIV>
							</DIV>
				</DIV>
				<!-- General Administration -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" onclick="goTo('#');">General Administration</DIV>
					<DIV CLASS="dropContainer">
						<DIV CLASS="dropMenu">
							<DIV CLASS="dropItem"><A HREF="whitfield_users.aspx" NAME="Personnals">Personnels</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Vendors">Vendors</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Clients">Clients</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Government">Government</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Equipment">Equipment</A></DIV>
						</DIV>
					</DIV>
				</DIV>
				
				<!-- General Administration -->
				<DIV CLASS="collapsed">
					<DIV CLASS="navItem" onclick="goTo('#');">General Business</DIV>
					<DIV CLASS="dropContainer">
						<DIV CLASS="dropMenu">
							<DIV CLASS="dropItem"><A HREF="#" NAME="cert">Certifiations</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Ins">Insurance</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="Bonding">Bonding</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="sop">Standard Operating Procedures</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="safety">Safety</A></DIV>
							<DIV CLASS="dropItem"><A HREF="#" NAME="sandm">Sales and Marketing</A></DIV>
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