using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;


public partial class maintain_dlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                string k1 = n.GetKey(1);
                string v1 = n.Get(1);

                ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                ViewState["twcProjNumber"] = Request.QueryString["twcProjNumber"].ToString();

                DisplayListBoxValues();
            }
        }
    }
    public void DisplayListBoxValues()
    {
        try
        {
            try
            {
                Whitfieldcore wCore = new Whitfieldcore();
                DataSet dsRight = new DataSet();
                DataSet dsLeft = new DataSet();

                dsLeft = wCore.GetLeftDistributionList(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twcProjNumber"].ToString()));
                BindUsers(leftlist, dsLeft);
                dsRight = wCore.GetRightDistributionList(Convert.ToInt32(ViewState["twcProjNumber"].ToString()));
                BindUsers(rightlist, dsRight);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void BindUsers(ListBox ddl,DataSet ds)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = "UName";
            ddl.DataValueField = "Email";
            ddl.DataBind();
            ddl.Items.Insert(0, common.AddItemToList("Select Users", "0"));
        }
        else
        {
            ddl.DataSource = null;
            ddl.Items.Clear();

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore wCore = new Whitfieldcore();
            for (int i = 0; i < rightlist.Items.Count; i++)
            {
                if (rightlist.Items[i].Selected)
                {
                    wCore.DeleteRight(Convert.ToInt32(ViewState["twcProjNumber"].ToString()), rightlist.Items[i].Value);
                }
            }
            DisplayListBoxValues();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore wCore = new Whitfieldcore();
            for (int i = 0; i < leftlist.Items.Count; i++)
            {
                if (leftlist.Items[i].Selected)
                {
                    wCore.InsertRight(Convert.ToInt32(ViewState["twcProjNumber"].ToString()), leftlist.Items[i].Value); 
                }
            }
            DisplayListBoxValues();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
