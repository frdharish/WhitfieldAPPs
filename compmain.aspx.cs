using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class compmain : System.Web.UI.Page
{
    Int32 _compeID;
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
                        _compeID = _wc.GenerateCompeID();
                        ViewState["_compeID"] = _compeID.ToString();
                        //ddlEstimator.SelectedIndex = ddlEstimator.Items.IndexOf(ddlEstimator.Items.FindByValue(Request.Cookies["UserId"].Value.Trim()));
                    }
                    else
                    {
                        v = n.Get(1);
                        ViewState["_compeID"] = v.ToString();
                        FetchAndBind(Convert.ToInt32(v));
                    }
                }

                hidcompe.Value = ViewState["_compeID"].ToString();
            }
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

    #region Fetch and Bind
    public void FetchAndBind(Int32 _compeID)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        IDataReader iReader = _wc.GetCompetitorInfo(_compeID);
        // ' Loop through the DataReader and write out each entry        
        while (iReader.Read())
        {
            txtclientname.Text = iReader["Name"] == DBNull.Value ? "" : iReader["Name"].ToString();
            String City = iReader["City"] == DBNull.Value ? "" : iReader["City"].ToString();
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(ddlCity.Items.FindByValue(City.ToString()));
            String Statecd = iReader["State"] == DBNull.Value ? "" : iReader["State"].ToString();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(Statecd.ToString()));
            txtWeb.Text = iReader["Web"] == DBNull.Value ? "" : iReader["Web"].ToString();
            txtNotes.Text = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
            txtlaborRate.Text = iReader["LaborRate"] == DBNull.Value ? "" : iReader["LaborRate"].ToString();
            txtOverHead.Text = iReader["OverheadBurden"] == DBNull.Value ? "" : iReader["OverheadBurden"].ToString();
        }
    }

    #endregion 
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        if (Page.IsValid)
        {
            Boolean IsInsertSuccess = false;
            IsInsertSuccess = wc.ManageCompetition(
                 Convert.ToInt32(ViewState["_compeID"].ToString()),
                 txtclientname.Text.Trim(),
                 txtWeb.Text.Trim(), 
                 0,
                 txtNotes.Text.Trim(),
                 Convert.ToInt32(ddlCity.SelectedItem.Value),
                 Convert.ToInt32(ddlState.SelectedItem.Value),
                 txtlaborRate.Text.Trim(),
                 txtOverHead.Text.Trim(),
                 ""
                );
            if (IsInsertSuccess)
            {
                lblMsg.Text = "Competition is Successfully saved";
            }
        }
    }
}
