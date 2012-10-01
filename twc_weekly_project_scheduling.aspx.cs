using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Collections;
using System.Configuration;

public partial class twc_weekly_project_scheduling : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindYears();
            BindMonths();
            string strMonth = DateTime.Now.ToString("MMMM");
            string strYear = DateTime.Now.ToString("yyyy");
            DisplaySchedulingGrid(strYear, strMonth + "(" + strYear + ")");
        }
    }
    private void BindYears()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet hash = wUser.GetYear();
        ddlYear.DataSource = hash;
        ddlYear.DataTextField = "fycd_Desc";
        ddlYear.DataValueField = "fycd_Desc";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, common.AddItemToList("Select Year", "0"));
    }

    private void BindMonths()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet hash = wUser.GetMonths();
        ddlMonth.DataSource = hash;
        ddlMonth.DataTextField = "month_name";
        ddlMonth.DataValueField = "month_name";
        ddlMonth.DataBind();
        ddlMonth.Items.Insert(0, common.AddItemToList("Select Month", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DisplaySchedulingGrid(ddlYear.SelectedItem.Value, ddlMonth.SelectedItem.Value + "(" + ddlYear.SelectedItem.Value + ")");
    }
    private void DisplaySchedulingGrid(String yr, String mnth)
    {

        Whitfieldcore wc = new Whitfieldcore();
        DataSet _dsScheduling = wc.GetCummululativeProjectWeeklySchedule(yr, mnth);
        this.PopulateDataGrid(_dsScheduling, grdSchedule,yr,mnth);

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

    private void PopulateDataGrid(DataSet dsGridResults, DataGrid grdRpResults,String yr, String mnth)
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
                txtSelectionResultsMSG.Text = "Report for " + mnth  + ".";
            }
            else
            {
                txtSelectionResultsMSG.Text = "No Reports scheduled for " + mnth  + ".";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    public void PageResultGridNotes(object sender, DataGridPageChangedEventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        DataSet dsGridResults;
        grdSchedule.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = wc.GetCummululativeProjectSchedule();
        this.PopulateDataGrid(dsGridResults, grdSchedule,ddlYear.SelectedItem.Value, ddlMonth.SelectedItem.Value + "(" + ddlYear.SelectedItem.Value + ")");
    }

    public void grdSchedule_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.Cells[0].Text == "zzzzzz")
            {
                e.Item.Cells[0].Text = "Grand Total";
            }

        }
    }
}
