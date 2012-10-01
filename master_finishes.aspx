<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<table  align="center" cellspacing="0" cellpadding="0" border="0">
<th colspan="2" align="center">MASTER FINISHES LISTING</th>
    <td>
    <tr>
        <table border="1">
            <tr>
                <th>Brand/Manufacturer</th>
                <td>Brand Name</td>                
            </tr>
            <tr>
                <th>Type</th>
                <td>Drop Menu: Laminate; Veneer; Solid Lumber; Polymer; Granite</td>                
            </tr>
             <tr>
                <th>Name</th>
                <td>Material Name</td>
            </tr>
            <tr>
                <th>Number</th>
                <td>Number/Designation of Material</td>
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
            <td>Insert Finishes Listing Table Here</td>
        </table>
    </tr>
    
    
</table>			
</asp:Content>

