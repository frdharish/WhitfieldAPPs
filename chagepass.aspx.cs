using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chagepass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        whitfielduser wUser = new whitfielduser();
        if (wUser.IsUserExists(txtloginid.Text.Trim(),txtoldpasswd.Text.Trim()))
        {
            if (wUser.ChangePass(txtloginid.Text.Trim(), txtnewpasswd.Text.Trim()))
            {
                lblErrMsg.Text = "Your Password is successfully changed, please close the window and login";
            }
            else
            {
                lblErrMsg.Text = "Please check your userid and password.";
            }

        }
        else
        {
            lblErrMsg.Text = "Please check your Userid and Password and try again.";
        }
    }
}
