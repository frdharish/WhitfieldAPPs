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
using System.IO;
using System.Collections;
public partial class whitfield_estimation : System.Web.UI.Page
{
    private Int32 TotalEngHours = 0;    
    private Int32 TotalFabHours = 0;
    private Int32 TotalfinHours = 0;
    private Int32 TotalInstallHours = 0;
    private Int32 TotalMiscHours = 0;
    private Decimal TotalMatCost = 0;
    private Decimal TotalPrice = 0;
    private Decimal _contAmt = 0;

    private Decimal Grandlabor = 0;
    private Decimal GrandContDisp = 0;
    private Decimal GrandCont = 0;
    private Decimal GrandTotal = 0;
    private Decimal GrandOverHead = 0;
    private Decimal GrandProfit = 0;
    private Decimal GrandSellPrice = 0;


   // private Decimal Totalprice = 0;
    private Decimal Grandprice = 0;

    private const Int16 _DEFAULTPAGESIZE = 250;
    Int32 EstNum;
    public void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        // 1
        // Get collection
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            //tabWhitfieldParms
            if (Request.Cookies["RoleId"].Value == "2")
            {
                tabconsideration.HeaderText = "";
                tabconsideration.Visible = false;
            }
            // See if any query string exists
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);

                if (Request.QueryString["hFlag"] == "D")
                {
                    _wc.DeleteProjDocument(Convert.ToInt32(Request.QueryString["EstNum"]), Convert.ToInt32(Request.QueryString["seqno"]));
                    ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                    DataSet dsGridResults = this.GetDocs();
                    this.PopulateDataGrid(dsGridResults, grddocs);        
                }

                if (Request.QueryString["hFlag"] == "DMaterial")
                {
                    _wc.DeleteSubMaterialsFromEstimation(Convert.ToInt32(Request.QueryString["EstNum"]), Convert.ToInt32(Request.QueryString["submatid"]));
                    _wc.DELETEMaterialinWorkOrder(Convert.ToInt32(Request.QueryString["EstNum"]), Convert.ToInt32(Request.QueryString["submatid"]));
                    ViewState["EstNum"] = Request.QueryString["EstNum"].ToString();
                    DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(Request.QueryString["EstNum"]));
                    this.PopulateDataGrid(dsGridMaterials,grdEstimateMaterials);
                }

                // 4
                // Test different keys
                if (k == "createNew")
                {
                    EstNum = _wc.GenerateEstNum();
                    ViewState["EstNum"] = EstNum.ToString();
                    bindcontrols(EstNum);
                    ddlEstimator.SelectedIndex = ddlEstimator.Items.IndexOf(ddlEstimator.Items.FindByValue(Request.Cookies["UserId"].Value.Trim()));

                }

                if (k == "EstNum")
                {
                    EstNum = Convert.ToInt32(v);  // Here goes the code for the creation of new EstNum
                    ViewState["EstNum"] = EstNum;
                    this.FetchAndBind(EstNum);
                }

            }
            else
            {
                if (n.HasKeys())
                {
                    string k = n.GetKey(0);
                    string v = n.Get(0);
                    if (k == "EstNum")
                    {
                        EstNum = Convert.ToInt32(v);  // Here goes the code for the creation of new EstNum
                        ViewState["EstNum"] = EstNum;
                        this.FetchAndBind(EstNum);
                    }
                }
                else
                {
                    EstNum = Convert.ToInt32(ViewState["EstNum"].ToString());
                    this.FetchAndBind(EstNum);
                }
            }

            Response.Cookies["EstNum"].Value = EstNum.ToString();
            hdnEstNum.Value = EstNum.ToString();

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

            try
            {
                grdcompe.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.Project_competition();
                this.PopulateDataGrid(dsGridResults, grdcompe);
            }

            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }
            //***
            try
            {
                grdcompe.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.GetConversationLog();
                this.PopulateDataGrid(dsGridResults, grdConvHist);
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }

            //EmailLog
            try
            {
                grdEmailLog.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.GetEmailLog();
                this.PopulateDataGrid(dsGridResults,grdEmailLog);
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }

            //GetDocumentsforProject
            try
            {
                grdcompe.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridResults;
                dsGridResults = this.GetDocs();
                this.PopulateDataGrid(dsGridResults, grddocs);
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }

            //GetMaterialsForEstimates
            try
            {
                grdEstimateMaterials.PageSize = _DEFAULTPAGESIZE;
                DataSet dsGridMaterials;
                dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(ViewState["EstNum"].ToString()));
                this.PopulateDataGrid(dsGridMaterials,grdEstimateMaterials);
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message.ToString());
            }
        }
        else
        {
            pHprojClient.Visible = true;
            pHprojcompe.Visible = true;
        }
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

    public string Showdocument(object EstNum, object seqnumber,object docname)
    {
        return "<a ID='ViewNotes' href=\"javascript:showdocument('" + EstNum.ToString().Trim() + "','" + seqnumber.ToString().Trim() + "');\"" + ">" + docname.ToString().Trim() + "</a>";
    }
    #endregion

    public string DeleteDocument(object EstNum, object seqnumber)
    {

        return "<a ID='DeleteDocs' href=\"javascript:Deletedocument('" + EstNum.ToString().Trim() + "','" + seqnumber.ToString().Trim() + "');\"" + ">Delete</a>";
    }

    public string DeleteMaterial(object EstNum, object sub_mat_id)
    {

        return "<a ID='DeleteDocs' href=\"javascript:DeleteMaterial('" + EstNum.ToString().Trim() + "','" + sub_mat_id.ToString().Trim() + "');\"" + ">Delete</a>";
    }



    public void bindcontrols(Int32 _estNum)
    {
        BindProjectType();
        BindArch();
        BindEstimators();
        if (Request.Cookies["RoleId"].Value == "2")
        {
            ddlEstimator.Enabled = false;
        }
        //BindClientinfo(_estNum);
        BindWinClientinfo(_estNum);
        //BindCompSet(_estNum);
        BindWinCompSet(_estNum);
        BindProjectStatus();
        BindTerms(_estNum);
        //BindInternationTerms(_estNum);
        DisplayGrid();
        BindGenCond(_estNum);
        //BindSpecExcl(_estNum);
        BindDocumentTypes();
        BindContingency(_estNum);
        BindDrawingList(_estNum);
        BindAmendmentList(_estNum);
        BindAlternatives(_estNum);
        BindItemBreakDown(_estNum);
        BindTypeOfWork();
    }
    public void FetchAndBind(Int32 _estNum)
    {
        if (Request.Cookies["RoleId"].Value == "1")
        {
            btnDelete.Visible = true;
        }

        pHprojClient.Visible = true;
        pHprojcompe.Visible = true;
        Whitfieldcore _wc = new Whitfieldcore();
        bindcontrols(_estNum);
        IDataReader iReader = _wc.GetProjectInfo(_estNum);
        // ' Loop through the DataReader and write out each entry        
        while (iReader.Read())
        {
            //lstbidclient
            //lstcompe
            
            txtprjname.Text = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
            lblPrjHeader.Text = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
            txtbasebid.Text  = iReader["BaseBid"] == DBNull.Value ? "" : iReader["BaseBid"].ToString();
            txtfinalbid.Text = iReader["FinalPrice"] == DBNull.Value ? "" : iReader["FinalPrice"].ToString();
            txtdesc.Text = iReader["ProjDescr"] == DBNull.Value ? "" : iReader["ProjDescr"].ToString();
            txtNotes.Text = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
            txtBidDate.Text = iReader["BidDate"] == DBNull.Value ? "" : iReader["BidDate"].ToString();
            txtEditStartTime.Text = iReader["BidTime"] == DBNull.Value ? "" : iReader["BidTime"].ToString();
            txtARD.Text = iReader["AwardDur"] == DBNull.Value ? "" : iReader["AwardDur"].ToString();
            txtawardDate.Text = iReader["AwardDate"] == DBNull.Value ? "" : iReader["AwardDate"].ToString();
            txtConstStdate.Text = iReader["ConstrStart"]== DBNull.Value ? "" : iReader["ConstrStart"].ToString();
            txtConstDuration.Text = iReader["ConstrDur"] == DBNull.Value ? "" : iReader["ConstrDur"].ToString();
            txtConstEndDate.Text = iReader["ConstrCompl"] == DBNull.Value ? "" : iReader["ConstrCompl"].ToString();

            //Adding New Fields
            txtfabEndDate.Text = iReader["fab_end"] == DBNull.Value ? "" : iReader["fab_end"].ToString();
            txtfabStartdate.Text = iReader["fab_start"] == DBNull.Value ? "" : iReader["fab_start"].ToString();
            txtfabduration.Text = iReader["fab_duration"] == DBNull.Value ? "" : iReader["fab_duration"].ToString();
            txtStreet.Text = iReader["prj_street"] == DBNull.Value ? "" : iReader["prj_street"].ToString();
            txtCity.Text = iReader["prj_city"] == DBNull.Value ? "" : iReader["prj_city"].ToString();
            txtState.Text = iReader["prj_state"] == DBNull.Value ? "" : iReader["prj_state"].ToString();
            txtzip.Text = iReader["prj_zip"] == DBNull.Value ? "" : iReader["prj_zip"].ToString();
            //New Fields Ends

            txtrealprjNumber.Text = iReader["Real_proj_Number"] == DBNull.Value ? "" : iReader["Real_proj_Number"].ToString();
            String wincompe = iReader["WinMill"] == DBNull.Value ? "" : iReader["WinMill"].ToString();
            String winclient = iReader["WinClient"] == DBNull.Value ? "" : iReader["WinClient"].ToString();
            String prjstatus = iReader["Status"] == DBNull.Value ? "" : iReader["Status"].ToString();
            String prjType = iReader["ProjType"] == DBNull.Value ? "" : iReader["ProjType"].ToString(); ;
            String prjArch = iReader["Architect"] == DBNull.Value ? "" : iReader["Architect"].ToString();
            String prjEsti = iReader["loginid"] == DBNull.Value ? "" : iReader["loginid"].ToString();
            ddlwoncompe.SelectedIndex = ddlwoncompe.Items.IndexOf(ddlwoncompe.Items.FindByValue(wincompe.ToString()));
            ddlwonclient.SelectedIndex = ddlwonclient.Items.IndexOf(ddlwonclient.Items.FindByValue(winclient.ToString()));
            ddlPrjStatus.SelectedIndex = ddlPrjStatus.Items.IndexOf(ddlPrjStatus.Items.FindByValue(prjstatus.ToString()));
            ddlprjtype.SelectedIndex = ddlprjtype.Items.IndexOf(ddlprjtype.Items.FindByValue(prjType.ToString()));
            ddlarchitect.SelectedIndex = ddlarchitect.Items.IndexOf(ddlarchitect.Items.FindByValue(prjArch.ToString()));
            ddlEstimator.SelectedIndex = ddlEstimator.Items.IndexOf(ddlEstimator.Items.FindByValue(prjEsti.ToString()));
            if (ddlPrjStatus.SelectedItem.Value == "5")
            {
                txtrealprjNumber.ReadOnly = false;
            }
            //txtTotCont.Text = iReader["Contengency"] == DBNull.Value ? "0" : iReader["Contengency"].ToString();
           
            txtTotCotCost.Text = iReader["Contengency"] == DBNull.Value ? "0" : iReader["Contengency"].ToString();

            txtEngRate.Text = iReader["enghourrate"] == DBNull.Value ? "45.00" : iReader["enghourrate"].ToString();
            txtFabRate.Text = iReader["fabhourrate"] == DBNull.Value ? "39.00" : iReader["fabhourrate"].ToString();
            txtInstRate.Text = iReader["insthourrate"] == DBNull.Value ? "45.00" : iReader["insthourrate"].ToString();
            txtMiscRate.Text = iReader["mischourrate"] == DBNull.Value ? "25.00" : iReader["mischourrate"].ToString();
            txtOverHeadRate.Text = iReader["overheadrate"] == DBNull.Value ? "24.11" : iReader["overheadrate"].ToString();
            txtMarkUpPercent.Text = iReader["profit_markup"] == DBNull.Value ? "15.00" : iReader["profit_markup"].ToString();

            txtDrawingDt.Text = iReader["drawingdate"] == DBNull.Value ? "" : iReader["drawingdate"].ToString();
            String TypeOfWork = iReader["typeofwork"] == DBNull.Value ? "" : iReader["typeofwork"].ToString();
            ddlTypeofWork.SelectedIndex = ddlTypeofWork.Items.IndexOf(ddlTypeofWork.Items.FindByValue(TypeOfWork.ToString()));

        }
        //Populate Parameters
        txtTotMatCost.Text = _wc.GetMaterialCost(_estNum).ToString();
        txtMatContTotal.Text = (_wc.GetMaterialCost(_estNum) + Convert.ToInt32(txtTotCotCost.Text)).ToString();
        DataSet dsNormal = _wc.GetBudgetHoursForEstimation(_estNum.ToString());
        DataTable dtNormal = dsNormal.Tables[0];
        foreach (DataRow dRow in dtNormal.Rows)
        {
            txtEngQty.Text = dRow["eng_hours"] == DBNull.Value ? "0" : dRow["eng_hours"].ToString();
            txtEngTotal.Text = (Convert.ToInt32(txtEngQty.Text) * Convert.ToDecimal(txtEngRate.Text)).ToString();
            String fabQty = dRow["fab_hours"] == DBNull.Value ? "0" : dRow["fab_hours"].ToString();
            String finQty = dRow["fin_hours"] == DBNull.Value ? "0" : dRow["fin_hours"].ToString();
            txtFabQty.Text = (Convert.ToInt32(fabQty) + Convert.ToInt32(finQty)).ToString();
            txtFabTotal.Text = (Convert.ToInt32(txtFabQty.Text) * Convert.ToDecimal(txtFabRate.Text)).ToString();
            txtInsQty.Text = dRow["install_hours"] == DBNull.Value ? "0" : dRow["install_hours"].ToString();
            txtInsTotal.Text = (Convert.ToInt32(txtInsQty.Text) * Convert.ToDecimal(txtInstRate.Text)).ToString();
            txtMiscQty.Text = dRow["misc_hours"] == DBNull.Value ? "0" : dRow["misc_hours"].ToString();
            txtMiscTotal.Text = (Convert.ToInt32(txtMiscQty.Text) * Convert.ToDecimal(txtMiscRate.Text)).ToString();
           // lblbudtot.Text = dRow["TotHours"] == DBNull.Value ? "0" : dRow["TotHours"].ToString();
        }
        if (txtEngQty.Text == "0" && txtFabQty.Text == "0" && txtInsQty.Text == "0" && txtMiscQty.Text == "0")
        {
            txtTotRate.Text = "0.00";
        }
        else
        {
            txtTotRate.Text = (Convert.ToDecimal(txtEngTotal.Text) + Convert.ToDecimal(txtFabTotal.Text) + Convert.ToDecimal(txtInsTotal.Text) + Convert.ToDecimal(txtMiscTotal.Text)).ToString("#.##");
        }
       
       if (txtTotRate.Text == "0.00")
       {
           lblOHPercent.Text = "0.00";
           lblOverHeadTotal.Text = "0.00";
           lblProfitTotal.Text = ((Convert.ToDecimal(txtMarkUpPercent.Text)/100) * Convert.ToDecimal(txtMatContTotal.Text)).ToString("#.##");
           //lblProfitTotal.Text = (Convert.ToDecimal(_wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100 *  Convert.ToInt32(txtMatContTotal.Text)).ToString("#.##");
           lblTotalOverHeadProfitPercent.Text = Convert.ToDecimal(txtMarkUpPercent.Text).ToString();
           //lblTotalOverHeadProfitPercent.Text = Convert.ToDecimal(_wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString()))).ToString();
           //lblTotalOverHeadProfit.Text = (Convert.ToDecimal(lblProfitTotal.Text)).ToString("#.##");
           lblTotalOverHeadProfit.Text = lblProfitTotal.Text;
           lblTotSellPrice.Text = (Convert.ToDecimal(txtMatContTotal.Text) + Convert.ToDecimal(lblTotalOverHeadProfit.Text)).ToString();
       }
       else
       {
           
           //Overhead = (Total Labor + total Material + Contingency)* Overhead percent
          // Response.Write("OverheadRate= " + _wc.GetOverHeadPercent(Convert.ToInt32(ViewState["EstNum"].ToString())));
          // Response.Write("TotRate+matcont= " + (Convert.ToDecimal(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text)).ToString("#.##"));
           //Response.Write("OverheadTotal= " + ((Convert.ToDecimal(_wc.GetOverHeadPercent(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100 * (Convert.ToDecimal(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text)))).ToString("#.##"));
           
           
           //lblOverHeadTotal.Text = ((Convert.ToDecimal(_wc.GetOverHeadPercent(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100 * (Convert.ToDecimal(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text)))).ToString("#.##");
           lblOverHeadTotal.Text = (Convert.ToDecimal(txtOverHeadRate.Text) * (Convert.ToInt32(txtEngQty.Text) + Convert.ToInt32(txtFabQty.Text) + Convert.ToInt32(txtMiscQty.Text))).ToString("#.##");
           
           
           
           if (txtOverHeadRate.Text == "0")
           {
               lblOverHeadTotal.Text = "0";
               lblOHPercent.Text = "0";
           }
           else
           {
               lblOverHeadTotal.Text = (Convert.ToDecimal(txtOverHeadRate.Text) * (Convert.ToInt32(txtEngQty.Text) + Convert.ToInt32(txtFabQty.Text) + Convert.ToInt32(txtMiscQty.Text))).ToString("#.##");
               lblOHPercent.Text = ((Convert.ToDecimal(lblOverHeadTotal.Text) / (Convert.ToDecimal(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text))) * 100).ToString("#.##");
           }

           
           lblProfitTotal.Text = (Convert.ToDecimal(txtMarkUpPercent.Text) / 100 * (Convert.ToInt32(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text) + Convert.ToDecimal(lblOverHeadTotal.Text))).ToString("#.##");
           //lblProfitTotal.Text = ((Convert.ToDecimal(_wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100 * (Convert.ToInt32(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text) + Convert.ToDecimal(lblOverHeadTotal.Text)))).ToString("#.##");
           
           lblTotalOverHeadProfitPercent.Text = (Convert.ToDecimal(lblOHPercent.Text) + Convert.ToDecimal(txtMarkUpPercent.Text)).ToString("#.##");
           //lblTotalOverHeadProfitPercent.Text = (Convert.ToDecimal(lblOHPercent.Text) + Convert.ToDecimal(_wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString())))).ToString("#.##");
           
           lblTotalOverHeadProfit.Text = (Convert.ToDecimal(lblOverHeadTotal.Text) + Convert.ToDecimal(lblProfitTotal.Text)).ToString("#.##");
           lblTotSellPrice.Text = (Convert.ToInt32(txtTotRate.Text) + Convert.ToDecimal(txtMatContTotal.Text) + Convert.ToDecimal(lblTotalOverHeadProfit.Text)).ToString();
       }

    }

    #region Bind Drop downs

    private void BindTypeOfWork()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("Fabrication and Installation", "Fabrication and Installation");
        hTable.Add("Fabrication", "Fabrication");
        hTable.Add("Fabrication, Packaging & Delivery", "Fabrication, Packaging & Delivery");
        hTable.Add("Installation", "Installation");
        hTable.Add("Design", "Design");
        hTable.Add("Design and Fabrication", "Design and Fabrication");
        hTable.Add("Design, Fabrication and Installation", "Design, Fabrication and Installation");
        hTable.Add("Time & Material", "Time & Material");
        ddlTypeofWork.DataSource = hTable;
        ddlTypeofWork.DataTextField = "value";
        ddlTypeofWork.DataValueField = "key";
        ddlTypeofWork.DataBind();
        //ddlTypeofWork.Items.Insert(0, common.AddItemToList("Select Project type", "Select Project type"));
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
           ddlEstimator.Items.Insert(0, common.AddItemToList("Select Estimator", "0"));

        }
    }

    private void BindWinClientinfo(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetClientlistForProject(EstNum.ToString());
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlwonclient.DataSource = dsGrp;
            ddlwonclient.DataTextField = "Name1";
            ddlwonclient.DataValueField = "ClientID";
            ddlwonclient.DataBind();
            ddlwonclient.Items.Insert(0, common.AddItemToList("Select", "0"));

        }
        else
        {
            ddlwonclient.Items.Insert(0, common.AddItemToList("No Clients Yet", "0"));
        }
    }

    
    private void BindWinCompSet(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetCompetitors(EstNum);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

           ddlwoncompe.DataSource = dsGrp;
           ddlwoncompe.DataTextField = "Name1";
           ddlwoncompe.DataValueField = "Compeid";
           ddlwoncompe.DataBind();
           ddlwoncompe.Items.Insert(0, common.AddItemToList("Select", "0"));

        }
        else
        {
            ddlwoncompe.Items.Insert(0, common.AddItemToList("No Competition Added", "0"));
        }
    }

    private void BindDocumentTypes()
    {
        //GetAllDocTypes
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllDocTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

           ddlDocType.DataSource = dsGrp;
           ddlDocType.DataTextField = "doc_Type_Desc";
           ddlDocType.DataValueField = "doc_type_id";
           ddlDocType.DataBind();
            //ddlPrjStatus.Items.Insert(0, common.AddItemToList("All", "0"));

        }
    }

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
           //ddlPrjStatus.Items.Insert(0, common.AddItemToList("All", "0"));

        }
    }


    #region Item BreakDown List

    public Hashtable Bindamendment_types()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("Amendment", "Amendment");
        hTable.Add("Modification", "Modification");
        hTable.Add("Addendums", "Addendums");
        hTable.Add("RFI", "RFI");
        hTable.Add("Clarification", "Clarification");
        hTable.Add("Other", "Other");
        return hTable;
    }


    public Hashtable BindDDLDefaults()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("ADD", "ADD");
        hTable.Add("DEDUCT", "DEDUCT");
        return hTable;
    }
    private void BindItemBreakDown(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        contingency wUser = new contingency();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.FetchProjectItemBreakdown(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdItemBreakDown);
        }
    }

    public void grdItemBreakDown_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdItemBreakDown.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.DeleteProjectItemBreakdown(Convert.ToInt32(DetailId));
        //BindItemBreakDown(Convert.ToInt32(ViewState["EstNum"].ToString()));
        Server.Transfer("whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString());
    }

    public void grdItemBreakDown_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdItemBreakDown.ShowFooter = true;
        grdItemBreakDown.EditItemIndex = -1;
        BindItemBreakDown(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    public void grdItemBreakDown_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdItemBreakDown.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.UPDATEProjectItemBreakdown(Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtIno"))).Text.ToString(), ((TextBox)(e.Item.FindControl("txtIdesc"))).Text.ToString(), ((TextBox)(e.Item.FindControl("txtIAmount"))).Text.ToString());
        grdItemBreakDown.EditItemIndex = -1;
        grdItemBreakDown.ShowFooter = true;
        BindItemBreakDown(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    public void grdItemBreakDown_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdItemBreakDown.ShowFooter = false;
        grdItemBreakDown.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        BindItemBreakDown(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    #endregion Item BreakDown List

    #region alternatives List
    private void BindAlternatives(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        contingency wUser = new contingency();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.FetchAlternatives(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdalternatives);
        }
    }
    public void grdalternatives_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdalternatives.ShowFooter = false;
        grdalternatives.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        BindAlternatives(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    public void grdalternatives_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdalternatives.ShowFooter = true;
        grdalternatives.EditItemIndex = -1;
        BindAlternatives(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    public void grdalternatives_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdalternatives.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.Deletealternatives(Convert.ToInt32(DetailId));
        BindAlternatives(Convert.ToInt32(ViewState["EstNum"].ToString()));
        //Server.Transfer("whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString());
    }
    public void grdalternatives_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdalternatives.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.UPDATEAlternatives(Convert.ToInt32(DetailId), ((DropDownList)(e.Item.FindControl("ddlType"))).SelectedItem.Value, ((TextBox)(e.Item.FindControl("txtAlternate_number"))).Text, ((TextBox)(e.Item.FindControl("txtdesc"))).Text, ((TextBox)(e.Item.FindControl("txtAmount"))).Text);
        grdalternatives.EditItemIndex = -1;
        grdalternatives.ShowFooter = true;
        BindAlternatives(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    #endregion alternatives List


    #region Drawing List
    private void BindDrawingList(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        contingency wUser = new contingency();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.FetchDrawingList(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdDrawingList);
        }
    }

    public void grdDrawingList_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdDrawingList.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.DeleteDrawingList(Convert.ToInt32(DetailId));
        BindDrawingList(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    #endregion Drawing List

    #region Amendment List
    private void BindAmendmentList(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        contingency wUser = new contingency();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.FetchAmendmenList(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdAmendments);
        }
    }


    public void grdAmendments_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdAmendments.ShowFooter = false;
        grdAmendments.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        BindAmendmentList(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    public void grdAmendments_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdAmendments.ShowFooter = true;
        grdAmendments.EditItemIndex = -1;
        BindAmendmentList(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    public void grdAmendments_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdAmendments.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.UpdateAmendmentList(Convert.ToInt32(DetailId), ((DropDownList)(e.Item.FindControl("ddlamendment_type"))).SelectedItem.Value, ((TextBox)(e.Item.FindControl("txtamendment_number"))).Text, ((TextBox)(e.Item.FindControl("txtamendment_date"))).Text, ((TextBox)(e.Item.FindControl("txtIamendment_impact"))).Text, ((TextBox)(e.Item.FindControl("txtInotes"))).Text);
        grdAmendments.EditItemIndex = -1;
        grdAmendments.ShowFooter = true;
        BindAmendmentList(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    public void grdAmendments_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdAmendments.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        contingency _wc = new contingency();
        _wc.DeleteAmendmentList(Convert.ToInt32(DetailId));
         BindAmendmentList(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    #endregion Amendment List

    #region Contingency Data Management
    private void BindContingency(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.GetContingency(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdContingency);
        }
    }

     

    public void grdContingency_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdContingency.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.DeleteContingencyRecord(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(DetailId));
        BindContingency(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    public void grdContingency_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        grdContingency.ShowFooter = false;
        grdContingency.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        BindContingency(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    public void grdContingency_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        grdContingency.ShowFooter = true;
        grdContingency.EditItemIndex = -1;
        BindContingency(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }
    public void grdContingency_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";

        DetailId = grdContingency.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.UpdateContingencyRecord(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(DetailId), ((TextBox)(e.Item.FindControl("txtqty"))).Text.ToString(), ((TextBox)(e.Item.FindControl("txtcost"))).Text.ToString());
        grdContingency.EditItemIndex = -1;
        grdContingency.ShowFooter = true;
        BindContingency(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }


    public void grdContingency_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        String DetailId = "";

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DetailId = grdContingency.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
            ((Label)(e.Item.FindControl("lblTotCost"))).Text = (Convert.ToDecimal(((Label)(e.Item.FindControl("lblqty"))).Text) * Convert.ToDecimal(((Label)(e.Item.FindControl("lblCost"))).Text.Trim())).ToString("00.00");
            //Totalprice += Convert.ToDecimal(((Label)(e.Item.FindControl("lblCost"))).Text.Trim());
            Grandprice += Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotCost"))).Text.Trim());
           
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            txtTotCont.Text = Math.Floor(Grandprice).ToString();
            _wc.UpdateContengency(ViewState["EstNum"].ToString(), Convert.ToInt32(Math.Floor(Grandprice).ToString().Trim()));
            e.Item.Cells[2].Text = "Total:";
            e.Item.Cells[2].ForeColor = System.Drawing.Color.Green;
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //e.Item.Cells[3].Text = TotalPrice.ToString("00.00");
            //e.Item.Cells[3].ForeColor = System.Drawing.Color.Green;
            //e.Item.Cells[3].Font.Bold = true;
            //e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = Grandprice.ToString("00.00");
            e.Item.Cells[5].ForeColor = System.Drawing.Color.Green;
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
           
            
        }
    }
    #endregion Contingency Data management

    public void grdTerms_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdTerms.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.DeleteTerm(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(DetailId));
        BindTerms(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    private void BindTerms(Int32 EstNum)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        DataSet dsTerms = new DataSet();
        dsTerms = wUser.GetTerms(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdTerms); 
        }
    }

    public void grdQuals_DeleteCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdQuals.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.DeleteQualifications(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(DetailId));
        BindGenCond(Convert.ToInt32(ViewState["EstNum"].ToString()));
    }

    private void BindGenCond(Int32 EstNum)
    { 
        DataSet dsTerms = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsTerms = wUser.GetSpecExcl(EstNum);
        if (dsTerms.Tables[0].Rows.Count > 0)
        {
            this.PopulateDataGrid(dsTerms,grdQuals); 
        }
    }

    
    #endregion 

    protected void btnDel_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.DeleteEstimateRecords(Convert.ToInt32(ViewState["EstNum"].ToString()));
        Server.Transfer("SearchProjects.aspx");
    }
    protected void btnDrawingDate_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            //lblTotSellPrice.text.  this goes to the baseBid in the ProjectInfo
            IsInsertSuccess = _wc.UpdateDrawingDate(ViewState["EstNum"].ToString(), txtDrawingDt.Text.Trim());
            lblMsg.Text = "Your record is added successfully.";
            Server.Transfer("whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString());
        }
    }

    protected void btnsaverefresh_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            //lblTotSellPrice.text.  this goes to the baseBid in the ProjectInfo
            IsInsertSuccess = _wc.UpdateParameters(ViewState["EstNum"].ToString(), Convert.ToDecimal(txtEngRate.Text.Trim()), Convert.ToDecimal(txtFabRate.Text.Trim()), Convert.ToDecimal(txtInstRate.Text.Trim()), Convert.ToDecimal(txtMiscRate.Text.Trim()), Convert.ToDecimal(txtOverHeadRate.Text.Trim()), Convert.ToDecimal(txtMarkUpPercent.Text.Trim()), Convert.ToDecimal(lblOHPercent.Text.Trim()), lblTotSellPrice.Text.Trim(), ddlTypeofWork.SelectedItem.Value);
            lblMsg.Text = "Your record is added successfully.";
            Server.Transfer("whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString());
        }
    }

    protected void btnnew_Click(object sender, EventArgs e)
    {
        String PrjNumber = "0";
        if (txtrealprjNumber.Text.Trim() == "")
        {
            PrjNumber = "0";
        }
        else
        {
            PrjNumber = txtrealprjNumber.Text.Trim();
        }
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = _wc.InsertEstimateMain(ViewState["EstNum"].ToString(),
                txtprjname.Text.Trim(),
                txtdesc.Text.Trim(),
                txtNotes.Text.Trim(),
                ddlprjtype.SelectedItem.Value,
                txtBidDate.Text.Trim(),
                txtEditStartTime.Text.Trim(),
                txtawardDate.Text.Trim(),
                txtARD.Text.Trim(),
                txtConstStdate.Text.Trim(),
                txtConstEndDate.Text.Trim(),
                txtConstDuration.Text.Trim(),
                "0",
                ddlPrjStatus.SelectedItem.Value,
                "0",
                ddlwonclient.SelectedItem.Value,
                ddlwoncompe.SelectedItem.Value,
                txtfinalbid.Text.Trim(),
                txtbasebid.Text.Trim(),
                "N",
                ddlarchitect.SelectedItem.Value,
                "Y",
                "Y",
                ddlEstimator.SelectedItem.Value, PrjNumber.Trim(),txtfabStartdate.Text.Trim(),txtfabEndDate.Text.Trim(),txtfabduration.Text.Trim(),txtStreet.Text.Trim(),txtCity.Text.Trim(),txtState.Text.Trim(),txtzip.Text.Trim());
            lblMsg.Text = "Your record is added successfully.";
        }
    }

    protected void btncon_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            _wc.UpdateContengency(ViewState["EstNum"].ToString(), Convert.ToInt32(txtTotCont.Text.Trim()));
        }
        Server.Transfer("whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString());
    }
    protected void btnconsider_Click(object sender, EventArgs e)
    {
        //Whitfieldcore _wc = new Whitfieldcore();
        //if (Page.IsValid)
        //{
        //    if (_wc.DeleteConsideration(Convert.ToInt32(ViewState["EstNum"].ToString())))
        //    {
        //        for (int i = 0; i < ChkTerms.Items.Count; i++)
        //        {
        //            if (ChkTerms.Items[i].Selected)
        //                _wc.PopulateConsideration(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkTerms.Items[i].Value));
        //        }

        //        for (int i = 0; i < ChkIntCond.Items.Count; i++)
        //        {
        //            if (ChkIntCond.Items[i].Selected)
        //                _wc.PopulateConsideration(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(ChkIntCond.Items[i].Value));
        //        }                
        //    }
        //    lblMsg.Text = "Your record is added successfully.";
        //}
        
    }

    protected void btnqual_Click(object sender, EventArgs e)
    {
        //Whitfieldcore _wc = new Whitfieldcore();
        //if (Page.IsValid)
        //{
        //    if (_wc.DeleteQualification(Convert.ToInt32(ViewState["EstNum"].ToString())))
        //    {
        //        for (int i = 0; i < chkGenCond.Items.Count; i++)
        //        {
        //            if (chkGenCond.Items[i].Selected)
        //                _wc.PopulateQualification(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(chkGenCond.Items[i].Value));
        //        }

        //        for (int i = 0; i < chkSpecExcl.Items.Count; i++)
        //        {
        //            if (chkSpecExcl.Items[i].Selected)
        //                _wc.PopulateQualification(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(chkSpecExcl.Items[i].Value));
        //        }
        //    }
        //    lblMsg.Text = "Your record is added successfully.";
        //}

    }

    protected void btnconv_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean isInsert = false;
            isInsert = _wc.InsertConversation(Convert.ToInt32(ViewState["EstNum"].ToString()), Request.Cookies["UserId"].Value.Trim(),txtconversation.Text.Trim(),txtcmtsDate.Text.Trim(),txtcmtsTime.Text.Trim());
            DataSet dsGridResults = this.GetConversationLog();
            this.PopulateDataGrid(dsGridResults, grdConvHist);
            if (isInsert)
                lblMsg.Text = "Your record is added successfully.";
        }

    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean isInsert = false;
            isInsert = this.InsertDocument(Convert.ToInt32(ViewState["EstNum"].ToString()), ddlDocType.SelectedItem.Value , Request.Cookies["UserId"].Value.Trim(), FileUpload1.PostedFile.ContentType.Trim(),FileUpload1.PostedFile.ContentLength.ToString());
            DataSet dsGridResults = this.GetDocs();
            this.PopulateDataGrid(dsGridResults,grddocs);
            if (isInsert)
                lblMsg.Text = "Your document is added successfully.";
        }

    }

    #region Datagrid common Functions
    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdclients.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.Project_clients();
        PopulateDataGrid(dsGridResults,grdclients);

    }

    public void PageResultGrid2(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdcompe.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.Project_competition();
        PopulateDataGrid(dsGridResults,grdcompe);
    }

    public void PageResultGrid3(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdcompe.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.GetConversationLog();
        PopulateDataGrid(dsGridResults,grdConvHist);
    }

    public void PageResultGriddocs(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdcompe.CurrentPageIndex = e.NewPageIndex;
        dsGridResults = this.GetDocs();
        PopulateDataGrid(dsGridResults,grddocs);
    }

 
    private DataSet Project_clients()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetContactsForProject(Convert.ToInt32(ViewState["EstNum"].ToString()));
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
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetCompetitonForProject(Convert.ToInt32(ViewState["EstNum"].ToString()));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }

    private DataSet GetConversationLog()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetConversationLogforProject(Convert.ToInt32(ViewState["EstNum"].ToString()));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }

    private DataSet GetEmailLog()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetEmailConversationLogforProject(Convert.ToInt32(ViewState["EstNum"].ToString()));
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
        return dsRpAdvances;
    }

    private DataSet GetDocs()
    {
        DataSet dsRpAdvances = new DataSet();
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            dsRpAdvances = _wc.GetDocumentsforProject(Convert.ToInt32(ViewState["EstNum"].ToString()));
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
    #endregion

    #region Project Document Upload
    public Boolean InsertDocument(Int32 EstNum, String doc_type_id, String _userid, String doc_mime_type, String docsize)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        try
        {
            byte[] imageSize = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = FileUpload1.PostedFile;
            uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_documents(EstNum,seq_num,doc_type_id,doc_mime_type,document,docsize,doc_name, LastModifiedBy,LastModifiedDate) Values (@EstNum, @seq_num, @doc_type_id, @doc_mime_type,@document,@docsize,@docname, @userid,getdate())  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
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
    #endregion 

    public void DisplayGrid()
    {
        Whitfieldcore _wc = new Whitfieldcore();
        DataSet _dsWorkOrders = new DataSet();
        _dsWorkOrders = _wc.GetWorkOrders(ViewState["EstNum"].ToString());
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
        //String DetailId = "";
        //DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        //Whitfieldcore _wc = new Whitfieldcore();

        grdpl1.ShowFooter = false;
        grdpl1.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        //((TextBox)(e.Item.FindControl("txtMatCost"))).Text = _wc.GetTotalMaterialPriceForWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), DetailId);
        this.DisplayGrid();
        //TextBox tb1 = (TextBox)grdpl1.Items[e.Item.ItemIndex].Cells[0].FindControl("txtfabhours");
         //ClientScript.RegisterStartupScript(Type type, string key, string script)
        //ClientScript.RegisterStartupScript(this.GetType(), "focus", "<script>javascript:document.forms[0].elements['" +
        //    tb1.ClientID.ToString() + "'].focus();" + "<" + "/script>");
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
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.DeleteWorkOrders(DetailId, ViewState["EstNum"].ToString());
        _wc.DELETEMaterialinWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), DetailId);
        this.DisplayGrid();
    }
    public void grdpl1_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        //Response.Write("Comes In");
        String DetailId = "";

        DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.UpdateWorkorders(DetailId, Convert.ToInt32(((TextBox)(e.Item.FindControl("txtMatCost"))).Text), Convert.ToInt32(ViewState["EstNum"].ToString()), (((TextBox)(e.Item.FindControl("txtLongDesc1"))).Text).ToString(), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtfabhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtfinhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtinstallhours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtEngHours"))).Text), Convert.ToInt32(((TextBox)(e.Item.FindControl("txtMiscHours"))).Text), (((TextBox)(e.Item.FindControl("txtNotes"))).Text).ToString(), "1", (((TextBox)(e.Item.FindControl("txtref"))).Text).ToString());
        grdpl1.EditItemIndex = -1;
        grdpl1.ShowFooter = true;
        this.DisplayGrid();
    }
    public void grd1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        String DetailId = "";
        
        //(a.EnghourRate * b.eng_hours + a.fabhourrate * b.fab_hours + a.insthourrate * b.install_hours + a.mischourrate*b.misc_hours + a.fabhourrate*b.fin_hours) total_labor
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DetailId = grdpl1.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
            String TotMatPriceWO = _wc.GetTotalMaterialPriceForWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), DetailId);
           
            if (TotMatPriceWO == "0")
            {
                TotMatPriceWO = "1";
            }

            Decimal TotMatPriceProj = _wc.GetTotalMaterialPriceForEstimation(Convert.ToInt32(ViewState["EstNum"]));

            if (TotMatPriceProj == 0)
            {
                TotMatPriceProj = 100;
            }

            //Contingency Dispersement
            ((Label)(e.Item.FindControl("lblContDisp"))).Text = ((Convert.ToDecimal(TotMatPriceWO) / TotMatPriceProj) * 100).ToString("00.00");   
            
            //Material Cost
            ((Label)(e.Item.FindControl("lblMatCost"))).Text =    _wc.GetTotalMaterialPriceForWorkOrder(Convert.ToInt32(ViewState["EstNum"].ToString()), DetailId);

            String tmpContDisp = ((Label)(e.Item.FindControl("lblContDisp"))).Text;
            if (((Label)(e.Item.FindControl("lblContDisp"))).Text == "1")
                tmpContDisp = "0";

            //Contengency
            //Response.Write("Contengency:" + _contAmt.ToString() + " tmpContDisp:" + tmpContDisp);

            _contAmt = Convert.ToDecimal(_wc.GetContengency(Convert.ToInt32(ViewState["EstNum"].ToString())));

            String TotalContengency = (Convert.ToDecimal(_contAmt) * Convert.ToDecimal(Convert.ToDecimal(tmpContDisp) / 100)).ToString("00.00");
            ((Label)(e.Item.FindControl("lblContigency"))).Text =  TotalContengency;
            
            //Material Cost + Contingency
            ((Label)(e.Item.FindControl("lblMatPlusCont"))).Text = (Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatCost"))).Text) + Convert.ToDecimal(TotalContengency)).ToString("00.00");

            //Overhead = (Total Labor + total Material + Contingency)* Overhead percent
            //(Total Labor + total Material + Contingency)* Overhead percent
            //Response.Write("OHPercent:" + _wc.GetOverHeadPercent(Convert.ToInt32(ViewState["EstNum"].ToString())));
            //Response.Write("<br>Profit Markup:" + _wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString())));

            //Overhead = (Total Labor + total Material + Contingency)* Overhead percent
            //((Label)(e.Item.FindControl("lbloverhead"))).Text = ((Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotlabor"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatPlusCont"))).Text)) * Convert.ToDecimal(Convert.ToDecimal(_wc.GetOverHeadPercent(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100)).ToString("00.00");

            ((Label)(e.Item.FindControl("lbloverhead"))).Text = ((Convert.ToDecimal(((Label)(e.Item.FindControl("lblfinhours"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblMiscHours"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblEnghours"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblfabhours"))).Text)) * Convert.ToDecimal(((HiddenField)(e.Item.FindControl("hdntot_rate"))).Value)).ToString("00.00");
            
            //Profit = (Total Labor + Total Material + Contingency + Overhead) * profit percent
                //txtMarkUpPercent.Text.Trim()
            ((Label)(e.Item.FindControl("lblProfit"))).Text = ((Convert.ToDecimal(((Label)(e.Item.FindControl("lbloverhead"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotlabor"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatPlusCont"))).Text)) * Convert.ToDecimal(Convert.ToDecimal(_wc.GetProfitMarkUp(Convert.ToInt32(ViewState["EstNum"].ToString()))) / 100)).ToString("00.00");

            ((Label)(e.Item.FindControl("lblSellPrice"))).Text = (Convert.ToDecimal(((Label)(e.Item.FindControl("lbloverhead"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblProfit"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotlabor"))).Text) + Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatPlusCont"))).Text)).ToString("00.00");

            Grandlabor += Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotlabor"))).Text.Trim());
            GrandContDisp += Convert.ToDecimal(((Label)(e.Item.FindControl("lblContDisp"))).Text.Trim());
            GrandCont += Convert.ToDecimal(((Label)(e.Item.FindControl("lblContigency"))).Text.Trim());
            GrandTotal += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatPlusCont"))).Text.Trim());
            GrandOverHead += Convert.ToDecimal(((Label)(e.Item.FindControl("lbloverhead"))).Text.Trim());
            GrandProfit += Convert.ToDecimal(((Label)(e.Item.FindControl("lblProfit"))).Text.Trim());
            GrandSellPrice += Convert.ToDecimal(((Label)(e.Item.FindControl("lblSellPrice"))).Text.Trim());

            TotalFabHours += Convert.ToInt32(((Label)(e.Item.FindControl("lblfabhours"))).Text);
            TotalfinHours += Convert.ToInt32(((Label)(e.Item.FindControl("lblfinhours"))).Text);
            TotalInstallHours += Convert.ToInt32(((Label)(e.Item.FindControl("lblinstallhours"))).Text);
            TotalEngHours += Convert.ToInt32(((Label)(e.Item.FindControl("lblEnghours"))).Text);
            TotalMiscHours += Convert.ToInt32(((Label)(e.Item.FindControl("lblMiscHours"))).Text);
            TotalMatCost += Convert.ToDecimal(((Label)(e.Item.FindControl("lblMatCost"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[6].Text = "Item Totals:";
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[7].Text = TotalEngHours.ToString();
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[8].Text = TotalFabHours.ToString();
            e.Item.Cells[8].Font.Bold = true;
            e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[9].Text = TotalfinHours.ToString();
            e.Item.Cells[9].Font.Bold = true;
            e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[10].Text = TotalInstallHours.ToString();
            e.Item.Cells[10].Font.Bold = true;
            e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[11].Text = TotalMiscHours.ToString();
            e.Item.Cells[11].Font.Bold = true;
            e.Item.Cells[11].HorizontalAlign = HorizontalAlign.Center;
            

            e.Item.Cells[12].Text = String.Format("{0:0.##}", Decimal.Floor(Grandlabor));  
            e.Item.Cells[12].Font.Bold = true;
            e.Item.Cells[12].HorizontalAlign = HorizontalAlign.Center;

            e.Item.Cells[13].Text = String.Format("{0:0.##}", Decimal.Floor(TotalMatCost));   
            e.Item.Cells[13].Font.Bold = true;
            e.Item.Cells[13].HorizontalAlign = HorizontalAlign.Center;




            e.Item.Cells[14].Text = String.Format("{0:0.##}", Decimal.Floor(GrandCont));  
            e.Item.Cells[14].Font.Bold = true;
            e.Item.Cells[14].HorizontalAlign = HorizontalAlign.Center;

            e.Item.Cells[15].Text = String.Format("{0:0.##}", Decimal.Floor(GrandContDisp)) + "%"; 
            e.Item.Cells[15].Font.Bold = true;
            e.Item.Cells[15].HorizontalAlign = HorizontalAlign.Center;


            e.Item.Cells[16].Text = String.Format("{0:0.##}", Decimal.Floor(GrandTotal)); 
            e.Item.Cells[16].Font.Bold = true;
            e.Item.Cells[16].HorizontalAlign = HorizontalAlign.Center;

            e.Item.Cells[17].Text = String.Format("{0:0.##}", Decimal.Floor(GrandOverHead)); 
            e.Item.Cells[17].Font.Bold = true;
            e.Item.Cells[17].HorizontalAlign = HorizontalAlign.Center;


            e.Item.Cells[18].Text = String.Format("{0:0.##}", Decimal.Floor(GrandProfit));
            e.Item.Cells[18].Font.Bold = true;
            e.Item.Cells[18].HorizontalAlign = HorizontalAlign.Center;


            e.Item.Cells[19].Text = String.Format("{0:0.##}", Decimal.Floor(GrandSellPrice)); 
            e.Item.Cells[19].Font.Bold = true;
            e.Item.Cells[19].HorizontalAlign = HorizontalAlign.Center;


        }
    }
    public static string WrappableText(object source)
    {
        string nwln = Environment.NewLine;
        return source.ToString().Replace(nwln, "<br />");
    } 


    public void grdpl1_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        Int32 EstNum = 0;
        String work_order_id = "";
        DataSet dsExpand = new DataSet();
        Whitfieldcore _dbClass = new Whitfieldcore();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    EstNum = Convert.ToInt32(ViewState["EstNum"].ToString());
                    work_order_id = grdpl1.DataKeys[e.Item.ItemIndex].ToString();
                    dsExpand = _dbClass.GetMaterialForWorkOrder(EstNum, work_order_id);
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[13].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    if (dsExpand.Tables[0].Rows.Count > 0)
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).EstNum = EstNum;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).WorkOrderID = work_order_id;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(EstNum, work_order_id,dsExpand);

                        }
                        else
                        {
                            exp.Visible = false;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }
                    }
                    else
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).EstNum = EstNum;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).WorkOrderID = work_order_id;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).FetchSubMaterials(EstNum, work_order_id, dsExpand);
                        }
                        else
                        {
                            exp.Visible = false;
                            ((workorder_materials)(e.Item.FindControl("DynamicTable1"))).Visible = false;
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
    protected void ddlPrjStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrjStatus.SelectedItem.Value == "5")
        {
            txtrealprjNumber.ReadOnly = false;
        }
    }
    #region	Show Closing Tag
    public string ShowClosingTags()
    {

        return "</td></tr><tr><td colspan=\"13\">";

    }
    #endregion

    public void grdEstimateMaterials_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalPrice += Convert.ToDecimal(((Label)(e.Item.FindControl("lblTotalPrice"))).Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[7].Text = "Total:";
            e.Item.Cells[7].ForeColor = System.Drawing.Color.Green;
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[8].Text = String.Format("{0:c}", TotalPrice.ToString());
            e.Item.Cells[8].ForeColor = System.Drawing.Color.Green;
            e.Item.Cells[8].Font.Bold = true;
            e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    public void grdEstimateMaterials_EditCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        grdEstimateMaterials.ShowFooter = false;
        grdEstimateMaterials.EditItemIndex = Convert.ToInt32(e.Item.ItemIndex);
        DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(ViewState["EstNum"].ToString()));
        this.PopulateDataGrid(dsGridMaterials, grdEstimateMaterials);
    }
    public void grdEstimateMaterials_CancelCommand(object sender, DataGridCommandEventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        grdEstimateMaterials.ShowFooter = true;
        grdEstimateMaterials.EditItemIndex = -1;
        DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(ViewState["EstNum"].ToString()));
        this.PopulateDataGrid(dsGridMaterials, grdEstimateMaterials);
    }
    public void grdEstimateMaterials_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String DetailId = "";
        DetailId = grdEstimateMaterials.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        Whitfieldcore _wc = new Whitfieldcore();
        _wc.UpdateMaterialinEstimation(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(DetailId), (((TextBox)(e.Item.FindControl("txtPriceInProject"))).Text).ToString(), (((TextBox)(e.Item.FindControl("txtmatnotes"))).Text).ToString(), ((RadioButtonList)(e.Item.FindControl("chkVerified"))).SelectedItem.Value, ((RadioButtonList)(e.Item.FindControl("chkPurchased"))).SelectedItem.Value, ((RadioButtonList)(e.Item.FindControl("chkReceived"))).SelectedItem.Value);
        grdEstimateMaterials.EditItemIndex = -1;
        grdEstimateMaterials.ShowFooter = true;
        DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(ViewState["EstNum"].ToString()));
        this.PopulateDataGrid(dsGridMaterials, grdEstimateMaterials);
    }

    public String GetTotalMaterialQtyForEstimation(object EstNum, object submatid)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        String retVal = _wc.GetTotalMaterialQtyForEstimation(Convert.ToInt32(EstNum), Convert.ToInt32(submatid));
        return retVal;
    }
    public String GetTotalPrice(object EstNum, object submatid, object priceinproject)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        String retQty = _wc.GetTotalMaterialQtyForEstimation(Convert.ToInt32(EstNum), Convert.ToInt32(submatid));
        Decimal TotalMatCost = Convert.ToDecimal(retQty) * Convert.ToDecimal(priceinproject.ToString().Replace("$", "").Trim());
        return TotalMatCost.ToString();         
    }

    public static void ExportDataSetToExcel(DataSet ds, string filename)
    {
        try
        {
            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.Font.Size = 9;
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            DataSet dsRpAdvances = _wc.GetMaterialForExcelExport(Convert.ToInt32(Request.QueryString["EstNum"]));
            ExportDataSetToExcel(dsRpAdvances, "SystemListing.xls");
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnstandard_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            Boolean IsIns  = _wc.PopulateStandardMaterial(Convert.ToInt32(Request.QueryString["EstNum"]));
            DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(Request.QueryString["EstNum"]));
            this.PopulateDataGrid(dsGridMaterials, grdEstimateMaterials);
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnLEED_Click(object sender, EventArgs e)
    {
        try
        {
            Whitfieldcore _wc = new Whitfieldcore();
            Boolean IsIns = _wc.PopulateLEEDMaterial(Convert.ToInt32(Request.QueryString["EstNum"]));
            DataSet dsGridMaterials = _wc.GetMaterialForEsitmation(Convert.ToInt32(Request.QueryString["EstNum"]));
            this.PopulateDataGrid(dsGridMaterials, grdEstimateMaterials);
        }
        catch (Exception)
        {
            throw;
        }
    }


    private void ClearControls(Control control)
    {
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls(control.Controls[i]);
        }
        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else
                if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
        }
        return;
    }

    protected void btnQuote_Click(object sender, EventArgs e)
    {
        try
        {
            PDFHelper _pdfhelper = new PDFHelper();
            _pdfhelper.GeneratePDF(ViewState["EstNum"].ToString(),"N");
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnpl_Click(object sender, EventArgs e)
    {
        try
        {
            PDFHelper _pdfhelper = new PDFHelper();
            _pdfhelper.GeneratePDF(ViewState["EstNum"].ToString(), "Y");
            DataSet dsGridResults = this.GetEmailLog();
            this.PopulateDataGrid(dsGridResults, grdEmailLog);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
