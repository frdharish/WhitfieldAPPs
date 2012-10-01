using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;

public partial class workorder_materials : System.Web.UI.UserControl
{
    public Int32 EstNum;
    public String WorkOrderID;
    private const Int16 _DEFAULTPAGESIZE = 25;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void FetchSubMaterials(Int32 EstNum, String work_order_id,DataSet dsrec)
    {
        ViewState["EstNum"] = EstNum.ToString();
        ViewState["WorkOrderID"] = WorkOrderID.ToString();
        hdnEstNum.Value = EstNum.ToString();
        hdnworkorderNumber.Value = work_order_id.ToString();
        BindSubMaterials();
        if (dsrec.Tables[0].Rows.Count > 0)
        {
            grdpl1.DataSource = dsrec;
            grdpl1.DataBind();
        }
    }
    private void DisplayGrid(Int32 EstNum, String work_order_id)
    {
        try
        {
            Whitfieldcore _DbClass = new Whitfieldcore();
            DataSet dsSubMats = _DbClass.GetMaterialForWorkOrder(EstNum, work_order_id);
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
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
    }
    public void grdpl1_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdpl1.ShowFooter = true;
        grdpl1.EditItemIndex = -1;
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
    }

    public void grdpl1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.DELETEMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString(),Convert.ToInt32(DetailId));
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
       // ((YourPageClass)this.Page).YourMethod();
        Page.GetType().InvokeMember("DisplayGrid", BindingFlags.InvokeMethod, null, this.Page, null);


    }
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.UPDATEMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString(), Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtqty"))).Text);
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
        Page.GetType().InvokeMember("DisplayGrid", BindingFlags.InvokeMethod, null, this.Page, null);
    }
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {
        grdpl1.CurrentPageIndex = e.NewPageIndex;
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
    }
    public void ResultGridItemCreated(object sender, DataGridItemEventArgs e)
    {
        ListItemType elemType = e.Item.ItemType;
        TableCell pager = (TableCell)e.Item.Controls[0];
        // Check to see if the itemPa is the Pager Bar
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
                //wUser.PopulateMaterialinWorkOrder(Convert.ToInt32(EstNum.ToString()), WorkOrderID.ToString(), Convert.ToInt32(RdoprjMaterials.Items[i].Value));
                wUser.PopulateMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString(), Convert.ToInt32(RdoprjMaterials.Items[i].Value));
        }
        this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
        Page.GetType().InvokeMember("DisplayGrid", BindingFlags.InvokeMethod, null, this.Page, null);
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore _dbClass = new Whitfieldcore();
            foreach (DataGridItem dgItem in grdpl1.Items)
            {
               // String DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
                Int32 DetailId = Convert.ToInt32(grdpl1.DataKeys[dgItem.ItemIndex].ToString());
                String FeatureValue = ((TextBox)dgItem.FindControl("txtqty1")).Text;
                _dbClass.UPDATEMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString(), Convert.ToInt32(DetailId), FeatureValue.ToString().Trim());
            }
            this.DisplayGrid(Convert.ToInt32(ViewState["EstNum"].ToString()), ViewState["WorkOrderID"].ToString());
            Page.GetType().InvokeMember("DisplayGrid", BindingFlags.InvokeMethod, null, this.Page, null);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }

       
        
        
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        
    }
}
