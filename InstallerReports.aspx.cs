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

public partial class InstallerReports : System.Web.UI.Page
{
    private Decimal TotalRptHours = 0;
    private Decimal TotalManHours = 0;
    private Decimal SumInstallHours1 = 0;
    private const Int16 _DEFAULTPAGESIZE = 10;
    Int32 EstNum;
    Int32 twc_project_number;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        whitfield_reports _wr = new whitfield_reports();
        // 1
        // Get collection
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            // See if any query string exists
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                string k1 = n.GetKey(1);
                string v1 = n.Get(1);

                //Check for QueryString Date

                if (k == "ReportDate")
                {
                    txtReportDate.Text = v;
                    twc_project_number = Convert.ToInt32(v1);
                    EstNum = Convert.ToInt32(Request.QueryString["EstNum"].ToString());
                    ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                    ViewState["twc_project_number"] = twc_project_number;
                    txtwhitPrjNumber.Text = twc_project_number.ToString();
                    //this.FetchAndBind(EstNum, twc_project_number);
                    bindcontrols(EstNum, twc_project_number);
                }
                else
                {
                    txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    twc_project_number = Convert.ToInt32(v1);
                    ViewState["EstNum"] = EstNum;
                    ViewState["twc_project_number"] = twc_project_number;
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    //this.FetchAndBind(EstNum, twc_project_number);
                    bindcontrols(EstNum, twc_project_number);
                }


