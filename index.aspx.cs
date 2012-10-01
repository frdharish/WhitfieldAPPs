using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void LoginUser()
    {
            //[FirstName] [varchar](50) NOT NULL,
            //[LastName] [varchar](50) NOT NULL,
            //[Address] [varchar](250) NOT NULL,
            //[City] [varchar](50) NOT NULL,
            //[State] [varchar](50) NOT NULL,
            //[Zip] [varchar](50) NOT NULL,
            //[ContactNo1] [varchar](50) NOT NULL,
            //[ContactNo2] [varchar](50) NOT NULL,
            //[LoginId] [varchar](50) NOT NULL,
            //[Password] [varchar](50) NOT NULL,
            //[CreatedBy] [int] NULL,
            //[CreatedOn] [datetime] NULL,
            //[ModifiedBy] [int] NULL,
            //[ModifiedOn] [timestamp] NULL,
            //[EmployeeNo] [varchar](50) NOT NULL,
            //[IsActive] [bit] NOT NULL
        whitfielduser wUser = new whitfielduser();
        if (wUser.IsUserExists(tbUserID.Text.Trim(),tbpassword.Text.Trim()))
        {
            DataSet dsUser = wUser.GetUserRecord(tbUserID.Text.Trim());
            DataTable myControls;
            myControls = dsUser.Tables[0];
            if (myControls.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dRow in myControls.Rows)
                    {
                        Response.Cookies["useridentifier"].Value = dRow["Userid"].ToString().Trim();
                        Response.Cookies["Name"].Value = dRow["FirstName"].ToString() +" " + dRow["LastName"].ToString();
                        Response.Cookies["UserId"].Value = dRow["LoginId"].ToString().Trim();
                        Response.Cookies["EmployeeNo"].Value = dRow["EmployeeNo"].ToString().Trim();
                        Response.Cookies["RoleId"].Value = dRow["RoleId"].ToString().Trim();

                        if (dRow["RoleId"].ToString().Trim() == "5")
                            Response.Redirect("installer_projects.aspx");
                        else
                            Response.Redirect("whitfieldmain.aspx");
                    }
                }
                catch (Exception ex)
                {
                    HttpResponse objResponse = HttpContext.Current.Response;
                    objResponse.Write(ex.Message);
                }
            }

        }
        else{
            lblMsg.Text = "Check your Userid and password";
        }
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            try
            {
                this.LoginUser();
            }
            catch (Exception ex)
            {
                HttpResponse objResponse = HttpContext.Current.Response;
                objResponse.Write(ex.Message);
            }

        }   
    }
}
