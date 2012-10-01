using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class whitfieldmain : System.Web.UI.Page
{

    private decimal TotalPendingBaseBid = 0;
    private decimal TotalSubmittedBaseBid = 0;
    private decimal TotalAwardedBaseBid = 0;
    private decimal TotalFabHours = 0;
    private decimal TotalInstallHours = 0;


    private const Int16 _DEFAULTPAGESIZE = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet dsSubmitted;
            DataSet dsPending;
            DataSet dsAwarded;
            dsSubmitted = this.Summary_Queue("3");
            this.PopulateDataGrid(dsSubmitted, grdsubmitted);
            dsPending = this.Summary_Queue("1,2");
            this.PopulateDataGrid(dsPending,grdPending);
            dsAwarded = this.Summary_Queue("5");
            this.PopulateDataGrid(dsAwarded,grdAwarded);
        }
    }
    #region UI Methods
    public string ShowEditImage(object EstNum)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + EstNum.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion

    #region Datagrid common Functions
    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdsubmitted.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue("3");
        PopulateDataGrid(dsGridResults,grdsubmitted);

    }

    public void PageResultGrid2(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdPending.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue("1,2");
        PopulateDataGrid(dsGridResults,grdPending);

    }
    public void PageResultGrid3(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdAwarded.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue("5");
        PopulateDataGrid(dsGridResults, grdAwarded);

    }
    public void grdPending_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalPendingBaseBid += Convert.ToDecimal(e.Item.Cells[3].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            //e.Item.Cells[0].Text = "Total($):";
            //e.Item.Cells[2].Text = string.Format("{0:c}", TotalPendingBaseBid);
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        }
    }
    public void grdsubmitted_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           // e.Item.Cells[3].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[3].Text));
            TotalSubmittedBaseBid += Convert.ToDecimal(e.Item.Cells[3].Text);
            TotalInstallHours += Convert.ToDecimal(e.Item.Cells[4].Text);
            TotalFabHours += Convert.ToDecimal(e.Item.Cells[5].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[2].Text = string.Format("{0:c}", TotalSubmittedBaseBid);
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[4].Text = TotalInstallHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = TotalFabHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void grdAwarded_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalAwardedBaseBid += Convert.ToDecimal(e.Item.Cells[3].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[2].Text = string.Format("{0:c}", TotalAwardedBaseBid);
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void GridFormat(DataGridItemEventArgs e)
    {

        e.Item.Cells[2].Font.Bold = true;
        e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    }
    private DataSet Summary_Queue(String _statuscd)
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetProjectInfo(Request.Cookies["RoleId"].Value, Request.Cookies["UserId"].Value, _statuscd);
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

    private void PopulateDataGrid(DataSet dsGridResults,DataGrid grdRpResults)
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
                //txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " Record(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
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
