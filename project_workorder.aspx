<%@ Page Language="C#" AutoEventWireup="true" CodeFile="project_workorder.aspx.cs" Inherits="project_workorder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to Whitfield Co Project Management Systems</title>
	<link rel="stylesheet" href="assets/css/styles.css" type="text/css" />
	<meta name="CODE_LANGUAGE" Content="C#" />
	<meta name="vs_defaultClientScript" content="JavaScript" />
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <script src="assets/highslide/highslide-full.js" type="text/javascript"></script>
     <script type="text/javascript">
         hs.align = 'center';
         hs.graphicsDir = 'assets/highslide/graphics/';
         hs.outlineType = 'rounded-white';
         hs.outlineWhileAnimating = true;
         hs.showCredits = false;
         hs.moveText = '';


         function formatNumber() {
             if (!(event.keyCode == 45 || event.keyCode == 46 || event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) { event.returnValue = false; }
         }
	</script>
    <style type="text/css">
        .style1
        {
            width: 183px;
        }
        .style2
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            color: #000000;
            text-decoration: none;
            width: 183px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <table width="100%" border="0" >
            <tr>
                <td>
                
                    <table width="100%" border="0">
                        <tr>                        
                            <td width="65%">Description:</br><asp:textbox id="txtdesc" width="95%" runat="server" Font-Names="Arial" Font-Size=Small MaxLength="50"></asp:textbox></td>
                            <td width="35%">Drawing Reference:</br><asp:TextBox ID="txtreftext" runat="server" MaxLength="100" Width="95%"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table width="100%" border="0" >

	                    <tr>
                            <td class="form1">Notes/Comments:<br />
	                            <asp:textbox id="txtNotes" width="95%"
	                            runat="server" Font-Names="Arial" Font-Size=Small TextMode=MultiLine Rows="5" cols="80"></asp:textbox><br />
	                        </td>
                <td width="25%" >          
	                <table>
	                        <tr>
	                            <td align="right" valign="center" >Engineering Hours:</td>
	                            <td align="left" valign="center" ><asp:TextBox ID="txtEngHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtEngHours')"></asp:TextBox></td>
	                        </tr>
	                        <tr>
	                            <td align="right" valign="center" >Fabrication Hours:</td>
	                            <td align="left" valign="center" ><asp:TextBox ID="txtFabHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtFabHours')"></asp:TextBox> </td>
	                        </tr>
	                        <tr>
	                            <td align="right" valign="center" >Finishing Hours:</td>
	                            <td align="left" valign="center" ><asp:TextBox ID="txtFinishHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtFinishHours')"></asp:TextBox></td>
	                        </tr>
	                            <tr>
	                            <td align="right" valign="center" >Installation Hours:</td>
	                            <td align="left" valign="center" ><asp:TextBox ID="txtInstallHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtInstallHours')"></asp:TextBox></td>
	                        </tr>
	                        <tr>
	                            <td align="right" valign="center" >Miscellaneous Hours:</td>
	                            <td align="left" valign="center" ><asp:TextBox ID="txtMiscHours" MaxLength="5" Width="30px" runat="server" onkeypress="formatNumber('txtMiscHours')"></asp:TextBox> </td>
	                        </tr>  

	                </table>
	            </td>
	                    </tr>
                    </table>
                </td>
            </tr>
        </table>
	    
     

     
     <TABLE  width="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
	     <tr>

	        <td  align="center" class="form1">
			        <asp:button id="btnnew" runat="server" Text="Save Workorder" CssClass="button" 
                        onclick="btnnew_Click"></asp:button>
           </td>
           <td  align="center" class="form1">
                     <button id="eulabox"  class="button" name="eulabox" onclick="CloseandRefresh();">Close</button>
                    <asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=Larger></asp:Label>
		    </td>
	    </tr>
	   </TABLE>
     <table border="0" width="100%" >
     	 <tr>            
	        
	        
	        
	        <td width="65%" valign="top" >
	            <table width="100%" border="0">
                
	                <tr>
	                    <td width="80%" align="right">Total Material Cost:</td>
	                    <td width="20%" aligh="left"><asp:TextBox ID="txtMaterialCost" MaxLength="7" Width="50px" runat="server" onkeypress="formatNumber('txtMaterialCost')"></asp:TextBox> 
	                    </td>
	        <td class="form1" >Active:
	            <asp:RadioButtonList ID="chkActive" CssClass="form1"  RepeatDirection="Horizontal" runat="server">
	                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
	                    <asp:ListItem Text="No" Value="0" Selected=true></asp:ListItem>
	            </asp:RadioButtonList>  
	            <asp:HiddenField ID="hidEstNum" runat="server" />
	        </td>
	                </tr>
	            </table>
	        </td>
    <table>
        <tr>
            <td align=right valign=top>Engineering Hours:</td>
            <td>All work associated with the development of shop drawings, sketches, coordination, planning, 
                quality control, material research & procurement, cut lists, field verifications and dimensions. 
                Specifically excludes standard jobsite and general production meetings and any work and/or 
                negotiations occuring prior to award of the contract.</td>  
        </tr>
        <tr>
            <td align=right valign=top>Fabrication Hours:</td>
            <td>All work associated with the direct fabrication of the work order such as cutting, machining,
                edging, cnc programming and operating, assembly. Preparatory work for finishing such as joint
                hole, and corner filling, rough sanding and delivery to finishing is considered a fabrication
                responsibility. Also includes any cleanup work directly associated with debris/falldown 
                generated from the fabrication of the work order.</td>
        </tr>
        <tr>
            <td align=right valign=top>Finishing Hours:</td>
            <td>All work associated with finishing operations such as chemical mixing, final sanding, handling,
                staging and touch up.</td>
        </tr>
        <tr>
            <td align=right valign=top>Miscellaneous Hours:</td>
            <td>All miscellaneous work such as general shop cleaning, packing, loading, handling, delivery, general
                errands, equipment/tool maintenance, and any activity indirectly associated with the complete
                execution a particular work order.</td>
        </tr>
    </table>
	        
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
