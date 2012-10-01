using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
public partial class maintaincontact : System.Web.UI.Page
{
    Int32 _clientNum;
    Int32 _contactID;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            BindTitles();
            BindState();
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
                string v = n.Get(0);  //For Edit v= 'E'

                // 4
                // Test different keys
                if (k == "clientid")
                {
                    _contactID = _wc.GenerateContactID();
                    _clientNum = Convert.ToInt32(v);
                    ViewState["ClientNum"] = _clientNum.ToString();
                    ViewState["ContactID"] = _contactID.ToString();
                    FetchFromClient(_clientNum);
                }
                else
                {
                    String v1 = n.Get(1);
                    _contactID = Convert.ToInt32(v);
                    _clientNum = Convert.ToInt32(v1);
                    ViewState["ContactID"] = _contactID.ToString();
                    ViewState["ClientNum"] = _clientNum.ToString();
                    FetchAndBind(Convert.ToInt32(_contactID.ToString()));
                }
            }
            hidclient.Value = ViewState["ClientNum"].ToString();
        }
    }
    #region Fetch and Bind
    public void FetchFromClient(Int32 _clientNum)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        IDataReader iReader = _wc.GetClientInfo(_clientNum);
        while (iReader.Read())
        {
            txttele.Text = iReader["Phone"] == DBNull.Value ? "" : iReader["Phone"].ToString();
            txtFax.Text = iReader["Fax"] == DBNull.Value ? "" : iReader["Fax"].ToString();
            txtAddress.Text = iReader["Street"] == DBNull.Value ? "" : iReader["Street"].ToString();
            String City = iReader["City"] == DBNull.Value ? "" : iReader["City"].ToString();
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(City.ToString()));
            String Statecd = iReader["State"] == DBNull.Value ? "" : iReader["State"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Statecd.ToString()));
            //txtzip.Text = iReader["Zip"] == DBNull.Value ? "" : iReader["Zip"].ToString();            
        }

    }
    public void FetchAndBind(Int32 _contactNumber)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        IDataReader iReader = _wc.GetContactInfo(_contactNumber);
        // ' Loop through the DataReader and write out each entry 
        //ContactID
        //ClientID 
        //First 
        //Last 
        //Title 
        //Tel 
        //Ext 
        //Email ,
        //Notes 
        //Address 
        //City 
        //State 
        //Zip
        while (iReader.Read())
        {

            txtcontactfname.Text = iReader["First"] == DBNull.Value ? "" : iReader["First"].ToString();
            txtcontactlname.Text = iReader["Last"] == DBNull.Value ? "" : iReader["Last"].ToString();
            //txttitle.Text = iReader["Title"] == DBNull.Value ? "" : iReader["Title"].ToString();
            String title = iReader["Title"] == DBNull.Value ? "" : iReader["Title"].ToString();
            ddltitle.SelectedIndex = ddltitle.Items.IndexOf(ddltitle.Items.FindByValue(title.ToString()));
            txttele.Text = iReader["Tel"] == DBNull.Value ? "" : iReader["Tel"].ToString();
            txtextn.Text = iReader["Ext"] == DBNull.Value ? "" : iReader["Ext"].ToString();
            txtEmail.Text = iReader["Email"] == DBNull.Value ? "" : iReader["Email"].ToString();
            txtAddress.Text = iReader["Address"] == DBNull.Value ? "" : iReader["Address"].ToString();
            String City = iReader["City"] == DBNull.Value ? "" : iReader["City"].ToString();
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(City.ToString()));
            String Statecd = iReader["State"] == DBNull.Value ? "" : iReader["State"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Statecd.ToString()));
            txtzip.Text = iReader["Zip"] == DBNull.Value ? "" : iReader["Zip"].ToString();
            txtNotes.Text = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
        }
    }

    #endregion 
    private void BindTitles()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetListtitles();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddltitle.DataSource = dsGrp;
            ddltitle.DataTextField = "Title";
            ddltitle.DataValueField = "TitleID";
            ddltitle.DataBind();
            ddltitle.Items.Insert(0, common.AddItemToList("Select Title", ""));

        }
    }

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
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = wc.ManageContacts(Convert.ToInt32(ViewState["ContactID"].ToString()),
                Convert.ToInt32(ViewState["ClientNum"].ToString()),
                txtcontactfname.Text.Trim(),
                txtcontactlname.Text.Trim(),
                ddltitle.SelectedItem.Value,
                txttele.Text.Trim(),
                txtextn.Text.Trim(),
                txtEmail.Text.Trim(),
                txtNotes.Text.Trim(),
                txtAddress.Text.Trim(),
                ddlCity.SelectedItem.Value,
                ddlState.SelectedItem.Value,
                txtzip.Text.Trim()
                );
            if (IsInsertSuccess)
            {
                //Response.Redirect("addclient.aspx?IsNew=N&hClientID=" + ViewState["ClientNum"].ToString());

                //Response.Write("<script language='javascript'>parent.agreewin.hide();</script>");
                
                lblMsg.Text = "Client is Successfully saved";
            }
        }
    }
}
