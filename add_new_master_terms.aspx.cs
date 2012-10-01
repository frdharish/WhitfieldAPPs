﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Collections.Specialized;
using System.IO;

public partial class add_new_master_terms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropdownGroups();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            contingency wIns = new contingency();
            Int32 IntFlg = wIns.PopulateTerms(ddlGroup.SelectedItem.Value, txtdesc.Text.Trim());
            Response.Write("<script language='javascript'>parent.location.replace('master_terms.aspx');</script>");

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    public void BindDropdownGroups()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("Schedule", "Schedule");
        hTable.Add("Pricing", "Pricing");
        hTable.Add("Payment", "Payment");
        ddlGroup.DataSource = hTable;
        ddlGroup.DataTextField = "value";
        ddlGroup.DataValueField = "key";
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, common.AddItemToList("Select", ""));
    }
}
