using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class worker_maintenance : System.Web.UI.Page
{
    public Int32 EstNum;
    public Int32 twcProjectNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        whitfielduser _wuser = new whitfielduser();
        if (!Page.IsPostBack)
        {
            Bindstates();
            BindEmplyeeType();
            // 1 Get collection
            NameValueCollection n = Request.QueryString;
            // 2 See if any query string exists
            if (n.HasKeys())
            {
                // 3 Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                string v1 = n.Get(1);
                // 4
                // Test different keys
                EstNum = Convert.ToInt32(v);
                twcProjectNumber = Convert.ToInt32(v1);
                hidEstNum.Value = EstNum.ToString();
                hidtwcProjNumber.Value = twcProjectNumber.ToString();
            }
            ViewState["EstNum"] = EstNum;
            ViewState["twcProjectNumber"] = twcProjectNumber;
            this.DisplayManPowerGrid();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        whitfielduser wUser = new whitfielduser();
        Boolean isInsert = wUser.ManageWorkers(txtfn.Text.Trim(),
                                             txtln.Text.Trim(),
                                             txtaddress.Text.Trim(),
                                             txtCity.Text.Trim(),
                                             ddlstate.SelectedItem.Value,
                                             txtrate.Text.Trim(),
                                             Convert.ToInt32(ddlEmplyType.SelectedItem.Value),
                                             txtSSN.Text.Trim(),
                                             Request.Cookies["UserId"].Value
                                             );
        if (Request.Cookies["RoleId"].Value == "5")
                Response.Write("<script language='javascript'>parent.location.replace('InstallerReports.aspx?EstNum=" + ViewState["EstNum"].ToString() + "&twc_project_number=" + ViewState["twcProjectNumber"].ToString() + "');</script>");
        else
                Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInfo.aspx?EstNum=" + ViewState["EstNum"].ToString() + "&twc_project_number=" + ViewState["twcProjectNumber"].ToString() + "');</script>");
    }
    protected void BindEmplyeeType()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetEmplyeeTypesNOPM();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlEmplyType.DataSource = dsGrp;
            ddlEmplyType.DataTextField = "installer_type_name";
            ddlEmplyType.DataValueField = "installer_type_id";
            ddlEmplyType.DataBind();
            ddlEmplyType.Items.Insert(0, common.AddItemToList("Select Emplyee Type", ""));

        }
    }

    protected DataSet FetchEmplyeeTypes()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetEmplyeeTypesNOPM();
        return dsGrp;
    }
    protected  DataSet FetchStates()
    {
        DataSet dsStates = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsStates = wUser.GetStates();
        return dsStates;
    }
    private void Bindstates()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetStates();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlstate.DataSource = dsGrp;
            ddlstate.DataTextField = "State";
            ddlstate.DataValueField = "statecd";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, common.AddItemToList("All", ""));

        }
    }

    #region DataGrid for ManPower maintenance

    private void DisplayManPowerGrid()
    {
        whitfielduser _wUser = new whitfielduser();
        DataSet _dsRep = new DataSet();


        if (Request.Cookies["RoleId"].Value == "5")
            _dsRep = _wUser.FetchWorkersForInstaller(Request.Cookies["UserId"].Value);
        else
            _dsRep = _wUser.FetchAllWorkers();


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
                if (maxResultItemInPage - (grdManPower.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdManPower.PageSize - 1);
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
        whitfielduser _wRep = new whitfielduser();
        String worker_id = "";
        worker_id = grdManPower.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        _wRep.DeleteWorkerRecord(worker_id);
        this.DisplayManPowerGrid();
    }

    public void grdManPower_UpdateCommand(object sender, DataGridCommandEventArgs e)
    {
        String ManPower_id = "";
        ManPower_id = grdManPower.DataKeys[Convert.ToInt32(e.Item.ItemIndex)].ToString();
        whitfielduser _wRep = new whitfielduser();
        _wRep.UpdateWorkers(Convert.ToInt32(ManPower_id), ((TextBox)(e.Item.FindControl("txtfirstname"))).Text, ((TextBox)(e.Item.FindControl("txtlastname"))).Text, ((TextBox)(e.Item.FindControl("txtStreet"))).Text, ((TextBox)(e.Item.FindControl("txtCity"))).Text, ((DropDownList)(e.Item.FindControl("ddlstate"))).SelectedItem.Value, ((TextBox)(e.Item.FindControl("txtRate"))).Text, Convert.ToInt32(((DropDownList)(e.Item.FindControl("ddlworker_type"))).SelectedItem.Value), ((TextBox)(e.Item.FindControl("txtssn"))).Text, Request.Cookies["UserId"].Value.Trim());
        grdManPower.EditItemIndex = -1;
        grdManPower.ShowFooter = true;
        this.DisplayManPowerGrid();
    }
    #endregion Manpower Maintenance.
}
