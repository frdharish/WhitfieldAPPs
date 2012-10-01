using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class AddBid : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 Compeid;
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
                string v1 = n.Get(1);
                // 4
                // Test different keys
                Compeid = Convert.ToInt32(v);
                EstNum = Convert.ToInt32(v1);
                hidEstNum.Value = EstNum.ToString();
                txtBidAmt.Text  = _wc.GetBidAmt(EstNum, Compeid);
                txtClientName.Text = _wc.GetClientName(EstNum);
                txtEstName.Text = _wc.GetProjectName(EstNum);
            }
            ViewState["EstNum"] = EstNum.ToString();
            ViewState["Compeid"] = Compeid.ToString();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.AddBidAmount(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["Compeid"].ToString()), txtBidAmt.Text);
        lblMsg.Text = "Your record is added successfully.";
    }
}
