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

public partial class newconditionstoProject : System.Web.UI.Page
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
                BindTerms(Convert.ToInt32(v));
            }
        }
    }
    private void BindTerms(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetMasterTerms(EstNum);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ChkTerms.DataSource = dsGrp;
            ChkTerms.DataTextField = "description";
            ChkTerms.DataValueField = "sub_terms_id";
            ChkTerms.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore wUser = new Whitfieldcore();
            for (int i = 0; i < ChkTerms.Items.Count; i++)
            {
                if (ChkTerms.Items[i].Selected)
                    wUser.PopulateConsideration(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkTerms.Items[i].Value));
            }
            Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString() + "');</script>");
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
