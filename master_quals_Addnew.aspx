<%@ Page Title="" Language="C#" MasterPageFile="~/whitfieldmain.master" AutoEventWireup="true" CodeFile="master_quals_Addnew.aspx.cs" Inherits="master_quals_Addnew" %>
<%@ Register TagPrefix="uc1" TagName="DynamicTable" Src="master_quals1.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
<asp:ScriptManager ID="ScriptManager" runat="server" />
<uc1:DynamicTable  ID="DynamicTable1" runat="server" ></uc1:DynamicTable>
</div>
</asp:Content>

