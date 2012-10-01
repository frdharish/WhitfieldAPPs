using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class twc_project_client : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 twcProjectNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        if (!Page.IsPostBack)
        {
            BindClient();
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
            ViewState["twcProjectNumber"] = twcProjectNumber;
        }
    }
    private void BindClient()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetClientlist();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ChkPrjClient.DataSource = dsGrp;
            ChkPrjClient.DataTextField = "Name";
            ChkPrjClient.DataValueField = "ClientID";
            ChkPrjClient.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        _wc.DeleteProjectClient(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twcProjectNumber"].ToString()));
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        for (int i = 0; i < ChkPrjClient.Items.Count; i++)
        {
            if (ChkPrjClient.Items[i].Selected)
                _wc.PopulateProject_client(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkPrjClient.Items[i].Value), Convert.ToInt32(ViewState["twcProjectNumber"].ToString()));
        }
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInfo.aspx?EstNum=" + ViewState["EstNum"].ToString() + "&twc_project_number=" + ViewState["twcProjectNumber"].ToString() + "');</script>");
    }
}
