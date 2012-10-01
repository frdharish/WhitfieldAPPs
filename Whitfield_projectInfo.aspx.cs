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
using System.Net;
using System.Text;
using System.Net.Mail;
using System.IO;

public partial class Whitfield_projectInfo : System.Web.UI.Page
{
    private Decimal TotalFabHours = 0;
    private Decimal TotalfinHours = 0;
    private Decimal TotalInstallHours = 0;
    private Decimal TotalEngHours = 0;
    private Decimal TotalMiscHours = 0;
    private Decimal TotalMatCost = 0;
    private Decimal TotalRptHours = 0;
    private Decimal TotalManHours = 0;
    private Decimal SumInstallHours1 = 0;
    private const Int16 _DEFAULTPAGESIZE = 100;
    public String Construction_Start_Date = "";
    public String Construction_End_Date = "";
    Int32 EstNum;
    Int32 twc_project_number;
    Int32 ActiveIndexNumber = 0;
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

                if (Request.QueryString["hFlag"] == "D")
                {
                    _wc.DeleteProjDocument(Convert.ToInt32(Request.QueryString["EstNum"]), Convert.ToInt32(Request.QueryString["seqno"]), Convert.ToInt32(Request.QueryString["twcProjNumber"]));
                    ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                    ViewState["twc_project_number"] = Request.QueryString["twcProjNumber"].ToString();
                    twc_project_number = Convert.ToInt32(Request.QueryString["twcProjNumber"].ToString());
                    DataSet dsGridResults = this.GetDocs();
                    this.PopulateDataGrid(dsGridResults, grddocs);
                }

                //Check for QueryString Date
                if (k == "ReportDate")
                {
                    txtReportDate.Text = v;
                    twc_project_number = Convert.ToInt32(v1);
                    EstNum = Convert.ToInt32(Request.QueryString["EstNum"].ToString()); 
                    ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                    ViewState["twc_project_number"] = twc_project_number;
                    txtwhitPrjNumber.Text = twc_project_number.ToString() ;
                    txtrealPrjNumber.Text = _wc.GetReal_proj_Number(twc_project_number).ToString();
                    this.FetchAndBind(EstNum, twc_project_number);
                    ActiveIndexNumber = 4;
                }
                else
                {
                    txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    twc_project_number = Convert.ToInt32(v1);
                    ViewState["EstNum"] = EstNum;
                    ViewState["twc_project_number"] = twc_project_number;
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    txtrealPrjNumber.Text = _wc.GetReal_proj_Number(Convert.ToInt32(ViewState["twc_project_number"].ToString())).ToString();
                    this.FetchAndBind(EstNum, twc_project_number);
                }


