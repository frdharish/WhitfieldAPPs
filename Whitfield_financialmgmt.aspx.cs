using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Whitfield_financialmgmt : System.Web.UI.Page
{
    private decimal TotalCurrentContract = 0;
    private decimal TotalOriginalContract = 0;
    private decimal TotalChangeOrders = 0;
    private decimal TotalEarnedAmount = 0;
    private decimal TotalOpenInvoices = 0;
    private decimal TotalBalRemaining = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet dsSubmitted;
            //DataSet dsPending;
           // DataSet dsAwarded;
            dsSubmitted = this.Summary_Queue();
            this.PopulateDataGrid(dsSubmitted,grdProjects);
        }
    }

    #region UI Methods
    public string ShowEditImage(object EstNum,object twc_project_number)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + EstNum.ToString().Trim() + "','" + twc_project_number + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion

    #region	Show Closing Tag
    public string ShowClosingTags()
    {

        return "</td></tr><tr><td colspan=\"9\">";

    }
    #endregion

    #region Datagrid common Functions

    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdProjects.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = dsGridResults = this.Summary_Queue();
        PopulateDataGrid(dsGridResults, grdProjects);

    }
    public void grdProjects_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Decimal _totBalRemaining = 0;
            Decimal _totEarnedAmount = 0;
           // TotalPendingBaseBid += Convert.ToDecimal(e.Item.Cells[3].Text);
            //Earned AMount = current contract - (open invoices + Balance Remaining)
            //Open Invoices = sum of total invoice amount where date received is null
            //Balance Remining = currentconract - (Earned Amount + Open Invoices)
            e.Item.Cells[4].Text = (Convert.ToDecimal(e.Item.Cells[5].Text) + Convert.ToDecimal(e.Item.Cells[6].Text)).ToString();
           
            TotalCurrentContract += Convert.ToDecimal(e.Item.Cells[4].Text);
            TotalOriginalContract += Convert.ToDecimal(e.Item.Cells[5].Text);
            TotalChangeOrders += Convert.ToDecimal(e.Item.Cells[6].Text);
            
            _totEarnedAmount = (Convert.ToDecimal(e.Item.Cells[4].Text) - Convert.ToDecimal(e.Item.Cells[7].Text));
            ((Label)(e.Item.FindControl("lblBalremaining"))).Text = string.Format("{0:c}", _totEarnedAmount);
           // e.Item.Cells[6].Text = string.Format("{0:c}", _totEarnedAmount);
            TotalEarnedAmount += Convert.ToDecimal(_totEarnedAmount);


            TotalOpenInvoices += Convert.ToDecimal(e.Item.Cells[8].Text);
            
             _totBalRemaining = ( Convert.ToDecimal(e.Item.Cells[4].Text) - (_totEarnedAmount + Convert.ToDecimal(e.Item.Cells[8].Text)) );
            TotalBalRemaining += Convert.ToDecimal(_totBalRemaining);
            e.Item.Cells[7].Text = string.Format("{0:c}", _totBalRemaining);
            //((Label)(e.Item.FindControl("lblBalremaining"))).Text = string.Format("{0:c}", _totBalRemaining);

            e.Item.Cells[4].Text = "$" + e.Item.Cells[4].Text;
            e.Item.Cells[5].Text = "$" + e.Item.Cells[5].Text;
            e.Item.Cells[6].Text = "$" + e.Item.Cells[6].Text;
            e.Item.Cells[8].Text = "$" + e.Item.Cells[8].Text;
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            //e.Item.Cells[3].Text = TotalCurrentContract.ToString();
            e.Item.Cells[4].Text = string.Format("{0:c}", TotalCurrentContract); 
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;

            //.Item.Cells[4].Text = TotalOriginalContract.ToString();
            e.Item.Cells[5].Text = string.Format("{0:c}", TotalOriginalContract);
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[6].Text = string.Format("{0:c}", TotalChangeOrders); 
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[7].Text = string.Format("{0:c}", TotalBalRemaining);
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[8].Text = string.Format("{0:c}", TotalOpenInvoices);
            e.Item.Cells[8].Font.Bold = true;
            e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[9].Text = string.Format("{0:c}", TotalEarnedAmount);
            e.Item.Cells[9].Font.Bold = true;
            e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Right;            
        }
    }
    public void grdProjects_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        Int32 _twc_proj_number_ID = 0;
        DataSet dsExpand = new DataSet();
        project_invoice _pi = new project_invoice();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    _twc_proj_number_ID = Convert.ToInt32(grdProjects.DataKeys[Convert.ToInt32(e.Item.ItemIndex)]);
                    _twc_proj_number_ID = Convert.ToInt32(grdProjects.DataKeys[e.Item.ItemIndex]);
                    dsExpand = _pi.GetInvoiceforProject(Convert.ToInt32(_twc_proj_number_ID.ToString()));
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[10].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    if (dsExpand.Tables[0].Rows.Count > 0)
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).ProjectNumber = _twc_proj_number_ID;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(dsExpand);

                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).Visible = false;
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
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).ProjectNumber = _twc_proj_number_ID;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(dsExpand);
                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_financialmgmt_child)(e.Item.FindControl("DynamicTable1"))).Visible = false;
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
    public void GridFormat(DataGridItemEventArgs e)
    {

        e.Item.Cells[3].Font.Bold = true;
        e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
    }
    private DataSet Summary_Queue()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            project_invoice _wc = new project_invoice();
            dsRpAdvances = _wc.GetProjectInvoices();
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
