using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

public partial class testgodaddy1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("testing the connection");
        DataSet dsUser = GetUserRecord("admin");
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
                    Response.Write(dRow["RoleId"].ToString().Trim());
                }
                Response.Write("connection succeeded");
            }
            catch (Exception ex)
            {
                HttpResponse objResponse = HttpContext.Current.Response;
                objResponse.Write(ex.Message);
            }
        }
    }
    public DataSet GetUserRecord(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.* , b.RoleId from [User] a , UserRole b Where a.loginid = b.loginid AND  a.loginid = @loginid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }
}
