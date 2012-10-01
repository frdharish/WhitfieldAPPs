using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class manageclients : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 100;
    protected string _pageName = common.GetPageName(HttpContext.Current.Request.ServerVariables.Get("PATH_INFO")).ToUpper();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            grdRpResults.PageSize = _DEFAULTPAGESIZE;
            DataSet dsGridResults;
            dsGridResults = this.Summary_Queue();
            this.PopulateDataGrid(dsGridResults);
        }

        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    #region UI Methods
    public string ShowEditImage(object ClientID)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + ClientID.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion 

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
            dsRpAdvances = _wc.GetClientlist();
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
                txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " Client(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                txtSelectionResultsMSG.Text = "No Clients Setup yet.";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }

    #endregion
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("addclient.aspx?IsNew=Y");
    }
}
