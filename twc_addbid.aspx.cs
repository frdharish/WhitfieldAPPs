using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class twc_addbid : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 Compeid;
    public Int32 twc_proj_number;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        if (!Page.IsPostBack)
        {
            // 1 Get collection
            NameValueCollection n = Request.QueryString;
            // 2 See if any query string exists
            if (n.HasKeys())
            {
                // 3 Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                string v1 = n.Get(1);
                string v2 = n.Get(2);
                // 4
                // Test different keys
                Compeid = Convert.ToInt32(v);
                EstNum = Convert.ToInt32(v1);
                twc_proj_number = Convert.ToInt32(v2);
                hidEstNum.Value = EstNum.ToString();
                hidProjNumber.Value = twc_proj_number.ToString();
                txtBidAmt.Text = _wc.GetBidAmt(EstNum, Compeid,twc_proj_number);
                txtClientName.Text = _wc.GetClientName(EstNum,twc_proj_number);
                txtEstName.Text = _wc.GetProjectName(EstNum,twc_proj_number);
            }
                ViewState["EstNum"] = EstNum.ToString();
                ViewState["twc_proj_number"] = twc_proj_number.ToString();
                 ViewState["Compeid"] = Compeid.ToString();
        }

    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        _wc.AddBidAmount(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twc_proj_number"].ToString()), Convert.ToInt32(ViewState["Compeid"].ToString()), txtBidAmt.Text);
       // lblMsg.Text = "Your record is added successfully.";
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInfo.aspx?EstNum=" + ViewState["EstNum"].ToString() + "&twc_project_number=" + ViewState["twc_proj_number"].ToString() + "');</script>");
    }

}
