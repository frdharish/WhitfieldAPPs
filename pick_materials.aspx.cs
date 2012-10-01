using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class pick_materials : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 WorkOrderNumber;
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

                string k1 = n.GetKey(1);
                string v1 = n.Get(1);
                // 4
                // Test different keys
                EstNum = Convert.ToInt32(v);
                WorkOrderNumber = Convert.ToInt32(v1);
                hidEstNum.Value = EstNum.ToString();
                hidWorkOrder.Value = WorkOrderNumber.ToString();
            }
            ViewState["EstNum"] = EstNum.ToString();
            ViewState["WorkOrderNumber"]= WorkOrderNumber.ToString();
            BindSubMaterials();
        }
    }
    private void BindSubMaterials()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetMaterialForEsitmation(Convert.ToInt32(ViewState["EstNum"].ToString()));
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
          RdoprjMaterials.DataSource = dsGrp;
          RdoprjMaterials.DataTextField = "OrigMatName";
          RdoprjMaterials.DataValueField = "sub_mat_id";
          RdoprjMaterials.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wUser = new Whitfieldcore();
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        for (int i = 0; i < RdoprjMaterials.Items.Count; i++)
        {
            if (RdoprjMaterials.Items[i].Selected)
                wUser.PopulateMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderNumber"].ToString(), Convert.ToInt32(RdoprjMaterials.Items[i].Value));
        }
        //Response.Write("<script language='javascript'>parent.location.replace('whitfield_estimation.aspx');</script>");
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString() + "');</script>");
    }
}
