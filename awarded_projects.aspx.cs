using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;

public partial class awarded_projects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            BindAwardedProjects();
        }
    }
    private void BindAwardedProjects()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wProjects = new Whitfieldcore();
        dsGrp = wProjects.GetProjectInfo("", "", "5");
        if (dsGrp.Tables[0].Rows.Count > 0)
        {

            RdoAwdProjects.DataSource = dsGrp;
            RdoAwdProjects.DataTextField = "ProjName";
            RdoAwdProjects.DataValueField = "EstNum";
            RdoAwdProjects.DataBind();
        }
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Int32 twc_prj_number=0;
        String EstNum = "";
        Whitfield_Project wUser = new Whitfield_Project();
       // wUser.DeleteProjectClient(Convert.ToInt32(ViewState["EstNum"].ToString()));
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        for (int i = 0; i < RdoAwdProjects.Items.Count; i++)
        {
            if (RdoAwdProjects.Items[i].Selected)
            {
                EstNum = RdoAwdProjects.Items[i].Value.ToString();
                twc_prj_number = wUser.SetUpProjecs(Convert.ToInt32(RdoAwdProjects.Items[i].Value));
            }
        }
        //Server.Transfer("Whitfield_projectInfo.aspx?EstNum=" + EstNum + "&twc_project_number=" + twc_prj_number.ToString());
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_projectInfo.aspx?EstNum=" + EstNum + "&twc_project_number=" + twc_prj_number.ToString() + "');</script>");
    }
}
