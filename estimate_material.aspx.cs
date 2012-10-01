using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class estimate_material : System.Web.UI.Page
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
            ViewState["EstNum"] = EstNum.ToString();
            BindMaterialTypes();
            BindSubMaterials();
            
        }
    }
    protected void ddlMatType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubMaterials();
    }
    private void BindMaterialTypes()
    {
        try
        {
            Whitfieldcore _dbClass = new Whitfieldcore();
            DataSet dsportfolio = new DataSet();
            dsportfolio = _dbClass.GetAllMaterialTypes();
            if (dsportfolio.Tables[0].Rows.Count > 0)
            {

                ddlMatType.DataSource = dsportfolio;
                ddlMatType.DataTextField = "Mat_type_Desc";
                ddlMatType.DataValueField = "Mat_type_id";
                ddlMatType.DataBind();
                ddlMatType.Items.Insert(0, common.AddItemToList("Fetch All Material Types", "0"));
            }
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    private void BindSubMaterials()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllSubMaterials(ddlMatType.SelectedItem.Value);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            RdoPrjClient.DataSource = dsGrp;
            RdoPrjClient.DataTextField = "matdesc";
            RdoPrjClient.DataValueField = "sub_mat_id";
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
                wUser.PopulateMaterialinEstimation(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(RdoPrjClient.Items[i].Value));
        }
        //Response.Write("<script language='javascript'>parent.location.replace('whitfield_estimation.aspx');</script>");
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString()  + "');</script>");
    }
}
