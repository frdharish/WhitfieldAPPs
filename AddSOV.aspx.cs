using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Configuration;
using System.Collections.Specialized;

public partial class AddSOV : System.Web.UI.Page
{
    //Int32 twc_project_number;
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
                        // See if any query string exists
            // See if any query string exists
            if (n.HasKeys())
            {
                string k = n.GetKey(0);
                string v = n.Get(0);

                string k1 = n.GetKey(1);
                string v1 = n.Get(1);

                ViewState["EstNum"] = v;
                ViewState["twc_project_number"] = Convert.ToInt32(v1);
            }
            BindItemNumber();
        }
    }

    private void BindItemNumber()
    {
        project_invoice _pi = new project_invoice();
        DataSet dsGrp = new DataSet();
        dsGrp = _pi.GetHashtableData();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlNo.DataSource = dsGrp;
            ddlNo.DataValueField = "seq_value";
            ddlNo.DataTextField = "seq_value";
            ddlNo.DataBind(); 
        }
    }

    protected void btnnew_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean BoolIns = false;
            project_invoice _pi = new project_invoice();
            Whitfield_Project _wc = new Whitfield_Project();
            BoolIns = _pi.MaintainInvoiceRecords(ViewState["twc_project_number"].ToString(), ddlNo.SelectedItem.Value, txtDescription.Text.Trim(), txtAmt.Text.Trim());
            if (BoolIns)
            {
                lblMsg.Text = "Schedule of Value is added";
            }
            else
            {
                lblMsg.Text = "There is an error occured";
            }
            _wc.UpdateCostUpdates(ViewState["EstNum"].ToString(), ViewState["twc_project_number"].ToString());
            Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInvoice.aspx?EstNum=" + ViewState["EstNum"].ToString() + "&twc_project_number=" + ViewState["twc_project_number"].ToString() + "');</script>");
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
