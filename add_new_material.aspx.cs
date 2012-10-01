using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class add_new_material : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            BindMaterials();
        }
    }

    private void BindMaterials()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllMaterialTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlType.DataSource = dsGrp;
            ddlType.DataTextField = "Mat_type_Desc";
            ddlType.DataValueField = "Mat_type_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, common.AddItemToList("Select Type", ""));

        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean BoolIns = false;
            Whitfieldcore wIns = new Whitfieldcore();
            BoolIns = wIns.PopulateMasterMaterials(Convert.ToInt32(ddlType.SelectedItem.Value), txtRefNumber.Text.Trim(), txtDescription.Text.Trim(), "", "N", txtMemo.Text.Trim());
            if (BoolIns)
            {
                lblMsg.Text = "Material is added";
            }
            else
            {
                lblMsg.Text = "There is an error occured";
            }
            Response.Write("<script language='javascript'>parent.location.replace('master_materials.aspx');</script>");
           
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
