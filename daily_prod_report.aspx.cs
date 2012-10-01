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
using System.Net;
using System.Text;
using System.Net.Mail;
using System.IO;
public partial class daily_prod_report : System.Web.UI.Page
{

    private Decimal TotalFabHours = 0;
    private Decimal TotalfinHours = 0;
    private Decimal TotalEngHours = 0;
    private Decimal TotalMiscHours = 0;

    private Decimal SumFabHours = 0;
    private Decimal SumfinHours = 0;
    private Decimal SumEngHours = 0;
    private Decimal SumMiscHours = 0;

    private Decimal SumEFabHours = 0;
    private Decimal SumEfinHours = 0;
    private Decimal SumEEngHours = 0;
    private Decimal SumEMiscHours = 0;

    private Decimal SumTotHours = 0;
    private Decimal TotHours = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        whitfield_prod_reports _wr = new whitfield_prod_reports();
        NameValueCollection n = Request.QueryString;

        if (!Page.IsPostBack)
        {
            //Logic Here for the Project Daily Field Report
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                txtReportDate.Text = v;
            }
            else
            {
                txtReportDate.Text = _wr.GetCurrentDate().Trim();
            }
            bindcontrols();
            if (_wr.IsReportExists(txtReportDate.Text.Trim()))
            {
                DataSet _dsDailyRpt = _wr.GetReportForProject(txtReportDate.Text.Trim());
                //txtReportDate.Text = _wr.GetCurrentDate();
                DataTable dtUsr = _dsDailyRpt.Tables[0];
                String _chkStatus = "";
                foreach (DataRow dRow in dtUsr.Rows)
                {
                    //txtRptNotes.Text = dRow["Daily_notes"] == DBNull.Value ? "" : dRow["Daily_notes"].ToString();
                    txtRptIssues.Text = dRow["Daily_comments"] == DBNull.Value ? "" : dRow["Daily_comments"].ToString();
                    //txtRptChangeOrderNotes.Text = dRow["Change_order_notes"] == DBNull.Value ? "" : dRow["Change_order_notes"].ToString();
                    _chkStatus = dRow["is_locked"] == DBNull.Value ? "" : dRow["is_locked"].ToString();
                    if (_chkStatus.Trim() == "Y")
                    {
                        chkActive.SelectedIndex = chkActive.Items.IndexOf(chkActive.Items.FindByValue(_chkStatus));
                      //  btnWO.Visible = false;
                    }
                }

            }
            //Logic for Project Daily Field Report Ends.
        }
    }
    public void bindcontrols()
    {
        BindProjects();
        BindEmployees();
        DisplayReportGrid();
        DisplayHistoryGrid();
        DisplayEmployeeHoursGrid();
        BindYears();
        BindMonths();
        DisplayProductionSchedule();
        //Here goes the logic for Project Schedule Datagrid

    }
    public void BindYears()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet hash = wUser.GetYear();
        ddlYear.DataSource = hash;
        ddlYear.DataTextField = "fycd_Desc";
        ddlYear.DataValueField = "fycd_Desc";
        ddlYear.DataBind();
    }

    public void BindMonths()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet hash = wUser.GetMonths();
        ddlMonth.DataSource = hash;
        ddlMonth.DataTextField = "month_name";
        ddlMonth.DataValueField = "month_name";
        ddlMonth.DataBind();
    }


    private void DisplayProductionSchedule()
    {
        plSchedule.Controls.Clear();
        try
        {
            whitfield_prod_reports wSchedule = new whitfield_prod_reports();
            Whitfieldcore wWeek = new Whitfieldcore();

            //Fetch the General week Number for the outer loop
            //Fetch the Production schedule Dataset by passing the YEAR, MONTH and Week and bind the DataGrid. Continue for other Weeks.

            DataSet dsWeek = wWeek.GetWeeks();
            if (dsWeek.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in dsWeek.Tables[0].Rows)
                {
                    String _weekName = dRow["week_name"].ToString();
                    DataSet dsProdSchedule = wSchedule.GetProductionScheduleForDates(ddlMonth.SelectedItem.Value, ddlYear.SelectedItem.Value, _weekName);
                    Int32 resultCountProd = 0;
                    if (dsProdSchedule.Tables.Count > 0)
                        resultCountProd = dsProdSchedule.Tables[0].Rows.Count;

                    if (resultCountProd > 0)
                    {
                       // Label lblTxt = new Label();
                       // lblTxt.CssClass = "header1";
                       // lblTxt.Text = _weekName;
                        DataGrid dGrid = new DataGrid();
                        dGrid.ID = "grd" + ddlMonth.SelectedItem.Value + ddlYear.SelectedItem.Value + _weekName;
                        dGrid.HorizontalAlign = HorizontalAlign.Left;
                        dGrid.CssClass="data";
                        dGrid.HeaderStyle.Font.Bold=true;
                        dGrid.HeaderStyle.HorizontalAlign= HorizontalAlign.Center;
                        dGrid.HeaderStyle.BackColor = System.Drawing.Color.LightBlue;
                        dGrid.HeaderStyle.CssClass="subnav";
                        //dGrid.Width=Unit.Pixel(500);
                        //dGrid.AllowPaging=false;
                        //dGrid.AutoGenerateColumns=false;
                        //dGrid.SelectedItemStyle.BackColor=System.Drawing.Color.LightGray;
                        //dGrid.ShowFooter=true;
                        dGrid.Caption = _weekName;
                        dGrid.CaptionAlign = TableCaptionAlign.Left;
                        dGrid.ItemStyle.Wrap = true;
                        dGrid.DataSource = dsProdSchedule.Tables[0];
                        dGrid.DataBind();
                        //plSchedule.Controls.Add(lblTxt);
                        plSchedule.Controls.Add(dGrid);
                    }
                }
            }


        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }


    public string showHistoryReport(object ReportDate)
    {
        return "<a ID='ViewNotes' href=\"javascript:showHistoryReport('" + ReportDate.ToString().Trim() + "');\"" + ">" + ReportDate.ToString().Trim() + "</a>";
    }
    public void BindProjects(){
        DataSet dsGrp = new DataSet();
        Whitfield_Project wProjects = new Whitfield_Project();
        dsGrp = wProjects.GetProjectInfo();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlProject.DataSource = dsGrp;
            ddlProject.DataTextField = "ProjName";
            ddlProject.DataValueField = "EstNum";
            ddlProject.DataBind();
            ddlProject.Items.Insert(0, common.AddItemToList("Select Project", "0"));
        }
    }
    public void BindWorkOrders()
    {

        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();
        ddlworkorders.Items.Clear();
        dsGrp = wUser.GetWorkOrders(ddlProject.SelectedItem.Value);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlworkorders.DataSource = dsGrp;
            ddlworkorders.DataTextField = "woid";
            ddlworkorders.DataValueField = "work_order_id";
            ddlworkorders.DataBind();
            ddlworkorders.Items.Insert(0, common.AddItemToList("Select WorkOrder", "0"));
        }
        else
        {
            ddlworkorders.Items.Insert(0, common.AddItemToList("No workorders available", "0"));
        }
    }

    public void BindEmployees()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetProjectUsersNoInstallers();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlEmpl.DataSource = dsGrp;
            ddlEmpl.DataTextField = "uName";
            ddlEmpl.DataValueField = "loginId";
            ddlEmpl.DataBind();
            ddlEmpl.Items.Insert(0, common.AddItemToList("Select Worker", "0"));

        }
    }
    public DataSet FetchProjectUsers()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetProjectUsers();
        return dsGrp;
    }
    public DataSet FetchReportActivity()
    {
        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();
        dsGrp = wUser.GetWorkOrders(ViewState["EstNum"].ToString(), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        return dsGrp;
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindWorkOrders();
    }
    protected void ddlworkorders_SelectedIndexChanged(object sender, EventArgs e)
    {
        whitfield_prod_reports _wr = new whitfield_prod_reports();
        DataSet dsNormal = new DataSet();
        DataSet dsBudget = new DataSet();

        DataSet dsCummTD = new DataSet();
        DataSet dsCummBudget = new DataSet();
        DataSet dsCummDaily = new DataSet();

        dsNormal = _wr.GetBudgetHoursForWO(ddlProject.SelectedItem.Value, ddlworkorders.SelectedItem.Value);
        dsBudget = _wr.GetHoursTDForWO(ddlProject.SelectedItem.Value,ddlworkorders.SelectedItem.Value);

         dsCummBudget = _wr.GetCummulativeBudgetHoursForWO(txtReportDate.Text.Trim());
         dsCummDaily  = _wr.GetCummulativeHoursForToday(txtReportDate.Text.Trim());
         dsCummTD = _wr.GetCummulativeHoursTDForWO(txtReportDate.Text.Trim());

        //Instantiate the labels
        //cumulative labels instantiation
            lblcumEngHours.Text = "0";
            lblcumFabHours.Text = "0";
            lblcumfinHours.Text = "0"; 
            lblcummiscHours.Text = "0";
            lblcumtotHours.Text = "0"; 
            lblcumEngTD.Text = "0"; 
            lblcumfabTD.Text = "0"; 
            lblcumfinTD.Text = "0"; 
            lblcummiscTD.Text = "0";
            lblcumtotTD.Text = "0"; 
            lblcumDailyEng.Text = "0";
            lblcumDailyfab.Text = "0";
            lblcumDailyfin.Text = "0";
            lblcumDailymisc.Text = "0";
            lblcumDailytot.Text = "0";
            lblcumdiffEng.Text = "0"; 
            lblcumdifffab.Text = "0"; 
            lblcumdifffin.Text = "0"; 
            lblcumdiffmisc.Text = "0";
            lblcumdifftot.Text = "0";

            //cummulative hours
            DataTable dtCummBudget = dsCummBudget.Tables[0];
            foreach (DataRow dRow in dtCummBudget.Rows)
            {
                lblcumEngHours.Text = dRow["eng_hours"] == DBNull.Value ? "0" : dRow["eng_hours"].ToString();
                lblcumFabHours.Text = dRow["fab_hours"] == DBNull.Value ? "0" : dRow["fab_hours"].ToString();
                lblcumfinHours.Text = dRow["fin_hours"] == DBNull.Value ? "0" : dRow["fin_hours"].ToString();
                lblcummiscHours.Text = dRow["misc_hours"] == DBNull.Value ? "0" : dRow["misc_hours"].ToString();
                lblcumtotHours.Text = dRow["TotHours"] == DBNull.Value ? "0" : dRow["TotHours"].ToString();
            }
            //dumulative Daily Hours
            DataTable dtCummDaily = dsCummDaily.Tables[0];
            foreach (DataRow dRow1 in dtCummDaily.Rows)
            {
                lblcumDailyEng.Text = dRow1["eng_hours"] == DBNull.Value ? "0" : dRow1["eng_hours"].ToString();
                lblcumDailyfab.Text = dRow1["fab_hours"] == DBNull.Value ? "0" : dRow1["fab_hours"].ToString();
                lblcumDailyfin.Text = dRow1["fin_hours"] == DBNull.Value ? "0" : dRow1["fin_hours"].ToString();
                lblcumDailymisc.Text = dRow1["misc_hours"] == DBNull.Value ? "0" : dRow1["misc_hours"].ToString();
                lblcumDailytot.Text = dRow1["TotHours"] == DBNull.Value ? "0" : dRow1["TotHours"].ToString();
            }
            //dumulative Daily Hours
            DataTable dtCummTD = dsCummTD.Tables[0];
            foreach (DataRow dRow2 in dtCummTD.Rows)
            {
                lblcumEngTD.Text = dRow2["eng_hours"] == DBNull.Value ? "0" : dRow2["eng_hours"].ToString();
                lblcumfabTD.Text = dRow2["fab_hours"] == DBNull.Value ? "0" : dRow2["fab_hours"].ToString();
                lblcumfinTD.Text = dRow2["fin_hours"] == DBNull.Value ? "0" : dRow2["fin_hours"].ToString();
                lblcummiscTD.Text = dRow2["misc_hours"] == DBNull.Value ? "0" : dRow2["misc_hours"].ToString();
                lblcumtotTD.Text = dRow2["TotHours"] == DBNull.Value ? "0" : dRow2["TotHours"].ToString();
            }
            
        //Cumulative Difference Calculation

            lblcumdiffEng.Text = (Decimal.Parse(lblcumEngHours.Text) - (Convert.ToDecimal(lblcumEngTD.Text))).ToString();
            lblcumdifffab.Text = (Decimal.Parse(lblcumFabHours.Text) - (Convert.ToDecimal(lblcumfabTD.Text))).ToString();
            lblcumdifffin.Text = (Decimal.Parse(lblcumfinHours.Text) - (Convert.ToDecimal(lblcumfinTD.Text))).ToString();
            lblcumdiffmisc.Text = (Decimal.Parse(lblcummiscHours.Text) - (Convert.ToDecimal(lblcumtotTD.Text))).ToString();
            lblcumdifftot.Text = (Convert.ToDecimal(lblcumdiffEng.Text) + Convert.ToDecimal(lblcumdifffab.Text) + Convert.ToDecimal(lblcumdifffin.Text) + Convert.ToDecimal(lblcumdiffmisc.Text)).ToString();
        //*******************
                //Normal Hours Labels Instantiation.


                lblbudeng.Text = "0";
                lblbudfab.Text = "0";
                lblbudfin.Text = "0";
                lblbudmisc.Text = "0";
                lblbudtot.Text = "0";

                lblEngTD.Text = "0";
                lblfabTD.Text = "0";
                lblfinTD.Text = "0";
                lblmiscTD.Text = "0";
                lbltotTD.Text = "0";

                lbldiffEng.Text = "0";
                lbldifffab.Text = "0";
                lbldifffin.Text = "0";
                lbldiffmisc.Text = "0";
                lbldifftot.Text = "0";

                DataTable dtNormal = dsNormal.Tables[0];
                foreach (DataRow dRow in dtNormal.Rows)
                {
                    lblbudeng.Text = dRow["eng_hours"] == DBNull.Value ? "0" : dRow["eng_hours"].ToString();
                    lblbudfab.Text = dRow["fab_hours"] == DBNull.Value ? "0" : dRow["fab_hours"].ToString();
                    lblbudfin.Text = dRow["fin_hours"] == DBNull.Value ? "0" : dRow["fin_hours"].ToString();
                    lblbudmisc.Text = dRow["misc_hours"] == DBNull.Value ? "0" : dRow["misc_hours"].ToString();
                    lblbudtot.Text = dRow["TotHours"] == DBNull.Value ? "0" : dRow["TotHours"].ToString();
                }
                
                DataTable dtTD = dsBudget.Tables[0];
                foreach (DataRow dRow1 in dtTD.Rows)
                {
                    lblEngTD.Text = dRow1["eng_hours"] == DBNull.Value ? "0" : dRow1["eng_hours"].ToString();
                    lblfabTD.Text = dRow1["fab_hours"] == DBNull.Value ? "0" : dRow1["fab_hours"].ToString();
                    lblfinTD.Text = dRow1["fin_hours"] == DBNull.Value ? "0" : dRow1["fin_hours"].ToString();
                    lblmiscTD.Text = dRow1["misc_hours"] == DBNull.Value ? "0" : dRow1["misc_hours"].ToString();
                    lbltotTD.Text = dRow1["TotHours"] == DBNull.Value ? "0" : dRow1["TotHours"].ToString();
                }

                txtenghours.Text = txtenghours.Text.Trim() == "" ? "0" : txtenghours.Text.Trim().ToString();
                txtfabhours.Text = txtfabhours.Text.Trim() == "" ? "0" : txtfabhours.Text.Trim().ToString();
                txtmischours.Text = txtmischours.Text.Trim() == "" ? "0" : txtmischours.Text.Trim().ToString();
                txtfinhours.Text = txtfinhours.Text.Trim() == "" ? "0" : txtfinhours.Text.Trim().ToString();

                lbldiffEng.Text = (Decimal.Parse(lblbudeng.Text) - (Convert.ToDecimal(lblEngTD.Text) + Convert.ToDecimal(txtenghours.Text))).ToString();
                lbldifffab.Text = (Decimal.Parse(lblbudfab.Text) - (Convert.ToDecimal(lblfabTD.Text) + Convert.ToDecimal(txtfabhours.Text))).ToString();
                lbldifffin.Text = (Decimal.Parse(lblbudfin.Text) - (Convert.ToDecimal(lblfinTD.Text) + Convert.ToDecimal(txtfinhours.Text))).ToString();
                lbldiffmisc.Text = (Decimal.Parse(lblbudmisc.Text) - (Convert.ToDecimal(lblmiscTD.Text) + Convert.ToDecimal(txtmischours.Text))).ToString();
                lbldifftot.Text = (Convert.ToDecimal(lbldiffEng.Text) + Convert.ToDecimal(lbldifffab.Text) + Convert.ToDecimal(lbldifffin.Text) + Convert.ToDecimal(lbldiffmisc.Text)).ToString();
    
        //Instantiate the labels
    }
    #region Daily Field Report Activity Grid
    private void DisplayReportGrid()
    {

        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetReportActivityForProject(_wRep.GetReportNumber(txtReportDate.Text.Trim()));
        this.PopulateRepDataGrid(_dsRep,grdActivity);
    }

    private void DisplayHistoryGrid()
    {

        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetProductionDailyReports();
        this.PopulateRepDataGrid(_dsRep,grdHistoryRpt);
    }

    private void DisplayEmployeeHoursGrid()
    {

        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetEmployeeDailyHours(txtReportDate.Text.Trim());
        this.PopulateRepDataGrid(_dsRep,grdEmployeeHours);
    }


    public void PopulateRepDataGrid(DataSet dsGridResults, DataGrid grdActivity1)
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
                if (resultCount > (grdActivity1.CurrentPageIndex + 1) * grdActivity1.PageSize)
                    maxResultItemInPage = (grdActivity1.CurrentPageIndex + 1) * grdActivity1.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdActivity1.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdActivity1.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdActivity1.Visible = true;
                grdActivity1.DataSource = tblInstallments;
                grdActivity1.DataBind();
            }
            else
            {
                grdActivity1.Visible = false;
            }
        }
        catch (Exception exp)
        {

            Response.Write(exp.Message.ToString());
        }
    }

    public void grdActivity_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdActivity.ShowFooter = false;
        grdActivity.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        this.DisplayReportGrid();
        DisplayHistoryGrid();
        DisplayEmployeeHoursGrid();
    }

    public void grdActivity_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdActivity.ShowFooter = true;
        grdActivity.EditItemIndex = -1;
        this.DisplayReportGrid();
        DisplayHistoryGrid();
        DisplayEmployeeHoursGrid();
    }

    public void grdActivity_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String activity_id = "";
        activity_id = grdActivity.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        _wRep.DeleteProjectActivity(activity_id);
        this.DisplayReportGrid();
        DisplayHistoryGrid();
        DisplayEmployeeHoursGrid();
    }

    public void grdActivity_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String activity_id = "";
        activity_id = grdActivity.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        _wRep.UpdateReportActivity(Convert.ToInt32(activity_id), Convert.ToString(((TextBox)(e.Item.FindControl("txtfabhours"))).Text), Convert.ToString(((TextBox)(e.Item.FindControl("txtfinhours"))).Text), Convert.ToString(((TextBox)(e.Item.FindControl("txtenghours"))).Text), Convert.ToString(((TextBox)(e.Item.FindControl("txtmischours"))).Text), (((TextBox)(e.Item.FindControl("txtNotes"))).Text).ToString());
        grdActivity.EditItemIndex = -1;
        grdActivity.ShowFooter = true;
        this.DisplayReportGrid();
        DisplayHistoryGrid();
        DisplayEmployeeHoursGrid();
    }


    public void grdEmployeeHours_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            SumEFabHours += Convert.ToDecimal(e.Item.Cells[1].Text);
            SumEfinHours += Convert.ToDecimal(e.Item.Cells[2].Text);
            SumEEngHours += Convert.ToDecimal(e.Item.Cells[3].Text);
            SumEMiscHours += Convert.ToDecimal(e.Item.Cells[4].Text);
            SumTotHours += Convert.ToDecimal(e.Item.Cells[5].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {

            e.Item.Cells[1].Text = SumEFabHours.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].Text = SumEfinHours.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[3].Text = SumEEngHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[4].Text = SumEMiscHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = SumTotHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
        }
    }


    public void grdActivity_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (chkActive.SelectedItem.Value == "Y")
        {
            e.Item.Cells[8].Visible = false;
            e.Item.Cells[9].Visible = false;
        }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            TotalFabHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblfabhours"))).Text);
            TotalfinHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblfinhours"))).Text);
            TotalEngHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblEnghours"))).Text);
            TotalMiscHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMiscHours"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {

            e.Item.Cells[3].Text = TotalEngHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[4].Text = TotalFabHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = TotalfinHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].Text = TotalMiscHours.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void grdHistoryRpt_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            SumFabHours += Convert.ToDecimal(e.Item.Cells[1].Text);
            SumfinHours += Convert.ToDecimal(e.Item.Cells[2].Text);
            SumEngHours += Convert.ToDecimal(e.Item.Cells[3].Text);
            SumMiscHours += Convert.ToDecimal(e.Item.Cells[4].Text);
            TotHours += Convert.ToDecimal(e.Item.Cells[5].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {

            e.Item.Cells[1].Text = SumFabHours.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].Text = SumfinHours.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[3].Text = SumEngHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[4].Text = SumMiscHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = TotHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    #endregion Daily Field Report Activity.

    protected void btnProd_Click(object sender, EventArgs e)
    {
        DisplayProductionSchedule();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
            txtReportDate.Text = "";
            txtRptIssues.Text = "";
            txtfabhours.Text = "";
            txtfinhours.Text = "";
            txtmischours.Text = "";
            txtenghours.Text = "";
            bindcontrols();
    }
    protected void btnWO_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            whitfield_prod_reports _wRep = new whitfield_prod_reports();
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = _wRep.ManageReportMain(txtReportDate.Text.Trim(),
                                           "",
                                           txtRptIssues.Text.Trim(),
                                           "",
                                           chkActive.SelectedItem.Value.Trim());

            if (IsInsertSuccess)
            {
                IsInsertSuccess = _wRep.ManageReportActivityMain(_wRep.GetReportNumber(txtReportDate.Text.Trim()),
                                                                           ddlEmpl.SelectedItem.Value,
                                                                           ddlProject.SelectedItem.Value,
                                                                           ddlworkorders.SelectedItem.Value,
                                                                           Convert.ToString(txtfabhours.Text.Trim()),
                                                                           Convert.ToString(txtfinhours.Text.Trim()),
                                                                           Convert.ToString(txtenghours.Text.Trim()),
                                                                           Convert.ToString(txtmischours.Text.Trim()),
                                                                           txtActComments.Text.Trim());
            }

           DisplayReportGrid();
           DisplayHistoryGrid();
           DisplayEmployeeHoursGrid();
          
        }
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {

        Response.Redirect("msir_render_pdf.aspx?reportDt=" + txtReportDate.Text.Trim());
    }

    public void sendEmail()
    {
        whitfield_prod_reports _wRep = new whitfield_prod_reports();
        MailMessage message = new MailMessage();

        message.To.Add(System.Configuration.ConfigurationManager.AppSettings["devEmail"]);


        //using (IDataReader reader = u.GetMSIRAdminRecords())  //HHS Uncomment this portion when there is an email list.
        //{
        //    while (reader.Read())
        //    {
        //        message.To.Add(reader["EMAIL_ADDRESS"].ToString());
        //    }
        //}

        message.To.Add(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString());
        //message.To.Add(System.Configuration.ConfigurationManager.AppSettings["PMEmail"].ToString());
        message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["DPR_fromEmail"]);
        message.Subject = "Daily Production report for " + txtReportDate.Text.Trim();
        message.IsBodyHtml = true;

        StringBuilder sb = new StringBuilder();
        sb.Append("<html><head></head>");
        sb.Append("<body>");
        //Header
        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD><IMG height='80' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/TWC%20Primary%20Logo1.JPG' border='0'></TD>");
        sb.Append("<TD class='form1' vAlign='bottom' align='right' width='100%'><b>The Whitfield Company, Inc.<br>");
        sb.Append("8836 Washington Blvd., Ste 101<br>");
        sb.Append("Jessup, MD 20794<br>");
		sb.Append("(301)-483-0791<br>");
		sb.Append("(301)-483-0792</b><br>");
        sb.Append("<IMG height='9' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/images.gif' width='1'>");
		sb.Append("</TD>");
        sb.Append("</TR></TABLE>");


        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD>");
        //sb.Append("<br><b>Following is the Daily Production report for " + txtReportDate.Text.Trim() + "</b>");
        //Significant Issues/Impediments Notes/Comments
        sb.Append("<br><b>Significant Issues/Impediments Notes/Comments:</b>" + txtRptIssues.Text.Trim() + "<br>");
        sb.Append("</TD>");
        sb.Append("</TR></TABLE>");
        
        //Activity
        DataGrid dg = new DataGrid();
        dg.Font.Size = 9;
        dg.CssClass = "data";
        System.Drawing.ColorConverter colConvert = new ColorConverter();

        dg.HeaderStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#60829F");
        dg.HeaderStyle.CssClass = "subnav";
        dg.HeaderStyle.Font.Bold = true;
        dg.ItemStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#EAEFF3");
        dg.ItemStyle.Font.Bold = true;
        dg.FooterStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#D9D9D9");

        dg.DataSource = _wRep.GetReportActivityForProjectForEmail(_wRep.GetReportNumber(txtReportDate.Text.Trim()));
        dg.DataBind();
        StringBuilder SBActivity = new StringBuilder();
        StringWriter SWActivity = new StringWriter(SBActivity);
        HtmlTextWriter htmlTWActivity = new HtmlTextWriter(SWActivity);
        dg.RenderControl(htmlTWActivity);
        string ActivityString = SBActivity.ToString();
        
        //EmployeeHours
        StringBuilder SBEmployeeHours = new StringBuilder();
        StringWriter SWEmployeeHours = new StringWriter(SBEmployeeHours);
        HtmlTextWriter htmlTWEmployeeHours = new HtmlTextWriter(SWEmployeeHours);
        grdEmployeeHours.RenderControl(htmlTWEmployeeHours);
        string EmployeeHoursString = SBEmployeeHours.ToString();
        sb.Append("<br><b>Employee Hours:</b><br>" + EmployeeHoursString + "<br><b>Employee Activity:</b><br>" + ActivityString);
        sb.Append("</body></html>");
        message.Body = sb.ToString();
        SmtpClient smtp = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp"]);
        smtp.Send(message);
    }


    protected void btnMail_Click(object sender, EventArgs e)
    {
        //Add Email Function here.
        sendEmail();

    }
}
