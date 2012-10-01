using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Net.Mail;

public partial class Whitfield_testmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sendEmail();
    }

    public void sendEmail()
    {
        MailMessage message = new MailMessage();
       // Useractions u = new Useractions();

        //If host is dev email gets set to developer, otherwise gets 
        //sent to the correct Admin configured email only HHS Feb 10
       // if (Request.UserHostName != System.Configuration.ConfigurationManager.AppSettings["hostName"])
        //{
            message.To.Add(System.Configuration.ConfigurationManager.AppSettings["devEmail"]);
        //}

        //using (IDataReader reader = u.GetMSIRAdminRecords())
        //{
        //    while (reader.Read())
        //    {
        //        message.To.Add(reader["EMAIL_ADDRESS"].ToString());
        //    }
        //}

        message.To.Add(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString());
        message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["fromEmail"]);
        message.Subject = "Testing the Whitfield company email";
        StringBuilder sb = new StringBuilder();
        sb.Append("Whitfield company email Testing." + System.Environment.NewLine + System.Environment.NewLine);


        if (Request.ServerVariables["SERVER_NAME"].Equals(System.Configuration.ConfigurationManager.AppSettings["hostName"]))
        {
            sb.Append("please visit http://" + Request.ServerVariables["SERVER_NAME"].ToString() + " to validate and activate the user." + System.Environment.NewLine + System.Environment.NewLine);
        }
        else
        {
            sb.Append("please visit http://" + Request.ServerVariables["SERVER_NAME"].ToString() + " to validate and activate the user." + System.Environment.NewLine + System.Environment.NewLine);
        }
        message.Body = sb.ToString();
        SmtpClient smtp = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp"]);
        smtp.Send(message);
    }
}