                if (k == "EstNum")
                {
                    EstNum = Convert.ToInt32(v);  // Here goes the code for the creation of new EstNum
                    twc_project_number = Convert.ToInt32(v1); 
                    ViewState["EstNum"] = EstNum;
                    ViewState["twc_project_number"] = twc_project_number;
                    //txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    txtrealPrjNumber.Text = _wc.GetReal_proj_Number(Convert.ToInt32(ViewState["twc_project_number"].ToString())).ToString();
                    this.FetchAndBind(EstNum, twc_project_number);
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
                        //txtReportDate.Text = _wr.GetCurrentDate().Trim();
                        txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                        txtrealPrjNumber.Text = _wc.GetReal_proj_Number(Convert.ToInt32(ViewState["twc_project_number"].ToString())).ToString();
                        this.FetchAndBind(EstNum, twc_project_number);
                    }
                }
                else
                {
                    EstNum = Convert.ToInt32(ViewState["EstNum"].ToString());
                    twc_project_number = Convert.ToInt32(ViewState["twc_project_number"].ToString());
                    //txtReportDate.Text = _wr.GetCurrentDate().Trim();
                    txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
                    txtrealPrjNumber.Text = _wc.GetReal_proj_Number(Convert.ToInt32(ViewState["twc_project_number"].ToString())).ToString();
                    this.FetchAndBind(EstNum, twc_project_number);
                }
            }

            Response.Cookies["EstNum"].Value = EstNum.ToString();
            Response.Cookies["twc_project_number"].Value = twc_project_number.ToString();
            hdnEstNum.Value = EstNum.ToString();
            hdntwcProjNumber.Value = twc_project_number.ToString();
            

            //Bind the clients and competition and Conversation Log
            try
            {
                grdclients.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.Project_clients();
                this.PopulateDataGrid(dsGridResults, grdclients);
            }

            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }

         

            //GetDocumentsforProject
            try
            {
                grddocs.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.GetDocs();
                this.PopulateDataGrid(dsGridResults, grddocs);
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }
                
           //Logic Here for the Project Daily Field Report


           // if (_wr.IsReportExists(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text))

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
             Whitfieldcore _wc1 = new Whitfieldcore();
             lblTotAnnFabHours.Text = _wc1.GetTotalFabricationHours(twc_project_number.ToString());
             lblTotScheduledHours.Text = _wc1.GetTotalscheduledHours(twc_project_number);
            //GetTotalFabricationHours
        }
        else
        {
            //pHprojClient.Visible = true;
            //pHprojcompe.Visible = true;
        }

        tabgeneral.ActiveTabIndex = ActiveIndexNumber;

    }
    #region UI Methods
    public string ShowContactEditImage(object url, object id)
    {
        return "<a ID='ViewNotes' href=\"javascript:popupprocess('" + url.ToString().Trim() + "','" + id.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    public string ShowviewImage(object EstNum, object seqnumber)
    {
        return "<a ID='ViewNotes' href=\"javascript:showdocument('" + EstNum.ToString().Trim() + "','" + seqnumber.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/sort_down.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }

    public string Showdocument(object EstNum, object seqnumber, object docname)
    {
        return "<a ID='ViewNotes' href=\"javascript:showdocument('" + EstNum.ToString().Trim() + "','" + seqnumber.ToString().Trim() + "');\"" + ">" + docname.ToString().Trim() + "</a>";
    }

    public string DeleteDocument(object EstNum, object seqnumber)
    {

        return "<a ID='DeleteDocs' href=\"javascript:Deletedocument('" + EstNum.ToString().Trim() + "','" + seqnumber.ToString().Trim() + "');\"" + ">Delete</a>";
    }
    public string showHistoryReport(object ReportDate)
    {
        return "<a ID='ViewNotes' href=\"javascript:showHistoryReport('" + ReportDate.ToString().Trim() + "');\"" + ">" + ReportDate.ToString().Trim() + "</a>";
    }
    #endregion

    public void bindcontrols(Int32 _estNum,Int32 twc_project_number)
    {
        
        BindProjectType();
        BindArch();
        BindWinClientinfo(_estNum,twc_project_number);
        BindInstallers();
        DisplayGrid();
        BindDocumentTypes();
        BindWorkOrders();
        BindEmplyeeTypes();
        DisplayReportGrid();
        DisplayManPowerGrid();
        DisplayHistoryGrid();
        DisplaySchedulingGrid();
        DisplayHistoryNotes();
        BindProjectStatus();
        BindYears();
        BindMonths();
        BindWeeks();
        string strMonth = DateTime.Now.ToString("MMMM");
        string strYear = DateTime.Now.ToString("yyyy");
        ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(strMonth.ToString()));
        ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByValue(strYear.ToString()));
    }

    public void FetchAndBind(Int32 _estNum, Int32 twc_project_number)
    {

        DataSet dsInstallers;
        Whitfield_Project _wc = new Whitfield_Project();
        whitfield_reports _wr = new whitfield_reports();
        bindcontrols(_estNum,twc_project_number);
        IDataReader iReader = _wc.GetProjectInfo(_estNum, twc_project_number);
        // ' Loop through the DataReader and write out each entry        
        while (iReader.Read())
        {
            txttwcPrjNumber.Text = twc_project_number.ToString().Trim(); 
            txtrealPrjNumber.Text = iReader["Real_proj_Number"] == DBNull.Value ? "" : iReader["Real_proj_Number"].ToString();
            txtClientPrjNumber.Text = iReader["client_proj_number"] == DBNull.Value ? "" : iReader["client_proj_number"].ToString();
            txtContractNumber.Text = iReader["contract_number"] == DBNull.Value ? "" : iReader["contract_number"].ToString();
            txtprjname.Text = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
            lblPrjHeader.Text = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
              txtfinalbid.Text = iReader["FinalPrice"] == DBNull.Value ? "" : iReader["FinalPrice"].ToString();
            txtdesc.Text = iReader["ProjDescr"] == DBNull.Value ? "" : iReader["ProjDescr"].ToString();
            txtNotes.Text = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
            txtConstStdate.Text = iReader["ConstrStart"] == DBNull.Value ? "" : iReader["ConstrStart"].ToString();
            txtConstDuration.Text = iReader["ConstrDur"] == DBNull.Value ? "" : iReader["ConstrDur"].ToString();
            txtConstEndDate.Text = iReader["ConstrCompl"] == DBNull.Value ? "" : iReader["ConstrCompl"].ToString();
            txtOverheadCost.Text = iReader["OverheadCost"] == DBNull.Value ? "" : iReader["OverheadCost"].ToString();
            txtMatContCost.Text = iReader["MatContCost"] == DBNull.Value ? "" : iReader["MatContCost"].ToString();

            //txtCurrentContract.Text = iReader["C_Contract_Value"] == DBNull.Value ? "" : iReader["C_Contract_Value"].ToString();
            txtOrigContract.Text = iReader["O_Contract_Value"] == DBNull.Value ? "0" : iReader["O_Contract_Value"].ToString();
            txtChangeOrder.Text = iReader["Change_Order_Value"] == DBNull.Value ? "0" : iReader["Change_Order_Value"].ToString();
            lblCurrentContract.Text = (Convert.ToDecimal(txtOrigContract.Text) + Convert.ToDecimal(txtChangeOrder.Text)).ToString();
            
            //Construction_Start_Date = iReader["ConstrStart"] == DBNull.Value ? "" : iReader["ConstrStart"].ToString();
            //Construction_End_Date = iReader["ConstrCompl"] == DBNull.Value ? "" : iReader["ConstrCompl"].ToString();
            ViewState["Construction_Start_Date"] = iReader["ConstrStart"] == DBNull.Value ? "" : iReader["ConstrStart"].ToString();
            ViewState["Construction_End_Date"] = iReader["ConstrCompl"] == DBNull.Value ? "" : iReader["ConstrCompl"].ToString();

            String wincompe = iReader["WinMill"] == DBNull.Value ? "" : iReader["WinMill"].ToString();
            

            String winclient = iReader["WinClient"] == DBNull.Value ? "" : iReader["WinClient"].ToString();
            String prjType = iReader["ProjType"] == DBNull.Value ? "" : iReader["ProjType"].ToString(); ;
            String prjArch = iReader["Architect"] == DBNull.Value ? "" : iReader["Architect"].ToString();
            String Status = iReader["Status"] == DBNull.Value ? "" : iReader["Status"].ToString();
            
            ddlwonclient.SelectedIndex = ddlwonclient.Items.IndexOf(ddlwonclient.Items.FindByValue(winclient.ToString()));
            ddlprjtype.SelectedIndex = ddlprjtype.Items.IndexOf(ddlprjtype.Items.FindByValue(prjType.ToString()));
            ddlarchitect.SelectedIndex = ddlarchitect.Items.IndexOf(ddlarchitect.Items.FindByValue(prjArch.ToString()));
            ddlPrjStatus.SelectedIndex = ddlPrjStatus.Items.IndexOf(ddlPrjStatus.Items.FindByValue(Status.ToString()));
                
             dsInstallers = _wc.SelectInstallers(twc_project_number);
            if (dsInstallers.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in dsInstallers.Tables[0].Rows)
                { 
                    String _cntlVal = dRow["Userid"].ToString();
                    ListItem currentCheckBox = chkInstallers.Items.FindByValue(_cntlVal.ToString().Trim());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
                    }
                }
            }
            
        }
    }

    #region Bind Drop downs
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

        lblInstdiffbud.Text = (Convert.ToDecimal(lblinstbud.Text) - (Convert.ToDecimal(txtHours.Text) + Convert.ToDecimal(lblInstbudTD.Text))).ToString();
        lblCummDiffTD.Text = (Convert.ToDecimal(lblCummBudgetHours.Text) - Convert.ToDecimal(lblCummHoursTD.Text)).ToString();
   

    }

    private void BindProjectStatus()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetProjectStatusWithFilter();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlPrjStatus.DataSource = dsGrp;
            ddlPrjStatus.DataTextField = "StatType";
            ddlPrjStatus.DataValueField = "StatID";
            ddlPrjStatus.DataBind();
            //ddlPrjStatus.Items.Insert(0, common.AddItemToList("Select Status", "0"));
        }
    }

    private void BindInstallers()
    {
        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();        
        dsGrp = wUser.GetInstallers();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            chkInstallers.DataSource = dsGrp;
            chkInstallers.DataTextField = "InstallerName";
            chkInstallers.DataValueField = "UserId";
            chkInstallers.DataBind();
        }
    }

    private void BindEmplyeeTypes()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();

        if (Request.Cookies["RoleId"].Value == "5")
            dsGrp = wUser.FetchWorkersForInstaller(Request.Cookies["UserId"].Value);
        else
            dsGrp = wUser.FetchAllWorkers();

        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlEmplType.DataSource = dsGrp;
            ddlEmplType.DataTextField = "worker_name";
            ddlEmplType.DataValueField = "worker_id";
            ddlEmplType.DataBind();
            ddlEmplType.Items.Insert(0, common.AddItemToList("Select Manpower", "0"));

        }
    }

    private void BindProjectType()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetProjectTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlprjtype.DataSource = dsGrp;
            ddlprjtype.DataTextField = "ProjType";
            ddlprjtype.DataValueField = "ProjTypeID";
            ddlprjtype.DataBind();
            ddlprjtype.Items.Insert(0, common.AddItemToList("Select Project type", "0"));

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
    private void BindArch()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetArchitects();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {
            ddlarchitect.DataSource = dsGrp;
            ddlarchitect.DataTextField = "Architect";
            ddlarchitect.DataValueField = "ArchID";
            ddlarchitect.DataBind();
            ddlarchitect.Items.Insert(0, common.AddItemToList("Select Architect", "0"));
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
        //ddlYear.Items.Insert(0, common.AddItemToList("Select Year", "0"));
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
        //ddlMonth.Items.Insert(0, common.AddItemToList("Select Month", "0"));
    }

    private void BindWeeks()
    {
            DataSet dsGrp = new DataSet();
            Whitfieldcore wUser = new Whitfieldcore();
            DataSet ds = wUser.GetWeeks();
            ddlWeek.DataSource = ds;
            //[week_number],[week_name]week_name
            ddlWeek.DataTextField = "week_name";
            ddlWeek.DataValueField = "week_name";
            ddlWeek.DataBind();
            ddlWeek.Items.Insert(0, common.AddItemToList("Select Week", "0"));
    }

    private void BindWinClientinfo(Int32 EstNum,Int32 twc_project_number)
    {
        DataSet dsGrp = new DataSet();
        Whitfield_Project wUser = new Whitfield_Project();        
        dsGrp = wUser.GetClientlistForProject(EstNum.ToString(),twc_project_number);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlwonclient.DataSource = dsGrp;
            ddlwonclient.DataTextField = "Name1";
            ddlwonclient.DataValueField = "ClientID";
            ddlwonclient.DataBind();
            //ddlwonclient.Items.Insert(0, common.AddItemToList("Select", "0"));

        }
        else
        {
            ddlwonclient.Items.Insert(0, common.AddItemToList("No Clients Yet", "0"));
        }
    }



    private void BindDocumentTypes()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllDocTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlDocType.DataSource = dsGrp;
            ddlDocType.DataTextField = "doc_Type_Desc";
            ddlDocType.DataValueField = "doc_type_id";
            ddlDocType.DataBind();
        }
    }

    #endregion Bind Dropdowns
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfield_Project _wc = new Whitfield_Project();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = _wc.InsertEstimateMain(
                ViewState["EstNum"].ToString(), 
                ViewState["twc_project_number"].ToString(),
                txtprjname.Text.Trim(),
                txtdesc.Text.Trim(),
                txtNotes.Text.Trim(),
                ddlprjtype.SelectedItem.Value,
                txtConstStdate.Text.Trim(),
                txtConstEndDate.Text.Trim(),
                txtConstDuration.Text.Trim(),
                "0",
                ddlPrjStatus.SelectedItem.Value,
                "0",
                ddlwonclient.SelectedItem.Value,
                txtfinalbid.Text.Trim(),
                "N",
                ddlarchitect.SelectedItem.Value,
                "Y",
                "Y"
                ,txtClientPrjNumber.Text.Trim()
                ,txtContractNumber.Text.Trim(),txtMatContCost.Text.Trim(),txtOverheadCost.Text.Trim());

            InsertInstallers();
            lblMsg.Text = "Your record is added successfully.";
        }
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
                        IsInsertSuccess = _wc.ManageReportActivityMain(_wc.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()),ViewState["twc_project_number"].ToString(),
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
    protected void btnwodetails_Click(object sender, EventArgs e)
    {
        whitfield_reports _wc = new whitfield_reports();
        Boolean IsInsertSuccess = false;
        IsInsertSuccess = _wc.ManageReportActivityMain(_wc.GetReportNumber(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()),ViewState["twc_project_number"].ToString(),
                                                                                        ddlworkorders.SelectedItem.Value,
                                                                                        txtHours.Text.Trim(),
                                                                                        txtActComments.Text.Trim(), Request.Cookies["UserId"].Value);
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
    #region Project Documents

    private DataSet GetDocs()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfield_Project _wc = new Whitfield_Project();
            dsRpAdvances = _wc.GetDocumentsforProject(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean isInsert = false;
            isInsert = this.InsertDocument(Convert.ToInt32(ViewState["twc_project_number"].ToString()), Convert.ToInt32(ViewState["EstNum"].ToString()), ddlDocType.SelectedItem.Value, Request.Cookies["UserId"].Value.Trim(), FileUpload1.PostedFile.ContentType.Trim(), FileUpload1.PostedFile.ContentLength.ToString());
             
            DataSet dsGridResults = this.GetDocs();
            this.PopulateDataGrid(dsGridResults, grddocs);
            if (isInsert)
                lblMsg.Text = "Your document is added successfully.";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        whitfield_reports _wRep = new whitfield_reports();
        if (_wRep.IsReportExists(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim()))
        {
            DataSet _dsDailyRpt = _wRep.GetReportForProject(Convert.ToInt32(ViewState["twc_project_number"].ToString()), txtReportDate.Text.Trim());
            txtwhitPrjNumber.Text = ViewState["twc_project_number"].ToString();
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
            DisplayReportGrid();
            DisplayManPowerGrid();
            DisplayHistoryGrid();
        }
        else
        {
            txtRptNotes.Text = "";
            txtRptIssues.Text = "";
            txtRptChangeOrderNotes.Text = "";
            txtManHours.Text = "";
            //txtQty.Text = "";            
            DisplayReportGrid();
            DisplayManPowerGrid();
            DisplayHistoryGrid();
        }
    }

    public Boolean InsertDocument(Int32 twc_project_Number,Int32 EstNum, String doc_type_id, String _userid, String doc_mime_type, String docsize)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        try
        {
            byte[] imageSize = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = FileUpload1.PostedFile;
            uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO whitfield_Project_documents(TWC_proj_number,EstNum,seq_num,doc_type_id,doc_mime_type,document,docsize,doc_name, LastModifiedBy,LastModifiedDate) Values (@twc_project_Number,@EstNum, @seq_num, @doc_type_id, @doc_mime_type,@document,@docsize,@docname, @userid,getdate())  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_Number", DbType.Int32, twc_project_Number);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seq_num", DbType.Int32, _wc.GenerateseqNumberforDocs(EstNum));
            db.AddInParameter(dbCommand, "@doc_type_id", DbType.Int32, Convert.ToInt32(doc_type_id));
            db.AddInParameter(dbCommand, "@document", DbType.Binary, imageSize);
            db.AddInParameter(dbCommand, "@doc_mime_type", DbType.String, doc_mime_type);
            db.AddInParameter(dbCommand, "@docsize", DbType.String, docsize.ToString());
            db.AddInParameter(dbCommand, "@docname", DbType.String, System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName));
            db.AddInParameter(dbCommand, "@userid", DbType.String, _userid);
            db.ExecuteNonQuery(dbCommand);
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }
    public Boolean InsertInstallers()
    {
        try
        {
            Whitfield_Project _wc = new Whitfield_Project();
            _wc.DeleteInstallers(Convert.ToInt32(ViewState["twc_project_number"].ToString()));
            //ArrayList chkArray = GetSelectedItems(ChkProjContacts
            for (int i = 0; i < chkInstallers.Items.Count; i++)
            {

                if (chkInstallers.Items[i].Selected)
                    _wc.PopulateProject_Installers(Convert.ToInt32(ViewState["twc_project_number"].ToString()), Convert.ToInt32(chkInstallers.Items[i].Value));
            }
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }
    #endregion 
    #region Datagrid common Functions

    public void PageResultGridHistory(object sender, DataGridPageChangedEventArgs e)
    {

        //DataSet dsGridResults;
        grdHistoryRpt.CurrentPageIndex = e.NewPageIndex;
        //dsGridResults = this.Project_clients();
        DisplayHistoryGrid();

    }

    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdclients.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.Project_clients();
        PopulateDataGrid(dsGridResults, grdclients);

    }

    public void PageResultGrid2(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        //grdcompe.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.Project_competition();
        //PopulateDataGrid(dsGridResults, grdcompe);
    }
    public void PageResultGridNotes(object sender, DataGridPageChangedEventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        DataSet dsGridResults;
        grdWeeklyNotes.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = wc.GetNotes(Convert.ToInt32(twc_project_number));
        this.PopulateDataGrid(dsGridResults, grdWeeklyNotes);
    }


    public void PageResultGriddocs(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        //grdcompe.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.GetDocs();
        PopulateDataGrid(dsGridResults, grddocs);
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
    #endregion Data Grid Function Ends


    private DataSet Project_clients()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfield_Project _wc = new Whitfield_Project();
            dsRpAdvances = _wc.GetContactsForProject(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twc_project_number"].ToString()),Convert.ToInt32(ddlwonclient.SelectedItem.Value));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }

    private DataSet Project_competition()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfield_Project _wc = new Whitfield_Project();
            dsRpAdvances = _wc.GetCompetitonForProject(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }


    #region Work Order Functions
    private void DisplayGrid()
    {
        Whitfield_Project _wc = new Whitfield_Project();
        DataSet _dsWorkOrders = new DataSet();
        _dsWorkOrders = _wc.GetWorkOrders(ViewState["EstNum"].ToString(), Convert.ToInt32(ViewState["twc_project_number"].ToString()));
        this.PopulateDataGrid(_dsWorkOrders);
    }

    public void PopulateDataGrid(DataSet dsGridResults)
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
                if (resultCount > (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize)
                    maxResultItemInPage = (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdpl1.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdpl1.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdpl1.Visible = true;
                grdpl1.DataSource = tblInstallments;
                grdpl1.DataBind();
            }
            else
            {
                grdpl1.Visible = false;
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

    public void grdpl1_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfield_Project _wc = new Whitfield_Project();
        _wc.DeleteWorkOrders(DetailId, ViewState["twc_project_number"].ToString());
        this.DisplayGrid();
    }
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        //Response.Write("Comes In");
        String DetailId = "";

        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfield_Project _wc = new Whitfield_Project();

        _wc.UpdateWorkorders(DetailId, Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtMatCost"))).Text), (((TextBox)(e.Item.FindControl("txtLongDesc1"))).Text).ToString(), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtfabhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtfinhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtinstallhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtEngHours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtMiscHours"))).Text), (((TextBox)(e.Item.FindControl("txtNotes"))).Text).ToString(), "1");

        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid();
    }
    public void grd1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalFabHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblfabhours"))).Text);
            TotalfinHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblfinhours"))).Text);
            TotalInstallHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblinstallhours"))).Text);
            TotalEngHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblEnghours"))).Text);
            TotalMiscHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMiscHours"))).Text);
            TotalMatCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatCost"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = "Total($):";
            e.Item.Cells[2].Text = TotalMatCost.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[3].Text = TotalFabHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[4].Text = TotalfinHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = TotalInstallHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].Text = TotalEngHours.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[7].Text = TotalMiscHours.ToString();
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;
        }
    }
    #endregion Work Order Functions

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

    #region Manpower Activity Datagrid
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
            TotalManHours += Convert.ToDecimal(((Label)(e.Item.FindControl("lblinstallhours"))).Text);
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
    #endregion

    private void DisplaySchedulingGrid()
    {
 
        Whitfieldcore wc = new Whitfieldcore();
        DataSet _dsScheduling = new DataSet();
        lblTotScheduledHours.Text = wc.GetTotalscheduledHours(twc_project_number);
        if (wc.IsScheduleDataExists(Convert.ToInt32(ViewState["twc_project_number"].ToString())))
        {
            pnlActSchedule.Visible = true;
            _dsScheduling = wc.GetScheduleListing(ViewState["twc_project_number"].ToString());
            this.PopulateDataGrid(_dsScheduling, grdSchedule);
        }
        
    }
    private void DisplayHistoryNotes()
    {
         
        Whitfieldcore wc = new Whitfieldcore();
        DataSet _dsNotes = new DataSet();
        _dsNotes = wc.GetNotes(Convert.ToInt32(twc_project_number));
        this.PopulateDataGrid(_dsNotes, grdWeeklyNotes);
    }
    private void FetchSehedule()
    {
        txtSchhours.Text = "";
        txtWeeklyComments.Text = "";
        Whitfieldcore wc = new Whitfieldcore();
        DataSet ds = new DataSet();
        ds = wc.GetScheduleData(Convert.ToInt32(ViewState["twc_project_number"].ToString()), ddlYear.SelectedItem.Value.ToString(), ddlMonth.SelectedItem.Value.ToString() + "(" + ddlYear.SelectedItem.Value.ToString() + ")", ddlWeek.SelectedItem.Value.ToString());
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
                    String _hr = dRow["Hours"] != DBNull.Value ? dRow["Hours"].ToString() : "";
                    String _comments = dRow["weeklyNotes"] != DBNull.Value ? dRow["weeklyNotes"].ToString() : "";
                    //String project_amount = dRow["project_amount"] != DBNull.Value ? dRow["project_amount"].ToString() : "";
                    txtSchhours.Text = _hr;
                    txtWeeklyComments.Text = _comments;
                    //txtProjectedAmt.Text = project_amount;
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
            txtSchhours.Text = "0";
            txtWeeklyComments.Text = "";
        }
    }

    protected void btnProdSchedule_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        DataSet ds = new DataSet();
        if (!ViewState["Construction_Start_Date"].ToString().Equals("") && !ViewState["Construction_End_Date"].ToString().Equals(""))
        {
            ds = wc.GetSchedule(ViewState["Construction_Start_Date"].ToString(), ViewState["Construction_End_Date"].ToString());
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
                            wc.PopulateSchedule(Convert.ToInt32(ViewState["twc_project_number"].ToString()), _yr, _mnth + "(" + _yr + ")", hash[key].ToString(), iCnt, "0");
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
    protected void btnSaveHours_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        try
        {
            Boolean isValidEntry = wc.MaintainScheduledata(Convert.ToInt32(ViewState["twc_project_number"].ToString()), ddlYear.SelectedItem.Value.ToString(), ddlMonth.SelectedItem.Value.ToString() + "(" + ddlYear.SelectedItem.Value.ToString() + ")", ddlWeek.SelectedItem.Value.ToString(), Convert.ToInt32(txtSchhours.Text.Trim()), txtWeeklyComments.Text.Trim(), Convert.ToInt32(lblTotAnnFabHours.Text.Trim()),"0");
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
    protected void btnsaveparameters_Click(object sender, EventArgs e)
    {
        Whitfield_Project wc = new Whitfield_Project();
        try
        {
            Boolean IsUpdateSuccess = false;
            IsUpdateSuccess = wc.UpdateCostUpdates(
                ViewState["EstNum"].ToString(),
                ViewState["twc_project_number"].ToString(),
                txtOrigContract.Text.Trim(),
                txtChangeOrder.Text.Trim()
               );

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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

    protected void btnMail_Click(object sender, EventArgs e)
    {
        //Add Email Function here.
        sendEmail();
    }

    public void sendEmail()
    {
        Whitfieldcore wCore = new Whitfieldcore();
        whitfield_reports _wRep = new whitfield_reports();
        MailMessage message = new MailMessage();

        message.To.Add(System.Configuration.ConfigurationManager.AppSettings["devEmail"]);

        //Here is where we add the receipients.
        using (DataSet ds = wCore.GetRightDistributionList(Convert.ToInt32(ViewState["twc_project_number"].ToString())) )  //HHS Uncomment this portion when there is an email list.
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
