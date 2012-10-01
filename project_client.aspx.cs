using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class project_client : System.Web.UI.Page
{
    public Int32 EstNum;
    protected void Page_Load(object sender, EventArgs e)
    {
                Whitfieldcore _wc = new Whitfieldcore();
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
                        // 4
                        // Test different keys
                        EstNum = Convert.ToInt32(v);
                        hidEstNum.Value = EstNum.ToString();
                    }
                    ViewState["EstNum"] = EstNum;
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
        Whitfieldcore wUser = new Whitfieldcore();
        wUser.DeleteProjectClient(Convert.ToInt32(ViewState["EstNum"].ToString()));
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        for (int i = 0; i < ChkPrjClient.Items.Count; i++)
        {
            if (ChkPrjClient.Items[i].Selected)
                wUser.PopulateProject_client(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkPrjClient.Items[i].Value));
        }
        lblMsg.Text = "Your record is added successfully.";
    }
}