                if (k == "EstNum")
                {
                    EstNum = Convert.ToInt32(v);  // Here goes the code for the creation of new EstNum
                    twc_project_number = Convert.ToInt32(v1);
                    ViewState["EstNum"] = EstNum;
                    ViewState["twc_project_number"] = twc_project_number;
                    //txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    //this.FetchAndBind(EstNum, twc_project_number);
                    bindcontrols(EstNum, twc_project_number);
                }

            }
            else
            {
                if (n.HasKeys())
                {
                    string k = n.GetKey(0);
                    string v = n.Get(0);

                    string k1 = n.GetKey(1);
                    string v1 = n.Get(1);

                    if (k == "EstNum")
                    {
                        EstNum = Convert.ToInt32(v);  // Here goes the code for the creation of new EstNum

                        twc_project_number = Convert.ToInt32(v1);
                        ViewState["EstNum"] = EstNum;
                        ViewState["twc_project_number"] = twc_project_number;
                        txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                        //this.FetchAndBind(EstNum, twc_project_number);
                        bindcontrols(EstNum, twc_project_number);
                    }
                }
                else
                {
                    EstNum = Convert.ToInt32(ViewState["EstNum"].ToString());
                    twc_project_number = Convert.ToInt32(ViewState["twc_project_number"].ToString());
                    //txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    //this.FetchAndBind(EstNum, twc_project_number);
                    bindcontrols(EstNum, twc_project_number);
                }
            }

            Response.Cookies["EstNum"].Value = EstNum.ToString();
            Response.Cookies["twc_project_number"].Value = twc_project_number.ToString();
            hdnEstNum.Value = EstNum.ToString();
            hdntwcProjNumber.Value = twc_project_number.ToString();


            //Logic Here for the Project Daily Field Report

            if (_wr.IsReportExists(twc_project_number, txtReportDate.Text))
            {
                DataSet _dsDailyRpt = _wr.GetReportForProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim());
                //txtReportDate.Text = _wr.GetCurrentDate();
                DataTable dtUsr = _dsDailyRpt.Tables[0];
                String _chkStatus = "";
                foreach (DataRow dRow in dtUsr.Rows)
                {
                    txtRptNotes.Text = dRow["Daily_notes"] == DBNull.Value ? "" : dRow["Daily_notes"].ToString();
                    txtRptIssues.Text = dRow["Daily_comments"] == DBNull.Value ? "" : dRow["Daily_comments"].ToString();
                    txtRptChangeOrderNotes.Text = dRow["Change_order_notes"] == DBNull.Value ? "" : dRow["Change_order_notes"].ToString();
                    _chkStatus = dRow["is_locked"] == DBNull.Value ? "" : dRow["is_locked"].ToString();
                    if (_chkStatus.Trim() == "Y")
                    {
                        chkActive.SelectedIndex = chkActive.Items.IndexOf(chkActive.Items.FindByValue(_chkStatus));
                    }
                }
            }
            //Logic for Project Daily Field Report Ends.
        }
        else
        {
            //pHprojClient.Visible = true;
            //pHprojcompe.Visible = true;
        }
    }

    public void bindcontrols(Int32 _estNum, Int32 twc_project_number)
    {
        BindWorkOrders();
        BindEmplyeeTypes();
        DisplayReportGrid();
        DisplayManPowerGrid();
        DisplayHistoryGrid();
    }

    protected void ddlworkorders_SelectedIndexChanged(object sender, EventArgs e)
    {
        whitfield_reports _wr = new whitfield_reports();
        DataSet dsNormal = new DataSet();
        DataSet dsBudget = new DataSet();

        dsNormal = _wr.GetBudgetHoursForWO(ViewState["EstNum"].ToString(), ddlworkorders.SelectedItem.Value);
        dsBudget = _wr.GetHoursTDForWO(ViewState["EstNum"].ToString(), ddlworkorders.SelectedItem.Value);

        DataSet dsCummTD = new DataSet();
        DataSet dsCummBudget = new DataSet();

        dsCummBudget = _wr.GetCummulativeBudgetHoursForWO(txtReportDate.Text.Trim());
        dsCummTD = _wr.GetCummulativeHoursTDForWO(txtReportDate.Text.Trim());


        lblinstbud.Text = "0";
        lblInstbudTD.Text = "0";
        lblInstdiffbud.Text = "0";


        lblCummHoursTD.Text = "0";
        lblCummBudgetHours.Text = "0";
        lblCummDiffTD.Text = "0";

        DataTable dtNormal = dsNormal.Tables[0];
        foreach (DataRow dRow in dtNormal.Rows)
        {
            lblinstbud.Text = dRow["install_hours"] == DBNull.Value ? "0" : dRow["install_hours"].ToString();
        }

        DataTable dtTD = dsBudget.Tables[0];
        foreach (DataRow dRow1 in dtTD.Rows)
        {
            lblInstbudTD.Text = dRow1["install_hours"] == DBNull.Value ? "0" : dRow1["install_hours"].ToString();
        }

        //cumulative Daily Hours
        DataTable dtCummBudget = dsCummBudget.Tables[0];
        foreach (DataRow dRow1 in dtCummBudget.Rows)
        {
            lblCummBudgetHours.Text = dRow1["install_hours"] == DBNull.Value ? "0" : dRow1["install_hours"].ToString();
        }
        //dumulative Daily Hours
        DataTable dtCummTD = dsCummTD.Tables[0];
        foreach (DataRow dRow2 in dtCummTD.Rows)
        {
            lblCummHoursTD.Text = dRow2["install_hours"] == DBNull.Value ? "0" : dRow2["install_hours"].ToString();
        }

        txtHours.Text = txtHours.Text.Trim() == "" ? "0" : txtHours.Text.Trim().ToString();

        lblInstdiffbud.Text = (Int32.Parse(lblinstbud.Text) - (Convert.ToInt32(txtHours.Text) + Convert.ToInt32(lblInstbudTD.Text))).ToString();
        lblCummDiffTD.Text = (Int32.Parse(lblCummBudgetHours.Text) - Convert.ToInt32(lblCummHoursTD.Text)).ToString();


    }


    private void BindEmplyeeTypes()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.FetchWorkersForInstaller(Request.Cookies["UserId"].Value);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlEmplType.DataSource = dsGrp;
            ddlEmplType.DataTextField = "worker_name";
            ddlEmplType.DataValueField = "worker_id";
            ddlEmplType.DataBind();
            ddlEmplType.Items.Insert(0, common.AddItemToList("Select Manpower", "0"));

        }
    }



    public void BindWorkOrders()
    {

        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();
        dsGrp = wUser.GetWorkOrders(ViewState["EstNum"].ToString(), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlworkorders.DataSource = dsGrp;
            ddlworkorders.DataTextField = "WODesc";
            ddlworkorders.DataValueField = "work_order_id";
            ddlworkorders.DataBind();
            ddlworkorders.Items.Insert(0, common.AddItemToList("Select WorkOrder", "0"));

        }
    }
    public DataSet FetchReportActivity()
    {
        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();
        dsGrp = wUser.GetWorkOrders(ViewState["EstNum"].ToString(), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        return dsGrp;
    }
    protected void btnactivity_Click(object sender, EventArgs e)
    {
        whitfield_reports _wc = new whitfield_reports();
        Boolean IsInsertSuccess = false;
        IsInsertSuccess = _wc.ManageReportMain(txtReportDate.Text.Trim(),
                                       Convert.ToInt32(ViewState["twc_project_number"].ToString()),
                                       txtRptNotes.Text.Trim(),
                                       txtRptIssues.Text.Trim(),
                                       txtRptChangeOrderNotes.Text.Trim(),
                                       chkActive.SelectedItem.Value.Trim(), Request.Cookies["UserId"].Value);
        if (IsInsertSuccess)
        {
            if (ddlworkorders.SelectedItem.Value != "0")
            {
                IsInsertSuccess = _wc.ManageReportActivityMain(_wc.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()), ViewState["twc_project_number"].ToString(),
                                                                                    ddlworkorders.SelectedItem.Value,
                                                                                    txtHours.Text.Trim(),
                                                                                    txtActComments.Text.Trim(), Request.Cookies["UserId"].Value);
            }

            if (ddlEmplType.SelectedItem.Value != "0")
            {
                Boolean isManPowerInsert = _wc.ManageManpower(_wc.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()),
                                                                Convert.ToInt32(ddlEmplType.SelectedItem.Value),
                                                                txtManHours.Text.Trim(),
                                                                0);
            }
        }

        DisplayReportGrid();
        DisplayManPowerGrid();
        DisplayHistoryGrid();
    }
    protected void btnmpdetails_Click(object sender, EventArgs e)
    {
        whitfield_reports _wc = new whitfield_reports();
        Boolean IsInsertSuccess = false;
        IsInsertSuccess = _wc.ManageManpower(_wc.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()),
                                                                   Convert.ToInt32(ddlEmplType.SelectedItem.Value),
                                                                   txtManHours.Text.Trim(),
                                                                   0);
        DisplayReportGrid();
        DisplayManPowerGrid();
        DisplayHistoryGrid();
    }

    public string showHistoryReport(object ReportDate)
    {
        return "<a ID='ViewNotes' href=\"javascript:showHistoryReport('" + ReportDate.ToString().Trim() + "');\"" + ">" + ReportDate.ToString().Trim() + "</a>";
    }
    private void DisplayHistoryGrid()
    {

        whitfield_reports _wRep = new whitfield_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetFieldDailyReports(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        this.PopulateDataGrid(_dsRep, grdHistoryRpt);
    }

    #region Daily Field Report Activity Grid
    private void DisplayReportGrid()
    {

        whitfield_reports _wRep = new whitfield_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetReportActivityForProject(_wRep.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        this.PopulateRepDataGrid(_dsRep);
    }

    public void PopulateRepDataGrid(DataSet dsGridResults)
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
                if (resultCount > (grdActivity.CurrentPageIndex + 1) * grdActivity.PageSize)
                    maxResultItemInPage = (grdActivity.CurrentPageIndex + 1) * grdActivity.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdActivity.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdActivity.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdActivity.Visible = true;
                grdActivity.DataSource = tblInstallments;
                grdActivity.DataBind();
            }
            else
            {
                grdActivity.Visible = false;
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
    }

    public void grdActivity_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdActivity.ShowFooter = true;
        grdActivity.EditItemIndex = -1;
        this.DisplayReportGrid();
    }

    public void grdActivity_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String activity_id = "";
        activity_id = grdActivity.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_reports _wRep = new whitfield_reports();
        _wRep.DeleteProjectActivity(activity_id);
        this.DisplayReportGrid();
        DisplayHistoryGrid();
    }

    public void grdActivity_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String activity_id = "";
        activity_id = grdActivity.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_reports _wRep = new whitfield_reports();
        _wRep.UpdateReportActivity(Convert.ToInt32(activity_id), ((TextBox)(e.Item.FindControl("txtinstallhours"))).Text, (((TextBox)(e.Item.FindControl("txtNotes"))).Text).ToString());
        grdActivity.EditItemIndex = -1;
        grdActivity.ShowFooter = true;
        this.DisplayReportGrid();
        DisplayHistoryGrid();
    }

    public void grdActivity_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalRptHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblinstallhours"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = TotalRptHours.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        }
    }
    #endregion Daily Field Report Activity.

 
    private void DisplayManPowerGrid()
    {

        whitfield_reports _wRep = new whitfield_reports();
        DataSet _dsRep = new DataSet();
        _dsRep = _wRep.GetManPowerEntries(_wRep.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()));
        this.PopulateManPowerDataGrid(_dsRep);
    }

    public void PopulateManPowerDataGrid(DataSet dsGridResults)
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
                if (resultCount > (grdManPower.CurrentPageIndex + 1) * grdManPower.PageSize)
                    maxResultItemInPage = (grdManPower.CurrentPageIndex + 1) * grdManPower.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdActivity.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdActivity.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdManPower.Visible = true;
                grdManPower.DataSource = tblInstallments;
                grdManPower.DataBind();
            }
            else
            {
                grdManPower.Visible = false;
            }
        }
        catch (Exception exp)
        {

            Response.Write(exp.Message.ToString());
        }
    }

    public void grdManPower_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdManPower.ShowFooter = false;
        grdManPower.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        this.DisplayManPowerGrid();
    }

    public void grdManPower_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdManPower.ShowFooter = true;
        grdManPower.EditItemIndex = -1;
        this.DisplayManPowerGrid();
    }

    public void grdManPower_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String ManPower_id = "";
        ManPower_id = grdManPower.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_reports _wRep = new whitfield_reports();
        _wRep.DeleteManPowerEntries(ManPower_id);
        this.DisplayManPowerGrid();
    }

    public void grdManPower_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String ManPower_id = "";
        ManPower_id = grdManPower.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfield_reports _wRep = new whitfield_reports();
        _wRep.UpdateManPowerActivity(Convert.ToInt32(ManPower_id), ((TextBox)(e.Item.FindControl("txtinstallhours"))).Text, 0);
        grdManPower.EditItemIndex = -1;
        grdManPower.ShowFooter = true;
        this.DisplayManPowerGrid();
    }

    public void grdManPower_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalManHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotHours"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = TotalManHours.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void grdHistoryRpt_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            SumInstallHours1 += Convert.ToDecimal(e.Item.Cells[1].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {

            e.Item.Cells[1].Text = SumInstallHours1.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Left;
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
                //txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " contacts(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                //txtSelectionResultsMSG.Text = "No Contacts Setup yet.";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    protected void btnMail_Click(object sender, EventArgs e)
    {
        sendEmail();
    }
    public void sendEmail()
    {
        Whitfieldcore wCore = new Whitfieldcore();
        whitfield_reports _wRep = new whitfield_reports();
        MailMessage message = new MailMessage();

       // message.To.Add(System.Configuration.ConfigurationManager.AppSettings["devEmail"]);

        //Here is where we add the receipients.
        using (DataSet ds = wCore.GetRightDistributionList(Convert.ToInt32(ViewState["twc_project_number"].ToString())))  //HHS Uncomment this portion when there is an email list.
        {
            DataTable dtUsr = ds.Tables[0];
            if (dtUsr.Rows.Count > 0)
            {
                foreach (DataRow dRow in dtUsr.Rows)
                {
                    string _email = dRow["Email"] == DBNull.Value ? "" : dRow["Email"].ToString();
                    message.To.Add(_email);
                }
            }
        }

        message.To.Add(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString());
        //This is commented by Harish on Friday, January 27th with the request of Jammie.
        //message.To.Add(System.Configuration.ConfigurationManager.AppSettings["PMEmail"].ToString());

        message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["DFR_fromEmail"]);
        message.Subject = txtReportDate.Text.Trim() + "  Daily Field Report:" + lblPrjHeader.Text.Trim();
        message.IsBodyHtml = true;

        StringBuilder sb = new StringBuilder();
        sb.Append("<html><head></head>");
        sb.Append("<body>");
        //Header
        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD><IMG height='80' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/TWC%20Primary%20Logo1.JPG' border='0'></TD>");
        sb.Append("<TD class='form1' vAlign='bottom' align='right' width='100%'><b>The Whitfield Corporation, Inc.,<br>");
        sb.Append("P.O. Box 0385<br>");
        sb.Append("Fulton, MD 20759<br>");
        sb.Append("(301)-483-0791<br>");
        sb.Append("(301)-483-0792</b><br>");
        sb.Append("<IMG height='9' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/images.gif' width='1'>");
        sb.Append("</TD>");
        sb.Append("</TR></TABLE>");

        //EmployeeHours
        System.Drawing.ColorConverter colConvert = new ColorConverter();
        DataGrid dgWorkOrders = new DataGrid();
        dgWorkOrders.Font.Size = 9;
        dgWorkOrders.CssClass = "data";

        dgWorkOrders.HeaderStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#60829F");
        dgWorkOrders.HeaderStyle.CssClass = "subnav";
        dgWorkOrders.HeaderStyle.Font.Bold = true;
        dgWorkOrders.ItemStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#EAEFF3");
        dgWorkOrders.FooterStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#D9D9D9");

        dgWorkOrders.DataSource = _wRep.GetReportActivityForProjectMail(_wRep.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        dgWorkOrders.DataBind();

        StringBuilder SBEmployeeHours = new StringBuilder();
        StringWriter SWEmployeeHours = new StringWriter(SBEmployeeHours);
        HtmlTextWriter htmlTWEmployeeHours = new HtmlTextWriter(SWEmployeeHours);
        dgWorkOrders.RenderControl(htmlTWEmployeeHours);
        string EmployeeHoursString = SBEmployeeHours.ToString();
        sb.Append("<br><B>Work Executed for Today:</b><br>" + EmployeeHoursString);


        //Daily Work Performed Notes/Comments
        String StrRptNotes = "";

        if (txtRptNotes.Text == "")
        {
            StrRptNotes = "None.";
        }
        else
        {
            StrRptNotes = txtRptNotes.Text.Trim();
        }
        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD>");
        sb.Append("<br><b>Daily Work Performed Notes/Comments:</b>" + StrRptNotes + "<br>");
        sb.Append("</TD>");
        sb.Append("</TR></TABLE>");



        //Significant Issues/Impediments Notes/Comments:
        String StrRptIssues = "";

        if (txtRptIssues.Text == "")
        {
            StrRptIssues = "None.";
        }
        else
        {
            StrRptIssues = txtRptIssues.Text.Trim();
        }

        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD>");
        sb.Append("<br><b>Significant Issues/Impediments Notes/Comments:</b>" + StrRptIssues + "<br>");
        sb.Append("</TD>");
        sb.Append("</TR></TABLE>");

        //Change Order Work Notes/Comments

        String StrRptChangeOrderNotes = "";
        if (txtRptChangeOrderNotes.Text == "")
        {
            StrRptChangeOrderNotes = "None.";
        }
        else
        {
            StrRptChangeOrderNotes = txtRptChangeOrderNotes.Text.Trim();
        }

        sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
        sb.Append("<TD>");
        sb.Append("<br><b>Change Order Work Notes/Comments:</b>" + StrRptChangeOrderNotes + "<br>");
        sb.Append("</TD>");
        sb.Append("</TR></TABLE>");

        //Man Power Detail
        DataGrid dg = new DataGrid();
        dg.Font.Size = 9;
        dg.CssClass = "data";


        dg.HeaderStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#60829F");
        dg.HeaderStyle.CssClass = "subnav";
        dg.HeaderStyle.Font.Bold = true;
        dg.ItemStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#EAEFF3");
        dg.FooterStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#D9D9D9");

        dg.DataSource = _wRep.GetManPowerEntriesMail(_wRep.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()));
        dg.DataBind();
        StringBuilder SBActivity = new StringBuilder();
        StringWriter SWActivity = new StringWriter(SBActivity);
        HtmlTextWriter htmlTWActivity = new HtmlTextWriter(SWActivity);
        dg.RenderControl(htmlTWActivity);
        string ActivityString = SBActivity.ToString();

        ////EmployeeHours
        //DataGrid dgWorkOrders = new DataGrid();
        //dgWorkOrders.Font.Size = 9;
        //dgWorkOrders.CssClass = "data";

        //dgWorkOrders.HeaderStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#60829F");
        //dgWorkOrders.HeaderStyle.CssClass = "subnav";
        //dgWorkOrders.HeaderStyle.Font.Bold = true;
        //dgWorkOrders.ItemStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#EAEFF3");
        //dgWorkOrders.FooterStyle.BackColor = (System.Drawing.Color)colConvert.ConvertFromString("#D9D9D9");

        //dgWorkOrders.DataSource = _wRep.GetReportActivityForProjectMail(_wRep.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        //dgWorkOrders.DataBind();

        //StringBuilder SBEmployeeHours = new StringBuilder();
        //StringWriter SWEmployeeHours = new StringWriter(SBEmployeeHours);
        //HtmlTextWriter htmlTWEmployeeHours = new HtmlTextWriter(SWEmployeeHours);
        //dgWorkOrders.RenderControl(htmlTWEmployeeHours);
        //string EmployeeHoursString = SBEmployeeHours.ToString();



        sb.Append("<br><b>Man Power Detail:</b><br>" + ActivityString);
        sb.Append("</body></html>");
        message.Body = sb.ToString();
        SmtpClient smtp = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp"]);
        smtp.Send(message);
    }
}
