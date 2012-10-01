using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class whitfieldmain : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.ForeColor = System.Drawing.Color.Maroon;
        lblUser.Text = Request.Cookies["Name"].Value.ToUpper();
        lblServer.Text = HttpContext.Current.Server.MachineName.Trim();
        Response.CacheControl = "no-cache";
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "-1");

        if (!Page.IsPostBack)
        {
                    
                
                if (Request.Cookies["RoleId"].Value == "1")
                    
                        pnladmin.Visible = true;

                if (Request.Cookies["RoleId"].Value == "2")
                        pnlEstimator.Visible = true;

                if (Request.Cookies["RoleId"].Value == "3")

                        pnlpuser.Visible = true;

                if (Request.Cookies["RoleId"].Value == "5")

                  pnlInstaller.Visible = true;
        }

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}
