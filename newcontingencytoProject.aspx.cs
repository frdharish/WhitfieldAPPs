using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Data.Common;
using System.IO;

public partial class newcontingencytoProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            if (n.HasKeys())
            {
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                ViewState["EstNum"] = v.ToString();
                hidEstNum.Value = ViewState["EstNum"].ToString();
                BindContingency(Convert.ToInt32(v));
            }
        }
    }
    private void BindContingency(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetMasterContingencies(EstNum);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ChkCongingency.DataSource = dsGrp;
            ChkCongingency.DataTextField = "description";
            ChkCongingency.DataValueField = "sub_contingency_id";
            ChkCongingency.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore wUser = new Whitfieldcore();
            for (int i = 0; i < ChkCongingency.Items.Count; i++)
            {
                if (ChkCongingency.Items[i].Selected)
                    wUser.PopulateContingency(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkCongingency.Items[i].Value));
            }
            Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString() + "');</script>");
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
