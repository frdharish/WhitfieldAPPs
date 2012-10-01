using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Collections;


public partial class project_contacts : System.Web.UI.Page
{
    public Int32 EstNum;
    protected void Page_Load(object sender, EventArgs e)
    {                
            Whitfieldcore _wc = new Whitfieldcore();
            if (!Page.IsPostBack)
            {
                BindCompetition();
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
                    ViewState["EstNum"] = EstNum.ToString();
                }
            }
    }
    private void BindCompetition()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetCompetitors();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

          ChkProjContacts.DataSource = dsGrp;
          ChkProjContacts.DataTextField = "Name";
          ChkProjContacts.DataValueField = "CompeID";
          ChkProjContacts.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wUser = new Whitfieldcore();
        wUser.DeleteProjectCompe(Convert.ToInt32(ViewState["EstNum"].ToString()));
        for (int i = 0; i < ChkProjContacts.Items.Count; i++)
        {
            if (ChkProjContacts.Items[i].Selected)
                wUser.PopulateProject_compe(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkProjContacts.Items[i].Value));
        }
        lblMsg.Text = "Your record is added successfully.";

    }

    ArrayList GetSelectedItems(CheckBoxList lb)
    {
        ArrayList a = new ArrayList();

        for (int i = 0; i < lb.Items.Count; i++)
        {
            if (lb.Items[i].Selected)
                a.Add(lb.Items[i].Value);
        }
        return a;
    }

}
