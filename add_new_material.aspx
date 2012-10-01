<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="add_new_material.aspx.cs" Inherits="add_new_material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  align="left"  width="100%" cellspacing="0" cellpadding="0" border="0">
<th colspan="2" align="left">Add New Material</th>
<tr>
    <td>
                <table border="1">
                    <tr>
                        <th>Type</th>
                        <td><asp:dropdownlist ValidationGroup="insertnew" id="ddlType" runat="server"></asp:dropdownlist></td>                
                    </tr>
                    
                     <tr>
                        <th>Material Type</th>
                        <td><asp:textbox  ValidationGroup="insertnew" id="txtRefNumber" runat="server" MaxLength="100" Width="224px"></asp:textbox></td>
                    </tr>
                    
                    <tr>
                        <th>Description</th>
                        <td><asp:textbox  ValidationGroup="insertnew" id="txtDescription" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox></td>
                    </tr>                  


                    <tr>
                        <th>Notes/Comments:</th>
                        <td><asp:textbox  ValidationGroup="insertnew" id="txtMemo" runat="server" TextMode="MultiLine" Rows="3"  Columns="40" Width="224px"></asp:textbox></td>               
                    </tr>
                    
                    <tr>
                        <td><asp:button  ValidationGroup="insertnew" id="btnnew" runat="server" Text="Save Materials" CssClass="button" onclick="btnnew_Click" />
                        <br /><asp:Label ID="lblMsg" ForeColor=Maroon runat=server Font-Bold=true Font-Size=medium></asp:Label></td>
                    </tr>
                </table>
    </td>
 </tr>   
</table>
</asp:Content>

