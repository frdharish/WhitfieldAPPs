using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class whitfield_users_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        whitfielduser _wuser = new whitfielduser();
        if (!Page.IsPostBack)
        {
            Bindroles();
            Bindstates();
            BindEmplyeeType();
            if (Request.QueryString["hFlag"] == "E")
            {
                DataSet dsUser = _wuser.GetUserRecord(Request.QueryString["hUserid"]);
                DataTable dtUsr = dsUser.Tables[0];
                foreach (DataRow dRow in dtUsr.Rows)                    
                {
                    txtfn.Text = dRow["FirstName"].ToString(); 
                    txtln.Text = dRow["LastName"].ToString(); 
                    txtem.Text = dRow["email_address"].ToString(); 
                    txtEmpNo.Text = dRow["EmployeeNo"].ToString(); 
                    txtaddress.Text = dRow["Address"].ToString();
                    txtphno.Text = dRow["ContactNo1"].ToString();
                    BindCitiesforState(dRow["state"].ToString());
                    ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByValue(dRow["state"].ToString()));
                    ddlcity.SelectedIndex = ddlcity.Items.IndexOf(ddlcity.Items.FindByValue(dRow["city"].ToString()));
                    txtzip.Text = dRow["zip"].ToString(); 
                    txtuserid.Text = dRow["Loginid"].ToString(); 
                    txtpasswd.Text = dRow["password"].ToString();
                    ddlrole.SelectedIndex = ddlrole.Items.IndexOf(ddlrole.Items.FindByValue(dRow["roleid"].ToString()));
                    ddlEmplyType.SelectedIndex = ddlEmplyType.Items.IndexOf(ddlEmplyType.Items.FindByValue(dRow["empl_type_id"].ToString()));
                    txtrate.Text = dRow["hourly_rate"].ToString();
                }
              
            }
            else
            {
                txtuserid.ReadOnly = false;
            }

        }

    }
    #region Bind Drop down


    private void BindEmplyeeType()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetEmplyeeTypes();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

           ddlEmplyType.DataSource = dsGrp;
           ddlEmplyType.DataTextField = "empl_type_name";
           ddlEmplyType.DataValueField = "empl_type_id";
           ddlEmplyType.DataBind();
           ddlEmplyType.Items.Insert(0, common.AddItemToList("Select Emplyee Type", ""));

        }
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
    private void Bindroles()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetAllRoles();
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlrole.DataSource = dsGrp;
            ddlrole.DataTextField = "Name";
            ddlrole.DataValueField = "RoleId";
            ddlrole.DataBind();
            ddlrole.Items.Insert(0, common.AddItemToList("All", ""));

        }
    }

    private void BindCitiesforState()
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetCitiesForStates(ddlstate.SelectedItem.Value.Trim());
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlcity.DataSource = dsGrp;
            ddlcity.DataTextField = "city";
            ddlcity.DataValueField = "Cityid";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, common.AddItemToList("All", ""));

        }
    }
    private void BindCitiesforState(String statecd)
    {
        DataSet dsGrp = new DataSet();
        whitfielduser wUser = new whitfielduser();
        dsGrp = wUser.GetCitiesForStates(statecd);
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            ddlcity.DataSource = dsGrp;
            ddlcity.DataTextField = "city";
            ddlcity.DataValueField = "Cityid";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, common.AddItemToList("All", ""));

        }
    }
    #endregion
    protected void btnnew_Click(object sender, EventArgs e)
    {
        whitfielduser wUser = new whitfielduser();
        Boolean isInsert = wUser.ManageUsers(txtfn.Text.Trim(),
                                             txtln.Text.Trim(),
                                             txtaddress.Text.Trim(),
                                             ddlcity.SelectedItem.Value,
                                             ddlstate.SelectedItem.Value,
                                             txtzip.Text.Trim(),
                                             txtphno.Text.Trim(),
                                             txtuserid.Text.Trim(),
                                             txtpasswd.Text.Trim(),
                                             txtEmpNo.Text.Trim(),
                                             "1",
                                             txtem.Text.Trim(),
                                             txtrate.Text.Trim(),
                                             ddlrole.SelectedItem.Value,
                                             Convert.ToInt32(ddlEmplyType.SelectedItem.Value)
                                             );
        Response.Redirect("whitfield_users.aspx");

    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCitiesforState();
    }
}
