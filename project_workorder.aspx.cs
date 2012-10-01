using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class project_workorder : System.Web.UI.Page
{
    public Int32 EstNum;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
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
                // 4
                // Test different keys
                EstNum = Convert.ToInt32(v);
                hidEstNum.Value = EstNum.ToString();
            }
            ViewState["EstNum"] = EstNum;
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
            Whitfieldcore wUser = new Whitfieldcore();
            wUser.ManageWorkOrders(Convert.ToInt32(ViewState["EstNum"].ToString()), txtdesc.Text.Trim(), Convert.ToInt32(txtMaterialCost.Text.Trim()), Convert.ToInt32(txtFabHours.Text.Trim()), Convert.ToInt32(txtFinishHours.Text.Trim()), Convert.ToInt32(txtInstallHours.Text.Trim()), Convert.ToInt32(txtEngHours.Text.Trim()), Convert.ToInt32(txtMiscHours.Text.Trim()), txtNotes.Text.Trim(), chkActive.SelectedItem.Value.Trim(), txtreftext.Text.Trim());
            //Response.Write("<script language='javascript'>parent.agreewin.hide();</script>");
            Response.Write("<script language='javascript'>parent.location.replace('whitfield_estimation.aspx?EstNum=" + hidEstNum.Value + "');</script>");
    }
}
