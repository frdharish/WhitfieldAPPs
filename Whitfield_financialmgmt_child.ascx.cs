using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class Whitfield_financialmgmt_child : System.Web.UI.UserControl
{
    public Int32 ProjectNumber;
    private const Int16 _DEFAULTPAGESIZE = 100;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void DisplayGrid(Int32 material_id)
    {
        try
        {

            project_invoice _pi = new project_invoice();
            DataSet _dsInvoices = new DataSet();
            _dsInvoices = _pi.GetInvoiceforProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            PopulateDataGrid(_dsInvoices, grdinv);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    public void FetchSubMaterials(DataSet dsrec)
    {
        ViewState["projNumber"] = ProjectNumber.ToString();
        //Response.Write(dsrec.Tables[0].Rows.Count);
        if (dsrec.Tables[0].Rows.Count > 0)
        {
           grdinv.DataSource = dsrec;
           grdinv.DataBind();
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
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {
        grdinv.CurrentPageIndex = e.NewPageIndex;
        this.DisplayGrid(Convert.ToInt32(ViewState["projNumber"].ToString()));
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
    public void grdinv_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Cells[4].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[4].Text));
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;       
        }
    }
    //End DataGrid Functions
}
