using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class SearchProjects : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 25;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindProjectStatus();
            BindEstimators();
            DataSet dsGridResults;
            dsGridResults = this.Summary_Queue();
            this.PopulateDataGrid(dsGridResults);
        }
    }
    #region UI Methods
    public string ShowEditImage(object EstNum)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + EstNum.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion
    private void BindProjectStatus()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetProjectStatus();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlPrjStatus.DataSource = dsGrp;
            ddlPrjStatus.DataTextField = "StatType";
            ddlPrjStatus.DataValueField = "StatID";
            ddlPrjStatus.DataBind();
            ddlPrjStatus.Items.Insert(0, common.AddItemToList("All", ""));

        }
    }
    private void BindEstimators()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetEstimators();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlEstimator.DataSource = dsGrp;
            ddlEstimator.DataTextField = "estName";
            ddlEstimator.DataValueField = "Loginid";
            ddlEstimator.DataBind();
            ddlEstimator.Items.Insert(0, common.AddItemToList("Select Estimator", ""));

        }
    }

    #region Datagrid common Functions
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdRpResults.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue();
        PopulateDataGrid(dsGridResults);

    }

    private DataSet Summary_Queue()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            if(Request.Cookies["RoleId"].Value == "2")
                dsRpAdvances = _wc.GetProjectInfo(Request.Cookies["RoleId"].Value, Request.Cookies["UserId"].Value, txtEstName.Text.Trim(), ddlPrjStatus.SelectedItem.Value);
            else
                dsRpAdvances = _wc.GetProjectInfo(Request.Cookies["RoleId"].Value, ddlEstimator.SelectedItem.Value, txtEstName.Text.Trim(), ddlPrjStatus.SelectedItem.Value);
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

    private void PopulateDataGrid(DataSet dsGridResults)
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
                txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " Record(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                txtSelectionResultsMSG.Text = "Please broaden your search and try again.";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }

    #endregion 
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        DataSet dsGridResults;
        dsGridResults = this.Summary_Queue();
        PopulateDataGrid(dsGridResults);
    }
}
