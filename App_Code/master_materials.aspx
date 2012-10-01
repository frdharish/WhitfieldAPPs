<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<table  align="center" cellspacing="0" cellpadding="0" border="0">
<th colspan="2" align="center">MASTER MATERIALS LISTING</th>
    <td>
    <tr>
        <table border="1">
            <tr>
                <th>Type</th>
                <td>Drop Menu: Sheet Goods; Hardware; Finishing; Laminate; Solid Lumber; Polymer; Granite; Glass; Plastics</td>                
            </tr>
             <tr>
                <th>Reference #</th>
                <td>AlphaNumeric reference number</td>
            </tr>
            <tr>
                <th>Description</th>
                <td>Description of Material</td>
            </tr>
            <tr>
                <th>Cost</th>
                <td>Cost of Material</td>                
            </tr>
            <tr>
                <th>U.O.M.</th>
                <td>Drop Menu: Each; Gallon; Sheet; SQFT; LF; SQYD</td>                
            </tr>
            <tr>
                <th>Brand/Manufacturer</th>
                <td>Brand Name</td>                
            </tr>
            <tr>
                <th>LEED</th>
                <td>Yes/No - Default is "No"</td>                
            </tr>

            <tr>
                <th>Notes/Comments:</th>
                <td>Memo Field</td>                
            </tr>
     
        </table>
    </tr>
    </td>
 
    <td>
    <tr>
        <td>Insert Search button here. Search parameters is a keyword search for all fields</td>
    </tr>
    </td>

    <tr>
        <table border="1">
            <td>Insert Materials Listing Table Here</td>
        </table>
    </tr>
    
    
</table>			
</asp:Content>

