using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class master_contingency : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        contingency _wc = new contingency();
        if (!Page.IsPostBack)
        {
            
            try
            {
                grdEstimateMaterials.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults = _wc.FetchContingencyData();
                PopulateDataGrid(dsGridResults, grdEstimateMaterials);

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }
        }
    }

    public void grdEstimateMaterials_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        grdEstimateMaterials.ShowFooter = false;
        grdEstimateMaterials.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        DataSet dsGridResults = _wc.FetchContingencyData();
        PopulateDataGrid(dsGridResults, grdEstimateMaterials);
    }
    public void grdEstimateMaterials_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        grdEstimateMaterials.ShowFooter = true;
        grdEstimateMaterials.EditItemIndex = -1;
        DataSet dsGridResults = _wc.FetchContingencyData();
        PopulateDataGrid(dsGridResults, grdEstimateMaterials);
    }

    public void grdEstimateMaterials_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        String DetailId = "";
        DetailId = grdEstimateMaterials.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _wc.DeleteContingency(Convert.ToInt32(DetailId));
        _wc.DeleteSubContingencyForContingency(Convert.ToInt32(DetailId));
        DataSet dsGridResults = _wc.FetchContingencyData();
        PopulateDataGrid(dsGridResults, grdEstimateMaterials);
    }
    public void grdEstimateMaterials_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = grdEstimateMaterials.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.UpdateContingency(Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtdesc"))).Text);
        grdEstimateMaterials.EditItemIndex = -1;
        grdEstimateMaterials.ShowFooter = true;
        DataSet dsGridResults = _wc.FetchContingencyData();
        PopulateDataGrid(dsGridResults, grdEstimateMaterials);
    }

    public void grdEstimateMaterials_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        Int32 cont_id = 0;

        contingency mm = new contingency();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    cont_id = Convert.ToInt32(grdEstimateMaterials.DataKeys[Convert.ToInt32(e.Item.ItemIndex)]);
                    cont_id = Convert.ToInt32(grdEstimateMaterials.DataKeys[e.Item.ItemIndex]);
                    DataSet dsExpand = mm.FetchSubContingencyData(cont_id);
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[4].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    // if (dsExpand.HasRows())
                    // {
                    if (img.ImageUrl == "assets/img/Plus.gif")
                    {
                        img.ImageUrl = "assets/img/Minus.gif";
                        exp.Visible = true;
                        ((master_contingency1)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                        ((master_contingency1)(e.Item.FindControl("DynamicTable1"))).cont_id = cont_id;
                        ((master_contingency1)(e.Item.FindControl("DynamicTable1"))).LoadDetails(dsExpand);

                    }
                    else
                    {
                        exp.Visible = false;
                        ((master_contingency1)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                        img.ImageUrl = "assets/img/Plus.gif";
                    }
                    //}
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public string ShowClosingTags()
    {

        return "</td></tr><tr><td colspan=\"6\">";

    }


    #region DataGrid Functions
    private void PopulateDataGrid(DataSet dsGridResults, DataGrid grdRpResults)
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
                if (resultCount > (grdRpResults.CurrentPageIndex + 1) * grdRpResults.PageSize)
                    maxResultItemInPage = (grdRpResults.CurrentPageIndex + 1) * grdRpResults.PageSize;
                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdRpResults.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdRpResults.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdRpResults.Visible = true;
                grdRpResults.DataSource = tblInstallments;
                grdRpResults.DataBind();
            }
            else
            {
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
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

    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {
        contingency mm = new contingency();
        DataSet dsGridResults;
        grdEstimateMaterials.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = mm.FetchContingencyData();
        PopulateDataGrid(dsGridResults, grdEstimateMaterials);
    }

    #endregion
}
