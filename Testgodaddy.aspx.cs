using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Testgodaddy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        whitfielduser wUser = new whitfielduser();
        DataSet dsUser = wUser.GetUserRecord("admin");
        DataTable myControls;
        myControls = dsUser.Tables[0];
        if (myControls.Rows.Count > 0)
        {
            try
            {
                foreach (DataRow dRow in myControls.Rows)
                {
                    Response.Write(dRow["FirstName"].ToString() + " " + dRow["LastName"].ToString());
                    Response.Write(dRow["LoginId"].ToString().Trim());
                    Response.Write(dRow["EmployeeNo"].ToString().Trim());
                    Response.Write( dRow["RoleId"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                HttpResponse objResponse = HttpContext.Current.Response;
                objResponse.Write(ex.Message);
            }
        }

    }
}
