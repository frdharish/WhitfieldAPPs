using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Configuration;

public partial class production_schedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = wc.GetSchedule("01/01/2010", "08/01/2010");
            Int32 resultCount = 0;

            if (ds.Tables.Count > 0)
                resultCount = ds.Tables[0].Rows.Count;

            DataTable myControls;
            myControls = ds.Tables[0];
            Int32 iCnt = 1;
            if (myControls.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dRow in myControls.Rows)
                    {
                        Hashtable hash = wc.GetWeeksHash();
                        String _yr = dRow["dt2"] != DBNull.Value ? dRow["dt2"].ToString() : "";
                        String _mnth = dRow["dt1"] != DBNull.Value ? dRow["dt1"].ToString() : "";
                        foreach (string key in hash.Keys)
                        {
                            //+ '(' + [fycd] + ')'
                            wc.PopulateSchedule(1, _yr, _mnth + "(" + _yr + ")", hash[key].ToString(),iCnt,"0");
                            //passs
                            //_yr
                            //_mnth
                            //hash[key].ToString()
                            //ProjectNumber to the Maintainschedule
                        }
                        iCnt++;
                    }
                    Response.Write("setup Completed.");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Write("No Data");

            }


        }
    }
}
