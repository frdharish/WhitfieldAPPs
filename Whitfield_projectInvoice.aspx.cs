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

public partial class Whitfield_projectInvoice : System.Web.UI.Page
{
    private decimal TotalfabLabcost = 0;
    private decimal TotalInstallLabCost = 0;
    private decimal TotalMateralCost = 0;
    private decimal TotalOverheadCost = 0;
    private decimal TotalBaseContractCost = 0;
    private decimal TotalChangeOrderCost = 0;
    private decimal TotalInvoiceAmount = 0;

    private decimal TotalSOVAmount = 0;
    private decimal TotalCOSOVAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {        

        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {

            // See if any query string exists
            Whitfield_Project _wc = new Whitfield_Project();
            if (n.HasKeys())
            {
                string k = n.GetKey(0);
                string v = n.Get(0);

                string k1 = n.GetKey(1);
                string v1 = n.Get(1);

                hdnEstNum.Value = v;
                hdntwcProjNumber.Value = v1;

                ViewState["EstNum"] = v;
                ViewState["twc_project_number"] = v1;
                _wc.UpdateCostUpdates(v, v1);
                BindPage(Convert.ToInt32(v), Convert.ToInt32(v1));               
            }
        }  

    }
    private void BindPage(Int32 EstNum, Int32 ProjectNumber)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        try
        {
            IDataReader iReader = _wc.GetProjectInfo(Convert.ToInt32(EstNum), Convert.ToInt32(ProjectNumber));
            while (iReader.Read())
            {
                BindWinClientinfo(Convert.ToInt32(EstNum), Convert.ToInt32(ProjectNumber));
               
                txtOrigContract.Text = iReader["O_Contract_Value"] == DBNull.Value ? "0" : iReader["O_Contract_Value"].ToString();
                txtChangeOrder.Text = iReader["Change_Order_Value"] == DBNull.Value ? "0" : iReader["Change_Order_Value"].ToString();
                lblCurrentContract.Text = (Convert.ToDecimal(txtOrigContract.Text) + Convert.ToDecimal(txtChangeOrder.Text)).ToString();
                lblPrjHeader.Text = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
                txtInitialPaymentDate.Text = iReader["Init_Payment_Date"] == DBNull.Value ? "" : iReader["Init_Payment_Date"].ToString();
                txtFinalPaymentDate.Text = iReader["Final_Payment_Date"] == DBNull.Value ? "" : iReader["Final_Payment_Date"].ToString();
                //String winclient = iReader["WinClient"] == DBNull.Value ? "" : iReader["WinClient"].ToString();
                String winclient = _wc.GetWinningClient(Convert.ToInt32(EstNum));
                String Payment_point_of_contact = iReader["Payment_point_of_contact"] == DBNull.Value ? "" : iReader["Payment_point_of_contact"].ToString();
                //Response.Write("Wining Client:" + winclient);
                BindContacts(Convert.ToInt32(winclient));
                ddlContacts.SelectedIndex = ddlContacts.Items.IndexOf(ddlContacts.Items.FindByValue(Payment_point_of_contact.ToString()));
               
                BindYears();
                BindMonths();
                BindWeeks();
                string strMonth = DateTime.Now.ToString("MMMM");
                string strYear = DateTime.Now.ToString("yyyy");
                ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(strMonth.ToString()));
                ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByValue(strYear.ToString()));
            }
            DisplayGrid();
            DisplaySOVGrid();
            DisplayCOSOVGrid();
            DisplayHistoryNotes();
            DisplaySchedulingGrid();
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
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

    }

    private void BindWeeks()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet ds = wUser.GetWeeks();
        ddlWeek.DataSource = ds;
        ddlWeek.DataTextField = "week_name";
        ddlWeek.DataValueField = "week_name";
        ddlWeek.DataBind();
        ddlWeek.Items.Insert(0, common.AddItemToList("Select Week", "0"));
    }
    private void BindWinClientinfo(Int32 EstNum, Int32 twc_project_number)
    {
        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();
        dsGrp = wUser.GetClientlistForProject(EstNum.ToString(), twc_project_number);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlwonclient.DataSource = dsGrp;
            ddlwonclient.DataTextField = "Name1";
            ddlwonclient.DataValueField = "ClientID";
            ddlwonclient.DataBind();
        }
        else
        {
            ddlwonclient.Items.Insert(0, common.AddItemToList("No Clients Yet", "0"));
        }
    }
    private void BindContacts(Int32 Clientid)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetContactsForClientsSOV(Clientid);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlContacts.DataSource = dsGrp;
            ddlContacts.DataTextField = "FName";
            ddlContacts.DataValueField = "ContactID";
            ddlContacts.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        try
        {
            project_invoice _pi = new project_invoice();
            _pi.UpdateProjectInfo(Convert.ToInt32(ViewState["EstNum"].ToString()),Convert.ToInt32(ViewState["twc_project_number"].ToString()),txtInitialPaymentDate.Text.Trim(),txtFinalPaymentDate.Text.Trim(),ddlContacts.SelectedItem.Value,txtOrigContract.Text.Trim(),txtChangeOrder.Text.Trim());
            BindPage(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }

    #region DataGrid Function Starts Here
    private void DisplayGrid()
    {
        try
        {
            project_invoice _pi = new project_invoice();
            DataSet _dsInvoices = new DataSet();
            _dsInvoices = _pi.GetInvoiceforProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            PopulateDataGrid(_dsInvoices, grdpl1);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    private void DisplaySOVGrid()
    {
        try
        {
            project_invoice _pi = new project_invoice();
            DataSet _dsSOV = new DataSet();
            _dsSOV = _pi.GetInvoiceSOVforProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            PopulateDataGrid(_dsSOV, grdSOV);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }

    private void DisplayCOSOVGrid()
    {
        try
        {
            project_invoice _pi = new project_invoice();
            DataSet _dsSOV = new DataSet();
            _dsSOV = _pi.GetInvoiceCOSOVforProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            PopulateDataGrid(_dsSOV,grdCOSOV);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    public void PopulateDataGrid(DataSet dsGridResults, DataGrid grd)
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
                if (resultCount > (grd.CurrentPageIndex + 1) * grd.PageSize)
                    maxResultItemInPage = (grd.CurrentPageIndex + 1) * grd.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grd.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grd.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grd.Visible = true;
                grd.DataSource = tblInstallments;
                grd.DataBind();
            }
            else
            {
                grd.Visible = false;
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
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String InvoiceID = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _pi = new project_invoice();
        _pi.MaintainInvoiceRecords(ViewState["twc_project_number"].ToString(), ((TextBox)(e.Item.FindControl("txtDate_Submited"))).Text, ((TextBox)(e.Item.FindControl("txtDate_Received"))).Text, ((TextBox)(e.Item.FindControl("txtDate_Approved"))).Text, ((TextBox)(e.Item.FindControl("txtfab_lab_Cost"))).Text, ((TextBox)(e.Item.FindControl("txtIns_lab_Cost"))).Text, ((TextBox)(e.Item.FindControl("txtMaterial_cost"))).Text, ((TextBox)(e.Item.FindControl("txtBase_contract"))).Text, ((TextBox)(e.Item.FindControl("txtChange_order"))).Text, ((TextBox)(e.Item.FindControl("txtInvoice_comments"))).Text, InvoiceID);
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid();
    }
    public void grdpl1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _dbClass = new project_invoice();
        _dbClass.DeleteInvoice(Convert.ToInt32(ViewState["twc_project_number"].ToString()),DetailId);
        this.DisplayGrid();
    }

    public void grdSOV_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        String DetailId = "";
        DetailId = grdSOV.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _dbClass = new project_invoice();
        _dbClass.DeleteSOV(Convert.ToInt32(ViewState["twc_project_number"].ToString()),DetailId);
        _wc.UpdateCostUpdates(ViewState["EstNum"].ToString(), ViewState["twc_project_number"].ToString());
        this.DisplaySOVGrid();
    }

    public void grdSOV_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdSOV.ShowFooter = false;
        grdSOV.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        this.DisplaySOVGrid();
    }
    public void grdSOV_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        //'grdSOV_CancelCommand' 
        grdSOV.ShowFooter = true; 
        grdSOV.EditItemIndex = -1;
        this.DisplaySOVGrid();
    }
    public void grdSOV_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        String SeqNo = grdSOV.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _pi = new project_invoice();
        _pi.MaintainInvoiceRecords(ViewState["twc_project_number"].ToString(), SeqNo, ((TextBox)(e.Item.FindControl("txtDescription"))).Text, ((TextBox)(e.Item.FindControl("txtsov_amount"))).Text);
        _wc.UpdateCostUpdates(ViewState["EstNum"].ToString(), ViewState["twc_project_number"].ToString());
        grdSOV.EditItemIndex = -1;
        grdSOV.ShowFooter = true;
        this.DisplaySOVGrid();
    }
    public void PageResultGrid(object sender, DataGridPageChangedEventArgs e)
    {
        grdSOV.CurrentPageIndex = e.NewPageIndex;
        this.DisplayGrid();
    }
    public void PageResultGridSOV(object sender, DataGridPageChangedEventArgs e)
    {
        grdSOV.CurrentPageIndex = e.NewPageIndex;
        this.DisplaySOVGrid();
    }

    public void grdpl1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            TotalfabLabcost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblfab_lab_Cost"))).Text);
            TotalInstallLabCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblIns_lab_Cost"))).Text);
            TotalMateralCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMaterial_cost"))).Text);
            TotalOverheadCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblOverhead_Cost0"))).Text);
            TotalBaseContractCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblBase_contract"))).Text);
            TotalChangeOrderCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblChange_order"))).Text);
            TotalInvoiceAmount += Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotal_inv_Amount0"))).Text);  
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[5].Text = string.Format("{0:c}", TotalfabLabcost); 
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[6].Text = string.Format("{0:c}", TotalInstallLabCost);  
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[7].Text = string.Format("{0:c}", TotalMateralCost);
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[8].Text = string.Format("{0:c}", TotalOverheadCost);
            e.Item.Cells[8].Font.Bold = true;
            e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[9].Text = string.Format("{0:c}", TotalBaseContractCost);
            e.Item.Cells[9].Font.Bold = true;
            e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[10].Text = string.Format("{0:c}", TotalChangeOrderCost);
            e.Item.Cells[10].Font.Bold = true;
            e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Right;

            e.Item.Cells[11].Text = string.Format("{0:c}", TotalInvoiceAmount);
            e.Item.Cells[11].Font.Bold = true;
            e.Item.Cells[11].HorizontalAlign = HorizontalAlign.Right;
        }
    }


    public void grdSOV_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           TotalSOVAmount += Convert.ToDecimal(((Label)(e.Item.FindControl("lblsov_amount"))).Text);
           ((Label)(e.Item.FindControl("lblsov_amount"))).Text = "$" + ((Label)(e.Item.FindControl("lblsov_amount"))).Text;
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[3].Text = string.Format("{0:c}", TotalSOVAmount);
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void grdCOSOV_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalCOSOVAmount += Convert.ToDecimal(((Label)(e.Item.FindControl("lblsov_amount"))).Text);
            ((Label)(e.Item.FindControl("lblsov_amount"))).Text = "$" + ((Label)(e.Item.FindControl("lblsov_amount"))).Text;
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].Text = "Total($):";
            e.Item.Cells[4].Text = string.Format("{0:c}", TotalCOSOVAmount);
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
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

    public void grdCOSOV_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        String DetailId = "";
        DetailId = grdCOSOV.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _dbClass = new project_invoice();
        _dbClass.DeleteCOSOV(Convert.ToInt32(ViewState["twc_project_number"].ToString()), DetailId);
        _wc.UpdateCostUpdates(ViewState["EstNum"].ToString(), ViewState["twc_project_number"].ToString());
        this.DisplayCOSOVGrid();
    }

    public void grdCOSOV_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdCOSOV.ShowFooter = false;
        grdCOSOV.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        this.DisplayCOSOVGrid();
    }
     
    public void grdCOSOV_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        //'grdSOV_CancelCommand' 
        grdCOSOV.ShowFooter = true;
        grdCOSOV.EditItemIndex = -1;
        this.DisplayCOSOVGrid();
    }
    public void grdCOSOV_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        String SeqNo = grdCOSOV.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        project_invoice _pi = new project_invoice();
        _pi.MaintainChangeOrderSOVRecords(ViewState["twc_project_number"].ToString(), SeqNo, ((TextBox)(e.Item.FindControl("txtco_number"))).Text, ((TextBox)(e.Item.FindControl("txtDescription"))).Text, ((TextBox)(e.Item.FindControl("txtsov_amount"))).Text, ((TextBox)(e.Item.FindControl("txtDate_Submited"))).Text, ((TextBox)(e.Item.FindControl("txtDate_Approved"))).Text, ((TextBox)(e.Item.FindControl("txtNotes"))).Text);
        grdCOSOV.EditItemIndex = -1;
        grdCOSOV.ShowFooter = true;
        _wc.UpdateCostUpdates(ViewState["EstNum"].ToString(), ViewState["twc_project_number"].ToString());
        this.DisplayCOSOVGrid();
    }

    #endregion DataGrid Function Ends Here

    protected void btnProdSchedule_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        DataSet ds = new DataSet();
 
        if (!txtInitialPaymentDate.Text.ToString().Equals("") && !txtFinalPaymentDate.Text.ToString().Equals(""))
        {
            wc.RemoveCashFlowScheduledata(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            ds = wc.GetSchedule(txtInitialPaymentDate.Text.ToString(), txtFinalPaymentDate.Text.ToString());
            Int32 resultCount = 0;
            if (ds.Tables.Count > 0)
                resultCount = ds.Tables[0].Rows.Count;
            DataTable myControls;
            myControls = ds.Tables[0];
            Int32 iCnt = 1;
            if (myControls.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dRow in myControls.Rows)
                    {
                        Hashtable hash = wc.GetWeeksHash();
                        String _yr = dRow["dt2"] != DBNull.Value ? dRow["dt2"].ToString() : "";
                        String _mnth = dRow["dt1"] != DBNull.Value ? dRow["dt1"].ToString() : "";
                        foreach (string key in hash.Keys)
                        {
                            wc.PopulateCashFlowSchedule(Convert.ToInt32(ViewState["twc_project_number"].ToString()), _yr, _mnth + "(" + _yr + ")", hash[key].ToString(), iCnt);
                        }
                        iCnt++;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                DisplaySchedulingGrid();
            }
            else
            {
                Response.Write("No Data");
            }
        }
        else
        {
            Response.Write("Construction Start date and Construction End date should be Set");
        }
    }

    #region CashFlow Analysis Module

    private void FetchSehedule()
    {

        txtSchAmount.Text = "0";
        txtWeeklyComments.Text = "";
        Whitfieldcore wc = new Whitfieldcore();
        DataSet ds = new DataSet();
        ds = wc.GetScheduleDataForCashFlow(Convert.ToInt32(ViewState["twc_project_number"].ToString()), ddlYear.SelectedItem.Value.ToString(), ddlMonth.SelectedItem.Value.ToString() + "(" + ddlYear.SelectedItem.Value.ToString() + ")", ddlWeek.SelectedItem.Value.ToString());
        Int32 resultCount = 0;
        if (ds.Tables.Count > 0)
            resultCount = ds.Tables[0].Rows.Count;
        DataTable myControls;
        myControls = ds.Tables[0];
        if (myControls.Rows.Count > 0)
        {
            try
            {
                foreach (DataRow dRow in myControls.Rows)
                {
                    String _comments = dRow["weeklyNotes"] != DBNull.Value ? dRow["weeklyNotes"].ToString() : "";
                    String project_amount = dRow["project_amount"] != DBNull.Value ? dRow["project_amount"].ToString() : "0";
                    txtSchAmount.Text = project_amount;
                    txtWeeklyComments.Text = _comments;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            DisplaySchedulingGrid();
        }
        else
        {
            txtSchAmount.Text = "0";
            txtWeeklyComments.Text = "";
        }
    }

    private void DisplaySchedulingGrid()
    {

        Whitfieldcore wc = new Whitfieldcore();
        DataSet _dsScheduling = new DataSet();
        lblTotAnnFabHours.Text = wc.GetCurrentContractValue(Convert.ToInt32(ViewState["twc_project_number"])).ToString();
        lblTotScheduledHours.Text = wc.GetTotalscheduledCashFlow(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        if (wc.IsCashFlowScheduleDataExists(Convert.ToInt32(ViewState["twc_project_number"].ToString())))
        {
            pnlActSchedule.Visible = true;
            _dsScheduling = wc.GetCashflowListing(ViewState["twc_project_number"].ToString());
            this.PopulateDataGrid(_dsScheduling, grdSchedule);
        }

    }
    private void DisplayHistoryNotes()
    {

        Whitfieldcore wc = new Whitfieldcore();
        DataSet _dsNotes = new DataSet();
        _dsNotes = wc.GetCashFlowNotes(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        this.PopulateDataGrid(_dsNotes, grdWeeklyNotes);
    }

    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchSehedule();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchSehedule();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchSehedule();
    }
   

    protected void btnSaveHours_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        try
        {
            Boolean isValidEntry = wc.MaintainCashFlowScheduledata(Convert.ToInt32(ViewState["twc_project_number"].ToString()), ddlYear.SelectedItem.Value.ToString(), ddlMonth.SelectedItem.Value.ToString() + "(" + ddlYear.SelectedItem.Value.ToString() + ")", ddlWeek.SelectedItem.Value.ToString(), txtWeeklyComments.Text.Trim(), txtSchAmount.Text.Trim());
            if (!isValidEntry)
            {
                lblSchError.Text = "Please check the input hours. The scheduled hours should not exceed " + lblTotAnnFabHours.Text.Trim();
            }
            else
            {
                lblSchError.Text = "";
            }
            DisplaySchedulingGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    #endregion
}
