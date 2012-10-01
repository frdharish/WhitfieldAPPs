using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class archmain : System.Web.UI.Page
{
    Int32 _ArchID;
    protected void Page_Load(object sender, EventArgs e)
    {
                Whitfieldcore _wc = new Whitfieldcore();
                if (!Page.IsPostBack)
                {
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
                        string v = n.Get(0);

                        // 4
                        // Test different keys
                        if (k == "IsNew")
                        {
                            if (v == "Y")
                            {
                                _ArchID = _wc.GenerateArchID();
                                ViewState["_ArchID"] = _ArchID.ToString();
                            }
                            else
                            {
                                v = n.Get(1);
                                ViewState["_ArchID"] = v.ToString();
                                FetchAndBind(Convert.ToInt32(v));
                            }
                        }

                        //hidclient.Value = ViewState["ClientNum"].ToString();
                    }
                }
    }

    #region Fetch and Bind
    public void FetchAndBind(Int32 _ArchID)
    {
        //[Architect] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[City] [int] NULL,
        //[State] [int] NULL,
        //[Zip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[Fax] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[Web] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //[Notes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL

        Whitfieldcore _wc = new Whitfieldcore();
        IDataReader iReader = _wc.GetArchitectInfo(_ArchID);
        // ' Loop through the DataReader and write out each entry        
        while (iReader.Read())
        {
            txtclientname.Text = iReader["Architect"] == DBNull.Value ? "" : iReader["Architect"].ToString();
            txtstreet.Text = iReader["Address"] == DBNull.Value ? "" : iReader["Address"].ToString();
            String City = iReader["City"] == DBNull.Value ? "" : iReader["City"].ToString();
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(City.ToString()));
            String Statecd = iReader["State"] == DBNull.Value ? "" : iReader["State"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Statecd.ToString()));
            txtZipcode.Text = iReader["Zip"] == DBNull.Value ? "" : iReader["Zip"].ToString();
            txtPhNumber.Text = iReader["Phone"] == DBNull.Value ? "" : iReader["Phone"].ToString();
            txtFaxNumber.Text = iReader["Fax"] == DBNull.Value ? "" : iReader["Fax"].ToString();
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
    private void BindCities(string StateCD)
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
            IsInsertSuccess = wc.ManageArchitects(Convert.ToInt32(ViewState["_ArchID"].ToString()),
                txtclientname.Text.Trim(),
                txtstreet.Text.Trim(),
                Convert.ToInt32(ddlCity.SelectedItem.Value),
                Convert.ToInt32(ddlState.SelectedItem.Value),
                txtZipcode.Text.Trim(),
                txtPhNumber.Text.Trim(),
                txtFaxNumber.Text.Trim(),
                txtWeb.Text.Trim(),
                txtNotes.Text.Trim());
            if (IsInsertSuccess)
            {
                lblMsg.Text = "Architect is Successfully saved";
            }
        }
    }
}
