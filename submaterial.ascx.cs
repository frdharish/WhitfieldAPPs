using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class submaterial : System.Web.UI.UserControl
{
    public Int32 Material_ID;
    private const Int16 _DEFAULTPAGESIZE = 25;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            //GetUOM();
            //try
            //{
            //    grdpl1.PageSize = _DEFAULTPAGESIZE;
            //    this.DisplayGrid();

            //}
            //catch (Exception exp)
            //{
            //    Response.Write(exp.Message.ToString());
            //}
        }
    }

    public DataSet UOMSet()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllUOM_TYPES();
        return dsGrp;
    }
    public void GetUOM()
    {
        DataSet dsGrp = this.UOMSet();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlUOM.DataSource = dsGrp;
            ddlUOM.DataTextField = "uom_type_desc";
            ddlUOM.DataValueField = "uom_type_id";
            ddlUOM.DataBind();
            ddlUOM.Items.Insert(0, common.AddItemToList("Select Type", ""));

        }
    }
    public void FetchSubMaterials(DataSet dsrec)
    {
        ViewState["material_id"] = Material_ID.ToString();
        if (dsrec.Tables[0].Rows.Count > 0)
        {
            grdpl1.DataSource = dsrec;
            grdpl1.DataBind();
        }
        GetUOM();
    }
    private void DisplayGrid(Int32 material_id)
    {
        try
        {
            Whitfieldcore _DbClass = new Whitfieldcore();
            DataSet dsSubMats = _DbClass.GetAllSubMaterials(material_id);
            PopulateDataGrid(dsSubMats, grdpl1);

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    //DataGrid Functions
    public void PopulateDataGrid(DataSet dsGridResults, DataGrid grdpl1)
    {
        Int32 resultCount = 0;
        if (dsGridResults.Tables.Count > 0)
            resultCount = dsGridResults.Tables[0].Rows.Count;
        Int32 maxResultItemInPage = 0;
        Int32 minResultItemInPage = 0;
        try
        {
            if (resultCount > 0)
            {

                DataTable tblInstallments = dsGridResults.Tables[0];
                //Display results in Grid
                if (resultCount > (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize)
                    maxResultItemInPage = (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdpl1.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdpl1.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdpl1.Visible = true;
                grdpl1.DataSource = tblInstallments;
                grdpl1.DataBind();
            }
            else
            {
                grdpl1.Visible = false;
            }
        }
        catch (Exception exp)
        {

            Response.Write(exp.Message.ToString());
        }
    }
    public void grdpl1_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdpl1.ShowFooter = false;
        grdpl1.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }
    public void grdpl1_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdpl1.ShowFooter = true;
        grdpl1.EditItemIndex = -1;
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }

    public void grdpl1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.DeleteSubMaterials(Convert.ToInt32(DetailId));
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.UPDATESubMaterials(Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtthickness"))).Text, ((TextBox)(e.Item.FindControl("txtlength"))).Text, ((TextBox)(e.Item.FindControl("txtweight"))).Text, ((TextBox)(e.Item.FindControl("txtwidth"))).Text, ((TextBox)(e.Item.FindControl("txtDescription"))).Text, ((TextBox)(e.Item.FindControl("txtCost"))).Text, Convert.ToInt32(((DropDownList)(e.Item.FindControl("ddlUOM"))).SelectedItem.Value), ((RadioButtonList)(e.Item.FindControl("chkLEED"))).SelectedItem.Value, ((TextBox)(e.Item.FindControl("txtManufacturer"))).Text, ((RadioButtonList)(e.Item.FindControl("chkFSC"))).SelectedItem.Value, ((TextBox)(e.Item.FindControl("txtMaterial_Code"))).Text, ((TextBox)(e.Item.FindControl("txtNotes"))).Text, ((RadioButtonList)(e.Item.FindControl("chkDefault_Field"))).SelectedItem.Value);
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {
        grdpl1.CurrentPageIndex = e.NewPageIndex;
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }
    public void ResultGridItemCreated(object sender, DataGridItemEventArgs e)
    {
        ListItemType elemType = e.Item.ItemType;
        TableCell pager = (TableCell)e.Item.Controls[0];
        // Check to see if the item is the Pager Bar
        if (elemType == ListItemType.Pager)
        {
            for (int i = 0; i < pager.Controls.Count; i += 2)
            {
                Object objControl = pager.Controls[i];
                if (objControl is LinkButton)
                {
                    LinkButton linkBtn = (LinkButton)objControl;
                    linkBtn.Text = "&nbsp;[" + linkBtn.Text + "]&nbsp;";
                }
                else //Can only be a label
                {
                    Label linkLabel = (Label)objControl;
                    linkLabel.Text = "Page " + linkLabel.Text;
                    linkLabel.CssClass = "Status";
                }
            }
        }
    }
    //End DataGrid Functions
    protected void btnnew_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean BoolIns = false;
            Whitfieldcore wIns = new Whitfieldcore();
            BoolIns = wIns.PopulateSubMaterials(Convert.ToInt32(ViewState["material_id"].ToString()), txtthickness.Text.Trim(), txtlength.Text.Trim(), txtweight.Text.Trim(), txtWidth.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), Convert.ToInt32(ddlUOM.SelectedItem.Value), chkActive.SelectedItem.Value, txtManu.Text.Trim(), chkiFSC.SelectedItem.Value, txtMatCode.Text.Trim(), txtMemo.Text.Trim(), rdoDefault_Field.SelectedItem.Value);
            if (BoolIns)
            {
                lblMsg.Text = "Sub Material is added";
            }
            else
            {
                lblMsg.Text = "There is an error occured";
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        this.DisplayGrid(Convert.ToInt32(ViewState["material_id"].ToString()));
    }
}
