using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class whitfield_project_listing : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 100;
    private decimal Totalfabhours = 0;
    private decimal Totalinstallhours = 0;
    private decimal TotalSubmittedBaseBid = 0;
    private decimal TotalOH = 0;
    private decimal TotalMATCONT= 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdsubmitted.PageSize = _DEFAULTPAGESIZE;
            DataSet dsSubmitted;
            dsSubmitted = this.Summary_Queue();
            this.PopulateDataGrid(dsSubmitted, grdsubmitted);
        }
    }
    #region UI Methods
    public string ShowEditImage(object EstNum,object twc_proj_number)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + EstNum.ToString().Trim() + "','" + twc_proj_number + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion
    #region Datagrid common Functions
    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdsubmitted.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue();
        PopulateDataGrid(dsGridResults, grdsubmitted);

    }
    public void grdsubmitted_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             Totalfabhours += Convert.ToDecimal(e.Item.Cells[5].Text);
             Totalinstallhours += Convert.ToDecimal(e.Item.Cells[6].Text);
             TotalSubmittedBaseBid += Convert.ToDecimal(e.Item.Cells[8].Text);
             TotalOH += Convert.ToDecimal(e.Item.Cells[9].Text);
             TotalMATCONT += Convert.ToDecimal(e.Item.Cells[10].Text);

        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {

            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[5].Text = Totalfabhours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[6].Text = Totalinstallhours.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[7].Text = string.Format("{0:c}", TotalSubmittedBaseBid); 
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[9].Text = string.Format("{0:c}", TotalMATCONT);
            e.Item.Cells[9].Font.Bold = true;
            e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[10].Text = string.Format("{0:c}", TotalOH);
            e.Item.Cells[10].Font.Bold = true;
            e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Right;

        }


    }
    public void GridFormat(DataGridItemEventArgs e)
    {

        e.Item.Cells[2].Font.Bold = true;
        e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    }
    private DataSet Summary_Queue()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfield_Project _wc = new Whitfield_Project();
            dsRpAdvances = _wc.GetProjectInfo();
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
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
                //Display the results message line
                txtSelectionResultsMSG.Text = "There are " + dsGridResults.Tables[0].Rows.Count + " Active Project(s). Displaying Project(s) " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                //txtSelectionResultsMSG.Text = "Please broaden your search and try again.";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }

    #endregion 

}
