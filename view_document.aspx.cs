using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
 
public partial class view_document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        // 1
        // Get collection
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            // See if any query string exists
            if (n.HasKeys())
            {
                // 3
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                string v1 = n.Get(1);
                ShowTheFile(v.ToString(), v1.ToString());
            }
        }
    }

    private void ShowTheFile(String EstNum, String seqNum)
    {
        // Define SQL select statement

        string SQL = "SELECT document,doc_mime_type from Project_documents WHERE EstNum = " + EstNum.ToString() + " AND seq_num = " + seqNum.ToString();
        // Create Connection object
        SqlConnection dbConn = null;
        dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString);
        // Create Command Object
        SqlCommand dbComm = new SqlCommand(SQL, dbConn);
        // Open Connection
        dbConn.Open();
        // Execute command and receive DataReader
        SqlDataReader dbRead = dbComm.ExecuteReader();
        // Read row
        dbRead.Read();
        // Clear Response buffer
        Response.Clear();
        // Set ContentType to the ContentType of our file
        Response.ContentType = (string)dbRead["doc_mime_type"];
        Response.BinaryWrite((byte[])dbRead["document"]);
        // Write data out of database into Output Stream
        //Response.OutputStream.Write((byte[])dbRead["ABSTRACT_DOCUMENT"], 0, (int)dbRead["CONTENT_SIZE"]);
        // Close database connection
        dbConn.Close();
        // End the page
        Response.End();
    }
}
