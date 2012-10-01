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
using System.Net;
using System.Net.Mail;
using System.Collections.Specialized;
using System.IO;

public partial class master_terms1 : System.Web.UI.UserControl
{
    public Int32 term_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindDropdownGroups();
            BindDDLDefaults();
        }
    }

    public void BindDDLDefaults()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("Yes", "Y");
        hTable.Add("No", "N");
        ddldefault.DataSource = hTable;
        ddldefault.DataTextField = "value";
        ddldefault.DataValueField = "key";
        ddldefault.DataBind();
       // ddldefault.Items.Insert(0, common.AddItemToList("Select", ""));
    }



    public void LoadDetails(DataSet dsrec)
    {
        try
        {
            //BindDropdownGroups();
            BindDDLDefaults();
            ViewState["cont_id"] = term_id.ToString();
            PopulateDataGrid(dsrec, grd1);
            
        }
        catch (Exception)
        {
            throw;
        }
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
        grd1.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = mm.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
        PopulateDataGrid(dsGridResults, grd1);
    }

    #endregion

    #region DML DataGrid Functions
    public void grd1_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        grd1.ShowFooter = false;
        grd1.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        DataSet dsGridResults = _wc.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
        PopulateDataGrid(dsGridResults, grd1);
    }
    public void grd1_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        grd1.ShowFooter = true;
        grd1.EditItemIndex = -1;
        DataSet dsGridResults = _wc.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
        PopulateDataGrid(dsGridResults, grd1);
    }

    public void grd1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        contingency _wc = new contingency();
        String DetailId = "";
        DetailId = grd1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _dbClass = new Whitfieldcore();
        _wc.DeleteSubTerms(Convert.ToInt32(DetailId));
        DataSet dsGridResults = _wc.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
        PopulateDataGrid(dsGridResults, grd1);
    }
    public void grd1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = grd1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.UpdateSubTerms(Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtdesc"))).Text, ((RadioButtonList)(e.Item.FindControl("chkis_default"))).SelectedItem.Value);
        grd1.EditItemIndex = -1;
        grd1.ShowFooter = true;
        DataSet dsGridResults = _wc.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
        PopulateDataGrid(dsGridResults, grd1);
    }
    #endregion
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            contingency mm = new contingency();
            Int32 IsValidInsert = mm.PopulateSubTerms(Convert.ToInt32(ViewState["cont_id"].ToString()), txtdesc.Text.Trim(), ddldefault.SelectedItem.Value);
            DataSet dsGridResults = mm.FetchSubTermsData(Convert.ToInt32(ViewState["cont_id"].ToString()));
            PopulateDataGrid(dsGridResults, grd1);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
