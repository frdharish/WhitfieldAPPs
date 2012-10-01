using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class twc_project_workorder : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 twcProjectNumber;
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
                // 4
                // Test different keys
                EstNum = Convert.ToInt32(v);
                twcProjectNumber = Convert.ToInt32(v1);
                hidEstNum.Value = EstNum.ToString();
                hidtwcProjNumber.Value = twcProjectNumber.ToString();
            }
            ViewState["EstNum"] = EstNum;
            ViewState["twcProjNumber"] = twcProjectNumber;
        }
    }

    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        _wc.ManageWorkOrders(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twcProjNumber"].ToString()), txtdesc.Text.Trim(), Convert.ToInt32(txtMaterialCost.Text.Trim()), Convert.ToInt32(txtFabHours.Text.Trim()), Convert.ToInt32(txtFinishHours.Text.Trim()), Convert.ToInt32(txtInstallHours.Text.Trim()), Convert.ToInt32(txtEngHours.Text.Trim()), Convert.ToInt32(txtMiscHours.Text.Trim()), txtNotes.Text.Trim(), chkActive.SelectedItem.Value.Trim());
       Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInfo.aspx?EstNum=" + hidEstNum.Value + "&twcProjNumber=" + hidtwcProjNumber.Value + "');</script>");
    }
}
