using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class addclient : System.Web.UI.Page
{
    private const Int16 _DEFAULTPAGESIZE = 10;
    Int32 _clientNum;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            BindState();
            BindClientTypes();
            BindCities("");
            // 1
            // Get collection
            NameValueCollection n = Request.QueryString;
            // 2
            // See if any query string exists
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);

                // 4
                // Test different keys
                if (k == "IsNew")
                {
                    if (v == "Y")
                    {
                        _clientNum = _wc.GenerateClientID();
                        ViewState["ClientNum"] = _clientNum.ToString();
                        //ddlEstimator.SelectedIndex = ddlEstimator.Items.IndexOf(ddlEstimator.Items.FindByValue(Request.Cookies["UserId"].Value.Trim()));
                    }
                    else
                    {
                        v = n.Get(1);
                        ViewState["ClientNum"] = v.ToString();
                        FetchAndBind(Convert.ToInt32(v));
                    }
                }

                hidclient.Value = ViewState["ClientNum"].ToString();
                // bind the datagrid for contacts for client
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
        }
    }

    #region UI Methods
    public string ShowEditImage(object ClientID, object ContactID)
    {
        return "<a ID='ViewNotes' href=\"javascript:ShowEdit('" + ClientID.ToString().Trim() + "','" + ContactID.ToString().Trim() + "');\"" + ">" +
            "<img src='" + Page.ResolveUrl("assets/img/edit.gif") + "' align='absmiddle' border='0' ID='ImageCheckBox'/></a>";
    }
    #endregion

    #region Fetch and Bind
    public void FetchAndBind(Int32 _clientNumber)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        IDataReader iReader = _wc.GetClientInfo(_clientNumber);
        // ' Loop through the DataReader and write out each entry        
        while (iReader.Read())
        {
            txtclientname.Text = iReader["Name"] == DBNull.Value ? "" : iReader["Name"].ToString();
            String cType = iReader["ClientType"] == DBNull.Value ? "" : iReader["ClientType"].ToString();
            ddlClientType.SelectedIndex = ddlClientType.Items.IndexOf(ddlClientType.Items.FindByValue(cType.ToString()));
            txtstreet.Text = iReader["Street"] == DBNull.Value ? "" : iReader["Street"].ToString();
            String City = iReader["City"] == DBNull.Value ? "" : iReader["City"].ToString();
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(City.ToString()));
            String Statecd = iReader["State"] == DBNull.Value ? "" : iReader["State"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Statecd.ToString()));
            txtPhNumber.Text = iReader["Phone"] == DBNull.Value ? "" : iReader["Phone"].ToString();
            txtFaxNumber.Text = iReader["Fax"] == DBNull.Value ? "" : iReader["Fax"].ToString();
            txtFTP.Text = iReader["Web"] == DBNull.Value ? "" : iReader["Web"].ToString();
            txtLogin.Text = iReader["login"] == DBNull.Value ? "" : iReader["login"].ToString();
            txtPass.Text = iReader["pw"] == DBNull.Value ? "" : iReader["pw"].ToString();
            txtWeb.Text = iReader["Web"] == DBNull.Value ? "" : iReader["Web"].ToString();
            txtNotes.Text = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
        }
    }

    #endregion 
    private void BindState()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetStatelist();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlState.DataSource = dsGrp;
            ddlState.DataTextField = "StateCD";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, common.AddItemToList("Select State", ""));

        }
    }
    private void BindCities(String StateCD)
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetCityList(StateCD);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlCity.DataSource = dsGrp;
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, common.AddItemToList("Select City", ""));

        }
    }
    private void BindClientTypes()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wc = new Whitfieldcore();
        dsGrp = wc.GetClientTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

          ddlClientType.DataSource = dsGrp;
          ddlClientType.DataTextField = "ClientType";
          ddlClientType.DataValueField = "ClientTypeID";
          ddlClientType.DataBind();
          ddlClientType.Items.Insert(0, common.AddItemToList("Client Types", "0"));

        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = wc.ManageClients(Convert.ToInt32(ViewState["ClientNum"].ToString()),
                txtclientname.Text.Trim(),
                Convert.ToInt32(ddlClientType.SelectedItem.Value),
                txtstreet.Text.Trim(),
                Convert.ToInt32(ddlCity.SelectedItem.Value),
                Convert.ToInt32(ddlState.SelectedItem.Value),
                txtPhNumber.Text.Trim(),
                txtFaxNumber.Text.Trim(),
                txtWeb.Text.Trim(),
                txtFTP.Text.Trim(),
                txtLogin.Text.Trim(),
                txtPass.Text.Trim(),
                txtNotes.Text.Trim());
            if (IsInsertSuccess)
            {
                lblMsg.Text = "Client is Successfully saved";
            }
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
            dsRpAdvances = _wc.GetContactsForClient(Convert.ToInt32(ViewState["ClientNum"].ToString()));
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
                txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " contacts(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                txtSelectionResultsMSG.Text = "No Contacts Setup yet.";
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
