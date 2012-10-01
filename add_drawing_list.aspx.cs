using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Collections.Specialized;
using System.IO;

public partial class add_drawing_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection n = Request.QueryString;
        if (!Page.IsPostBack)
        {
            if (n.HasKeys())
            {
                // Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                ViewState["EstNum"] = v.ToString();
                hidEstNum.Value = ViewState["EstNum"].ToString();
                BindDropdownGroups();
            }
        }

    }
    public void BindDropdownGroups()
    {
        //List: Drawing; Specification; Sketch; Other
        Hashtable hTable = new Hashtable();
        hTable.Add("Drawing", "Drawing");
        hTable.Add("Specification", "Specification");
        hTable.Add("Sketch", "Sketch");
        hTable.Add("Other", "Other");
        ddlType.DataSource = hTable;
        ddlType.DataTextField = "value";
        ddlType.DataValueField = "key";
        ddlType.DataBind();
        ddlType.Items.Insert(0, common.AddItemToList("Select", ""));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            contingency wIns = new contingency();
            Int32 IntFlg = wIns.PopulateDrawingList(Convert.ToInt32(ViewState["EstNum"].ToString()), ddlType.SelectedItem.Value, txtName.Text, txtNumber.Text.Trim(), txtRevision.Text.Trim(), txtfabEndDate.Text.Trim());
            Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString() + "');</script>");

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
