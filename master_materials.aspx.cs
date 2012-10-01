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
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;


public partial class master_materials : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 25;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            //BindMaterials();
            BindMaterialTypes();
            try
            {
                grdpl1.PageSize = _DEFAULTPAGESIZE;
                this.DisplayGrid();

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }
        }
    }

    #region	Show Closing Tag
    public string ShowClosingTags()
    {

        return "</td></tr><tr><td colspan=\"8\">";

    }
    #endregion


    protected void btnnew_Click(object sender, EventArgs e)
    {
       
        this.DisplayGrid();
    }

    //DataGrid Functions
    private void DisplayGrid()
    {
        try
        {
            Whitfieldcore _dbClass = new Whitfieldcore();
            DataSet _dsWorkOrders = new DataSet();
            _dsWorkOrders = _dbClass.GetAllMaterials(Convert.ToInt32(ddlMatType.SelectedItem.Value));
            PopulateDataGrid(_dsWorkOrders, grdpl1);

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
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
        this.DisplayGrid();
    }
    public void grdpl1_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdpl1.ShowFooter = true;
        grdpl1.EditItemIndex = -1;
        this.DisplayGrid();
    }

    public void grdpl1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.DeleteMaterials(Convert.ToInt32(DetailId));
        this.DisplayGrid();
    }
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _dbClass.UPDATEMasterMaterials(Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtReference_Number"))).Text, ((TextBox)(e.Item.FindControl("txtDescription"))).Text, "", "N", ((TextBox)(e.Item.FindControl("txtComments"))).Text);
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid();
    }
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {
        grdpl1.CurrentPageIndex = e.NewPageIndex;
        this.DisplayGrid();
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
    public void grdpl1_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        Int32 Material_ID = 0;
        DataSet dsExpand = new DataSet();
        Whitfieldcore _dbClass = new Whitfieldcore();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    Material_ID = Convert.ToInt32(grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)]);
                    Material_ID = Convert.ToInt32(grdpl1.DataKeys[e.Item.ItemIndex]);
                    dsExpand = _dbClass.GetAllSubMaterials(Material_ID);
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[6].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    if (dsExpand.Tables[0].Rows.Count > 0)
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Material_ID = Material_ID;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(dsExpand);

                        }
                        else
                        {
                            exp.Visible = false;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }
                    }
                    else
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            //((ViewDesignAdmin)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Material_ID = Material_ID;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(dsExpand);
                        }
                        else
                        {
                            exp.Visible = false;
                            ((submaterial)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }

                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    //DataGrid Funtion Ends

    protected void ddlMatType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayGrid();
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

    public static void ExportDataSetToExcel(DataSet ds, string filename)
    {
        try
        {
            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.Font.Size = 9;
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore _dbClass = new Whitfieldcore();
            DataSet dsRpAdvances = _dbClass.GetAllMaterials(Convert.ToInt32(ddlMatType.SelectedItem.Value));
            ExportDataSetToExcel(dsRpAdvances, "SystemListing.xls");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
