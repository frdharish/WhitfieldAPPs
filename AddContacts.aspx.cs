using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class AddContacts : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 Clientid;
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
                Clientid = Convert.ToInt32(v);
                EstNum = Convert.ToInt32(v1);
                hidEstNum.Value = EstNum.ToString();
            }
            ViewState["EstNum"] = EstNum.ToString();
            ViewState["Clientid"] = Clientid.ToString();
            BindContacts(Clientid);
        }
    }

    private void BindContacts(Int32 Clientid)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetContactsForClients(Clientid);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            RdoPrjClient.DataSource = dsGrp;
            RdoPrjClient.DataTextField = "FName";
            RdoPrjClient.DataValueField = "ContactID";
            RdoPrjClient.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wUser = new Whitfieldcore();
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        for (int i = 0; i < RdoPrjClient.Items.Count; i++)
        {
            if (RdoPrjClient.Items[i].Selected)
                wUser.AddPrimaryContact(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["Clientid"].ToString()), Convert.ToInt32(RdoPrjClient.Items[i].Value));
        }
    }
}
